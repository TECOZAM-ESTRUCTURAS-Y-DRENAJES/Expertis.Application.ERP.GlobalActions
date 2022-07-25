Public Class ClsCerrarLineasAlbCompra
    Implements Expertis.Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Engine.IAction.Execute
        If Not record Is Nothing AndAlso record.Rows.Count > 0 Then
            Dim Pedido As New PedidoCompraLinea
            Pedido.CerrarLineas(record)
            ExpertisApp.GenerateMessage("Líneas cerradas correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ActionRefreshCIForm(programID)
        End If
    End Sub

End Class