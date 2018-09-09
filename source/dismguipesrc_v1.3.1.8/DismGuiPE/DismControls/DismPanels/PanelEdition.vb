Public Class PanelEdition
    Inherits DismPanelBase
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents MountedWimInfo As DismGuiPE.MountedWimInfoComboBox
    Private WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CBTargetEditions As System.Windows.Forms.ComboBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TBCurrentEdition As System.Windows.Forms.TextBox
    Private WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TT As System.Windows.Forms.ToolTip
    Private components As System.ComponentModel.IContainer
    Friend WithEvents ChkAcceptEula As System.Windows.Forms.CheckBox
    Friend WithEvents ChkProductKey As System.Windows.Forms.CheckBox
    Friend WithEvents MSKey As DismGuiPE.MSProductKeyBox
    Friend WithEvents BtnSetEdition As System.Windows.Forms.Button
    Friend WithEvents BtnSetProductKey As System.Windows.Forms.Button
    Friend WithEvents ChkPushToQueue As System.Windows.Forms.CheckBox
    Friend WithEvents BtnRefresh As System.Windows.Forms.Button

    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnLoadConfig()
        ChkPushToQueue.Checked = DismConfig.GetItem("EditionPushToQueue", False)
    End Sub

    Protected Overrides Sub OnUpdateInfo(Flags As WimInfoDetail)
        If Flags And WimInfoDetail.MountedWimInfo Then MountedWimInfo.UpdateMountedWimInfo()
        If Flags And WimInfoDetail.Edition Then MountedWimInfo.UpdateSelectedItemDetail()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        MountedWimInfo.UpdateSelectedItemDetail()
    End Sub

    Private Sub MountedWimInfo_UpdateSelectedItemDetailProgress(sender As Object, e As UpdateProgressEventArgs) Handles MountedWimInfo.UpdateSelectedItemDetailProgress
        UpdateControlState(e.IsCompleted)
        OnUpdateProgress(e)
    End Sub

    Private Sub MountedWimInfo_SelectedItemChanged(sender As Object, e As MountedWimInfoComboBoxEventArgs) Handles MountedWimInfo.SelectedItemChanged
        TBCurrentEdition.Text = e.Tag
        CBTargetEditions.DataSource = e.Data
    End Sub

    Private Sub BtnSetEdition_Click(sender As Object, e As EventArgs) Handles BtnSetEdition.Click
        If CBTargetEditions.SelectedIndex = -1 Then
            MsgBox("请选择一个可用的版本！", MsgBoxStyle.Critical, Title)
            CBTargetEditions.Select()
            Return
        End If
        Dim Image As String = MountedWimInfo.Text.Trim
        Dim ProductKey As String = MSKey.Text.Trim()

        Dim Args As New DismControlEventArgs(DismShell.CreateSetEditionArguments(Image,
                                                                        CBTargetEditions.Text,
                                                                        ProductKey,
                                                                        ChkProductKey.Checked,
                                                                        ChkAcceptEula.Checked),
                                            DismMissionFlags.SetEdition,
                                            "设置版本")
        Args.PushToQueue = ChkPushToQueue.Checked
        OnExecute(Args)
    End Sub

    Private Sub BtnSetProductKey_Click(sender As Object, e As EventArgs) Handles BtnSetProductKey.Click
        Dim Image As String = MountedWimInfo.Text.Trim

        Dim ProductKey As String = MSKey.Text.Trim()
        Dim Args As New DismControlEventArgs(DismShell.CreateSetProductKeyArguments(Image, ProductKey),
                                            DismMissionFlags.SetProductKey,
                                            "设置密钥")
        Args.PushToQueue = ChkPushToQueue.Checked
        OnExecute(Args)
    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.BtnRefresh = New System.Windows.Forms.Button()
        Me.ChkPushToQueue = New System.Windows.Forms.CheckBox()
        Me.BtnSetProductKey = New System.Windows.Forms.Button()
        Me.BtnSetEdition = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CBTargetEditions = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TBCurrentEdition = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ChkAcceptEula = New System.Windows.Forms.CheckBox()
        Me.ChkProductKey = New System.Windows.Forms.CheckBox()
        Me.MountedWimInfo = New DismGuiPE.MountedWimInfoComboBox()
        Me.MSKey = New DismGuiPE.MSProductKeyBox()
        Me.SuspendLayout()
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRefresh.Location = New System.Drawing.Point(320, 264)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(80, 28)
        Me.BtnRefresh.TabIndex = 7
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
        Me.ChkPushToQueue.TabIndex = 4
        Me.ChkPushToQueue.Text = "添加到任务队列"
        Me.ChkPushToQueue.UseVisualStyleBackColor = True
        '
        'BtnSetProductKey
        '
        Me.BtnSetProductKey.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSetProductKey.Location = New System.Drawing.Point(506, 264)
        Me.BtnSetProductKey.Name = "BtnSetProductKey"
        Me.BtnSetProductKey.Size = New System.Drawing.Size(80, 28)
        Me.BtnSetProductKey.TabIndex = 9
        Me.BtnSetProductKey.Text = "设置密钥"
        Me.BtnSetProductKey.UseVisualStyleBackColor = True
        '
        'BtnSetEdition
        '
        Me.BtnSetEdition.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSetEdition.Location = New System.Drawing.Point(420, 264)
        Me.BtnSetEdition.Name = "BtnSetEdition"
        Me.BtnSetEdition.Size = New System.Drawing.Size(80, 28)
        Me.BtnSetEdition.TabIndex = 8
        Me.BtnSetEdition.Text = "设置版本"
        Me.BtnSetEdition.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "已安装映像："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(13, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 17)
        Me.Label4.TabIndex = 114
        Me.Label4.Text = "产品密钥："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CBTargetEditions
        '
        Me.CBTargetEditions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CBTargetEditions.DisplayMember = "Edition"
        Me.CBTargetEditions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBTargetEditions.FormattingEnabled = True
        Me.CBTargetEditions.ItemHeight = 12
        Me.CBTargetEditions.Location = New System.Drawing.Point(82, 73)
        Me.CBTargetEditions.Name = "CBTargetEditions"
        Me.CBTargetEditions.Size = New System.Drawing.Size(503, 20)
        Me.CBTargetEditions.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(13, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 17)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "目标版本："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TBCurrentEdition
        '
        Me.TBCurrentEdition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBCurrentEdition.Location = New System.Drawing.Point(82, 44)
        Me.TBCurrentEdition.Name = "TBCurrentEdition"
        Me.TBCurrentEdition.ReadOnly = True
        Me.TBCurrentEdition.Size = New System.Drawing.Size(503, 21)
        Me.TBCurrentEdition.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(13, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 17)
        Me.Label5.TabIndex = 112
        Me.Label5.Text = "当前版本："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TT
        '
        Me.TT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TT.ToolTipTitle = "版本设置"
        '
        'ChkAcceptEula
        '
        Me.ChkAcceptEula.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkAcceptEula.AutoSize = True
        Me.ChkAcceptEula.Location = New System.Drawing.Point(200, 260)
        Me.ChkAcceptEula.Name = "ChkAcceptEula"
        Me.ChkAcceptEula.Size = New System.Drawing.Size(90, 16)
        Me.ChkAcceptEula.TabIndex = 5
        Me.ChkAcceptEula.Text = "/AcceptEula"
        Me.TT.SetToolTip(Me.ChkAcceptEula, "同意更高版本的许可条款。")
        Me.ChkAcceptEula.UseVisualStyleBackColor = True
        '
        'ChkProductKey
        '
        Me.ChkProductKey.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkProductKey.AutoSize = True
        Me.ChkProductKey.Location = New System.Drawing.Point(200, 277)
        Me.ChkProductKey.Name = "ChkProductKey"
        Me.ChkProductKey.Size = New System.Drawing.Size(90, 16)
        Me.ChkProductKey.TabIndex = 6
        Me.ChkProductKey.Text = "/ProductKey"
        Me.TT.SetToolTip(Me.ChkProductKey, "产品密钥")
        Me.ChkProductKey.UseVisualStyleBackColor = True
        '
        'MountedWimInfo
        '
        Me.MountedWimInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MountedWimInfo.ItemHeightOffset = 6
        Me.MountedWimInfo.ListSelectedItemDetail = DismGuiPE.WimInfoDetail.Edition
        Me.MountedWimInfo.Location = New System.Drawing.Point(82, 12)
        Me.MountedWimInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.MountedWimInfo.MaxDropDownItems = 4
        Me.MountedWimInfo.Name = "MountedWimInfo"
        Me.MountedWimInfo.ReadOnly = False
        Me.MountedWimInfo.SelectedIndex = -1
        Me.MountedWimInfo.Size = New System.Drawing.Size(504, 24)
        Me.MountedWimInfo.TabIndex = 0
        Me.MountedWimInfo.ToolTipTitle = "版本设置"
        Me.MountedWimInfo.WithOnlineImage = True
        '
        'MSKey
        '
        Me.MSKey.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MSKey.Location = New System.Drawing.Point(82, 107)
        Me.MSKey.Name = "MSKey"
        Me.MSKey.Size = New System.Drawing.Size(503, 21)
        Me.MSKey.TabIndex = 3
        '
        'PanelEdition
        '
        Me.Controls.Add(Me.MSKey)
        Me.Controls.Add(Me.ChkAcceptEula)
        Me.Controls.Add(Me.ChkProductKey)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CBTargetEditions)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TBCurrentEdition)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtnRefresh)
        Me.Controls.Add(Me.ChkPushToQueue)
        Me.Controls.Add(Me.BtnSetProductKey)
        Me.Controls.Add(Me.BtnSetEdition)
        Me.Controls.Add(Me.MountedWimInfo)
        Me.Controls.Add(Me.Label2)
        Me.Name = "PanelEdition"
        Me.Size = New System.Drawing.Size(600, 300)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub


    Private Sub ChkPushToQueue_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPushToQueue.CheckedChanged
        DismConfig.SetItem("EditionPushToQueue", ChkPushToQueue.Checked)
        DismConfig.Save()
    End Sub
End Class
