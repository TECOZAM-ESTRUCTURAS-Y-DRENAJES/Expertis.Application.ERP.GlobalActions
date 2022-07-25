Public Class clsPlanificadorRecursosOTs
    Implements Engine.IAction

    Public Class dataPlanificacion
        Public IDOT As Integer?
        Public IDOficio As String

        Public Sub New(ByVal IDOT As Integer)
            Me.IDOT = IDOT
        End Sub
    End Class

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Engine.IAction.Execute
        Dim data As New dataPlanificacion(record.Rows(0)("IDOT"))
        AbrirPlanificacion(data)
    End Sub

    Public Sub PlanificarDesdeOTLineas(ByVal data As dataPlanificacion)
        AbrirPlanificacion(data)
    End Sub

    Private Sub AbrirPlanificacion(ByVal data As dataPlanificacion)
        If ExpertisApp.IsFormOpen("PLANIFRECURSOS") Then ExpertisApp.CloseForm("PLANIFRECURSOS")
        Dim HT As New Hashtable
        HT("IDOT") = data.IDOT
        If Length(data.IDOficio) > 0 Then HT("IDOficio") = data.IDOficio

        Dim f As Planificador = ExpertisApp.OpenForm("PLANIFRECURSOS")
        f.Params = HT
    End Sub

End Class
