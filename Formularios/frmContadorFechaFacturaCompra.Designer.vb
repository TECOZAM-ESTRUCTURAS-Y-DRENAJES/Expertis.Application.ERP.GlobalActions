<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContadorFechaFacturaCompra
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
        Me.LblContador = New Solmicro.Expertis.Engine.UI.Label
        Me.BtnAceptar = New Solmicro.Expertis.Engine.UI.Button
        Me.BtnCancelar = New Solmicro.Expertis.Engine.UI.Button
        Me.AdvContador = New Solmicro.Expertis.Engine.UI.AdvSearch
        Me.FrmDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'FrmDatos
        '
        Me.FrmDatos.Controls.Add(Me.AdvContador)
        Me.FrmDatos.Controls.Add(Me.BtnCancelar)
        Me.FrmDatos.Controls.Add(Me.BtnAceptar)
        Me.FrmDatos.Controls.Add(Me.ClbFecha)
        Me.FrmDatos.Controls.Add(Me.LbLFecha)
        Me.FrmDatos.Controls.Add(Me.LblContador)
        Me.FrmDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FrmDatos.Location = New System.Drawing.Point(0, 0)
        Me.FrmDatos.Name = "FrmDatos"
        Me.FrmDatos.Size = New System.Drawing.Size(260, 144)
        Me.FrmDatos.TabIndex = 1
        Me.FrmDatos.TabStop = False
        Me.FrmDatos.Text = "Contador / Fecha"
        '
        'ClbFecha
        '
        Me.ClbFecha.DisabledBackColor = System.Drawing.Color.White
        Me.ClbFecha.Location = New System.Drawing.Point(96, 50)
        Me.ClbFecha.Name = "ClbFecha"
        Me.ClbFecha.Size = New System.Drawing.Size(147, 21)
        Me.ClbFecha.TabIndex = 2
        '
        'LbLFecha
        '
        Me.LbLFecha.Location = New System.Drawing.Point(6, 54)
        Me.LbLFecha.Name = "LbLFecha"
        Me.LbLFecha.Size = New System.Drawing.Size(70, 13)
        Me.LbLFecha.TabIndex = 3
        Me.LbLFecha.Text = "Fecha Fact."
        '
        'LblContador
        '
        Me.LblContador.Location = New System.Drawing.Point(6, 24)
        Me.LblContador.Name = "LblContador"
        Me.LblContador.Size = New System.Drawing.Size(60, 13)
        Me.LblContador.TabIndex = 0
        Me.LblContador.Text = "Contador"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Location = New System.Drawing.Point(14, 91)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(111, 25)
        Me.BtnAceptar.TabIndex = 3
        Me.BtnAceptar.Text = "&Aceptar"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Location = New System.Drawing.Point(132, 91)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(111, 25)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "&Cancelar"
        '
        'AdvContador
        '
        Me.AdvContador.DisabledBackColor = System.Drawing.Color.White
        Me.AdvContador.EntityName = "EntidadContador"
        Me.AdvContador.Location = New System.Drawing.Point(96, 24)
        Me.AdvContador.Name = "AdvContador"
        Me.AdvContador.SecondaryDataFields = "IDContador"
        Me.AdvContador.Size = New System.Drawing.Size(147, 23)
        Me.AdvContador.TabIndex = 5
        '
        'frmContadorFechaFacturaCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(260, 144)
        Me.Controls.Add(Me.FrmDatos)
        Me.Name = "frmContadorFechaFacturaCompra"
        Me.Text = "Copia Factura Compra"
        Me.FrmDatos.ResumeLayout(False)
        Me.FrmDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents FrmDatos As Solmicro.Expertis.Engine.UI.Frame
    Public WithEvents ClbFecha As Solmicro.Expertis.Engine.UI.CalendarBox
    Public WithEvents LbLFecha As Solmicro.Expertis.Engine.UI.Label
    Public WithEvents LblContador As Solmicro.Expertis.Engine.UI.Label
    Public WithEvents BtnCancelar As Solmicro.Expertis.Engine.UI.Button
    Public WithEvents BtnAceptar As Solmicro.Expertis.Engine.UI.Button
    Public WithEvents AdvContador As Solmicro.Expertis.Engine.UI.AdvSearch
End Class
