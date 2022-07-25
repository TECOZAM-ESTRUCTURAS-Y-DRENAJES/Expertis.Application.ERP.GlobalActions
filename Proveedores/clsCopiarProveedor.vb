Public Class clsCopiarProveedor
    Implements Solmicro.Expertis.Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Solmicro.Expertis.Engine.IAction.Execute
        If ExpertisApp.GenerateMessage("¿Desea copiar un nuevo proveedor en base al actual: |?", Windows.Forms.MessageBoxButtons.YesNo, Windows.Forms.MessageBoxIcon.Question, record.Rows(0)("IDProveedor")) = Windows.Forms.DialogResult.Yes Then
            Dim StData As Proveedor.DataCopiaProv = ExpertisApp.ExecuteTask(Of String, Proveedor.DataCopiaProv)(AddressOf Proveedor.CopiarProveedor, record.Rows(0)("IDProveedor"))
            If Length(StData.Errores) = 0 Then
                If Length(StData.IDProveedorNew) > 0 Then
                    If ExpertisApp.GenerateMessage("Se ha generado el proveedor: |.¿Desea ver este nuevo proveedor?", Windows.Forms.MessageBoxButtons.YesNo, Windows.Forms.MessageBoxIcon.Question, StData.IDProveedorNew) = Windows.Forms.DialogResult.Yes Then
                        ExpertisApp.OpenForm("MPROV", New FilterItem("IDProveedor", FilterOperator.Equal, StData.IDProveedorNew))
                    End If
                End If
            Else : ExpertisApp.GenerateMessage("Ocurrió el siguiente error en el proceso de copiado:||", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error, vbNewLine, StData.Errores)
            End If
        End If
    End Sub

End Class