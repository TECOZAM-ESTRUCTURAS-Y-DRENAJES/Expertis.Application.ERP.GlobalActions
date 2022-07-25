Public Class ClsActualizarStockAlbVenta
    Implements Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Engine.IAction.Execute
        If Not record Is Nothing AndAlso record.Rows.Count > 0 Then
            Dim DtChanges As DataTable = record.GetChanges
            If Not DtChanges Is Nothing AndAlso DtChanges.Rows.Count > 0 Then
                ExpertisApp.GenerateMessage("Existen actualizaciones pendientes.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Dim Log() As StockUpdateData = ExpertisApp.ExecuteTask(Of Integer, StockUpdateData())(AddressOf AlbaranVentaCabecera.ActualizarStockAlbaran, CInt(record.Rows(0)("IDAlbaran")))
                ActionRefreshSimpleForm(programID)
                If Not Log Is Nothing AndAlso Log.Length > 0 Then
                    Dim Frmdetalle As New ERP.CommonClasses.DetalleActualizacionStock
                    Frmdetalle.DataSource = Log
                    Frmdetalle.ShowDialog()
                Else : ExpertisApp.GenerateMessage("No hay líneas para actualizar.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

End Class