Public Class PanelImageApply
    Inherits DismPanelBase
    Friend WithEvents ChkCheckIntegrity As System.Windows.Forms.CheckBox
    Friend WithEvents ChkVerify As System.Windows.Forms.CheckBox
    Friend WithEvents ChkNoRpFix As System.Windows.Forms.CheckBox
    Friend WithEvents ChkConfirmTrustedFile As System.Windows.Forms.CheckBox
    Private components As System.ComponentModel.IContainer
    Private WithEvents TT As System.Windows.Forms.ToolTip
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents WimFile As DismGuiPE.WimFileSelector
    Private WithEvents WimInfo As DismGuiPE.WimInfoComboBox
    Private WithEvents TBImageName As System.Windows.Forms.TextBox
    Private WithEvents TBImageDescription As System.Windows.Forms.TextBox
    Private WithEvents BtnApply As System.Windows.Forms.Button
    Private WithEvents ChkPushToQueue As System.Windows.Forms.CheckBox
    Friend WithEvents ChkWIMBoot As System.Windows.Forms.CheckBox
    Private WithEvents FSApplyDir As DismGuiPE.FileOrFolderSelector

    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnLoadConfig()
        WimFile.Text = DismConfig.GetItem("ApplyWimFile", "")
        FSApplyDir.Text = DismConfig.GetItem("ApplyDir", "")
        ChkCheckIntegrity.Checked = DismConfig.GetItem("ApplyCheckIntegrity", False)
        ChkVerify.Checked = DismConfig.GetItem("ApplyVerify", False)
        ChkNoRpFix.Checked = DismConfig.GetItem("AppyNoRpFix", False)
        ChkConfirmTrustedFile.Checked = DismConfig.GetItem("ApplyConfirmTrustedFile", False)
        ChkPushToQueue.Checked = DismConfig.GetItem("ApplyPushToQueue", False)
        ChkWIMBoot.Checked = DismConfig.GetItem("ApplyWIMBoot", False)
    End Sub

    Protected Overrides Sub OnUpdateInfo(Flags As WimInfoDetail)
        If Flags And WimInfoDetail.WimInfo Then WimInfo.UpdateWimInfo(WimFile.Text)
    End Sub

    Private Sub BtnApply_Click(sender As Object, e As EventArgs) Handles BtnApply.Click
        Dim wFile As String = WimFile.Text.Trim()
        Dim aDir As String = FSApplyDir.Text.Trim()
        Dim Index As String = WimInfo.Text

        If Not IO.File.Exists(wFile) Then
            MsgBox("未能找到：" & wFile & vbCrLf & "请选择一个WIM文件。", MsgBoxStyle.Critical, Title)
            WimFile.Select()
            Return
        End If

        If Not IO.Directory.Exists(aDir) Then
            If MsgBox("未能找到文件夹：" & aDir & vbCrLf & "是否创建它?", MsgBoxStyle.Exclamation Or
                      MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, "应用目录") = MsgBoxResult.Yes Then
                Try
                    IO.Directory.CreateDirectory(aDir)
                Catch ex As Exception
                    MsgBox("创建应用目录：" & aDir & "失败！" & vbCrLf &
                           "1、请检查路径是否包含非法字符。" & vbCrLf &
                           "2、请检查你是否拥有在该文件创建目录的权限。", MsgBoxStyle.Critical, Title)
                    FSApplyDir.Select()
                    Return
                End Try
            End If
        End If


        If Index = "" Then
            MsgBox("请选择一个映像索引！", MsgBoxStyle.Critical, Title)
            WimInfo.Select()
            Return
        End If

        Dim Args As New DismControlEventArgs()

        Args.Arguments = DismShell.CreateApplyImageArgumnets(wFile,
                                                             aDir,
                                                             Index,
                                                             ChkCheckIntegrity.Checked,
                                                             ChkVerify.Checked,
                                                             ChkNoRpFix.Checked,
                                                             ChkConfirmTrustedFile.Checked,
                                                             ChkWIMBoot.Checked)
        Args.Mission = DismMissionFlags.ApplyImage
        Args.Description = Title
        Args.PushToQueue = ChkPushToQueue.Checked

        DismConfig.SetItem("ApplyWimFile", wFile)
        DismConfig.SetItem("ApplyDir", aDir)
        DismConfig.SetItem("ApplyCheckIntegrity", ChkCheckIntegrity.Checked)
        DismConfig.SetItem("ApplyVerify", ChkVerify.Checked)
        DismConfig.SetItem("AppyNoRpFix", ChkNoRpFix.Checked)
        DismConfig.SetItem("ApplyConfirmTrustedFile", ChkConfirmTrustedFile.Checked)
        DismConfig.SetItem("ApplyWIMBoot", ChkWIMBoot.Checked)
        DismConfig.Save()

        OnExecute(Args)

    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.FSApplyDir = New DismGuiPE.FileOrFolderSelector()
        Me.ChkPushToQueue = New System.Windows.Forms.CheckBox()
        Me.BtnApply = New System.Windows.Forms.Button()
        Me.TBImageDescription = New System.Windows.Forms.TextBox()
        Me.TBImageName = New System.Windows.Forms.TextBox()
        Me.WimInfo = New DismGuiPE.WimInfoComboBox()
        Me.WimFile = New DismGuiPE.WimFileSelector()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ChkConfirmTrustedFile = New System.Windows.Forms.CheckBox()
        Me.ChkNoRpFix = New System.Windows.Forms.CheckBox()
        Me.ChkVerify = New System.Windows.Forms.CheckBox()
        Me.ChkCheckIntegrity = New System.Windows.Forms.CheckBox()
        Me.ChkWIMBoot = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'FSApplyDir
        '
        Me.FSApplyDir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FSApplyDir.BrowserStyle = DismGuiPE.FileOrFolderBrowserStyle.Folder
        Me.FSApplyDir.CheckFileExists = True
        Me.FSApplyDir.CheckPathExists = True
        Me.FSApplyDir.Filter = ""
        Me.FSApplyDir.Location = New System.Drawing.Point(74, 34)
        Me.FSApplyDir.Multiselect = False
        Me.FSApplyDir.Name = "FSApplyDir"
        Me.FSApplyDir.OverwritePrompt = True
        Me.FSApplyDir.ReadOnly = False
        Me.FSApplyDir.Size = New System.Drawing.Size(512, 24)
        Me.FSApplyDir.TabIndex = 1
        '
        'ChkPushToQueue
        '
        Me.ChkPushToQueue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkPushToQueue.AutoSize = True
        Me.ChkPushToQueue.Location = New System.Drawing.Point(13, 270)
        Me.ChkPushToQueue.Name = "ChkPushToQueue"
        Me.ChkPushToQueue.Size = New System.Drawing.Size(108, 16)
        Me.ChkPushToQueue.TabIndex = 9
        Me.ChkPushToQueue.Text = "添加到任务队列"
        Me.ChkPushToQueue.UseVisualStyleBackColor = True
        '
        'BtnApply
        '
        Me.BtnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnApply.Location = New System.Drawing.Point(506, 264)
        Me.BtnApply.Name = "BtnApply"
        Me.BtnApply.Size = New System.Drawing.Size(80, 28)
        Me.BtnApply.TabIndex = 10
        Me.BtnApply.Text = "应用"
        Me.BtnApply.UseVisualStyleBackColor = True
        '
        'TBImageDescription
        '
        Me.TBImageDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBImageDescription.Location = New System.Drawing.Point(74, 141)
        Me.TBImageDescription.Multiline = True
        Me.TBImageDescription.Name = "TBImageDescription"
        Me.TBImageDescription.ReadOnly = True
        Me.TBImageDescription.Size = New System.Drawing.Size(511, 116)
        Me.TBImageDescription.TabIndex = 8
        '
        'TBImageName
        '
        Me.TBImageName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBImageName.Location = New System.Drawing.Point(74, 114)
        Me.TBImageName.Name = "TBImageName"
        Me.TBImageName.ReadOnly = True
        Me.TBImageName.Size = New System.Drawing.Size(511, 21)
        Me.TBImageName.TabIndex = 7
        '
        'WimInfo
        '
        Me.WimInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WimInfo.DropDownWidth = 520
        Me.WimInfo.ImageDescriptionControl = Me.TBImageDescription
        Me.WimInfo.ImageNameControl = Me.TBImageName
        Me.WimInfo.ItemHeightOffset = 6
        Me.WimInfo.Location = New System.Drawing.Point(74, 87)
        Me.WimInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.WimInfo.MaxDropDownItems = 4
        Me.WimInfo.Name = "WimInfo"
        Me.WimInfo.Size = New System.Drawing.Size(511, 24)
        Me.WimInfo.TabIndex = 2
        Me.WimInfo.ToolTipTitle = "应用映像"
        Me.WimInfo.WimFile = ""
        '
        'WimFile
        '
        Me.WimFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WimFile.Location = New System.Drawing.Point(74, 8)
        Me.WimFile.Name = "WimFile"
        Me.WimFile.ShowAsSaveFileDialog = False
        Me.WimFile.Size = New System.Drawing.Size(512, 24)
        Me.WimFile.TabIndex = 0
        Me.WimFile.WimInfoControl = Me.WimInfo
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "映像文件："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(11, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 71
        Me.Label5.Text = "映像描述："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(11, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "映像名称："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(11, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "映像索引："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "应用目录："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TT
        '
        Me.TT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TT.ToolTipTitle = "应用映像"
        '
        'ChkConfirmTrustedFile
        '
        Me.ChkConfirmTrustedFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkConfirmTrustedFile.AutoSize = True
        Me.ChkConfirmTrustedFile.Location = New System.Drawing.Point(452, 64)
        Me.ChkConfirmTrustedFile.Name = "ChkConfirmTrustedFile"
        Me.ChkConfirmTrustedFile.Size = New System.Drawing.Size(138, 16)
        Me.ChkConfirmTrustedFile.TabIndex = 6
        Me.ChkConfirmTrustedFile.Text = "/ConfirmTrustedFile"
        Me.TT.SetToolTip(Me.ChkConfirmTrustedFile, "验证受信任的桌面映像。")
        Me.ChkConfirmTrustedFile.UseVisualStyleBackColor = True
        '
        'ChkNoRpFix
        '
        Me.ChkNoRpFix.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkNoRpFix.AutoSize = True
        Me.ChkNoRpFix.Location = New System.Drawing.Point(374, 64)
        Me.ChkNoRpFix.Name = "ChkNoRpFix"
        Me.ChkNoRpFix.Size = New System.Drawing.Size(72, 16)
        Me.ChkNoRpFix.TabIndex = 5
        Me.ChkNoRpFix.Text = "/NoRpFix"
        Me.TT.SetToolTip(Me.ChkNoRpFix, "禁用重分析点标记修复。")
        Me.ChkNoRpFix.UseVisualStyleBackColor = True
        '
        'ChkVerify
        '
        Me.ChkVerify.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkVerify.AutoSize = True
        Me.ChkVerify.Location = New System.Drawing.Point(302, 64)
        Me.ChkVerify.Name = "ChkVerify"
        Me.ChkVerify.Size = New System.Drawing.Size(66, 16)
        Me.ChkVerify.TabIndex = 4
        Me.ChkVerify.Text = "/Verify"
        Me.TT.SetToolTip(Me.ChkVerify, "检查错误和文件重复。")
        Me.ChkVerify.UseVisualStyleBackColor = True
        '
        'ChkCheckIntegrity
        '
        Me.ChkCheckIntegrity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkCheckIntegrity.AutoSize = True
        Me.ChkCheckIntegrity.Location = New System.Drawing.Point(184, 64)
        Me.ChkCheckIntegrity.Name = "ChkCheckIntegrity"
        Me.ChkCheckIntegrity.Size = New System.Drawing.Size(114, 16)
        Me.ChkCheckIntegrity.TabIndex = 3
        Me.ChkCheckIntegrity.Text = "/CheckIntegrity"
        Me.TT.SetToolTip(Me.ChkCheckIntegrity, "检测和跟踪 WIM 文件是否损坏。")
        Me.ChkCheckIntegrity.UseVisualStyleBackColor = True
        '
        'ChkWIMBoot
        '
        Me.ChkWIMBoot.AutoSize = True
        Me.ChkWIMBoot.Location = New System.Drawing.Point(74, 64)
        Me.ChkWIMBoot.Name = "ChkWIMBoot"
        Me.ChkWIMBoot.Size = New System.Drawing.Size(72, 16)
        Me.ChkWIMBoot.TabIndex = 72
        Me.ChkWIMBoot.Text = "/WIMBoot"
        Me.TT.SetToolTip(Me.ChkWIMBoot, "将 /WIMBoot 和 WIMBoot 配置一起使用以应用映像。")
        Me.ChkWIMBoot.UseVisualStyleBackColor = True
        '
        'PanelImageApply
        '
        Me.Controls.Add(Me.ChkWIMBoot)
        Me.Controls.Add(Me.ChkConfirmTrustedFile)
        Me.Controls.Add(Me.ChkNoRpFix)
        Me.Controls.Add(Me.ChkVerify)
        Me.Controls.Add(Me.ChkCheckIntegrity)
        Me.Controls.Add(Me.FSApplyDir)
        Me.Controls.Add(Me.ChkPushToQueue)
        Me.Controls.Add(Me.BtnApply)
        Me.Controls.Add(Me.TBImageDescription)
        Me.Controls.Add(Me.TBImageName)
        Me.Controls.Add(Me.WimInfo)
        Me.Controls.Add(Me.WimFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "PanelImageApply"
        Me.Size = New System.Drawing.Size(600, 300)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub


    Private Sub ChkPushToQueue_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPushToQueue.CheckedChanged
        DismConfig.SetItem("ApplyPushToQueue", ChkPushToQueue.Checked)
        DismConfig.Save()
    End Sub
End Class
