Imports System.IO
Public Class DismShell

#Region "映像检查函数"

    ''' <summary>
    ''' 修正映像装载路径
    ''' </summary>
    ''' <param name="ImageName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FixImage(ImageName As String) As String
        If IsNothing(ImageName) Then Return "/Online"
        Dim Temp As String = ImageName.Trim
        If Temp.Length = 0 Or Temp.StartsWith("/Online", StringComparison.OrdinalIgnoreCase) Then Return "/Online"
        Return "/Image:" & FixPath(Temp)
    End Function

    ''' <summary>
    ''' 判断映像是否存在
    ''' </summary>
    ''' <param name="ImageName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ImageExists(ImageName As String) As Boolean
        If IsNothing(ImageName) Then Return False
        Dim Temp As String = ImageName.Trim()
        If Temp = "" Then Return False
        If String.Compare(Temp, "/online", True) = 0 Then Return True
        Return IO.Directory.Exists(Temp)
    End Function

    ''' <summary>
    ''' 修正命令中使用的目录
    ''' </summary>
    ''' <param name="Path"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FixPath(Path As String) As String
        Dim Temp As String = Path.Trim
        If Temp.EndsWith("\") Then Temp = Temp.Substring(0, Temp.Length - 1)
        If Temp.Contains(" ") Then Temp = """" & Temp & """"
        Return Temp
    End Function


#End Region

#Region "创建信息表"

    'DisplayName : Microsoft.ZuneMusic
    'Version : 2014.228.1317.652
    'Architecture : neutral
    'ResourceId : ~
    'PackageName : Microsoft.ZuneMusic_2014.228.1317.652_neutral_~_8wekyb3d8bbwe

    Public Shared ReadOnly Property BuildMetroAppsInfoTable As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add("DisplayName", GetType(String))
            dt.Columns.Add("Version", GetType(String))
            dt.Columns.Add("Architecture", GetType(String))
            dt.Columns.Add("ResourceId", GetType(String))
            dt.Columns.Add("PackageName", GetType(String))
            Return dt
        End Get
    End Property

    ''' <summary>
    ''' 创建装载目录列表
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property BuildMountedWimInfoTable As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add("MountDir", GetType(String))
            dt.Columns.Add("ImageFile", GetType(String))
            dt.Columns.Add("ImageIndex", GetType(UInt32))
            dt.Columns.Add("MountedForRW", GetType(Boolean))
            dt.Columns.Add("Status", GetType(String))
            Return dt
        End Get
    End Property
    ''' <summary>
    ''' 创建映像索引列表
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property BuildWimInfoTable As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add("Index", GetType(UInt32))
            dt.Columns.Add("Name", GetType(String))
            dt.Columns.Add("Description", GetType(String))
            dt.Columns.Add("Size", GetType(ULong))
            Return dt
        End Get
    End Property
    ''' <summary>
    ''' 创建功能列表
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property BuildFeaturesTable As DataTable
        Get
            Dim dt As New DataTable()
            dt.Columns.Add("FeatureName", GetType(String))
            dt.Columns.Add("State", GetType(String))
            Return dt
        End Get
    End Property
    ''' <summary>
    ''' 创建程序包列表
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property BuildPackagesTable As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add("PackageIdentity", GetType(String))
            dt.Columns.Add("State", GetType(String))
            dt.Columns.Add("ReleaseType", GetType(String))
            dt.Columns.Add("InstallTime", GetType(String))
            Return dt
        End Get
    End Property
    ''' <summary>
    ''' 创建驱动列表
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property BuildDriversTable As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add("PublishedName", GetType(String))
            dt.Columns.Add("OriginalFileName", GetType(String))
            dt.Columns.Add("Inbox", GetType(String))
            dt.Columns.Add("ClassName", GetType(String))
            dt.Columns.Add("ProviderName", GetType(String))
            dt.Columns.Add("Date", GetType(String))
            dt.Columns.Add("Version", GetType(String))
            Return dt
        End Get
    End Property

    ''' <summary>
    ''' 创建应用列表
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property BuildAppsTable As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add("ProductCode", GetType(String))
            dt.Columns.Add("ProductName", GetType(String))
            Return dt
        End Get
    End Property

    ''' <summary>
    ''' 创建可用目标版本列表
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property BuildTargetEditionsTable As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add("Edition", GetType(String))
            Return dt
        End Get
    End Property

#End Region

#Region "DISM组件路径"

    Private Shared mDismPath As String = GetDismExecutePath()

    Private Shared Function DismExists() As Boolean
        Return File.Exists(mDismPath)
    End Function

    Private Shared Function GetDismExecutePath() As String
        Dim DismSelector As Integer = DismConfig.GetItem("DismSelector", 0)
        DismConfig.Save()

        Dim Sys As String = System.Environment.SystemDirectory
        If Not Sys.EndsWith("\") Then Sys &= "\"
        Sys &= "DISM.EXE"

        Dim Temp As String = Application.StartupPath
        If Not Temp.EndsWith("\") Then Temp &= "\"

        Dim Local As String = Temp & IIf(System.Environment.Is64BitOperatingSystem, "DISM\x64\DISM.EXE", "DISM\x86\DISM.EXE")

        If DismSelector = 0 Then
            Temp = Sys
            If Not IO.File.Exists(Temp) Then Temp = Local
        Else
            Temp = Local
            If Not IO.File.Exists(Temp) Then Temp = Sys
        End If
        Return Temp
    End Function

    ''' <summary>
    ''' 更新Dism组件路径
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub UpdateDismExecutePath()
        mDismPath = GetDismExecutePath()
    End Sub

    ''' <summary>
    ''' 获取Dism组件路径
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property DismPath As String
        Get
            Return mDismPath
        End Get
    End Property

#End Region

#Region "Dism刷新列表回调函数"

    ''' <summary>
    ''' 执行Dism指令
    ''' </summary>
    ''' <param name="Arguments">参数</param>
    ''' <param name="Output">输出字符串集合</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DismExcute(Arguments As String, Output As List(Of String)) As Integer
        Output.Clear()
        Dim p As New Process
        With p.StartInfo
            .FileName = mDismPath
            .Arguments = Arguments
            .CreateNoWindow = True
            .RedirectStandardOutput = True
            .UseShellExecute = False
        End With
        p.Site = New DismShellDataObject() With {.Data = Output}
        AddHandler p.OutputDataReceived, AddressOf DataRecv
        p.Start()
        p.BeginOutputReadLine()
        p.WaitForExit()
        Dim ExitCode As Integer = p.ExitCode
        RemoveHandler p.OutputDataReceived, AddressOf DataRecv
        p.Dispose()
        Return ExitCode
    End Function

    Public Shared Function DismExcute(Arguments As String) As Integer
        Dim p As New Process
        With p.StartInfo
            .FileName = mDismPath
            .Arguments = Arguments
        End With
        p.Start()
        p.WaitForExit()
        Dim ExitCode As Integer = p.ExitCode
        p.Dispose()
        Return ExitCode
    End Function

    ''' <summary>
    ''' 拦截Dism输出信息事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Shared Sub DataRecv(sender As Object, e As DataReceivedEventArgs)
        Dim p As Process = TryCast(sender, Process)
        If (p IsNot Nothing) AndAlso (e.Data IsNot Nothing) Then
            Dim DataObject As DismShellDataObject = TryCast(p.Site, DismShellDataObject)
            If DataObject IsNot Nothing AndAlso DataObject.Data IsNot Nothing Then
                DataObject.Data.Add(e.Data)
            End If
        End If
    End Sub

#End Region

#Region "获取信息列表"

    Public Shared Function GetMetroAppsInfo(dt As DataTable, Image As String) As DismException
        dt.Rows.Clear()
        If (Not Image.StartsWith("/")) AndAlso (Not Directory.Exists(Image)) Then Return New DismException(-3, "未能找挂载的映像！", "Image")
        If Not DismExists() Then Return New DismException(-2, "未能找到DISM组件！", "DismPath")
        Dim Data As New List(Of String)
        Dim ExitCode As Integer = DismExcute(FixImage(Image) & " /Get-ProvisionedAppxPackages /English", Data)
        If ExitCode = 0 Then
            Dim Temp As String = ""
            Dim dr As DataRow = Nothing
            For i As Integer = 0 To Data.Count - 1
                Temp = Data(i)
                If Temp.StartsWith("DisplayName :") Then
                    dr = dt.NewRow
                    dr("DisplayName") = Temp.Remove(0, 13).Trim()
                ElseIf Temp.StartsWith("Version :") Then
                    dr("Version") = Temp.Remove(0, 9).Trim()
                ElseIf Temp.StartsWith("Architecture :") Then
                    dr("Architecture") = Temp.Remove(0, 14).Trim()
                ElseIf Temp.StartsWith("ResourceId :") Then
                    dr("ResourceId") = Temp.Remove(0, 12).Trim
                ElseIf Temp.StartsWith("PackageName :") Then
                    dr("PackageName") = Temp.Remove(0, 13).Trim
                    dt.Rows.Add(dr)
                End If
                'DisplayName:    Microsoft.ZuneMusic()
                'Version : 2014.228.1317.652
                'Architecture:   neutral()
                'ResourceId : ~
                'PackageName : Microsoft.ZuneMusic_2014.228.1317.652_neutral_~_8wekyb3d8bbwe
            Next
            Return New DismException(ExitCode)
        End If
        Return New DismException(ExitCode, "执行命令遇到错误：" & vbCrLf & Join(Data.ToArray, vbCrLf))
    End Function

    ''' <summary>
    ''' 获取 WIM 文件信息
    ''' </summary>
    ''' <param name="WimFile"></param>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetWimInfo(WimFile As String, dt As DataTable) As DismException

        dt.Rows.Clear()

        If Not File.Exists(WimFile) Then Return New DismException(-1, "映像文件不存在!", "WimFile")
        If Not DismExists() Then Return New DismException(-2, "未能找到DISM组件！", "DismPath")

        Dim Data As New List(Of String)

        Dim ExitCode As Integer = DismExcute("/Get-WimInfo /English /wimfile:" & FixPath(WimFile), Data)

        If ExitCode = 0 Then
            Dim Temp As String = ""
            Dim dr As DataRow = Nothing
            For i As Integer = 0 To Data.Count - 1
                Temp = Data(i)
                If Temp.StartsWith("Index :") Then
                    dr = dt.NewRow
                    Dim ImageIndex As UInt32 = 0
                    UInt32.TryParse(Temp.Remove(0, 7).Trim(), ImageIndex)
                    dr("Index") = ImageIndex
                ElseIf Temp.StartsWith("Name :") Then
                    dr("Name") = Temp.Remove(0, 6).Trim()
                ElseIf Temp.StartsWith("Description :") Then
                    dr("Description") = Temp.Remove(0, 13).Trim()
                ElseIf Temp.StartsWith("Size :") Then
                    Dim wSize As ULong = 0
                    Temp = Temp.ToLower().Remove(0, 6).Replace("bytes", "").Trim()
                    Temp = Temp.Replace(",", "")
                    ULong.TryParse(Temp, wSize)
                    dr("Size") = wSize
                    dt.Rows.Add(dr)
                End If
            Next
            Return New DismException(ExitCode)
        End If

        Return New DismException(ExitCode, "执行命令遇到错误：" & vbCrLf & Join(Data.ToArray(), vbCrLf))

    End Function

    ''' <summary>
    ''' 获取已安装映像信息
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetMountedWimInfo(dt As DataTable) As DismException
        dt.Rows.Clear()
        If Not DismExists() Then Return New DismException(-2, "未能找到DISM组件！", "DismPath")
        Dim Data As New List(Of String)
        Dim ExitCode As Integer = DismExcute("/Get-MountedWimInfo /English", Data)
        If ExitCode = 0 Then
            Dim Temp As String = ""
            Dim dr As DataRow = Nothing
            For i As Integer = 0 To Data.Count - 1
                Temp = Data(i)
                If Temp.StartsWith("Mount Dir :") Then
                    dr = dt.NewRow
                    dr("MountDir") = Temp.Remove(0, 11).Trim()
                ElseIf Temp.StartsWith("Image File :") Then
                    dr("ImageFile") = Temp.Remove(0, 12).Trim()
                ElseIf Temp.StartsWith("Image Index :") Then
                    Dim ImageIndex As UInt32
                    UInt32.TryParse(Temp.Remove(0, 13), ImageIndex)
                    dr("ImageIndex") = ImageIndex
                ElseIf Temp.StartsWith("Mounted Read/Write :") Then
                    Temp = Temp.Remove(0, 20).Trim()
                    dr("MountedForRW") = (String.Compare(Temp, "Yes", True) = 0)
                ElseIf Temp.StartsWith("Status :") Then
                    Temp = Temp.Remove(0, 8).Trim()
                    Select Case Temp.ToLower()
                        Case "ok"
                            Temp = "确定"
                        Case "needs remount"
                            Temp = "需要重新挂载"
                    End Select
                    dr("Status") = Temp
                    dt.Rows.Add(dr)
                End If
            Next
            Return New DismException(ExitCode)
        End If
        Return New DismException(ExitCode, "执行命令遇到错误：" & vbCrLf & Join(Data.ToArray(), vbCrLf))
    End Function

    ''' <summary>
    ''' 获取映像功能列表
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="Image"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFeatures(dt As DataTable, Image As String) As DismException
        dt.Rows.Clear()

        If (Not Image.StartsWith("/")) AndAlso (Not Directory.Exists(Image)) Then Return New DismException(-3, "未能找挂载的映像！", "Image")
        If Not DismExists() Then Return New DismException(-2, "未能找到DISM组件！", "DismPath")

        Dim Data As New List(Of String)

        Dim ExitCode As Integer = DismExcute(FixImage(Image) & " /Get-Features /English", Data)

        If ExitCode = 0 Then

            Dim Temp As String = ""
            Dim dr As DataRow = Nothing
            For i As Integer = 0 To Data.Count - 1
                Temp = Data(i)
                If Temp.StartsWith("Feature Name :") Then
                    dr = dt.NewRow
                    dr("FeatureName") = Temp.Remove(0, 14).Trim()
                ElseIf Temp.StartsWith("State :") Then
                    'Enable Pending
                    'DisablePending
                    Temp = Temp.Remove(0, 7).Trim()
                    Dim Src As String = Temp
                    Temp = Temp.ToLower()
                    Temp = Temp.Replace(" ", "")
                    If Temp = "enabled" Then
                        Temp = "启用"
                    ElseIf Temp = "disabled" Then
                        Temp = "禁用"
                    ElseIf Temp = "enablepending" Then
                        Temp = "启用挂起"
                    ElseIf Temp = "disablepending" Then
                        Temp = "禁用挂起"
                    ElseIf Temp = "disabledwithpayloadremoved" Then
                        Temp = "禁用已删除的负载"
                    Else
                        Temp = Src
                    End If
                    dr!State = Temp
                    dt.Rows.Add(dr)
                End If
            Next
            Return New DismException(ExitCode)
        End If

        Return New DismException(ExitCode, "执行命令遇到错误：" & vbCrLf & Join(Data.ToArray, vbCrLf))
    End Function

    ''' <summary>
    ''' 获取程序包列表
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="Image"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPackages(dt As DataTable, Image As String) As DismException
        dt.Rows.Clear()
        If (Not Image.StartsWith("/")) AndAlso (Not Directory.Exists(Image)) Then Return New DismException(-3, "未能找挂载的映像！", "Image")
        If Not DismExists() Then Return New DismException(-2, "未能找到DISM组件！", "DismPath")
        Dim Data As New List(Of String)
        Dim ExitCode As Integer = DismExcute(FixImage(Image) & " /Get-Packages /English", Data)

        If ExitCode = 0 Then
            Dim Temp As String = ""
            Dim dr As DataRow = Nothing
            Dim Src As String = ""
            For i As Integer = 0 To Data.Count - 1
                Temp = Data(i)
                If Temp.StartsWith("Package Identity :") Then
                    dr = dt.NewRow()
                    dr!PackageIdentity = Temp.Remove(0, 18).Trim()
                ElseIf Temp.StartsWith("State :") Then
                    Temp = Temp.Remove(0, 7).Trim()
                    Src = Temp
                    Select Case Temp.ToLower
                        Case "installed"
                            Temp = "已安装"
                        Case "superseded"
                            Temp = "被取代"
                        Case Else
                            Temp = Src
                    End Select
                    dr!State = Temp
                ElseIf Temp.StartsWith("Release Type :") Then
                    dr!ReleaseType = Temp.Remove(0, 14).Trim()
                ElseIf Temp.StartsWith("Install Time :") Then
                    dr!InstallTime = Temp.Remove(0, 14).Trim()
                    dt.Rows.Add(dr)
                End If
            Next

            'Package Identity : Package_for_KB2911134~31bf3856ad364e35~amd64~~6.3.1.0
            'State : Installed
            'Release Type : Update
            'Install Time : 2013/12/12 1:19
            Return New DismException(0)
        End If
        Return New DismException(ExitCode, "执行命令遇到错误：" & vbCrLf & Join(Data.ToArray, vbCrLf))
    End Function

    ''' <summary>
    ''' 获取驱动列表
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="Image"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetDrivers(dt As DataTable, Image As String) As DismException
        dt.Rows.Clear()

        If (Not Image.StartsWith("/")) AndAlso (Not Directory.Exists(Image)) Then Return New DismException(-3, "未能找挂载的映像！", "Image")

        If Not DismExists() Then Return New DismException(-2, "未能找到DISM组件！", "DismPath")

        Dim Data As New List(Of String)

        Dim ExitCode As Integer = DismExcute(FixImage(Image) & " /Get-Drivers /English", Data)


        If ExitCode = 0 Then
            Dim Temp As String = ""
            Dim dr As DataRow = Nothing
            For i As Integer = 0 To Data.Count - 1
                Temp = Data(i)
                If Temp.StartsWith("Published Name :") Then
                    dr = dt.NewRow
                    dr!PublishedName = Temp.Remove(0, 16).Trim()
                ElseIf Temp.StartsWith("Original File Name :") Then
                    dr!OriginalFileName = Temp.Remove(0, 20).Trim()
                ElseIf Temp.StartsWith("Inbox :") Then
                    Temp = Temp.Remove(0, 7).Trim()
                    dr!Inbox = (String.Compare(Temp, "Yes", True) = 0)
                ElseIf Temp.StartsWith("Class Name :") Then
                    dr!ClassName = Temp.Remove(0, 12).Trim()
                ElseIf Temp.StartsWith("Provider Name :") Then
                    dr!ProviderName = Temp.Remove(0, 15).Trim()
                ElseIf Temp.StartsWith("Date :") Then
                    dr!Date = Temp.Remove(0, 6).Trim()
                ElseIf Temp.StartsWith("Version :") Then
                    dr!Version = Temp.Remove(0, 9).Trim()
                    dt.Rows.Add(dr)
                End If
            Next

            'Published Name : oem8.inf
            'Original File Name : iwdbus.inf
            'Inbox : No
            'Class Name : System
            'Provider Name : Intel Corporation
            'Date : 2013/9/26
            'Version : 4.5.30.0
            Return New DismException(ExitCode)
        End If
        Return New DismException(ExitCode, "执行命令遇到错误：" & vbCrLf & Join(Data.ToArray, vbCrLf))
    End Function

    ''' <summary>
    ''' 获取应用列表
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="Image"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetApplications(dt As DataTable, Image As String) As DismException

        dt.Rows.Clear()
        If Not Directory.Exists(Image) Then Return New DismException(-3, "未能找挂载的映像！", "Image")
        If Not DismExists() Then Return New DismException(-2, "未能找到DISM组件！", "DismPath")
        Dim Data As New List(Of String)
        Dim ExitCode As Integer = DismExcute(FixImage(Image) & " /Get-Apps /English", Data)

        If ExitCode = 0 Then
            Dim Temp As String = ""
            Dim dr As DataRow = Nothing
            For i As Integer = 0 To Data.Count - 1
                Temp = Data(i)
                If Temp.StartsWith("Product Code :") Then
                    dr = dt.NewRow
                    dr!ProductCode = Temp.Remove(0, 14).Trim()
                ElseIf Temp.StartsWith("Product Name :") Then
                    dr!ProductName = Temp.Remove(0, 14).Trim()
                    dt.Rows.Add(dr)
                End If
            Next

            '产品代码 : {CB2F7EDD-9D1F-43C1-90FC-4F52EAE172A1}
            '产品名称 : Microsoft .NET Framework 1.1

            'Product Code : {CB2F7EDD-9D1F-43C1-90FC-4F52EAE172A1}
            'Product Name : Microsoft .NET Framework 1.1

            Return New DismException(ExitCode)
        End If

        Return New DismException(ExitCode, "执行命令遇到错误：" & vbCrLf & Join(Data.ToArray, vbCrLf))

    End Function

    ''' <summary>
    ''' 获取映像当前版本
    ''' </summary>
    ''' <param name="Edition"></param>
    ''' <param name="Image"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCurrentEdition(ByRef Edition As String, Image As String) As DismException
        Edition = ""
        If (Not Image.StartsWith("/")) AndAlso Not Directory.Exists(Image) Then Return New DismException(-3, "未能找挂载的映像！", "Image")
        If Not DismExists() Then Return New DismException(-2, "未能找到DISM组件！", "DismPath")
        Dim Data As New List(Of String)
        Dim ExitCode As Integer = DismExcute(FixImage(Image) & " /Get-CurrentEdition /English", Data)
        If ExitCode = 0 Then
            For Each Line As String In Data
                If Line.StartsWith("Current Edition :") Then
                    Edition = Line.Remove(0, 17).Trim()
                    Exit For
                End If
            Next
            Return New DismException(ExitCode)
        End If
        Return New DismException(ExitCode, "执行命令遇到错误：" & vbCrLf & Join(Data.ToArray, vbCrLf))
    End Function

    ''' <summary>
    ''' 获取映像可用升级版本列表
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="Image"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetTargetEditions(dt As DataTable, Image As String) As DismException
        dt.Clear()
        If (Not Image.StartsWith("/")) AndAlso Not Directory.Exists(Image) Then Return New DismException(-3, "未能找挂载的映像！", "Image")
        If Not DismExists() Then Return New DismException(-2, "未能找到DISM组件！", "DismPath")
        Dim Data As New List(Of String)
        Dim ExitCode As Integer = DismExcute(FixImage(Image) & " /Get-TargetEditions /English", Data)
        If ExitCode = 0 Then
            Dim Temp As String = ""
            Dim dr As DataRow = Nothing
            For i As Integer = 0 To Data.Count - 1
                Temp = Data(i)
                If Temp.StartsWith("Target Edition :") Then
                    dr = dt.NewRow
                    dr!Edition = Temp.Remove(0, 16).Trim()
                    dt.Rows.Add(dr)
                End If
            Next
            Return New DismException(ExitCode)
        End If
        Return New DismException(ExitCode, "执行命令遇到错误：" & vbCrLf & Join(Data.ToArray, vbCrLf))
    End Function

#End Region

#Region "创建功能执行命令"

    ''' <summary>
    ''' 创建设置版本参数
    ''' </summary>
    ''' <param name="Image">已安装映像</param>
    ''' <param name="Edition">版本</param>
    ''' <param name="ProductKey">产品密钥</param>
    ''' <param name="IsApplyProductKey">是否应用产品密钥</param>
    ''' <param name="AcceptEula">接受更高版本协议</param>
    ''' <param name="GetEulaPath">保存协议路径</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateSetEditionArguments(Image As String,
                                                     Edition As String,
                                                     ProductKey As String,
                                                     Optional IsApplyProductKey As Boolean = False,
                                                     Optional AcceptEula As Boolean = False,
                                                     Optional GetEulaPath As String = "") As String
        Dim Temp As String = FixImage(Image)
        Temp = Temp & " /Set-Edition:" & Edition
        If IsApplyProductKey Then Temp = Temp & " /ProductKey:" & ProductKey
        If AcceptEula Then Temp = Temp & " /AcceptEula"
        If GetEulaPath <> "" Then Temp = Temp & " /GetEula:""" & GetEulaPath & """"
        Return Temp

    End Function

    ''' <summary>
    ''' 创建设置产品密钥参数
    ''' </summary>
    ''' <param name="Image">已安装映像</param>
    ''' <param name="ProductKey">产品密钥</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateSetProductKeyArguments(Image As String, ProductKey As String) As String
        Dim Temp As String = FixImage(Image)
        Temp = Temp & " /ProductKey:" & ProductKey
        Return Temp
    End Function
    ''' <summary>
    ''' 创建挂载映像参数
    ''' </summary>
    ''' <param name="WimFile">.WIM 文件路径</param>
    ''' <param name="MountDir">挂载路径</param>
    ''' <param name="Index">映像索引</param>
    ''' <param name="IsReadOnly">是否以只读方式挂载</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateMountImageArguments(WimFile As String,
                                                     MountDir As String,
                                                     Index As UInt32,
                                                     Optional IsReadOnly As Boolean = False) As String
        Return "/Mount-Wim /WimFile:" & FixPath(WimFile) & " /MountDir:" & FixPath(MountDir) & " /Index:" & Index & IIf(IsReadOnly, " /ReadOnly", "")
    End Function

    ''' <summary>
    ''' 创建卸载映像参数
    ''' </summary>
    ''' <param name="MountDir">挂载目录</param>
    ''' <param name="CommitChanges">是否保存更改</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateUnMountImageArguments(MountDir As String, CommitChanges As Boolean, Optional Append As Boolean = False) As String
        Return "/Unmount-Wim /MountDir:" & FixPath(MountDir) & " " & IIf(CommitChanges, "/Commit", "/Discard") & IIf(Append, " /Append", "")
    End Function

    ''' <summary>
    ''' 创建应用映像参数
    ''' </summary>
    ''' <param name="WimFile">.WIM 文件</param>
    ''' <param name="ApplyDir">应用目录</param>
    ''' <param name="Index">映像索引</param>
    ''' <param name="CheckIntegrity">如果检测到 WIM 文件损坏，则使用 /CheckIntegrity 停止操作</param>
    ''' <param name="Verify">检查错误和文件重复</param>
    ''' <param name="NoRpFix">禁用重分析点标记修复</param>
    ''' <param name="ConfirmTrustedFile">验证受信任的桌面映像</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateApplyImageArgumnets(WimFile As String,
                                                     ApplyDir As String,
                                                     Index As UInt32,
                                                     Optional CheckIntegrity As Boolean = False,
                                                     Optional Verify As Boolean = False,
                                                     Optional NoRpFix As Boolean = False,
                                                     Optional ConfirmTrustedFile As Boolean = False,
                                                     Optional WIMBoot As Boolean = False) As String

        Dim Temp As String = "/Apply-Image /ImageFile:" & FixPath(WimFile)
        If File.Exists(WimFile) Then
            Dim fInfo As New IO.FileInfo(WimFile)
            If fInfo.Extension.ToLower = ".swm" Then
                Temp = Temp & " /SWMFile:" & FixPath(fInfo.FullName.Substring(0, fInfo.FullName.Length - fInfo.Extension.Length) & "*" & fInfo.Extension)
            End If
        End If

        Temp = Temp & " /ApplyDir:" & FixPath(ApplyDir) & " /Index:" & Index

        If CheckIntegrity Then Temp = Temp & " /CheckIntegrity"
        If Verify Then Temp = Temp & " /Verify"
        If NoRpFix Then Temp = Temp & " /NoRpFix"
        If ConfirmTrustedFile Then Temp = Temp & " /ConfirmTrustedFile"
        If WIMBoot Then Temp = Temp & " /WIMBoot"

        Return Temp

        '/Apply-Image /ImageFile:<path_to_image_file> /ApplyDir:<target_directory>
        '{/Index:<image_index> | /Name:<image_name>} [/CheckIntegrity] [/Verify]
        '[/NoRpFix] [/SWMFile:<pattern>] [/ConfirmTrustedFile]

        '将映像应用到指定的驱动器。
        '如果检测到 WIM 文件损坏，则使用 /CheckIntegrity 停止操作。
        '可以使用 /Verify 检查错误和文件重复。
        '可以使用 /NoRpFix 禁用重分析点标记修复。
        '可以使用 /SWMFile 引用拆分的 WIM 文件(SWM)。<pattern> 是拆分文件的命名模式和位置。
        '可以使用 /ConfirmTrustedFile 验证受信任的桌面映像。有关支持的平台的详细信息, 请参阅 http://go.microsoft.com/fwlink/?LinkID=309482。
    End Function

    ''' <summary>
    ''' 创建捕获映像到新的 .WIM 文件参数
    ''' </summary>
    ''' <param name="WimFile"></param>
    ''' <param name="CaptureDir"></param>
    ''' <param name="Name"></param>
    ''' <param name="Description"></param>
    ''' <param name="Compress"></param>
    ''' <param name="ConfigFile"></param>
    ''' <param name="Bootable"></param>
    ''' <param name="CheckIntegrity"></param>
    ''' <param name="Verify"></param>
    ''' <param name="NoRpFix"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateCaptureImageArguments(WimFile As String,
                                                       CaptureDir As String,
                                                       Name As String,
                                                       Description As String,
                                                       Compress As String,
                                                       Optional ConfigFile As String = "",
                                                       Optional Bootable As Boolean = False,
                                                       Optional CheckIntegrity As Boolean = False,
                                                       Optional Verify As Boolean = False,
                                                       Optional NoRpFix As Boolean = False,
                                                       Optional WIMBoot As Boolean = False) As String
        Dim Temp As String = "/Capture-Image /ImageFile:" & FixPath(WimFile) & " /CaptureDir:" & FixPath(CaptureDir) &
                             " /Name:" & FixPath(Name) & IIf(Description = "", "", " /Description:" & FixPath(Description))
        If Not WIMBoot Then Temp = Temp & " /Compress:" & Compress
        If ConfigFile <> "" Then Temp = Temp & " /ConfigFile:" & FixPath(ConfigFile)
        If Bootable Then Temp = Temp & " /Bootable"
        If CheckIntegrity Then Temp = Temp & " /CheckIntegrity"
        If Verify Then Temp = Temp & " /Verify"
        If NoRpFix Then Temp = Temp & " /NoRpFix"
        If WIMBoot Then Temp = Temp & " /WIMBoot"
        Return Temp

        '  /Capture-Image /ImageFile:<path_to_image_file> /CaptureDir:<source_directory>
        '  /Name:<Name>
        '  [/Description:Description] [/ConfigFile:<wimscript.ini>]
        '  [/Compress:{fast|max|none}] [/Bootable] [/CheckIntegrity] [/Verify]
        '  [/NoRpFix]

        '  将驱动器的映像捕获到新的 WIM 文件中。捕获的目录包括
        '所有子文件夹和数据。无法捕获空目录。
        '  可以使用 /ConfigFile 指定列出了
        '映像捕获和压缩命令的排除项的配置文件所在的位置。
        '  可以使用 /Compress 指定用于执行初始捕获操作的压缩
        '类型。
        '  可以使用 /Bootable 将 Windows PE 卷映像标记为能够引导。
        '  可以使用 /CheckIntegrity 检测和跟踪 WIM 文件是否损坏。
        '  可以使用 /Verify 检查错误和文件重复。
        '  可以使用 /NoRpFix 禁用重分析点标记修复。

        '示例:
        '      DISM.exe /Capture-Image /ImageFile:install.wim /CaptureDir:D:\
        '        /Name:Drive-D

    End Function

    Public Shared Function CreateCaptureCustomImageArguments(CaptureDir As String,
                                                             Optional ConfigFile As String = "",
                                                             Optional CheckIntegrity As Boolean = False,
                                                             Optional Verify As Boolean = False) As String
        Dim Temp As String = "/Capture-CustomImage /CaptureDir:" & FixPath(CaptureDir)
        If ConfigFile <> "" Then Temp = Temp & " /ConfigFile:" & FixPath(ConfigFile)
        If CheckIntegrity Then Temp = Temp & " /CheckIntegrity"
        If Verify Then Temp = Temp & " /Verify"
        Return Temp
    End Function

    ''' <summary>
    ''' 创建捕获映像追加到已有 .WIM 文件参数
    ''' </summary>
    ''' <param name="WimFile"></param>
    ''' <param name="CaptureDir"></param>
    ''' <param name="Name"></param>
    ''' <param name="Description"></param>
    ''' <param name="ConfigFile"></param>
    ''' <param name="Bootable"></param>
    ''' <param name="CheckIntegrity"></param>
    ''' <param name="Verify"></param>
    ''' <param name="NoRpFix"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateAppendImageArguments(WimFile As String,
                                                       CaptureDir As String,
                                                       Name As String,
                                                       Description As String,
                                                       Optional ConfigFile As String = "",
                                                       Optional Bootable As Boolean = False,
                                                       Optional CheckIntegrity As Boolean = False,
                                                       Optional Verify As Boolean = False,
                                                       Optional NoRpFix As Boolean = False,
                                                       Optional WIMBoot As Boolean = False) As String
        Dim Temp As String = "/Append-Image /ImageFile:" & FixPath(WimFile) & " /CaptureDir:" & FixPath(CaptureDir) &
                             " /Name:" & FixPath(Name) & IIf(Description = "", "", " /Description:" & FixPath(Description))

        If ConfigFile <> "" Then Temp = Temp & " /ConfigFile:" & FixPath(ConfigFile)
        If Bootable Then Temp = Temp & " /Bootable"
        If CheckIntegrity Then Temp = Temp & " /CheckIntegrity"
        If Verify Then Temp = Temp & " /Verify"
        If NoRpFix Then Temp = Temp & " /NoRpFix"
        If WIMBoot Then Temp = Temp & " /WIMBoot"
        Return Temp

        '/Append-Image /ImageFile:<path_to_image_file> /CaptureDir:<source_directory>
        '  /Name:<Name>
        '  [/Description:Description] [/ConfigFile:<wimscript.ini>]
        '  [/Bootable] [/CheckIntegrity] [/Verify] [/NoRpFix]

        '  将其他映像添加到 WIM 文件中。
        '  使用 /ConfigFile 指定列出了
        '  映像捕获和压缩命令的排除项的配置文件所在的位置。
        '  使用 /Bootable 将 Windows PE 卷映像标记为能够启动。
        '  使用 /CheckIntegrity 检测和跟踪 WIM 文件损坏。
        '  使用 /Verify 检查错误和文件重复。
        '  使用 /NoRpFix 禁用重分析点标记修复。

        '示例:
        '      DISM.exe /Append-Image /ImageFile:install.wim /CaptureDir:D:\
        '        /Name:Drive-D


    End Function

    ''' <summary>
    ''' 创建删除映像参数
    ''' </summary>
    ''' <param name="WimFile"></param>
    ''' <param name="Index"></param>
    ''' <param name="CheckIntegrity"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateDeleteImageArguments(WimFile As String, Index As UInt32, Optional CheckIntegrity As Boolean = False) As String

        Return "/Delete-Image /ImageFile:" & FixPath(WimFile) & " /Index:" & Index & IIf(CheckIntegrity, " /CheckIntegrity", "")

        '/Delete-Image /ImageFile:<path_to_image_file>
        '  {/Index:<image_index> | /Name:<image_name>} [/CheckIntegrity]

        '  从具有多个卷映像的 WIM 文件中删除指定的
        '  卷映像。
        '  使用 /CheckIntegrity 检测和跟踪 WIM 文件损坏。

        '示例:
        '      DISM.exe /Delete-Image /ImageFile:install.wim /Index:1
    End Function

    ''' <summary>
    ''' 创建导出映像参数
    ''' </summary>
    ''' <param name="SourecImageFile"></param>
    ''' <param name="SourceIndex"></param>
    ''' <param name="DestinationImageFile"></param>
    ''' <param name="DestinationName"></param>
    ''' <param name="Compress"></param>
    ''' <param name="Bootable"></param>
    ''' <param name="CheckIntegrity"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateExportImageArguments(SourecImageFile As String,
                                                      SourceIndex As UInt32,
                                                      DestinationImageFile As String,
                                                      Optional DestinationName As String = "",
                                                      Optional Compress As String = "Fast",
                                                      Optional Bootable As Boolean = False,
                                                      Optional CheckIntegrity As Boolean = False,
                                                      Optional WIMBoot As Boolean = False) As String

        Dim Temp As String = "/Export-Image /SourceImageFile:" & FixPath(SourecImageFile)

        If File.Exists(SourecImageFile) Then
            Dim fInfo As New IO.FileInfo(SourecImageFile)
            If fInfo.Extension.ToLower = ".swm" Then
                Temp = Temp & " /SWMFile:" & FixPath(fInfo.FullName.Substring(0, fInfo.FullName.Length - fInfo.Extension.Length) & "*" & fInfo.Extension)
            End If
        End If

        Temp = Temp & " /SourceIndex:" & SourceIndex & " /DestinationImageFile:" & FixPath(DestinationImageFile)
        If DestinationName <> "" Then Temp = Temp & " /DestinationName:" & FixPath(DestinationName)
        If Compress <> "" AndAlso (Not WIMBoot) Then Temp = Temp & " /Compress:" & Compress
        If Bootable Then Temp = Temp & " /Bootable"
        If CheckIntegrity Then Temp = Temp & " /CheckIntegrity"
        If WIMBoot Then Temp = Temp & " /WIMBoot"
        Return Temp

        '/Export-Image {/SourceImageFile:<path_to_image_file> | [/SWMFile:<pattern>]}
        '  {/SourceIndex:<image_index> | /SourceName:<image_name>}
        '  /DestinationImageFile:<path_to_image_file> [/DestinationName:<Name>]
        '  [/Compress:{fast|max|none|recovery}] [/Bootable] [/CheckIntegrity]

        '  将指定映像的副本导出到其他文件。
        '  源文件和目标文件必须使用同一种压缩类型。
        '  可以使用 /SWMFile 引用拆分的 WIM 文件(SWM)。
        '  <pattern> 是拆分文件的命名模式和位置。
        '  可以使用 /Compress 指定在将映像导出到新 WIM 文件时
        '  用于捕获操作的压缩类型。
        '  可以使用 /Bootable 将 Windows PE 卷映像标记为能够引导。
        '  可以使用 /CheckIntegrity 检测和跟踪 WIM 文件损坏。

        '示例:
        '      DISM.exe /Export-Image /SourceImageFile:install.wim /SourceIndex:1
        '        /DestinationImageFile:install2.wim

    End Function

    ''' <summary>
    ''' 创建拆分 .WIM 文件参数
    ''' </summary>
    ''' <param name="WimFile"></param>
    ''' <param name="SWMFile"></param>
    ''' <param name="FileSize"></param>
    ''' <param name="CheckIntegrity"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateSplitImageArguments(WimFile As String,
                                                     SWMFile As String,
                                                     FileSize As UInt32,
                                                     Optional CheckIntegrity As Boolean = False) As String
        Return "/Split-Image /ImageFile:" & FixPath(WimFile) & " /SWMFile:" & FixPath(SWMFile) & " /FileSize:" &
               FileSize & IIf(CheckIntegrity, " /CheckIntegrity", "")
        '/Split-Image
        '  /ImageFile:<path_to_image_file> /SWMFile:<path_to_swm> /FileSize:<MB-Size>
        '  [/CheckIntegrity]

        '  将现有 .wim 文件拆分为多个只读 WIM 拆分文件。
        '  使用 /FileSize 为创建的每个文件指定最大
        '大小(兆字节(MB))。
        '  使用 /CheckIntegrity 检测和跟踪 WIM 文件损坏。

        '示例:
        '      DISM.exe /Split-Image /ImageFile:install.wim /SWMFile:split.swm
        '        /FileSize:650

    End Function

    ''' <summary>
    ''' 创建重新挂载映像参数
    ''' </summary>
    ''' <param name="MountDir"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateRemountImageArguments(MountDir As String) As String
        Return "/Remount-Wim /MountDir:" & FixPath(MountDir)

        '/Remount-Image /MountDir:<target_mount_directory>

        '  恢复孤立的映像安装目录。

        '示例:
        '      DISM.exe /Remount-Image /MountDir:C:\test\offline

    End Function

    ''' <summary>
    ''' 创建保存对挂载的映像所做的更改
    ''' </summary>
    ''' <param name="MountDir"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateCommitImageArguments(MountDir As String, Optional Append As Boolean = False) As String

        Return "/Commit-Wim /MountDir:" & FixPath(MountDir) & IIf(Append, " /Append", "")

        '/Commit-Wim /MountDir:<target_mount_directory>

        '  应用对装载的映像所做的更改。在使用 /Unmount-Wim 选项之前，
        '  映像一直保持装载。

        '示例:
        '      DISM.exe /Commit-Wim /MountDir:C:\test\offline
    End Function

    ''' <summary>
    ''' 创建清理损坏映像文件参数
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateCleanupImageArguments() As String
        Return "/Cleanup-Wim"
    End Function

    ''' <summary>
    ''' 创建启用映像功能参数
    ''' </summary>
    ''' <param name="Image"></param>
    ''' <param name="FeatureName"></param>
    ''' <param name="SourceList"></param>
    ''' <param name="All"></param>
    ''' <param name="LimitAccess"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateEnableFeatureArguments(Image As String, FeatureName As String, SourceList() As String, Optional All As Boolean = False, Optional LimitAccess As Boolean = False) As String
        Dim Temp As String = FixImage(Image)
        Temp = Temp & " /Enable-Feature /FeatureName:" & FixPath(FeatureName)
        If All Then Temp = Temp & " /All"
        If LimitAccess Then Temp = Temp & " /LimitAccess"
        If SourceList IsNot Nothing Then
            For Each Src As String In SourceList
                Temp = Temp & " /Source:" & FixPath(Src)
            Next
        End If
        Return Temp
    End Function

    ''' <summary>
    ''' 创建禁用功能参数
    ''' </summary>
    ''' <param name="Image"></param>
    ''' <param name="FeatureName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateDisableFeatureArguments(Image As String, FeatureName As String) As String
        Dim Temp As String = FixImage(Image)
        Temp = Temp & " /Disable-Feature /FeatureName:" & FixPath(FeatureName)
        Return Temp
    End Function

    ''' <summary>
    ''' 创建添加程序包参数
    ''' </summary>
    ''' <param name="Image"></param>
    ''' <param name="PackagePath"></param>
    ''' <param name="IgnoreCheck"></param>
    ''' <param name="PreventPending"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateAddPackageArguments(Image As String, PackagePath As String, Optional IgnoreCheck As Boolean = False, Optional PreventPending As Boolean = False) As String
        Dim Temp As String = FixImage(Image)
        Temp = Temp & " /Add-Package /PackagePath:" & FixPath(PackagePath)
        If IgnoreCheck Then Temp = Temp & " /IgnoreCheck"
        If PreventPending Then Temp = Temp & " /PreventPending"
        Return Temp
    End Function

    ''' <summary>
    ''' 创建删除程序包参数
    ''' </summary>
    ''' <param name="Image"></param>
    ''' <param name="PackageIdentity"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateRemovePackageArguments(Image As String, PackageIdentity As String) As String
        Dim Temp As String = FixImage(Image)
        Return Temp & " /Remove-Package /PackageName:" & FixPath(PackageIdentity)
    End Function

    ''' <summary>
    ''' 创建添加驱动参数
    ''' </summary>
    ''' <param name="Image"></param>
    ''' <param name="Driver"></param>
    ''' <param name="Recurse"></param>
    ''' <param name="ForceUnsigned"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateAddDriverArguments(Image As String,
                                           Driver As String,
                                           Optional Recurse As Boolean = True,
                                           Optional ForceUnsigned As Boolean = False) As String
        Dim Temp As String = "/Image:" & FixPath(Image) & " /Add-Driver /Driver:" & FixPath(Driver)
        If Recurse Then Temp = Temp & " /Recurse"
        If ForceUnsigned Then Temp = Temp & " /ForceUnsigned"
        Return Temp
    End Function

    ''' <summary>
    ''' 创建删除驱动参数
    ''' </summary>
    ''' <param name="Image"></param>
    ''' <param name="Driver"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateRemoveDriverArguments(Image As String, Driver As String) As String
        Dim Temp As String = "/Image:" & FixPath(Image) & " /Remove-Driver /Driver:" & FixPath(Driver)
        Return Temp
    End Function

    ''' <summary>
    ''' 创建无人参与服务参数
    ''' </summary>
    ''' <param name="Image"></param>
    ''' <param name="UnattendFile"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateUnattendArgumenets(Image As String, UnattendFile As String) As String
        Dim Temp As String = FixImage(Image)
        Return Temp = Temp & " /Apply-Unattend:" & FixPath(UnattendFile)
    End Function

    Public Shared Function CreateAddMetroPackage(Image As String,
                                                 PackagePath As String,
                                                 DependencyPackagePath As String(),
                                                 LicensePath As String,
                                                 CustomDataPath As String,
                                                 Optional SkipLicense As Boolean = False) As String
        Dim Temp As String = FixImage(Image) & " /Add-ProvisionedAppxPackage"
        If (Not IsNothing(DependencyPackagePath)) AndAlso DependencyPackagePath.Length Then
            For Each s As String In DependencyPackagePath
                If s.Trim <> "" Then Temp = Temp & " /DependencyPackagePath:" & FixPath(s.Trim())
            Next
        End If
        If LicensePath.Trim() <> "" Then Temp = Temp & " /LicensePath:" & FixPath(LicensePath.Trim())
        If CustomDataPath.Trim() <> "" Then Temp = Temp & " /CustomDataPath:" & FixPath(CustomDataPath.Trim())
        If SkipLicense Then Temp = Temp & " /SkipLicense"
        Return Temp
    End Function

    Public Shared Function CreateAddMetroPackage(Image As String, FolderPath As String, Optional SkipLicense As Boolean = False) As Boolean
        Dim Temp As String = FixImage(Image) & " /Add-ProvisionedAppxPackage /FolderPath:" & FixPath(FolderPath)
        If SkipLicense Then Temp = Temp & " /SkipLicense"
        Return Temp
    End Function

    Public Shared Function CreateRemoveMetroPackage(Image As String, PackageName As String) As String
        Return FixImage(Image) & " /Remove-ProvisionedAppxPackage /PackageName:" & PackageName
    End Function

    '    Dism /Image:C:\test\offline /Add-ProvisionedAppxPackage /FolderPath:c:\Test\Apps\MyUnpackedApp /CustomDataPath:c:\Test\Apps\CustomData.xml
    'Dism /Online /Add-ProvisionedAppxPackage /PackagePath:C:\Test\Apps\MyPackedApp\MainPackage.appx /DependencyPackagePath:C:\Test\Apps\MyPackedApp\Framework-x86.appx /DependencyPackagePath:C:\Test\Apps\MyPackedApp\Framework-x64.appx /LicensePath:C:\Test\Apps\MyLicense.xml
    'Dism /Online /Add-ProvisionedAppxPackage /FolderPath:C:\Test\Apps\MyUnpackedApp /SkipLicense
    'Dism /Image:C:\test\offline /Add-ProvisionedAppxPackage /PackagePath:C:\Test\Apps\MyPackedApp\MainPackage.appxbundle /SkipLicense
#End Region

End Class
