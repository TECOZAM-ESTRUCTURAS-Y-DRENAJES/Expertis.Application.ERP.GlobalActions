Public Class ClsContabFactVenta
    Implements Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Engine.IAction.Execute
        If record.Rows(0)("IDFactura") > 0 Then
            If record.Rows(0)("estado") <> enumContabilizado.Contabilizado Then
                If New Parametro().Contabilidad Then
                    Dim G As Guid = MarcarRegistro(record.Rows(0)("IDFactura"), FilterType.Numeric)
                    Dim SimInfo As New DataSimulacionContableInfo
                    SimInfo.TipoContabilizacion = enumTipoContabilizacion.tcFacturaVenta
                    SimInfo.IDEjercicio = record.Rows(0)("IDEjercicio") & String.Empty
                    SimInfo.GuidSimulacion = G
                    SimInfo.Caption = ExpertisApp.Traslate("Simulación Contable - FACTURAS VENTA -")
                    ExpertisApp.OpenForm("CISIMUCONT", , SimInfo)
                    DesmarcarRegistro(G, FilterType.Numeric)
                Else
                    ExpertisApp.ExecuteTask(Of DataTable)(AddressOf FacturaVentaCabecera.CambiarEstadoFactura, record)
                    ExpertisApp.GenerateMessage("Factura Validada y Cobros Generados.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ActionRefreshSimpleForm(programID)
                End If
            End If
        End If
    End Sub

End Class