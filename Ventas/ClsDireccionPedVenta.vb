Public Class ClsDireccionPedVenta
    Implements Engine.IAction

    Private MyProg As Guid
    Private MyDt As DataTable

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Engine.IAction.Execute
        Dim BusquedaDireccion As New AdvancedSearch
        BusquedaDireccion.EntityName = "ClienteDireccion"
        MyDt = record : MyProg = programID
        AddHandler BusquedaDireccion.SetPredefinedFilter, AddressOf BusquedaDireccion_SetPredefinedFilter
        AddHandler BusquedaDireccion.SelectionChanged, AddressOf BusquedaDireccion_SelectionChanged
        BusquedaDireccion.Open()
    End Sub

    Private Sub BusquedaDireccion_SetPredefinedFilter(ByVal sender As Object, ByVal e As Solmicro.Expertis.Engine.UI.AdvSearchFilterEventArgs)
        If Not MyDt Is Nothing AndAlso MyDt.Rows.Count > 0 Then
            Dim StData As New Cliente.DataGrupoCliente
            StData.IDCliente = MyDt.Rows(0)("IDCliente") : StData.TipoGrupo = "Direccion"
            Dim StrGrupo As String = ExpertisApp.ExecuteTask(Of Cliente.DataGrupoCliente, String)(AddressOf Cliente.Grupo, StData)
            If Length(StrGrupo) > 0 Then
                e.Filter.Add("idcliente", FilterOperator.Equal, StrGrupo)
            Else : e.Filter.Add("idcliente", FilterOperator.Equal, MyDt.Rows(0)("IDCliente"))
            End If
            e.Filter.Add(New BooleanFilterItem("Envio", FilterOperator.Equal, True))
        End If
    End Sub

    Private Sub BusquedaDireccion_SelectionChanged(ByVal sender As Object, ByVal e As Solmicro.Expertis.Engine.UI.AdvSearchSelectionChangedEventArgs)
        If Not MyDt Is Nothing AndAlso MyDt.Rows.Count > 0 Then
            Dim dtCopy As DataTable = MyDt.Copy
            dtCopy.Rows(0)("IDDireccionEnvio") = e.Selected.Rows(0)("IDDireccion") & String.Empty
            MyDt.TableName = "PedidoVentaCabecera"
            Dim PVC As New PedidoVentaCabecera
            PVC.Update(dtCopy)
            ActionRefreshSimpleForm(MyProg)
        End If
    End Sub

End Class