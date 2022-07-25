Public Class clsContabilizarProvisionAC
    Implements Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Engine.IAction.Execute
        Dim p As New Parametro

        If p.GestionInventarioPermanente Then
            ExpertisApp.GenerateMessage("Está utilizando la Gestión de Inventario permanente, ésta opción es incompatible con la misma.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim frm As New frmSeleccionarFecha
            If frm.ShowDialog = DialogResult.OK Then

                Dim IDEjercicio As String = ExpertisApp.ExecuteTask(Of Date, String)(AddressOf EjercicioContable.Predeterminado, frm.Fecha)
                Dim IDEjercicioTributario As String
                Dim dtEjercicio As DataTable = New EjercicioContable().SelOnPrimaryKey(IDEjercicio)
                If dtEjercicio.Rows.Count > 0 Then
                    IDEjercicioTributario = dtEjercicio.Rows(0)("IDEjercicioTributario") & String.Empty
                End If

                Dim PeriodosFecha As New Cierre.DataGetPeriodoFecha(IDEjercicio, frm.Fecha)
                Dim Periodo As Integer = ExpertisApp.ExecuteTask(Of Cierre.DataGetPeriodoFecha, Integer)(AddressOf Cierre.GetPeriodoFecha, PeriodosFecha)

                Dim PeriodosFechaSig As New Cierre.DataGetPeriodoFecha(IDEjercicio, frm.Fecha)
                PeriodosFechaSig = ExpertisApp.ExecuteTask(Of Cierre.DataGetPeriodoFecha, Cierre.DataGetPeriodoFecha)(AddressOf Cierre.GetPeriodoSiguienteFecha, PeriodosFechaSig)


                Dim blnContinuar As Boolean = True

                Dim f As New Filter(FilterUnionOperator.Or)
                Dim fPeriodoActual As New Filter
                fPeriodoActual.Add(New StringFilterItem("IDEjercicio", IDEjercicio))
                fPeriodoActual.Add(New NumberFilterItem("Mes", Periodo))
                fPeriodoActual.Add(New NumberFilterItem("IDTipoApunte", enumDiarioTipoApunte.ACProvision))
                f.Add(fPeriodoActual)

                If Length(PeriodosFechaSig.IDEjercicioSiguiente) > 0 Then
                    Dim fPeriodoSiguiente As New Filter
                    fPeriodoSiguiente.Add(New StringFilterItem("IDEjercicio", PeriodosFechaSig.IDEjercicioSiguiente))
                    fPeriodoSiguiente.Add(New NumberFilterItem("Mes", PeriodosFechaSig.PeriodoSiguiente))
                    fPeriodoSiguiente.Add(New NumberFilterItem("IDTipoApunte", enumDiarioTipoApunte.CompensacionACProvision))
                    f.Add(fPeriodoSiguiente)
                End If

                If p.ContabilidadMultiple AndAlso Length(IDEjercicioTributario) > 0 Then
                    Dim fPeriodoActualTrib As New Filter
                    fPeriodoActualTrib.Add(New StringFilterItem("IDEjercicio", IDEjercicioTributario))
                    fPeriodoActualTrib.Add(New NumberFilterItem("Mes", Periodo))
                    fPeriodoActualTrib.Add(New NumberFilterItem("IDTipoApunte", enumDiarioTipoApunte.ACProvision))
                    f.Add(fPeriodoActualTrib)

                    PeriodosFechaSig = New Cierre.DataGetPeriodoFecha(IDEjercicioTributario, frm.Fecha)
                    PeriodosFechaSig = ExpertisApp.ExecuteTask(Of Cierre.DataGetPeriodoFecha, Cierre.DataGetPeriodoFecha)(AddressOf Cierre.GetPeriodoSiguienteFecha, PeriodosFechaSig)

                    If Length(PeriodosFechaSig.IDEjercicioSiguiente) > 0 Then
                        Dim fPeriodoSiguienteTrib As New Filter
                        fPeriodoSiguienteTrib.Add(New StringFilterItem("IDEjercicio", PeriodosFechaSig.IDEjercicioSiguiente))
                        fPeriodoSiguienteTrib.Add(New NumberFilterItem("Mes", PeriodosFechaSig.PeriodoSiguiente))
                        fPeriodoSiguienteTrib.Add(New NumberFilterItem("IDTipoApunte", enumDiarioTipoApunte.CompensacionACProvision))
                        f.Add(fPeriodoSiguienteTrib)
                    End If
                End If

                Dim dtExisteAsiento As DataTable = New BE.DataEngine().Filter("VFrmBorrarApuntesDiarioContable", f)
                If dtExisteAsiento.Rows.Count > 0 Then

                    Dim AsientosEliminar As String
                    Dim Ejercicios As List(Of Object) = (From c In dtExisteAsiento Select c("IDEjercicio") Distinct).ToList
                    For Each Ejercicio As String In Ejercicios
                        Dim NAsientosEj As List(Of Object) = (From c In dtExisteAsiento Where c("IDEjercicio") = Ejercicio Select c("NAsiento") Distinct).ToList
                        AsientosEliminar &= Strings.Join(NAsientosEj.ToArray, ",") & " (Ejercicio: " & Ejercicio & ")" & vbNewLine
                    Next

                    If ExpertisApp.GenerateMessage("Ya se ha realizado la provisión en el Período indicado. Se van a eliminar los siguientes asientos contables.{0}{1}{2}¿Desea continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, vbNewLine, AsientosEliminar, vbNewLine) = DialogResult.No Then
                        blnContinuar = False
                    Else
                        '//Borrar asientos. 
                        Dim EjercicioCerrado As List(Of DataRow) = (From c In dtExisteAsiento Where Not c.IsNull("EjercicioCerrado") AndAlso c("EjercicioCerrado") = True Select c).ToList
                        If Not EjercicioCerrado Is Nothing AndAlso EjercicioCerrado.Count > 0 Then
                            blnContinuar = False
                            ExpertisApp.GenerateMessage("Alguno de los Asientos, está incluido en un Ejercicio Cerrado. Se cancelará el proceso.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            Dim PeriodoCerrado As List(Of DataRow) = (From c In dtExisteAsiento Where Not c.IsNull("MesCierre") Select c).ToList
                            If PeriodoCerrado.Count > 0 Then
                                blnContinuar = False
                                ExpertisApp.GenerateMessage("Alguno de los Asientos, está incluido en un Periodo Cerrado. Se cancelará el proceso.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                For Each Ejercicio As String In Ejercicios
                                    Dim objNAsientos As New Filter(FilterUnionOperator.Or)
                                    Dim NAsientosEj As List(Of Object) = (From c In dtExisteAsiento Where c("IDEjercicio") = Ejercicio Select c("NAsiento") Distinct).ToList
                                    For Each NAsiento As Integer In NAsientosEj
                                        objNAsientos.Add(New NumberFilterItem("NAsiento", NAsiento))
                                    Next
                                    If objNAsientos.Count > 0 Then
                                        Dim dataDelete As New DiarioContable.DataDeleteWhereFilter(Ejercicio, objNAsientos)
                                        ExpertisApp.ExecuteTask(Of DiarioContable.DataDeleteWhereFilter)(AddressOf DiarioContable.DeleteWhereFilter, dataDelete)
                                    End If
                                Next
                            End If
                        End If
                    End If
                End If

                If blnContinuar Then
                    Dim SimInfo As New DataSimulacionContableInfoACProvision(frm.Fecha, Nothing)
                    SimInfo.TipoContabilizacion = enumTipoContabilizacion.tcACProvision
                    SimInfo.Caption = ExpertisApp.Traslate("Simulación Contable - ALBARAN COMPRA PROVISION -")
                    SimInfo.FechaDesde = frm.FechaDesde
                    SimInfo.FechaHasta = frm.FechaHasta
                    ExpertisApp.OpenForm("CISIMUCONT", , SimInfo)
                End If

            End If
        End If
    End Sub

End Class
