Public Class ClsComunAlbFactVenta

    Public Function GenerarAlbaran(ByVal entityname As String, ByVal programid As Guid, ByVal record As DataTable, Optional ByVal MostrarLog As Boolean = True) As AlbaranLogProcess
        Dim LogAlb As New AlbaranLogProcess
        If Not record Is Nothing AndAlso record.Rows.Count > 0 Then
            Dim DtLineas As DataTable = New PedidoVentaLinea().Filter(New FilterItem("IDPedido", FilterOperator.Equal, record.Rows(0)("IDPedido")))
            If Not DtLineas Is Nothing AndAlso DtLineas.Rows.Count > 0 Then
                Dim DtChanges As DataTable = record.GetChanges
                If Not DtChanges Is Nothing AndAlso DtChanges.Rows.Count > 0 Then
                    ExpertisApp.GenerateMessage("Existen actualizaciones pendientes.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Dim IDTipoAlbaran As String = String.Empty
                    Dim p As New Parametro
                    If Length(record.Rows(0)("IDClienteDistribuidor")) > 0 Then ' AlbaranExpediciónDistribuidor
                        IDTipoAlbaran = p.TipoAlbaranExpDistribuidor()
                        If Len(IDTipoAlbaran) = 0 Then
                            ExpertisApp.GenerateMessage("El parámetro 'TIPOALB_ED' no existe o no está correctamente configurado.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) '9890
                        End If
                    ElseIf Length(record.Rows(0)("IDAlmacenEnvio")) = 0 Then ' AlbaranNormal
                        IDTipoAlbaran = p.TipoAlbaranPorDefecto()
                        If Len(IDTipoAlbaran) = 0 Then
                            ExpertisApp.GenerateMessage("El parámetro 'TIPO_ALB' no existe o no está correctamente configurado.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) '9890
                        End If
                    Else ' AlbaranDeposito  
                        IDTipoAlbaran = p.TipoAlbaranDeDeposito()
                        If Len(IDTipoAlbaran) = 0 Then
                            ExpertisApp.GenerateMessage("El parámetro 'TIPO_ALB_D' no existe o no está correctamente configurado.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) '9890
                        End If
                    End If
                    If Len(IDTipoAlbaran) > 0 Then
                        Dim Aviso As Boolean = p.PermisoExpedicion()
                        Dim Preparacion As Boolean = p.PermisoAlbaran()

                        If Aviso And Length(record.Rows(0)("FechaAviso")) = 0 Then
                            ExpertisApp.GenerateMessage("El pedido no está validado. Rellene la fecha de aviso.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Function
                        End If
                        If Preparacion And Length(record.Rows(0)("FechaPreparacion")) = 0 Then
                            ExpertisApp.GenerateMessage("El pedido no está validado. Rellene la fecha de preparación.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Function
                        End If

                        Dim fParcServ As New Filter
                        fParcServ.Add(New NumberFilterItem("IDPedido", FilterOperator.Equal, CInt(record.Rows(0)("IDPedido"))))
                        fParcServ.Add(New NumberFilterItem("Estado", FilterOperator.Equal, enumpvlEstado.pvlParcServido))
                        Dim dtLineasParcServ As DataTable = New PedidoVentaLinea().Filter(fParcServ)
                        If dtLineasParcServ.Rows.Count > 0 Then
                            ExpertisApp.GenerateMessage("El pedido contiene líneas Parcialmente Servidas, genere el Albarán desde Expediciones.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Function
                        End If

                        Dim f As New Filter
                        f.Add(New NumberFilterItem("IDPedido", FilterOperator.Equal, CInt(record.Rows(0)("IDPedido"))))
                        f.Add(New NumberFilterItem("Estado", FilterOperator.Equal, enumpvlEstado.pvlPedido))
                        Dim dtLineasPedido As DataTable = New PedidoVentaLinea().Filter(f)
                        If Not dtLineasPedido Is Nothing AndAlso dtLineasPedido.Rows.Count > 0 Then
                            'Control de fechas y contadores
                            Dim StrIDContador As String = String.Empty
                            Dim DtFechaAlbaran As Date
                            If New Parametro().ValidarCambioFechaFacturas Then
                                Dim FrmContFecha As New frmContadorFechaAlbaran
                                FrmContFecha.Fecha = record.Rows(0)("FechaPedido")
                                If FrmContFecha.ShowDialog = DialogResult.OK Then
                                    Dim FilAlbaranes As New Filter
                                    FilAlbaranes.Add("IDContador", FilterOperator.Equal, FrmContFecha.Contador)
                                    FilAlbaranes.Add("FechaAlbaran", FilterOperator.GreaterThan, IIf(Length(FrmContFecha.Fecha) > 0, FrmContFecha.Fecha, record.Rows(0)("FechaPedido")))
                                    DtFechaAlbaran = IIf(Length(FrmContFecha.Fecha) > 0, FrmContFecha.Fecha, record.Rows(0)("FechaPedido"))
                                    StrIDContador = FrmContFecha.Contador
                                    Dim DtAlbaranes As DataTable = New AlbaranVentaCabecera().Filter(FilAlbaranes)
                                    If Not DtAlbaranes Is Nothing AndAlso DtAlbaranes.Rows.Count > 0 Then
                                        ExpertisApp.GenerateMessage("No se puede generar el albarán con la fecha introducida. Existen albaranes generados posteriores a la fecha.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        Exit Function
                                    End If
                                Else : Exit Function
                                End If
                            End If

                            Dim AlbInfo(-1) As CrearAlbaranVentaInfo
                            Dim fPedidoPdte As New Filter(FilterUnionOperator.Or)
                            fPedidoPdte.Add(New NumberFilterItem("Estado", enumpvlEstado.pvlPedido))
                            For Each pedido As DataRow In dtLineasPedido.Select(fPedidoPdte.Compose(New AdoFilterComposer))
                                Dim dataInfo As New CrearAlbaranVentaInfo
                                dataInfo.IDLinea = pedido("IDLineaPedido")
                                dataInfo.Cantidad = pedido("QPedida") ' - pedido("QServida")
                                dataInfo.CantidadUD = pedido("QInterna")
                                If pedido.Table.Columns.Contains("QInterna2") AndAlso Length(pedido("QInterna2")) > 0 Then dataInfo.Cantidad2 = CDbl(pedido("QInterna2"))
                                dataInfo.IDPedido = CInt(record.Rows(0)("IDPedido"))
                                dataInfo.PedidoCliente = record.Rows(0)("PedidoCliente") & String.Empty
                                ReDim Preserve AlbInfo(AlbInfo.Length)
                                AlbInfo(AlbInfo.Length - 1) = dataInfo
                            Next

                            Dim datos As DataPrcAlbaranar
                            If DtFechaAlbaran <> cnMinDate Then
                                datos = New DataPrcAlbaranar(AlbInfo, StrIDContador, DtFechaAlbaran, IDTipoAlbaran)
                            Else : datos = New DataPrcAlbaranar(AlbInfo, StrIDContador, , IDTipoAlbaran)
                            End If
                            LogAlb = New BE.DataEngine().RunProcess(GetType(PrcAlbaranarPedidosVenta), datos)

                            If Not LogAlb Is Nothing AndAlso Not LogAlb.CreateData Is Nothing AndAlso LogAlb.CreateData.CreatedElements.Length = 1 Then
                                Dim AVC As New AlbaranVentaCabecera
                                Dim dtAvc As DataTable = AVC.SelOnPrimaryKey(LogAlb.CreateData.CreatedElements(0).IDElement)
                                If dtAvc.Rows.Count <> 0 Then
                                    Dim rwAvc As DataRow = dtAvc.Rows(0)
                                    Dim oC As Cliente = New Cliente
                                    Dim dtC As DataTable = oC.SelOnPrimaryKey(rwAvc("IDCliente"))
                                    If New Parametro().DatosTransporteAutomatico() Then

                                        Dim frmTrnspt As New frmdatostransporte
                                        frmTrnspt.SetData(rwAvc)
                                        frmTrnspt.ShowDialog()
                                        If rwAvc.RowState = DataRowState.Modified Then
                                            AVC.Update(dtAvc)
                                        End If
                                    End If

                                    If CBool(dtC.Rows(0)("GenerarDaa")) Then
                                        Dim frmDAA As frmSelectDaa = New frmSelectDaa
                                        frmDAA.IDCliente = rwAvc("IDCliente")
                                        frmDAA.DireccionDefecto(rwAvc("IDCliente"))
                                        frmDAA.IDAlbaran = rwAvc("IDAlbaran")
                                        frmDAA.ShowDialog()
                                    End If
                                End If
                                TratarLog(LogAlb, enumTipoDocumentoCreado.AlbaranVenta, MostrarLog, True)
                            End If
                        End If
                    End If
                End If
            End If
        End If
        Return LogAlb
    End Function

    Public Sub GenerarFactura(ByVal entityname As String, ByVal programid As Guid, ByVal record As DataTable)
        If Not record Is Nothing AndAlso record.Rows.Count > 0 Then
            If record.Rows(0)("Estado") <> enumavcEstadoFactura.avcFacturado Then
                If Nz(record.Rows(0)("Facturable"), 0) = 0 Then
                    ExpertisApp.GenerateMessage("El albarán no es facturable.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Dim StrIDContador As String = String.Empty
                    Dim DteFechaFactura As Date
                    Dim p As New Parametro
                    If p.ValidarCambioFechaFacturas Then
                        Dim FrmContFecha As New frmContadorFechaFactura
                        FrmContFecha.Fecha = record.Rows(0)("FechaAlbaran")
                        If FrmContFecha.ShowDialog = DialogResult.OK Then
                            Dim FilFacturas As New Filter
                            FilFacturas.Add("IDContador", FilterOperator.Equal, FrmContFecha.Contador)
                            FilFacturas.Add("FechaFactura", FilterOperator.GreaterThan, IIf(Length(FrmContFecha.Fecha) > 0, FrmContFecha.Fecha, record.Rows(0)("FechaAlbaran")))
                            DteFechaFactura = IIf(Length(FrmContFecha.Fecha) > 0, FrmContFecha.Fecha, record.Rows(0)("FechaAlbaran"))
                            StrIDContador = FrmContFecha.Contador
                            Dim DtFacturas As DataTable = New FacturaVentaCabecera().Filter(FilFacturas)
                            If Not DtFacturas Is Nothing AndAlso DtFacturas.Rows.Count > 0 Then
                                ExpertisApp.GenerateMessage("No se puede generar la factura con la fecha introducida. Existen facturas generadas posteriores a la fecha.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                            End If
                        Else : Exit Sub
                        End If
                    End If
                    If p.GestionInventarioPermanente Then
                        If record.Rows(0)("IDTipoAlbaran") <> p.TipoAlbaranDeDeposito Then
                            Dim f As New Filter
                            f.Add(New NumberFilterItem("IDAlbaran", CInt(record.Rows(0)("IDAlbaran"))))
                            f.Add(New NumberFilterItem("EstadoStock", enumavlEstadoStock.avlActualizado))
                            f.Add(New NumberFilterItem("Contabilizado", FilterOperator.NotEqual, enumContabilizado.Contabilizado))
                            Dim dtLineasAlb As DataTable = New AlbaranVentaLinea().Filter(f)
                            If dtLineasAlb.Rows.Count > 0 Then
                                ExpertisApp.GenerateMessage("Existen líneas con Stock actualizado sin Contabilizar. Revise sus datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vbNewLine)
                                Exit Sub
                            End If
                        End If
                    End If
                    If Length(record.Rows(0)("IDAlbaran")) > 0 Then
                        If record.Rows(0)("TipoFacturacion") = enummcTipoFacturacion.mcGeneral Then
                            Dim BlnNSerie As Boolean = ExpertisApp.ExecuteTask(Of Integer, Boolean)(AddressOf AlbaranVentaCabecera.ComprobarNumerosSerieAlbaran, CInt(record.Rows(0)("IDAlbaran")))
                            If BlnNSerie Then
                                If Length(StrIDContador) = 0 Then
                                    Dim FrmContFecha As New frmContadorFechaFactura
                                    FrmContFecha.Fecha = record.Rows(0)("FechaAlbaran")
                                    FrmContFecha.Cliente = record.Rows(0)("IDCliente")
                                    If FrmContFecha.ShowDialog = DialogResult.OK Then
                                        StrIDContador = FrmContFecha.Contador
                                        DteFechaFactura = IIf(Length(FrmContFecha.Fecha) > 0, FrmContFecha.Fecha, record.Rows(0)("FechaAlbaran"))
                                    Else : Exit Sub
                                    End If
                                End If
                                If ExpertisApp.GenerateMessage("Se procederá a crear una Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                    Dim datos As New DataPrcFacturacionGeneral(New Integer() {record.Rows(0)("IDAlbaran")}, StrIDContador, DteFechaFactura)
                                    Dim BEDataEngine As New BE.DataEngine
                                    Dim Propuesta As ResultFacturacion = BEDataEngine.RunProcess(GetType(PrcFacturacionGeneral), datos)
                                    Dim datosAct As New DataPrcActualizarFactura(Propuesta)
                                    Propuesta = BEDataEngine.RunProcess(GetType(PrcActualizarFactura), datosAct)
                                    TratarLog(Propuesta.Log, enumTipoDocumentoCreado.FacturaVenta, False, True)
                                Else : ExpertisApp.GenerateMessage("Proceso cancelado.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                                'End If
                            Else : ExpertisApp.GenerateMessage("El albarán tiene lineas con gestión de numeros de serie no establecidos.|No se puede facturar hasta que haga la distribución de los Numeros de Serie.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vbNewLine)
                            End If
                        Else : ExpertisApp.GenerateMessage("El Cliente | no admite el modo de facturación general. Facture el albarán por autofacturación.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Quoted(record.Rows(0)("IDCliente")))
                        End If
                    End If
                End If
            End If
        End If
    End Sub
End Class
