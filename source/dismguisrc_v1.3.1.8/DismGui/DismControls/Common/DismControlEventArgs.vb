''' <summary>
''' 表示Dism面板控件事件数据
''' </summary>
''' <remarks></remarks>
<Serializable> _
Public Class DismControlEventArgs

    Inherits EventArgs
    ''' <summary>
    ''' 获取或者设置DISM的参数
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Arguments As String = ""

    ''' <summary>
    ''' 获取或者设置任务标识
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Mission As DismMissionFlags = DismMissionFlags.None

    ''' <summary>
    ''' 获取或者设置任务描述
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Description As String = ""

    ''' <summary>
    ''' 获取或者设置附加信息
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Message As String = ""

    ''' <summary>
    ''' 获取或者设置一个标识，指示是否拦截消息
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property HookMessage As Integer = 0

    ''' <summary>
    ''' 获取或者设置一个标识，指示是否将任务添加到任务队列
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PushToQueue As Boolean = False

    ''' <summary>
    ''' 获取或者设置创建任务的时间
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property [Date] As Date = Now

    ''' <summary>
    ''' 创建Dism面板控件事件数据对象
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()


    End Sub

    ''' <summary>
    ''' 创建Dism面板控件事件数据对象
    ''' </summary>
    ''' <param name="Arguments">执行参数</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Arguments As String)
        Me.Arguments = Arguments
    End Sub

    ''' <summary>
    ''' 创建Dism面板控件事件数据对象
    ''' </summary>
    ''' <param name="Arguments">执行参数</param>
    ''' <param name="Mission">任务标识</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Arguments As String, Mission As DismMissionFlags)
        Me.Arguments = Arguments
        Me.Mission = Mission
    End Sub

    ''' <summary>
    ''' 创建Dism面板控件事件数据对象
    ''' </summary>
    ''' <param name="Arguments">执行参数</param>
    ''' <param name="Mission">任务标识</param>
    ''' <param name="Description">任务描述</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Arguments As String, Mission As DismMissionFlags, Description As String)
        Me.Arguments = Arguments
        Me.Mission = Mission
        Me.Description = Description
    End Sub

    ''' <summary>
    ''' 创建Dism面板控件事件数据对象
    ''' </summary>
    ''' <param name="Arguments">执行参数</param>
    ''' <param name="Mission">任务标识</param>
    ''' <param name="Description">任务描述</param>
    ''' <param name="HookMessage">是否拦截消息</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Arguments As String, Mission As DismMissionFlags, Description As String, HookMessage As Integer)
        Me.Arguments = Arguments
        Me.Mission = Mission
        Me.Description = Description
        Me.HookMessage = HookMessage
    End Sub

    Public Overrides Function ToString() As String
        Return Me.Arguments
    End Function

End Class

''' <summary>
''' 任务标识
''' </summary>
''' <remarks></remarks>
Public Enum DismMissionFlags As Integer
    ''' <summary>
    ''' 无
    ''' </summary>
    ''' <remarks></remarks>
    None = 0
    ''' <summary>
    ''' 从 WIM 文件中装载映像
    ''' </summary>
    ''' <remarks></remarks>
    MountImage
    ''' <summary>
    ''' 更新映像，但不卸载。
    ''' </summary>
    ''' <remarks></remarks>
    CommitImage
    ''' <summary>
    ''' 应用一个映像
    ''' </summary>
    ''' <remarks></remarks>
    ApplyImage
    ''' <summary>
    ''' 卸载已安装 WIM 映像
    ''' </summary>
    ''' <remarks></remarks>
    UnmountImage
    ''' <summary>
    ''' 将指定目录的映像捕获到新的 WIM 文件中
    ''' </summary>
    ''' <remarks></remarks>
    CaptureImage
    ''' <summary>
    ''' 捕获 WIMBoot 映像自定义配置文件
    ''' </summary>
    ''' <remarks></remarks>
    CaptureCustomImage
    ''' <summary>
    ''' 将指定目录的映像添加到 WIM 文件中
    ''' </summary>
    ''' <remarks></remarks>
    AppendImage
    ''' <summary>
    ''' 将指定映像的副本导出到其他文件
    ''' </summary>
    ''' <remarks></remarks>
    ExportImage
    ''' <summary>
    ''' 将现有 .wim 文件拆分为多个只读 WIM (SWM)拆分文件
    ''' </summary>
    ''' <remarks></remarks>
    SplitImage
    ''' <summary>
    ''' 从具有多个卷映像的 WIM 文件删除指定的卷映像
    ''' </summary>
    ''' <remarks></remarks>
    DeleteImage
    ''' <summary>
    ''' 恢复孤立的映像装载目录
    ''' </summary>
    ''' <remarks></remarks>
    RemountImage
    ''' <summary>
    ''' 删除与损坏的已安装 WIM 映像关联的资源
    ''' </summary>
    ''' <remarks></remarks>
    CleanupImage
    ''' <summary>
    ''' 启用映像中的特定功能
    ''' </summary>
    ''' <remarks></remarks>
    EnableFeature
    ''' <summary>
    ''' 禁用映像中的特定功能
    ''' </summary>
    ''' <remarks></remarks>
    DisableFeature
    ''' <summary>
    ''' 向映像中添加程序包
    ''' </summary>
    ''' <remarks></remarks>
    AddPackage
    ''' <summary>
    ''' 从映像中删除程序包
    ''' </summary>
    ''' <remarks></remarks>
    RemovePackage
    ''' <summary>
    ''' 向脱机映像中添加驱动程序包
    ''' </summary>
    ''' <remarks></remarks>
    AddDriver
    ''' <summary>
    ''' 从脱机映像中删除驱动程序包
    ''' </summary>
    ''' <remarks></remarks>
    RemoveDriver
    ''' <summary>
    ''' 显示当前映像的版本
    ''' </summary>
    ''' <remarks></remarks>
    GetCurrentEdition
    ''' <summary>
    ''' 将映像升级到较高的版本
    ''' </summary>
    ''' <remarks></remarks>
    SetEdition
    ''' <summary>
    ''' 设置脱机映像的产品密钥
    ''' </summary>
    ''' <remarks></remarks>
    SetProductKey
    ''' <summary>
    ''' 将无人参与文件应用于映像
    ''' </summary>
    ''' <remarks></remarks>
    ApplyUnattend
    ''' <summary>
    ''' 显示有关 MSP 修补程序是否适用于安装的映像的信息
    ''' </summary>
    ''' <remarks></remarks>
    CheckAppPatch
    ''' <summary>
    ''' 显示有关安装的 MSP 修补程序的信息
    ''' </summary>
    ''' <remarks></remarks>
    GetAppPatchInfo
    ''' <summary>
    ''' 自定义命令
    ''' </summary>
    ''' <remarks></remarks>
    CustomCommand
    ''' <summary>
    ''' 添加Metro应用
    ''' </summary>
    ''' <remarks></remarks>
    AddProvisionedAppxPackage
    ''' <summary>
    ''' 删除Metro应用
    ''' </summary>
    ''' <remarks></remarks>
    RemoveProvisionedAppxPackage
    ''' <summary>
    ''' 执行队列
    ''' </summary>
    ''' <remarks></remarks>
    RunQueue
    ''' <summary>
    ''' 递交信息
    ''' </summary>
    ''' <remarks></remarks>
    PostMessage
End Enum

''' <summary>
''' 表示将处理不包含事件数据的Dism控件事件的方法
''' </summary>
''' <param name="sender">Dism面板控件</param>
''' <param name="e">Dism面板控件事件数据对象</param>
''' <remarks></remarks>
Public Delegate Sub DismControlEventHandler(sender As IDismControl, e As DismControlEventArgs)


''' <summary>
''' 更新映像方式
''' </summary>
''' <remarks></remarks>
Public Enum DismCommitFlags As Integer
    None = 0
    Commit = 1
    Append = 2
    Discard = 4
    Cancel = 8
End Enum