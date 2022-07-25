Public Class frmSeleccionarFecha

#Region " Propiedades "

    Public Property Fecha() As Date
        Get
            Return Nz(cbxFecha.Value, cnMinDate)
        End Get
        Set(ByVal value As Date)
            cbxFecha.Value = value
        End Set
    End Property


    Public Property FechaDesde() As Date
        Get
            Return Nz(cbxFechaDesde.Value, cnMinDate)
        End Get
        Set(ByVal value As Date)
            cbxFechaDesde.Value = value
        End Set
    End Property

    Public Property FechaHasta() As Date
        Get
            Return Nz(cbxFechaHasta.Value, cnMinDate)
        End Get
        Set(ByVal value As Date)
            cbxFechaHasta.Value = value
        End Set
    End Property

#End Region


#Region " Aceptar/Cancelar "

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        If Nz(cbxFecha.Value, cnMinDate) = cnMinDate Then
            ExpertisApp.GenerateMessage("Debe indicar una Fecha de Contabilización.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

#End Region


End Class