Public Class PanelFeatures
    Inherits DismPanelBase
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents MountedWimInfo As DismGui.MountedWimInfoComboBox
    Friend WithEvents DGFeatures As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChkPushToQueue As System.Windows.Forms.CheckBox
    Friend WithEvents BtnEnable As System.Windows.Forms.Button
    Friend WithEvents BtnDisable As System.Windows.Forms.Button
    Friend WithEvents BtnRefresh As System.Windows.Forms.Button

    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnLoadConfig()
        ChkPushToQueue.Checked = DismConfig.GetItem("FeaturesPushToQueue", False)
    End Sub

    Protected Overrides Sub OnUpdateInfo(Flags As WimInfoDetail)
        If Flags And WimInfoDetail.MountedWimInfo Then MountedWimInfo.UpdateMountedWimInfo()
        If Flags And WimInfoDetail.Feature Then MountedWimInfo.UpdateSelectedItemDetail()
    End Sub

    Private Sub InitializeComponent()

        Me.MountedWimInfo = New DismGui.MountedWimInfoComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DGFeatures = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChkPushToQueue = New System.Windows.Forms.CheckBox()
        Me.BtnEnable = New System.Windows.Forms.Button()
        Me.BtnDisable = New System.Windows.Forms.Button()
        Me.BtnRefresh = New System.Windows.Forms.Button()
        CType(Me.DGFeatures, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MountedWimInfo
        '
        Me.MountedWimInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MountedWimInfo.ItemHeightOffset = 6
        Me.MountedWimInfo.ListSelectedItemDetail = DismGui.WimInfoDetail.Feature
        Me.MountedWimInfo.Location = New System.Drawing.Point(83, 12)
        Me.MountedWimInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.MountedWimInfo.MaxDropDownItems = 4
        Me.MountedWimInfo.Name = "MountedWimInfo"
        Me.MountedWimInfo.ReadOnly = False
        Me.MountedWimInfo.SelectedIndex = -1
        Me.MountedWimInfo.Size = New System.Drawing.Size(503, 24)
        Me.MountedWimInfo.TabIndex = 0
        Me.MountedWimInfo.ToolTipTitle = "功能管理"
        Me.MountedWimInfo.WithOnlineImage = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "已安装映像："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DGFeatures
        '
        Me.DGFeatures.AllowUserToAddRows = False
        Me.DGFeatures.AllowUserToDeleteRows = False
        Me.DGFeatures.AllowUserToResizeColumns = False
        Me.DGFeatures.AllowUserToResizeRows = False
        Me.DGFeatures.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGFeatures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGFeatures.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.DGFeatures.Location = New System.Drawing.Point(13, 39)
        Me.DGFeatures.MultiSelect = False
        Me.DGFeatures.Name = "DGFeatures"
        Me.DGFeatures.ReadOnly = True
        Me.DGFeatures.RowHeadersVisible = False
        Me.DGFeatures.RowTemplate.Height = 23
        Me.DGFeatures.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGFeatures.Size = New System.Drawing.Size(572, 215)
        Me.DGFeatures.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.DataPropertyName = "FeatureName"
        Me.Column1.HeaderText = "功能名称"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "State"
        Me.Column2.HeaderText = "状态"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 70
        '
        'ChkPushToQueue
        '
        Me.ChkPushToQueue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkPushToQueue.AutoSize = True
        Me.ChkPushToQueue.Location = New System.Drawing.Point(13, 270)
        Me.ChkPushToQueue.Name = "ChkPushToQueue"
        Me.ChkPushToQueue.Size = New System.Drawing.Size(108, 16)
        Me.ChkPushToQueue.TabIndex = 2
        Me.ChkPushToQueue.Text = "添加到任务队列"
        Me.ChkPushToQueue.UseVisualStyleBackColor = True
        '
        'BtnEnable
        '
        Me.BtnEnable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEnable.Location = New System.Drawing.Point(506, 264)
        Me.BtnEnable.Name = "BtnEnable"
        Me.BtnEnable.Size = New System.Drawing.Size(80, 28)
        Me.BtnEnable.TabIndex = 5
        Me.BtnEnable.Text = "启用"
        Me.BtnEnable.UseVisualStyleBackColor = True
        '
        'BtnDisable
        '
        Me.BtnDisable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDisable.Location = New System.Drawing.Point(420, 264)
        Me.BtnDisable.Name = "BtnDisable"
        Me.BtnDisable.Size = New System.Drawing.Size(80, 28)
        Me.BtnDisable.TabIndex = 4
        Me.BtnDisable.Text = "禁用"
        Me.BtnDisable.UseVisualStyleBackColor = True
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRefresh.Location = New System.Drawing.Point(320, 264)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(80, 28)
        Me.BtnRefresh.TabIndex = 3
        Me.BtnRefresh.Text = "刷新"
        Me.BtnRefresh.UseVisualStyleBackColor = True
        '
        'PanelFeatures
        '
        Me.Controls.Add(Me.BtnRefresh)
        Me.Controls.Add(Me.ChkPushToQueue)
        Me.Controls.Add(Me.BtnEnable)
        Me.Controls.Add(Me.BtnDisable)
        Me.Controls.Add(Me.DGFeatures)
        Me.Controls.Add(Me.MountedWimInfo)
        Me.Controls.Add(Me.Label2)
        Me.Name = "PanelFeatures"
        Me.Size = New System.Drawing.Size(600, 300)
        CType(Me.DGFeatures, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Sub BtnEnable_Click(sender As Object, e As EventArgs) Handles BtnEnable.Click
        Dim f As New AddFeature
        f.Image = MountedWimInfo.Text.Trim
        If DGFeatures.SelectedRows.Count Then
            f.FeatureName = DGFeatures.SelectedRows(0).Cells(0).Value.ToString
        End If
        If f.ShowDialog = DialogResult.OK Then
            Dim Arg As New DismControlEventArgs(f.Arguments, DismMissionFlags.EnableFeature, "启用功能")
            Arg.PushToQueue = ChkPushToQueue.Checked
            OnExecute(Arg)
        End If
        f.Dispose()
        f = Nothing
    End Sub

    Private Sub BtnDisable_Click(sender As Object, e As EventArgs) Handles BtnDisable.Click

        If DGFeatures.SelectedRows.Count = 0 Then
            MsgBox("请从功能列表选择一个功能。", MsgBoxStyle.Critical, "禁用功能")
            Return
        End If



        Dim Image As String = MountedWimInfo.Text.Trim()
        Dim FeatureName As String = DGFeatures.SelectedRows(0).Cells(FindColumnIndex("FeatureName")).Value.ToString

        If MsgBox("确定要禁用功能【" & FeatureName & "】？",
                  MsgBoxStyle.Question Or
                  MsgBoxStyle.YesNo Or
                  MsgBoxStyle.DefaultButton2, Title) = MsgBoxResult.No Then Return

        Dim Arg As New DismControlEventArgs(DismShell.CreateDisableFeatureArguments(Image, FeatureName),
                                             DismMissionFlags.DisableFeature,
                                            "禁用功能")

        Arg.PushToQueue = ChkPushToQueue.Checked
        OnExecute(Arg)

    End Sub

    Private Function FindColumnIndex(DataPropertyName As String) As Integer
        For i As Integer = 0 To DGFeatures.Columns.Count - 1
            If String.Compare(DGFeatures.Columns(i).DataPropertyName, DataPropertyName) = 0 Then
                Return i
            End If
        Next
        Return -1
    End Function

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        MountedWimInfo.UpdateSelectedItemDetail()
    End Sub

    Private Sub MountedWimInfo_UpdateSelectedItemDetailProgress(sender As Object, e As UpdateProgressEventArgs) Handles MountedWimInfo.UpdateSelectedItemDetailProgress
        UpdateControlState(e.IsCompleted)
        OnUpdateProgress(e)
    End Sub

    Private Sub MountedWimInfo_SelectedItemChanged(sender As Object, e As MountedWimInfoComboBoxEventArgs) Handles MountedWimInfo.SelectedItemChanged
        DGFeatures.DataSource = e.Data
        DGFeatures.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGFeatures.Sort(DGFeatures.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
    End Sub

    Private Sub ChkPushToQueue_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPushToQueue.CheckedChanged
        DismConfig.SetItem("FeaturesPushToQueue", ChkPushToQueue.Checked)
        DismConfig.Save()
    End Sub

End Class

