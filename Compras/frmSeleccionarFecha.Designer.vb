<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeleccionarFecha
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
        Me.cmdCancelar = New Solmicro.Expertis.Engine.UI.Button
        Me.cmdAceptar = New Solmicro.Expertis.Engine.UI.Button
        Me.FraMain = New Solmicro.Expertis.Engine.UI.Frame
        Me.cbxFecha = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.lblFecha = New Solmicro.Expertis.Engine.UI.Label
        Me.FraFiltroFechas = New Solmicro.Expertis.Engine.UI.Frame
        Me.cbxFechaDesde = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.lblFechaDesde = New Solmicro.Expertis.Engine.UI.Label
        Me.cbxFechaHasta = New Solmicro.Expertis.Engine.UI.CalendarBox
        Me.lblFechaHasta = New Solmicro.Expertis.Engine.UI.Label
        Me.pnlBottom.suspendlayout()
        Me.FraMain.SuspendLayout()
        Me.FraFiltroFechas.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlBottom
        '
        Me.pnlBottom.Controls.Add(Me.cmdCancelar)
        Me.pnlBottom.Controls.Add(Me.cmdAceptar)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 146)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(345, 59)
        Me.pnlBottom.TabIndex = 0
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(199, 14)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(89, 34)
        Me.cmdCancelar.TabIndex = 1
        Me.cmdCancelar.Text = "Cancelar"
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(60, 14)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(89, 34)
        Me.cmdAceptar.TabIndex = 0
        Me.cmdAceptar.Text = "Aceptar"
        '
        'FraMain
        '
        Me.FraMain.Controls.Add(Me.FraFiltroFechas)
        Me.FraMain.Controls.Add(Me.cbxFecha)
        Me.FraMain.Controls.Add(Me.lblFecha)
        Me.FraMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FraMain.Location = New System.Drawing.Point(0, 0)
        Me.FraMain.Name = "FraMain"
        Me.FraMain.Size = New System.Drawing.Size(345, 146)
        Me.FraMain.TabIndex = 1
        Me.FraMain.TabStop = False
        '
        'cbxFecha
        '
        Me.cbxFecha.DisabledBackColor = System.Drawing.Color.White
        Me.cbxFecha.Location = New System.Drawing.Point(164, 108)
        Me.cbxFecha.Name = "cbxFecha"
        Me.cbxFecha.Size = New System.Drawing.Size(144, 21)
        Me.cbxFecha.TabIndex = 1
        '
        'lblFecha
        '
        Me.lblFecha.Location = New System.Drawing.Point(31, 112)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(130, 13)
        Me.lblFecha.TabIndex = 0
        Me.lblFecha.Text = "Fecha Contabilización"
        '
        'FraFiltroFechas
        '
        Me.FraFiltroFechas.Controls.Add(Me.cbxFechaHasta)
        Me.FraFiltroFechas.Controls.Add(Me.lblFechaHasta)
        Me.FraFiltroFechas.Controls.Add(Me.cbxFechaDesde)
        Me.FraFiltroFechas.Controls.Add(Me.lblFechaDesde)
        Me.FraFiltroFechas.Dock = System.Windows.Forms.DockStyle.Top
        Me.FraFiltroFechas.Location = New System.Drawing.Point(3, 17)
        Me.FraFiltroFechas.Name = "FraFiltroFechas"
        Me.FraFiltroFechas.Size = New System.Drawing.Size(339, 80)
        Me.FraFiltroFechas.TabIndex = 2
        Me.FraFiltroFechas.TabStop = False
        Me.FraFiltroFechas.Text = "Período Fechas Albaranes"
        '
        'cbxFechaDesde
        '
        Me.cbxFechaDesde.DisabledBackColor = System.Drawing.Color.White
        Me.cbxFechaDesde.Location = New System.Drawing.Point(161, 26)
        Me.cbxFechaDesde.Name = "cbxFechaDesde"
        Me.cbxFechaDesde.Size = New System.Drawing.Size(144, 21)
        Me.cbxFechaDesde.TabIndex = 3
        '
        'lblFechaDesde
        '
        Me.lblFechaDesde.Location = New System.Drawing.Point(31, 30)
        Me.lblFechaDesde.Name = "lblFechaDesde"
        Me.lblFechaDesde.Size = New System.Drawing.Size(80, 13)
        Me.lblFechaDesde.TabIndex = 2
        Me.lblFechaDesde.Text = "Fecha Desde"
        '
        'cbxFechaHasta
        '
        Me.cbxFechaHasta.DisabledBackColor = System.Drawing.Color.White
        Me.cbxFechaHasta.Location = New System.Drawing.Point(161, 49)
        Me.cbxFechaHasta.Name = "cbxFechaHasta"
        Me.cbxFechaHasta.Size = New System.Drawing.Size(144, 21)
        Me.cbxFechaHasta.TabIndex = 5
        '
        'lblFechaHasta
        '
        Me.lblFechaHasta.Location = New System.Drawing.Point(31, 53)
        Me.lblFechaHasta.Name = "lblFechaHasta"
        Me.lblFechaHasta.Size = New System.Drawing.Size(76, 13)
        Me.lblFechaHasta.TabIndex = 4
        Me.lblFechaHasta.Text = "Fecha Hasta"
        '
        'frmSeleccionarFecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 205)
        Me.Controls.Add(Me.FraMain)
        Me.Controls.Add(Me.pnlBottom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmSeleccionarFecha"
        Me.Text = "Seleccionar Fecha Contabilización"
        Me.pnlBottom.ResumeLayout(False)
        Me.FraMain.ResumeLayout(False)
        Me.FraMain.PerformLayout()
        Me.FraFiltroFechas.ResumeLayout(False)
        Me.FraFiltroFechas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBottom As Solmicro.Expertis.Engine.UI.Panel
    Friend WithEvents cmdCancelar As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents cmdAceptar As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents FraMain As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents cbxFecha As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents lblFecha As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents FraFiltroFechas As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents cbxFechaHasta As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents lblFechaHasta As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents cbxFechaDesde As Solmicro.Expertis.Engine.UI.CalendarBox
    Friend WithEvents lblFechaDesde As Solmicro.Expertis.Engine.UI.Label
End Class
