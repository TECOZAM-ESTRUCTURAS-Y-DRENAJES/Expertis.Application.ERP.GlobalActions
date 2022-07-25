Public Class frmDeshacerCierreContableEjercicio

#Region " Propiedades "

    Public Property AsientoRegularizacion() As Boolean
        Get
            Return chkRegularizacion.Checked
        End Get
        Set(ByVal value As Boolean)
            chkRegularizacion.Checked = value
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

    Public Property AsientoCierre() As Boolean
        Get
            Return chkCierre.Checked
        End Get
        Set(ByVal value As Boolean)
            chkCierre.Checked = value
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

        Dim CuentasRegularizacion As String = ExpertisApp.ExecuteTask(Of Object, String)(AddressOf DiarioContable.GetCuentasRegularizacion, Nothing)


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
            If dtAsientos.Rows.Count = 0 Then
                Me.chkRegularizacion.Checked = False
                Me.chkRegularizacion.Enabled = False

                Me.chkRegularizacionG8y9.Checked = False
                Me.chkRegularizacionG8y9.Enabled = False

                Me.chkCierre.Checked = False
                Me.chkCierre.Enabled = False
            Else

                Dim Regularizacion As List(Of DataRow) = (From Apte In dtAsientos _
                                                          Where Apte("IDTipoApunte") = enumDiarioTipoApunte.Regularizacion _
                                                          Select Apte).ToList
                If Regularizacion Is Nothing OrElse Regularizacion.Count = 0 Then
                    Me.chkRegularizacion.Checked = False
                    Me.chkRegularizacion.Enabled = False
                End If

                Dim RegularizacionG8y9 As List(Of DataRow) = (From Apte In dtAsientos _
                                                              Where Apte("IDTipoApunte") = enumDiarioTipoApunte.RegularizacionGrupos8y9 _
                                                              Select Apte).ToList
                If RegularizacionG8y9 Is Nothing OrElse RegularizacionG8y9.Count = 0 Then
                    Me.chkRegularizacionG8y9.Checked = False
                    Me.chkRegularizacionG8y9.Enabled = False
                End If
              
                Dim Cierre As List(Of DataRow) = (From c In dtAsientos Where c("IDTipoApunte") = enumDiarioTipoApunte.Cierre Select c).ToList
                If Cierre Is Nothing OrElse Cierre.Count = 0 Then
                    Me.chkCierre.Checked = False
                    Me.chkCierre.Enabled = False
                End If
            End If
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
            If dtAsientos.Rows.Count = 0 Then
                Me.chkApertura.Checked = False
                Me.chkApertura.Enabled = False
            End If
        End If
    End Sub

#End Region

#Region " Aceptar/Cancelar "

    Protected Overridable Sub CmbAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbAceptar.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Protected Overridable Sub cmbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

#End Region

   
End Class