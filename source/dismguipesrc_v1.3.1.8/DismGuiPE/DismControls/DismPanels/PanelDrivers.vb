Public Class PanelDrivers
    Inherits DismPanelBase
    Private WithEvents DGDrivers As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents ChkForceUnsigned As System.Windows.Forms.CheckBox
    Private WithEvents ChkRecurse As System.Windows.Forms.CheckBox
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private components As System.ComponentModel.IContainer
    Friend WithEvents TT As System.Windows.Forms.ToolTip
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FSPackagePath As DismGuiPE.FileOrFolderSelector
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents ChkPushToQueue As System.Windows.Forms.CheckBox
    Friend WithEvents BtnRefresh As System.Windows.Forms.Button
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents MountedWimInfo As DismGuiPE.MountedWimInfoComboBox


    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnLoadConfig()
        FSPackagePath.Text = DismConfig.GetItem("DriversPackagePath", "")
        ChkPushToQueue.Checked = DismConfig.GetItem("DriversPushToQueue", False)
    End Sub

    Protected Overrides Sub OnUpdateInfo(Flags As WimInfoDetail)
        If Flags And WimInfoDetail.MountedWimInfo Then MountedWimInfo.UpdateMountedWimInfo()
        If Flags And WimInfoDetail.Driver Then MountedWimInfo.UpdateSelectedItemDetail()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        MountedWimInfo.UpdateSelectedItemDetail()
    End Sub

    Private Sub MountedWimInfo_UpdateSelectedItemDetailProgress(sender As Object, e As UpdateProgressEventArgs) Handles MountedWimInfo.UpdateSelectedItemDetailProgress
        UpdateControlState(e.IsCompleted)
        OnUpdateProgress(e)
    End Sub

    Private Sub MountedWimInfo_SelectedItemChanged(sender As Object, e As MountedWimInfoComboBoxEventArgs) Handles MountedWimInfo.SelectedItemChanged
        DGDrivers.DataSource = e.Data
        If DGDrivers.ColumnCount Then
            For i As Integer = 0 To DGDrivers.ColumnCount - 1
                DGDrivers.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next
            DGDrivers.Sort(DGDrivers.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If DGDrivers.Rows.Count = 0 Then Return

        If DGDrivers.SelectedRows.Count = 0 Then
            MsgBox("请选择一个驱动！", MsgBoxStyle.Critical, Title)
            DGDrivers.Select()
            Return
        End If

        'PublishedName
        Dim DriveName As String = DGDrivers.SelectedRows(0).Cells(FindColumnIndex("PublishedName")).Value

        If MsgBox("确定要删除驱动【" & DriveName & "】？",
           MsgBoxStyle.Question Or
           MsgBoxStyle.YesNo Or
           MsgBoxStyle.DefaultButton2, Title) = MsgBoxResult.No Then Return

        Dim Image As String = MountedWimInfo.Text.Trim()
        Dim Args As New DismControlEventArgs(DismShell.CreateRemoveDriverArguments(Image, DriveName),
                                             DismMissionFlags.RemoveDriver,
                                             "删除驱动")
        Args.PushToQueue = ChkPushToQueue.Checked
        OnExecute(Args)
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click

        Dim PackagePath As String = FSPackagePath.Text.Trim()
        If PackagePath = "" OrElse Not (IO.File.Exists(PackagePath) Or IO.Directory.Exists(PackagePath)) Then
            MsgBox("请选择一个驱动文件或者其所在目录！", MsgBoxStyle.Critical, Title)
            FSPackagePath.Select()
            Return
        End If

        Dim Image As String = MountedWimInfo.Text.Trim

        Dim Args As New DismControlEventArgs(DismShell.CreateAddDriverArguments(Image,
                                                                                PackagePath,
                                                                                ChkRecurse.Checked,
                                                                                ChkForceUnsigned.Checked),
                                             DismMissionFlags.AddDriver,
                                             "添加驱动")
        Args.PushToQueue = ChkPushToQueue.Checked

        DismConfig.SetItem("DriversPackagePath", PackagePath)
        DismConfig.Save()

        OnExecute(Args)

    End Sub

    Private Function FindColumnIndex(DataPropertyName As String) As Integer
        For i As Integer = 0 To DGDrivers.Columns.Count - 1
            If String.Compare(DGDrivers.Columns(i).DataPropertyName, DataPropertyName) = 0 Then
                Return i
            End If
        Next
        Return -1
    End Function

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MountedWimInfo = New DismGuiPE.MountedWimInfoComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnRefresh = New System.Windows.Forms.Button()
        Me.ChkPushToQueue = New System.Windows.Forms.CheckBox()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.FSPackagePath = New DismGuiPE.FileOrFolderSelector()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ChkForceUnsigned = New System.Windows.Forms.CheckBox()
        Me.ChkRecurse = New System.Windows.Forms.CheckBox()
        Me.DGDrivers = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DGDrivers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MountedWimInfo
        '
        Me.MountedWimInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MountedWimInfo.ItemHeightOffset = 6
        Me.MountedWimInfo.ListSelectedItemDetail = DismGuiPE.WimInfoDetail.Driver
        Me.MountedWimInfo.Location = New System.Drawing.Point(84, 12)
        Me.MountedWimInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.MountedWimInfo.MaxDropDownItems = 4
        Me.MountedWimInfo.Name = "MountedWimInfo"
        Me.MountedWimInfo.ReadOnly = False
        Me.MountedWimInfo.SelectedIndex = -1
        Me.MountedWimInfo.Size = New System.Drawing.Size(502, 24)
        Me.MountedWimInfo.TabIndex = 0
        Me.MountedWimInfo.ToolTipTitle = "驱动管理"
        Me.MountedWimInfo.WithOnlineImage = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "已安装映像："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'FSPackagePath
        '
        Me.FSPackagePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FSPackagePath.BrowserStyle = DismGuiPE.FileOrFolderBrowserStyle.FileOrFolderOpen
        Me.FSPackagePath.CheckFileExists = True
        Me.FSPackagePath.CheckPathExists = True
        Me.FSPackagePath.Filter = """程序包文件(*.CAB,*.MSU)|*.CAB;*.MSU|所有文件(*.*)|*.*"""
        Me.FSPackagePath.Location = New System.Drawing.Point(75, 233)
        Me.FSPackagePath.Multiselect = False
        Me.FSPackagePath.Name = "FSPackagePath"
        Me.FSPackagePath.OverwritePrompt = True
        Me.FSPackagePath.ReadOnly = False
        Me.FSPackagePath.Size = New System.Drawing.Size(511, 24)
        Me.FSPackagePath.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(13, 236)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 17)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "驱动文件："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TT
        '
        Me.TT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TT.ToolTipTitle = "驱动管理"
        '
        'ChkForceUnsigned
        '
        Me.ChkForceUnsigned.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkForceUnsigned.AutoSize = True
        Me.ChkForceUnsigned.Location = New System.Drawing.Point(200, 277)
        Me.ChkForceUnsigned.Name = "ChkForceUnsigned"
        Me.ChkForceUnsigned.Size = New System.Drawing.Size(108, 16)
        Me.ChkForceUnsigned.TabIndex = 5
        Me.ChkForceUnsigned.Text = "/ForceUnsigned"
        Me.TT.SetToolTip(Me.ChkForceUnsigned, "强制添加没数字签名的驱动")
        Me.ChkForceUnsigned.UseVisualStyleBackColor = True
        '
        'ChkRecurse
        '
        Me.ChkRecurse.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkRecurse.AutoSize = True
        Me.ChkRecurse.Location = New System.Drawing.Point(200, 260)
        Me.ChkRecurse.Name = "ChkRecurse"
        Me.ChkRecurse.Size = New System.Drawing.Size(72, 16)
        Me.ChkRecurse.TabIndex = 4
        Me.ChkRecurse.Text = "/Recurse"
        Me.TT.SetToolTip(Me.ChkRecurse, "可查询所有子文件夹中的驱动程序。")
        Me.ChkRecurse.UseVisualStyleBackColor = True
        '
        'DGDrivers
        '
        Me.DGDrivers.AllowUserToAddRows = False
        Me.DGDrivers.AllowUserToDeleteRows = False
        Me.DGDrivers.AllowUserToOrderColumns = True
        Me.DGDrivers.AllowUserToResizeColumns = False
        Me.DGDrivers.AllowUserToResizeRows = False
        Me.DGDrivers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGDrivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGDrivers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7})
        Me.DGDrivers.Location = New System.Drawing.Point(13, 40)
        Me.DGDrivers.MultiSelect = False
        Me.DGDrivers.Name = "DGDrivers"
        Me.DGDrivers.ReadOnly = True
        Me.DGDrivers.RowHeadersVisible = False
        Me.DGDrivers.RowTemplate.Height = 23
        Me.DGDrivers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGDrivers.Size = New System.Drawing.Size(572, 187)
        Me.DGDrivers.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "PublishedName"
        Me.Column1.HeaderText = "已发布的名称"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "OriginalFileName"
        Me.Column2.HeaderText = "原始文件名"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "Inbox"
        Me.Column3.HeaderText = "内置驱动程序"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "ClassName"
        Me.Column4.HeaderText = "类名称"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "ProviderName"
        Me.Column5.HeaderText = "提供程序名称"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "Date"
        Me.Column6.HeaderText = "日期"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "Version"
        Me.Column7.HeaderText = "版本"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'PanelDrivers
        '
        Me.Controls.Add(Me.ChkForceUnsigned)
        Me.Controls.Add(Me.ChkRecurse)
        Me.Controls.Add(Me.DGDrivers)
        Me.Controls.Add(Me.MountedWimInfo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnRefresh)
        Me.Controls.Add(Me.ChkPushToQueue)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.FSPackagePath)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PanelDrivers"
        Me.Size = New System.Drawing.Size(600, 300)
        CType(Me.DGDrivers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Sub ChkPushToQueue_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPushToQueue.CheckedChanged
        DismConfig.SetItem("DriversPushToQueue", ChkPushToQueue.Checked)
        DismConfig.Save()
    End Sub
End Class
