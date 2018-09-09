Imports System
Imports System.Threading
''' <summary>
''' 主界面
''' </summary>
''' <remarks></remarks>
Public Class Main

    Private TempFolder As Environment.SpecialFolder = Environment.SpecialFolder.LocalApplicationData
    Private Const DefaultScratchDirActived As Boolean = False


    ''' <summary>
    ''' Dism任务队列管理器
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared DismQueue As New DismQueueManager()


#Region "初始化控件"

    'Dism面板控件集合
    Private mDismCtrls As New List(Of DismPanelElement)

    ''' <summary>
    ''' 窗体初始化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateProgressBar(0)
        LoadScratchDirSettings()
        ShowDriveInfo()
        AddComponent()
    End Sub

    ''' <summary>
    ''' 添加所有Dism面板控件
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddComponent()

        AddPanel("Tools", WimInfoDetail.None, "工具箱", New PanelToolBox())

        AddPanel("Capture", WimInfoDetail.WimInfo, "捕获映像", New PanelImageCapture())

        AddPanel("Mount", WimInfoDetail.MountedWimInfo Or WimInfoDetail.WimInfo, "挂载映像", New PanelImageMount())

        AddPanel("Apply", WimInfoDetail.WimInfo, "应用映像", New PanelImageApply())

        AddPanel("Export", WimInfoDetail.WimInfo, "导出映像", New PanelImageExport())

        AddPanel("Others", WimInfoDetail.WimInfo, "更多映像功能", New PanelImageOthers())

        AddPanel("Features", WimInfoDetail.MountedWimInfo, "功能管理", New PanelFeatures())

        AddPanel("Packages", WimInfoDetail.MountedWimInfo, "程序包管理", New PanelPackages())

        AddPanel("MetroApps", WimInfoDetail.MountedWimInfo, "Metro应用管理", New PanelMetroMgr())

        AddPanel("Drivers", WimInfoDetail.MountedWimInfo, "驱动管理", New PanelDrivers())

        AddPanel("Edition", WimInfoDetail.MountedWimInfo, "版本设置", New PanelEdition())

        AddPanel("Unattend", WimInfoDetail.MountedWimInfo, "无人参与服务", New PanelUnattend())

        AddPanel("Cleanup", WimInfoDetail.MountedWimInfo, "组件库管理", New PanelCleanup())

        AddPanel("DismCustom", WimInfoDetail.MountedWimInfo, "自定义Dism命令", New PanelDismCustom())

        AddPanel("Esd", WimInfoDetail.WimInfo, ".ESD 转换为 .WIM", New PanelESD())

        AddPanel("Queue", WimInfoDetail.None, "任务队列", New PanelQueue())

        AddPanel("Config", WimInfoDetail.None, "选项", New PanelConfig())

        AddPanel("About", WimInfoDetail.None, "关于", New PanelAbout())

        TaskButtonLayout()

    End Sub

    ''' <summary>
    ''' 添加一个Dism面板控件，并且添加事件处理
    ''' </summary>
    ''' <param name="Name">控件名称</param>
    ''' <param name="DefaultUpdateInfo">默认更新映像信息</param>
    ''' <param name="Text">任务栏显示标题</param>
    ''' <param name="Panel">Dism面板控件</param>
    ''' <remarks></remarks>
    Private Sub AddPanel(Name As String, DefaultUpdateInfo As WimInfoDetail, Text As String, Panel As IDismControl)
        Dim e As DismPanelElement = DismPanelElement.Create(Name, DefaultUpdateInfo, Text, Panel)
        HookDismControlEvent(e)
        mDismCtrls.Add(e)
    End Sub

    ''' <summary>
    ''' 对任务按钮进行UI布局调整
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub TaskButtonLayout()
        Dim x As Integer = 3
        Dim y As Integer = 3
        Dim w As Integer = PDISM_Features.Width - x - x - 2
        Dim h As Integer = 30
        Dim e As DismPanelElement = Nothing
        For i As Integer = 0 To mDismCtrls.Count - 1
            e = mDismCtrls(i)
            e.TaskButton.Location = New Point(x, y)
            e.TaskButton.Size = New Size(w, h)
            PDISM_Features.Controls.Add(e.TaskButton)
            y += h + 2
        Next
        mDismCtrls(0).TaskButton.Checked = True

    End Sub

    ''' <summary>
    ''' 添加Dism面板控件事件处理
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub HookDismControlEvent(e As DismPanelElement)
        AddHandler e.TaskButton.CheckedChanged, AddressOf RB_CheckedChanged
        AddHandler e.Panel.Execute, AddressOf DismExecuteProc
        AddHandler e.Panel.UpdateProgress, AddressOf DismPanelProgressProc
    End Sub

    ''' <summary>
    ''' 移除Dism面板控件事件处理
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UnHookDismControlEvent(e As DismPanelElement)
        RemoveHandler e.TaskButton.CheckedChanged, AddressOf RB_CheckedChanged
        RemoveHandler e.Panel.Execute, AddressOf DismExecuteProc
        RemoveHandler e.Panel.UpdateProgress, AddressOf DismPanelProgressProc
    End Sub

    ''' <summary>
    ''' 当任务按钮改变后，显示对应画面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RB_CheckedChanged(sender As Object, e As EventArgs)
        PDISM_Parameters.Controls.Clear()
        Dim DPE As DismPanelElement = (From d As DismPanelElement In mDismCtrls Where d.TaskButton.Equals(sender) Select d).FirstOrDefault
        If Not IsNothing(DPE) AndAlso DPE.TaskButton.Checked Then
            PDISM_Parameters.Controls.Add(DPE.Panel)
            DPE.Panel.LoadConfig()
            DPE.Panel.UpdateInfo(DPE.DefaultUpdateInfo)
        End If
    End Sub

#End Region

#Region "处理Dism指令"

    ''' <summary>
    ''' Dism面板控件执行指令事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DismExecuteProc(sender As IDismControl, e As DismControlEventArgs)

        Dim DismEventObject As New DismAsyncObject(sender, e)

        If e.Mission = DismMissionFlags.PostMessage Then
            AddMsg(e.Message)
            Return
        End If

        '进入队列处理
        If e.Mission = DismMissionFlags.RunQueue Then
            If Not IO.File.Exists(DismShell.DismPath) Then
                AddMsg("处理任务队列失败！" & vbCrLf &
                       "无法找到文件：" & DismShell.DismPath)
                Return
            End If
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf RunQueueMissionProc), sender)
            Return
        End If

        '若指定了暂存目录，并且该目录存在。添加暂存目录项
        If ChkScratchDirActived.Checked AndAlso IO.Directory.Exists(FSScratchDir.Text) Then
            DismEventObject.e.Arguments = DismEventObject.e.Arguments & " /ScratchDir:" & DismShell.FixPath(FSScratchDir.Text)
        End If

        '若该指令是留到队列处理的，则压进DismQueue
        If e.PushToQueue Then
            DismQueue.Add(e)
            AddMsg("添加任务到队列：" & e.Description & vbCrLf & e.Arguments)
            Return
        End If

        If Not IO.File.Exists(DismShell.DismPath) Then
            AddMsg("DISM " & e.Arguments & vbCrLf)
            AddMsg("处理任务失败！" & vbCrLf &
                   "无法找到文件：" & DismShell.DismPath)
            Return
        End If

        '启动执行指令线程处理，以免锁死主线程。
        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf RunSingleMissionProc), DismEventObject)

    End Sub

    ''' <summary>
    ''' 通报处理进度，在此主要是用于锁定任务按钮和操作面板，以免重复操作。
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DismPanelProgressProc(sender As IDismControl, e As UpdateProgressEventArgs)

        If IsNothing(e) Then
            UpdateControlState(True)
            Return
        End If

        '通报Dism面板是否忙碌
        UpdateControlState(e.IsCompleted)

        '设置处理进度条
        If e.IsLoop Then
            If Not e.IsCompleted Then
                UpdateProgressBar(500)
            Else
                UpdateProgressBar(0)
            End If
        Else
            Invoke(New UpdateProgressEventHandler(AddressOf UpdateProcLabel), sender, e)
        End If

    End Sub

    Private Sub UpdateProcLabel(sender As IDismControl, e As UpdateProgressEventArgs)
        lblProc.Visible = (Not e.IsCompleted) And (Not e.Current >= e.Total)
        If e.Total Then
            lblProc.Text = Format(CDbl(e.Current) / CDbl(e.Total), "0.0%")
        Else
            lblProc.Text = "0.0%"
        End If
    End Sub

    ''' <summary>
    ''' 更新画面是否可操作
    ''' </summary>
    ''' <param name="IsEnabled"></param>
    ''' <remarks></remarks>
    Private Sub UpdateControlState(IsEnabled As Boolean)
        If InvokeRequired Then
            Invoke(New UpdateControlStateHandler(AddressOf _UpdateControlState), IsEnabled)
        Else
            _UpdateControlState(IsEnabled)
        End If
    End Sub

    ''' <summary>
    ''' 更新画面是否可操作
    ''' </summary>
    ''' <param name="IsEnabled"></param>
    ''' <remarks></remarks>
    Private Sub _UpdateControlState(IsEnabled As Boolean)
        PDISM_Features.Enabled = IsEnabled
        PDISM_Buffer.Enabled = IsEnabled
        PDISM_Parameters.Enabled = IsEnabled

    End Sub

    ''' <summary>
    ''' 执行所有任务队列
    ''' </summary>
    ''' <param name="sender">Dism面板控件，一般都是PanelQueue对象。</param>
    ''' <remarks></remarks>
    Private Sub RunQueueMissionProc(sender As IDismControl)
        '锁定主界面和设置进度条
        UpdateControlState(False)
        UpdateProgressBar(500)

        Dim DismQueueObject As DismAsyncObject = Nothing
        Dim MC As Integer = DismQueue.Count
        Dim PC As Integer = 0
        Do While DismQueue.Count
            PC += 1
            AddMsg("正在处理任务队列：" & PC & "/" & MC)
            DismQueueObject = New DismAsyncObject(Nothing, DismQueue(0))
            If DismQueueObject.e.HookMessage Then '判断是否需要拦截信息
                RunWithNoWindow(DismQueueObject, False)
            Else
                RunWithWindow(DismQueueObject, False)
            End If
            DismQueue.RemoveAt(0) '清除首个任务。
            sender.UpdateInfo(WimInfoDetail.None) '更新任务队列面板任务列表
        Loop
        AddMsg("所有任务都处理完毕。")

        '解锁主界面和设置进度条
        UpdateProgressBar(0)
        UpdateControlState(True)
    End Sub

    ''' <summary>
    ''' 执行单个任务
    ''' </summary>
    ''' <param name="DataObject"></param>
    ''' <remarks></remarks>
    Private Sub RunSingleMissionProc(DataObject As DismAsyncObject)
        UpdateControlState(False)
        UpdateProgressBar(500)

        If DataObject.e.HookMessage Then
            RunWithNoWindow(DataObject)
        Else
            RunWithWindow(DataObject)
        End If

        UpdateProgressBar(0)
        UpdateControlState(True)
        If Not IsNothing(DataObject) AndAlso (Not IsNothing(DataObject.e)) AndAlso DataObject.e.Mission = DismMissionFlags.CustomCommand Then DataObject.sender.UpdateInfo(WimInfoDetail.None)
    End Sub

    ''' <summary>
    ''' 创建带窗口的Dism处理进程
    ''' </summary>
    ''' <param name="DataObject">数据对象</param>
    ''' <param name="ToUpdateSourceControl">是否需要更新源Dism面板的信息。可选项，默认为 True。</param>
    ''' <remarks></remarks>
    Private Sub RunWithWindow(DataObject As DismAsyncObject, Optional ToUpdateSourceControl As Boolean = True)
        AddMsg(Now.ToString("[yyyy-MM-dd HH:mm:ss]") & "正在执行:" & vbCrLf & "DISM " & DataObject.e.Arguments)
        Dim DismProc As New Process
        With DismProc.StartInfo
            .FileName = DismShell.DismPath
            .Arguments = DataObject.e.Arguments
            .CreateNoWindow = False
            '.RedirectStandardOutput = True
            '.RedirectStandardError = True
            .UseShellExecute = True
        End With

        DismProc.Start()
        DismProc.WaitForExit()
        Dim ExitCode As Integer = DismProc.ExitCode
        DismProc.Dispose()
        DismProc = Nothing

        If ExitCode = 0 Then
            If ToUpdateSourceControl Then
                With DataObject
                    If .e.Mission = DismMissionFlags.MountImage Then .sender.UpdateInfo(WimInfoDetail.MountedWimInfo)
                    If .e.Mission = DismMissionFlags.UnmountImage Then .sender.UpdateInfo(WimInfoDetail.MountedWimInfo)
                    If .e.Mission = DismMissionFlags.RemountImage Then .sender.UpdateInfo(WimInfoDetail.MountedWimInfo)
                    If .e.Mission = DismMissionFlags.CaptureImage Then .sender.UpdateInfo(WimInfoDetail.WimInfo)
                    If .e.Mission = DismMissionFlags.AppendImage Then .sender.UpdateInfo(WimInfoDetail.WimInfo)
                    If .e.Mission = DismMissionFlags.DeleteImage Then .sender.UpdateInfo(WimInfoDetail.WimInfo)
                    If .e.Mission = DismMissionFlags.EnableFeature Then .sender.UpdateInfo(WimInfoDetail.Feature)
                    If .e.Mission = DismMissionFlags.DisableFeature Then .sender.UpdateInfo(WimInfoDetail.Feature)
                    If .e.Mission = DismMissionFlags.AddPackage Then .sender.UpdateInfo(WimInfoDetail.Package)
                    If .e.Mission = DismMissionFlags.RemovePackage Then .sender.UpdateInfo(WimInfoDetail.Package)
                    If .e.Mission = DismMissionFlags.AddDriver Then .sender.UpdateInfo(WimInfoDetail.Driver)
                    If .e.Mission = DismMissionFlags.RemoveDriver Then .sender.UpdateInfo(WimInfoDetail.Driver)
                    If .e.Mission = DismMissionFlags.SetEdition Then .sender.UpdateInfo(WimInfoDetail.Edition)
                    If .e.Mission = DismMissionFlags.SetProductKey Then .sender.UpdateInfo(WimInfoDetail.Edition)
                    If .e.Mission = DismMissionFlags.AddProvisionedAppxPackage Then .sender.UpdateInfo(WimInfoDetail.MetroApps)
                    If .e.Mission = DismMissionFlags.RemoveProvisionedAppxPackage Then .sender.UpdateInfo(WimInfoDetail.MetroApps)
                End With
            End If
            AddMsg(vbCrLf & Now.ToString("[yyyy-MM-dd HH:mm:ss]") & "执行成功！" & vbCrLf)
        Else
            AddMsg(vbCrLf & Now.ToString("[yyyy-MM-dd HH:mm:ss]") & "执行的时候遇到错误：" & ExitCode & vbCrLf)
        End If
    End Sub

    ''' <summary>
    ''' 创建不带窗口的Dism处理进程
    ''' </summary>
    ''' <param name="DataObject">数据对象</param>
    ''' <param name="ToUpdateSourceControl">是否需要更新源Dism面板的信息。可选项，默认为 True。</param>
    ''' <remarks></remarks>
    Private Sub RunWithNoWindow(DataObject As DismAsyncObject, Optional ToUpdateSourceControl As Boolean = True)

        AddMsg(Now.ToString("[yyyy-MM-dd HH:mm:ss]") & "正在执行:" & vbCrLf & "DISM " & DataObject.e.Arguments)
        Dim DismProc As New Process
        With DismProc.StartInfo
            .FileName = DismShell.DismPath
            .Arguments = DataObject.e.Arguments
            .CreateNoWindow = True
            .RedirectStandardOutput = True
            .UseShellExecute = False
        End With
        AddHandler DismProc.OutputDataReceived, AddressOf DismProcess_OutputDataReceived
        DismProc.Start()
        DismProc.BeginOutputReadLine()
        DismProc.WaitForExit()
        RemoveHandler DismProc.OutputDataReceived, AddressOf DismProcess_OutputDataReceived
        Dim ExitCode As Integer = DismProc.ExitCode
        DismProc.Dispose()
        DismProc = Nothing

        If ExitCode = 0 Then
            If ToUpdateSourceControl Then
                With DataObject
                    If .e.Mission = DismMissionFlags.MountImage Then .sender.UpdateInfo(WimInfoDetail.MountedWimInfo)
                    If .e.Mission = DismMissionFlags.UnmountImage Then .sender.UpdateInfo(WimInfoDetail.MountedWimInfo)
                    If .e.Mission = DismMissionFlags.RemountImage Then .sender.UpdateInfo(WimInfoDetail.MountedWimInfo)
                    If .e.Mission = DismMissionFlags.CaptureImage Then .sender.UpdateInfo(WimInfoDetail.WimInfo)
                    If .e.Mission = DismMissionFlags.AppendImage Then .sender.UpdateInfo(WimInfoDetail.WimInfo)
                    If .e.Mission = DismMissionFlags.DeleteImage Then .sender.UpdateInfo(WimInfoDetail.WimInfo)
                    If .e.Mission = DismMissionFlags.EnableFeature Then .sender.UpdateInfo(WimInfoDetail.Feature)
                    If .e.Mission = DismMissionFlags.DisableFeature Then .sender.UpdateInfo(WimInfoDetail.Feature)
                    If .e.Mission = DismMissionFlags.AddPackage Then .sender.UpdateInfo(WimInfoDetail.Package)
                    If .e.Mission = DismMissionFlags.RemovePackage Then .sender.UpdateInfo(WimInfoDetail.Package)
                    If .e.Mission = DismMissionFlags.AddDriver Then .sender.UpdateInfo(WimInfoDetail.Driver)
                    If .e.Mission = DismMissionFlags.RemoveDriver Then .sender.UpdateInfo(WimInfoDetail.Driver)
                    If .e.Mission = DismMissionFlags.SetEdition Then .sender.UpdateInfo(WimInfoDetail.Edition)
                    If .e.Mission = DismMissionFlags.SetProductKey Then .sender.UpdateInfo(WimInfoDetail.Edition)
                    If .e.Mission = DismMissionFlags.AddProvisionedAppxPackage Then .sender.UpdateInfo(WimInfoDetail.MetroApps)
                    If .e.Mission = DismMissionFlags.RemoveProvisionedAppxPackage Then .sender.UpdateInfo(WimInfoDetail.MetroApps)
                End With
            End If
            AddMsg(vbCrLf & Now.ToString("[yyyy-MM-dd HH:mm:ss]") & "执行成功！" & vbCrLf)
        Else
            AddMsg(vbCrLf & Now.ToString("[yyyy-MM-dd HH:mm:ss]") & "执行的时候遇到错误：" & ExitCode & vbCrLf)
        End If

    End Sub

    ''' <summary>
    ''' 拦截信息时的输出事件（不带窗口的Dism进程）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DismProcess_OutputDataReceived(sender As Object, e As DataReceivedEventArgs)
        If Not IsNothing(e.Data) Then AddMsg(e.Data)
    End Sub

    ''' <summary>
    ''' 更新进度条
    ''' </summary>
    ''' <param name="Value">进度</param>
    ''' <remarks></remarks>
    Private Sub UpdateProgressBar(Value As Integer)
        If InvokeRequired Then
            Invoke(New EventHandler(AddressOf _SetProgressBar), Value)
        Else
            _SetProgressBar(Value, Nothing)
        End If
    End Sub

    ''' <summary>
    ''' 更新进度条
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub _SetProgressBar(sender As Object, e As EventArgs)
        PBProc.Value = sender
        PBProc.Style = IIf(PBProc.Value, ProgressBarStyle.Marquee, ProgressBarStyle.Blocks)
    End Sub

#End Region

#Region "指定缓存目录"

    Private Sub LoadScratchDirSettings()
        FSScratchDir.Text = DismConfig.GetItem("ScratchDir", Environment.GetFolderPath(TempFolder))
        ChkScratchDirActived.Checked = DismConfig.GetItem("ScratchDirActived", DefaultScratchDirActived)
        DismConfig.Save()
        FSScratchDir.Enabled = ChkScratchDirActived.Checked
        BtnScratchDirDefault.Enabled = ChkScratchDirActived.Checked
    End Sub

    ''' <summary>
    ''' 启用暂存目录选择变化事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChkScratchDirActived_CheckedChanged(sender As Object, e As EventArgs) Handles ChkScratchDirActived.CheckedChanged
        DismConfig.SetItem("ScratchDirActived", ChkScratchDirActived.Checked)
        DismConfig.Save()
        FSScratchDir.Enabled = ChkScratchDirActived.Checked
        BtnScratchDirDefault.Enabled = ChkScratchDirActived.Checked
        If ChkScratchDirActived.Checked AndAlso Not IO.Directory.Exists(FSScratchDir.Text) Then FSScratchDir.ShowDialog()
    End Sub

    ''' <summary>
    ''' 设置默认暂存目录
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnScratchDirDefault_Click(sender As Object, e As EventArgs) Handles BtnScratchDirDefault.Click
        FSScratchDir.Text = Environment.GetFolderPath(TempFolder)
        DismConfig.SetItem("ScratchDir", FSScratchDir.Text.Trim())
        DismConfig.Save()
        ShowDriveInfo()
    End Sub

    ''' <summary>
    ''' 暂存目录已选择。
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FSScratchDir_FolderSelected(sender As Object, e As EventArgs) Handles FSScratchDir.FileOrFolderSelected
        DismConfig.SetItem("ScratchDir", FSScratchDir.Text.Trim())
        DismConfig.Save()
        ShowDriveInfo()
    End Sub

    ''' <summary>
    ''' 显示暂存目录所在驱动器的信息
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowDriveInfo()
        Dim DI As IO.DriveInfo = GetFolderDriveInfo(FSScratchDir.Text.Trim())
        Dim FreeSpace As ULong = 0
        If Not IsNothing(DI) Then
            FreeSpace = CULng(DI.AvailableFreeSpace)
            lblDriveFreeSpace.Text = GetSizeDescritpion(FreeSpace) & " (" & DI.DriveFormat & ")"
            If FreeSpace < 1073741824UL Then
                lblDriveAlert.Text = "可用空间小于 1GB！有些功能可能无法执行。"
            Else
                lblDriveAlert.Text = ""
            End If

        Else
            lblDriveFreeSpace.Text = ""
            lblDriveAlert.Text = "无法获取该文件夹所在的驱动器信息！"
        End If
    End Sub

    ''' <summary>
    ''' 根据文件夹获取驱动器信息
    ''' </summary>
    ''' <param name="Path">文件夹路径</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetFolderDriveInfo(Path As String) As IO.DriveInfo
        If Not IO.Directory.Exists(Path) Then Return Nothing
        Try
            Dim dirInfo As New IO.DirectoryInfo(Path)
            Return New IO.DriveInfo(dirInfo.FullName)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 获取空间大小的带单位描述。
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSizeDescritpion(Value As ULong) As String
        Dim wSize As ULong = Value
        Dim Level As Integer = 0
        Dim Formatter() As String = {"{0}B",
                                     "{0:F2}KB",
                                     "{0:F2}MB",
                                     "{0:F2}GB",
                                     "{0:F2}TB",
                                     "{0:F2}PB",
                                     "{0:F2}EB",
                                     "{0:F2}ZB",
                                     "{0:F2}YB",
                                     "{0:F2}NB",
                                     "{0:F2}DB"}
        If wSize < 1024 Then Return wSize.ToString & "B"
        Dim Result As Double = CDbl(wSize)
        Dim Unit As Double = 1024.0
        Do While Result >= Unit And Level < 10
            Level += 1
            Result /= Unit
        Loop

        Return String.Format(Formatter(Level), Result)


        '1 kilobyte kB = 1000 (103) byte 
        '1 megabyte MB = 1 000 000 (106) byte 
        '1 gigabyte GB = 1 000 000 000 (109) byte 
        '1 terabyte TB = 1 000 000 000 000 (1012) byte 
        '1 petabyte PB = 1 000 000 000 000 000 (1015) byte 
        '1 exabyte EB = 1 000 000 000 000 000 000 (1018) byte 
        '1 zettabyte ZB = 1 000 000 000 000 000 000 000 (1021) byte 
        '1 yottabyte YB = 1 000 000 000 000 000 000 000 000 (1024) byte 
        '1 nonabyte NB = 1 000 000 000 000 000 000 000 000 000 (1027) byte 
        '1 doggabyte DB = 1 000 000 000 000 000 000 000 000 000 000 (1030) byte 
    End Function

#End Region

#Region "显示信息"

    ''' <summary>
    ''' 显示指定的信息，线程间安全。
    ''' </summary>
    ''' <param name="Msg">信息</param>
    ''' <remarks></remarks>
    Private Sub AddMsg(Msg As String)
        If InvokeRequired Then
            Invoke(New EventHandler(AddressOf _SetMsgProc), Msg)
        Else
            TBDISM_Output.AppendText(Msg & vbCrLf)
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub _SetMsgProc(sender As Object, e As EventArgs)
        TBDISM_Output.AppendText(sender.ToString & vbCrLf)
        TBDISM_Output.ScrollToCaret()
    End Sub

    ''' <summary>
    ''' 清除所有显示的信息
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        TBDISM_Output.Text = ""
    End Sub

#End Region

#Region "当正在处理事件时，退出程序无效。"

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = Not PDISM_Features.Enabled
    End Sub

#End Region

End Class
