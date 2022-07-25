<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeshacerCierreContableEjercicio
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
        Me.chkApertura = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.chkRegularizacion = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.chkCierre = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.chkRegularizacionG8y9 = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.pnlBottom.suspendlayout()
        Me.FraMain.SuspendLayout()
        Me.pnlEjericicios.suspendlayout()
        Me.SuspendLayout()
        '
        'pnlBottom
        '
        Me.pnlBottom.Controls.Add(Me.cmbCancelar)
        Me.pnlBottom.Controls.Add(Me.CmbAceptar)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 211)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(561, 63)
        Me.pnlBottom.TabIndex = 1
        '
        'cmbCancelar
        '
        Me.cmbCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmbCancelar.Location = New System.Drawing.Point(312, 19)
        Me.cmbCancelar.Name = "cmbCancelar"
        Me.cmbCancelar.Size = New System.Drawing.Size(117, 32)
        Me.cmbCancelar.TabIndex = 23
        Me.cmbCancelar.Text = "Cancelar"
        '
        'CmbAceptar
        '
        Me.CmbAceptar.Location = New System.Drawing.Point(131, 19)
        Me.CmbAceptar.Name = "CmbAceptar"
        Me.CmbAceptar.Size = New System.Drawing.Size(117, 32)
        Me.CmbAceptar.TabIndex = 22
        Me.CmbAceptar.Text = "Aceptar"
        '
        'FraMain
        '
        Me.FraMain.Controls.Add(Me.chkRegularizacionG8y9)
        Me.FraMain.Controls.Add(Me.pnlEjericicios)
        Me.FraMain.Controls.Add(Me.chkApertura)
        Me.FraMain.Controls.Add(Me.chkRegularizacion)
        Me.FraMain.Controls.Add(Me.chkCierre)
        Me.FraMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FraMain.Location = New System.Drawing.Point(0, 0)
        Me.FraMain.Name = "FraMain"
        Me.FraMain.Size = New System.Drawing.Size(561, 211)
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
        Me.pnlEjericicios.Size = New System.Drawing.Size(555, 62)
        Me.pnlEjericicios.TabIndex = 7
        '
        'ulblIDEjSiguiente
        '
        Me.ulblIDEjSiguiente.Location = New System.Drawing.Point(125, 32)
        Me.ulblIDEjSiguiente.Name = "ulblIDEjSiguiente"
        Me.ulblIDEjSiguiente.Size = New System.Drawing.Size(73, 23)
        Me.ulblIDEjSiguiente.TabIndex = 5
        '
        'ulblIDEjActual
        '
        Me.ulblIDEjActual.Location = New System.Drawing.Point(125, 3)
        Me.ulblIDEjActual.Name = "ulblIDEjActual"
        Me.ulblIDEjActual.Size = New System.Drawing.Size(73, 23)
        Me.ulblIDEjActual.TabIndex = 4
        '
        'ulblDescEjSiguiente
        '
        Me.ulblDescEjSiguiente.Location = New System.Drawing.Point(204, 32)
        Me.ulblDescEjSiguiente.Name = "ulblDescEjSiguiente"
        Me.ulblDescEjSiguiente.Size = New System.Drawing.Size(245, 23)
        Me.ulblDescEjSiguiente.TabIndex = 3
        '
        'ulblDescEjActual
        '
        Me.ulblDescEjActual.Location = New System.Drawing.Point(204, 3)
        Me.ulblDescEjActual.Name = "ulblDescEjActual"
        Me.ulblDescEjActual.Size = New System.Drawing.Size(245, 23)
        Me.ulblDescEjActual.TabIndex = 2
        '
        'lblEjSiguiente
        '
        Me.lblEjSiguiente.Location = New System.Drawing.Point(7, 37)
        Me.lblEjSiguiente.Name = "lblEjSiguiente"
        Me.lblEjSiguiente.Size = New System.Drawing.Size(112, 13)
        Me.lblEjSiguiente.TabIndex = 1
        Me.lblEjSiguiente.Text = "Ejercicio Siguiente"
        '
        'lblEjActual
        '
        Me.lblEjActual.Location = New System.Drawing.Point(7, 8)
        Me.lblEjActual.Name = "lblEjActual"
        Me.lblEjActual.Size = New System.Drawing.Size(94, 13)
        Me.lblEjActual.TabIndex = 0
        Me.lblEjActual.Text = "Ejercicio Actual"
        '
        'chkApertura
        '
        Me.chkApertura.Location = New System.Drawing.Point(15, 90)
        Me.chkApertura.Name = "chkApertura"
        Me.chkApertura.Size = New System.Drawing.Size(534, 23)
        Me.chkApertura.TabIndex = 0
        Me.chkApertura.Text = "Deshacer asiento de Apertura para el Ejercicio"
        '
        'chkRegularizacion
        '
        Me.chkRegularizacion.Location = New System.Drawing.Point(15, 177)
        Me.chkRegularizacion.Name = "chkRegularizacion"
        Me.chkRegularizacion.Size = New System.Drawing.Size(534, 23)
        Me.chkRegularizacion.TabIndex = 3
        Me.chkRegularizacion.Text = "Deshacer asiento de Regularización para el Ejercicio"
        '
        'chkCierre
        '
        Me.chkCierre.Location = New System.Drawing.Point(15, 119)
        Me.chkCierre.Name = "chkCierre"
        Me.chkCierre.Size = New System.Drawing.Size(534, 23)
        Me.chkCierre.TabIndex = 1
        Me.chkCierre.Text = "Deshacer asiento de Cierre para el Ejercicio"
        '
        'chkRegularizacionG8y9
        '
        Me.chkRegularizacionG8y9.Location = New System.Drawing.Point(15, 148)
        Me.chkRegularizacionG8y9.Name = "chkRegularizacionG8y9"
        Me.chkRegularizacionG8y9.Size = New System.Drawing.Size(534, 23)
        Me.chkRegularizacionG8y9.TabIndex = 2
        Me.chkRegularizacionG8y9.Text = "Deshacer asiento de Regularización (Grupos 8 y 9) para el Ejercicio"
        '
        'frmDeshacerCierreContableEjercicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(561, 274)
        Me.Controls.Add(Me.FraMain)
        Me.Controls.Add(Me.pnlBottom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmDeshacerCierreContableEjercicio"
        Me.Text = "Deshacer Cierre Ejercicio"
        Me.pnlBottom.ResumeLayout(False)
        Me.FraMain.ResumeLayout(False)
        Me.pnlEjericicios.ResumeLayout(False)
        Me.pnlEjericicios.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBottom As Solmicro.Expertis.Engine.UI.Panel
    Friend WithEvents FraMain As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents chkApertura As Solmicro.Expertis.Engine.UI.CheckBox
    Friend WithEvents chkCierre As Solmicro.Expertis.Engine.UI.CheckBox
    Friend WithEvents chkRegularizacion As Solmicro.Expertis.Engine.UI.CheckBox
    Public WithEvents cmbCancelar As Solmicro.Expertis.Engine.UI.Button
    Public WithEvents CmbAceptar As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents pnlEjericicios As Solmicro.Expertis.Engine.UI.Panel
    Friend WithEvents ulblIDEjSiguiente As Solmicro.Expertis.Engine.UI.UnderLineLabel
    Friend WithEvents ulblIDEjActual As Solmicro.Expertis.Engine.UI.UnderLineLabel
    Friend WithEvents ulblDescEjSiguiente As Solmicro.Expertis.Engine.UI.UnderLineLabel
    Friend WithEvents ulblDescEjActual As Solmicro.Expertis.Engine.UI.UnderLineLabel
    Friend WithEvents lblEjSiguiente As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents lblEjActual As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents chkRegularizacionG8y9 As Solmicro.Expertis.Engine.UI.CheckBox
End Class
