Public Class PanelImageCapture
    Inherits DismPanelBase
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents ChkBootable As System.Windows.Forms.CheckBox
    Private WithEvents TT As System.Windows.Forms.ToolTip
    Private components As System.ComponentModel.IContainer
    Private WithEvents ChkNoRpFix As System.Windows.Forms.CheckBox
    Private WithEvents ChkVerify As System.Windows.Forms.CheckBox
    Private WithEvents ChkCheckIntegrity As System.Windows.Forms.CheckBox
    Private WithEvents BtnExclusion As System.Windows.Forms.Button
    Private WithEvents CBCompress As System.Windows.Forms.ComboBox
    Private WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents FSCaptureDir As DismGui.FileOrFolderSelector
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents WimFile As DismGui.WimFileSelector
    Private WithEvents WimInfo As DismGui.WimInfoComboBox
    Private WithEvents TBImageName As System.Windows.Forms.TextBox
    Private WithEvents TBImageDescription As System.Windows.Forms.TextBox
    Private WithEvents BtnAppend As System.Windows.Forms.Button
    Private WithEvents BtnNew As System.Windows.Forms.Button
    Private WithEvents ChkPushToQueue As System.Windows.Forms.CheckBox
    Private WithEvents ChkWIMBoot As System.Windows.Forms.CheckBox
    Private WithEvents BtnCustomImage As System.Windows.Forms.Button

    Private ExclusionList As New DismExclusionList

    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnLoadConfig()
        WimFile.Text = DismConfig.GetItem("CaptureWimFile", "")
        FSCaptureDir.Text = DismConfig.GetItem("CaptureDir", "")
        TBImageName.Text = DismConfig.GetItem("CaptureName", "")
        TBImageDescription.Text = DismConfig.GetItem("CaptureDescription", "")
        CBCompress.Text = DismConfig.GetItem("CaptureCompress", "快速（Fast）")
        ChkBootable.Checked = DismConfig.GetItem("CaptureBootable", False)
        ChkCheckIntegrity.Checked = DismConfig.GetItem("CaptureCheckIntegrity", False)
        ChkVerify.Checked = DismConfig.GetItem("CaptureVerify", False)
        ChkNoRpFix.Checked = DismConfig.GetItem("CaptureNoRpFix", False)
        ChkPushToQueue.Checked = DismConfig.GetItem("CapturePushToQueue", False)
        ChkWIMBoot.Checked = DismConfig.GetItem("CaptureWIMBoot", False)
    End Sub

    Protected Overrides Sub OnUpdateInfo(Flags As WimInfoDetail)
        If Flags And WimInfoDetail.WimInfo Then WimInfo.UpdateWimInfo(WimFile.Text)
    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ChkWIMBoot = New System.Windows.Forms.CheckBox()
        Me.ChkBootable = New System.Windows.Forms.CheckBox()
        Me.ChkNoRpFix = New System.Windows.Forms.CheckBox()
        Me.ChkVerify = New System.Windows.Forms.CheckBox()
        Me.ChkCheckIntegrity = New System.Windows.Forms.CheckBox()
        Me.BtnCustomImage = New System.Windows.Forms.Button()
        Me.CBCompress = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BtnExclusion = New System.Windows.Forms.Button()
        Me.ChkPushToQueue = New System.Windows.Forms.CheckBox()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.BtnAppend = New System.Windows.Forms.Button()
        Me.TBImageDescription = New System.Windows.Forms.TextBox()
        Me.TBImageName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FSCaptureDir = New DismGui.FileOrFolderSelector()
        Me.WimInfo = New DismGui.WimInfoComboBox()
        Me.WimFile = New DismGui.WimFileSelector()
        Me.SuspendLayout()
        '
        'TT
        '
        Me.TT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TT.ToolTipTitle = "捕获映像"
        '
        'ChkWIMBoot
        '
        Me.ChkWIMBoot.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkWIMBoot.AutoSize = True
        Me.ChkWIMBoot.Location = New System.Drawing.Point(160, 67)
        Me.ChkWIMBoot.Name = "ChkWIMBoot"
        Me.ChkWIMBoot.Size = New System.Drawing.Size(72, 16)
        Me.ChkWIMBoot.TabIndex = 53
        Me.ChkWIMBoot.Text = "/WIMBoot"
        Me.TT.SetToolTip(Me.ChkWIMBoot, "捕获能够使用 WIMBoot 配置应用的映像。")
        Me.ChkWIMBoot.UseVisualStyleBackColor = True
        '
        'ChkBootable
        '
        Me.ChkBootable.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkBootable.AutoSize = True
        Me.ChkBootable.Location = New System.Drawing.Point(238, 67)
        Me.ChkBootable.Name = "ChkBootable"
        Me.ChkBootable.Size = New System.Drawing.Size(78, 16)
        Me.ChkBootable.TabIndex = 3
        Me.ChkBootable.Text = "/Bootable"
        Me.TT.SetToolTip(Me.ChkBootable, "将 Windows PE 卷映像标记为能够引导。")
        Me.ChkBootable.UseVisualStyleBackColor = True
        '
        'ChkNoRpFix
        '
        Me.ChkNoRpFix.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkNoRpFix.AutoSize = True
        Me.ChkNoRpFix.Location = New System.Drawing.Point(514, 67)
        Me.ChkNoRpFix.Name = "ChkNoRpFix"
        Me.ChkNoRpFix.Size = New System.Drawing.Size(72, 16)
        Me.ChkNoRpFix.TabIndex = 6
        Me.ChkNoRpFix.Text = "/NoRpFix"
        Me.TT.SetToolTip(Me.ChkNoRpFix, "禁用重分析点标记修复。")
        Me.ChkNoRpFix.UseVisualStyleBackColor = True
        '
        'ChkVerify
        '
        Me.ChkVerify.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkVerify.AutoSize = True
        Me.ChkVerify.Location = New System.Drawing.Point(442, 67)
        Me.ChkVerify.Name = "ChkVerify"
        Me.ChkVerify.Size = New System.Drawing.Size(66, 16)
        Me.ChkVerify.TabIndex = 5
        Me.ChkVerify.Text = "/Verify"
        Me.TT.SetToolTip(Me.ChkVerify, "检查错误和文件重复。")
        Me.ChkVerify.UseVisualStyleBackColor = True
        '
        'ChkCheckIntegrity
        '
        Me.ChkCheckIntegrity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkCheckIntegrity.AutoSize = True
        Me.ChkCheckIntegrity.Location = New System.Drawing.Point(322, 67)
        Me.ChkCheckIntegrity.Name = "ChkCheckIntegrity"
        Me.ChkCheckIntegrity.Size = New System.Drawing.Size(114, 16)
        Me.ChkCheckIntegrity.TabIndex = 4
        Me.ChkCheckIntegrity.Text = "/CheckIntegrity"
        Me.TT.SetToolTip(Me.ChkCheckIntegrity, "检测和跟踪 WIM 文件是否损坏。")
        Me.ChkCheckIntegrity.UseVisualStyleBackColor = True
        '
        'BtnCustomImage
        '
        Me.BtnCustomImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCustomImage.Location = New System.Drawing.Point(238, 263)
        Me.BtnCustomImage.Name = "BtnCustomImage"
        Me.BtnCustomImage.Size = New System.Drawing.Size(176, 28)
        Me.BtnCustomImage.TabIndex = 54
        Me.BtnCustomImage.Text = "捕获WIMBoot自定义设置文件"
        Me.BtnCustomImage.UseVisualStyleBackColor = True
        '
        'CBCompress
        '
        Me.CBCompress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CBCompress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBCompress.FormattingEnabled = True
        Me.CBCompress.Items.AddRange(New Object() {"无（None）", "快速（Fast）", "最大压缩（Max）"})
        Me.CBCompress.Location = New System.Drawing.Point(74, 64)
        Me.CBCompress.Name = "CBCompress"
        Me.CBCompress.Size = New System.Drawing.Size(74, 20)
        Me.CBCompress.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(13, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 17)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "压 缩 率："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnExclusion
        '
        Me.BtnExclusion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnExclusion.Location = New System.Drawing.Point(138, 263)
        Me.BtnExclusion.Name = "BtnExclusion"
        Me.BtnExclusion.Size = New System.Drawing.Size(80, 28)
        Me.BtnExclusion.TabIndex = 11
        Me.BtnExclusion.Text = "排除项"
        Me.BtnExclusion.UseVisualStyleBackColor = True
        '
        'ChkPushToQueue
        '
        Me.ChkPushToQueue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkPushToQueue.AutoSize = True
        Me.ChkPushToQueue.Location = New System.Drawing.Point(13, 270)
        Me.ChkPushToQueue.Name = "ChkPushToQueue"
        Me.ChkPushToQueue.Size = New System.Drawing.Size(108, 16)
        Me.ChkPushToQueue.TabIndex = 10
        Me.ChkPushToQueue.Text = "添加到任务队列"
        Me.ChkPushToQueue.UseVisualStyleBackColor = True
        '
        'BtnNew
        '
        Me.BtnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNew.Location = New System.Drawing.Point(420, 264)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(80, 28)
        Me.BtnNew.TabIndex = 12
        Me.BtnNew.Text = "新建"
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'BtnAppend
        '
        Me.BtnAppend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAppend.Location = New System.Drawing.Point(506, 264)
        Me.BtnAppend.Name = "BtnAppend"
        Me.BtnAppend.Size = New System.Drawing.Size(80, 28)
        Me.BtnAppend.TabIndex = 13
        Me.BtnAppend.Text = "追加"
        Me.BtnAppend.UseVisualStyleBackColor = True
        '
        'TBImageDescription
        '
        Me.TBImageDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBImageDescription.Location = New System.Drawing.Point(74, 147)
        Me.TBImageDescription.Multiline = True
        Me.TBImageDescription.Name = "TBImageDescription"
        Me.TBImageDescription.Size = New System.Drawing.Size(511, 112)
        Me.TBImageDescription.TabIndex = 9
        '
        'TBImageName
        '
        Me.TBImageName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBImageName.Location = New System.Drawing.Point(74, 120)
        Me.TBImageName.Name = "TBImageName"
        Me.TBImageName.Size = New System.Drawing.Size(511, 21)
        Me.TBImageName.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "映像文件："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(13, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "映像描述："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(13, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "映像名称："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(13, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "映像索引："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "捕获目录："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FSCaptureDir
        '
        Me.FSCaptureDir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FSCaptureDir.BrowserStyle = DismGui.FileOrFolderBrowserStyle.Folder
        Me.FSCaptureDir.CheckFileExists = True
        Me.FSCaptureDir.CheckPathExists = True
        Me.FSCaptureDir.Filter = ""
        Me.FSCaptureDir.Location = New System.Drawing.Point(74, 36)
        Me.FSCaptureDir.Multiselect = False
        Me.FSCaptureDir.Name = "FSCaptureDir"
        Me.FSCaptureDir.OverwritePrompt = True
        Me.FSCaptureDir.ReadOnly = False
        Me.FSCaptureDir.Size = New System.Drawing.Size(512, 24)
        Me.FSCaptureDir.TabIndex = 1
        '
        'WimInfo
        '
        Me.WimInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WimInfo.DropDownWidth = 520
        Me.WimInfo.ImageDescriptionControl = Me.TBImageDescription
        Me.WimInfo.ImageNameControl = Me.TBImageName
        Me.WimInfo.ItemHeightOffset = 6
        Me.WimInfo.Location = New System.Drawing.Point(74, 91)
        Me.WimInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.WimInfo.MaxDropDownItems = 4
        Me.WimInfo.Name = "WimInfo"
        Me.WimInfo.Size = New System.Drawing.Size(512, 24)
        Me.WimInfo.TabIndex = 7
        Me.WimInfo.ToolTipTitle = "捕获映像"
        Me.WimInfo.WimFile = ""
        '
        'WimFile
        '
        Me.WimFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WimFile.FilterIndex = 1
        Me.WimFile.IsEsdFile = False
        Me.WimFile.Location = New System.Drawing.Point(74, 10)
        Me.WimFile.Name = "WimFile"
        Me.WimFile.ShowAsSaveFileDialog = True
        Me.WimFile.Size = New System.Drawing.Size(512, 24)
        Me.WimFile.TabIndex = 0
        Me.WimFile.WimInfoControl = Me.WimInfo
        '
        'PanelImageCapture
        '
        Me.Controls.Add(Me.BtnCustomImage)
        Me.Controls.Add(Me.ChkWIMBoot)
        Me.Controls.Add(Me.FSCaptureDir)
        Me.Controls.Add(Me.CBCompress)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BtnExclusion)
        Me.Controls.Add(Me.ChkBootable)
        Me.Controls.Add(Me.ChkNoRpFix)
        Me.Controls.Add(Me.ChkVerify)
        Me.Controls.Add(Me.ChkCheckIntegrity)
        Me.Controls.Add(Me.ChkPushToQueue)
        Me.Controls.Add(Me.BtnNew)
        Me.Controls.Add(Me.BtnAppend)
        Me.Controls.Add(Me.TBImageDescription)
        Me.Controls.Add(Me.TBImageName)
        Me.Controls.Add(Me.WimInfo)
        Me.Controls.Add(Me.WimFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "PanelImageCapture"
        Me.Size = New System.Drawing.Size(600, 300)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Sub BtnExclusion_Click(sender As Object, e As EventArgs) Handles BtnExclusion.Click
        Dim Temp As String = FSCaptureDir.Text.Trim()

        If Not IO.Directory.Exists(Temp) Then
            MsgBox("捕获目录不存在！", MsgBoxStyle.Critical, Title)
            FSCaptureDir.Select()
            Return
        End If

        Dim f As New ExclusionEditor
        f.StartPath = Temp
        f.ExclusionList = Me.ExclusionList
        f.ShowDialog()
        f.Dispose()
    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Dim wFile As String = WimFile.Text.Trim()
        Dim cDir As String = FSCaptureDir.Text.Trim()
        Dim ImageName As String = TBImageName.Text.Trim()

        If ChkBootable.Checked And ChkWIMBoot.Checked Then
            MsgBox("/Bootable 和 /WIMBoot 参数不能同时启用。", MsgBoxStyle.Critical, Title)
            Return
        End If

        If wFile = "" Then
            MsgBox(".WIM 文件路径不能为空。", MsgBoxStyle.Critical, Title)
            WimFile.Select()
            Return
        End If

        If ImageName = "" Then
            MsgBox("映像名称不能为空。", MsgBoxStyle.Critical, Title)
            TBImageName.Select()
            Return
        End If

        If Not IO.Directory.Exists(cDir) Then
            MsgBox("捕获目录不存在。", MsgBoxStyle.Critical, Title)
            FSCaptureDir.Select()
            Return
        End If

        Dim Compress As String = ""
        Select Case CBCompress.SelectedIndex
            Case 0
                Compress = "None"
            Case 1
                Compress = "Fast"
            Case Else
                Compress = "Max"
        End Select

        Dim ConfigFile As String = Me.ExclusionList.FileName

        If Me.ExclusionList.IsEmpty Then
            ConfigFile = ""
        Else
            Me.ExclusionList.SaveToFile()
        End If

        If IO.File.Exists(wFile) AndAlso MsgBox("文件已经存在。" & vbCrLf & "是否覆盖它？",
                                                MsgBoxStyle.Question Or
                                                MsgBoxStyle.YesNo Or
                                                MsgBoxStyle.DefaultButton2, Title) = MsgBoxResult.No Then Return

        Dim Args As New DismControlEventArgs()

        Args.Arguments = DismShell.CreateCaptureImageArguments(wFile,
                                                               cDir,
                                                               ImageName,
                                                               TBImageDescription.Text.Trim(),
                                                               Compress,
                                                               ConfigFile,
                                                               ChkBootable.Checked,
                                                               ChkCheckIntegrity.Checked,
                                                               ChkVerify.Checked,
                                                               ChkNoRpFix.Checked,
                                                               ChkWIMBoot.Checked)
        Args.Mission = DismMissionFlags.CaptureImage
        Args.Description = "新建映像"
        Args.PushToQueue = ChkPushToQueue.Checked

        DismConfig.SetItem("CaptureWimFile", WimFile.Text.Trim())
        DismConfig.SetItem("CaptureDir", FSCaptureDir.Text.Trim())
        DismConfig.SetItem("CaptureName", TBImageName.Text.Trim())
        DismConfig.SetItem("CaptureDescription", TBImageDescription.Text.Trim())
        DismConfig.SetItem("CaptureCompress", "快速")
        DismConfig.SetItem("CaptureBootable", ChkBootable.Checked)
        DismConfig.SetItem("CaptureCheckIntegrity", ChkCheckIntegrity.Checked)
        DismConfig.SetItem("CaptureVerify", ChkVerify.Checked)
        DismConfig.SetItem("CaptureNoRpFix", ChkNoRpFix.Checked)
        DismConfig.SetItem("CaptureWIMBoot", ChkWIMBoot.Checked)
        DismConfig.Save()

        OnExecute(Args)
    End Sub

    Private Sub BtnAppend_Click(sender As Object, e As EventArgs) Handles BtnAppend.Click

        Dim wFile As String = WimFile.Text.Trim()
        Dim cDir As String = FSCaptureDir.Text.Trim()
        Dim ImageName As String = TBImageName.Text.Trim()

        If ChkBootable.Checked And ChkWIMBoot.Checked Then
            MsgBox("/Bootable 和 /WIMBoot 参数不能同时启用。", MsgBoxStyle.Critical, Title)
            Return
        End If

        If Not IO.File.Exists(wFile) Then
            MsgBox(".WIM 文件路径不存在。", MsgBoxStyle.Critical, Title)
            WimFile.Select()
            Return
        End If

        If ImageName = "" Then
            MsgBox("映像名称不能为空。", MsgBoxStyle.Critical, Title)
            TBImageName.Select()
            Return
        End If

        If Not IO.Directory.Exists(cDir) Then
            MsgBox("捕获目录不存在。", MsgBoxStyle.Critical, Title)
            FSCaptureDir.Select()
            Return
        End If

        Dim ConfigFile As String = Me.ExclusionList.FileName

        If Me.ExclusionList.IsEmpty Then
            ConfigFile = ""
        Else
            Me.ExclusionList.SaveToFile()
        End If

        Dim Args As New DismControlEventArgs()

        Args.Arguments = DismShell.CreateAppendImageArguments(wFile,
                                                              cDir,
                                                              ImageName,
                                                              TBImageDescription.Text.Trim(),
                                                              ConfigFile,
                                                              ChkBootable.Checked,
                                                              ChkCheckIntegrity.Checked,
                                                              ChkVerify.Checked,
                                                              ChkNoRpFix.Checked,
                                                              ChkWIMBoot.Checked)
        Args.Mission = DismMissionFlags.CaptureImage
        Args.Description = "追加映像"
        Args.PushToQueue = ChkPushToQueue.Checked

        DismConfig.SetItem("CaptureWimFile", WimFile.Text.Trim())
        DismConfig.SetItem("CaptureDir", FSCaptureDir.Text.Trim())
        DismConfig.SetItem("CaptureName", TBImageName.Text.Trim())
        DismConfig.SetItem("CaptureDescription", TBImageDescription.Text.Trim())
        DismConfig.SetItem("CaptureBootable", ChkBootable.Checked)
        DismConfig.SetItem("CaptureCheckIntegrity", ChkCheckIntegrity.Checked)
        DismConfig.SetItem("CaptureVerify", ChkVerify.Checked)
        DismConfig.SetItem("CaptureNoRpFix", ChkNoRpFix.Checked)
        DismConfig.SetItem("CaptureWIMBoot", ChkWIMBoot.Checked)
        DismConfig.Save()

        OnExecute(Args)
    End Sub

    Private Sub ChkPushToQueue_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPushToQueue.CheckedChanged
        DismConfig.SetItem("CapturePushToQueue", ChkPushToQueue.Checked)
        DismConfig.Save()
    End Sub

    Private Sub BtnCustomImage_Click(sender As Object, e As EventArgs) Handles BtnCustomImage.Click

        Dim cDir As String = FSCaptureDir.Text.Trim()
        If Not IO.Directory.Exists(cDir) Then
            MsgBox("捕获目录不存在。", MsgBoxStyle.Critical, Title)
            FSCaptureDir.Select()
            Return
        End If

        Dim ConfigFile As String = Me.ExclusionList.FileName

        If Me.ExclusionList.IsEmpty Then
            ConfigFile = ""
        Else
            Me.ExclusionList.SaveToFile()
        End If

        Dim Args As New DismControlEventArgs With {.Mission = DismMissionFlags.CaptureCustomImage}
        Args.Arguments = DismShell.CreateCaptureCustomImageArguments(cDir, ConfigFile, ChkCheckIntegrity.Checked, ChkVerify.Checked)
        Args.Description = "捕获 WIMBoot 映像自定义配置文件"

        OnExecute(Args)

    End Sub
End Class
