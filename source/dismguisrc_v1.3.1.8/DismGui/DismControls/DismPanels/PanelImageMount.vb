Public Class PanelImageMount
    Inherits DismPanelBase
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents TBImageDescription As System.Windows.Forms.TextBox
    Friend WithEvents BtnDismount As System.Windows.Forms.Button
    Friend WithEvents BtnMount As System.Windows.Forms.Button
    Friend WithEvents ChkPushToQueue As System.Windows.Forms.CheckBox
    Private WithEvents TBImageName As System.Windows.Forms.TextBox
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents BtnRemountImage As System.Windows.Forms.Button
    Private WithEvents ChkMountAsReadOnly As System.Windows.Forms.CheckBox
    Private WithEvents WimInfo As DismGui.WimInfoComboBox
    Private WithEvents MountedWimInfo As DismGui.MountedWimInfoComboBox
    Friend WithEvents BtnCommitImage As System.Windows.Forms.Button
    Private WithEvents TT As System.Windows.Forms.ToolTip
    Private components As System.ComponentModel.IContainer
    Private WithEvents WimFile As DismGui.WimFileSelector

    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnLoadConfig()
        WimFile.Text = DismConfig.GetItem("MountWimFile", "")
        MountedWimInfo.Text = DismConfig.GetItem("MountImageDir", "")
        ChkMountAsReadOnly.Checked = DismConfig.GetItem("MountAsReadOnly", False)
        ChkPushToQueue.Checked = DismConfig.GetItem("MountPushToQueue", False)
    End Sub

    Protected Overrides Sub OnUpdateInfo(Flags As WimInfoDetail)
        If Flags And WimInfoDetail.WimInfo Then WimInfo.UpdateWimInfo()
        If Flags And WimInfoDetail.MountedWimInfo Then MountedWimInfo.UpdateMountedWimInfo()
    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.WimFile = New DismGui.WimFileSelector()
        Me.WimInfo = New DismGui.WimInfoComboBox()
        Me.TBImageDescription = New System.Windows.Forms.TextBox()
        Me.TBImageName = New System.Windows.Forms.TextBox()
        Me.MountedWimInfo = New DismGui.MountedWimInfoComboBox()
        Me.ChkMountAsReadOnly = New System.Windows.Forms.CheckBox()
        Me.BtnRemountImage = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnDismount = New System.Windows.Forms.Button()
        Me.BtnMount = New System.Windows.Forms.Button()
        Me.ChkPushToQueue = New System.Windows.Forms.CheckBox()
        Me.BtnCommitImage = New System.Windows.Forms.Button()
        Me.TT = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "映像文件："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WimFile
        '
        Me.WimFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WimFile.Location = New System.Drawing.Point(74, 10)
        Me.WimFile.Name = "WimFile"
        Me.WimFile.ShowAsSaveFileDialog = False
        Me.WimFile.Size = New System.Drawing.Size(512, 24)
        Me.WimFile.TabIndex = 0
        Me.WimFile.WimInfoControl = Me.WimInfo
        '
        'WimInfo
        '
        Me.WimInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WimInfo.DropDownWidth = 520
        Me.WimInfo.ImageDescriptionControl = Me.TBImageDescription
        Me.WimInfo.ImageNameControl = Me.TBImageName
        Me.WimInfo.ItemHeightOffset = 6
        Me.WimInfo.Location = New System.Drawing.Point(74, 66)
        Me.WimInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.WimInfo.MaxDropDownItems = 4
        Me.WimInfo.Name = "WimInfo"
        Me.WimInfo.Size = New System.Drawing.Size(274, 24)
        Me.WimInfo.TabIndex = 2
        Me.WimInfo.ToolTipTitle = "挂载映像"
        Me.WimInfo.WimFile = ""
        '
        'TBImageDescription
        '
        Me.TBImageDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBImageDescription.Location = New System.Drawing.Point(74, 121)
        Me.TBImageDescription.Multiline = True
        Me.TBImageDescription.Name = "TBImageDescription"
        Me.TBImageDescription.ReadOnly = True
        Me.TBImageDescription.Size = New System.Drawing.Size(511, 139)
        Me.TBImageDescription.TabIndex = 6
        '
        'TBImageName
        '
        Me.TBImageName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBImageName.Location = New System.Drawing.Point(74, 95)
        Me.TBImageName.Name = "TBImageName"
        Me.TBImageName.ReadOnly = True
        Me.TBImageName.Size = New System.Drawing.Size(511, 21)
        Me.TBImageName.TabIndex = 5
        '
        'MountedWimInfo
        '
        Me.MountedWimInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MountedWimInfo.ItemHeightOffset = 6
        Me.MountedWimInfo.ListSelectedItemDetail = DismGui.WimInfoDetail.None
        Me.MountedWimInfo.Location = New System.Drawing.Point(74, 37)
        Me.MountedWimInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.MountedWimInfo.MaxDropDownItems = 4
        Me.MountedWimInfo.Name = "MountedWimInfo"
        Me.MountedWimInfo.ReadOnly = False
        Me.MountedWimInfo.SelectedIndex = -1
        Me.MountedWimInfo.Size = New System.Drawing.Size(512, 24)
        Me.MountedWimInfo.TabIndex = 1
        Me.MountedWimInfo.ToolTipTitle = "挂载映像"
        Me.MountedWimInfo.WithOnlineImage = False
        '
        'ChkMountAsReadOnly
        '
        Me.ChkMountAsReadOnly.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkMountAsReadOnly.AutoSize = True
        Me.ChkMountAsReadOnly.Location = New System.Drawing.Point(361, 72)
        Me.ChkMountAsReadOnly.Name = "ChkMountAsReadOnly"
        Me.ChkMountAsReadOnly.Size = New System.Drawing.Size(120, 16)
        Me.ChkMountAsReadOnly.TabIndex = 3
        Me.ChkMountAsReadOnly.Text = "以只读的方式挂载"
        Me.ChkMountAsReadOnly.UseVisualStyleBackColor = True
        '
        'BtnRemountImage
        '
        Me.BtnRemountImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRemountImage.Location = New System.Drawing.Point(487, 66)
        Me.BtnRemountImage.Name = "BtnRemountImage"
        Me.BtnRemountImage.Size = New System.Drawing.Size(99, 24)
        Me.BtnRemountImage.TabIndex = 4
        Me.BtnRemountImage.Text = "重新挂载映像"
        Me.BtnRemountImage.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "挂载目录："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(13, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "映像索引："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(13, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "映像名称："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(13, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "映像描述："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnDismount
        '
        Me.BtnDismount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDismount.Location = New System.Drawing.Point(506, 264)
        Me.BtnDismount.Name = "BtnDismount"
        Me.BtnDismount.Size = New System.Drawing.Size(80, 28)
        Me.BtnDismount.TabIndex = 9
        Me.BtnDismount.Text = "卸载"
        Me.BtnDismount.UseVisualStyleBackColor = True
        '
        'BtnMount
        '
        Me.BtnMount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMount.Location = New System.Drawing.Point(420, 264)
        Me.BtnMount.Name = "BtnMount"
        Me.BtnMount.Size = New System.Drawing.Size(80, 28)
        Me.BtnMount.TabIndex = 8
        Me.BtnMount.Text = "挂载"
        Me.BtnMount.UseVisualStyleBackColor = True
        '
        'ChkPushToQueue
        '
        Me.ChkPushToQueue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkPushToQueue.AutoSize = True
        Me.ChkPushToQueue.Location = New System.Drawing.Point(13, 270)
        Me.ChkPushToQueue.Name = "ChkPushToQueue"
        Me.ChkPushToQueue.Size = New System.Drawing.Size(108, 16)
        Me.ChkPushToQueue.TabIndex = 7
        Me.ChkPushToQueue.Text = "添加到任务队列"
        Me.ChkPushToQueue.UseVisualStyleBackColor = True
        '
        'BtnCommitImage
        '
        Me.BtnCommitImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCommitImage.Location = New System.Drawing.Point(315, 264)
        Me.BtnCommitImage.Name = "BtnCommitImage"
        Me.BtnCommitImage.Size = New System.Drawing.Size(80, 28)
        Me.BtnCommitImage.TabIndex = 10
        Me.BtnCommitImage.Text = "保存映像"
        Me.TT.SetToolTip(Me.BtnCommitImage, "将挂载的映像内容更新到 .WIM 文件中，但不卸载该映像。")
        Me.BtnCommitImage.UseVisualStyleBackColor = True
        '
        'TT
        '
        Me.TT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TT.ToolTipTitle = "挂载映像"
        '
        'PanelImageMount
        '
        Me.Controls.Add(Me.BtnCommitImage)
        Me.Controls.Add(Me.ChkPushToQueue)
        Me.Controls.Add(Me.BtnMount)
        Me.Controls.Add(Me.BtnDismount)
        Me.Controls.Add(Me.TBImageDescription)
        Me.Controls.Add(Me.TBImageName)
        Me.Controls.Add(Me.BtnRemountImage)
        Me.Controls.Add(Me.ChkMountAsReadOnly)
        Me.Controls.Add(Me.WimInfo)
        Me.Controls.Add(Me.MountedWimInfo)
        Me.Controls.Add(Me.WimFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "PanelImageMount"
        Me.Size = New System.Drawing.Size(600, 300)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Sub BtnMount_Click(sender As Object, e As EventArgs) Handles BtnMount.Click


        Dim wFile As String = WimFile.Text.Trim
        Dim mDir As String = MountedWimInfo.Text.Trim
        Dim Index As String = WimInfo.Text.Trim

        If Not IO.File.Exists(wFile) Then
            MsgBox(".WIM 文件不存在。", MsgBoxStyle.Critical, Title)
            WimFile.Select()
            Return
        End If

        If Not IO.Directory.Exists(mDir) Then
            MsgBox("装载目录不存在。", MsgBoxStyle.Critical, Title)
            MountedWimInfo.Select()
            Return
        End If

        If Index = "" Then
            MsgBox("请选择一个映像。", MsgBoxStyle.Critical, Title)
            WimInfo.Select()
            Return
        End If

        Dim Args As New DismControlEventArgs()
        Args.Arguments = DismShell.CreateMountImageArguments(WimFile.Text.Trim, MountedWimInfo.Text.Trim, WimInfo.Text, ChkMountAsReadOnly.Checked)
        Args.Mission = DismMissionFlags.MountImage
        Args.Description = "挂载映像"
        Args.PushToQueue = ChkPushToQueue.Checked


        DismConfig.SetItem("MountWimFile", wFile)
        DismConfig.SetItem("MountImageDir", mDir)
        DismConfig.SetItem("MountAsReadOnly", ChkMountAsReadOnly.Checked)
        DismConfig.Save()

        OnExecute(Args)

    End Sub

    Private Sub BtnDismount_Click(sender As Object, e As EventArgs) Handles BtnDismount.Click

        Dim mDir As String = MountedWimInfo.Text.Trim

        If Not IO.Directory.Exists(mDir) Then
            MsgBox("挂载目录不存在。", MsgBoxStyle.Critical, Title)
            MountedWimInfo.Select()
            Return
        End If
        Dim f As New UnmountImageDialog()
        f.ShowDialog()
        Dim dlgResult As DismCommitFlags = f.Commit
        f.Dispose()

        If dlgResult = DismCommitFlags.Cancel Then Return
        Dim bCommit As Boolean = IIf(dlgResult = DismCommitFlags.Commit Or dlgResult = DismCommitFlags.Append, True, False)
        Dim bAppend As Boolean = IIf(dlgResult = DismCommitFlags.Append, True, False)

        Dim Args As New DismControlEventArgs()
        Args.Arguments = DismShell.CreateUnMountImageArguments(mDir, bCommit, bAppend)
        Args.Mission = DismMissionFlags.UnmountImage
        Args.Description = "卸载映像"
        Args.PushToQueue = ChkPushToQueue.Checked

        DismConfig.SetItem("MountImageDir", mDir)
        DismConfig.Save()

        OnExecute(Args)
    End Sub

    Private Sub BtnRemountImage_Click(sender As Object, e As EventArgs) Handles BtnRemountImage.Click
        Dim mDir As String = MountedWimInfo.Text.Trim

        If Not IO.Directory.Exists(mDir) Then
            MsgBox("装载目录不存在。", MsgBoxStyle.Critical, Title)
            MountedWimInfo.Select()
            Return
        End If

        Dim Args As New DismControlEventArgs()
        Args.Arguments = DismShell.CreateRemountImageArguments(mDir)
        Args.Mission = DismMissionFlags.UnmountImage
        Args.Description = "重新装载映像"
        Args.PushToQueue = ChkPushToQueue.Checked

        DismConfig.SetItem("MountImageDir", mDir)
        DismConfig.Save()

        OnExecute(Args)
    End Sub


    Private Sub ChkPushToQueue_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPushToQueue.CheckedChanged
        DismConfig.SetItem("MountPushToQueue", ChkPushToQueue.Checked)
        DismConfig.Save()
    End Sub

    Private Sub BtnCommitImage_Click(sender As Object, e As EventArgs) Handles BtnCommitImage.Click

        Dim mDir As String = MountedWimInfo.Text.Trim

        If Not IO.Directory.Exists(mDir) Then
            MsgBox("装载目录不存在。", MsgBoxStyle.Critical, Title)
            MountedWimInfo.Select()
            Return
        End If

        Dim f As New CommitImageDialog()
        f.ShowDialog()
        Dim dlgResult As DismCommitFlags = f.Commit
        f.Dispose()

        If f.Commit = DismCommitFlags.Cancel Then Return
        Dim Args As New DismControlEventArgs With {.Mission = DismMissionFlags.CommitImage}
        Args.Arguments = DismShell.CreateCommitImageArguments(mDir, dlgResult = DismCommitFlags.Append)
        Args.Description = "保存映像"

        OnExecute(Args)


    End Sub
End Class
