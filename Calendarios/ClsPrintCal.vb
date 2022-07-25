Public Class ClsPrintCal
    Implements IAction

    Private MyTime As New Timer
    Private IntOpcion As Integer
    Private MPrgID As System.Guid

    Public Sub Execute(ByVal entityName As String, ByVal programID As System.Guid, ByVal record As System.Data.DataTable) Implements Engine.IAction.Execute
        Dim FrmPreview As New FrmPrintPreview
        Dim Result As DialogResult = FrmPreview.ShowDialog
        If Result = DialogResult.OK Then
            MyTime.Interval = 1000
            AddHandler MyTime.Tick, AddressOf PrintCal
            IntOpcion = FrmPreview.IntOpcion
            MPrgID = programID
            Dim FrmCal As Form = ExpertisApp.GetForm(MPrgID)
            FrmCal.WindowState = FormWindowState.Normal
            FrmCal.Width = 964 : FrmCal.Height = 639

            MyTime.Start()
        End If
    End Sub

    Private Sub PrintCal(ByVal sender As Object, ByVal e As System.EventArgs)
        MyTime.Stop()
        Dim FrmCal As Form = ExpertisApp.GetForm(MPrgID)
        Dim PrFr As New Printing.PrintForm
        If IntOpcion = 0 Then
            PrFr.PrintAction = Drawing.Printing.PrintAction.PrintToPrinter
        ElseIf IntOpcion = 1 Then
            PrFr.PrintAction = Drawing.Printing.PrintAction.PrintToPreview
        End If
        PrFr.DocumentName = "Calendario"
        PrFr.PrinterSettings.DefaultPageSettings.Landscape = True
        PrFr.Form = FrmCal
        PrFr.Print(FrmCal, Printing.PrintForm.PrintOption.CompatibleModeClientAreaOnly)
        FrmCal.WindowState = FormWindowState.Maximized
    End Sub

End Class