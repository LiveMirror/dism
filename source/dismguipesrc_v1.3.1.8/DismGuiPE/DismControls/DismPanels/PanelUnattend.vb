Public Class PanelUnattend
    Inherits DismPanelBase
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents MountedWimInfo As DismGuiPE.MountedWimInfoComboBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FSUnattendFile As DismGuiPE.FileOrFolderSelector
    Friend WithEvents BtnUnattendApply As System.Windows.Forms.Button
    Friend WithEvents ChkPushToQueue As System.Windows.Forms.CheckBox

    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnLoadConfig()
        FSUnattendFile.Text = DismConfig.GetItem("UnattendFile", "")
        ChkPushToQueue.Checked = DismConfig.GetItem("UnattendPushToQueue", False)
    End Sub

    Protected Overrides Sub OnUpdateInfo(Flags As WimInfoDetail)
        If Flags And WimInfoDetail.MountedWimInfo Then MountedWimInfo.UpdateMountedWimInfo()
    End Sub

    Private Sub BtnUnattendApply_Click(sender As Object, e As EventArgs) Handles BtnUnattendApply.Click
        Dim Image As String = MountedWimInfo.Text.Trim

        If Image = "" Then
            MsgBox("请选择一个映像！", MsgBoxStyle.Critical, "无人参与服务")
            MountedWimInfo.Select()
            Return
        End If

        Dim UnattendFile As String = FSUnattendFile.Text.Trim()

        If Not IO.File.Exists(UnattendFile) Then
            MsgBox("无人参与服务配置文件不存在！", MsgBoxStyle.Critical, "无人参与服务")
            FSUnattendFile.Select()
            Return
        End If

        Dim Args As New DismControlEventArgs(DismShell.CreateUnattendArgumenets(Image, UnattendFile),
                                             DismMissionFlags.ApplyUnattend,
                                             "无人参与服务")
        Args.PushToQueue = ChkPushToQueue.Checked

        DismConfig.SetItem("UnattendFile", UnattendFile)
        DismConfig.Save()

        OnExecute(Args)

    End Sub



    Private Sub InitializeComponent()
        Me.ChkPushToQueue = New System.Windows.Forms.CheckBox()
        Me.BtnUnattendApply = New System.Windows.Forms.Button()
        Me.MountedWimInfo = New DismGuiPE.MountedWimInfoComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FSUnattendFile = New DismGuiPE.FileOrFolderSelector()
        Me.SuspendLayout()
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
        'BtnUnattendApply
        '
        Me.BtnUnattendApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnUnattendApply.Location = New System.Drawing.Point(506, 264)
        Me.BtnUnattendApply.Name = "BtnUnattendApply"
        Me.BtnUnattendApply.Size = New System.Drawing.Size(80, 28)
        Me.BtnUnattendApply.TabIndex = 3
        Me.BtnUnattendApply.Text = "应用"
        Me.BtnUnattendApply.UseVisualStyleBackColor = True
        '
        'MountedWimInfo
        '
        Me.MountedWimInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MountedWimInfo.ItemHeightOffset = 6
        Me.MountedWimInfo.ListSelectedItemDetail = DismGuiPE.WimInfoDetail.None
        Me.MountedWimInfo.Location = New System.Drawing.Point(82, 12)
        Me.MountedWimInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.MountedWimInfo.MaxDropDownItems = 4
        Me.MountedWimInfo.Name = "MountedWimInfo"
        Me.MountedWimInfo.ReadOnly = False
        Me.MountedWimInfo.SelectedIndex = -1
        Me.MountedWimInfo.Size = New System.Drawing.Size(504, 24)
        Me.MountedWimInfo.TabIndex = 0
        Me.MountedWimInfo.ToolTipTitle = "无人参与服务"
        Me.MountedWimInfo.WithOnlineImage = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "已安装映像："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 12)
        Me.Label1.TabIndex = 109
        Me.Label1.Text = "配置文件："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FSUnattendFile
        '
        Me.FSUnattendFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FSUnattendFile.BrowserStyle = DismGuiPE.FileOrFolderBrowserStyle.FileOpen
        Me.FSUnattendFile.CheckFileExists = True
        Me.FSUnattendFile.CheckPathExists = True
        Me.FSUnattendFile.Filter = """XML文件(*.XML)|*.xml|所有文件(*.*)|(*.*)"
        Me.FSUnattendFile.Location = New System.Drawing.Point(82, 39)
        Me.FSUnattendFile.Multiselect = False
        Me.FSUnattendFile.Name = "FSUnattendFile"
        Me.FSUnattendFile.OverwritePrompt = True
        Me.FSUnattendFile.ReadOnly = False
        Me.FSUnattendFile.Size = New System.Drawing.Size(504, 24)
        Me.FSUnattendFile.TabIndex = 1
        '
        'PanelUnattend
        '
        Me.Controls.Add(Me.FSUnattendFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ChkPushToQueue)
        Me.Controls.Add(Me.BtnUnattendApply)
        Me.Controls.Add(Me.MountedWimInfo)
        Me.Controls.Add(Me.Label2)
        Me.Name = "PanelUnattend"
        Me.Size = New System.Drawing.Size(600, 300)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub


    Private Sub ChkPushToQueue_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPushToQueue.CheckedChanged
        DismConfig.SetItem("UnattendPushToQueue", ChkPushToQueue.Checked)
        DismConfig.Save()
    End Sub
End Class
