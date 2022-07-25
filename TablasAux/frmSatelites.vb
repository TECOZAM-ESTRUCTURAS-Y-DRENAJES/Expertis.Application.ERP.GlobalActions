Imports System.Collections.Generic

Public Class frmSatelites

#Region "Propiedades Públicas"

    Private MyDtData As New DataTable
    Public WriteOnly Property DtData() As DataTable
        Set(ByVal value As DataTable)
            MyDtData = value
        End Set
    End Property

    Private MStrEntity As String
    Public WriteOnly Property Entidad() As String
        Set(ByVal value As String)
            MStrEntity = value
        End Set
    End Property

#End Region

#Region "Variables Privadas"

    Private MyStDataSatelite As New SateliteTables.DataReturnSatTable

#End Region

#Region "Procesos / Funciones Privadas"

    Private Sub ConfigureForm()
        Dim StData As New SateliteTables.DataSatTable(MStrEntity, MyDtData)
        MyStDataSatelite = ExpertisApp.ExecuteTask(Of SateliteTables.DataSatTable, SateliteTables.DataReturnSatTable)(AddressOf SateliteTables.GetSateliteTable, StData)
        If Not MyStDataSatelite Is Nothing AndAlso Not MyStDataSatelite.DtDataSat Is Nothing Then
            AddFields()
            Me.ULblEntidad.Text = MStrEntity
            Me.ULblTablaAuxiliar.Text = MyStDataSatelite.DtDataSat.TableName
        Else
            Me.GrdSatelite.Dock = DockStyle.None
            Me.GrdSatelite.SendToBack()

            Dim LblInfo As New Engine.UI.Label
            LblInfo.Text = "No se ha encontrado información de tablas satélites relacionadas con la entidad: " & MStrEntity & "."
            LblInfo.AutoSize = False
            LblInfo.TextAlign = Drawing.ContentAlignment.MiddleCenter
            Me.FrmData.Controls.Add(LblInfo)
            LblInfo.Dock = DockStyle.Fill
            
            Me.BtnAceptar.Visible = False
            Me.BtnCancelar.Text = "Cerrar"
            Me.BtnCancelar.Location = New System.Drawing.Point(Me.BtnCancelar.Location.X, Me.BtnCancelar.Location.Y - 15)
        End If
    End Sub

    Private Sub AddFields()
        For Each Dc As DataColumn In MyStDataSatelite.DtDataSat.Columns
            Dim BlnAdd As Boolean = True
            For Each DcPK As DataColumn In MyStDataSatelite.DtDataSat.PrimaryKey
                If Dc.ColumnName = "UsuarioAudi" OrElse _
                   Dc.ColumnName = "FechaModificacionAudi" OrElse _
                   Dc.ColumnName = "FechaCreacionAudi" Then
                    BlnAdd = False
                    Exit For
                ElseIf Dc.ColumnName = DcPK.ColumnName OrElse Dc.ColumnName = "BaseDatos" OrElse Dc.ColumnName = "DescBaseDatos" Then
                    Dim ColAdd As New GridEX.GridEXColumn
                    ColAdd.Key = Dc.ColumnName
                    ColAdd.Caption = Dc.ColumnName
                    ColAdd.BoundMode = GridEX.ColumnBoundMode.Bound
                    ColAdd.DataMember = Dc.ColumnName
                    ColAdd.EditType = GridEX.EditType.NoEdit
                    If Dc.ColumnName = "BaseDatos" OrElse Dc.ColumnName = "DescBaseDatos" Then
                        ColAdd.Visible = True
                        ColAdd.CellStyle.BackColor = Drawing.Color.SkyBlue
                    Else : ColAdd.Visible = False
                    End If
                    Me.GrdSatelite.Columns.Add(ColAdd)
                    BlnAdd = False
                    Exit For
                End If
            Next
            If BlnAdd Then
                Dim ColAdd As New GridEX.GridEXColumn
                ColAdd.Key = Dc.ColumnName
                ColAdd.Caption = Dc.ColumnName
                ColAdd.BoundMode = GridEX.ColumnBoundMode.Bound
                ColAdd.DataMember = Dc.ColumnName
                ColAdd.ColumnType = GridEX.ColumnType.Text
                ColAdd.Visible = True
                If Dc.ColumnName = "BaseDatos" OrElse Dc.ColumnName = "DescBaseDatos" Then
                    ColAdd.EditType = GridEX.EditType.NoEdit
                ElseIf Dc.DataType Is System.Type.GetType("System.String") OrElse Dc.DataType Is System.Type.GetType("System.Guid") Then
                    ColAdd.EditType = GridEX.EditType.TextBox
                ElseIf Dc.DataType Is System.Type.GetType("System.DateTime") Then
                    ColAdd.EditType = GridEX.EditType.CalendarCombo
                ElseIf Dc.DataType Is System.Type.GetType("System.Int32") Then
                    ColAdd.EditType = GridEX.EditType.TextBox
                    ColAdd.FormatString = "#0"
                ElseIf Dc.DataType Is System.Type.GetType("System.Decimal") Then
                    ColAdd.EditType = GridEX.EditType.TextBox
                    ColAdd.FormatString = "#0.00"
                ElseIf Dc.DataType Is System.Type.GetType("System.Boolean") Then
                    ColAdd.EditType = GridEX.EditType.CheckBox
                    ColAdd.ColumnType = GridEX.ColumnType.CheckBox
                End If
                Me.GrdSatelite.Columns.Add(ColAdd)
            End If
        Next
        Me.GrdSatelite.DataSource = MyStDataSatelite.DtDataSat
    End Sub

    Private Function CheckSaveData() As Boolean
        Dim DtGrid As DataTable = Me.GrdSatelite.DataSource
        For Each Dr As DataRow In DtGrid.Select
            For Each Dc As DataColumn In MyStDataSatelite.DtDataSat.Columns
                If Not Dc.AllowDBNull AndAlso Length(Dr(Dc.ColumnName)) = 0 Then
                    ExpertisApp.GenerateMessage("El campo | es un dato obligatorio. Empresa: |.", MessageBoxButtons.OK, MessageBoxIcon.Error, Dc.ColumnName, Dr("BaseDatos"))
                    Return False
                End If
            Next
        Next
        Return True
    End Function

#End Region

#Region "Eventos frmSatelites"

#Region "Eventos Formulario"

    Private Sub frmSatelites_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ConfigureForm()
    End Sub

#End Region

#Region "Eventos Buttons"

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If CheckSaveData() Then
            Dim StData As New SateliteTables.DataSatTable(MStrEntity, MyStDataSatelite.DtDataSat)
            ExpertisApp.ExecuteTask(Of SateliteTables.DataSatTable)(AddressOf SateliteTables.SaveSateliteTable, StData)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

#End Region

#Region "Eventos Timer"

    Private Sub TimeClose_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

#End Region

#End Region

End Class