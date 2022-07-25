Public Class ClsGenerarAlbFactVenta
    Implements Solmicro.Expertis.Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Solmicro.Expertis.Engine.IAction.Execute
        If ExpertisApp.GenerateMessage("Se va a generar el albarán de venta y a continuación la factura de venta relacionada.|¿Desea continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, vbNewLine) = DialogResult.Yes Then
            'Generamos la parte del albarán de venta
            Dim ClsComunes As New ClsComunAlbFactVenta
            Dim LogAlb As AlbaranLogProcess = ClsComunes.GenerarAlbaran(entityName, programID, record, False)
            'Generamos la parte de Factura de Venta
            If Not LogAlb Is Nothing AndAlso Not LogAlb.CreateData Is Nothing AndAlso Not LogAlb.CreateData.CreatedElements Is Nothing AndAlso LogAlb.CreateData.CreatedElements.Count > 0 Then
                Dim DtAlbNew As DataTable = New BE.DataEngine().Filter("frmMntoAlbaranVenta", New FilterItem("IDAlbaran", FilterOperator.Equal, LogAlb.CreateData.CreatedElements(0).IDElement))
                If Not DtAlbNew Is Nothing AndAlso DtAlbNew.Rows.Count > 0 Then
                    ClsComunes.GenerarFactura(entityName, programID, DtAlbNew)
                End If
            End If
            ActionRefreshSimpleForm(programID)
        End If
    End Sub

End Class