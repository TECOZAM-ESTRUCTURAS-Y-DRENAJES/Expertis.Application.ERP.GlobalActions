Public Class frmContadorFechaAlbaran

    Private MContador As String
    Private MFecha As Date

    Public Property Contador() As String
        Get
            Return MContador
        End Get
        Set(ByVal value As String)
            MContador = value
        End Set
    End Property

    Public Property Fecha() As Date
        Get
            Return MFecha
        End Get
        Set(ByVal value As Date)
            MFecha = value
        End Set
    End Property

    Protected Overridable Sub LoadData()
        If Length(MContador) > 0 Then
            Me.AdvContador.Value = MContador
        Else
            'Load Contador por defecto
            ExpertisApp.ExecuteTask(Of CentroGestion.ContadorEntidad, String)(AddressOf CentroGestion.GetContadorPredeterminadoCGestionUsuario, CentroGestion.ContadorEntidad.FacturaVenta)
            Dim StData As Contador.DefaultCounter = ExpertisApp.ExecuteTask(Of String, Contador.DefaultCounter)(AddressOf Business.General.Contador.GetDefaultCounterValue, "AlbaranVentaCabecera")
            Me.AdvContador.Value = StData.CounterID
        End If
        If Length(MFecha) > 0 Then Me.ClbFecha.Value = MFecha
    End Sub

    Private Function CheckData() As Boolean
        If Length(Me.AdvContador.Value) = 0 Then
            ExpertisApp.GenerateMessage("El Contador es un dato Obligatorio.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        Return True
    End Function

    Private Sub SaveData()
        MContador = Me.AdvContador.Value
        If Length(Me.ClbFecha.Value) > 0 Then MFecha = Me.ClbFecha.Value
    End Sub

    Private Sub frmContadorFechaAlbaran_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.DesignMode Then LoadData()
    End Sub

    Private Sub AdvContador_SetPredefinedFilter(ByVal sender As Object, ByVal e As Engine.UI.AdvSearchFilterEventArgs) Handles AdvContador.SetPredefinedFilter
        e.Filter.Add("Entidad", FilterOperator.Equal, "AlbaranVentaCabecera")
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If CheckData() Then
            SaveData()
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

End Class