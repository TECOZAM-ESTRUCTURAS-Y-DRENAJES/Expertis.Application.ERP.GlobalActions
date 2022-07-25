Public Class clsPrecioOptimo
    Implements Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Engine.IAction.Execute
        Dim FrmFecha As New frmFechaCalcPrecioOptimo
        FrmFecha.Fecha = record.Rows(0)("FechaPedido")
        If FrmFecha.ShowDialog = DialogResult.OK Then
            Dim StData As New PedidoVentaCabecera.DataPrecioOptimo(record.Rows(0)("IDPedido"), FrmFecha.Fecha)
            ExpertisApp.ExecuteTask(Of PedidoVentaCabecera.DataPrecioOptimo)(AddressOf PedidoVentaCabecera.PrecioOptimo, StData)
            ActionRefreshSimpleForm(programID)
        End If
    End Sub

End Class
