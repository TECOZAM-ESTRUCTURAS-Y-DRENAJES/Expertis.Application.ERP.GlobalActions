Public Class ClsGenerarPedCompra
    Implements Solmicro.Expertis.Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Solmicro.Expertis.Engine.IAction.Execute
        Select Case entityName
            Case "SolicitudCompraLinea"
                If record.Rows.Count > 0 Then
                    ExpertisApp.GenerateMessage("Se procesarán las lineas con cantidades y no se tendrán en cuenta las solicitudes rechazadas.", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Dim objFilter As New Filter
                    Dim dt As DataTable = record
                    Dim BEDataEngine As New BE.DataEngine
                    objFilter.Add(New IsNullFilterItem("IDProveedor"))
                    Dim adr() As DataRow = dt.Select(objFilter.Compose(New AdoFilterComposer))
                    If Not IsNothing(adr) AndAlso adr.Length > 0 Then
                        ExpertisApp.GenerateMessage("El Proveedor es un dato Obligatorio. Por favor revise los datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    objFilter.Clear()
                    objFilter.UnionOperator = FilterUnionOperator.Or
                    objFilter.Add(New NumberFilterItem("Estado", FilterOperator.GreaterThanOrEqual, enumscEstado.scDenegada))
                    objFilter.Add(New NumberFilterItem("CantidadMarca1", 0))
                    For Each dr As DataRow In dt.Select(objFilter.Compose(New AdoFilterComposer))
                        dr.Delete()
                    Next
                    dt.AcceptChanges()
                    If dt.Rows.Count > 0 Then
                        Dim Solicitudes(-1) As DataSolicitudCompra
                        For Each dr As DataRow In dt.Rows
                            Dim sol As New DataSolicitudCompra(dr("IDLineaSolicitud"), dr("CantidadMarca1"))
                            ReDim Preserve Solicitudes(Solicitudes.Length)
                            Solicitudes(Solicitudes.Length - 1) = sol
                        Next
                        Dim FrmCall As Form = ExpertisApp.GetForm(programID)
                        Dim StrContador As String = String.Empty
                        For Each Frm As Form In System.Windows.Forms.Application.OpenForms
                            If FrmCall.Name = Frm.Name Then
                                StrContador = CType(FrmCall, Expertis.Application.ERP.SolicitudCompra.CIGestionDeSolicitud).advContador.Text
                                Exit For
                            End If
                        Next
                        Dim datos As New DataPrcCrearPedidoCompraSolicitudCompra(Solicitudes, StrContador)
                        Dim log As LogProcess = BEDataEngine.RunProcess(GetType(PrcCrearPedidoCompraSolicitudCompra), datos)
                        TratarLog(log, enumTipoDocumentoCreado.PedidoCompra, True, True)
                    Else
                        ExpertisApp.GenerateMessage("No hay líneas para generar ningún proceso.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    CommonMembers.ActionRefreshCIForm(programID)
                Else : ExpertisApp.GenerateMessage("No hay líneas seleccionadas para generar ningún proceso.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
        End Select
    End Sub

End Class