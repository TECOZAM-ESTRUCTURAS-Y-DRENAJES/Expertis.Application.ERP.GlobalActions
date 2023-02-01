Imports Solmicro.Expertis.Business.ClasesTecozam

Public Class ClsGenerarDocuwareFactCompra
    Public Sub GenerarFacturaCompra(ByVal dt As DataTable)

        Dim cont As Integer = 0

        '29/7/22 Sacar los resultados en una tabla
        Dim frm As New DetalleActualizacionPagoPiso

        'Tabla para mostrar resultados
        Dim dt2 As New DataTable
        dt2.Columns.Add("FechaFactura", GetType(String))
        dt2.Columns.Add("NFactura", GetType(String))
        dt2.Columns.Add("SuFactura", GetType(String))

        Dim suFactura As String
        Dim dtFormada As New DataTable
        Dim drformada As DataRow
        Dim col As Integer = 0
        dtFormada.Columns.Add("IDProveedor", GetType(String))
        dtFormada.Columns.Add("FechaFactura", GetType(String))
        dtFormada.Columns.Add("SuFactura", GetType(String))
        dtFormada.Columns.Add("IDArticulo", GetType(String))
        dtFormada.Columns.Add("Cantidad", GetType(Double))
        dtFormada.Columns.Add("Precio", GetType(Double))
        dtFormada.Columns.Add("Importe", GetType(Double))
        dtFormada.Columns.Add("NObra", GetType(String))


        For Each dr As DataRow In dt.Rows

            suFactura = dt(cont)("SuFactura")
            drformada = dtFormada.NewRow
            drformada("IDProveedor") = dt(cont)("IDProveedor")
            drformada("SuFactura") = dt(cont)("SuFactura")
            drformada("FechaFactura") = dt(cont)("FechaFactura")
            drformada("IDArticulo") = dt(cont)("IDArticulo")
            drformada("Cantidad") = dt(cont)("Cantidad")
            drformada("Precio") = dt(cont)("Precio")
            drformada("Importe") = dt(cont)("Importe")
            drformada("NObra") = dt(cont)("NObra")
            'dtFormada.Rows.Add(drformada)
            'Si la siguiente fila tiene SuFactura diferente, empiezo el for otra vez
            'Sino añado otras columnas
            'Con un do while?
            cont += 1
            col = 0
            Try
                While suFactura = dt(cont)("SuFactura")
                    If Not dtFormada.Columns.Contains("IDArticulo" & col) Then
                        'Creo Estructura
                        dtFormada.Columns.Add("IDArticulo" & col, GetType(String))
                        dtFormada.Columns.Add("Cantidad" & col, GetType(Double))
                        dtFormada.Columns.Add("Precio" & col, GetType(Double))
                        dtFormada.Columns.Add("Importe" & col, GetType(Double))
                        'Inserto
                        drformada("IDArticulo" & col) = dt(cont)("IDArticulo")
                        drformada("Cantidad" & col) = dt(cont)("Cantidad")
                        drformada("Precio" & col) = dt(cont)("Precio")
                        drformada("Importe" & col) = dt(cont)("Importe")
                    Else
                        drformada("IDArticulo" & col) = dt(cont)("IDArticulo")
                        drformada("Cantidad" & col) = dt(cont)("Cantidad")
                        drformada("Precio" & col) = dt(cont)("Precio")
                        drformada("Importe" & col) = dt(cont)("Importe")
                    End If
                    col += 1
                    cont += 1
                End While
                dtFormada.Rows.Add(drformada)
            Catch ex As Exception
                dtFormada.Rows.Add(drformada)
                Exit For
            End Try     
            'cont += 1


        Next
        'Dim dtFinal As New DataTable
        'dtFinal = dtFormada
        Dim IDProveedorFra As String
        Dim SuFra As String
        Dim FechaFra As Date
        Dim IDFactura As String
        Dim tablaProveedor As New DataTable
        Dim fProveedor As New Filter

        Dim i As Integer = 0
        For Each dr As DataRow In dtFormada.Rows
            IDProveedorFra = dtFormada(i)("IDProveedor")
            SuFra = dtFormada(i)("SuFactura")
            FechaFra = dtFormada(i)("FechaFactura")
            IDFactura = creaFacturaCabecera(IDProveedorFra, SuFra, FechaFra, tablaProveedor, fProveedor)


            i += 1
        Next

        frm.mData2 = dt2
        frm.ShowDialog()
    End Sub

    Public Function creaFacturaCabecera(ByVal IDProveedorFra As String, ByVal SuFra As String, ByVal FechaFra As Date, ByVal tablaProveedor As DataTable, ByVal fProveedor As Filter)
        Dim dt As New DataTable
        Dim f As New Filter
        Dim IDFactura As String = ""
        f.Add("IDProveedor", FilterOperator.Equal, IDProveedorFra)
        dt = New BE.DataEngine().Filter("tbMaestroProveedor", f)
        MessageBox.Show(dt.Rows.Count)


        Return IDFactura
    End Function
End Class