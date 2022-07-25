Public Class clsCopiarCliente
    Implements Solmicro.Expertis.Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Solmicro.Expertis.Engine.IAction.Execute
        If ExpertisApp.GenerateMessage("¿Desea copiar un nuevo cliente en base al actual: |?", Windows.Forms.MessageBoxButtons.YesNo, Windows.Forms.MessageBoxIcon.Question, record.Rows(0)("IDCliente")) = Windows.Forms.DialogResult.Yes Then
            Dim StData As Cliente.DataCopiaCliente = ExpertisApp.ExecuteTask(Of String, Cliente.DataCopiaCliente)(AddressOf Cliente.CopiarCliente, record.Rows(0)("IDCliente"))
            If Length(StData.Errores) = 0 Then
                If Length(StData.IDClienteNew) > 0 Then
                    If ExpertisApp.GenerateMessage("Se ha generado el cliente: |.¿Desea ver este nuevo cliente?", Windows.Forms.MessageBoxButtons.YesNo, Windows.Forms.MessageBoxIcon.Question, StData.IDClienteNew) = Windows.Forms.DialogResult.Yes Then
                        ExpertisApp.OpenForm("MCLIENTE", New FilterItem("IDCliente", FilterOperator.Equal, StData.IDClienteNew))
                    End If
                End If
            Else : ExpertisApp.GenerateMessage("Ocurrió el siguiente error en el proceso de copiado:||", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error, vbNewLine, StData.Errores)
            End If
        End If
    End Sub

End Class