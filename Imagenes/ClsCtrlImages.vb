Public Class ClsCtrlImages
    Implements Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Engine.IAction.Execute
        Dim DtPK As DataTable = ExpertisApp.ExecuteTask(Of String, DataTable)(AddressOf EntidadFoto.GetPrimaryKeyTable, entityName)
        Dim Data As New DatosConfigFotoInfo
        Data.DatosEntidad = New EntidadFotoInfo
        Data.DatosEntidad.Entidad = entityName : Data.DatosEntidad.Clave = record.Rows(0)(DtPK.Columns(0).ColumnName)
        Dim FrImg As New frmImagen
        FrImg.DatosFoto = Data
        FrImg.ShowDialog()
    End Sub

End Class