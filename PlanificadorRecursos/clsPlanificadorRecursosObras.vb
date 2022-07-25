Public Class clsPlanificadorRecursosObras
    Implements Engine.IAction

    Public Class dataPlanificacion
        Public IDObra, IDTrabajo, IDTarea As Integer?
        Public IDOficio, IDOperario As String

        Public Sub New(ByVal IDObra As Integer)
            Me.IDObra = IDObra
        End Sub
    End Class

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Engine.IAction.Execute
        Dim data As New dataPlanificacion(record.Rows(0)("IDObra"))
        If record.Columns.Contains("IDTrabajo") Then data.IDTrabajo = record.Rows(0)("IDTrabajo")
        If record.Columns.Contains("IDTarea") Then data.IDTarea = record.Rows(0)("IDTarea")
        If record.Columns.Contains("IDOficio") Then data.IDOficio = record.Rows(0)("IDOficio") & String.Empty
        If record.Columns.Contains("IDOperario") Then data.IDOperario = record.Rows(0)("IDOperario") & String.Empty
        AbrirPlanificacion(Data)
    End Sub

    Public Sub PlanificarDesdeTrabajos(ByVal data As dataPlanificacion)
        AbrirPlanificacion(data)
    End Sub

    Public Sub PlanificarDesdeTrabajoOperario(ByVal data As dataPlanificacion)
        AbrirPlanificacion(data)
    End Sub

    Private Sub AbrirPlanificacion(ByVal data As dataPlanificacion)
        If ExpertisApp.IsFormOpen("PLANIFRECURSOS") Then ExpertisApp.CloseForm("PLANIFRECURSOS")
        Dim HT As New Hashtable
        HT("IDObra") = data.IDObra
        If Not data.IDTrabajo Is Nothing Then HT("IDTrabajo") = data.IDTrabajo
        If Not data.IDTarea Is Nothing Then HT("IDTarea") = data.IDTarea
        If Length(data.IDOficio) > 0 Then HT("IDOficio") = data.IDOficio
        If Length(data.IDOperario) > 0 Then HT("IDOperario") = data.IDOperario

        Dim f As Planificador = ExpertisApp.OpenForm("PLANIFRECURSOS")
        f.Params = HT
    End Sub

End Class
