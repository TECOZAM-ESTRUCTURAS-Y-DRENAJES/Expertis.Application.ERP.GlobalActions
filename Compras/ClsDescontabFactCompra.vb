Public Class ClsDescontabFactCompra
    Implements Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Engine.IAction.Execute
        If Not record Is Nothing AndAlso record.Rows.Count > 0 Then
            If record.Rows(0)("IDFactura") > 0 Then
                If record.Rows(0)("estado") <> enumContabilizado.NoContabilizado AndAlso Not record.Rows(0)("NoDescontabilizar") Then
                    If New Parametro().Contabilidad Then
                        Dim G As Guid = MarcarRegistro(record.Rows(0)("IDFactura"), FilterType.Numeric)
                        Dim frm As New Expertis.Application.ERP.FacturaCompra.frmDescontabilizar
                        If ExpertisApp.ExecuteTask(Of String, Boolean)(AddressOf FacturaCompraLinea.ExistenLineasInmovilizadas, G.ToString) = True Then
                            If ExpertisApp.GenerateMessage("Existen líneas seleccionadas que están inmovilizadas. ¿Desea continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.No Then
                                Exit Sub
                            End If
                        End If
                        frm.IDProcess = G
                        frm.ShowDialog()
                        DesmarcarRegistro(G, FilterType.Numeric)
                        ActionRefreshSimpleForm(programID)
                    Else
                        ExpertisApp.ExecuteTask(Of DataTable)(AddressOf FacturaCompraCabecera.CambiarEstadoFactura, record)
                        ExpertisApp.GenerateMessage("Puede modificar su factura, recuerde validar de nuevo para crear los pagos.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ActionRefreshSimpleForm(programID)
                    End If
                End If
            End If
        End If
    End Sub

End Class