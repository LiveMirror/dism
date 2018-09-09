Imports AutocompleteMenuNS
Public Class PanelDismCustom
    Inherits DismPanelBase
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TBCmdLine As System.Windows.Forms.TextBox
    Friend WithEvents BtnExecute As System.Windows.Forms.Button
    Friend WithEvents ChkHookMessage As System.Windows.Forms.CheckBox
    Friend WithEvents ACMCommandList As AutocompleteMenuNS.AutocompleteMenu

    Private mCommandList As New List(Of MulticolumnAutocompleteItem)

    Public Sub New()
        InitializeComponent()
        AddPopupItems()
    End Sub

    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBCmdLine = New System.Windows.Forms.TextBox()
        Me.BtnExecute = New System.Windows.Forms.Button()
        Me.ChkHookMessage = New System.Windows.Forms.CheckBox()
        Me.ACMCommandList = New AutocompleteMenuNS.AutocompleteMenu()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 12)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "DISM "
        '
        'TBCmdLine
        '
        Me.TBCmdLine.AcceptsTab = True
        Me.TBCmdLine.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ACMCommandList.SetAutocompleteMenu(Me.TBCmdLine, Me.ACMCommandList)
        Me.TBCmdLine.Location = New System.Drawing.Point(15, 32)
        Me.TBCmdLine.Multiline = True
        Me.TBCmdLine.Name = "TBCmdLine"
        Me.TBCmdLine.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TBCmdLine.Size = New System.Drawing.Size(571, 225)
        Me.TBCmdLine.TabIndex = 0
        '
        'BtnExecute
        '
        Me.BtnExecute.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExecute.Location = New System.Drawing.Point(506, 264)
        Me.BtnExecute.Name = "BtnExecute"
        Me.BtnExecute.Size = New System.Drawing.Size(80, 28)
        Me.BtnExecute.TabIndex = 2
        Me.BtnExecute.Text = "执行"
        Me.BtnExecute.UseVisualStyleBackColor = True
        '
        'ChkHookMessage
        '
        Me.ChkHookMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkHookMessage.AutoSize = True
        Me.ChkHookMessage.Checked = True
        Me.ChkHookMessage.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkHookMessage.Location = New System.Drawing.Point(15, 264)
        Me.ChkHookMessage.Name = "ChkHookMessage"
        Me.ChkHookMessage.Size = New System.Drawing.Size(96, 16)
        Me.ChkHookMessage.TabIndex = 1
        Me.ChkHookMessage.Text = "拦截输出信息"
        Me.ChkHookMessage.UseVisualStyleBackColor = True
        '
        'ACMCommandList
        '
        Me.ACMCommandList.AllowsTabKey = True
        Me.ACMCommandList.AppearInterval = 50
        Me.ACMCommandList.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ACMCommandList.ImageList = Nothing
        Me.ACMCommandList.Items = New String(-1) {}
        Me.ACMCommandList.MinFragmentLength = 1
        Me.ACMCommandList.SearchPattern = "[\/\-\\\""\:\w_]"
        Me.ACMCommandList.TargetControlWrapper = Nothing
        '
        'PanelDismCustom
        '
        Me.Controls.Add(Me.ChkHookMessage)
        Me.Controls.Add(Me.BtnExecute)
        Me.Controls.Add(Me.TBCmdLine)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PanelDismCustom"
        Me.Size = New System.Drawing.Size(600, 300)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Sub AddPopupItems()
        ACMCommandList.SetAutocompleteItems(New List(Of AutocompleteItem))
        ACMCommandList.MaximumSize = New Size(Me.Width, 160)

        '通用映像处理命令:
        AddPopupItem("/Get-MountedImageInfo", "显示有关安装的 WIM 和 VHD 映像的信息。")
        AddPopupItem("/Get-ImageInfo", "显示有关 WIM 或 VHD 文件中映像的信息。")
        AddPopupItem("/Commit-Image", "保存对装载的 WIM 或 VHD 映像的更改。")
        AddPopupItem("/Unmount-Image", "卸载已装载的 WIM 或 VHD 映像。")
        AddPopupItem("/Mount-Image", "从 WIM 或 VHD 文件装载映像。")
        AddPopupItem("/Remount-Image", "恢复孤立的映像装载目录。")
        AddPopupItem("/Cleanup-Mountpoints", "删除与损坏的已安装映像关联的资源。")

        'WIM 命令:
        AddPopupItem("/Capture-CustomImage", "将自定义设置捕获到 WIMBoot 系统上的增量 WIM 文件中。")
        AddPopupItem("/Get-WIMBootEntry", "显示指定磁盘卷的 WIMBoot 配置项。")
        AddPopupItem("/Update-WIMBootEntry", "更新指定磁盘卷的 WIMBoot 配置项。")
        AddPopupItem("/List-Image", "显示指定映像中的文件和文件夹的列表。")
        AddPopupItem("/Delete-Image", "从具有多个卷映像的 WIM 文件删除指定的卷映像。")
        AddPopupItem("/Split-Image", "将现有 .wim 文件拆分为多个只读 WIM (SWM)拆分文件。")
        AddPopupItem("/Export-Image", "将指定映像的副本导出到其他文件。")
        AddPopupItem("/Append-Image", "将其他映像添加到 WIM 文件中。")
        AddPopupItem("/Capture-Image", "将驱动器的映像捕获到新的 WIM 文件中")
        AddPopupItem("/Apply-Image", "应用一个映像。")
        AddPopupItem("/Get-MountedWimInfo", "显示有关安装的 WIM 映像的信息。")
        AddPopupItem("/Get-WimInfo", "显示有关 WIM 文件中的映像的信息。")
        AddPopupItem("/Commit-Wim", "保存对安装的 WIM 映像的更改。")
        AddPopupItem("/Unmount-Wim", "卸载安装的 WIM 映像。")
        AddPopupItem("/Mount-Wim", "从 WIM 文件安装映像。")
        AddPopupItem("/Remount-Wim", "恢复孤立的 WIM 安装目录。")
        AddPopupItem("/Cleanup-Wim", "删除与损坏的已安装 WIM 映像关联的资源。")

        'WIM 命令参数:
        AddPopupItem("/WIMBoot", "捕获能够使用 WIMBoot 配置应用的映像。")
        AddPopupItem("/ConfigFile", "映像捕获和压缩命令的排除项的配置文件。")
        AddPopupItem("/Compress:None", "无压缩，指定用于执行初始捕获操作的压缩类型")
        AddPopupItem("/Compress:Fast", "快速，指定用于执行初始捕获操作的压缩类型")
        AddPopupItem("/Compress:Max", "最大压缩，指定用于执行初始捕获操作的压缩类型")
        AddPopupItem("/Compress:Recovery", "重置映像，指定用于执行初始捕获操作的压缩类型")
        AddPopupItem("/Bootable", "将 Windows PE 卷映像标记为能够引导。")
        AddPopupItem("/CheckIntegrity", "可检测和跟踪 WIM 文件是否损坏。")
        AddPopupItem("/Verify", "可检查错误和文件重复。")
        AddPopupItem("/NoRpFix", "禁用重分析点标记修复。")
        AddPopupItem("/WimFile", ".WIM 文件路径。")
        AddPopupItem("/ImageFile", "映像文件路径。")
        AddPopupItem("/SourceImageFile", "源映像文件路径。")
        AddPopupItem("/DestinationImageFile", "目标映像文件路径。")
        AddPopupItem("/Index", "映像索引")
        AddPopupItem("/SourceIndex", "源映像索引")
        AddPopupItem("/Name", "映像名称")
        AddPopupItem("/SourceName", "源映像名称")
        AddPopupItem("/DestinationName", "目标映像名称")
        AddPopupItem("/Description", "映像描述")
        AddPopupItem("/Append", "将映像添加到现有 .wim 文件。")
        AddPopupItem("/ApplyDir", "应用映像路径。")
        AddPopupItem("/Commit", "保存更改。")
        AddPopupItem("/Discard", "放弃更改。")
        AddPopupItem("/CaptureDir", "捕获目录。")
        AddPopupItem("/ReadOnly", "以只读的方式挂载映像。")
        AddPopupItem("/MountDir", "挂载目录。")
        AddPopupItem("/FileSize", "创建的每个文件指定最大大小（单位：MB）")

        '映像规格:
        AddPopupItem("/Online", "以正在运行的操作系统为目标。")
        AddPopupItem("/Image", "指定脱机 Windows 映像的根目录的路径。")

        'DISM 选项:
        AddPopupItem("/English", "用英文显示命令行输出。")
        AddPopupItem("/Format", "指定报告输出格式。")
        AddPopupItem("/WinDir", "指定 Windows 目录的路径。")
        AddPopupItem("/SysDriveDir", "指定名为 BootMgr 的系统加载程序文件的路径。")
        AddPopupItem("/LogPath", "指定日志文件路径。")
        AddPopupItem("/LogLevel", "指定日志(1-4)中所示的输出级别。")
        AddPopupItem("/NoRestart", "取消自动重新启动和重新启动提示。")
        AddPopupItem("/Quiet", "取消除错误消息之外的所有输出。")
        AddPopupItem("/ScratchDir", "指定暂存目录的路径。")

        '程序包命令:
        AddPopupItem("/Get-Packages", "显示有关映像中所有程序包的基本信息。")
        AddPopupItem("/Get-PackageInfo", "显示有关以 .cab 文件形式提供的程序包的详细信息。")
        AddPopupItem("/PackagePath", "可以指向 .cab 文件、.msu 文件或文件夹。")
        AddPopupItem("/IgnoreCheck", "安装时跳过适用性检查失败的程序包")
        AddPopupItem("/PreventPending", "安装时跳过程序包或 Windows 映像具有挂起的联机操作")
        AddPopupItem("/PackageName", "程序包名称")
        AddPopupItem("/Add-Package", "在映像中添加一个或多个程序包。")
        AddPopupItem("/Remove-Package", "删除一个或多个程序包。")

        '功能命令:
        AddPopupItem("/Get-Features", "显示有关程序包中的所有功能（包括可选的 Windows Foundation 功能在内的操作系统组件）的基本信息。")
        AddPopupItem("/Get-FeatureInfo", "显示有关某项功能的的详细信息。")
        AddPopupItem("/FeatureName", "功能名称")
        AddPopupItem("/Enable-Feature", "启用由 FeatureName 命令参数指定的功能。")
        AddPopupItem("/Source", "操作所需的文件源。")
        AddPopupItem("/LimitAccess", "阻止 DISM 联系 WU/WSUS。")
        AddPopupItem("/All", "启用指定功能的所有父级功能或者获取所有驱动。")
        AddPopupItem("/Disable-Feature", "禁用由 FeatureName 命令参数指定的功能。")
        AddPopupItem("/Remove", "删除某个功能但不会删除该功能在映像中的清单")

        '驱动程序命令:
        AddPopupItem("/Get-Drivers", "显示有关联机映像或脱机映像中的驱动程序包的基本信息。")
        AddPopupItem("/Get-DriverInfo", "显示有关特定驱动程序包的详细信息。")
        AddPopupItem("/Driver", "驱动程序")
        AddPopupItem("/Add-Driver", "向脱机 Windows 映像中添加第三方驱动程序包。")
        AddPopupItem("/Recurse", "查询所有的子文件夹以确定要添加的驱动程序。")
        AddPopupItem("/ForceUnsigned", "强行添加没有数字签名的驱动。")
        AddPopupItem("/Remove-Driver", "从脱机映像中删除第三方驱动程序。")

        '无人守值服务:
        AddPopupItem("/Apply-Unattend", "将 Unattend.xml 文件应用于映像。")

        '版本命令:
        AddPopupItem("/Get-CurrentEdition", "显示指定映像的版本。")
        AddPopupItem("/Get-TargetEditions", "显示可以将映像更改为的 Windows 版本的列表。")
        AddPopupItem("/Set-Edition", "将脱机 Windows 映像更改到更高版本。")
        AddPopupItem("/GetEula", "将最终用户许可协议复制到一个指定的路径。")
        AddPopupItem("/AcceptEula", "参数接受最终用户许可协议")
        AddPopupItem("/Set-ProductKey", "在脱机 Windows 映像中输入当前版本的产品密钥。")

        '应用程序命令:
        AddPopupItem("/Check-AppPatch", "显示 MSP 修补程序是否适用于脱机映像的信息。")
        AddPopupItem("/PatchLocation", "修补程序路径")
        AddPopupItem("/Get-AppPatchInfo", "显示有关安装的 MSP 修补程序的信息。")
        AddPopupItem("/PatchCode", "显示应用修补程序的所有 MSI 应用程序的信息。")
        AddPopupItem("/ProductCode", "显示指定应用程序中的所有 MSP 修补程序的相关信息。")
        AddPopupItem("/Get-AppPatches", "显示有关脱机映像上安装的所有应用程序已应用的所有 MSP 修补程序的基本信息。")
        AddPopupItem("/Get-AppInfo", "显示有关已安装的特定 Windows Installer 应用程序的详细信息。")
        AddPopupItem("/Get-Apps", "显示有关脱机映像中的所有 Windows Installer 应用程序的基本信息。")

        'Metro应用命令：
        AddPopupItem("/Get-ProvisionedAppxPackages", "显示有关在映像中设置为安装以供每个新用户使用的应用程序包（.appx 或 .appxbundle）的信息。")
        AddPopupItem("/Add-ProvisionedAppxPackage", "将一个或多个应用程序包添加到映像。")
        AddPopupItem("/FolderPath", "含有主程序包、任何依赖包和许可文件的解压应用文件的文件夹。")
        AddPopupItem("/CustomDataPath", "指定应用的可选自定义数据文件。")
        AddPopupItem("/LicensePath", "含有应用程序许可的 .xml 文件的位置。")
        AddPopupItem("/SkipLicense", "忽略应用程序许可信息。")
        AddPopupItem("/Remove-ProvisionedAppxPackage", "从映像中删除应用程序包（.appx 或 .appxbundle）的设置")
        AddPopupItem("/Set-ProvisionedAppxDataFile", "将自定义数据文件添加到指定的应用程序包中（.appx 或 .appxbundle）。")

        'AddItem("abcd", "sadsa")
        '国际化命令:
        AddPopupItem("/Get-Intl", "显示有关国际设置和语言的信息。")
        AddPopupItem("/Set-UILang", "设置默认系统用户界面 (UI) 语言。")
        AddPopupItem("/Set-UILangFallback", "设置脱机 Windows 映像中系统 UI 的备选默认语言。")
        AddPopupItem("/Set-Syslocale", "设置脱机 Windows 映像中非 Unicode 程序的语言(也称为系统区域置)和字体设置。")
        AddPopupItem("/Set-UserLocale:", "设置脱机 Windows 映像中的（标准和格式）语言（也称为用户区域设置）")
        AddPopupItem("/Set-InputLocale", "设置要在脱机 Windows 映像中使用的输入区域设置和键盘布局。")
        AddPopupItem("/Set-AllIntl", "默认系统 UI 语言、非 Unicode 程序的语言、（标准和格式）语言，以及输入区域设置和键盘布局设置为脱机 Windows 映像中指定的语言。")
        AddPopupItem("/Set-TimeZone", "设置 Windows 映像中的默认时区。")
        AddPopupItem("/Set-SKUIntlDefaults", "将脱机 Windows 映像中的默认系统 UI 语言、非 Unicode 程序的语言、标准和格式的语言，以及输入区域设置、键盘布局和时区值设置")
        AddPopupItem("/Set-LayeredDriver", "指定用于日语键盘或朝鲜语键盘的键盘驱动程序。")
        AddPopupItem("/Gen-LangINI", "生成一个新的 Lang.ini 文件，该文件由安装程序用于定义映像内部和分发外部的语言包。")
        AddPopupItem("/Set-SetupUILang", "定义安装程序将使用的默认语言。")
        AddPopupItem("/Distribution", "指定 Windows 分发的路径。")

        '组件命令:
        AddPopupItem("/Cleanup-Image", "对映像执行清理或恢复操作。")
        AddPopupItem("/RevertPendingActions", "Windows 映像中未启动的系统恢复方案。")
        AddPopupItem("/SPSuperseded", "删除在 Service Pack 安装期间创建的任何备份文件。")
        AddPopupItem("/StartComponentCleanup", "防止将 Service Pack 列在( 已安装更新 )控制面板中。")
        AddPopupItem("/ResetBase", "重置已取代组件的基础，这可以进一步减少组件库大小。")
        AddPopupItem("/AnalyzeComponentStore", "创建组件库的报告。")
        AddPopupItem("/CheckHealth", "检查是否已将映像标记为已被出现故障的进程损坏以及损坏是否可修复。")
        AddPopupItem("/ScanHealth", "扫描映像以了解组件存储是否损坏。")
        AddPopupItem("/RestoreHealth", "扫描映像以了解组件存储是否损坏，然后自动执行修复操作。")
        AddPopupItem("/Optimize-Image", "对脱机的映像执行指定的配置。")

        'PE 服务命令行选项
        AddPopupItem("/Get-PESettings", "在 Windows PE 映像中显示一系列 Windows PE 设置。")
        AddPopupItem("/Get-Profiling", "检索 Windows PE 配置处理工具的启用/禁用状态。")
        AddPopupItem("/Get-ScratchSpace", "检索 Windows PE 系统卷暂存空间的已配置数量。")
        AddPopupItem("/Get-TargetPath", "检索 Windows PE 映像的目标路径。")
        AddPopupItem("/Set-ScratchSpace", "设置 Windows PE 映像可用的暂存空间 (MB)。有效值为 32、64、128、256 和 512。")
        AddPopupItem("/Set-TargetPath", "对于硬盘启动方案，此选项可设置磁盘上 Windows PE 映像的位置。")
        AddPopupItem("/Enable-Profiling", "Windows PE 映像启用配置处理（文件日志）以创建你自己的配置文件。默认情况下，禁用配置处理。")
        AddPopupItem("/Disable-Profiling", "Windows PE 映像关闭用于创建配置文件的文件日志。")
        AddPopupItem("/Apply-Profiles", "删除 Windows PE 映像中任何不属于自定义配置文件的文件。")

        mCommandList.Sort(AddressOf SortProc)
    End Sub

    Private Function SortProc(x As MulticolumnAutocompleteItem, y As MulticolumnAutocompleteItem) As Integer
        Return String.Compare(x.Text, y.Text, True)
    End Function

    Private Sub AddPopupItem(Parameter As String, Description As String)
        Dim FirstColWidth As Integer = 150
        Dim cWidths() As Integer = {FirstColWidth, Me.Width - FirstColWidth}
        Dim it As MulticolumnAutocompleteItem = Nothing
        it = New MulticolumnAutocompleteItem(New String() {Parameter, Description}, Parameter, False) With {.ColumnWidth = cWidths}
        mCommandList.Add(it)
    End Sub

    Private Sub AddMountedItem(Parameter As String, Description As String)
        Dim FirstColWidth As Integer = 150
        Dim cWidths() As Integer = {FirstColWidth, Me.Width - FirstColWidth}
        Dim it As MulticolumnAutocompleteItem = Nothing
        it = New MulticolumnAutocompleteItem(New String() {Parameter, Description}, Parameter, False) With {.ColumnWidth = cWidths}
        ACMCommandList.AddItem(it)
    End Sub

    Private Sub BtnExecute_Click(sender As Object, e As EventArgs) Handles BtnExecute.Click
        Dim Temp As String = TBCmdLine.Text.Trim()
        Temp = Temp.Replace(vbCr, "")
        Temp = Temp.Replace(vbLf, "")
        Dim IsHookMessage As Integer = 0
        If Temp = "" Then
            Temp = "/?"
            IsHookMessage = 1
        Else
            IsHookMessage = IIf(ChkHookMessage.Checked, 1, 0)
        End If
        Dim Args As New DismControlEventArgs With {.Mission = DismMissionFlags.CustomCommand}
        Args.Description = "自定义Dism命令"
        Args.Arguments = Temp
        Args.HookMessage = IsHookMessage

        OnExecute(Args)

    End Sub

    Private Sub TBCmdLine_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBCmdLine.KeyPress
        Dim KeyCode As Integer = Asc(e.KeyChar)
        If KeyCode = Keys.Enter Or e.KeyChar = vbLf Then
            If Not TBCmdLine.Text.EndsWith(" ") Then TBCmdLine.Text = TBCmdLine.Text & " "
            TBCmdLine.SelectionStart = TBCmdLine.Text.Length
            e.Handled = True
            BtnExecute_Click(BtnExecute, New EventArgs())
        End If
    End Sub

    Protected Overrides Sub OnUpdateInfo(Flags As WimInfoDetail)

        If InvokeRequired Then
            Invoke(New EventHandler(AddressOf ActiveProc))
        Else
            ActiveProc(Nothing, Nothing)
        End If

        If Flags And WimInfoDetail.MountedWimInfo Then Threading.ThreadPool.QueueUserWorkItem(AddressOf GetMountedWimInfoProc)

    End Sub

    Private Sub GetMountedWimInfoProc()
        UpdateControlState(False)
        Dim dt As DataTable = DismShell.BuildMountedWimInfoTable
        DismShell.GetMountedWimInfo(dt)
        UpdateControlState(True)
        Invoke(New ShowWimInfoHandler(AddressOf ShowMountedWimInfo), dt)
    End Sub

    Private Sub ShowMountedWimInfo(dt As DataTable)
        Dim Temp As String = ""
        ACMCommandList.SetAutocompleteItems(Clone(mCommandList))
        For Each dr As DataRow In dt.Rows()
            Temp = "" & dr("MountDir")
            AddMountedItem(DismShell.FixImage(Temp), Temp & " (" & dr("Status") & ")")
            AddMountedItem("/MountDir:" & DismShell.FixPath(Temp), Temp & " (" & dr("Status") & ")")
        Next
        ActiveProc(Nothing, Nothing)
    End Sub

    Private Function Clone(CommandList As List(Of MulticolumnAutocompleteItem)) As List(Of MulticolumnAutocompleteItem)
        Dim mList As New List(Of MulticolumnAutocompleteItem)
        Dim it As MulticolumnAutocompleteItem = Nothing
        Dim Temp As String = ""
        For Each e As MulticolumnAutocompleteItem In CommandList
            it = New MulticolumnAutocompleteItem(e.MenuTextByColumns, e.Text, False) With {.ColumnWidth = e.ColumnWidth}
            mList.Add(it)
        Next
        Return mList
    End Function

    Private Sub ActiveProc(sender As Object, e As EventArgs)
        TBCmdLine.Select()
    End Sub

    'Private Sub ACMCommandList_Selected(sender As Object, e As SelectedEventArgs) Handles ACMCommandList.Selected
    '    TBCmdLine.Text = TBCmdLine.Text & " "
    '    TBCmdLine.SelectionStart = TBCmdLine.Text.Length
    'End Sub
End Class
