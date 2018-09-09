Public Class PanelImageExport
    Inherits DismPanelBase
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents WimFile As DismGuiPE.WimFileSelector
    Private WithEvents WimInfo As DismGuiPE.WimInfoComboBox
    Private WithEvents TBImageName As System.Windows.Forms.TextBox
    Private WithEvents TBImageDescription As System.Windows.Forms.TextBox
    Friend WithEvents BtnExport As System.Windows.Forms.Button
    Private WithEvents CBCompress As System.Windows.Forms.ComboBox
    Private WithEvents ChkBootable As System.Windows.Forms.CheckBox
    Private WithEvents TT As System.Windows.Forms.ToolTip
    Private components As System.ComponentModel.IContainer
    Private WithEvents ChkCheckIntegrity As System.Windows.Forms.CheckBox
    Private WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents TBTargetImageName As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents TargetWimFile As DismGuiPE.WimFileSelector
    Private WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents ChkWIMBoot As System.Windows.Forms.CheckBox
    Friend WithEvents ChkPushToQueue As System.Windows.Forms.CheckBox

    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnLoadConfig()
        WimFile.Text = DismConfig.GetItem("ExportWimFile", "")
        TargetWimFile.Text = DismConfig.GetItem("ExportTargetWimFile", "")
        TBTargetImageName.Text = DismConfig.GetItem("ExportTargetImageName", "")
        CBCompress.Text = DismConfig.GetItem("ExportCompress", "快速（Fast）")
        ChkPushToQueue.Checked = DismConfig.GetItem("ExportPushToQueue", False)
        ChkWIMBoot.Checked = DismConfig.GetItem("ExportWIMBoot", False)
    End Sub

    Protected Overrides Sub OnUpdateInfo(Flags As WimInfoDetail)
        If Flags And WimInfoDetail.WimInfo Then WimInfo.UpdateWimInfo(WimFile.Text.Trim())
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click

        Dim srcFile As String = WimFile.Text.Trim()
        Dim srcIndex As String = WimInfo.Text.Trim()
        Dim destFile As String = TargetWimFile.Text.Trim()
        Dim destImageName As String = TBTargetImageName.Text.Trim()

        If ChkBootable.Checked And ChkWIMBoot.Checked Then
            MsgBox("/Bootable 和 /WIMBoot 参数不能同时启用。", MsgBoxStyle.Critical, Title)
            Return
        End If

        If Not IO.File.Exists(srcFile) Then
            MsgBox("源 .WIM/.SWM 文件不存在。", MsgBoxStyle.Critical, Title)
            WimFile.Select()
            Return
        End If

        If srcIndex = "" Then
            MsgBox("请选择一个映像。", MsgBoxStyle.Critical, Title)
            WimInfo.Select()
            Return
        End If

        If destFile = "" Then
            MsgBox("目标 .WIM 文件路径不能为空。", MsgBoxStyle.Critical, Title)
            TargetWimFile.Select()
            Return
        End If

        Dim Compress As String = ""

        Select Case CBCompress.SelectedIndex
            Case 0
                Compress = "None"
            Case 1
                Compress = "Fast"
            Case 2
                Compress = "Max"
            Case 3
                Compress = "Recovery"
            Case Else
                Compress = "None"
        End Select

        Dim Args As New DismControlEventArgs
        Args.Arguments = DismShell.CreateExportImageArguments(srcFile,
                                                              srcIndex,
                                                              destFile,
                                                              destImageName,
                                                              Compress,
                                                              ChkBootable.Checked,
                                                              ChkCheckIntegrity.Checked,
                                                              ChkWIMBoot.Checked)
        Args.Mission = DismMissionFlags.ExportImage
        Args.Description = "导出映像"
        Args.PushToQueue = ChkPushToQueue.Checked

        DismConfig.SetItem("ExportWimFile", srcFile)
        DismConfig.SetItem("ExportTargetWimFile", destFile)
        DismConfig.SetItem("ExportTargetImageName", destImageName)
        DismConfig.SetItem("ExportCompress", CBCompress.Text)
        DismConfig.SetItem("ExportWIMBoot", ChkWIMBoot.Checked)
        DismConfig.Save()

        OnExecute(Args)

    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ChkWIMBoot = New System.Windows.Forms.CheckBox()
        Me.ChkBootable = New System.Windows.Forms.CheckBox()
        Me.ChkCheckIntegrity = New System.Windows.Forms.CheckBox()
        Me.CBCompress = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TBTargetImageName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ChkPushToQueue = New System.Windows.Forms.CheckBox()
        Me.BtnExport = New System.Windows.Forms.Button()
        Me.TBImageDescription = New System.Windows.Forms.TextBox()
        Me.TBImageName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TargetWimFile = New DismGuiPE.WimFileSelector()
        Me.WimInfo = New DismGuiPE.WimInfoComboBox()
        Me.WimFile = New DismGuiPE.WimFileSelector()
        Me.SuspendLayout()
        '
        'TT
        '
        Me.TT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TT.ToolTipTitle = "导出映像"
        '
        'ChkWIMBoot
        '
        Me.ChkWIMBoot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkWIMBoot.AutoSize = True
        Me.ChkWIMBoot.Location = New System.Drawing.Point(309, 185)
        Me.ChkWIMBoot.Name = "ChkWIMBoot"
        Me.ChkWIMBoot.Size = New System.Drawing.Size(72, 16)
        Me.ChkWIMBoot.TabIndex = 84
        Me.ChkWIMBoot.Text = "/WIMBoot"
        Me.TT.SetToolTip(Me.ChkWIMBoot, "能够使用 WIMBoot 配置应用的映像。")
        Me.ChkWIMBoot.UseVisualStyleBackColor = True
        '
        'ChkBootable
        '
        Me.ChkBootable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkBootable.AutoSize = True
        Me.ChkBootable.Location = New System.Drawing.Point(387, 185)
        Me.ChkBootable.Name = "ChkBootable"
        Me.ChkBootable.Size = New System.Drawing.Size(78, 16)
        Me.ChkBootable.TabIndex = 5
        Me.ChkBootable.Text = "/Bootable"
        Me.TT.SetToolTip(Me.ChkBootable, "将 Windows PE 卷映像标记为能够引导。")
        Me.ChkBootable.UseVisualStyleBackColor = True
        '
        'ChkCheckIntegrity
        '
        Me.ChkCheckIntegrity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkCheckIntegrity.AutoSize = True
        Me.ChkCheckIntegrity.Location = New System.Drawing.Point(471, 185)
        Me.ChkCheckIntegrity.Name = "ChkCheckIntegrity"
        Me.ChkCheckIntegrity.Size = New System.Drawing.Size(114, 16)
        Me.ChkCheckIntegrity.TabIndex = 6
        Me.ChkCheckIntegrity.Text = "/CheckIntegrity"
        Me.TT.SetToolTip(Me.ChkCheckIntegrity, "检测和跟踪 WIM 文件是否损坏。")
        Me.ChkCheckIntegrity.UseVisualStyleBackColor = True
        '
        'CBCompress
        '
        Me.CBCompress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CBCompress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBCompress.FormattingEnabled = True
        Me.CBCompress.Items.AddRange(New Object() {"无（None）", "快速（Fast）", "最大压缩（Max）", "重置映像（Recovery）"})
        Me.CBCompress.Location = New System.Drawing.Point(74, 183)
        Me.CBCompress.Name = "CBCompress"
        Me.CBCompress.Size = New System.Drawing.Size(180, 20)
        Me.CBCompress.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.Location = New System.Drawing.Point(13, 213)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 83
        Me.Label7.Text = "目标文件："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TBTargetImageName
        '
        Me.TBTargetImageName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBTargetImageName.Location = New System.Drawing.Point(74, 237)
        Me.TBTargetImageName.Name = "TBTargetImageName"
        Me.TBTargetImageName.Size = New System.Drawing.Size(511, 21)
        Me.TBTargetImageName.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(13, 240)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "目标名称："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.Location = New System.Drawing.Point(13, 184)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 17)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "压缩率："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'BtnExport
        '
        Me.BtnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExport.Location = New System.Drawing.Point(506, 264)
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(80, 28)
        Me.BtnExport.TabIndex = 10
        Me.BtnExport.Text = "导出"
        Me.BtnExport.UseVisualStyleBackColor = True
        '
        'TBImageDescription
        '
        Me.TBImageDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBImageDescription.Location = New System.Drawing.Point(74, 88)
        Me.TBImageDescription.Multiline = True
        Me.TBImageDescription.Name = "TBImageDescription"
        Me.TBImageDescription.ReadOnly = True
        Me.TBImageDescription.Size = New System.Drawing.Size(511, 89)
        Me.TBImageDescription.TabIndex = 3
        '
        'TBImageName
        '
        Me.TBImageName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBImageName.Location = New System.Drawing.Point(74, 63)
        Me.TBImageName.Name = "TBImageName"
        Me.TBImageName.ReadOnly = True
        Me.TBImageName.Size = New System.Drawing.Size(511, 21)
        Me.TBImageName.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "映像文件："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(13, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "映像描述："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(13, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "映像名称："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(13, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "映像索引："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TargetWimFile
        '
        Me.TargetWimFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TargetWimFile.FilterIndex = 0
        Me.TargetWimFile.IsEsdFile = False
        Me.TargetWimFile.Location = New System.Drawing.Point(74, 207)
        Me.TargetWimFile.Name = "TargetWimFile"
        Me.TargetWimFile.ShowAsSaveFileDialog = True
        Me.TargetWimFile.Size = New System.Drawing.Size(512, 24)
        Me.TargetWimFile.TabIndex = 7
        Me.TargetWimFile.WimInfoControl = Nothing
        '
        'WimInfo
        '
        Me.WimInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WimInfo.DropDownWidth = 520
        Me.WimInfo.ImageDescriptionControl = Me.TBImageDescription
        Me.WimInfo.ImageNameControl = Me.TBImageName
        Me.WimInfo.ItemHeightOffset = 6
        Me.WimInfo.Location = New System.Drawing.Point(74, 35)
        Me.WimInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.WimInfo.MaxDropDownItems = 4
        Me.WimInfo.Name = "WimInfo"
        Me.WimInfo.Size = New System.Drawing.Size(511, 24)
        Me.WimInfo.TabIndex = 1
        Me.WimInfo.ToolTipTitle = "导出映像"
        Me.WimInfo.WimFile = ""
        '
        'WimFile
        '
        Me.WimFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WimFile.FilterIndex = 0
        Me.WimFile.IsEsdFile = False
        Me.WimFile.Location = New System.Drawing.Point(74, 8)
        Me.WimFile.Name = "WimFile"
        Me.WimFile.ShowAsSaveFileDialog = False
        Me.WimFile.Size = New System.Drawing.Size(512, 24)
        Me.WimFile.TabIndex = 0
        Me.WimFile.WimInfoControl = Me.WimInfo
        '
        'PanelImageExport
        '
        Me.Controls.Add(Me.ChkWIMBoot)
        Me.Controls.Add(Me.CBCompress)
        Me.Controls.Add(Me.TargetWimFile)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TBTargetImageName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ChkBootable)
        Me.Controls.Add(Me.ChkCheckIntegrity)
        Me.Controls.Add(Me.ChkPushToQueue)
        Me.Controls.Add(Me.BtnExport)
        Me.Controls.Add(Me.TBImageDescription)
        Me.Controls.Add(Me.TBImageName)
        Me.Controls.Add(Me.WimInfo)
        Me.Controls.Add(Me.WimFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Name = "PanelImageExport"
        Me.Size = New System.Drawing.Size(600, 300)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub


    Private Sub ChkPushToQueue_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPushToQueue.CheckedChanged
        DismConfig.SetItem("ExportPushToQueue", ChkPushToQueue.Checked)
        DismConfig.Save()
    End Sub
End Class
