Public Class ClsActualizarStockAlbCompra
    Implements Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Engine.IAction.Execute
        If Not record Is Nothing AndAlso record.Rows.Count > 0 Then
            Dim DtChanges As DataTable = record.GetChanges
            If Not DtChanges Is Nothing AndAlso DtChanges.Rows.Count > 0 Then
                ExpertisApp.GenerateMessage("Existen actualizaciones pendientes.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Dim log() As StockUpdateData = ExpertisApp.ExecuteTask(Of Integer, StockUpdateData())(AddressOf AlbaranCompraCabecera.ActualizarStockAlbaran, CInt(record.Rows(0)("IDAlbaran")))
                ActionRefreshSimpleForm(programID)
                If Not log Is Nothing AndAlso log.Length > 0 Then
                    Dim detalle As New ERP.CommonClasses.DetalleActualizacionStock
                    detalle.DataSource = log
                    detalle.ShowDialog()
                Else
                    ExpertisApp.GenerateMessage("No hay líneas para actualizar.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

End Class