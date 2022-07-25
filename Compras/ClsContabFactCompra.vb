Public Class ClsContabFactCompra
    Implements Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Engine.IAction.Execute
        If record.Rows(0)("IDFactura") > 0 Then
            If record.Rows(0)("estado") <> enumContabilizado.Contabilizado Then
                Dim p As New Parametro
                If p.Contabilidad Then
                    If p.CAnaliticPredet Then
                        Dim dtFCAnaliticaNoDeduc As DataTable = New BE.DataEngine().Filter("vFCConIVANoDeducible", New NumberFilterItem("IDFactura", record.Rows(0)("IDFactura")))
                        If Not dtFCAnaliticaNoDeduc Is Nothing AndAlso dtFCAnaliticaNoDeduc.Rows.Count > 0 Then
                            ExpertisApp.GenerateMessage("La Factura seleccionada tiene IVA No Deducible. Recuerde que debe revisar los desgloses analíticos.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                    Dim G As Guid = MarcarRegistro(record.Rows(0)("IDFactura"), FilterType.Numeric)
                    Dim SimInfo As New DataSimulacionContableInfo
                    SimInfo.GuidSimulacion = G
                    SimInfo.TipoContabilizacion = enumTipoContabilizacion.tcFacturaCompra
                    SimInfo.IDEjercicio = record.Rows(0)("IDEjercicio") & String.Empty
                    SimInfo.Caption = "Simulación Contable - FACTURAS COMPRA -"
                    ExpertisApp.OpenForm("CISIMUCONT", , SimInfo)
                    DesmarcarRegistro(G, FilterType.Numeric)
                    ActionRefreshSimpleForm(programID)
                Else
                    ExpertisApp.ExecuteTask(Of DataTable)(AddressOf FacturaCompraCabecera.CambiarEstadoFactura, record)
                    ExpertisApp.GenerateMessage("Factura Validada y Pagos Generados.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ActionRefreshSimpleForm(programID)
                End If
            End If
        End If
    End Sub

End Class