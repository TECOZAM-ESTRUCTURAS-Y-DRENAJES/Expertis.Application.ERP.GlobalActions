Public Class ClsGenerarAlbVenta
    Implements Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Engine.IAction.Execute
        If Not record Is Nothing AndAlso record.Rows.Count > 0 Then
            Dim ClsComunes As New ClsComunAlbFactVenta
            ClsComunes.GenerarAlbaran(entityName, programID, record)
            ActionRefreshSimpleForm(programID)
        End If
    End Sub

End Class
