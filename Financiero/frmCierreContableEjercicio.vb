Public Class frmCierreContableEjercicio

#Region " Propiedades "

    Public Property AsientoRegularizacion() As Boolean
        Get
            Return chkRegularizacion.Checked
        End Get
        Set(ByVal value As Boolean)
            chkRegularizacion.Checked = value
        End Set
    End Property
    Protected mNAsientoRegularizacion As Integer
    Public Property NAsientoRegularizacion() As Integer
        Get
            Return mNAsientoRegularizacion
        End Get
        Set(ByVal value As Integer)
            mNAsientoRegularizacion = value
        End Set
    End Property

    Public Property AsientoRegularizacionG8y9() As Boolean
        Get
            Return chkRegularizacionG8y9.Checked
        End Get
        Set(ByVal value As Boolean)
            chkRegularizacionG8y9.Checked = value
        End Set
    End Property
    Protected mNAsientoRegularizacionG8y9 As Integer
    Public Property NAsientoRegularizacionG8y9() As Integer
        Get
            Return mNAsientoRegularizacionG8y9
        End Get
        Set(ByVal value As Integer)
            mNAsientoRegularizacionG8y9 = value
        End Set
    End Property

    Public Property AsientoCierre() As Boolean
        Get
            Return chkCierre.Checked
        End Get
        Set(ByVal value As Boolean)
            chkCierre.Checked = value
        End Set
    End Property
    Protected mNAsientoCierre As Integer
    Public Property NAsientoCierre() As Integer
        Get
            Return mNAsientoCierre
        End Get
        Set(ByVal value As Integer)
            mNAsientoCierre = value
        End Set
    End Property

    Public Property AsientoApertura() As Boolean
        Get
            Return chkApertura.Checked
        End Get
        Set(ByVal value As Boolean)
            chkApertura.Checked = value
        End Set
    End Property
    Protected mNAsientoApertura As Integer
    Public Property NAsientoApertura() As Integer
        Get
            Return mNAsientoApertura
        End Get
        Set(ByVal value As Integer)
            mNAsientoApertura = value
        End Set
    End Property

    Public Property FechaAsientoRegularizacion() As Date
        Get
            Return Me.cbxFechaRegularizacion.Value
        End Get
        Set(ByVal value As Date)
            Me.cbxFechaRegularizacion.Value = value
        End Set
    End Property
    Public Property FechaAsientoRegularizacionG8y9() As Date
        Get
            Return Me.cbxFechaRegularizacionG8y9.Value
        End Get
        Set(ByVal value As Date)
            Me.cbxFechaRegularizacionG8y9.Value = value
        End Set
    End Property
    Public Property FechaAsientoCierre() As Date
        Get
            Return Me.cbxFechaCierre.Value
        End Get
        Set(ByVal value As Date)
            Me.cbxFechaCierre.Value = value
        End Set
    End Property
    Public Property FechaAsientoApertura() As Date
        Get
            Return Me.cbxFechaApertura.Value
        End Get
        Set(ByVal value As Date)
            Me.cbxFechaApertura.Value = value
        End Set
    End Property

    Public Property IDCContablePerdidas() As String
        Get
            Return Me.AdvIDCuentaPerdidas.Value
        End Get
        Set(ByVal value As String)
            Me.AdvIDCuentaPerdidas.Value = value
        End Set
    End Property

    Public Property IDEjercicioActual() As String
        Get
            Return Me.ulblIDEjActual.Text
        End Get
        Set(ByVal value As String)
            Me.ulblIDEjActual.Text = value
        End Set
    End Property

    Public Property IDEjercicioSiguiente() As String
        Get
            Return Me.ulblIDEjSiguiente.Text
        End Get
        Set(ByVal value As String)
            Me.ulblIDEjSiguiente.Text = value
        End Set
    End Property


#End Region

#Region " Carga del formulario "

    Protected mdtEjercicioActual As DataTable
    Protected mdtEjercicioSiguiente As DataTable
    'Protected mCuentasRegularizacion As List(Of String)
    'Protected mCuentasRegularizacionG8y9 As List(Of String)


    Public Overridable Function Abrir(ByVal IDEjercicioActual As String) As DialogResult
        Dim ej As New EjercicioContable
        Dim DescEjercicioActual As String
        If Length(IDEjercicioActual) = 0 Then
            ExpertisApp.GenerateMessage("Debe indicar un Ejercicio Actual", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return Windows.Forms.DialogResult.Cancel
        Else
            mdtEjercicioActual = ej.SelOnPrimaryKey(IDEjercicioActual)
            If mdtEjercicioActual.Rows.Count = 0 Then
                ExpertisApp.GenerateMessage("El Ejercicio Contable {0} no existe en el sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information, Quoted(IDEjercicioActual))
                Return Windows.Forms.DialogResult.Cancel
            Else
                DescEjercicioActual = mdtEjercicioActual.Rows(0)("DescEjercicio")
                Me.AdvIDCuentaPerdidas.MaxLength = mdtEjercicioActual.Rows(0)("DigitosAuxiliar")
            End If
        End If

        Me.ulblIDEjActual.Text = IDEjercicioActual
        Me.chkRegularizacion.Text = Me.chkRegularizacion.Text & Space(1) & Quoted(Me.ulblIDEjActual.Text)
        Me.chkRegularizacionG8y9.Text = Me.chkRegularizacionG8y9.Text & Space(1) & Quoted(Me.ulblIDEjActual.Text)
        Me.chkCierre.Text = Me.chkCierre.Text & Space(1) & Quoted(Me.ulblIDEjActual.Text)
        Me.ulblDescEjActual.Text = DescEjercicioActual

        Dim f As New Filter
        f.Add(New StringFilterItem("IDEjercicioAnterior", IDEjercicioActual))
        Dim dtEjSiguiente As DataTable = ej.Filter(f)
        If dtEjSiguiente.Rows.Count = 1 Then
            Me.ulblIDEjSiguiente.Text = dtEjSiguiente.Rows(0)("IDEjercicio")
            Me.ulblDescEjSiguiente.Text = dtEjSiguiente.Rows(0)("DescEjercicio")
            Me.chkApertura.Text = Me.chkApertura.Text & Space(1) & Quoted(Me.ulblIDEjSiguiente.Text)
            mdtEjercicioSiguiente = dtEjSiguiente
        End If

        Me.chkRegularizacion.Checked = True
        Me.chkRegularizacionG8y9.Checked = True
        Me.chkCierre.Checked = True
        Me.chkApertura.Checked = True

        If dtEjSiguiente.Rows.Count > 1 Then
            Dim IDEjercicios As List(Of String) = (From c In dtEjSiguiente Select CStr(c("IDEjercicio")) Distinct).ToList
            Dim strEjercicios As String = String.Join(",", IDEjercicios.ToArray)
            ExpertisApp.GenerateMessage("Hay más de un ejercicio siguiente para el mismo Ejercicio actual. Revise sus datos.{0}{1}", MessageBoxButtons.OK, MessageBoxIcon.Information, vbNewLine, strEjercicios)
            Me.chkApertura.Checked = False
            Me.chkApertura.Enabled = False
        End If
        'Dim CuentasRegularizacion As String = ExpertisApp.ExecuteTask(Of Object, String)(AddressOf DiarioContable.GetCuentasRegularizacion, Nothing)
        'mCuentasRegularizacion = Strings.Split(CuentasRegularizacion, ",").ToList
        'mCuentasRegularizacionG8y9 = New List(Of String)(New String() {"8", "9"})

        ComprobarAsientosEnEjercicioActual()
        ComprobarAsientosEnEjercicioSiguiente()

        Return Me.ShowDialog
    End Function

    Protected Overridable Sub ComprobarAsientosEnEjercicioActual()
        If Length(Me.ulblIDEjActual.Text) > 0 Then
            Dim fTipoApunte As New Filter(FilterUnionOperator.Or)
            fTipoApunte.Add(New NumberFilterItem("IDTipoApunte", enumDiarioTipoApunte.Regularizacion))
            fTipoApunte.Add(New NumberFilterItem("IDTipoApunte", enumDiarioTipoApunte.RegularizacionGrupos8y9))
            fTipoApunte.Add(New NumberFilterItem("IDTipoApunte", enumDiarioTipoApunte.Cierre))

            Dim fDC As New Filter
            fDC.Add(New StringFilterItem("IDEjercicio", Me.ulblIDEjActual.Text))
            fDC.Add(fTipoApunte)
            Dim dtAsientos As DataTable = New BE.DataEngine().Filter("tbDiarioContable", fDC, "IDTipoApunte,NAsiento,IDCContable")
            If dtAsientos.Rows.Count > 0 Then

                Dim Regularizacion As List(Of DataRow) = (From Apte In dtAsientos _
                                                          Where Apte("IDTipoApunte") = enumDiarioTipoApunte.Regularizacion _
                                                          Select Apte).ToList
                If Not Regularizacion Is Nothing AndAlso Regularizacion.Count > 0 Then
                    Me.chkRegularizacion.Checked = False
                    Me.chkRegularizacion.Enabled = False
                End If

                Dim RegularizacionG8y9 As List(Of DataRow) = (From Apte In dtAsientos _
                                                              Where Apte("IDTipoApunte") = enumDiarioTipoApunte.RegularizacionGrupos8y9 _
                                                              Select Apte).ToList
                If Not RegularizacionG8y9 Is Nothing AndAlso RegularizacionG8y9.Count > 0 Then
                    Me.chkRegularizacionG8y9.Checked = False
                    Me.chkRegularizacionG8y9.Enabled = False
                End If

                Dim Cierre As List(Of DataRow) = (From c In dtAsientos Where c("IDTipoApunte") = enumDiarioTipoApunte.Cierre Select c).ToList
                If Not Cierre Is Nothing AndAlso Cierre.Count > 0 Then
                    Me.chkCierre.Checked = False
                    Me.chkCierre.Enabled = False
                End If
            End If
        Else
            Me.chkRegularizacion.Checked = False
            Me.chkRegularizacion.Enabled = False

            Me.chkRegularizacionG8y9.Checked = False
            Me.chkRegularizacionG8y9.Enabled = False

            Me.chkCierre.Checked = False
            Me.chkCierre.Enabled = False
        End If
    End Sub

    Protected Overridable Sub ComprobarAsientosEnEjercicioSiguiente()
        If Length(Me.ulblIDEjSiguiente.Text) > 0 Then
            Dim fTipoApunte As New Filter(FilterUnionOperator.Or)
            fTipoApunte.Add(New NumberFilterItem("IDTipoApunte", enumDiarioTipoApunte.Apertura))

            Dim fDC As New Filter
            fDC.Add(New StringFilterItem("IDEjercicio", Me.ulblIDEjSiguiente.Text))
            fDC.Add(fTipoApunte)
            Dim dtAsientos As DataTable = New BE.DataEngine().Filter("tbDiarioContable", fDC, "IDTipoApunte,NAsiento")
            If dtAsientos.Rows.Count > 0 Then
                Me.chkApertura.Checked = False
                Me.chkApertura.Enabled = False
            End If
        Else
            Me.chkApertura.Checked = False
            Me.chkApertura.Enabled = False
        End If
    End Sub

#End Region

#Region " Configuración de los checks "

    Protected Overridable Sub chkRegularizacion_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRegularizacion.CheckedChanged
        SettingAsientoRegularizacion()
    End Sub

    Protected Overridable Sub chkRegularizacionG8y9_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRegularizacionG8y9.CheckedChanged
        SettingAsientoRegularizacionG8y9()
    End Sub

    Protected Overridable Sub chkCierre_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCierre.CheckedChanged
        SettingAsientoCierre()
    End Sub

    Protected Overridable Sub chkApertura_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkApertura.CheckedChanged
        SettingAsientoApertura()
    End Sub

    Protected Overridable Sub SettingAsientoRegularizacion()
        If Me.chkRegularizacion.Checked Then
            Me.cbxFechaRegularizacion.Enabled = True
            Me.AdvIDCuentaPerdidas.Enabled = True
            If Length(Me.ulblIDEjActual.Text) > 0 Then
                Me.txtNAsientoRegularizacion.Enabled = True
                Me.txtNAsientoRegularizacion.Text = ExpertisApp.ExecuteTask(Of String, Integer)(AddressOf EjercicioContable.IncNAsiento, Me.ulblIDEjActual.Text)
            End If
        Else
            Me.cbxFechaRegularizacion.Enabled = False
            Me.cbxFechaRegularizacion.Value = System.DBNull.Value
            Me.AdvIDCuentaPerdidas.Enabled = False
            Me.AdvIDCuentaPerdidas.Value = System.DBNull.Value
            Me.txtNAsientoRegularizacion.Enabled = False
            Me.txtNAsientoRegularizacion.Text = String.Empty
        End If
    End Sub

    Protected Overridable Sub SettingAsientoRegularizacionG8y9()
        If Me.chkRegularizacionG8y9.Checked Then
            Me.cbxFechaRegularizacionG8y9.Enabled = True
            If Length(Me.ulblIDEjActual.Text) > 0 Then
                Me.txtNAsientoRegularizacionG8y9.Enabled = True
                Me.txtNAsientoRegularizacionG8y9.Text = ExpertisApp.ExecuteTask(Of String, Integer)(AddressOf EjercicioContable.IncNAsiento, Me.ulblIDEjActual.Text)
            End If
        Else
            Me.cbxFechaRegularizacionG8y9.Enabled = False
            Me.cbxFechaRegularizacionG8y9.Value = System.DBNull.Value
            Me.txtNAsientoRegularizacionG8y9.Enabled = False
            Me.txtNAsientoRegularizacionG8y9.Text = String.Empty
        End If
    End Sub

    Protected Overridable Sub SettingAsientoCierre()
        If Me.chkCierre.Checked Then
            Me.cbxFechaCierre.Enabled = True

            If Length(Me.ulblIDEjActual.Text) > 0 Then
                Me.txtNAsientoCierre.Enabled = True
                Me.txtNAsientoCierre.Text = ExpertisApp.ExecuteTask(Of String, Integer)(AddressOf EjercicioContable.IncNAsiento, Me.ulblIDEjActual.Text)
            End If
        Else
            Me.cbxFechaCierre.Enabled = False
            Me.cbxFechaCierre.Value = System.DBNull.Value

            Me.txtNAsientoCierre.Enabled = False
            Me.txtNAsientoCierre.Text = String.Empty
        End If
    End Sub

    Protected Overridable Sub SettingAsientoApertura()
        If Me.chkApertura.Checked Then
            Me.cbxFechaApertura.Enabled = True

            If Length(Me.ulblIDEjSiguiente.Text) > 0 Then
                Me.txtNAsientoApertura.Enabled = True
                Me.txtNAsientoApertura.Text = ExpertisApp.ExecuteTask(Of String, Integer)(AddressOf EjercicioContable.IncNAsiento, Me.ulblIDEjSiguiente.Text)
            End If
        Else
            Me.cbxFechaApertura.Enabled = False
            Me.cbxFechaApertura.Value = System.DBNull.Value

            Me.txtNAsientoApertura.Enabled = False
            Me.txtNAsientoApertura.Text = String.Empty
        End If
    End Sub

#End Region

#Region " Aceptar/Cancelar "

    Protected Overridable Sub CmbAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbAceptar.Click
        If ValidarEjercicios() AndAlso ValidarDatosRegularizacion() AndAlso ValidarDatosRegularizacionG8y9() AndAlso ValidarDatosCierre() AndAlso ValidarDatosApertura() Then
            If Me.chkRegularizacion.Checked Then
                mNAsientoRegularizacion = Nz(Me.txtNAsientoRegularizacion.Text, 0)
            Else
                mNAsientoRegularizacion = 0
            End If
            If Me.chkRegularizacionG8y9.Checked Then
                mNAsientoRegularizacionG8y9 = Nz(Me.txtNAsientoRegularizacionG8y9.Text, 0)
            Else
                mNAsientoRegularizacionG8y9 = 0
            End If
            If Me.chkCierre.Checked Then
                mNAsientoCierre = Nz(Me.txtNAsientoCierre.Text, 0)
            Else
                mNAsientoCierre = 0
            End If
            If Me.chkApertura.Checked Then
                mNAsientoApertura = Nz(Me.txtNAsientoApertura.Text, 0)
            Else
                mNAsientoApertura = 0
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Protected Overridable Sub cmbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

#End Region

#Region " Validaciones "

    Protected Overridable Function ValidarEjercicios() As Boolean
        ValidarEjercicios = True

        If (Me.chkRegularizacion.Checked OrElse Me.chkRegularizacionG8y9.Checked OrElse Me.chkCierre.Checked) AndAlso Length(Me.lblEjActual.Text) = 0 Then
            ExpertisApp.GenerateMessage("No existe un Ejercicio actual. No se realizarán los Asientos de Regularización/Cierre.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.chkRegularizacion.Checked = False
            Me.chkCierre.Checked = False
            ValidarEjercicios = False
        End If

        If Me.chkApertura.Checked AndAlso Length(Me.lblEjSiguiente.Text) = 0 Then
            ExpertisApp.GenerateMessage("No existe un Ejercicio siguiente. No se realizará el Asiento de Apertura.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.chkApertura.Checked = False
            ValidarEjercicios = False
        End If

        If (Me.chkRegularizacion.Checked OrElse Me.chkRegularizacionG8y9.Checked OrElse Me.chkCierre.Checked) AndAlso Length(Me.lblEjActual.Text) > 0 Then
            Dim dtEjercicio As DataTable = New EjercicioContable().SelOnPrimaryKey(Me.lblEjActual.Text)
            If dtEjercicio.Rows.Count > 0 AndAlso dtEjercicio.Rows(0)("EjercicioCerrado") Then
                ExpertisApp.GenerateMessage("El Ejercicio {0} está cerrado.", MessageBoxButtons.OK, MessageBoxIcon.Information, Me.lblEjActual.Text)
                ValidarEjercicios = False
            End If
        End If

        If Me.chkApertura.Checked AndAlso Length(Me.lblEjSiguiente.Text) > 0 Then
            Dim dtEjercicio As DataTable = New EjercicioContable().SelOnPrimaryKey(Me.lblEjSiguiente.Text)
            If dtEjercicio.Rows.Count > 0 AndAlso dtEjercicio.Rows(0)("EjercicioCerrado") Then
                ExpertisApp.GenerateMessage("El Ejercicio {0} está cerrado.", MessageBoxButtons.OK, MessageBoxIcon.Information, Me.lblEjSiguiente.Text)
                ValidarEjercicios = False
            End If
        End If
    End Function

    Protected FORMATO_FECHA As String = "dd/MM/yyyy"
    Protected Overridable Function ValidarDatosRegularizacion() As Boolean
        ValidarDatosRegularizacion = True
        If Me.chkRegularizacion.Checked Then
            If Nz(Me.cbxFechaRegularizacion.Value, cnMinDate) = cnMinDate Then
                ExpertisApp.GenerateMessage("Debe indicar la Fecha del Asiento de Regularización.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ValidarDatosRegularizacion = False
            Else
                If Me.cbxFechaRegularizacion.Value < mdtEjercicioActual.Rows(0)("FechaDesde") OrElse Me.cbxFechaRegularizacion.Value > mdtEjercicioActual.Rows(0)("FechaHasta") Then
                    ExpertisApp.GenerateMessage("La fecha {0} está fuera del intervalo del ejercicio (desde: {1} hasta: {2}).", MessageBoxButtons.OK, MessageBoxIcon.Warning, Format(Me.cbxFechaRegularizacion.Value, FORMATO_FECHA), Format(mdtEjercicioActual.Rows(0)("FechaDesde"), FORMATO_FECHA), Format(mdtEjercicioActual.Rows(0)("FechaHasta"), FORMATO_FECHA))
                    ValidarDatosRegularizacion = False
                Else
                    If Length(Me.AdvIDCuentaPerdidas.Value) = 0 Then
                        ExpertisApp.GenerateMessage("Debe indicar la Cuenta de Pérdidas para el Asiento de Regularización.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ValidarDatosRegularizacion = False
                    Else
                        If Nz(Me.txtNAsientoRegularizacion.Text, 0) = 0 Then
                            ExpertisApp.GenerateMessage("Debe indicar un Nº de Asiento para el Asiento de Regularización.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ValidarDatosRegularizacion = False
                        End If
                    End If
                End If
            End If
        End If
    End Function

    Protected Overridable Function ValidarDatosRegularizacionG8y9() As Boolean
        ValidarDatosRegularizacionG8y9 = True
        If Me.chkRegularizacionG8y9.Checked Then
            If Nz(Me.cbxFechaRegularizacionG8y9.Value, cnMinDate) = cnMinDate Then
                ExpertisApp.GenerateMessage("Debe indicar la Fecha del Asiento de Regularización de los Grupos 8 y 9.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ValidarDatosRegularizacionG8y9 = False
            Else
                If Me.cbxFechaRegularizacionG8y9.Value < mdtEjercicioActual.Rows(0)("FechaDesde") OrElse Me.cbxFechaRegularizacionG8y9.Value > mdtEjercicioActual.Rows(0)("FechaHasta") Then
                    ExpertisApp.GenerateMessage("La fecha {0} está fuera del intervalo del ejercicio (desde: {1} hasta: {2}).", MessageBoxButtons.OK, MessageBoxIcon.Warning, Format(Me.cbxFechaRegularizacionG8y9.Value, FORMATO_FECHA), Format(mdtEjercicioActual.Rows(0)("FechaDesde"), FORMATO_FECHA), Format(mdtEjercicioActual.Rows(0)("FechaHasta"), FORMATO_FECHA))
                    ValidarDatosRegularizacionG8y9 = False
                Else
                    If Nz(Me.txtNAsientoRegularizacionG8y9.Text, 0) = 0 Then
                        ExpertisApp.GenerateMessage("Debe indicar un Nº de Asiento para el Asiento de Regularización de los Grupos 8 y 9.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ValidarDatosRegularizacionG8y9 = False
                    End If
                End If
            End If
        End If
    End Function

    Protected Overridable Function ValidarDatosCierre() As Boolean
        ValidarDatosCierre = True
        If Me.chkCierre.Checked Then
            If Nz(Me.cbxFechaCierre.Value, cnMinDate) = cnMinDate Then
                ExpertisApp.GenerateMessage("Debe indicar la Fecha del Asiento de Cierre.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ValidarDatosCierre = False
            Else
                If Me.cbxFechaCierre.Value < mdtEjercicioActual.Rows(0)("FechaDesde") OrElse Me.cbxFechaCierre.Value > mdtEjercicioActual.Rows(0)("FechaHasta") Then
                    ExpertisApp.GenerateMessage("La fecha {0} está fuera del intervalo del ejercicio (desde: {1} hasta: {2}).", MessageBoxButtons.OK, MessageBoxIcon.Warning, Format(Me.cbxFechaCierre.Value, FORMATO_FECHA), Format(mdtEjercicioActual.Rows(0)("FechaDesde"), FORMATO_FECHA), Format(mdtEjercicioActual.Rows(0)("FechaHasta"), FORMATO_FECHA))
                    ValidarDatosCierre = False
                Else
                    If Nz(Me.txtNAsientoCierre.Text, 0) = 0 Then
                        ExpertisApp.GenerateMessage("Debe indicar un Nº de Asiento para el Asiento de Cierre.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ValidarDatosCierre = False
                    End If
                End If
            End If
        End If
    End Function

    Protected Overridable Function ValidarDatosApertura() As Boolean
        ValidarDatosApertura = True
        If Me.chkApertura.Checked Then
            If Nz(Me.cbxFechaApertura.Value, cnMinDate) = cnMinDate Then
                ExpertisApp.GenerateMessage("Debe indicar la Fecha del Asiento de Apertura.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ValidarDatosApertura = False
            Else
                If Me.cbxFechaApertura.Value < mdtEjercicioSiguiente.Rows(0)("FechaDesde") OrElse Me.cbxFechaApertura.Value > mdtEjercicioSiguiente.Rows(0)("FechaHasta") Then
                    ExpertisApp.GenerateMessage("La fecha {0} está fuera del intervalo del ejercicio (desde: {1} hasta: {2}).", MessageBoxButtons.OK, MessageBoxIcon.Warning, Format(Me.cbxFechaApertura.Value, FORMATO_FECHA), Format(mdtEjercicioSiguiente.Rows(0)("FechaDesde"), FORMATO_FECHA), Format(mdtEjercicioSiguiente.Rows(0)("FechaHasta"), FORMATO_FECHA))
                    ValidarDatosApertura = False
                Else
                    If Nz(Me.txtNAsientoApertura.Text, 0) = 0 Then
                        ExpertisApp.GenerateMessage("Debe indicar un Nº de Asiento para el Asiento de Apertura.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ValidarDatosApertura = False
                    End If
                End If
            End If
        End If
    End Function

#End Region

#Region " Otros controles "

    Protected Overridable Sub AdvIDCuentaPerdidas_SetPredefinedFilter(ByVal sender As Object, ByVal e As Engine.UI.AdvSearchFilterEventArgs) Handles AdvIDCuentaPerdidas.SetPredefinedFilter
        If Length(Me.ulblIDEjActual.Text) > 0 Then
            e.Filter.Add(New StringFilterItem("IDEjercicio", Me.ulblIDEjActual.Text))
            e.Filter.Add("Auxiliar", FilterOperator.Equal, True)
        Else
            e.Filter.Add(New NoRowsFilterItem)
        End If
    End Sub

    Protected Overridable Sub AdvIDCuentaPerdidas_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles AdvIDCuentaPerdidas.Validating
        If Length(AdvIDCuentaPerdidas.Text) > 0 Then
            AdvIDCuentaPerdidas.Text = PuntoPorCero(AdvIDCuentaPerdidas.Text, AdvIDCuentaPerdidas.MaxLength, Me.ulblIDEjActual.Text)
            Dim PC As New PlanContable
            Dim dtPlanCont As DataTable = PC.SelOnPrimaryKey(Me.ulblIDEjActual.Text, AdvIDCuentaPerdidas.Text)
            If IsNothing(dtPlanCont) OrElse dtPlanCont.Rows.Count = 0 Then
                ExpertisApp.GenerateMessage("La Cuenta Contable, no existe en el Ejercicio actual.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                e.Cancel = True
            End If
        End If
    End Sub

    Protected Overridable Sub NAsiento_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNAsientoRegularizacion.Validating, txtNAsientoRegularizacionG8y9.Validating, txtNAsientoCierre.Validating, txtNAsientoApertura.Validating
        If Length(sender.Text) > 0 AndAlso Not IsNumeric(sender.Text) Then
            e.Cancel = True
            ExpertisApp.GenerateMessage("El valor introducido debe ser numérico.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            sender.Text = String.Empty
            sender.Focus()
        End If
    End Sub

#End Region

  
End Class