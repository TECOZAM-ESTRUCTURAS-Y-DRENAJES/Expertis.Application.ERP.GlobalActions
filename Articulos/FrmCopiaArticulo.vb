Public Class FrmCopiaArticulo
    Inherits Solmicro.Expertis.Engine.UI.FormBase

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Public WithEvents cmbCancelar As Solmicro.Expertis.Engine.UI.Button
    Public WithEvents CmbAceptar As Solmicro.Expertis.Engine.UI.Button
    Public WithEvents FwiContador As Solmicro.Expertis.Engine.UI.AdvSearch
    Public WithEvents lblFwiContador As Solmicro.Expertis.Engine.UI.Label
    Public WithEvents lblIDArticulo As Solmicro.Expertis.Engine.UI.Label
    Public WithEvents txIDArticulo As Solmicro.Expertis.Engine.UI.TextBox
    Public WithEvents chkTodos As Solmicro.Expertis.Engine.UI.CheckBox
    Public WithEvents chkAlmacenes As Solmicro.Expertis.Engine.UI.CheckBox
    Public WithEvents chkUnidades As Solmicro.Expertis.Engine.UI.CheckBox
    Public WithEvents chkClientes As Solmicro.Expertis.Engine.UI.CheckBox
    Public WithEvents chkTarifas As Solmicro.Expertis.Engine.UI.CheckBox
    Public WithEvents chkProveedores As Solmicro.Expertis.Engine.UI.CheckBox
    Public WithEvents chkEstructuras As Solmicro.Expertis.Engine.UI.CheckBox
    Public WithEvents chkRutas As Solmicro.Expertis.Engine.UI.CheckBox
    Public WithEvents chkCostesVarios As Solmicro.Expertis.Engine.UI.CheckBox
    Public WithEvents chkAnalitica As Solmicro.Expertis.Engine.UI.CheckBox
    Public WithEvents chkDocumentos As Solmicro.Expertis.Engine.UI.CheckBox
    Public WithEvents chkIdiomas As Solmicro.Expertis.Engine.UI.CheckBox
    Public WithEvents chkPromociones As Solmicro.Expertis.Engine.UI.CheckBox
    Public WithEvents chkEspecificaciones As Solmicro.Expertis.Engine.UI.CheckBox
    Public WithEvents chkCaracteristicas As Solmicro.Expertis.Engine.UI.CheckBox
    Public WithEvents chkCaracteristicasMaq As Solmicro.Expertis.Engine.UI.CheckBox
    Public WithEvents txtDescArticulo As Solmicro.Expertis.Engine.UI.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmbCancelar = New Solmicro.Expertis.Engine.UI.Button
        Me.CmbAceptar = New Solmicro.Expertis.Engine.UI.Button
        Me.FwiContador = New Solmicro.Expertis.Engine.UI.AdvSearch
        Me.lblFwiContador = New Solmicro.Expertis.Engine.UI.Label
        Me.lblIDArticulo = New Solmicro.Expertis.Engine.UI.Label
        Me.txIDArticulo = New Solmicro.Expertis.Engine.UI.TextBox
        Me.chkTodos = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.chkAlmacenes = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.chkUnidades = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.chkClientes = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.chkTarifas = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.chkProveedores = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.chkEstructuras = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.chkRutas = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.chkCostesVarios = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.chkAnalitica = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.txtDescArticulo = New Solmicro.Expertis.Engine.UI.TextBox
        Me.chkDocumentos = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.chkIdiomas = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.chkPromociones = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.chkEspecificaciones = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.chkCaracteristicas = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.chkCaracteristicasMaq = New Solmicro.Expertis.Engine.UI.CheckBox
        Me.SuspendLayout()
        '
        'cmbCancelar
        '
        Me.cmbCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmbCancelar.Location = New System.Drawing.Point(264, 280)
        Me.cmbCancelar.Name = "cmbCancelar"
        Me.cmbCancelar.Size = New System.Drawing.Size(112, 32)
        Me.cmbCancelar.TabIndex = 19
        Me.cmbCancelar.Text = "Cancelar"
        '
        'CmbAceptar
        '
        Me.CmbAceptar.Location = New System.Drawing.Point(144, 280)
        Me.CmbAceptar.Name = "CmbAceptar"
        Me.CmbAceptar.Size = New System.Drawing.Size(112, 32)
        Me.CmbAceptar.TabIndex = 18
        Me.CmbAceptar.Text = "Aceptar"
        '
        'FwiContador
        '
        Me.FwiContador.EntityName = "EntidadContador"
        Me.FwiContador.Location = New System.Drawing.Point(72, 8)
        Me.FwiContador.MaxLength = 25
        Me.FwiContador.Name = "FwiContador"
        Me.FwiContador.SecondaryDataFields = "IDContador"
        Me.FwiContador.Size = New System.Drawing.Size(120, 21)
        Me.FwiContador.TabIndex = 18
        Me.FwiContador.ViewName = "tbEntidadContador"
        '
        'lblFwiContador
        '
        Me.lblFwiContador.Location = New System.Drawing.Point(8, 8)
        Me.lblFwiContador.Name = "lblFwiContador"
        Me.lblFwiContador.Size = New System.Drawing.Size(56, 17)
        Me.lblFwiContador.TabIndex = 2
        Me.lblFwiContador.Tag = ""
        Me.lblFwiContador.Text = "Contador"
        '
        'lblIDArticulo
        '
        Me.lblIDArticulo.Location = New System.Drawing.Point(8, 32)
        Me.lblIDArticulo.Name = "lblIDArticulo"
        Me.lblIDArticulo.Size = New System.Drawing.Size(47, 17)
        Me.lblIDArticulo.TabIndex = 4
        Me.lblIDArticulo.Text = "Artículo"
        '
        'txIDArticulo
        '
        Me.txIDArticulo.Location = New System.Drawing.Point(72, 32)
        Me.txIDArticulo.MaxLength = 25
        Me.txIDArticulo.Name = "txIDArticulo"
        Me.txIDArticulo.Size = New System.Drawing.Size(120, 21)
        Me.txIDArticulo.TabIndex = 0
        '
        'chkTodos
        '
        Me.chkTodos.Checked = True
        Me.chkTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodos.Location = New System.Drawing.Point(16, 64)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(176, 23)
        Me.chkTodos.TabIndex = 2
        Me.chkTodos.Text = "Copiar todos los conceptos"
        '
        'chkAlmacenes
        '
        Me.chkAlmacenes.Checked = True
        Me.chkAlmacenes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAlmacenes.Location = New System.Drawing.Point(72, 96)
        Me.chkAlmacenes.Name = "chkAlmacenes"
        Me.chkAlmacenes.Size = New System.Drawing.Size(160, 23)
        Me.chkAlmacenes.TabIndex = 3
        Me.chkAlmacenes.Text = "Copiar Almacenes"
        '
        'chkUnidades
        '
        Me.chkUnidades.Checked = True
        Me.chkUnidades.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUnidades.Location = New System.Drawing.Point(72, 120)
        Me.chkUnidades.Name = "chkUnidades"
        Me.chkUnidades.Size = New System.Drawing.Size(168, 23)
        Me.chkUnidades.TabIndex = 4
        Me.chkUnidades.Text = "Copiar Unidades"
        '
        'chkClientes
        '
        Me.chkClientes.Checked = True
        Me.chkClientes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkClientes.Location = New System.Drawing.Point(72, 144)
        Me.chkClientes.Name = "chkClientes"
        Me.chkClientes.Size = New System.Drawing.Size(128, 23)
        Me.chkClientes.TabIndex = 5
        Me.chkClientes.Text = "Copiar Clientes"
        '
        'chkTarifas
        '
        Me.chkTarifas.Checked = True
        Me.chkTarifas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTarifas.Location = New System.Drawing.Point(72, 192)
        Me.chkTarifas.Name = "chkTarifas"
        Me.chkTarifas.Size = New System.Drawing.Size(104, 23)
        Me.chkTarifas.TabIndex = 7
        Me.chkTarifas.Text = "Copiar Tarifas"
        '
        'chkProveedores
        '
        Me.chkProveedores.Checked = True
        Me.chkProveedores.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkProveedores.Location = New System.Drawing.Point(72, 168)
        Me.chkProveedores.Name = "chkProveedores"
        Me.chkProveedores.Size = New System.Drawing.Size(168, 23)
        Me.chkProveedores.TabIndex = 6
        Me.chkProveedores.Text = "Copiar Proveedores"
        '
        'chkEstructuras
        '
        Me.chkEstructuras.Checked = True
        Me.chkEstructuras.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEstructuras.Location = New System.Drawing.Point(72, 216)
        Me.chkEstructuras.Name = "chkEstructuras"
        Me.chkEstructuras.Size = New System.Drawing.Size(136, 23)
        Me.chkEstructuras.TabIndex = 8
        Me.chkEstructuras.Text = "Copiar Estructuras"
        '
        'chkRutas
        '
        Me.chkRutas.Checked = True
        Me.chkRutas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRutas.Location = New System.Drawing.Point(72, 240)
        Me.chkRutas.Name = "chkRutas"
        Me.chkRutas.Size = New System.Drawing.Size(104, 23)
        Me.chkRutas.TabIndex = 9
        Me.chkRutas.Text = "Copiar Rutas"
        '
        'chkCostesVarios
        '
        Me.chkCostesVarios.Checked = True
        Me.chkCostesVarios.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCostesVarios.Location = New System.Drawing.Point(288, 240)
        Me.chkCostesVarios.Name = "chkCostesVarios"
        Me.chkCostesVarios.Size = New System.Drawing.Size(152, 23)
        Me.chkCostesVarios.TabIndex = 10
        Me.chkCostesVarios.Text = "Copiar Costes Varios"
        '
        'chkAnalitica
        '
        Me.chkAnalitica.Checked = True
        Me.chkAnalitica.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAnalitica.Location = New System.Drawing.Point(288, 96)
        Me.chkAnalitica.Name = "chkAnalitica"
        Me.chkAnalitica.Size = New System.Drawing.Size(120, 23)
        Me.chkAnalitica.TabIndex = 11
        Me.chkAnalitica.Text = "Copiar Analítica"
        '
        'txtDescArticulo
        '
        Me.txtDescArticulo.Location = New System.Drawing.Point(195, 32)
        Me.txtDescArticulo.MaxLength = 300
        Me.txtDescArticulo.Name = "txtDescArticulo"
        Me.txtDescArticulo.Size = New System.Drawing.Size(341, 21)
        Me.txtDescArticulo.TabIndex = 1
        '
        'chkDocumentos
        '
        Me.chkDocumentos.Location = New System.Drawing.Point(288, 72)
        Me.chkDocumentos.Name = "chkDocumentos"
        Me.chkDocumentos.Size = New System.Drawing.Size(136, 23)
        Me.chkDocumentos.TabIndex = 12
        Me.chkDocumentos.Text = "Copiar Documentos"
        Me.chkDocumentos.Visible = False
        '
        'chkIdiomas
        '
        Me.chkIdiomas.Checked = True
        Me.chkIdiomas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIdiomas.Location = New System.Drawing.Point(288, 144)
        Me.chkIdiomas.Name = "chkIdiomas"
        Me.chkIdiomas.Size = New System.Drawing.Size(120, 23)
        Me.chkIdiomas.TabIndex = 14
        Me.chkIdiomas.Text = "Copiar Idiomas"
        '
        'chkPromociones
        '
        Me.chkPromociones.Checked = True
        Me.chkPromociones.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPromociones.Location = New System.Drawing.Point(288, 120)
        Me.chkPromociones.Name = "chkPromociones"
        Me.chkPromociones.Size = New System.Drawing.Size(144, 23)
        Me.chkPromociones.TabIndex = 13
        Me.chkPromociones.Text = "Copiar Promociones"
        '
        'chkEspecificaciones
        '
        Me.chkEspecificaciones.Checked = True
        Me.chkEspecificaciones.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEspecificaciones.Location = New System.Drawing.Point(288, 168)
        Me.chkEspecificaciones.Name = "chkEspecificaciones"
        Me.chkEspecificaciones.Size = New System.Drawing.Size(200, 23)
        Me.chkEspecificaciones.TabIndex = 15
        Me.chkEspecificaciones.Text = "Copiar Especificaciones"
        '
        'chkCaracteristicas
        '
        Me.chkCaracteristicas.Checked = True
        Me.chkCaracteristicas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCaracteristicas.Location = New System.Drawing.Point(288, 192)
        Me.chkCaracteristicas.Name = "chkCaracteristicas"
        Me.chkCaracteristicas.Size = New System.Drawing.Size(152, 23)
        Me.chkCaracteristicas.TabIndex = 16
        Me.chkCaracteristicas.Text = "Copiar Características"
        '
        'chkCaracteristicasMaq
        '
        Me.chkCaracteristicasMaq.Checked = True
        Me.chkCaracteristicasMaq.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCaracteristicasMaq.Location = New System.Drawing.Point(288, 216)
        Me.chkCaracteristicasMaq.Name = "chkCaracteristicasMaq"
        Me.chkCaracteristicasMaq.Size = New System.Drawing.Size(224, 23)
        Me.chkCaracteristicasMaq.TabIndex = 17
        Me.chkCaracteristicasMaq.Text = "Copiar Características Maquinaria"
        '
        'FrmCopiaArticulo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(544, 317)
        Me.Controls.Add(Me.chkCaracteristicasMaq)
        Me.Controls.Add(Me.chkCaracteristicas)
        Me.Controls.Add(Me.chkEspecificaciones)
        Me.Controls.Add(Me.chkPromociones)
        Me.Controls.Add(Me.chkIdiomas)
        Me.Controls.Add(Me.chkDocumentos)
        Me.Controls.Add(Me.lblIDArticulo)
        Me.Controls.Add(Me.lblFwiContador)
        Me.Controls.Add(Me.txtDescArticulo)
        Me.Controls.Add(Me.chkAnalitica)
        Me.Controls.Add(Me.chkCostesVarios)
        Me.Controls.Add(Me.chkRutas)
        Me.Controls.Add(Me.chkEstructuras)
        Me.Controls.Add(Me.chkProveedores)
        Me.Controls.Add(Me.chkTarifas)
        Me.Controls.Add(Me.chkClientes)
        Me.Controls.Add(Me.chkUnidades)
        Me.Controls.Add(Me.chkAlmacenes)
        Me.Controls.Add(Me.chkTodos)
        Me.Controls.Add(Me.txIDArticulo)
        Me.Controls.Add(Me.cmbCancelar)
        Me.Controls.Add(Me.CmbAceptar)
        Me.Controls.Add(Me.FwiContador)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmCopiaArticulo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Copia Artículo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private _IDContador As String
    Private _IDArticulo As String
    Private _DescArticulo As String
    Private _CaracteristicasMaq As Boolean
    Private _Caracteristicas As Boolean
    Private _Especificaciones As Boolean
    Private _Promociones As Boolean
    Private _Idiomas As Boolean
    Private _Documentos As Boolean
    Private _Analitica As Boolean
    Private _CostesVarios As Boolean
    Private _Rutas As Boolean
    Private _Estructuras As Boolean
    Private _Proveedores As Boolean
    Private _Tarifas As Boolean
    Private _Clientes As Boolean
    Private _Unidades As Boolean
    Private _Almacenes As Boolean

    Property DescArticulo() As String
        Get
            Return _DescArticulo
        End Get
        Set(ByVal Value As String)
            _DescArticulo = Value
        End Set
    End Property

    ReadOnly Property CaracteristicasMaq() As Boolean
        Get
            Return _CaracteristicasMaq
        End Get
    End Property

    ReadOnly Property Caracteristicas() As Boolean
        Get
            Return _Caracteristicas
        End Get
    End Property

    ReadOnly Property Especificaciones() As Boolean
        Get
            Return _Especificaciones
        End Get        
    End Property

    ReadOnly Property Promociones() As Boolean
        Get
            Return _Promociones
        End Get        
    End Property

    ReadOnly Property Idiomas() As Boolean
        Get
            Return _Idiomas
        End Get        
    End Property

    ReadOnly Property Documentos() As Boolean
        Get
            Return _Documentos
        End Get        
    End Property

    ReadOnly Property Analitica() As Boolean
        Get
            Return _Analitica
        End Get        
    End Property

    ReadOnly Property CostesVarios() As Boolean
        Get
            Return _CostesVarios
        End Get        
    End Property

    ReadOnly Property Rutas() As Boolean
        Get
            Return _Rutas
        End Get        
    End Property

    ReadOnly Property Estructuras() As Boolean
        Get
            Return _Estructuras
        End Get        
    End Property

    ReadOnly Property Proveedores() As Boolean
        Get
            Return _Proveedores
        End Get        
    End Property

    ReadOnly Property Tarifas() As Boolean
        Get
            Return _Tarifas
        End Get        
    End Property

    ReadOnly Property Clientes() As Boolean
        Get
            Return _Clientes
        End Get        
    End Property

    ReadOnly Property Unidades() As Boolean
        Get
            Return _Unidades
        End Get        
    End Property

    ReadOnly Property Almacenes() As Boolean
        Get
            Return _Almacenes
        End Get        
    End Property

    Public WriteOnly Property CopiaCaract() As Boolean
        Set(ByVal value As Boolean)
            If value Then
                Me.lblIDArticulo.Visible = False : Me.txtDescArticulo.Visible = False
                Me.lblFwiContador.Visible = False : Me.FwiContador.Visible = False
                Me.txIDArticulo.Visible = False
            End If
        End Set
    End Property

    Property IDContador() As String
        Get
            Return _IDContador
        End Get
        Set(ByVal Value As String)
            _IDContador = Value
        End Set
    End Property

    Property IDArticulo() As String
        Get
            Return _IDArticulo
        End Get
        Set(ByVal Value As String)
            _IDArticulo = Value
        End Set
    End Property

    Private Sub FrmCopiaArticulo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FwiContador.Text = _IDContador
        txtDescArticulo.Text = _DescArticulo
        txIDArticulo.Text = _IDArticulo
    End Sub

    Private Sub FwiContador_SetPredefinedFilter(ByVal sender As Object, ByVal e As Engine.UI.AdvSearchFilterEventArgs) Handles FwiContador.SetPredefinedFilter
        e.Filter.Add(New StringFilterItem("Entidad", FilterOperator.Equal, "Articulo"))
    End Sub

    Private Sub CmbAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbAceptar.Click
        If txtDescArticulo.Text.Trim = String.Empty AndAlso Me.txtDescArticulo.Visible = True Then
            ExpertisApp.GenerateMessage("Introduzca la descripción del artículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim strIDArticulo As String = Me.txIDArticulo.Text.Trim
        If Length(strIDArticulo) > 0 Then
            Dim dtArticulo As DataTable = New Articulo().SelOnPrimaryKey(strIDArticulo)
            If Not dtArticulo Is Nothing AndAlso dtArticulo.Rows.Count > 0 Then
                ExpertisApp.GenerateMessage("El Artículo '|' ya se encuentra registrado en la Base de Datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, strIDArticulo)
                Exit Sub
            End If
        End If

        _IDContador = FwiContador.Text.Trim
        _IDArticulo = txIDArticulo.Text.Trim
        _DescArticulo = txtDescArticulo.Text.Trim
        _CaracteristicasMaq = chkCaracteristicasMaq.Checked
        _Caracteristicas = chkCaracteristicas.Checked
        _Especificaciones = chkEspecificaciones.Checked
        _Promociones = chkPromociones.Checked
        _Idiomas = chkIdiomas.Checked
        _Documentos = chkDocumentos.Checked
        _Analitica = chkAnalitica.Checked
        _CostesVarios = chkCostesVarios.Checked
        _Rutas = chkRutas.Checked
        _Estructuras = chkEstructuras.Checked
        _Proveedores = chkProveedores.Checked
        _Tarifas = chkTarifas.Checked
        _Clientes = chkClientes.Checked
        _Unidades = chkUnidades.Checked
        _Almacenes = chkAlmacenes.Checked

        If _IDContador.Length > 0 Then
            Dim oEntidadContador As New EntidadContador
            Dim f As New Filter
            f.Add(New StringFilterItem("Entidad", "Articulo"))
            f.Add(New StringFilterItem("IDContador", _IDContador))
            Dim dt As DataTable = oEntidadContador.Filter(f)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                ExpertisApp.GenerateMessage("El contador elegido no existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
        'If _IDContador.Length = 0 AndAlso _IDArticulo.Length = 0 Then
        '    'No ha seleccionado ningun Contador. Por defecto se cogerá
        '    'el que tenga el Artículo que va a copiar. ¿Desea continuar?.
        '    If ExpertisApp.GenerateMessage("Mensaje 10688 - No ha seleccionado ningun Contador. Por defecto se cogerá el que tenga el Artículo que va a copiar. ¿Desea continuar?.",MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.No Then
        '        Me.DialogResult = DialogResult.None
        '    Else
        '        Me.DialogResult = DialogResult.OK
        '    End If
        'Else
        Me.DialogResult = DialogResult.OK
        'End If


    End Sub

    Private Sub chkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodos.CheckedChanged
        If chkTodos.Checked Then
            chkCaracteristicasMaq.Checked = True
            chkCaracteristicas.Checked = True
            chkEspecificaciones.Checked = True
            chkPromociones.Checked = True
            chkIdiomas.Checked = True
            'chkDocumentos.Checked = True
            chkAnalitica.Checked = True
            chkCostesVarios.Checked = True
            chkRutas.Checked = True
            chkEstructuras.Checked = True
            chkProveedores.Checked = True
            chkTarifas.Checked = True
            chkClientes.Checked = True
            chkUnidades.Checked = True
            chkAlmacenes.Checked = True
        Else
            chkCaracteristicasMaq.Checked = False
            chkCaracteristicas.Checked = False
            chkEspecificaciones.Checked = False
            chkPromociones.Checked = False
            chkIdiomas.Checked = False
            'chkDocumentos.Checked = false
            chkAnalitica.Checked = False
            chkCostesVarios.Checked = False
            chkRutas.Checked = False
            chkEstructuras.Checked = False
            chkProveedores.Checked = False
            chkTarifas.Checked = False
            chkClientes.Checked = False
            chkUnidades.Checked = False
            chkAlmacenes.Checked = False
        End If
    End Sub

End Class
