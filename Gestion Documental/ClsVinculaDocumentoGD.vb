Public Class clsVinculaDocumentoGD
    Implements Solmicro.Expertis.Engine.IAction

    Public Sub Execute(ByVal EntityName As String, ByVal ProgramID As System.Guid, ByVal Record As System.Data.DataTable) Implements Solmicro.Expertis.Engine.IAction.Execute
        VinculaDocumentos(EntityName, Record)
    End Sub

    Public Sub VinculaDocumentos(ByVal strEntityName As String, ByVal dtCurrent As DataTable)
        If Len(strEntityName) > 0 AndAlso Not IsNothing(dtCurrent) AndAlso dtCurrent.Rows.Count > 0 Then
            Dim dtPK As DataTable = RellenarDtPK(strEntityName, dtCurrent)
            Dim HT As New Hashtable
            HT("Entidad") = strEntityName
            HT("dtPK") = dtPK
            If ExpertisApp.IsFormOpen("BUSQDOCUS") Then ExpertisApp.CloseForm("BUSQDOCUS")
            ExpertisApp.OpenForm("BUSQDOCUS", , HT)
        End If
    End Sub

    Private Function RellenarDtPK(ByVal strEntityName As String, ByVal dtCurrent As DataTable) As DataTable
        Dim oDE As New BE.DataEngine
        Dim dtPK As DataTable = oDE.GetPrimaryKey(strEntityName)
        Dim drPK As DataRow = dtPK.NewRow
        For Each dc As DataColumn In dtPK.Columns
            drPK(dc.ColumnName) = dtCurrent.Rows(0)(dc.ColumnName)
        Next
        dtPK.Rows.Add(drPK)
        Return dtPK
    End Function

End Class