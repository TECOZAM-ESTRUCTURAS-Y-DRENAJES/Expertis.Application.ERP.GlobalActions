Imports Janus.Windows.GridEX

Public Class DetalleActualizacionPagoPiso
    Inherits System.Windows.Forms.Form


    Public mData2 As New DataTable

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        'CrearEsquema()
    End Sub

    Private Sub DetalleActualizacionPagoPisos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Detalle.TabKeyBehavior = TabKeyBehavior.ControlNavigation
        Detalle.DataSource = mData2
    End Sub

    Private Sub DetalleActualizacionPagoPisos_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        CloseButton.Focus()
    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub
End Class