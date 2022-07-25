Public Class ClsDireccionPedCompra
    Implements Engine.IAction

    Private WithEvents BusquedaDireccion As New AdvancedSearch
    Private MyDt As DataTable
    Private MyProgramID As Guid

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Engine.IAction.Execute
        If Not record Is Nothing AndAlso record.Rows.Count > 0 Then
            MyProgramID = programID : MyDt = record
            BusquedaDireccion.EntityName = "ProveedorDireccion"
            BusquedaDireccion.ViewName = "tbProveedorDireccion"
            BusquedaDireccion.Open()
        End If
    End Sub

    Private Sub FwBusquedaDireccion_SetPredefinedFilter(ByVal sender As Object, ByVal e As Engine.UI.AdvSearchFilterEventArgs) Handles BusquedaDireccion.SetPredefinedFilter
        e.Filter.Add("IDProveedor", FilterOperator.Equal, MyDt.Rows(0)("IDProveedor"))
        e.Filter.Add("Envio", FilterOperator.Equal, True)
    End Sub

    Private Sub FwBusquedaDireccion_SelectionChanged(ByVal sender As Object, ByVal e As Engine.UI.AdvSearchSelectionChangedEventArgs) Handles BusquedaDireccion.SelectionChanged
        MyDt.Rows(0)("IDDireccion") = BusquedaDireccion.SelectedRow.Rows(0)("IDDireccion")
        Dim ClsPedCab As New PedidoCompraCabecera
        MyDt.TableName = "PedidoCompraCabecera"
        ClsPedCab.Update(MyDt)
        ActionRefreshSimpleForm(MyProgramID)
    End Sub

End Class