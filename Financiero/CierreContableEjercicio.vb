Public Class CierreContableEjercicio
    Implements Solmicro.Expertis.Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Solmicro.Expertis.Engine.IAction.Execute
        If Not record Is Nothing AndAlso record.Rows.Count > 0 Then
            If Length(record.Rows(0)("IDEjercicio")) > 0 Then
                Dim IDEjercicio As String = record.Rows(0)("IDEjercicio")
                Dim frm As New frmCierreContableEjercicio
                If frm.Abrir(IDEjercicio) = DialogResult.OK Then

                    Dim log As New LogProcess
                    Try
                        If frm.AsientoRegularizacion Then
                            Dim datAcumulado As New DiarioContable.DataAsientoRegularizacion(frm.IDEjercicioActual, frm.NAsientoRegularizacion, frm.FechaAsientoRegularizacion, frm.IDCContablePerdidas)
                            Dim NumApuntesRegularizacion As Integer = ExpertisApp.ExecuteTask(Of DiarioContable.DataAsientoRegularizacion, Integer)(AddressOf DiarioContable.AsientoRegularizacion, datAcumulado)
                            If NumApuntesRegularizacion > 0 Then
                                ReDim Preserve log.CreatedElements(log.CreatedElements.Length)
                                log.CreatedElements(log.CreatedElements.Length - 1) = New CreateElement()
                                log.CreatedElements(log.CreatedElements.Length - 1).NElement = ExpertisApp.Traslate("Se ha generado el Asiento de Regularización. Se han generado {0} apuntes.", NumApuntesRegularizacion)
                            Else
                                ReDim Preserve log.Errors(log.Errors.Length)
                                log.Errors(log.Errors.Length - 1) = New ClassErrors
                                log.Errors(log.Errors.Length - 1).Elements = ExpertisApp.Traslate("Regularización")
                                log.Errors(log.Errors.Length - 1).MessageError = ExpertisApp.Traslate("No se ha generado el Asiento de Regularización.")
                            End If
                        End If

                        If frm.AsientoRegularizacionG8y9 Then
                            Dim datos As New Regularizacion8y9.DataRegularizacion
                            datos.IDEjercicio = frm.IDEjercicioActual
                            datos.Fecha = frm.FechaAsientoRegularizacionG8y9
                            Dim dtRegularizacionG8y9 As DataTable = ExpertisApp.ExecuteTask(Of Regularizacion8y9.DataRegularizacion, DataTable)(AddressOf Regularizacion8y9.Regularizacion, datos)

                            If dtRegularizacionG8y9 Is Nothing OrElse dtRegularizacionG8y9.Rows.Count = 0 Then
                                ExpertisApp.GenerateMessage("No hay datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Else
                                Dim datValidarCuentas As New CommonMembers.DataComprobarCContablesDestino(frm.IDEjercicioActual, dtRegularizacionG8y9)
                                datValidarCuentas = CommonMembers.ComprobarCContablesDestino(datValidarCuentas)
                                If datValidarCuentas.OK Then
                                    Dim datosAsientoReg As New DiarioContable.DataAsientoRegularizacion8y9(frm.IDEjercicioActual, dtRegularizacionG8y9, frm.FechaAsientoRegularizacionG8y9)
                                    datosAsientoReg.NAsiento = frm.NAsientoRegularizacionG8y9
                                    Dim NumApuntesRegularizacion As Integer = ExpertisApp.ExecuteTask(Of DiarioContable.DataAsientoRegularizacion8y9, Integer)(AddressOf DiarioContable.AsientoRegularizacionGrupos8y9, datosAsientoReg)
                                    If NumApuntesRegularizacion > 0 Then
                                        ReDim Preserve log.CreatedElements(log.CreatedElements.Length)
                                        log.CreatedElements(log.CreatedElements.Length - 1) = New CreateElement()
                                        log.CreatedElements(log.CreatedElements.Length - 1).NElement = ExpertisApp.Traslate("Se ha generado el Asiento de Regularización de los Grupos 8 y 9. Se han generado {0} apuntes.", NumApuntesRegularizacion)
                                    Else
                                        ReDim Preserve log.Errors(log.Errors.Length)
                                        log.Errors(log.Errors.Length - 1) = New ClassErrors
                                        log.Errors(log.Errors.Length - 1).Elements = ExpertisApp.Traslate("Regularización(Grupos 8 y 9)")
                                        log.Errors(log.Errors.Length - 1).MessageError = ExpertisApp.Traslate("No se ha generado el Asiento de Regularización de los Grupos 8 y 9.")
                                    End If
                                Else
                                    ReDim Preserve log.Errors(log.Errors.Length)
                                    log.Errors(log.Errors.Length - 1) = New ClassErrors
                                    log.Errors(log.Errors.Length - 1).Elements = ExpertisApp.Traslate("Regularización(Grupos 8 y 9)")
                                    log.Errors(log.Errors.Length - 1).MessageError = ExpertisApp.Traslate(datValidarCuentas.MensajeError)
                                End If
                            End If
                        End If

                        If frm.AsientoCierre Then
                            Dim datosAsientoCierre As New DiarioContable.DataAsiento(frm.IDEjercicioActual, frm.NAsientoCierre, frm.FechaAsientoCierre)
                            Dim NumApuntesCierre As Integer = ExpertisApp.ExecuteTask(Of DiarioContable.DataAsiento, Integer)(AddressOf DiarioContable.AsientoCierre, datosAsientoCierre)
                            If NumApuntesCierre > 0 Then
                                ReDim Preserve log.CreatedElements(log.CreatedElements.Length)
                                log.CreatedElements(log.CreatedElements.Length - 1) = New CreateElement()
                                log.CreatedElements(log.CreatedElements.Length - 1).NElement = ExpertisApp.Traslate("Se ha generado el Asiento de Cierre. Se han generado {0} apuntes.", NumApuntesCierre)
                            Else
                                ReDim Preserve log.Errors(log.Errors.Length)
                                log.Errors(log.Errors.Length - 1) = New ClassErrors
                                log.Errors(log.Errors.Length - 1).Elements = ExpertisApp.Traslate("Cierre")
                                log.Errors(log.Errors.Length - 1).MessageError = ExpertisApp.Traslate("No se ha generado el Asiento de Cierre.")
                            End If
                        End If

                        If frm.AsientoApertura Then
                            Dim datosAsientoAper As New DiarioContable.DataAsiento(frm.IDEjercicioSiguiente, frm.NAsientoApertura, frm.FechaAsientoApertura)
                            Dim NumApuntesApertura As Integer = ExpertisApp.ExecuteTask(Of DiarioContable.DataAsiento, Integer)(AddressOf DiarioContable.AsientoApertura, datosAsientoAper)
                            If NumApuntesApertura > 0 Then
                                ReDim Preserve log.CreatedElements(log.CreatedElements.Length)
                                log.CreatedElements(log.CreatedElements.Length - 1) = New CreateElement()
                                log.CreatedElements(log.CreatedElements.Length - 1).NElement = ExpertisApp.Traslate("Se ha generado el Asiento de Apertura. Se han generado {0} apuntes.", NumApuntesApertura)
                            Else
                                ReDim Preserve log.Errors(log.Errors.Length)
                                log.Errors(log.Errors.Length - 1) = New ClassErrors
                                log.Errors(log.Errors.Length - 1).Elements = ExpertisApp.Traslate("Apertura")
                                log.Errors(log.Errors.Length - 1).MessageError = ExpertisApp.Traslate("No se ha generado el Asiento de Apertura.")
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
            End If
        End If
    End Sub

End Class
