Public Class clsExportMasivoFactVentaGAIA
    Implements Expertis.Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Engine.IAction.Execute
        Dim ClsGaia As New GaiaNetExchange
        Dim FrmSelTipo As New frmSelTipoFicheroGAIA
        If FrmSelTipo.ShowDialog = DialogResult.OK Then
            ClsGaia.GenerarEnviarDocumentosGaia(record, entityName, FrmSelTipo.OpcionTipoFichero)
            ActionRefreshCIForm(programID)
        End If
    End Sub

End Class