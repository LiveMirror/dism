Public Class PanelPackages
    Inherits DismPanelBase
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents MountedWimInfo As DismGuiPE.MountedWimInfoComboBox
    Private WithEvents DGPackages As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FSPackagePath As DismGuiPE.FileOrFolderSelector
    Friend WithEvents BtnRefresh As System.Windows.Forms.Button
    Friend WithEvents ChkPushToQueue As System.Windows.Forms.CheckBox
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents TT As System.Windows.Forms.ToolTip
    Private components As System.ComponentModel.IContainer
    Private WithEvents ChkPreventPending As System.Windows.Forms.CheckBox
    Private WithEvents ChkIgnoreCheck As System.Windows.Forms.CheckBox

    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnLoadConfig()
        FSPackagePath.Text = DismConfig.GetItem("PackagesPackagePath", "")
        ChkPushToQueue.Checked = DismConfig.GetItem("PackagesPushToQueue", False)
    End Sub

    Protected Overrides Sub OnUpdateInfo(Flags As WimInfoDetail)
        If Flags And WimInfoDetail.MountedWimInfo Then MountedWimInfo.UpdateMountedWimInfo()
        If Flags And WimInfoDetail.Package Then MountedWimInfo.UpdateSelectedItemDetail()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        MountedWimInfo.UpdateSelectedItemDetail()
    End Sub

    Private Sub MountedWimInfo_UpdateSelectedItemDetailProgress(sender As Object, e As UpdateProgressEventArgs) Handles MountedWimInfo.UpdateSelectedItemDetailProgress
        UpdateControlState(e.IsCompleted)
        OnUpdateProgress(e)
    End Sub

    Private Sub MountedWimInfo_SelectedItemChanged(sender As Object, e As MountedWimInfoComboBoxEventArgs) Handles MountedWimInfo.SelectedItemChanged
        DGPackages.DataSource = e.Data
        If DGPackages.ColumnCount Then
            DGPackages.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            For i As Integer = 1 To DGPackages.ColumnCount - 1
                DGPackages.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next
            DGPackages.Sort(DGPackages.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If DGPackages.Rows.Count = 0 Then Return

        If DGPackages.SelectedRows.Count = 0 Then
            MsgBox("请选择一个程序包！", MsgBoxStyle.Critical, Title)
            DGPackages.Select()
            Return
        End If

        Dim PackageIdentity As String = DGPackages.SelectedRows(0).Cells(FindColumnIndex("PackageIdentity")).Value.ToString

        If MsgBox("确定要删除该程序包【" & PackageIdentity & "】？",
           MsgBoxStyle.Question Or
           MsgBoxStyle.YesNo Or
           MsgBoxStyle.DefaultButton2, Title) = MsgBoxResult.No Then Return

        Dim Image As String = MountedWimInfo.Text.Trim()
        Dim Args As New DismControlEventArgs(DismShell.CreateRemovePackageArguments(Image, PackageIdentity),
                                             DismMissionFlags.RemovePackage,
                                             "删除程序包")
        Args.PushToQueue = ChkPushToQueue.Checked
        OnExecute(Args)
    End Sub

    Private Function FindColumnIndex(DataPropertyName As String) As Integer
        For i As Integer = 0 To DGPackages.Columns.Count - 1
            If String.Compare(DGPackages.Columns(i).DataPropertyName, DataPropertyName) = 0 Then
                Return i
            End If
        Next
        Return -1
    End Function

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click

        Dim PackagePath As String = FSPackagePath.Text.Trim()
        If PackagePath = "" OrElse Not (IO.File.Exists(PackagePath) Or IO.Directory.Exists(PackagePath)) Then
            MsgBox("请选择一个程序包或者所在目录！", MsgBoxStyle.Critical, Title)
            FSPackagePath.Select()
            Return
        End If

        Dim Image As String = MountedWimInfo.Text.Trim

        Dim Args As New DismControlEventArgs(DismShell.CreateAddPackageArguments(Image,
                                                                                PackagePath,
                                                                                ChkIgnoreCheck.Checked,
                                                                                ChkPreventPending.Checked),
                                             DismMissionFlags.AddPackage,
                                             "添加程序包")
        Args.PushToQueue = ChkPushToQueue.Checked

        DismConfig.SetItem("PackagePath", PackagePath)
        DismConfig.Save()

        OnExecute(Args)

    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MountedWimInfo = New DismGuiPE.MountedWimInfoComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DGPackages = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FSPackagePath = New DismGuiPE.FileOrFolderSelector()
        Me.BtnRefresh = New System.Windows.Forms.Button()
        Me.ChkPushToQueue = New System.Windows.Forms.CheckBox()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.TT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ChkPreventPending = New System.Windows.Forms.CheckBox()
        Me.ChkIgnoreCheck = New System.Windows.Forms.CheckBox()
        CType(Me.DGPackages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MountedWimInfo
        '
        Me.MountedWimInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MountedWimInfo.ItemHeightOffset = 6
        Me.MountedWimInfo.ListSelectedItemDetail = DismGuiPE.WimInfoDetail.Package
        Me.MountedWimInfo.Location = New System.Drawing.Point(82, 12)
        Me.MountedWimInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.MountedWimInfo.MaxDropDownItems = 4
        Me.MountedWimInfo.Name = "MountedWimInfo"
        Me.MountedWimInfo.ReadOnly = False
        Me.MountedWimInfo.SelectedIndex = -1
        Me.MountedWimInfo.Size = New System.Drawing.Size(504, 24)
        Me.MountedWimInfo.TabIndex = 0
        Me.MountedWimInfo.ToolTipTitle = "程序包管理"
        Me.MountedWimInfo.WithOnlineImage = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "已安装映像："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DGPackages
        '
        Me.DGPackages.AllowUserToAddRows = False
        Me.DGPackages.AllowUserToDeleteRows = False
        Me.DGPackages.AllowUserToOrderColumns = True
        Me.DGPackages.AllowUserToResizeColumns = False
        Me.DGPackages.AllowUserToResizeRows = False
        Me.DGPackages.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGPackages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGPackages.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.DGPackages.Location = New System.Drawing.Point(14, 39)
        Me.DGPackages.MultiSelect = False
        Me.DGPackages.Name = "DGPackages"
        Me.DGPackages.ReadOnly = True
        Me.DGPackages.RowHeadersVisible = False
        Me.DGPackages.RowTemplate.Height = 23
        Me.DGPackages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGPackages.Size = New System.Drawing.Size(571, 185)
        Me.DGPackages.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.DataPropertyName = "PackageIdentity"
        Me.Column1.HeaderText = "程序包标识符"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.DataPropertyName = "State"
        Me.Column2.HeaderText = "状态"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 51
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.DataPropertyName = "ReleaseType"
        Me.Column3.HeaderText = "发行类型"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 61
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.DataPropertyName = "InstallTime"
        Me.Column4.HeaderText = "安装时间"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 61
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(13, 234)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 17)
        Me.Label1.TabIndex = 90
        Me.Label1.Text = "程序包文件："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FSPackagePath
        '
        Me.FSPackagePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FSPackagePath.BrowserStyle = DismGuiPE.FileOrFolderBrowserStyle.FileOrFolderOpen
        Me.FSPackagePath.CheckFileExists = True
        Me.FSPackagePath.CheckPathExists = True
        Me.FSPackagePath.Filter = """程序包文件(*.CAB,*.MSU)|*.CAB;*.MSU|所有文件(*.*)|*.*"""
        Me.FSPackagePath.Location = New System.Drawing.Point(94, 230)
        Me.FSPackagePath.Multiselect = False
        Me.FSPackagePath.Name = "FSPackagePath"
        Me.FSPackagePath.OverwritePrompt = True
        Me.FSPackagePath.ReadOnly = False
        Me.FSPackagePath.Size = New System.Drawing.Size(491, 24)
        Me.FSPackagePath.TabIndex = 2
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRefresh.Location = New System.Drawing.Point(320, 264)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(80, 28)
        Me.BtnRefresh.TabIndex = 6
        Me.BtnRefresh.Text = "刷新"
        Me.BtnRefresh.UseVisualStyleBackColor = True
        '
        'ChkPushToQueue
        '
        Me.ChkPushToQueue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkPushToQueue.AutoSize = True
        Me.ChkPushToQueue.Location = New System.Drawing.Point(13, 270)
        Me.ChkPushToQueue.Name = "ChkPushToQueue"
        Me.ChkPushToQueue.Size = New System.Drawing.Size(108, 16)
        Me.ChkPushToQueue.TabIndex = 3
        Me.ChkPushToQueue.Text = "添加到任务队列"
        Me.ChkPushToQueue.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAdd.Location = New System.Drawing.Point(506, 264)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(80, 28)
        Me.BtnAdd.TabIndex = 8
        Me.BtnAdd.Text = "添加"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelete.Location = New System.Drawing.Point(420, 264)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(80, 28)
        Me.BtnDelete.TabIndex = 7
        Me.BtnDelete.Text = "删除"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'TT
        '
        Me.TT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TT.ToolTipTitle = "程序包管理"
        '
        'ChkPreventPending
        '
        Me.ChkPreventPending.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkPreventPending.AutoSize = True
        Me.ChkPreventPending.Location = New System.Drawing.Point(200, 277)
        Me.ChkPreventPending.Name = "ChkPreventPending"
        Me.ChkPreventPending.Size = New System.Drawing.Size(114, 16)
        Me.ChkPreventPending.TabIndex = 5
        Me.ChkPreventPending.Text = "/PreventPending"
        Me.TT.SetToolTip(Me.ChkPreventPending, "如果程序包或 Windows 映像具有挂起的联机操作，跳过程序包安装。")
        Me.ChkPreventPending.UseVisualStyleBackColor = True
        '
        'ChkIgnoreCheck
        '
        Me.ChkIgnoreCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkIgnoreCheck.AutoSize = True
        Me.ChkIgnoreCheck.Location = New System.Drawing.Point(200, 260)
        Me.ChkIgnoreCheck.Name = "ChkIgnoreCheck"
        Me.ChkIgnoreCheck.Size = New System.Drawing.Size(96, 16)
        Me.ChkIgnoreCheck.TabIndex = 4
        Me.ChkIgnoreCheck.Text = "/IgnoreCheck"
        Me.TT.SetToolTip(Me.ChkIgnoreCheck, "如果适用性检查失败，跳过程序包安装。")
        Me.ChkIgnoreCheck.UseVisualStyleBackColor = True
        '
        'PanelPackages
        '
        Me.Controls.Add(Me.ChkPreventPending)
        Me.Controls.Add(Me.ChkIgnoreCheck)
        Me.Controls.Add(Me.BtnRefresh)
        Me.Controls.Add(Me.ChkPushToQueue)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.FSPackagePath)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGPackages)
        Me.Controls.Add(Me.MountedWimInfo)
        Me.Controls.Add(Me.Label2)
        Me.Name = "PanelPackages"
        Me.Size = New System.Drawing.Size(600, 300)
        CType(Me.DGPackages, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Sub ChkPushToQueue_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPushToQueue.CheckedChanged
        DismConfig.SetItem("PackagesPushToQueue", ChkPushToQueue.Checked)
        DismConfig.Save()
    End Sub

End Class
