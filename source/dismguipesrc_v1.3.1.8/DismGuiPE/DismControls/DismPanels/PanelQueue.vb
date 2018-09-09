Imports System.Runtime.Serialization.Formatters.Binary
Public Class PanelQueue
    Inherits DismPanelBase
    Friend WithEvents BtnExecute As System.Windows.Forms.Button
    Friend WithEvents BtnClean As System.Windows.Forms.Button
    Friend WithEvents BtnMoveToBottom As System.Windows.Forms.Button
    Friend WithEvents BtnMoveDown As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnMoveUp As System.Windows.Forms.Button
    Friend WithEvents BtnMoveToTop As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BtnLoad As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents DGQueue As System.Windows.Forms.DataGridView

    Private ToFirst As Bitmap = My.Resources.ToFirst
    Private ToPrev As Bitmap = My.Resources.ToPrev
    Private ToNext As Bitmap = My.Resources.ToNext
    Private ToEnd As Bitmap = My.Resources.ToEnd

    Public Sub New()
        InitializeComponent()
        ToFirst.MakeTransparent(Color.White)
        ToPrev.MakeTransparent(Color.White)
        ToNext.MakeTransparent(Color.White)
        ToEnd.MakeTransparent(Color.White)
        BtnMoveToTop.Image = ToFirst
        BtnMoveUp.Image = ToPrev
        BtnMoveDown.Image = ToNext
        BtnMoveToBottom.Image = ToEnd
    End Sub

    Protected Overrides Sub OnUpdateInfo(Flags As WimInfoDetail)
        If InvokeRequired Then
            Invoke(New EventHandler(AddressOf _OnUpdateInfo), Nothing, Nothing)
        Else
            _OnUpdateInfo(Nothing, Nothing)
        End If
    End Sub

    Private Sub CheckMoveButtonState()
        Dim Index As Integer = -1
        If DGQueue.SelectedRows.Count Then Index = DGQueue.SelectedRows(0).Index
        BtnMoveToTop.Enabled = Index > 0
        BtnMoveUp.Enabled = Index > 0
        BtnMoveDown.Enabled = (Index < DGQueue.Rows.Count - 1) And (Not Index = -1)
        BtnMoveToBottom.Enabled = (Index < DGQueue.Rows.Count - 1) And (Not Index = -1)
    End Sub

    Private Sub BtnMoveToTop_Click(sender As Object, e As EventArgs) Handles BtnMoveToTop.Click
        If DGQueue.SelectedRows.Count = 0 Then Return
        Dim Index As Integer = DGQueue.SelectedRows(0).Index
        Main.DismQueue.MoveToTop(Index)
        OnUpdateInfo(WimInfoDetail.None)
        DGQueue.Rows(0).Selected = True
        CheckMoveButtonState()
    End Sub

    Private Sub BtnMoveUp_Click(sender As Object, e As EventArgs) Handles BtnMoveUp.Click
        If DGQueue.SelectedRows.Count = 0 Then Return
        Dim Index As Integer = DGQueue.SelectedRows(0).Index
        Main.DismQueue.Swap(Index - 1, Index)
        OnUpdateInfo(WimInfoDetail.None)
        DGQueue.Rows(Index - 1).Selected = True
        CheckMoveButtonState()
    End Sub

    Private Sub BtnMoveDown_Click(sender As Object, e As EventArgs) Handles BtnMoveDown.Click
        If DGQueue.SelectedRows.Count = 0 Then Return
        Dim Index As Integer = DGQueue.SelectedRows(0).Index
        Main.DismQueue.Swap(Index + 1, Index)
        OnUpdateInfo(WimInfoDetail.None)
        DGQueue.Rows(Index + 1).Selected = True
        CheckMoveButtonState()
    End Sub

    Private Sub BtnMoveToBottom_Click(sender As Object, e As EventArgs) Handles BtnMoveToBottom.Click
        If DGQueue.SelectedRows.Count = 0 Then Return
        Dim Index As Integer = DGQueue.SelectedRows(0).Index
        Main.DismQueue.MoveToBottom(Index)
        OnUpdateInfo(WimInfoDetail.None)
        DGQueue.Rows(DGQueue.Rows.Count - 1).Selected = True
        CheckMoveButtonState()
    End Sub

    Private Sub BtnClean_Click(sender As Object, e As EventArgs) Handles BtnClean.Click
        Main.DismQueue.Clear()
        OnUpdateInfo(WimInfoDetail.None)
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If DGQueue.SelectedRows.Count = 0 Then Return
        Dim Index As Integer = DGQueue.SelectedRows(0).Index
        Main.DismQueue.RemoveAt(Index)
        OnUpdateInfo(WimInfoDetail.None)
    End Sub

    Private Sub BtnExecute_Click(sender As Object, e As EventArgs) Handles BtnExecute.Click
        OnExecute(New DismControlEventArgs() With {.Mission = DismMissionFlags.RunQueue})
    End Sub

    Private Sub DGQueue_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DGQueue.RowEnter
        CheckMoveButtonState()
    End Sub

    Private Sub BtnLoad_Click(sender As Object, e As EventArgs) Handles BtnLoad.Click
        Dim cd As New OpenFileDialog()
        cd.Multiselect = False
        cd.Filter = "任务队列文件(*.Queue)|*.Queue"
        cd.Title = "请选择一个任务队列文件..."
        If cd.ShowDialog = DialogResult.OK Then
            Dim Temp As DismQueueManager = LoadQueue(cd.FileName)
            If Not IsNothing(Temp) Then
                Main.DismQueue = Temp
                UpdateInfo(WimInfoDetail.None)
            End If
        End If
        cd.Dispose()
        cd = Nothing
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim cd As New SaveFileDialog()
        cd.Filter = "任务队列文件(*.Queue)|*.Queue"
        cd.Title = "另存为任务队列文件..."
        cd.FileName = Now.ToString("yyyyMMddHHmmss") & "Task"
        If cd.ShowDialog = DialogResult.OK Then
            SaveQueue(cd.FileName, Main.DismQueue)
        End If
        cd.Dispose()
        cd = Nothing
    End Sub

    Private Function LoadQueue(Path As String) As DismQueueManager
        If Not IO.File.Exists(Path) Then Return Nothing
        Dim bf As New BinaryFormatter
        Dim fs As New IO.FileStream(Path, IO.FileMode.Open)
        Dim dqmgr As DismQueueManager = Nothing
        Try
            dqmgr = bf.Deserialize(fs)
        Catch ex As Exception

        End Try
        fs.Close()
        Return dqmgr
    End Function

    Private Sub SaveQueue(Path As String, Mgr As DismQueueManager)
        If IO.File.Exists(Path) Then IO.File.Delete(Path)
        Dim bf As New BinaryFormatter
        Dim fs As New IO.FileStream(Path, IO.FileMode.OpenOrCreate)
        bf.Serialize(fs, Mgr)
        fs.Flush()
        fs.Close()
    End Sub

    Private Sub _OnUpdateInfo(sender As Object, e As EventArgs)
        Main.DismQueue.FillDataGridView(DGQueue)
        CheckMoveButtonState()
    End Sub

    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BtnMoveToTop = New System.Windows.Forms.Button()
        Me.BtnMoveUp = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnMoveDown = New System.Windows.Forms.Button()
        Me.BtnMoveToBottom = New System.Windows.Forms.Button()
        Me.BtnClean = New System.Windows.Forms.Button()
        Me.BtnExecute = New System.Windows.Forms.Button()
        Me.DGQueue = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnLoad = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        CType(Me.DGQueue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnMoveToTop
        '
        Me.BtnMoveToTop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMoveToTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnMoveToTop.Enabled = False
        Me.BtnMoveToTop.Location = New System.Drawing.Point(373, 264)
        Me.BtnMoveToTop.Name = "BtnMoveToTop"
        Me.BtnMoveToTop.Size = New System.Drawing.Size(28, 28)
        Me.BtnMoveToTop.TabIndex = 3
        Me.BtnMoveToTop.UseVisualStyleBackColor = True
        '
        'BtnMoveUp
        '
        Me.BtnMoveUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMoveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnMoveUp.Enabled = False
        Me.BtnMoveUp.Location = New System.Drawing.Point(403, 264)
        Me.BtnMoveUp.Name = "BtnMoveUp"
        Me.BtnMoveUp.Size = New System.Drawing.Size(28, 28)
        Me.BtnMoveUp.TabIndex = 4
        Me.BtnMoveUp.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnDelete.Location = New System.Drawing.Point(79, 264)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(60, 28)
        Me.BtnDelete.TabIndex = 2
        Me.BtnDelete.Text = "删除"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'BtnMoveDown
        '
        Me.BtnMoveDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMoveDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnMoveDown.Enabled = False
        Me.BtnMoveDown.Location = New System.Drawing.Point(433, 264)
        Me.BtnMoveDown.Name = "BtnMoveDown"
        Me.BtnMoveDown.Size = New System.Drawing.Size(28, 28)
        Me.BtnMoveDown.TabIndex = 5
        Me.BtnMoveDown.UseVisualStyleBackColor = True
        '
        'BtnMoveToBottom
        '
        Me.BtnMoveToBottom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMoveToBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnMoveToBottom.Enabled = False
        Me.BtnMoveToBottom.Location = New System.Drawing.Point(463, 264)
        Me.BtnMoveToBottom.Name = "BtnMoveToBottom"
        Me.BtnMoveToBottom.Size = New System.Drawing.Size(28, 28)
        Me.BtnMoveToBottom.TabIndex = 6
        Me.BtnMoveToBottom.UseVisualStyleBackColor = True
        '
        'BtnClean
        '
        Me.BtnClean.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnClean.Location = New System.Drawing.Point(13, 264)
        Me.BtnClean.Name = "BtnClean"
        Me.BtnClean.Size = New System.Drawing.Size(60, 28)
        Me.BtnClean.TabIndex = 1
        Me.BtnClean.Text = "清空"
        Me.BtnClean.UseVisualStyleBackColor = True
        '
        'BtnExecute
        '
        Me.BtnExecute.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExecute.Location = New System.Drawing.Point(506, 264)
        Me.BtnExecute.Name = "BtnExecute"
        Me.BtnExecute.Size = New System.Drawing.Size(80, 28)
        Me.BtnExecute.TabIndex = 7
        Me.BtnExecute.Text = "执行"
        Me.BtnExecute.UseVisualStyleBackColor = True
        '
        'DGQueue
        '
        Me.DGQueue.AllowUserToAddRows = False
        Me.DGQueue.AllowUserToDeleteRows = False
        Me.DGQueue.AllowUserToResizeColumns = False
        Me.DGQueue.AllowUserToResizeRows = False
        Me.DGQueue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGQueue.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.DGQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGQueue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column3, Me.Column2, Me.Column4, Me.Column5})
        Me.DGQueue.Location = New System.Drawing.Point(13, 16)
        Me.DGQueue.MultiSelect = False
        Me.DGQueue.Name = "DGQueue"
        Me.DGQueue.ReadOnly = True
        Me.DGQueue.RowHeadersWidth = 21
        Me.DGQueue.RowTemplate.Height = 23
        Me.DGQueue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGQueue.Size = New System.Drawing.Size(572, 242)
        Me.DGQueue.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "创建时间"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 120
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "执行命令"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.Width = 59
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "命令描述"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column2.Width = 59
        '
        'Column4
        '
        Me.Column4.HeaderText = "拦截信息"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column4.Width = 70
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column5.HeaderText = "执行参数"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'BtnLoad
        '
        Me.BtnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnLoad.Location = New System.Drawing.Point(164, 264)
        Me.BtnLoad.Name = "BtnLoad"
        Me.BtnLoad.Size = New System.Drawing.Size(60, 28)
        Me.BtnLoad.TabIndex = 8
        Me.BtnLoad.Text = "加载"
        Me.BtnLoad.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.Location = New System.Drawing.Point(230, 264)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(60, 28)
        Me.BtnSave.TabIndex = 9
        Me.BtnSave.Text = "保存"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'PanelQueue
        '
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnLoad)
        Me.Controls.Add(Me.BtnMoveToTop)
        Me.Controls.Add(Me.BtnMoveUp)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnMoveDown)
        Me.Controls.Add(Me.BtnMoveToBottom)
        Me.Controls.Add(Me.BtnClean)
        Me.Controls.Add(Me.BtnExecute)
        Me.Controls.Add(Me.DGQueue)
        Me.Name = "PanelQueue"
        Me.Size = New System.Drawing.Size(600, 300)
        CType(Me.DGQueue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub


End Class
