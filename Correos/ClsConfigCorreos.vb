Public Class ClsConfigCorreos
    Implements Solmicro.Expertis.Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Solmicro.Expertis.Engine.IAction.Execute
        Dim FilParams As New Business.General.Correos.DataCorreos(entityName, ExpertisApp.Token.UserID)
        Dim FrmParam As New FrmParamMails
        FrmParam.MailParamInfo = ExpertisApp.ExecuteTask(Of Business.General.Correos.DataCorreos, SmtpServerInfo)(AddressOf Business.General.Correos.LoadSmtpServerInfo, FilParams)
        If FrmParam.ShowDialog = DialogResult.OK Then
            ExpertisApp.ExecuteTask(Of SmtpServerInfo)(AddressOf Business.General.Correos.SaveSmtpServerInfo, FrmParam.MailParamInfo)
        End If
    End Sub

End Class