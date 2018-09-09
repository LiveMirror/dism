Public Class PanelCleanup
    Inherits DismPanelBase
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents MountedWimInfo As DismGuiPE.MountedWimInfoComboBox
    Friend WithEvents ChkHideSP As System.Windows.Forms.CheckBox
    Friend WithEvents RBSPSuperseded As System.Windows.Forms.RadioButton
    Friend WithEvents ChkSource As System.Windows.Forms.CheckBox
    Friend WithEvents RBRestoreHealth As System.Windows.Forms.RadioButton
    Friend WithEvents RBScanHealth As System.Windows.Forms.RadioButton
    Friend WithEvents RBStartComponentCleanup As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RBCheckHealth As System.Windows.Forms.RadioButton
    Friend WithEvents ChkResetBase As System.Windows.Forms.CheckBox
    Friend WithEvents RBRevertPendingActions As System.Windows.Forms.RadioButton
    Friend WithEvents RBAnalyzeComponentStore As System.Windows.Forms.RadioButton
    Friend WithEvents FSSource As DismGuiPE.FileOrFolderSelector
    Friend WithEvents BtnExecute As System.Windows.Forms.Button
    Friend WithEvents ChkPushToQueue As System.Windows.Forms.CheckBox

    Private Sub InitializeComponent()
        Me.ChkHideSP = New System.Windows.Forms.CheckBox()
        Me.RBSPSuperseded = New System.Windows.Forms.RadioButton()
        Me.ChkSource = New System.Windows.Forms.CheckBox()
        Me.RBRestoreHealth = New System.Windows.Forms.RadioButton()
        Me.RBScanHealth = New System.Windows.Forms.RadioButton()
        Me.RBStartComponentCleanup = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RBCheckHealth = New System.Windows.Forms.RadioButton()
        Me.ChkResetBase = New System.Windows.Forms.CheckBox()
        Me.RBRevertPendingActions = New System.Windows.Forms.RadioButton()
        Me.RBAnalyzeComponentStore = New System.Windows.Forms.RadioButton()
        Me.ChkPushToQueue = New System.Windows.Forms.CheckBox()
        Me.BtnExecute = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MountedWimInfo = New DismGuiPE.MountedWimInfoComboBox()
        Me.FSSource = New DismGuiPE.FileOrFolderSelector()
        Me.SuspendLayout()
        '
        'ChkHideSP
        '
        Me.ChkHideSP.AutoSize = True
        Me.ChkHideSP.Enabled = False
        Me.ChkHideSP.Location = New System.Drawing.Point(56, 240)
        Me.ChkHideSP.Name = "ChkHideSP"
        Me.ChkHideSP.Size = New System.Drawing.Size(378, 16)
        Me.ChkHideSP.TabIndex = 11
        Me.ChkHideSP.Text = "/HideSP 可阻止在操作系统的""已安装更新""中列出 Service Pack。"
        Me.ChkHideSP.UseVisualStyleBackColor = True
        '
        'RBSPSuperseded
        '
        Me.RBSPSuperseded.AutoSize = True
        Me.RBSPSuperseded.Location = New System.Drawing.Point(39, 218)
        Me.RBSPSuperseded.Name = "RBSPSuperseded"
        Me.RBSPSuperseded.Size = New System.Drawing.Size(407, 16)
        Me.RBSPSuperseded.TabIndex = 10
        Me.RBSPSuperseded.Text = "/SPSuperseded 可删除在 Service Pack 安装期间创建的所有备份文件。"
        Me.RBSPSuperseded.UseVisualStyleBackColor = True
        '
        'ChkSource
        '
        Me.ChkSource.AutoSize = True
        Me.ChkSource.Enabled = False
        Me.ChkSource.Location = New System.Drawing.Point(55, 152)
        Me.ChkSource.Name = "ChkSource"
        Me.ChkSource.Size = New System.Drawing.Size(120, 16)
        Me.ChkSource.TabIndex = 6
        Me.ChkSource.Text = "/Source 恢复源："
        Me.ChkSource.UseVisualStyleBackColor = True
        '
        'RBRestoreHealth
        '
        Me.RBRestoreHealth.AutoSize = True
        Me.RBRestoreHealth.Location = New System.Drawing.Point(39, 128)
        Me.RBRestoreHealth.Name = "RBRestoreHealth"
        Me.RBRestoreHealth.Size = New System.Drawing.Size(431, 16)
        Me.RBRestoreHealth.TabIndex = 5
        Me.RBRestoreHealth.Text = "/RestoreHealth 可扫描映像是否存在组件存储损坏,然后自动执行修复操作。"
        Me.RBRestoreHealth.UseVisualStyleBackColor = True
        '
        'RBScanHealth
        '
        Me.RBScanHealth.AutoSize = True
        Me.RBScanHealth.Location = New System.Drawing.Point(39, 108)
        Me.RBScanHealth.Name = "RBScanHealth"
        Me.RBScanHealth.Size = New System.Drawing.Size(287, 16)
        Me.RBScanHealth.TabIndex = 4
        Me.RBScanHealth.Text = "/ScanHealth 可扫描映像是否存在组件存储损坏。"
        Me.RBScanHealth.UseVisualStyleBackColor = True
        '
        'RBStartComponentCleanup
        '
        Me.RBStartComponentCleanup.AutoSize = True
        Me.RBStartComponentCleanup.Location = New System.Drawing.Point(39, 174)
        Me.RBStartComponentCleanup.Name = "RBStartComponentCleanup"
        Me.RBStartComponentCleanup.Size = New System.Drawing.Size(269, 16)
        Me.RBStartComponentCleanup.TabIndex = 8
        Me.RBStartComponentCleanup.Text = "/StartComponentCleanup 清理被取代的组件。"
        Me.RBStartComponentCleanup.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(272, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(307, 16)
        Me.Label1.TabIndex = 117
        Me.Label1.Text = "警告! 只应对无法启动的 Windows 映像执行恢复操作。"
        '
        'RBCheckHealth
        '
        Me.RBCheckHealth.AutoSize = True
        Me.RBCheckHealth.Location = New System.Drawing.Point(39, 86)
        Me.RBCheckHealth.Name = "RBCheckHealth"
        Me.RBCheckHealth.Size = New System.Drawing.Size(473, 16)
        Me.RBCheckHealth.TabIndex = 3
        Me.RBCheckHealth.Text = "/CheckHealth 可检查映像是否标记为由于进程失败而损坏以及是否能够修复该损坏。"
        Me.RBCheckHealth.UseVisualStyleBackColor = True
        '
        'ChkResetBase
        '
        Me.ChkResetBase.AutoSize = True
        Me.ChkResetBase.Enabled = False
        Me.ChkResetBase.Location = New System.Drawing.Point(56, 196)
        Me.ChkResetBase.Name = "ChkResetBase"
        Me.ChkResetBase.Size = New System.Drawing.Size(414, 16)
        Me.ChkResetBase.TabIndex = 9
        Me.ChkResetBase.Text = "/ResetBase 可重置被取代的基本组件，这可进一步减小组件存储的大小。"
        Me.ChkResetBase.UseVisualStyleBackColor = True
        '
        'RBRevertPendingActions
        '
        Me.RBRevertPendingActions.AutoSize = True
        Me.RBRevertPendingActions.Location = New System.Drawing.Point(39, 64)
        Me.RBRevertPendingActions.Name = "RBRevertPendingActions"
        Me.RBRevertPendingActions.Size = New System.Drawing.Size(227, 16)
        Me.RBRevertPendingActions.TabIndex = 2
        Me.RBRevertPendingActions.Text = "/RevertPendingActions 执行恢复操作"
        Me.RBRevertPendingActions.UseVisualStyleBackColor = True
        '
        'RBAnalyzeComponentStore
        '
        Me.RBAnalyzeComponentStore.AutoSize = True
        Me.RBAnalyzeComponentStore.Checked = True
        Me.RBAnalyzeComponentStore.Location = New System.Drawing.Point(39, 42)
        Me.RBAnalyzeComponentStore.Name = "RBAnalyzeComponentStore"
        Me.RBAnalyzeComponentStore.Size = New System.Drawing.Size(359, 16)
        Me.RBAnalyzeComponentStore.TabIndex = 1
        Me.RBAnalyzeComponentStore.TabStop = True
        Me.RBAnalyzeComponentStore.Text = "/AnalyzeComponentStore 分析组件库（WinSxS 文件夹）的大小"
        Me.RBAnalyzeComponentStore.UseVisualStyleBackColor = True
        '
        'ChkPushToQueue
        '
        Me.ChkPushToQueue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkPushToQueue.AutoSize = True
        Me.ChkPushToQueue.Location = New System.Drawing.Point(13, 270)
        Me.ChkPushToQueue.Name = "ChkPushToQueue"
        Me.ChkPushToQueue.Size = New System.Drawing.Size(108, 16)
        Me.ChkPushToQueue.TabIndex = 12
        Me.ChkPushToQueue.Text = "添加到任务队列"
        Me.ChkPushToQueue.UseVisualStyleBackColor = True
        '
        'BtnExecute
        '
        Me.BtnExecute.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExecute.Location = New System.Drawing.Point(506, 264)
        Me.BtnExecute.Name = "BtnExecute"
        Me.BtnExecute.Size = New System.Drawing.Size(80, 28)
        Me.BtnExecute.TabIndex = 13
        Me.BtnExecute.Text = "执行"
        Me.BtnExecute.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "已安装映像："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.MountedWimInfo.ToolTipTitle = "组件库管理"
        Me.MountedWimInfo.WithOnlineImage = True
        '
        'FSSource
        '
        Me.FSSource.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FSSource.BrowserStyle = DismGuiPE.FileOrFolderBrowserStyle.Folder
        Me.FSSource.CheckFileExists = True
        Me.FSSource.CheckPathExists = True
        Me.FSSource.Enabled = False
        Me.FSSource.Filter = ""
        Me.FSSource.Location = New System.Drawing.Point(165, 149)
        Me.FSSource.Multiselect = False
        Me.FSSource.Name = "FSSource"
        Me.FSSource.OverwritePrompt = True
        Me.FSSource.ReadOnly = False
        Me.FSSource.Size = New System.Drawing.Size(421, 24)
        Me.FSSource.TabIndex = 7
        '
        'PanelCleanup
        '
        Me.Controls.Add(Me.FSSource)
        Me.Controls.Add(Me.ChkHideSP)
        Me.Controls.Add(Me.RBSPSuperseded)
        Me.Controls.Add(Me.ChkSource)
        Me.Controls.Add(Me.RBRestoreHealth)
        Me.Controls.Add(Me.RBScanHealth)
        Me.Controls.Add(Me.RBStartComponentCleanup)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RBCheckHealth)
        Me.Controls.Add(Me.ChkResetBase)
        Me.Controls.Add(Me.RBRevertPendingActions)
        Me.Controls.Add(Me.RBAnalyzeComponentStore)
        Me.Controls.Add(Me.ChkPushToQueue)
        Me.Controls.Add(Me.BtnExecute)
        Me.Controls.Add(Me.MountedWimInfo)
        Me.Controls.Add(Me.Label2)
        Me.Name = "PanelCleanup"
        Me.Size = New System.Drawing.Size(600, 300)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnLoadConfig()
        FSSource.Text = DismConfig.GetItem("CleanupRestoreSource", "")
        ChkPushToQueue.Checked = DismConfig.GetItem("CleanupPushToQueue", False)
    End Sub

    Protected Overrides Sub OnUpdateInfo(Flags As WimInfoDetail)
        If Flags And WimInfoDetail.MountedWimInfo Then MountedWimInfo.UpdateMountedWimInfo()
    End Sub

    Private Sub BtnExecute_Click(sender As Object, e As EventArgs) Handles BtnExecute.Click

        Dim Temp As String = ""

        Dim Image As String = MountedWimInfo.Text.Trim()

        Dim HM As Integer = 0

        If RBRestoreHealth.Checked AndAlso ChkSource.Checked AndAlso (Not IO.Directory.Exists(FSSource.Text.Trim())) Then
            MsgBox("请选择一个恢复源！", MsgBoxStyle.Critical, Title)
            FSSource.Select()
            Return
        End If

        Temp = IIf(Image.StartsWith("/"), Image, "/Image:" & DismShell.FixPath(Image)) & " /Cleanup-Image"

        If RBAnalyzeComponentStore.Checked Then
            Temp = Temp & " /AnalyzeComponentStore"
            HM = 1
        End If

        If RBRevertPendingActions.Checked Then
            Temp = Temp & " /RevertPendingActions"
            HM = 1
        End If

        If RBCheckHealth.Checked Then
            Temp = Temp & " /CheckHealth"
            HM = 1
        End If

        If RBScanHealth.Checked Then
            Temp = Temp & " /ScanHealth"
            HM = 1
        End If

        If RBRestoreHealth.Checked Then
            Temp = Temp & " /RestoreHealth"
            If ChkSource.Checked Then
                Temp = Temp & " /Source:" & DismShell.FixPath(FSSource.Text.Trim)
            End If
        End If

        If RBStartComponentCleanup.Checked Then
            Temp = Temp & " /StartComponentCleanup"
            If ChkResetBase.Checked Then Temp = Temp & " /ResetBase"
        End If

        If RBSPSuperseded.Checked Then
            Temp = Temp & " /SPSuperseded"
            If ChkHideSP.Checked Then Temp = Temp & " /HideSP"
        End If

        Dim Args As New DismControlEventArgs(Temp, DismMissionFlags.CleanupImage, Title, HM)

        Args.PushToQueue = ChkPushToQueue.Checked

        DismConfig.SetItem("CleanupRestoreSource", FSSource.Text.Trim)
        DismConfig.Save()

        OnExecute(Args)

    End Sub

    Private Sub ChkPushToQueue_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPushToQueue.CheckedChanged
        DismConfig.SetItem("CleanupPushToQueue", ChkPushToQueue.Checked)
        DismConfig.Save()
    End Sub

    Private Sub RBRestoreHealth_CheckedChanged(sender As Object, e As EventArgs) Handles RBRestoreHealth.CheckedChanged
        ChkSource.Enabled = RBRestoreHealth.Checked
        FSSource.Enabled = RBRestoreHealth.Checked
    End Sub

    Private Sub RBStartComponentCleanup_CheckedChanged(sender As Object, e As EventArgs) Handles RBStartComponentCleanup.CheckedChanged
        ChkResetBase.Enabled = RBStartComponentCleanup.Checked
    End Sub

    Private Sub RBSPSuperseded_CheckedChanged(sender As Object, e As EventArgs) Handles RBSPSuperseded.CheckedChanged
        ChkHideSP.Enabled = RBSPSuperseded.Checked
    End Sub
End Class
