Public Class clsVerELM
    Implements Solmicro.Expertis.Engine.IAction

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Solmicro.Expertis.Engine.IAction.Execute
        Dim Prc As New ProcessStartInfo(ExpertisApp.Path & "\Expertis.Candy.exe")
        '1.- GUID en string de la sesión abierta en Expertis.
        Dim IDSesion As String = ExpertisApp.Token.Token.ToString
        '2.- PID en Integer del proceso Expertis iniciado.
        Dim PrcID As Integer = System.Diagnostics.Process.GetCurrentProcess.Id
        '3.- Sección a Mostrar: Ficha Articulo = 0 / Estructura = 1 / Flow Designer = 2 / Ruta = 3 / Diseñador = 4
        Select Case entityName
            Case "Articulo"
                Dim FrmOpt As New FrmSelecOpt
                If FrmOpt.ShowDialog = DialogResult.OK Then
                    Select Case FrmOpt.SelectedOpt
                        Case 0
                            'Ficha Artículo
                            Prc.Arguments = IDSesion & " " & PrcID & " 0 """ & record.Rows(0)("IDArticulo") & """"
                        Case 1
                            'Estructura Artículo
                            Prc.Arguments = IDSesion & " " & PrcID & " 1 """ & record.Rows(0)("IDArticulo") & """"
                        Case 2
                            'Ruta Artículo
                            Prc.Arguments = IDSesion & " " & PrcID & " 3 """ & record.Rows(0)("IDArticulo") & """"
                    End Select
                End If
            Case "OrdenFabricacion"
                'Flow Designer OF
                Prc.Arguments = IDSesion & " " & PrcID & " 2 """ & record.Rows(0)("IDArticulo") & """ " & """" & record.Rows(0)("IDOrden") & """"
        End Select
        System.Diagnostics.Process.Start(Prc)
    End Sub

End Class