<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelecOpt
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
        Me.FrmOpt = New Solmicro.Expertis.Engine.UI.Frame
        Me.RbRuta = New Solmicro.Expertis.Engine.UI.RadioButton
        Me.RbEstructura = New Solmicro.Expertis.Engine.UI.RadioButton
        Me.RbFicha = New Solmicro.Expertis.Engine.UI.RadioButton
        Me.PnlButtons = New Solmicro.Expertis.Engine.UI.Panel
        Me.BtnCancelar = New Solmicro.Expertis.Engine.UI.Button
        Me.BtnAceptar = New Solmicro.Expertis.Engine.UI.Button
        Me.FrmOpt.SuspendLayout()
        Me.PnlButtons.suspendlayout()
        Me.SuspendLayout()
        '
        'FrmOpt
        '
        Me.FrmOpt.Controls.Add(Me.RbRuta)
        Me.FrmOpt.Controls.Add(Me.RbEstructura)
        Me.FrmOpt.Controls.Add(Me.RbFicha)
        Me.FrmOpt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FrmOpt.Location = New System.Drawing.Point(0, 0)
        Me.FrmOpt.Name = "FrmOpt"
        Me.FrmOpt.Size = New System.Drawing.Size(194, 105)
        Me.FrmOpt.TabIndex = 0
        Me.FrmOpt.TabStop = False
        Me.FrmOpt.Text = "Seleccione Opción..."
        '
        'RbRuta
        '
        Me.RbRuta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RbRuta.Location = New System.Drawing.Point(12, 78)
        Me.RbRuta.Name = "RbRuta"
        Me.RbRuta.Size = New System.Drawing.Size(125, 23)
        Me.RbRuta.TabIndex = 2
        Me.RbRuta.Text = "Ruta"
        '
        'RbEstructura
        '
        Me.RbEstructura.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RbEstructura.Location = New System.Drawing.Point(12, 49)
        Me.RbEstructura.Name = "RbEstructura"
        Me.RbEstructura.Size = New System.Drawing.Size(125, 23)
        Me.RbEstructura.TabIndex = 1
        Me.RbEstructura.Text = "Estructura"
        '
        'RbFicha
        '
        Me.RbFicha.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RbFicha.Checked = True
        Me.RbFicha.Location = New System.Drawing.Point(12, 20)
        Me.RbFicha.Name = "RbFicha"
        Me.RbFicha.Size = New System.Drawing.Size(125, 23)
        Me.RbFicha.TabIndex = 0
        Me.RbFicha.TabStop = True
        Me.RbFicha.Text = "Ficha Artículo"
        '
        'PnlButtons
        '
        Me.PnlButtons.Controls.Add(Me.BtnCancelar)
        Me.PnlButtons.Controls.Add(Me.BtnAceptar)
        Me.PnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlButtons.Location = New System.Drawing.Point(0, 105)
        Me.PnlButtons.Name = "PnlButtons"
        Me.PnlButtons.Size = New System.Drawing.Size(194, 41)
        Me.PnlButtons.TabIndex = 1
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Location = New System.Drawing.Point(100, 6)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(82, 29)
        Me.BtnCancelar.TabIndex = 1
        Me.BtnCancelar.Text = "&Cancelar"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Location = New System.Drawing.Point(12, 6)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(82, 29)
        Me.BtnAceptar.TabIndex = 0
        Me.BtnAceptar.Text = "&Aceptar"
        '
        'FrmSelecOpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(194, 146)
        Me.Controls.Add(Me.FrmOpt)
        Me.Controls.Add(Me.PnlButtons)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSelecOpt"
        Me.Text = "Opciones de Visualización"
        Me.FrmOpt.ResumeLayout(False)
        Me.PnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FrmOpt As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents PnlButtons As Solmicro.Expertis.Engine.UI.Panel
    Friend WithEvents BtnCancelar As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents BtnAceptar As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents RbEstructura As Solmicro.Expertis.Engine.UI.RadioButton
    Friend WithEvents RbFicha As Solmicro.Expertis.Engine.UI.RadioButton
    Friend WithEvents RbRuta As Solmicro.Expertis.Engine.UI.RadioButton
End Class
