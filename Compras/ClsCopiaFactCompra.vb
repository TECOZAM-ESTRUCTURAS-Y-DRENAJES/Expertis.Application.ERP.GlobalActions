Imports Solmicro.Expertis.Business.ClasesTecozam

Public Class ClsCopiaFactCompra
    Implements Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Engine.IAction.Execute
        ''David v 29/8/22
        'If ExpertisApp.GenerateMessage("Se generará la copia de la factura seleccionada. ¿Desea continuar?.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
        '    Dim Create As CreateElement = New BE.DataEngine().RunProcess(GetType(PrcCopiaFacturaCompra), record.Rows(0)("IDFactura"))
        '    If Not Create Is Nothing Then
        '        ActionGoToRecordSimpleForm(programID, "IDFactura", Create.IDElement)
        '        ExpertisApp.GenerateMessage("Se ha generado la Factura '|'.", MessageBoxButtons.OK, MessageBoxIcon.Information, Create.NElement)
        '    End If
        'End If

        If ExpertisApp.GenerateMessage("Se generará la copia de la factura seleccionada. ¿Desea continuar?.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            'Ibis Adolfo 20220208
            Dim datos As New TECDataPrcCopiarFacturaCompra(record.Rows(0)("IDFactura"), record.Rows(0)("IDContador"))
            Dim FrmContFecha As New frmContadorFechaFacturaCompra
            FrmContFecha.Fecha = Date.Today
            FrmContFecha.Contador = record.Rows(0)("IDContador")
            If FrmContFecha.ShowDialog = DialogResult.OK Then
                datos.idContador = FrmContFecha.Contador
                Try
                    datos.fecha = FrmContFecha.Fecha
                Catch ex As Exception

                End Try
                Dim Create As CreateElement = New BE.DataEngine().RunProcess(GetType(PrcCopiaFacturaCompraProceso), datos)
                If Not Create Is Nothing Then
                    ActionGoToRecordSimpleForm(programID, "IDFactura", Create.IDElement)
                    ExpertisApp.GenerateMessage("Se ha generado la Factura '|'.", MessageBoxButtons.OK, MessageBoxIcon.Information, Create.NElement)
                End If
            End If

            'Dim Create As CreateElement = New BE.DataEngine().RunProcess(GetType(PrcCopiaFacturaVenta), record.Rows(0)("IDFactura"))
            
        End If
    End Sub

End Class