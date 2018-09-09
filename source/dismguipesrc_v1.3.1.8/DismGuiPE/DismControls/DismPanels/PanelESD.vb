Imports System.Threading
Public Class PanelESD
    Inherits DismPanelBase
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FSTemp As DismGuiPE.FileOrFolderSelector
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents EsdFile As DismGuiPE.WimFileSelector
    Private WithEvents WimInfo As DismGuiPE.WimInfoComboBox
    Private WithEvents TBImageName As System.Windows.Forms.TextBox
    Private WithEvents TargetWimFile As DismGuiPE.WimFileSelector
    Private WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtnConvert As System.Windows.Forms.Button
    Friend WithEvents BtnConvertAll As System.Windows.Forms.Button
    Friend WithEvents ChkBackup As System.Windows.Forms.CheckBox
    Private WithEvents TBImageDescription As System.Windows.Forms.TextBox
    Private Total As Long = 0
    Friend WithEvents BtnDecrypt As System.Windows.Forms.Button
    Private Current As Long = 0
    Private WithEvents TT As System.Windows.Forms.ToolTip
    Private components As System.ComponentModel.IContainer
    Private WithEvents ChkBootable As System.Windows.Forms.CheckBox
    Private WithEvents ChkCheckIntegrity As System.Windows.Forms.CheckBox
    Private WithEvents CBCompress As System.Windows.Forms.ComboBox
    Private WithEvents Label6 As System.Windows.Forms.Label
    Private EsdDecryptorPath As String = Application.StartupPath & IIf(Application.StartupPath.EndsWith("\"), "", "\") & "Tools\Internal\EsdDecryptor.exe"

    Private Delegate Sub FileCopyProgress(Total As Long, Current As Long)

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.BtnConvert = New System.Windows.Forms.Button()
        Me.TargetWimFile = New DismGuiPE.WimFileSelector()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.FSTemp = New DismGuiPE.FileOrFolderSelector()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TBImageDescription = New System.Windows.Forms.TextBox()
        Me.TBImageName = New System.Windows.Forms.TextBox()
        Me.WimInfo = New DismGuiPE.WimInfoComboBox()
        Me.EsdFile = New DismGuiPE.WimFileSelector()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnConvertAll = New System.Windows.Forms.Button()
        Me.ChkBackup = New System.Windows.Forms.CheckBox()
        Me.BtnDecrypt = New System.Windows.Forms.Button()
        Me.TT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ChkBootable = New System.Windows.Forms.CheckBox()
        Me.ChkCheckIntegrity = New System.Windows.Forms.CheckBox()
        Me.CBCompress = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BtnConvert
        '
        Me.BtnConvert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConvert.Location = New System.Drawing.Point(506, 264)
        Me.BtnConvert.Name = "BtnConvert"
        Me.BtnConvert.Size = New System.Drawing.Size(80, 28)
        Me.BtnConvert.TabIndex = 120
        Me.BtnConvert.Text = "转换"
        Me.BtnConvert.UseVisualStyleBackColor = True
        '
        'TargetWimFile
        '
        Me.TargetWimFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TargetWimFile.FilterIndex = 0
        Me.TargetWimFile.IsEsdFile = False
        Me.TargetWimFile.Location = New System.Drawing.Point(72, 228)
        Me.TargetWimFile.Name = "TargetWimFile"
        Me.TargetWimFile.ShowAsSaveFileDialog = True
        Me.TargetWimFile.Size = New System.Drawing.Size(514, 24)
        Me.TargetWimFile.TabIndex = 116
        Me.TargetWimFile.WimInfoControl = Nothing
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.Location = New System.Drawing.Point(11, 234)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 119
        Me.Label7.Text = "目标文件："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FSTemp
        '
        Me.FSTemp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FSTemp.BrowserStyle = DismGuiPE.FileOrFolderBrowserStyle.Folder
        Me.FSTemp.CheckFileExists = True
        Me.FSTemp.CheckPathExists = True
        Me.FSTemp.Filter = ""
        Me.FSTemp.Location = New System.Drawing.Point(72, 198)
        Me.FSTemp.Multiselect = False
        Me.FSTemp.Name = "FSTemp"
        Me.FSTemp.OverwritePrompt = True
        Me.FSTemp.ReadOnly = False
        Me.FSTemp.Size = New System.Drawing.Size(514, 24)
        Me.FSTemp.TabIndex = 108
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(11, 198)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 19)
        Me.Label2.TabIndex = 107
        Me.Label2.Text = "临时目录："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TBImageDescription
        '
        Me.TBImageDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBImageDescription.Location = New System.Drawing.Point(72, 93)
        Me.TBImageDescription.Multiline = True
        Me.TBImageDescription.Name = "TBImageDescription"
        Me.TBImageDescription.ReadOnly = True
        Me.TBImageDescription.Size = New System.Drawing.Size(513, 77)
        Me.TBImageDescription.TabIndex = 102
        '
        'TBImageName
        '
        Me.TBImageName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBImageName.Location = New System.Drawing.Point(72, 68)
        Me.TBImageName.Name = "TBImageName"
        Me.TBImageName.ReadOnly = True
        Me.TBImageName.Size = New System.Drawing.Size(513, 21)
        Me.TBImageName.TabIndex = 101
        '
        'WimInfo
        '
        Me.WimInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WimInfo.DropDownWidth = 522
        Me.WimInfo.ImageDescriptionControl = Me.TBImageDescription
        Me.WimInfo.ImageNameControl = Me.TBImageName
        Me.WimInfo.ItemHeightOffset = 6
        Me.WimInfo.Location = New System.Drawing.Point(72, 40)
        Me.WimInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.WimInfo.MaxDropDownItems = 4
        Me.WimInfo.Name = "WimInfo"
        Me.WimInfo.Size = New System.Drawing.Size(514, 24)
        Me.WimInfo.TabIndex = 100
        Me.WimInfo.ToolTipTitle = ".ESD 转换为 .WIM"
        Me.WimInfo.WimFile = ""
        '
        'EsdFile
        '
        Me.EsdFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EsdFile.FilterIndex = 0
        Me.EsdFile.IsEsdFile = True
        Me.EsdFile.Location = New System.Drawing.Point(72, 13)
        Me.EsdFile.Name = "EsdFile"
        Me.EsdFile.ShowAsSaveFileDialog = False
        Me.EsdFile.Size = New System.Drawing.Size(514, 24)
        Me.EsdFile.TabIndex = 99
        Me.EsdFile.WimInfoControl = Me.WimInfo
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(11, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = ".ESD文件："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(11, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 106
        Me.Label5.Text = "映像描述："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(11, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 105
        Me.Label4.Text = "映像名称："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(11, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "映像索引："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnConvertAll
        '
        Me.BtnConvertAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConvertAll.Location = New System.Drawing.Point(420, 264)
        Me.BtnConvertAll.Name = "BtnConvertAll"
        Me.BtnConvertAll.Size = New System.Drawing.Size(80, 28)
        Me.BtnConvertAll.TabIndex = 121
        Me.BtnConvertAll.Text = "全部转换"
        Me.BtnConvertAll.UseVisualStyleBackColor = True
        '
        'ChkBackup
        '
        Me.ChkBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkBackup.AutoSize = True
        Me.ChkBackup.Location = New System.Drawing.Point(13, 271)
        Me.ChkBackup.Name = "ChkBackup"
        Me.ChkBackup.Size = New System.Drawing.Size(144, 16)
        Me.ChkBackup.TabIndex = 122
        Me.ChkBackup.Text = "转换前备份 .ESD 文件"
        Me.ChkBackup.UseVisualStyleBackColor = True
        '
        'BtnDecrypt
        '
        Me.BtnDecrypt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDecrypt.Location = New System.Drawing.Point(311, 264)
        Me.BtnDecrypt.Name = "BtnDecrypt"
        Me.BtnDecrypt.Size = New System.Drawing.Size(80, 28)
        Me.BtnDecrypt.TabIndex = 123
        Me.BtnDecrypt.Text = "仅解密文件"
        Me.BtnDecrypt.UseVisualStyleBackColor = True
        '
        'TT
        '
        Me.TT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TT.ToolTipTitle = ".ESD 转换为 .WIM"
        '
        'ChkBootable
        '
        Me.ChkBootable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkBootable.AutoSize = True
        Me.ChkBootable.Location = New System.Drawing.Point(388, 177)
        Me.ChkBootable.Name = "ChkBootable"
        Me.ChkBootable.Size = New System.Drawing.Size(78, 16)
        Me.ChkBootable.TabIndex = 124
        Me.ChkBootable.Text = "/Bootable"
        Me.TT.SetToolTip(Me.ChkBootable, "将 Windows PE 卷映像标记为能够引导。")
        Me.ChkBootable.UseVisualStyleBackColor = True
        '
        'ChkCheckIntegrity
        '
        Me.ChkCheckIntegrity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkCheckIntegrity.AutoSize = True
        Me.ChkCheckIntegrity.Location = New System.Drawing.Point(472, 177)
        Me.ChkCheckIntegrity.Name = "ChkCheckIntegrity"
        Me.ChkCheckIntegrity.Size = New System.Drawing.Size(114, 16)
        Me.ChkCheckIntegrity.TabIndex = 125
        Me.ChkCheckIntegrity.Text = "/CheckIntegrity"
        Me.TT.SetToolTip(Me.ChkCheckIntegrity, "检测和跟踪 WIM 文件是否损坏。")
        Me.ChkCheckIntegrity.UseVisualStyleBackColor = True
        '
        'CBCompress
        '
        Me.CBCompress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CBCompress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBCompress.FormattingEnabled = True
        Me.CBCompress.Items.AddRange(New Object() {"无（None）", "快速（Fast）", "最大压缩（Max）"})
        Me.CBCompress.Location = New System.Drawing.Point(72, 175)
        Me.CBCompress.Name = "CBCompress"
        Me.CBCompress.Size = New System.Drawing.Size(180, 20)
        Me.CBCompress.TabIndex = 126
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.Location = New System.Drawing.Point(11, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 17)
        Me.Label6.TabIndex = 127
        Me.Label6.Text = "压缩率："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PanelESD
        '
        Me.Controls.Add(Me.CBCompress)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ChkBootable)
        Me.Controls.Add(Me.ChkCheckIntegrity)
        Me.Controls.Add(Me.BtnDecrypt)
        Me.Controls.Add(Me.ChkBackup)
        Me.Controls.Add(Me.BtnConvertAll)
        Me.Controls.Add(Me.BtnConvert)
        Me.Controls.Add(Me.TargetWimFile)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.FSTemp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TBImageDescription)
        Me.Controls.Add(Me.TBImageName)
        Me.Controls.Add(Me.WimInfo)
        Me.Controls.Add(Me.EsdFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Name = "PanelESD"
        Me.Size = New System.Drawing.Size(600, 300)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Protected Overrides Sub OnLoadConfig()
        CBCompress.Text = DismConfig.GetItem("EsdCompress", "快速（Fast）")
        EsdFile.Text = DismConfig.GetItem("EsdFile", "")
        FSTemp.Text = DismConfig.GetItem("EsdTemplate", "")
        ChkBackup.Checked = DismConfig.GetItem("EsdBackup", True)
        'ChkWIMBoot.Checked = DismConfig.GetItem("EsdWIMBoot", False)
        ChkBootable.Checked = DismConfig.GetItem("EsdBootable", False)
        ChkCheckIntegrity.Checked = DismConfig.GetItem("EsdCheckIntegrity", False)
        'ChkVerify.Checked = DismConfig.GetItem("EsdVerify", False)
        'ChkNoRpFix.Checked = DismConfig.GetItem("EsdNoRpFix", False)
        TargetWimFile.Text = DismConfig.GetItem("EsdTargetFile", "")
    End Sub

    Protected Overrides Sub OnUpdateInfo(Flags As WimInfoDetail)
        If Flags And WimInfoDetail.WimInfo Then WimInfo.UpdateWimInfo()
    End Sub

    Private Sub BtnDecrypt_Click(sender As Object, e As EventArgs) Handles BtnDecrypt.Click

        Dim eFile As String = EsdFile.Text.Trim()
        If Not IO.File.Exists(eFile) Then
            MsgBox("请选择一个 .ESD 文件。", MsgBoxStyle.Critical, Title)
            Return
        End If

        Dim ia As New EsdAsyncObject
        ia.EsdFile = eFile
        ia.Backup = ChkBackup.Checked

        DismConfig.SetItem("EsdFile", EsdFile.Text.Trim)
        DismConfig.SetItem("EsdBackup", ChkBackup.Checked)
        DismConfig.Save()

        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf DecryptOnlyProc), ia)

    End Sub

    Private Sub BtnConvertAll_Click(sender As Object, e As EventArgs) Handles BtnConvertAll.Click
        Dim eFile As String = EsdFile.Text.Trim()
        Dim wFile As String = TargetWimFile.Text.Trim()
        Dim Index As Integer = 0
        Dim iName As String = TBImageName.Text
        Dim iDesc As String = TBImageDescription.Text
        Dim IsCreate As Boolean = False
        Integer.TryParse(WimInfo.Text.Trim, Index)
        Dim TempDir As String = FSTemp.Text.Trim()

        If Not IO.File.Exists(eFile) Then
            MsgBox("请选择一个 .ESD 文件。", MsgBoxStyle.Critical, Title)
            Return
        End If

        If WimInfo.Count = 0 Then
            MsgBox("无效的 .ESD 文件。", MsgBoxStyle.Critical, Title)
            Return
        End If

        If Not IO.Directory.Exists(TempDir) Then
            MsgBox("临时目录为空或者不存在。", MsgBoxStyle.Critical, Title)
            Return
        End If

        If wFile = "" Then
            MsgBox("目标文件路径不能为空。", MsgBoxStyle.Critical, Title)
            Return
        End If

        If IO.File.Exists(wFile) Then
            Dim Result As MsgBoxResult = MsgBox("目标文件已存在。是否要覆盖它？" & vbCrLf & vbCrLf &
                                                "    选择 [ 是 ] 覆盖该文件" & vbCrLf &
                                                "    选择 [ 否 ] 追加到该文件中", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.DefaultButton3, Title)
            If Result = MsgBoxResult.Cancel Then Return
            IsCreate = (Result = MsgBoxResult.Yes)
        End If

        Dim Compress As String = ""

        Select Case CBCompress.SelectedIndex
            Case 0
                Compress = "None"
            Case 1
                Compress = "Fast"
            Case 2
                Compress = "Max"
            Case Else
                Compress = "Fast"
        End Select

        DismConfig.SetItem("EsdFile", EsdFile.Text.Trim)
        DismConfig.SetItem("EsdTemplate", FSTemp.Text.Trim)
        DismConfig.SetItem("EsdBackup", ChkBackup.Checked)
        DismConfig.SetItem("EsdTargetFile", TargetWimFile.Text.Trim)
        DismConfig.SetItem("EsdBootable", ChkBootable.Checked)
        DismConfig.SetItem("EsdCheckIntegrity", ChkCheckIntegrity.Checked)
        DismConfig.SetItem("EsdCompress", CBCompress.Text.Trim())
        DismConfig.Save()

        Dim ia As New EsdAsyncObject
        With ia
            .EsdFile = eFile
            .Index = Index
            .Bootable = ChkBootable.Checked
            .Compress = Compress
            .CheckIntegrity = ChkCheckIntegrity.Checked
            .Backup = ChkBackup.Checked
            .ImageInfo = WimInfo.DataSource
            .Descritpion = iDesc
            .IsCreate = IsCreate
            .Name = iName
            .TargetFile = wFile
            .Template = TempDir
        End With


        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf EsdConvertProc), ia)
    End Sub

    Private Sub BtnConvert_Click(sender As Object, e As EventArgs) Handles BtnConvert.Click
        Dim eFile As String = EsdFile.Text.Trim()
        Dim wFile As String = TargetWimFile.Text.Trim()
        Dim Index As Integer = 0
        Dim iName As String = TBImageName.Text
        Dim iDesc As String = TBImageDescription.Text
        Dim IsCreate As Boolean = False

        Integer.TryParse(WimInfo.Text.Trim, Index)
        Dim TempDir As String = FSTemp.Text.Trim()

        If Not IO.File.Exists(eFile) Then
            MsgBox("请选择一个 .ESD 文件。", MsgBoxStyle.Critical, Title)
            Return
        End If

        If Index = 0 Then
            MsgBox("请选择一个映像索引。", MsgBoxStyle.Critical, Title)
            Return
        End If

        If Not IO.Directory.Exists(TempDir) Then
            MsgBox("临时目录为空或者不存在。", MsgBoxStyle.Critical, Title)
            Return
        End If

        If wFile = "" Then
            MsgBox("目标文件路径不能为空。", MsgBoxStyle.Critical, Title)
            Return
        End If


        If IO.File.Exists(wFile) Then
            Dim Result As MsgBoxResult = MsgBox("目标文件已存在。是否要覆盖它？" & vbCrLf & vbCrLf &
                                                "    选择 [ 是 ] 覆盖该文件" & vbCrLf &
                                                "    选择 [ 否 ] 追加到该文件中", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.DefaultButton3, Title)
            If Result = MsgBoxResult.Cancel Then Return
            IsCreate = (Result = MsgBoxResult.Yes)
        End If

        Dim Compress As String = ""

        Select Case CBCompress.SelectedIndex
            Case 0
                Compress = "None"
            Case 1
                Compress = "Fast"
            Case 2
                Compress = "Max"
            Case Else
                Compress = "Fast"
        End Select

        DismConfig.SetItem("EsdFile", EsdFile.Text.Trim)
        DismConfig.SetItem("EsdTemplate", FSTemp.Text.Trim)
        DismConfig.SetItem("EsdBackup", ChkBackup.Checked)
        DismConfig.SetItem("EsdTargetFile", TargetWimFile.Text.Trim)
        DismConfig.SetItem("EsdBootable", ChkBootable.Checked)
        DismConfig.SetItem("EsdCheckIntegrity", ChkCheckIntegrity.Checked)
        DismConfig.SetItem("EsdCompress", CBCompress.Text.Trim())
        DismConfig.Save()

        Dim ia As New EsdAsyncObject
        With ia
            .EsdFile = eFile
            .Index = Index
            .Bootable = ChkBootable.Checked
            .Compress = Compress
            .CheckIntegrity = ChkCheckIntegrity.Checked
            .Backup = ChkBackup.Checked
            .Descritpion = iDesc
            .IsCreate = IsCreate
            .Name = iName
            .TargetFile = wFile
            .Template = TempDir
        End With


        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf EsdConvertProc), ia)
    End Sub

    ''' <summary>
    ''' 只解密 .ESD 文件.
    ''' </summary>
    ''' <param name="p"></param>
    ''' <remarks></remarks>
    Private Sub DecryptOnlyProc(p As EsdAsyncObject)

        UpdateControlState(False)
        OnUpdateProgress(False)

        Dim e As New DismControlEventArgs With {.Mission = DismMissionFlags.PostMessage}
        e.Message = "正在解密 .ESD 文件..."
        OnExecute(e)
        Dim Temp As String = ""
        If p.Backup Then
            Temp = p.EsdFile & ".bck"
            If Not IO.File.Exists(Temp) Then
                e.Message = "正在备份 .ESD 文件..."
                OnExecute(e)
                If CheckBackup(p.EsdFile) = 0 Then
                    If Kernel32.CopyFileEx(p.EsdFile, Temp, AddressOf CopyProgressRoutine, IntPtr.Zero, False, 0) Then
                        e.Message = "备份 .ESD 文件成功."
                    Else
                        e.Message = "备份 .ESD 文件失败."
                    End If
                Else
                    e.Message = "没有足够的空间或者可用空间不可知. 备份 .ESD 文件失败."
                End If
                OnExecute(e)
                OnUpdateProgress(New UpdateProgressEventArgs(0, 100) With {.IsLoop = False, .IsCompleted = True})
            End If
        End If


        If Not IO.File.Exists(EsdDecryptorPath) Then
            e.Message = "缺少解密工具." & EsdDecryptorPath
            OnExecute(e)
            e.Message = "解密 .ESD 文件失败！"
            OnExecute(e)
            UpdateControlState(True)
            OnUpdateProgress(True)
            Return
        End If

        Dim ExitCode As Integer = Decrypt(EsdDecryptorPath, p.EsdFile)

        If ExitCode = 0 Then
            e.Message = "解密 .ESD 文件成功."
        Else
            e.Message = ".ESD 文件已经解密过 或 根本没有加密 又或 解密失败.ExitCode = 0x" & String.Format("{0:X8}", ExitCode)
        End If

        OnExecute(e)
        UpdateControlState(True)
        OnUpdateProgress(True)

    End Sub

    ''' <summary>
    ''' 将 .ESD 文件的映像都转为 .WIM 映像
    ''' </summary>
    ''' <param name="p"></param>
    ''' <remarks></remarks>
    Private Sub EsdConvertProc(p As EsdAsyncObject)
        UpdateControlState(False)
        OnUpdateProgress(False)
        Dim e As New DismControlEventArgs With {.Mission = DismMissionFlags.PostMessage}
        e.Message = "正在将 .ESD 文件转换为 .WIM 文件..."
        OnExecute(e)
        Dim Temp As String = p.EsdFile & ".bck"

        If p.Backup Then
            Temp = p.EsdFile & ".bck"
            If Not IO.File.Exists(Temp) Then
                e.Message = "正在备份 .ESD 文件..."
                OnExecute(e)
                If CheckBackup(p.EsdFile) = 0 Then
                    If Kernel32.CopyFileEx(p.EsdFile, Temp, AddressOf CopyProgressRoutine, IntPtr.Zero, False, 0) Then
                        e.Message = "备份 .ESD 文件成功."
                    Else
                        e.Message = "备份 .ESD 文件失败."
                    End If
                Else
                    e.Message = "没有足够的空间或者可用空间不可知. 备份 .ESD 文件失败."
                End If
                OnExecute(e)
                OnUpdateProgress(New UpdateProgressEventArgs(0, 100) With {.IsLoop = False, .IsCompleted = True})
            End If
        End If

        e.Message = "正在解密 .ESD 文件..."
        OnExecute(e)


        If Not IO.File.Exists(EsdDecryptorPath) Then
            e.Message = "缺少解密工具." & EsdDecryptorPath
            OnExecute(e)
            e.Message = "转换 .ESD 文件转换为 .WIM 文件失败！"
            OnExecute(e)
            UpdateControlState(True)
            OnUpdateProgress(True)
            Return
        End If

        Dim ExitCode As Integer = Decrypt(EsdDecryptorPath, p.EsdFile)

        If ExitCode = 0 Then
            e.Message = "解密 .ESD 文件成功."
        Else
            e.Message = ".ESD 文件已经解密过 或 根本没有加密 又或 解密失败.ExitCode = 0x" & String.Format("{0:X8}", ExitCode)
        End If
        OnExecute(e)



        Dim Args As String = "", IsCreateTarget As Boolean = False

        If p.IsCreate OrElse Not IO.File.Exists(p.TargetFile) Then
            e.Message = "正在创建临时映像..."
            OnExecute(e)

            Dim EmptyContent As String = p.Template
            If Not EmptyContent.EndsWith("\") Then EmptyContent &= "\"
            EmptyContent &= Guid.NewGuid().ToString()
            IO.Directory.CreateDirectory(EmptyContent)

            Args = DismShell.CreateCaptureImageArguments(p.TargetFile, EmptyContent, "Template", "Template", p.Compress)
            If DismShell.DismExcute(Args) Then

                e.Message = "创建临时映像失败！"
                OnExecute(e)

                IO.Directory.Delete(EmptyContent)
                e.Message = "转换 .ESD 文件转换为 .WIM 文件失败！"
                OnExecute(e)
                UpdateControlState(True)
                OnUpdateProgress(True)
                Return

            End If

            IsCreateTarget = True
            IO.Directory.Delete(EmptyContent)

            e.Message = "创建临时映像成功！"
            OnExecute(e)
        End If

        If IsNothing(p.ImageInfo) Then
            Args = DismShell.CreateExportImageArguments(p.EsdFile, p.Index, p.TargetFile, , "Recovery", p.Bootable, p.CheckIntegrity)
            e.Message = "正在执行: " & Args
            OnExecute(e)
            If DismShell.DismExcute(Args) Then
                e.Message = "转换 .ESD 文件转换为 .WIM 文件失败！"
                OnExecute(e)
                If IsCreateTarget Then IO.File.Delete(p.TargetFile)
                UpdateControlState(True)
                OnUpdateProgress(True)
                Return
            End If
        Else
            Dim Index As Integer = 0
            For i As Integer = 0 To p.ImageInfo.Rows.Count - 1
                Index = p.ImageInfo(i)("Index")
                Args = DismShell.CreateExportImageArguments(p.EsdFile, Index, p.TargetFile, , "Recovery", p.Bootable, p.CheckIntegrity)
                e.Message = "正在执行: " & Args
                OnExecute(e)
                If DismShell.DismExcute(Args) Then
                    e.Message = "转换 .ESD 文件转换为 .WIM 文件失败！"
                    OnExecute(e)
                    If IsCreateTarget Then IO.File.Delete(p.TargetFile)
                    UpdateControlState(True)
                    OnUpdateProgress(True)
                    Return
                End If
            Next
        End If

        If IsCreateTarget Then
            e.Message = "正在删除临时映像..."
            OnExecute(e)
            Args = DismShell.CreateDeleteImageArguments(p.TargetFile, 1)
            If DismShell.DismExcute(Args) Then
                e.Message = "删除临时映像失败！"
                OnExecute(e)
            Else
                e.Message = "删除临时映像成功！"
                OnExecute(e)
            End If
        End If

        e.Message = "转换 .ESD 文件转换为 .WIM 文件成功！"
        OnExecute(e)

        UpdateControlState(True)
        OnUpdateProgress(True)

    End Sub

    Private Function Decrypt(Decryptor As String, EsdFile As String) As Integer
        Dim p As New Process()
        With p.StartInfo
            .FileName = Decryptor
            .Arguments = DismShell.FixPath(EsdFile)
            .CreateNoWindow = True
            .UseShellExecute = False
        End With
        p.Start()
        p.WaitForExit()
        Dim ExitCode As Integer = p.ExitCode
        Return ExitCode
    End Function

    Private Function CopyProgressRoutine(TotalFileSize As Long,
                                         TotalBytesTransferred As Long,
                                         StreamSize As Long,
                                         StreamBytesTransferred As Long,
                                         dwStreamNumber As Int32,
                                         dwCallbackReason As Int32,
                                         hSourceFile As IntPtr,
                                         hDestinationFile As IntPtr,
                                         lpData As IntPtr) As Int32
        OnUpdateProgress(New UpdateProgressEventArgs(TotalBytesTransferred, TotalFileSize) With {.IsLoop = False})
        Return 0
    End Function

    Private Function CheckBackup(EsdFile As String) As Integer
        Try
            Dim fInfo As New IO.FileInfo(EsdFile)
            Dim dInfo As New IO.DriveInfo(EsdFile)
            If fInfo.Length < dInfo.AvailableFreeSpace Then
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Friend Class EsdAsyncObject
        Public EsdFile As String = ""
        Public ImageInfo As DataTable = Nothing
        Public TargetFile As String = ""
        Public Template As String = ""
        Public Index As Integer = 0
        Public Name As String = ""
        Public Descritpion As String = ""
        Public WIMBoot As Boolean = False
        Public Bootable As Boolean = False
        Public CheckIntegrity As Boolean = False
        Public Verify As Boolean = False
        Public NoRpFix As Boolean = False
        Public Compress As String = "Fast"
        Public IsCreate As Boolean = False
        Public Backup As Boolean = False
        Public VDiskSize As Integer = 20480
    End Class



End Class
