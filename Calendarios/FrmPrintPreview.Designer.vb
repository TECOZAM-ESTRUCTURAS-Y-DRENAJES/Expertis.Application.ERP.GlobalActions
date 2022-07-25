<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrintPreview
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
        Me.FrmOpciones = New Solmicro.Expertis.Engine.UI.Frame
        Me.Panel1 = New Solmicro.Expertis.Engine.UI.Panel
        Me.BtnAceptar = New Solmicro.Expertis.Engine.UI.Button
        Me.BtnCancelar = New Solmicro.Expertis.Engine.UI.Button
        Me.RdImpresora = New Solmicro.Expertis.Engine.UI.RadioButton
        Me.RdVistaPrevia = New Solmicro.Expertis.Engine.UI.RadioButton
        Me.FrmOpciones.SuspendLayout()
        Me.Panel1.suspendlayout()
        Me.SuspendLayout()
        '
        'FrmOpciones
        '
        Me.FrmOpciones.Controls.Add(Me.RdVistaPrevia)
        Me.FrmOpciones.Controls.Add(Me.RdImpresora)
        Me.FrmOpciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FrmOpciones.Location = New System.Drawing.Point(0, 0)
        Me.FrmOpciones.Name = "FrmOpciones"
        Me.FrmOpciones.Size = New System.Drawing.Size(220, 83)
        Me.FrmOpciones.TabIndex = 0
        Me.FrmOpciones.TabStop = False
        Me.FrmOpciones.Text = "Opciones"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnCancelar)
        Me.Panel1.Controls.Add(Me.BtnAceptar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 83)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(220, 50)
        Me.Panel1.TabIndex = 1
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Location = New System.Drawing.Point(17, 7)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(86, 36)
        Me.BtnAceptar.TabIndex = 0
        Me.BtnAceptar.Text = "&Aceptar"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Location = New System.Drawing.Point(118, 7)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(86, 36)
        Me.BtnCancelar.TabIndex = 1
        Me.BtnCancelar.Text = "&Cancelar"
        '
        'RdImpresora
        '
        Me.RdImpresora.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RdImpresora.Checked = True
        Me.RdImpresora.Location = New System.Drawing.Point(12, 20)
        Me.RdImpresora.Name = "RdImpresora"
        Me.RdImpresora.Size = New System.Drawing.Size(195, 23)
        Me.RdImpresora.TabIndex = 0
        Me.RdImpresora.TabStop = True
        Me.RdImpresora.Text = "Enviar a Impresora"
        '
        'RdVistaPrevia
        '
        Me.RdVistaPrevia.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RdVistaPrevia.Location = New System.Drawing.Point(12, 49)
        Me.RdVistaPrevia.Name = "RdVistaPrevia"
        Me.RdVistaPrevia.Size = New System.Drawing.Size(195, 23)
        Me.RdVistaPrevia.TabIndex = 1
        Me.RdVistaPrevia.Text = "Vista Previa"
        '
        'FrmPrintPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(220, 133)
        Me.Controls.Add(Me.FrmOpciones)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPrintPreview"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Opciones de Impresión"
        Me.FrmOpciones.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FrmOpciones As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents Panel1 As Solmicro.Expertis.Engine.UI.Panel
    Friend WithEvents BtnCancelar As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents BtnAceptar As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents RdVistaPrevia As Solmicro.Expertis.Engine.UI.RadioButton
    Friend WithEvents RdImpresora As Solmicro.Expertis.Engine.UI.RadioButton
End Class
