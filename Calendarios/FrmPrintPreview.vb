Public Class FrmPrintPreview

    Public ReadOnly Property IntOpcion() As Integer
        Get
            If RdImpresora.Checked Then
                Return 0
            ElseIf RdVistaPrevia.Checked Then
                Return 1
            End If
        End Get
    End Property

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

End Class