Public Class ClsGenerarAlbFactCompra
    Implements Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Engine.IAction.Execute
        If ExpertisApp.GenerateMessage("Se va a generar el albarán de compra y a continuación la factura de compra relacionada.|¿Desea continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, vbNewLine) = DialogResult.Yes Then
            'Generamos primero la parte del albarán de compra
            Dim ClsComunes As New ClsComunAlbFactCompra
            Dim LogAlb As AlbaranLogProcess = ClsComunes.GenerarAlbaranCompra(entityName, programID, record, False)
            If Not LogAlb Is Nothing AndAlso Not LogAlb.CreateData.CreatedElements Is Nothing AndAlso LogAlb.CreateData.CreatedElements.Count > 0 Then
                'Generamos la parte de la factura de compra
                Dim DtAlbNew As DataTable = New BE.DataEngine().Filter("frmMntoAlbaranCompra", New FilterItem("IDAlbaran", FilterOperator.Equal, LogAlb.CreateData.CreatedElements(0).IDElement))
                If Not DtAlbNew Is Nothing AndAlso DtAlbNew.Rows.Count > 0 Then
                    ClsComunes.GenerarFacturaCompra(entityName, programID, DtAlbNew)
                End If
                ActionRefreshSimpleForm(programID)
            End If
        End If
    End Sub

End Class