Public Class clsGenerarAlbCompra
    Implements Solmicro.Expertis.Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Engine.IAction.Execute
        If Not record Is Nothing AndAlso record.Rows.Count > 0 Then
            Dim ClsComunes As New ClsComunAlbFactCompra
            ClsComunes.GenerarAlbaranCompra(entityName, programID, record)
        End If
        ActionRefreshSimpleForm(programID)
    End Sub

End Class