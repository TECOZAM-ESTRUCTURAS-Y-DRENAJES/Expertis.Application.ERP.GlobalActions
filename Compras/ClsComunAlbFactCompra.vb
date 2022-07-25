Public Class ClsComunAlbFactCompra

    Public Function GenerarAlbaranCompra(ByVal entityname As String, ByVal programid As Guid, ByVal record As DataTable, Optional ByVal MostrarLog As Boolean = True) As AlbaranLogProcess
        Dim log As New AlbaranLogProcess
        Dim DtLineas As DataTable = New PedidoCompraLinea().Filter(New FilterItem("IDPedido", FilterOperator.Equal, record.Rows(0)("IDPedido")))
        If Not DtLineas Is Nothing AndAlso DtLineas.Rows.Count > 0 Then
            Dim DtChanges As DataTable = record.GetChanges
            If Not DtChanges Is Nothing AndAlso DtChanges.Rows.Count > 0 Then
                ExpertisApp.GenerateMessage("Existen actualizaciones pendientes.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Dim IDPedido As Integer
                If IsNumeric(record.Rows(0)("IDPedido")) Then IDPedido = CInt(record.Rows(0)("IDPedido"))
                If IDPedido > 0 Then
                    If New Parametro().ActAutomaticaAlbCompra() Then
                        Dim dvAux As New DataView(DtLineas)
                        Dim f As New Filter(FilterUnionOperator.Or)
                        Dim f1 As New Filter, f2 As New Filter, f3 As New Filter, f4 As New Filter, f5 As New Filter, f6 As New Filter
                        f1.Add(New NumberFilterItem("TipoLineaCompra", FilterOperator.Equal, enumaclTipoLineaAlbaran.aclKit))
                        f2.Add(New NumberFilterItem("TipoLineaCompra", FilterOperator.Equal, enumaclTipoLineaAlbaran.aclKit))
                        f3.Add(New NumberFilterItem("TipoLineaCompra", FilterOperator.Equal, enumaclTipoLineaAlbaran.aclSubcontratacion))
                        f4.Add(New NumberFilterItem("TipoLineaCompra", FilterOperator.Equal, enumaclTipoLineaAlbaran.aclSubcontratacion))
                        f5.Add(New NumberFilterItem("Estado", FilterOperator.Equal, enumpclEstado.pclpedido))
                        f6.Add(New NumberFilterItem("Estado", FilterOperator.Equal, enumpclEstado.pclparcservido))
                        f1.Add(f5) : f2.Add(f6) : f3.Add(f5) : f4.Add(f6)
                        f.Add(f1) : f.Add(f2) : f.Add(f3) : f.Add(f4)
                        dvAux.RowFilter = f.Compose(New AdoFilterComposer)
                        If dvAux.Count > 0 Then
                            ExpertisApp.GenerateMessage("La actualización automática del stock está activada. Dicha actualización no se realizará para las líneas de tipo Kit y Subcontratación.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If

                    Dim fParcServ As New Filter
                    fParcServ.Add(New NumberFilterItem("IDPedido", FilterOperator.Equal, CInt(record.Rows(0)("IDPedido"))))
                    fParcServ.Add(New NumberFilterItem("Estado", FilterOperator.Equal, enumpclEstado.pclparcservido))
                    Dim dtLineasParcServ As DataTable = New PedidoCompraLinea().Filter(fParcServ)
                    If dtLineasParcServ.Rows.Count > 0 Then
                        ExpertisApp.GenerateMessage("El pedido contiene líneas Parcialmente Servidas, genere el Albarán desde Recepción de Pedidos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Function
                    End If

                    Dim datos As New DataPrcAlbaranarPedCompra(IDPedido)
                    log = New BE.DataEngine().RunProcess(GetType(PrcAlbaranarPedCompra), datos)
                    If MostrarLog Then TratarLog(log, enumTipoDocumentoCreado.AlbaranCompra, , True)
                End If
            End If
        End If
        Return log
    End Function

    Public Sub GenerarFacturaCompra(ByVal entityname As String, ByVal programid As Guid, ByVal record As DataTable)
        If Length(record.Rows(0)("IDTipoCompra")) > 0 Then
            Dim dtTipoCompra As DataTable = New TipoCompra().SelOnPrimaryKey(record.Rows(0)("IDTipoCompra"))
            If Not dtTipoCompra Is Nothing AndAlso dtTipoCompra.Rows.Count > 0 AndAlso Not Nz(dtTipoCompra.Rows(0)("Facturable"), False) Then
                ExpertisApp.GenerateMessage("El Albarán no es Facturable.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vbNewLine)
                Exit Sub
            End If
        End If
        If record.Rows(0)("Estado") <> enumaccEstado.accFacturado Then
            If record.Rows(0)("TipoFacturacion") = enummpTipoFacturacion.mpGeneral Then

                Dim blnGestionInvPermanente As Boolean = New Parametro().GestionInventarioPermanente
                Dim BlnNSerie As Boolean = ExpertisApp.ExecuteTask(Of Integer, Boolean)(AddressOf AlbaranCompraCabecera.ComprobarNumerosSerieAlbaran, CInt(record.Rows(0)("IDAlbaran")))
                Dim BlnSubOF As Boolean = False
                Dim SubOF As New Filter
                SubOF.Add(New NumberFilterItem("IDAlbaran", FilterOperator.Equal, CInt(record.Rows(0)("IDAlbaran"))))
                If Not blnGestionInvPermanente Then SubOF.Add(New IsNullFilterItem("IDOrdenRuta", False))
                Dim dtLineasAlb As DataTable = New BE.DataEngine().Filter("vNegEnlaceContableMovimientosACFacturacion", SubOF)

                If dtLineasAlb.Rows.Count > 0 Then
                    If Not blnGestionInvPermanente Then
                        Dim LineasAlbSinOrdenRuta As List(Of DataRow) = (From c In dtLineasAlb _
                                                             Where Not c.IsNull("IDOrdenRuta")).ToList()
                        If LineasAlbSinOrdenRuta Is Nothing OrElse LineasAlbSinOrdenRuta.Count > 0 Then
                            BlnSubOF = True
                        End If
                    Else
                        Dim LineasAlbSinOrdenRuta As List(Of DataRow) = (From c In dtLineasAlb _
                                                             Where Not c.IsNull("IDOrdenRuta")).ToList()
                        If LineasAlbSinOrdenRuta Is Nothing OrElse LineasAlbSinOrdenRuta.Count > 0 Then
                            BlnSubOF = True
                        Else
                            Dim LineasAlbNoContabilizadas As List(Of DataRow) = (From c In dtLineasAlb _
                                                             Where (c("EstadoStock") = enumaclEstadoStock.aclActualizado Or (c("EstadoStock") = enumaclEstadoStock.aclSinGestion And c("Especial") = 1)) AndAlso _
                                                               (c.IsNull("Contabilizado") OrElse c("Contabilizado") <> enumContabilizado.Contabilizado)).ToList()
                            If Not LineasAlbNoContabilizadas Is Nothing AndAlso LineasAlbNoContabilizadas.Count > 0 Then
                                ExpertisApp.GenerateMessage("Existen líneas con Stock actualizado sin Contabilizar. Revise sus datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vbNewLine)
                                Exit Sub
                            End If
                        End If
                    End If
                End If

                If BlnNSerie OrElse BlnSubOF Then
                    Dim frm As New Solmicro.Expertis.Application.ERP.AlbaranCompra.frmFacturar
                    frm.ShowDialog()
                    If frm.OK Then
                        Dim dteFechaFactura As Date
                        If IsDate(frm.fwiSuFecha.Value) Then dteFechaFactura = frm.fwiSuFecha.Value
                        Dim strSuFactura As String = frm.fwiSuFactura.Text & String.Empty
                        frm.Close()
                        If ExpertisApp.GenerateMessage("Se procederá a crear una Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Dim datos As New DataPrcFacturacionCompra(New Integer() {record.Rows(0)("IDAlbaran")}, Nothing, dteFechaFactura, strSuFactura)
                            Dim BEDataEngine As New BE.DataEngine
                            Dim Propuesta As ResultFacturacion = BEDataEngine.RunProcess(GetType(PrcFacturacionCompra), datos)
                            Dim datosAct As New DataPrcActualizarFactura(Propuesta)
                            Propuesta = BEDataEngine.RunProcess(GetType(PrcActualizarFacturaCompra), datosAct)
                            TratarLog(Propuesta.Log, enumTipoDocumentoCreado.FacturaCompra, False, True)
                        Else
                            ExpertisApp.GenerateMessage("Proceso cancelado.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                Else
                    ExpertisApp.GenerateMessage("El Albarán tiene lineas con gestión de numeros de serie no establecidos.{0}No se puede facturar hasta que haga la distribución de los Numeros de Serie.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vbNewLine)
                End If
            Else : ExpertisApp.GenerateMessage("El Proveedor {0} no admite el modo de facturación general. Facture el albarán por autofacturación.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, Quoted(record.Rows(0)("IDProveedor")))
            End If

        End If
    End Sub

End Class