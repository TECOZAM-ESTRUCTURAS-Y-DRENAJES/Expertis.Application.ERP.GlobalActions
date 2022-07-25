Public Class ClsCopiaPedVenta
    Implements Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Engine.IAction.Execute
        If ExpertisApp.GenerateMessage("Se generará la copia del pedido seleccionado. ¿Desea continuar?.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            Dim Create As CreateElement = New BE.DataEngine().RunProcess(GetType(PrcCopiaPedidoVenta), record.Rows(0)("IDPedido"))
            If Not Create Is Nothing Then
                ActionGoToRecordSimpleForm(programID, "IDPedido", Create.IDElement)
                ExpertisApp.GenerateMessage("Se ha generado el Pedido '|'.", MessageBoxButtons.OK, MessageBoxIcon.Information, Create.NElement)
            End If
        End If
    End Sub

End Class
