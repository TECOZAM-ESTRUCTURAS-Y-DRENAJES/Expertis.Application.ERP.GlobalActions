<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContadorFechaFactura
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
        Me.FrmDatos = New Solmicro.Expertis.Engine.UI.Frame
        Me.ClbFecha = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.LbLFecha = New Solmicro.Expertis.Engine.UI.Label
        Me.AdvContador = New Solmicro.Expertis.Engine.UI.AdvSearch
        Me.LblContador = New Solmicro.Expertis.Engine.UI.Label
        Me.PnlButtons = New Solmicro.Expertis.Engine.UI.Panel
        Me.BtnCancelar = New Solmicro.Expertis.Engine.UI.Button
        Me.BtnAceptar = New Solmicro.Expertis.Engine.UI.Button
        Me.FrmDatos.SuspendLayout()
        Me.PnlButtons.suspendlayout()
        Me.SuspendLayout()
        '
        'FrmDatos
        '
        Me.FrmDatos.Controls.Add(Me.ClbFecha)
        Me.FrmDatos.Controls.Add(Me.LbLFecha)
        Me.FrmDatos.Controls.Add(Me.AdvContador)
        Me.FrmDatos.Controls.Add(Me.LblContador)
        Me.FrmDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FrmDatos.Location = New System.Drawing.Point(0, 0)
        Me.FrmDatos.Name = "FrmDatos"
        Me.FrmDatos.Size = New System.Drawing.Size(216, 78)
        Me.FrmDatos.TabIndex = 0
        Me.FrmDatos.TabStop = False
        Me.FrmDatos.Text = "Contador / Fecha"
        '
        'ClbFecha
        '
        Me.ClbFecha.DisabledBackColor = System.Drawing.Color.White
        Me.ClbFecha.Location = New System.Drawing.Point(82, 50)
        Me.ClbFecha.Name = "ClbFecha"
        Me.ClbFecha.Size = New System.Drawing.Size(126, 21)
        Me.ClbFecha.TabIndex = 2
        '
        'LbLFecha
        '
        Me.LbLFecha.Location = New System.Drawing.Point(5, 54)
        Me.LbLFecha.Name = "LbLFecha"
        Me.LbLFecha.Size = New System.Drawing.Size(71, 13)
        Me.LbLFecha.TabIndex = 3
        Me.LbLFecha.Text = "Fecha Fact."
        '
        'AdvContador
        '
        Me.AdvContador.DisabledBackColor = System.Drawing.Color.White
        Me.AdvContador.EntityName = "EntidadContador"
        Me.AdvContador.Location = New System.Drawing.Point(82, 20)
        Me.AdvContador.Name = "AdvContador"
        Me.AdvContador.SecondaryDataFields = "IDContador"
        Me.AdvContador.Size = New System.Drawing.Size(126, 23)
        Me.AdvContador.TabIndex = 1
        '
        'LblContador
        '
        Me.LblContador.Location = New System.Drawing.Point(5, 24)
        Me.LblContador.Name = "LblContador"
        Me.LblContador.Size = New System.Drawing.Size(60, 13)
        Me.LblContador.TabIndex = 0
        Me.LblContador.Text = "Contador"
        '
        'PnlButtons
        '
        Me.PnlButtons.Controls.Add(Me.BtnCancelar)
        Me.PnlButtons.Controls.Add(Me.BtnAceptar)
        Me.PnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlButtons.Location = New System.Drawing.Point(0, 78)
        Me.PnlButtons.Name = "PnlButtons"
        Me.PnlButtons.Size = New System.Drawing.Size(216, 38)
        Me.PnlButtons.TabIndex = 3
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Location = New System.Drawing.Point(113, 6)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(95, 25)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Cancelar"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Location = New System.Drawing.Point(12, 6)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(95, 25)
        Me.BtnAceptar.TabIndex = 4
        Me.BtnAceptar.Text = "&Aceptar"
        '
        'frmContadorFechaFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(216, 116)
        Me.Controls.Add(Me.FrmDatos)
        Me.Controls.Add(Me.PnlButtons)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmContadorFechaFactura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Introduzca Contador y Fecha"
        Me.FrmDatos.ResumeLayout(False)
        Me.FrmDatos.PerformLayout()
        Me.PnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents FrmDatos As Solmicro.Expertis.Engine.UI.Frame
    Public WithEvents ClbFecha As Solmicro.Expertis.Engine.UI.CalendarBox
    Public WithEvents LbLFecha As Solmicro.Expertis.Engine.UI.Label
    Public WithEvents AdvContador As Solmicro.Expertis.Engine.UI.AdvSearch
    Public WithEvents LblContador As Solmicro.Expertis.Engine.UI.Label
    Public WithEvents PnlButtons As Solmicro.Expertis.Engine.UI.Panel
    Public WithEvents BtnCancelar As Solmicro.Expertis.Engine.UI.Button
    Public WithEvents BtnAceptar As Solmicro.Expertis.Engine.UI.Button
End Class
