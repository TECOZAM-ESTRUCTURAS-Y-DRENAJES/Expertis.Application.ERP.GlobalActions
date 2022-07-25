Public Class DeshacerCierreContableEjercicio
    Implements Solmicro.Expertis.Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Solmicro.Expertis.Engine.IAction.Execute
        Dim IDEjercicio As String = record.Rows(0)("IDEjercicio")
        Dim DescEjercicio As String = record.Rows(0)("DescEjercicio") & String.Empty
        Dim log As New LogProcess
        Dim frm As New frmDeshacerCierreContableEjercicio
        If frm.Abrir(IDEjercicio) = DialogResult.OK Then
            Try
                If frm.AsientoApertura AndAlso Length(frm.IDEjercicioSiguiente) > 0 Then
                    Dim blnOK As Boolean = ExpertisApp.ExecuteTask(Of String, Boolean)(AddressOf DiarioContable.DeshacerAsientoApertura, frm.IDEjercicioSiguiente)
                    If blnOK Then
                        ReDim Preserve log.CreatedElements(log.CreatedElements.Length)
                        log.CreatedElements(log.CreatedElements.Length - 1) = New CreateElement()
                        log.CreatedElements(log.CreatedElements.Length - 1).NElement = ExpertisApp.Traslate("Se ha eliminado el Asiento de Apertura.")
                    End If
                End If

                If frm.AsientoCierre AndAlso Length(frm.IDEjercicioActual) > 0 Then
                    Dim blnOK As Boolean = ExpertisApp.ExecuteTask(Of String, Boolean)(AddressOf DiarioContable.DeshacerAsientoCierre, frm.IDEjercicioActual)
                    If blnOK Then
                        ReDim Preserve log.CreatedElements(log.CreatedElements.Length)
                        log.CreatedElements(log.CreatedElements.Length - 1) = New CreateElement()
                        log.CreatedElements(log.CreatedElements.Length - 1).NElement = ExpertisApp.Traslate("Se ha eliminado el Asiento de Cierre.")
                    End If
                End If

                If frm.AsientoRegularizacionG8y9 AndAlso Length(frm.IDEjercicioActual) > 0 Then
                    Dim blnOK As Boolean = ExpertisApp.ExecuteTask(Of String, Boolean)(AddressOf DiarioContable.DeshacerAsientoRegularizacionGrupo8y9, frm.IDEjercicioActual)
                    If blnOK Then
                        ReDim Preserve log.CreatedElements(log.CreatedElements.Length)
                        log.CreatedElements(log.CreatedElements.Length - 1) = New CreateElement()
                        log.CreatedElements(log.CreatedElements.Length - 1).NElement = ExpertisApp.Traslate("Se ha eliminado el Asiento de Regularización de los grupos 8 y 9.")
                    End If
                End If

                If frm.AsientoRegularizacion AndAlso Length(frm.IDEjercicioActual) > 0 Then
                    Dim blnOK As Boolean = ExpertisApp.ExecuteTask(Of String, Boolean)(AddressOf DiarioContable.DeshacerAsientoRegularizacion, frm.IDEjercicioActual)
                    If blnOK Then
                        ReDim Preserve log.CreatedElements(log.CreatedElements.Length)
                        log.CreatedElements(log.CreatedElements.Length - 1) = New CreateElement()
                        log.CreatedElements(log.CreatedElements.Length - 1).NElement = ExpertisApp.Traslate("Se ha eliminado el Asiento de Regularización.")
                    End If
                End If
            Catch ex As Exception
                ReDim Preserve log.Errors(log.Errors.Length)
                log.Errors(log.Errors.Length - 1) = New ClassErrors
                log.Errors(log.Errors.Length - 1).Elements = String.Empty
                log.Errors(log.Errors.Length - 1).MessageError = ex.Message
            End Try

            TratarLog(log, -1, True)
            ActionRefreshSimpleForm(programID)
        End If
    End Sub

End Class
