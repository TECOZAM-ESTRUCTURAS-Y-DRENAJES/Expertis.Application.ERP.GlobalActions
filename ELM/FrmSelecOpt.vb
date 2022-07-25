Public Class FrmSelecOpt

    Private mSelectedOpt As Integer
    Public Property SelectedOpt() As Integer
        Get
            Return mSelectedOpt
        End Get
        Set(ByVal value As Integer)
            mSelectedOpt = value
        End Set
    End Property

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If RbFicha.Checked Then
            mSelectedOpt = 0
        ElseIf RbEstructura.Checked Then
            mSelectedOpt = 1
        ElseIf RbRuta.Checked Then
            mSelectedOpt = 2
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

End Class