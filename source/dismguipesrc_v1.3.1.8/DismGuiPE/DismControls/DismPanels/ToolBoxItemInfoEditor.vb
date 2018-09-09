Public Class ToolBoxItemInfoEditor
    Public Property PathConfigAll As String = ""
    Public Property PathConfigEnvironment As String = ""

    Private Sub ToolBoxItemInfoEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadItems()
    End Sub

    Private Sub LoadItems()
        DG.Rows.Clear()
        LoadConfig(Me.PathConfigAll, True)
        LoadConfig(Me.PathConfigEnvironment)
    End Sub

    Private Sub LoadConfig(Path As String, Optional IsPublic As Boolean = False)
        Dim Doc As XElement = XElement.Load(Path)
        Dim IsVisible As Boolean = False
        Dim xa As XAttribute = Nothing
        Dim ID As String = ""
        Dim DisplayName As String = ""
        Dim Index As Integer = 0
        For Each e As XElement In Doc.Elements("Item")
            xa = e.Attribute("ID")
            If IsNothing(xa) Then
                ID = "Unknow"
            Else
                ID = xa.Value
            End If
            xa = e.Attribute("Visible")
            If IsNothing(xa) Then
                IsVisible = False
            Else
                Boolean.TryParse(xa.Value, IsVisible)
            End If
            DisplayName = e.Value
            Index = DG.Rows.Add(ID, DisplayName, IsVisible, IsPublic)
            DG.Rows(Index).Cells(1).ReadOnly = False
            DG.Rows(Index).Cells(2).ReadOnly = False
        Next
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        LoadItems()
    End Sub

    Private Sub DG_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DG.CellEnter
        If e.RowIndex >= 0 And e.ColumnIndex = 1 Then
            DG.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag = DG.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString
            DG.BeginEdit(True)
        End If
    End Sub

    Private Sub DG_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles DG.CellValidated
        If e.RowIndex >= 0 And e.ColumnIndex = 1 Then
            Dim Temp As String = DG.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            If IsNothing(Temp) OrElse Temp = "" Then DG.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = DG.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag.ToString
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If DG.SelectedCells.Count = 0 Then
            MsgBox("请选择一个应用！", MsgBoxStyle.Critical, Me.Text)
            Return
        End If
        Dim RowIndex As Integer = DG.SelectedCells(0).RowIndex
        If RowIndex = -1 Then
            MsgBox("请选择一个应用！", MsgBoxStyle.Critical, Me.Text)
            Return
        End If
        DG.Rows.RemoveAt(RowIndex)
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        DG.Rows.Clear()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        DG.EndEdit()
        Dim ConfigAll As XElement = <Config/>
        Dim ConfigEnvironment As XElement = <Config/>
        Dim ID As String = ""
        Dim IsVisible As Boolean = False
        Dim IsPublic As Boolean = False
        Dim DisplayName As String = ""
        Dim x As XElement = Nothing
        For Each Row As DataGridViewRow In DG.Rows
            ID = Row.Cells(0).Value
            DisplayName = Row.Cells(1).Value
            If IsNothing(DisplayName) Then
                MsgBox("显示名称不能为空！", MsgBoxStyle.Critical, Me.Text)
                Return
            End If
            IsVisible = Row.Cells(2).Value
            IsPublic = Row.Cells(3).Value
            x = <Item ID=<%= ID %> Visible=<%= IsVisible.ToString %>/>
            x.Value = DisplayName
            If IsPublic Then
                ConfigAll.Add(x)
            Else
                ConfigEnvironment.Add(x)
            End If
        Next
        ConfigAll.Save(PathConfigAll)
        ConfigEnvironment.Save(PathConfigEnvironment)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class