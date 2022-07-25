Public Class ClsCopiaFactVenta
    Implements Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Engine.IAction.Execute
        If ExpertisApp.GenerateMessage("Se generará la copia de la factura seleccionada. ¿Desea continuar?.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            Dim Create As CreateElement = New BE.DataEngine().RunProcess(GetType(PrcCopiaFacturaVenta), record.Rows(0)("IDFactura"))
            If Not Create Is Nothing Then
                ActionGoToRecordSimpleForm(programID, "IDFactura", Create.IDElement)
                ExpertisApp.GenerateMessage("Se ha generado la Factura '|'.", MessageBoxButtons.OK, MessageBoxIcon.Information, Create.NElement)
            End If
        End If
    End Sub

End Class