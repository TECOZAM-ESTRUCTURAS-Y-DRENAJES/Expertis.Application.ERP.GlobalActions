Public Class ClsSatelites
    Implements Solmicro.Expertis.Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Solmicro.Expertis.Engine.IAction.Execute
        Dim FrmSat As New frmSatelites
        FrmSat.Entidad = entityName
        FrmSat.DtData = record
        FrmSat.ShowDialog()
        ActionRefreshSimpleForm(programID)
    End Sub

End Class