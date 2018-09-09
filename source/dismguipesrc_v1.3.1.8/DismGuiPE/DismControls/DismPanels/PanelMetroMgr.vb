Public Class PanelMetroMgr
    Inherits DismPanelBase
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents ChkPushToQueue As System.Windows.Forms.CheckBox
    Friend WithEvents BtnRefresh As System.Windows.Forms.Button
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents MountedWimInfo As DismGuiPE.MountedWimInfoComboBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGMetroApps As System.Windows.Forms.DataGridView

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.DGMetroApps = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MountedWimInfo = New DismGuiPE.MountedWimInfoComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnRefresh = New System.Windows.Forms.Button()
        Me.ChkPushToQueue = New System.Windows.Forms.CheckBox()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnAdd = New System.Windows.Forms.Button()
        CType(Me.DGMetroApps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGMetroApps
        '
        Me.DGMetroApps.AllowUserToAddRows = False
        Me.DGMetroApps.AllowUserToDeleteRows = False
        Me.DGMetroApps.AllowUserToResizeColumns = False
        Me.DGMetroApps.AllowUserToResizeRows = False
        Me.DGMetroApps.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGMetroApps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGMetroApps.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.DGMetroApps.Location = New System.Drawing.Point(14, 37)
        Me.DGMetroApps.MultiSelect = False
        Me.DGMetroApps.Name = "DGMetroApps"
        Me.DGMetroApps.ReadOnly = True
        Me.DGMetroApps.RowHeadersVisible = False
        Me.DGMetroApps.RowTemplate.Height = 23
        Me.DGMetroApps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGMetroApps.Size = New System.Drawing.Size(572, 215)
        Me.DGMetroApps.TabIndex = 10
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.DataPropertyName = "DisplayName"
        Me.Column1.HeaderText = "显示名称"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 78
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.DataPropertyName = "PackageName"
        Me.Column2.HeaderText = "应用名称"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.DataPropertyName = "Version"
        Me.Column3.HeaderText = "版本"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 54
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.DataPropertyName = "Architecture"
        Me.Column4.HeaderText = "体系结构"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 78
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "ResourceId"
        Me.Column5.HeaderText = "资源 ID"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        '
        'MountedWimInfo
        '
        Me.MountedWimInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MountedWimInfo.ItemHeightOffset = 6
        Me.MountedWimInfo.ListSelectedItemDetail = DismGuiPE.WimInfoDetail.MetroApps
        Me.MountedWimInfo.Location = New System.Drawing.Point(84, 10)
        Me.MountedWimInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.MountedWimInfo.MaxDropDownItems = 4
        Me.MountedWimInfo.Name = "MountedWimInfo"
        Me.MountedWimInfo.ReadOnly = False
        Me.MountedWimInfo.SelectedIndex = -1
        Me.MountedWimInfo.Size = New System.Drawing.Size(503, 24)
        Me.MountedWimInfo.TabIndex = 9
        Me.MountedWimInfo.ToolTipTitle = "Metro应用管理"
        Me.MountedWimInfo.WithOnlineImage = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(14, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "已安装映像："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRefresh.Location = New System.Drawing.Point(321, 262)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(80, 28)
        Me.BtnRefresh.TabIndex = 12
        Me.BtnRefresh.Text = "刷新"
        Me.BtnRefresh.UseVisualStyleBackColor = True
        '
        'ChkPushToQueue
        '
        Me.ChkPushToQueue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkPushToQueue.AutoSize = True
        Me.ChkPushToQueue.Location = New System.Drawing.Point(14, 268)
        Me.ChkPushToQueue.Name = "ChkPushToQueue"
        Me.ChkPushToQueue.Size = New System.Drawing.Size(108, 16)
        Me.ChkPushToQueue.TabIndex = 11
        Me.ChkPushToQueue.Text = "添加到任务队列"
        Me.ChkPushToQueue.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelete.Location = New System.Drawing.Point(421, 261)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(80, 28)
        Me.BtnDelete.TabIndex = 14
        Me.BtnDelete.Text = "删除"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAdd.Location = New System.Drawing.Point(507, 261)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(80, 28)
        Me.BtnAdd.TabIndex = 13
        Me.BtnAdd.Text = "添加"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'PanelMetroMgr
        '
        Me.Controls.Add(Me.DGMetroApps)
        Me.Controls.Add(Me.MountedWimInfo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnRefresh)
        Me.Controls.Add(Me.ChkPushToQueue)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnAdd)
        Me.Name = "PanelMetroMgr"
        Me.Size = New System.Drawing.Size(600, 300)
        CType(Me.DGMetroApps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Protected Overrides Sub OnUpdateInfo(Flags As WimInfoDetail)
        If Flags And WimInfoDetail.MountedWimInfo Then MountedWimInfo.UpdateMountedWimInfo()
        If Flags And WimInfoDetail.MetroApps Then MountedWimInfo.UpdateSelectedItemDetail()
    End Sub

    Private Sub MountedWimInfo_UpdateSelectedItemDetailProgress(sender As Object, e As UpdateProgressEventArgs) Handles MountedWimInfo.UpdateSelectedItemDetailProgress
        UpdateControlState(e.IsCompleted)
        OnUpdateProgress(e)
    End Sub

    Private Sub MountedWimInfo_SelectedItemChanged(sender As Object, e As MountedWimInfoComboBoxEventArgs) Handles MountedWimInfo.SelectedItemChanged
        DGMetroApps.DataSource = e.Data

        DGMetroApps.Sort(DGMetroApps.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        MountedWimInfo.UpdateSelectedItemDetail()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        '
        Dim f As New AddMetroApp()
        f.Image = MountedWimInfo.Text.Trim
        If f.ShowDialog = DialogResult.OK Then
            Dim Args As DismControlEventArgs = f.Arguments
            Args.PushToQueue = ChkPushToQueue.Checked
            OnExecute(Args)
        End If
        f.Dispose()
        f = Nothing
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        '
        If DGMetroApps.SelectedRows.Count = 0 Then
            MsgBox("请从应用列表选择一个应用。", MsgBoxStyle.Critical, "删除Metro应用")
            Return
        End If

        Dim Image As String = MountedWimInfo.Text.Trim()
        Dim PackageName As String = DGMetroApps.SelectedRows(0).Cells(FindColumnIndex("PackageName")).Value.ToString

        If MsgBox("确定要删除应用【" & PackageName & "】？",
                  MsgBoxStyle.Question Or
                  MsgBoxStyle.YesNo Or
                  MsgBoxStyle.DefaultButton2, Title) = MsgBoxResult.No Then Return

        Dim Args As New DismControlEventArgs
        Args.Arguments = DismShell.CreateRemoveMetroPackage(Image, PackageName)
        Args.Mission = DismMissionFlags.RemoveProvisionedAppxPackage
        Args.Description = "删除Metro应用"
        Args.PushToQueue = ChkPushToQueue.Checked

        OnExecute(Args)

    End Sub

    Private Function FindColumnIndex(DataPropertyName As String) As Integer
        For i As Integer = 0 To DGMetroApps.Columns.Count - 1
            If String.Compare(DGMetroApps.Columns(i).DataPropertyName, DataPropertyName) = 0 Then
                Return i
            End If
        Next
        Return -1
    End Function
End Class
