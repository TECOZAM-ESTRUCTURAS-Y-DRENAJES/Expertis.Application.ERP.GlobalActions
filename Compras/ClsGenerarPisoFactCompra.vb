Imports System.Text
Imports System.Windows.Forms

Public Class ClsGenerarPisoFactCompra

    Public Sub GenerarFacturaCompra(ByVal record As DataTable)

        Dim dteFechaFactura As Date
        Dim cont As Integer = 0

        '29/7/22 Sacar los resultados en una tabla
        Dim frm As New DetalleActualizacionPagoPiso

        'Tabla para mostrar resultados
        Dim dt As New DataTable
        dt.Columns.Add("FechaFactura", GetType(String))
        dt.Columns.Add("NFactura", GetType(String))
        dt.Columns.Add("SuFactura", GetType(String))

        Dim Propuesta As New ResultFacturacion

        For Each dr As DataRow In record.Rows

            If IsDate(record.Rows(cont)("FechaFactura")) Then dteFechaFactura = record.Rows(cont)("FechaFactura")
            Dim strSuFactura As String = record.Rows(cont)("SuFactura") & String.Empty
            Dim datos As New DataPrcFacturacionCompraPiso(New Integer() {record.Rows(cont)("IDPisoPago")}, Nothing, dteFechaFactura, strSuFactura, record.Rows(cont)("IDPisoPago"))
            Dim BEDataEngine As New BE.DataEngine
            Propuesta = BEDataEngine.RunProcess(GetType(PrcFacturacionCompraPiso), datos)
            Dim datosAct As New DataPrcActualizarFactura(Propuesta)
            Propuesta = BEDataEngine.RunProcess(GetType(PrcActualizarFacturaCompra), datosAct)
            'Añado linea para ver el total de facturas creadas al final
            Dim newrow As DataRow = dt.NewRow
            newrow("FechaFactura") = datos.DteFechaFactura
            newrow("SuFactura") = datos.SuFactura
            newrow("NFactura") = datosAct.RstFacturacion.PropuestaFacturas.Rows(0)("NFactura").ToString
            dt.Rows.Add(newrow)
            '
            'ACTUALIZA TBPISOPAGOS, FACTURADO A 1 Y NFACTURACOMPRA=FCVV22-
            '
            actualizaPagoPisos(datosAct.RstFacturacion.PropuestaFacturas.Rows(0)("IDPisoPagos").ToString, datosAct.RstFacturacion.PropuestaFacturas.Rows(0)("NFactura").ToString)

            '
            'PERMITE ABRIR LA ULTIMA FACTURA DE COMPRA
            '
            'If cont = record.Rows.Count - 1 Then
            '    TratarLog(Propuesta.Log, enumTipoDocumentoCreado.FacturaCompraPiso, False, True)
            'End If
            cont += 1
        Next
        frm.mData2 = dt
        frm.ShowDialog()
        'ola
        TratarLog(Propuesta.Log, enumTipoDocumentoCreado.FacturaCompraPiso, False, True)
    End Sub


    Public Sub actualizaPagoPisos(ByVal IDPisoPagos As String, ByVal NFacturaCompra As String)
        Dim art As New Business.Negocio.Articulo
        Dim strSQL As String
        strSQL = "UPDATE tbPisosPagos"
        strSQL &= " SET Facturado=1, NFacturaCompra ='" & NFacturaCompra & "'"
        strSQL &= " WHERE IDPisoPago = '" & IDPisoPagos & "'"

        Try
            art.executestrSQL(strSQL)
        Catch ex As Exception

        End Try
    End Sub
End Class
