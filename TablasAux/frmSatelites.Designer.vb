<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSatelites
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
        Me.components = New System.ComponentModel.Container
        Dim GrdSatelite_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.FrmCabecera = New Solmicro.Expertis.Engine.UI.Frame
        Me.ULblTablaAuxiliar = New Solmicro.Expertis.Engine.UI.UnderLineLabel
        Me.LblTablaAuxiliar = New Solmicro.Expertis.Engine.UI.Label
        Me.ULblEntidad = New Solmicro.Expertis.Engine.UI.UnderLineLabel
        Me.LblEntidad = New Solmicro.Expertis.Engine.UI.Label
        Me.FrmData = New Solmicro.Expertis.Engine.UI.Frame
        Me.GrdSatelite = New Solmicro.Expertis.Engine.UI.Grid
        Me.PnlButtons = New Solmicro.Expertis.Engine.UI.Panel
        Me.BtnAceptar = New Solmicro.Expertis.Engine.UI.Button
        Me.BtnCancelar = New Solmicro.Expertis.Engine.UI.Button
        Me.FrmCabecera.SuspendLayout()
        Me.FrmData.SuspendLayout()
        CType(Me.GrdSatelite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlButtons.suspendlayout()
        Me.SuspendLayout()
        '
        'FrmCabecera
        '
        Me.FrmCabecera.Controls.Add(Me.ULblTablaAuxiliar)
        Me.FrmCabecera.Controls.Add(Me.LblTablaAuxiliar)
        Me.FrmCabecera.Controls.Add(Me.ULblEntidad)
        Me.FrmCabecera.Controls.Add(Me.LblEntidad)
        Me.FrmCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.FrmCabecera.Location = New System.Drawing.Point(0, 0)
        Me.FrmCabecera.Name = "FrmCabecera"
        Me.FrmCabecera.Size = New System.Drawing.Size(901, 89)
        Me.FrmCabecera.TabIndex = 0
        Me.FrmCabecera.TabStop = False
        Me.FrmCabecera.Text = "Info"
        '
        'ULblTablaAuxiliar
        '
        Me.ULblTablaAuxiliar.Location = New System.Drawing.Point(118, 52)
        Me.ULblTablaAuxiliar.Name = "ULblTablaAuxiliar"
        Me.ULblTablaAuxiliar.Size = New System.Drawing.Size(771, 23)
        Me.ULblTablaAuxiliar.TabIndex = 3
        '
        'LblTablaAuxiliar
        '
        Me.LblTablaAuxiliar.AutoSize = False
        Me.LblTablaAuxiliar.Location = New System.Drawing.Point(12, 52)
        Me.LblTablaAuxiliar.Name = "LblTablaAuxiliar"
        Me.LblTablaAuxiliar.Size = New System.Drawing.Size(100, 23)
        Me.LblTablaAuxiliar.TabIndex = 2
        Me.LblTablaAuxiliar.Text = "Tabla Auxiliar"
        Me.LblTablaAuxiliar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ULblEntidad
        '
        Me.ULblEntidad.Location = New System.Drawing.Point(118, 20)
        Me.ULblEntidad.Name = "ULblEntidad"
        Me.ULblEntidad.Size = New System.Drawing.Size(771, 23)
        Me.ULblEntidad.TabIndex = 1
        '
        'LblEntidad
        '
        Me.LblEntidad.AutoSize = False
        Me.LblEntidad.Location = New System.Drawing.Point(12, 20)
        Me.LblEntidad.Name = "LblEntidad"
        Me.LblEntidad.Size = New System.Drawing.Size(63, 23)
        Me.LblEntidad.TabIndex = 0
        Me.LblEntidad.Text = "Entidad"
        Me.LblEntidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmData
        '
        Me.FrmData.Controls.Add(Me.GrdSatelite)
        Me.FrmData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FrmData.Location = New System.Drawing.Point(0, 89)
        Me.FrmData.Name = "FrmData"
        Me.FrmData.Size = New System.Drawing.Size(901, 385)
        Me.FrmData.TabIndex = 1
        Me.FrmData.TabStop = False
        Me.FrmData.Text = "Campos"
        '
        'GrdSatelite
        '
        Me.GrdSatelite.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GrdSatelite.AlternatingColors = True
        GrdSatelite_DesignTimeLayout.LayoutString = "<GridEXLayoutData><RootTable><GroupCondition /></RootTable></GridEXLayoutData>"
        Me.GrdSatelite.DesignTimeLayout = GrdSatelite_DesignTimeLayout
        Me.GrdSatelite.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdSatelite.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell
        Me.GrdSatelite.EntityName = Nothing
        Me.GrdSatelite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdSatelite.Location = New System.Drawing.Point(3, 17)
        Me.GrdSatelite.Name = "GrdSatelite"
        Me.GrdSatelite.PrimaryDataFields = Nothing
        Me.GrdSatelite.SecondaryDataFields = Nothing
        Me.GrdSatelite.Size = New System.Drawing.Size(895, 365)
        Me.GrdSatelite.TabIndex = 0
        Me.GrdSatelite.ViewName = Nothing
        '
        'PnlButtons
        '
        Me.PnlButtons.Controls.Add(Me.BtnAceptar)
        Me.PnlButtons.Controls.Add(Me.BtnCancelar)
        Me.PnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlButtons.Location = New System.Drawing.Point(0, 474)
        Me.PnlButtons.Name = "PnlButtons"
        Me.PnlButtons.Size = New System.Drawing.Size(901, 45)
        Me.PnlButtons.TabIndex = 2
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Location = New System.Drawing.Point(355, 6)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(87, 33)
        Me.BtnAceptar.TabIndex = 0
        Me.BtnAceptar.Text = "Aceptar"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Location = New System.Drawing.Point(458, 6)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(87, 33)
        Me.BtnCancelar.TabIndex = 1
        Me.BtnCancelar.Text = "Cancelar"
        '
        'frmSatelites
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(901, 519)
        Me.Controls.Add(Me.FrmData)
        Me.Controls.Add(Me.PnlButtons)
        Me.Controls.Add(Me.FrmCabecera)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSatelites"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tablas Auxiliares"
        Me.FrmCabecera.ResumeLayout(False)
        Me.FrmData.ResumeLayout(False)
        CType(Me.GrdSatelite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FrmCabecera As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents FrmData As Solmicro.Expertis.Engine.UI.Frame
    Friend WithEvents PnlButtons As Solmicro.Expertis.Engine.UI.Panel
    Friend WithEvents BtnAceptar As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents BtnCancelar As Solmicro.Expertis.Engine.UI.Button
    Friend WithEvents ULblEntidad As Solmicro.Expertis.Engine.UI.UnderLineLabel
    Friend WithEvents LblEntidad As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents ULblTablaAuxiliar As Solmicro.Expertis.Engine.UI.UnderLineLabel
    Friend WithEvents LblTablaAuxiliar As Solmicro.Expertis.Engine.UI.Label
    Friend WithEvents GrdSatelite As Solmicro.Expertis.Engine.UI.Grid
End Class
