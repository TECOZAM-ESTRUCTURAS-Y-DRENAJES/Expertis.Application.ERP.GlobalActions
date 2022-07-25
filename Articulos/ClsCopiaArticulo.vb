Public Class ClsCopiaArticulo
    Implements Solmicro.Expertis.Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Solmicro.Expertis.Engine.IAction.Execute
        If Not record Is Nothing AndAlso record.Rows.Count > 0 Then
            If Length(record.Rows(0)("IDArticulo")) > 0 Then
                Dim strIdArticulo As String = record.Rows(0)("IDArticulo")
                Dim strIDContador As String = record.Rows(0)("IDContador") & String.Empty
                Dim A As New Articulo
                If Length(strIDContador) = 0 Then
                    Dim dtCont As DataTable = A.AddNewForm
                    If Not dtCont Is Nothing AndAlso dtCont.Rows.Count > 0 Then
                        strIDContador = dtCont.Rows(0)("IDContador") & String.Empty
                    End If
                End If

                Dim frm As New FrmCopiaArticulo
                frm.IDContador = strIDContador
                frm.DescArticulo = record.Rows(0)("DescArticulo") & String.Empty

                If Length(strIDContador) = 0 Then
                    frm.IDArticulo = AccionCodificar(record, True)
                End If

                frm.ShowDialog()

                If frm.DialogResult = DialogResult.OK Then
                    strIDContador = frm.IDContador
                    Dim strIdArticuloNw As String = frm.IDArticulo

                    Dim data As New Articulo.DatosArtCopia
                    data.IDArticulo = strIdArticulo
                    data.DescArticulo = frm.txtDescArticulo.Text
                    data.IDContador = strIDContador
                    data.BlnCopyCaractMaq = frm.chkCaracteristicasMaq.Checked
                    data.BlnCopyCaract = frm.chkCaracteristicas.Checked
                    data.BlnCopyEsp = frm.chkEspecificaciones.Checked
                    data.BlnCopyPromo = frm.chkPromociones.Checked
                    data.BlnCopyIdio = frm.chkIdiomas.Checked
                    data.BlnCopyDoc = frm.chkDocumentos.Checked
                    data.BlnCopyAna = frm.chkAnalitica.Checked
                    data.BlnCopyCostesVar = frm.chkCostesVarios.Checked
                    data.BlnCopyRu = frm.chkRutas.Checked
                    data.BlnCopyEst = frm.chkEstructuras.Checked
                    data.BlnCopyProv = frm.chkProveedores.Checked
                    data.BlnCopyTar = frm.chkTarifas.Checked
                    data.BlnCopyClie = frm.chkClientes.Checked
                    data.BlnCopyUd = frm.chkUnidades.Checked
                    data.BlnCopyAlm = frm.chkAlmacenes.Checked
                    data.IDArticuloNew = strIdArticuloNw

                    strIdArticuloNw = ExpertisApp.ExecuteTask(Of Articulo.DatosArtCopia, String)(AddressOf Articulo.CopiaArticulo, data)

                    If strIdArticuloNw.Length > 0 Then
                        If ExpertisApp.GenerateMessage("El Artículo | se ha creado correctamente.|¿Desea visualizar sus datos ahora?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, strIdArticuloNw, vbNewLine) = DialogResult.Yes Then
                            ExpertisApp.OpenForm("MARTICULO", New FilterItem("IDArticulo", FilterOperator.Equal, strIdArticuloNw))
                        End If
                    End If
                End If
            End If
        End If
    End Sub


    Protected Overridable Function AccionCodificar(ByVal record As System.Data.DataTable, Optional ByVal UpdateContador As Boolean = False) As String
        Dim DtCaract As New DataTable
        Dim StData As New Articulo.DataCodifArt(record.Rows(0)("IDTipo"), record.Rows(0)("IDFamilia"), Nz(record.Rows(0)("IDSubFamilia"), String.Empty), DtCaract, record.Rows(0).Table)
        StData.UpdateContador = UpdateContador
        Dim StDataReturn As Articulo.DataCodifReturn = ExpertisApp.ExecuteTask(Of Articulo.DataCodifArt, Articulo.DataCodifReturn)(AddressOf Articulo.CodificarArticulo, StData)
        If Not StDataReturn Is Nothing Then
            If StDataReturn.IDArticulo.Length > 0 Then
                Return Nz(StDataReturn.IDArticulo, String.Empty)
            End If
        End If
    End Function

End Class