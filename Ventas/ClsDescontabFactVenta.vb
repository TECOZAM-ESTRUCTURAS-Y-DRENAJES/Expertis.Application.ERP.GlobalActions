Public Class ClsDescontabFactVenta
    Implements Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Engine.IAction.Execute
        If record.Rows(0)("IDFactura") > 0 Then
            If record.Rows(0)("estado") <> enumContabilizado.NoContabilizado Then
                If record.Columns.Contains("Arqueo") AndAlso Nz(record.Rows(0)("Arqueo"), False) Then Exit Sub
                If New Parametro().Contabilidad Then
                    Dim G As Guid = MarcarRegistro(record.Rows(0)("IDFactura"), FilterType.Numeric)
                    Dim frm As New Expertis.Application.ERP.FacturaVenta.frmDescontabilizar
                    frm.IDProcess = G
                    frm.ShowDialog()
                    DesmarcarRegistro(G, FilterType.Numeric)
                    ActionRefreshSimpleForm(programID)
                Else
                    ExpertisApp.ExecuteTask(Of DataTable)(AddressOf FacturaVentaCabecera.CambiarEstadoFactura, record)
                    ExpertisApp.GenerateMessage("Puede modificar su factura, recuerde validar de nuevo para crear los cobros.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ActionRefreshSimpleForm(programID)
                End If
            End If
        End If
    End Sub

End Class