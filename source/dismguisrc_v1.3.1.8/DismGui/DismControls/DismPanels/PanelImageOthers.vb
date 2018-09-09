Imports DismGui.WIMGAPI
Imports System.Runtime.InteropServices
Public Class PanelImageOthers
    Inherits DismPanelBase
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ChkCheckIntegrity As System.Windows.Forms.CheckBox
    Friend WithEvents CBUnit As System.Windows.Forms.ComboBox
    Private WithEvents TBBlockSize As System.Windows.Forms.TextBox
    Private WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents TargetWimFile As DismGui.WimFileSelector
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents WimFile As DismGui.WimFileSelector
    Friend WithEvents BtnSplit As System.Windows.Forms.Button
    Friend WithEvents ChkPushToQueue As System.Windows.Forms.CheckBox
    Private WithEvents TBImageName As System.Windows.Forms.TextBox
    Private WithEvents TBImageDescription As System.Windows.Forms.TextBox
    Private WithEvents WimInfo As DismGui.WimInfoComboBox
    Private components As System.ComponentModel.IContainer
    Friend WithEvents BtnEditImageInfo As System.Windows.Forms.Button
    Private WithEvents TT As System.Windows.Forms.ToolTip

    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnLoadConfig()

        WimFile.Text = DismConfig.GetItem("OthersWimFile", "")
        TargetWimFile.Text = DismConfig.GetItem("OthersTargetWimFile", "")
        TBBlockSize.Text = DismConfig.GetItem("OthersBlockSize", 1024UI)
        CBUnit.Text = DismConfig.GetItem("OthersUnit", "MB")
        ChkPushToQueue.Checked = DismConfig.GetItem("OthersPushToQueue", False)
        ChkCheckIntegrity.Checked = DismConfig.GetItem("OthersCheckIntegrity", False)

    End Sub

    Protected Overrides Sub OnUpdateInfo(Flags As WimInfoDetail)
        If Flags And WimInfoDetail.WimInfo Then WimInfo.UpdateWimInfo(WimFile.Text.Trim)
    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TT = New System.Windows.Forms.ToolTip(Me.components)
        Me.ChkCheckIntegrity = New System.Windows.Forms.CheckBox()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.TargetWimFile = New DismGui.WimFileSelector()
        Me.CBUnit = New System.Windows.Forms.ComboBox()
        Me.TBBlockSize = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ChkPushToQueue = New System.Windows.Forms.CheckBox()
        Me.BtnSplit = New System.Windows.Forms.Button()
        Me.TBImageDescription = New System.Windows.Forms.TextBox()
        Me.TBImageName = New System.Windows.Forms.TextBox()
        Me.WimInfo = New DismGui.WimInfoComboBox()
        Me.WimFile = New DismGui.WimFileSelector()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnEditImageInfo = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TT
        '
        Me.TT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TT.ToolTipTitle = "其它处理"
        '
        'ChkCheckIntegrity
        '
        Me.ChkCheckIntegrity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkCheckIntegrity.AutoSize = True
        Me.ChkCheckIntegrity.Location = New System.Drawing.Point(472, 236)
        Me.ChkCheckIntegrity.Name = "ChkCheckIntegrity"
        Me.ChkCheckIntegrity.Size = New System.Drawing.Size(114, 16)
        Me.ChkCheckIntegrity.TabIndex = 7
        Me.ChkCheckIntegrity.Text = "/CheckIntegrity"
        Me.TT.SetToolTip(Me.ChkCheckIntegrity, "检测和跟踪 WIM 文件是否损坏。")
        Me.ChkCheckIntegrity.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelete.Location = New System.Drawing.Point(420, 264)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(80, 28)
        Me.BtnDelete.TabIndex = 9
        Me.BtnDelete.Text = "删除"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'TargetWimFile
        '
        Me.TargetWimFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TargetWimFile.FilterIndex = 2
        Me.TargetWimFile.IsEsdFile = False
        Me.TargetWimFile.Location = New System.Drawing.Point(75, 201)
        Me.TargetWimFile.Name = "TargetWimFile"
        Me.TargetWimFile.ShowAsSaveFileDialog = True
        Me.TargetWimFile.Size = New System.Drawing.Size(511, 24)
        Me.TargetWimFile.TabIndex = 4
        Me.TargetWimFile.WimInfoControl = Nothing
        '
        'CBUnit
        '
        Me.CBUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CBUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBUnit.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CBUnit.FormattingEnabled = True
        Me.CBUnit.ItemHeight = 12
        Me.CBUnit.Items.AddRange(New Object() {"MB", "GB"})
        Me.CBUnit.Location = New System.Drawing.Point(165, 231)
        Me.CBUnit.Name = "CBUnit"
        Me.CBUnit.Size = New System.Drawing.Size(38, 20)
        Me.CBUnit.TabIndex = 6
        '
        'TBBlockSize
        '
        Me.TBBlockSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TBBlockSize.Location = New System.Drawing.Point(75, 231)
        Me.TBBlockSize.Name = "TBBlockSize"
        Me.TBBlockSize.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TBBlockSize.Size = New System.Drawing.Size(89, 21)
        Me.TBBlockSize.TabIndex = 5
        Me.TBBlockSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.Location = New System.Drawing.Point(-14, 232)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 17)
        Me.Label6.TabIndex = 106
        Me.Label6.Text = "拆分块大小："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.Location = New System.Drawing.Point(-14, 205)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 17)
        Me.Label8.TabIndex = 105
        Me.Label8.Text = "拆分的映像："
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ChkPushToQueue
        '
        Me.ChkPushToQueue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkPushToQueue.AutoSize = True
        Me.ChkPushToQueue.Location = New System.Drawing.Point(13, 270)
        Me.ChkPushToQueue.Name = "ChkPushToQueue"
        Me.ChkPushToQueue.Size = New System.Drawing.Size(108, 16)
        Me.ChkPushToQueue.TabIndex = 8
        Me.ChkPushToQueue.Text = "添加到任务队列"
        Me.ChkPushToQueue.UseVisualStyleBackColor = True
        '
        'BtnSplit
        '
        Me.BtnSplit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSplit.Location = New System.Drawing.Point(506, 264)
        Me.BtnSplit.Name = "BtnSplit"
        Me.BtnSplit.Size = New System.Drawing.Size(80, 28)
        Me.BtnSplit.TabIndex = 10
        Me.BtnSplit.Text = "拆分"
        Me.BtnSplit.UseVisualStyleBackColor = True
        '
        'TBImageDescription
        '
        Me.TBImageDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBImageDescription.Location = New System.Drawing.Point(74, 88)
        Me.TBImageDescription.Multiline = True
        Me.TBImageDescription.Name = "TBImageDescription"
        Me.TBImageDescription.Size = New System.Drawing.Size(511, 107)
        Me.TBImageDescription.TabIndex = 3
        '
        'TBImageName
        '
        Me.TBImageName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBImageName.Location = New System.Drawing.Point(74, 63)
        Me.TBImageName.Name = "TBImageName"
        Me.TBImageName.Size = New System.Drawing.Size(511, 21)
        Me.TBImageName.TabIndex = 2
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
        Me.WimInfo.ToolTipTitle = "更多映像功能"
        Me.WimInfo.WimFile = ""
        '
        'WimFile
        '
        Me.WimFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WimFile.FilterIndex = 1
        Me.WimFile.IsEsdFile = False
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
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "映像文件："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(13, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 98
        Me.Label5.Text = "映像描述："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(13, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "映像名称："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(13, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "映像索引："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnEditImageInfo
        '
        Me.BtnEditImageInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEditImageInfo.Location = New System.Drawing.Point(294, 263)
        Me.BtnEditImageInfo.Name = "BtnEditImageInfo"
        Me.BtnEditImageInfo.Size = New System.Drawing.Size(99, 28)
        Me.BtnEditImageInfo.TabIndex = 107
        Me.BtnEditImageInfo.Text = "修改映像信息"
        Me.BtnEditImageInfo.UseVisualStyleBackColor = True
        '
        'PanelImageOthers
        '
        Me.Controls.Add(Me.BtnEditImageInfo)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.TargetWimFile)
        Me.Controls.Add(Me.CBUnit)
        Me.Controls.Add(Me.TBBlockSize)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ChkCheckIntegrity)
        Me.Controls.Add(Me.ChkPushToQueue)
        Me.Controls.Add(Me.BtnSplit)
        Me.Controls.Add(Me.TBImageDescription)
        Me.Controls.Add(Me.TBImageName)
        Me.Controls.Add(Me.WimInfo)
        Me.Controls.Add(Me.WimFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Name = "PanelImageOthers"
        Me.Size = New System.Drawing.Size(600, 300)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click

        Dim wFile As String = WimFile.Text.Trim()
        Dim Index As String = WimInfo.Text.Trim()
        If Not IO.File.Exists(wFile) Then
            MsgBox(".WIM 文件不存在。", MsgBoxStyle.Critical, Title)
            WimFile.Select()
            Return
        End If
        If Index = "" Then
            MsgBox("请选择一个映像。", MsgBoxStyle.Critical, Title)
            WimInfo.Select()
            Return
        End If

        If MsgBox("确定要删除该映像？", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, Title) = MsgBoxResult.Yes Then

            Dim Arg As New DismControlEventArgs
            Arg.Arguments = DismShell.CreateDeleteImageArguments(wFile, Index, ChkCheckIntegrity.Checked)
            Arg.Mission = DismMissionFlags.DeleteImage
            Arg.Description = "删除映像"
            Arg.PushToQueue = ChkPushToQueue.Checked

            DismConfig.SetItem("OthersWimFile", wFile)
            DismConfig.SetItem("OthersCheckIntegrity", ChkCheckIntegrity.Checked)
            DismConfig.Save()

            OnExecute(Arg)

        End If
    End Sub

    Private Sub BtnSplit_Click(sender As Object, e As EventArgs) Handles BtnSplit.Click

        Dim wFile As String = WimFile.Text.Trim()
        Dim sFile As String = TargetWimFile.Text.Trim()

        If Not IO.File.Exists(wFile) Then
            MsgBox(".WIM 文件不存在。", MsgBoxStyle.Critical, Title)
            WimFile.Select()
            Return
        End If

        If sFile = "" Then
            MsgBox("请选择一个映像。", MsgBoxStyle.Critical, Title)
            TargetWimFile.Select()
            Return
        End If

        If CBUnit.SelectedIndex = -1 Then
            MsgBox("请选择一个容量单位。", MsgBoxStyle.Critical, Title)
            CBUnit.Select()
            Return
        End If

        Dim BlockSize As UInteger = 0
        UInteger.TryParse(TBBlockSize.Text.Trim, BlockSize)
        If CBUnit.SelectedIndex > 0 Then BlockSize = BlockSize << 10

        If BlockSize = 0 Then
            MsgBox("请输入一个正整数。", MsgBoxStyle.Critical, Title)
            TBBlockSize.Select()
            Return
        End If

        Dim Arg As New DismControlEventArgs
        Arg.Arguments = DismShell.CreateSplitImageArguments(wFile, sFile, BlockSize, ChkCheckIntegrity.Checked)
        Arg.Mission = DismMissionFlags.SplitImage
        Arg.Description = "拆分映像"
        Arg.PushToQueue = ChkPushToQueue.Checked

        DismConfig.SetItem("OthersWimFile", wFile)
        DismConfig.SetItem("OthersTargetFile", sFile)
        DismConfig.SetItem("OthersCheckIntegrity", ChkCheckIntegrity.Checked)
        DismConfig.SetItem("OthersUnit", CBUnit.Text)
        DismConfig.SetItem("OthersBlockSize", BlockSize)
        DismConfig.Save()

        OnExecute(Arg)
    End Sub

    Private Sub ChkPushToQueue_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPushToQueue.CheckedChanged
        DismConfig.SetItem("OthersPushToQueue", ChkPushToQueue.Checked)
        DismConfig.Save()
    End Sub



    Private Sub BtnEditImageInfo_Click(sender As Object, e As EventArgs) Handles BtnEditImageInfo.Click
        Dim wFile As String = WimFile.Text.Trim()

        If Not IO.File.Exists(wFile) Then
            MsgBox(".WIM 文件不存在！", MsgBoxStyle.Critical, Title)
            Return
        End If

        Dim Index As UInteger = 0
        UInteger.TryParse(WimInfo.Text.Trim(), Index)

        If Index = 0 Then
            MsgBox("请选择一个映像！", MsgBoxStyle.Critical, Title)
            Return
        End If

        Dim Name As String = TBImageName.Text.Trim()
        Dim Desc As String = TBImageDescription.Text.Trim()
        Dim EIIObject As New EditImageInfoObject With {.WimFile = wFile, .ImageIndex = Index, .Name = Name, .Description = Desc}
        DismConfig.SetItem("OthersWimFile", wFile)
        DismConfig.Save()

        System.Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AddressOf UpdateImageInformationProc), EIIObject)

    End Sub

    ''' <summary>
    ''' 更新映像信息
    ''' </summary>
    ''' <param name="EIIObject"></param>
    ''' <remarks></remarks>
    Private Sub UpdateImageInformationProc(EIIObject As EditImageInfoObject)
        Dim Args As New DismControlEventArgs With {.Mission = DismMissionFlags.PostMessage}
        Dim e As EditImageInfoObject = TryCast(EIIObject, EditImageInfoObject)

        UpdateControlState(False)
        OnUpdateProgress(False)
        Args.Message = "正在修改映像信息..."
        OnExecute(Args)
        '打开 .WIM 文件
        Dim hWim As IntPtr = WIMKits.CreateFile(e.WimFile, FileAccess.Write, FileMode.OpenExisting)

        If hWim <> IntPtr.Zero Then

            '设置临时目录
            If WIMKits.SetTemporaryPath(hWim, Application.StartupPath) Then

                '加载指定映像索引的映像
                Dim hImage As IntPtr = WIMKits.LoadImage(hWim, e.ImageIndex)

                If hImage <> IntPtr.Zero Then
                    Dim hInfo As IntPtr = IntPtr.Zero
                    Dim InfoSize As UInteger = 0
                    '获取原有映像信息
                    If WIMKits.GetImageInformation(hImage, hInfo, InfoSize) Then
                        Dim Temp As String = Marshal.PtrToStringUni(hInfo)

                        '这个地方必须要加上一个根节点，要不XML Linq 无法解析映像信息！
                        Temp = "<ImageInfo>" & Temp & "</ImageInfo>"
                        Dim Doc As XElement = XElement.Parse(Temp)
                        Dim P As XElement = Doc.Element("IMAGE")
                        Dim x As XElement

                        '修改映像名称
                        x = P.Element("NAME")
                        If IsNothing(x) Then
                            x = <NAME></NAME>
                            P.Add(x)
                        End If
                        x.Value = e.Name

                        '修改映像显示名称
                        x = P.Element("DISPLAYNAME")
                        If IsNothing(x) Then
                            x = <DISPLAYNAME/>
                            P.Add(x)
                        End If
                        x.Value = e.Name

                        '修改映像描述
                        x = P.Element("DESCRIPTION")
                        If IsNothing(x) Then
                            x = <DESCRIPTION/>
                            P.Add(x)
                        End If
                        x.Value = e.Description

                        '修改映像显示描述
                        x = P.Element("DISPLAYDESCRIPTION")
                        If IsNothing(x) Then
                            x = <DISPLAYDESCRIPTION/>
                            P.Add(x)
                        End If
                        x.Value = e.Description

                        Temp = P.ToString() & vbCrLf
                        Dim Byt() As Byte = System.Text.Encoding.Unicode.GetBytes(Temp)

                        '这个地方要注意,要在字符串数据前面加上编码信息,否则API无法识别这些信息。
                        Dim Data(Byt.Length + 1) As Byte
                        Data(0) = &HFF : Data(1) = &HFE
                        Byt.CopyTo(Data, 2)
                        Erase Byt
                        hInfo = Marshal.AllocHGlobal(Data.Length)
                        Marshal.Copy(Data, 0, hInfo, Data.Length)
                        If WIMKits.SetImageInformation(hImage, hInfo, Data.Length) Then
                            Args.Message = "修改映像信息成功！"
                            OnExecute(Args)
                        Else
                            Args.Message = "无法获取指定映像的信息。修改映像信息失败！GetLastError = " & Marshal.GetLastWin32Error()
                            OnExecute(Args)
                        End If
                        Erase Data
                        Marshal.FreeHGlobal(hInfo)
                    Else
                        Args.Message = "无法获取指定映像的信息。修改映像信息失败！GetLastError = " & Marshal.GetLastWin32Error()
                        OnExecute(Args)
                    End If
                    WIMKits.CloseHandle(hImage)
                    WIMKits.CloseHandle(hWim)
                Else
                    WIMKits.CloseHandle(hWim)
                    Args.Message = "无法加载指定的映像。修改映像信息失败！GetLastError = " & Marshal.GetLastWin32Error()
                    OnExecute(Args)
                End If
            Else
                WIMKits.CloseHandle(hWim)
                Args.Message = "设置临时目录。修改映像信息失败！GetLastError = " & Marshal.GetLastWin32Error()
                OnExecute(Args)
            End If
        Else
            Args.Message = "无法打开 .WIM 文件。修改映像信息失败！GetLastError = " & Marshal.GetLastWin32Error()
            OnExecute(Args)
        End If
        UpdateControlState(True)
        OnUpdateProgress(True)
        UpdateInfo(WimInfoDetail.WimInfo)
    End Sub

    Private Class EditImageInfoObject
        Public WimFile As String = ""
        Public ImageIndex As UInteger = 0
        Public Name As String = ""
        Public Description As String = ""
    End Class

End Class
