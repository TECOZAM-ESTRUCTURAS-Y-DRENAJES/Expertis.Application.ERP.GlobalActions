<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCierreContableEjercicio
    Inherits Solmicro.Expertis.Engine.UI.FormBase

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlBottom = New Solmicro.Expertis.Engine.UI.Panel
        Me.cmbCancelar = New Solmicro.Expertis.Engine.UI.Button
        Me.CmbAceptar = New Solmicro.Expertis.Engine.UI.Button
        Me.FraMain = New Solmicro.Expertis.Engine.UI.Frame
        Me.pnlEjericicios = New Solmicro.Expertis.Engine.UI.Panel
        Me.ulblIDEjSiguiente = New Solmicro.Expertis.Engine.UI.UnderLineLabel
        Me.ulblIDEjActual = New Solmicro.Expertis.Engine.UI.UnderLineLabel
        Me.ulblDescEjSiguiente = New Solmicro.Expertis.Engine.UI.UnderLineLabel
        Me.ulblDescEjActual = New Solmicro.Expertis.Engine.UI.UnderLineLabel
        Me.lblEjSiguiente = New Solmicro.Expertis.Engine.UI.Label
        Me.lblEjActual = New Solmicro.Expertis.Engine.UI.Label
        Me.FraAsientoApertura = New Solmicro.Expertis.Engine.UI.Frame
        Me.txtNAsientoApertura = New Solmicro.Expertis.Engine.UI.TextBox
        Me.lblNAsientoApertura = New Solmicro.Expertis.Engine.UI.Label
        Me.chkApertura = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.cbxFechaApertura = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.lblFechaApertura = New Solmicro.Expertis.Engine.UI.Label
        Me.FraAsientoCierre = New Solmicro.Expertis.Engine.UI.Frame
        Me.txtNAsientoCierre = New Solmicro.Expertis.Engine.UI.TextBox
        Me.lblNAsientoCierre = New Solmicro.Expertis.Engine.UI.Label
        Me.chkCierre = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.cbxFechaCierre = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.lblFechaCierre = New Solmicro.Expertis.Engine.UI.Label
        Me.FraAsientoRegularizacion = New Solmicro.Expertis.Engine.UI.Frame
        Me.txtNAsientoRegularizacion = New Solmicro.Expertis.Engine.UI.TextBox
        Me.lblNAsientoRegularizacion = New Solmicro.Expertis.Engine.UI.Label
        Me.chkRegularizacion = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.AdvIDCuentaPerdidas = New Solmicro.Expertis.Engine.UI.AdvSearch
        Me.cbxFechaRegularizacion = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.lblCuentaPerdidas = New Solmicro.Expertis.Engine.UI.Label
        Me.lblFechaRegularizacion = New Solmicro.Expertis.Engine.UI.Label
        Me.FraAsientoRegularizacionG8y9 = New Solmicro.Expertis.Engine.UI.Frame
        Me.txtNAsientoRegularizacionG8y9 = New Solmicro.Expertis.Engine.UI.TextBox
        Me.lblNAsientoRegularizacionG8y9 = New Solmicro.Expertis.Engine.UI.Label
        Me.chkRegularizacionG8y9 = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.cbxFechaRegularizacionG8y9 = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.lblFechaRegularizacionG8y9 = New Solmicro.Expertis.Engine.UI.Label
        Me.pnlBottom.suspendlayout()
        Me.FraMain.SuspendLayout()
        Me.pnlEjericicios.suspendlayout()
        Me.FraAsientoApertura.SuspendLayout()
        Me.FraAsientoCierre.SuspendLayout()
        Me.FraAsientoRegularizacion.SuspendLayout()
        Me.FraAsientoRegularizacionG8y9.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlBottom
        '
        Me.pnlBottom.Controls.Add(Me.cmbCancelar)
        Me.pnlBottom.Controls.Add(Me.CmbAceptar)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 456)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(513, 57)
        Me.pnlBottom.TabIndex = 5
        '
        'cmbCancelar
        '
        Me.cmbCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmbCancelar.Location = New System.Drawing.Point(288, 13)
        Me.cmbCancelar.Name = "cmbCancelar"
        Me.cmbCancelar.Size = New System.Drawing.Size(117, 32)
        Me.cmbCancelar.TabIndex = 21
        Me.cmbCancelar.Text = "Cancelar"
        '
        'CmbAceptar
        '
        Me.CmbAceptar.Location = New System.Drawing.Point(108, 13)
        Me.CmbAceptar.Name = "CmbAceptar"
        Me.CmbAceptar.Size = New System.Drawing.Size(117, 32)
        Me.CmbAceptar.TabIndex = 20
        Me.CmbAceptar.Text = "Aceptar"
        '
        'FraMain
        '
        Me.FraMain.Controls.Add(Me.pnlEjericicios)
        Me.FraMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.FraMain.Location = New System.Drawing.Point(0, 0)
        Me.FraMain.Name = "FraMain"
        Me.FraMain.Size = New System.Drawing.Size(513, 85)
        Me.FraMain.TabIndex = 0
        Me.FraMain.TabStop = False
        '
        'pnlEjericicios
        '
        Me.pnlEjericicios.Controls.Add(Me.ulblIDEjSiguiente)
        Me.pnlEjericicios.Controls.Add(Me.ulblIDEjActual)
        Me.pnlEjericicios.Controls.Add(Me.ulblDescEjSiguiente)
        Me.pnlEjericicios.Controls.Add(Me.ulblDescEjActual)
        Me.pnlEjericicios.Controls.Add(Me.lblEjSiguiente)
        Me.pnlEjericicios.Controls.Add(Me.lblEjActual)
        Me.pnlEjericicios.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEjericicios.Location = New System.Drawing.Point(3, 17)
        Me.pnlEjericicios.Name = "pnlEjericicios"
        Me.pnlEjericicios.Size = New System.Drawing.Size(507, 62)
        Me.pnlEjericicios.TabIndex = 0
        '
        'ulblIDEjSiguiente
        '
        Me.ulblIDEjSiguiente.Location = New System.Drawing.Point(138, 30)
        Me.ulblIDEjSiguiente.Name = "ulblIDEjSiguiente"
        Me.ulblIDEjSiguiente.Size = New System.Drawing.Size(73, 23)
        Me.ulblIDEjSiguiente.TabIndex = 5
        '
        'ulblIDEjActual
        '
        Me.ulblIDEjActual.Location = New System.Drawing.Point(138, 1)
        Me.ulblIDEjActual.Name = "ulblIDEjActual"
        Me.ulblIDEjActual.Size = New System.Drawing.Size(73, 23)
        Me.ulblIDEjActual.TabIndex = 4
        '
        'ulblDescEjSiguiente
        '
        Me.ulblDescEjSiguiente.Location = New System.Drawing.Point(216, 30)
        Me.ulblDescEjSiguiente.Name = "ulblDescEjSiguiente"
        Me.ulblDescEjSiguiente.Size = New System.Drawing.Size(253, 23)
        Me.ulblDescEjSiguiente.TabIndex = 3
        '
        'ulblDescEjActual
        '
        Me.ulblDescEjActual.Location = New System.Drawing.Point(217, 1)
        Me.ulblDescEjActual.Name = "ulblDescEjActual"
        Me.ulblDescEjActual.Size = New System.Drawing.Size(253, 23)
        Me.ulblDescEjActual.TabIndex = 2
        '
        'lblEjSiguiente
        '
        Me.lblEjSiguiente.Location = New System.Drawing.Point(16, 35)
        Me.lblEjSiguiente.Name = "lblEjSiguiente"
        Me.lblEjSiguiente.Size = New System.Drawing.Size(112, 13)
        Me.lblEjSiguiente.TabIndex = 1
        Me.lblEjSiguiente.Text = "Ejercicio Siguiente"
        '
        'lblEjActual
        '
        Me.lblEjActual.Location = New System.Drawing.Point(16, 6)
        Me.lblEjActual.Name = "lblEjActual"
        Me.lblEjActual.Size = New System.Drawing.Size(94, 13)
        Me.lblEjActual.TabIndex = 0
        Me.lblEjActual.Text = "Ejercicio Actual"
        '
        'FraAsientoApertura
        '
        Me.FraAsientoApertura.Controls.Add(Me.txtNAsientoApertura)
        Me.FraAsientoApertura.Controls.Add(Me.lblNAsientoApertura)
        Me.FraAsientoApertura.Controls.Add(Me.chkApertura)
        Me.FraAsientoApertura.Controls.Add(Me.cbxFechaApertura)
        Me.FraAsientoApertura.Controls.Add(Me.lblFechaApertura)
        Me.FraAsientoApertura.Dock = System.Windows.Forms.DockStyle.Top
        Me.FraAsientoApertura.Location = New System.Drawing.Point(0, 367)
        Me.FraAsientoApertura.Name = "FraAsientoApertura"
        Me.FraAsientoApertura.Size = New System.Drawing.Size(513, 84)
        Me.FraAsientoApertura.TabIndex = 4
        Me.FraAsientoApertura.TabStop = False
        Me.FraAsientoApertura.Text = "Asiento Apertura"
        '
        'txtNAsientoApertura
        '
        Me.txtNAsientoApertura.DisabledBackColor = System.Drawing.Color.White
        Me.txtNAsientoApertura.Location = New System.Drawing.Point(371, 49)
        Me.txtNAsientoApertura.Name = "txtNAsientoApertura"
        Me.txtNAsientoApertura.Size = New System.Drawing.Size(87, 21)
        Me.txtNAsientoApertura.TabIndex = 2
        Me.txtNAsientoApertura.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        '
        'lblNAsientoApertura
        '
        Me.lblNAsientoApertura.Location = New System.Drawing.Point(302, 53)
        Me.lblNAsientoApertura.Name = "lblNAsientoApertura"
        Me.lblNAsientoApertura.Size = New System.Drawing.Size(67, 13)
        Me.lblNAsientoApertura.TabIndex = 17
        Me.lblNAsientoApertura.Text = "Nº Asiento"
        '
        'chkApertura
        '
        Me.chkApertura.Location = New System.Drawing.Point(25, 20)
        Me.chkApertura.Name = "chkApertura"
        Me.chkApertura.Size = New System.Drawing.Size(428, 23)
        Me.chkApertura.TabIndex = 0
        Me.chkApertura.Text = "Crear el asiento de Apertura para el Ejercicio"
        '
        'cbxFechaApertura
        '
        Me.cbxFechaApertura.DisabledBackColor = System.Drawing.Color.White
        Me.cbxFechaApertura.Location = New System.Drawing.Point(167, 49)
        Me.cbxFechaApertura.Name = "cbxFechaApertura"
        Me.cbxFechaApertura.Size = New System.Drawing.Size(100, 21)
        Me.cbxFechaApertura.TabIndex = 1
        '
        'lblFechaApertura
        '
        Me.lblFechaApertura.Location = New System.Drawing.Point(64, 53)
        Me.lblFechaApertura.Name = "lblFechaApertura"
        Me.lblFechaApertura.Size = New System.Drawing.Size(40, 13)
        Me.lblFechaApertura.TabIndex = 10
        Me.lblFechaApertura.Text = "Fecha"
        '
        'FraAsientoCierre
        '
        Me.FraAsientoCierre.Controls.Add(Me.txtNAsientoCierre)
        Me.FraAsientoCierre.Controls.Add(Me.lblNAsientoCierre)
        Me.FraAsientoCierre.Controls.Add(Me.chkCierre)
        Me.FraAsientoCierre.Controls.Add(Me.cbxFechaCierre)
        Me.FraAsientoCierre.Controls.Add(Me.lblFechaCierre)
        Me.FraAsientoCierre.Dock = System.Windows.Forms.DockStyle.Top
        Me.FraAsientoCierre.Location = New System.Drawing.Point(0, 280)
        Me.FraAsientoCierre.Name = "FraAsientoCierre"
        Me.FraAsientoCierre.Size = New System.Drawing.Size(513, 87)
        Me.FraAsientoCierre.TabIndex = 3
        Me.FraAsientoCierre.TabStop = False
        Me.FraAsientoCierre.Text = "Asiento Cierre"
        '
        'txtNAsientoCierre
        '
        Me.txtNAsientoCierre.DisabledBackColor = System.Drawing.Color.White
        Me.txtNAsientoCierre.Location = New System.Drawing.Point(371, 48)
        Me.txtNAsientoCierre.Name = "txtNAsientoCierre"
        Me.txtNAsientoCierre.Size = New System.Drawing.Size(87, 21)
        Me.txtNAsientoCierre.TabIndex = 2
        Me.txtNAsientoCierre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        '
        'lblNAsientoCierre
        '
        Me.lblNAsientoCierre.Location = New System.Drawing.Point(302, 52)
        Me.lblNAsientoCierre.Name = "lblNAsientoCierre"
        Me.lblNAsientoCierre.Size = New System.Drawing.Size(67, 13)
        Me.lblNAsientoCierre.TabIndex = 15
        Me.lblNAsientoCierre.Text = "Nº Asiento"
        '
        'chkCierre
        '
        Me.chkCierre.Location = New System.Drawing.Point(25, 17)
        Me.chkCierre.Name = "chkCierre"
        Me.chkCierre.Size = New System.Drawing.Size(428, 23)
        Me.chkCierre.TabIndex = 0
        Me.chkCierre.Text = "Crear el asiento de Cierre para el Ejercicio"
        '
        'cbxFechaCierre
        '
        Me.cbxFechaCierre.DisabledBackColor = System.Drawing.Color.White
        Me.cbxFechaCierre.Location = New System.Drawing.Point(167, 48)
        Me.cbxFechaCierre.Name = "cbxFechaCierre"
        Me.cbxFechaCierre.Size = New System.Drawing.Size(100, 21)
        Me.cbxFechaCierre.TabIndex = 1
        '
        'lblFechaCierre
        '
        Me.lblFechaCierre.Location = New System.Drawing.Point(64, 52)
        Me.lblFechaCierre.Name = "lblFechaCierre"
        Me.lblFechaCierre.Size = New System.Drawing.Size(40, 13)
        Me.lblFechaCierre.TabIndex = 9
        Me.lblFechaCierre.Text = "Fecha"
        '
        'FraAsientoRegularizacion
        '
        Me.FraAsientoRegularizacion.Controls.Add(Me.txtNAsientoRegularizacion)
        Me.FraAsientoRegularizacion.Controls.Add(Me.lblNAsientoRegularizacion)
        Me.FraAsientoRegularizacion.Controls.Add(Me.chkRegularizacion)
        Me.FraAsientoRegularizacion.Controls.Add(Me.AdvIDCuentaPerdidas)
        Me.FraAsientoRegularizacion.Controls.Add(Me.cbxFechaRegularizacion)
        Me.FraAsientoRegularizacion.Controls.Add(Me.lblCuentaPerdidas)
        Me.FraAsientoRegularizacion.Controls.Add(Me.lblFechaRegularizacion)
        Me.FraAsientoRegularizacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.FraAsientoRegularizacion.Location = New System.Drawing.Point(0, 85)
        Me.FraAsientoRegularizacion.Name = "FraAsientoRegularizacion"
        Me.FraAsientoRegularizacion.Size = New System.Drawing.Size(513, 110)
        Me.FraAsientoRegularizacion.TabIndex = 1
        Me.FraAsientoRegularizacion.TabStop = False
        Me.FraAsientoRegularizacion.Text = "Asiento Regularización"
        '
        'txtNAsientoRegularizacion
        '
        Me.txtNAsientoRegularizacion.DisabledBackColor = System.Drawing.Color.White
        Me.txtNAsientoRegularizacion.Location = New System.Drawing.Point(371, 49)
        Me.txtNAsientoRegularizacion.Name = "txtNAsientoRegularizacion"
        Me.txtNAsientoRegularizacion.Size = New System.Drawing.Size(87, 21)
        Me.txtNAsientoRegularizacion.TabIndex = 2
        Me.txtNAsientoRegularizacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        '
        'lblNAsientoRegularizacion
        '
        Me.lblNAsientoRegularizacion.Location = New System.Drawing.Point(302, 53)
        Me.lblNAsientoRegularizacion.Name = "lblNAsientoRegularizacion"
        Me.lblNAsientoRegularizacion.Size = New System.Drawing.Size(67, 13)
        Me.lblNAsientoRegularizacion.TabIndex = 13
        Me.lblNAsientoRegularizacion.Text = "Nº Asiento"
        '
        'chkRegularizacion
        '
        Me.chkRegularizacion.Location = New System.Drawing.Point(25, 16)
        Me.chkRegularizacion.Name = "chkRegularizacion"
        Me.chkRegularizacion.Size = New System.Drawing.Size(428, 23)
        Me.chkRegularizacion.TabIndex = 0
        Me.chkRegularizacion.Text = "Crear el asiento de Regularización para el Ejercicio"
        '
        'AdvIDCuentaPerdidas
        '
        Me.AdvIDCuentaPerdidas.DisabledBackColor = System.Drawing.Color.White
        Me.AdvIDCuentaPerdidas.EntityName = "PlanContable"
        Me.AdvIDCuentaPerdidas.Location = New System.Drawing.Point(167, 81)
        Me.AdvIDCuentaPerdidas.Name = "AdvIDCuentaPerdidas"
        Me.AdvIDCuentaPerdidas.SecondaryDataFields = "IDCContable"
        Me.AdvIDCuentaPerdidas.Size = New System.Drawing.Size(100, 23)
        Me.AdvIDCuentaPerdidas.TabIndex = 3
        Me.AdvIDCuentaPerdidas.ViewName = "tbPlanContable"
        '
        'cbxFechaRegularizacion
        '
        Me.cbxFechaRegularizacion.DisabledBackColor = System.Drawing.Color.White
        Me.cbxFechaRegularizacion.Location = New System.Drawing.Point(167, 49)
        Me.cbxFechaRegularizacion.Name = "cbxFechaRegularizacion"
        Me.cbxFechaRegularizacion.Size = New System.Drawing.Size(100, 21)
        Me.cbxFechaRegularizacion.TabIndex = 1
        '
        'lblCuentaPerdidas
        '
        Me.lblCuentaPerdidas.Location = New System.Drawing.Point(64, 85)
        Me.lblCuentaPerdidas.Name = "lblCuentaPerdidas"
        Me.lblCuentaPerdidas.Size = New System.Drawing.Size(101, 13)
        Me.lblCuentaPerdidas.TabIndex = 11
        Me.lblCuentaPerdidas.Text = "Cuenta Pérdidas"
        '
        'lblFechaRegularizacion
        '
        Me.lblFechaRegularizacion.Location = New System.Drawing.Point(64, 53)
        Me.lblFechaRegularizacion.Name = "lblFechaRegularizacion"
        Me.lblFechaRegularizacion.Size = New System.Drawing.Size(40, 13)
        Me.lblFechaRegularizacion.TabIndex = 8
        Me.lblFechaRegularizacion.Text = "Fecha"
        '
        'FraAsientoRegularizacionG8y9
        '
        Me.FraAsientoRegularizacionG8y9.Controls.Add(Me.txtNAsientoRegularizacionG8y9)
        Me.FraAsientoRegularizacionG8y9.Controls.Add(Me.lblNAsientoRegularizacionG8y9)
        Me.FraAsientoRegularizacionG8y9.Controls.Add(Me.chkRegularizacionG8y9)
        Me.FraAsientoRegularizacionG8y9.Controls.Add(Me.cbxFechaRegularizacionG8y9)
        Me.FraAsientoRegularizacionG8y9.Controls.Add(Me.lblFechaRegularizacionG8y9)
        Me.FraAsientoRegularizacionG8y9.Dock = System.Windows.Forms.DockStyle.Top
        Me.FraAsientoRegularizacionG8y9.Location = New System.Drawing.Point(0, 195)
        Me.FraAsientoRegularizacionG8y9.Name = "FraAsientoRegularizacionG8y9"
        Me.FraAsientoRegularizacionG8y9.Size = New System.Drawing.Size(513, 85)
        Me.FraAsientoRegularizacionG8y9.TabIndex = 2
        Me.FraAsientoRegularizacionG8y9.TabStop = False
        Me.FraAsientoRegularizacionG8y9.Text = "Asiento Regularización  (Grupos 8 y 9)"
        '
        'txtNAsientoRegularizacionG8y9
        '
        Me.txtNAsientoRegularizacionG8y9.DisabledBackColor = System.Drawing.Color.White
        Me.txtNAsientoRegularizacionG8y9.Location = New System.Drawing.Point(371, 49)
        Me.txtNAsientoRegularizacionG8y9.Name = "txtNAsientoRegularizacionG8y9"
        Me.txtNAsientoRegularizacionG8y9.Size = New System.Drawing.Size(87, 21)
        Me.txtNAsientoRegularizacionG8y9.TabIndex = 16
        Me.txtNAsientoRegularizacionG8y9.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        '
        'lblNAsientoRegularizacionG8y9
        '
        Me.lblNAsientoRegularizacionG8y9.Location = New System.Drawing.Point(302, 53)
        Me.lblNAsientoRegularizacionG8y9.Name = "lblNAsientoRegularizacionG8y9"
        Me.lblNAsientoRegularizacionG8y9.Size = New System.Drawing.Size(67, 13)
        Me.lblNAsientoRegularizacionG8y9.TabIndex = 17
        Me.lblNAsientoRegularizacionG8y9.Text = "Nº Asiento"
        '
        'chkRegularizacionG8y9
        '
        Me.chkRegularizacionG8y9.Location = New System.Drawing.Point(25, 16)
        Me.chkRegularizacionG8y9.Name = "chkRegularizacionG8y9"
        Me.chkRegularizacionG8y9.Size = New System.Drawing.Size(476, 23)
        Me.chkRegularizacionG8y9.TabIndex = 0
        Me.chkRegularizacionG8y9.Text = "Crear el asiento de Regularización (Grupos 8 y 9) para el Ejercicio"
        '
        'cbxFechaRegularizacionG8y9
        '
        Me.cbxFechaRegularizacionG8y9.DisabledBackColor = System.Drawing.Color.White
        Me.cbxFechaRegularizacionG8y9.Location = New System.Drawing.Point(167, 49)
        Me.cbxFechaRegularizacionG8y9.Name = "cbxFechaRegularizacionG8y9"
        Me.cbxFechaRegularizacionG8y9.Size = New System.Drawing.Size(100, 21)
        Me.cbxFechaRegularizacionG8y9.TabIndex = 1
        '
        'lblFechaRegularizacionG8y9
        '
        Me.lblFechaRegularizacionG8y9.Location = New System.Drawing.Point(64, 53)
        Me.lblFechaRegularizacionG8y9.Name = "lblFechaRegularizacionG8y9"
        Me.lblFechaRegularizacionG8y9.Size = New System.Drawing.Size(40, 13)
        Me.lblFechaRegularizacionG8y9.TabIndex = 8
        Me.lblFechaRegularizacionG8y9.Text = "Fecha"
        '
        'frmCierreContableEjercicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 513)
        Me.Controls.Add(Me.FraAsientoApertura)
        Me.Controls.Add(Me.FraAsientoCierre)
        Me.Controls.Add(Me.FraAsientoRegularizacionG8y9)
        Me.Controls.Add(Me.FraAsientoRegularizacion)
        Me.Controls.Add(Me.FraMain)
        Me.Controls.Add(Me.pnlBottom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmCierreContableEjercicio"
        Me.Text = "Cierre Ejercicio"
        Me.pnlBottom.ResumeLayout(False)
        Me.FraMain.ResumeLayout(False)
        Me.pnlEjericicios.ResumeLayout(False)
        Me.pnlEjericicios.PerformLayout()
        Me.FraAsientoApertura.ResumeLayout(False)
        Me.FraAsientoApertura.PerformLayout()
        Me.FraAsientoCierre.ResumeLayout(False)
        Me.FraAsientoCierre.PerformLayout()
        Me.FraAsientoRegularizacion.ResumeLayout(False)
        Me.FraAsientoRegularizacion.PerformLayout()
        Me.FraAsientoRegularizacionG8y9.ResumeLayout(False)
        Me.FraAsientoRegularizacionG8y9.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBottom As Solmicro.Expertis.Engine.UI.Panel
    Public WithEvents cmbCancelar As Solmicro.Expertis.Engine.UI.Button
    Public WithEvents CmbAceptar As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents FraMain As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents pnlEjericicios As Solmicro.Expertis.Engine.UI.Panel
    Friend WithEvents ulblDescEjActual As Solmicro.Expertis.Engine.UI.UnderLineLabel
    Friend WithEvents lblEjSiguiente As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents lblEjActual As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents ulblDescEjSiguiente As Solmicro.Expertis.Engine.UI.UnderLineLabel
    Friend WithEvents chkApertura As Solmicro.Expertis.Engine.UI.CheckBox
    Friend WithEvents chkCierre As Solmicro.Expertis.Engine.UI.CheckBox
    Friend WithEvents chkRegularizacion As Solmicro.Expertis.Engine.UI.CheckBox
    Friend WithEvents ulblIDEjSiguiente As Solmicro.Expertis.Engine.UI.UnderLineLabel
    Friend WithEvents ulblIDEjActual As Solmicro.Expertis.Engine.UI.UnderLineLabel
    Friend WithEvents cbxFechaRegularizacion As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents cbxFechaApertura As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents cbxFechaCierre As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents lblFechaApertura As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents lblFechaCierre As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents lblFechaRegularizacion As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents AdvIDCuentaPerdidas As Solmicro.Expertis.Engine.UI.AdvSearch
    Friend WithEvents lblCuentaPerdidas As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents FraAsientoApertura As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents FraAsientoCierre As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents FraAsientoRegularizacion As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents lblNAsientoRegularizacion As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtNAsientoRegularizacion As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents txtNAsientoCierre As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents lblNAsientoCierre As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents txtNAsientoApertura As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents lblNAsientoApertura As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents FraAsientoRegularizacionG8y9 As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents txtNAsientoRegularizacionG8y9 As Solmicro.Expertis.Engine.UI.TextBox
    Friend WithEvents lblNAsientoRegularizacionG8y9 As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents chkRegularizacionG8y9 As Solmicro.Expertis.Engine.UI.CheckBox
    Friend WithEvents cbxFechaRegularizacionG8y9 As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents lblFechaRegularizacionG8y9 As Solmicro.Expertis.Engine.UI.Label
End Class
