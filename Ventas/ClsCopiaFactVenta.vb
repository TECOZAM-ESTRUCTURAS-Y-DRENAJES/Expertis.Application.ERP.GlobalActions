Imports Solmicro.Expertis.Business.ClasesTecozam

Public Class ClsCopiaFactVenta
    Implements Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Engine.IAction.Execute
        If ExpertisApp.GenerateMessage("Se generará la copia de la factura seleccionada. ¿Desea continuar?.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            'Ibis Adolfo 20220208
            Dim datos As New TECDataPrcCopiarFactura(record.Rows(0)("IDFactura"), record.Rows(0)("IDContador"))
            Dim FrmContFecha As New frmContadorFechaFactura
            FrmContFecha.Fecha = Date.Today
            FrmContFecha.Contador = record.Rows(0)("IDContador")
            If FrmContFecha.ShowDialog = DialogResult.OK Then
                datos.idContador = FrmContFecha.Contador

                'Dim Create As CreateElement = New BE.DataEngine().RunProcess(GetType(PrcCopiaFacturaVenta), record.Rows(0)("IDFactura"))
                Dim Create As CreateElement = New BE.DataEngine().RunProcess(GetType(PrcCopiaFacturaVenta), datos)
                If Not Create Is Nothing Then
                    ActionGoToRecordSimpleForm(programID, "IDFactura", Create.IDElement)
                    ExpertisApp.GenerateMessage("Se ha generado la Factura '|'.", MessageBoxButtons.OK, MessageBoxIcon.Information, Create.NElement)
                End If
            End If
        End If
    End Sub

End Class