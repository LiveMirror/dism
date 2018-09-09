''' <summary>
''' Dism面板控件基础类。请务必在继承类中重写OnLoadConfig和OnUpdateInfo事件！
''' </summary>
''' <remarks></remarks>
Public Class DismPanelBase
    Inherits UserControl
    Implements IDismControl


    ''' <summary>
    ''' 通报更新进度
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event UpdateProgress(sender As IDismControl, e As UpdateProgressEventArgs) Implements IDismControl.UpdateProgress

    ''' <summary>
    ''' 执行指令事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event Execute(sender As IDismControl, e As DismControlEventArgs) Implements IDismControl.Execute

    ''' <summary>
    ''' 更新控件状态
    ''' </summary>
    ''' <param name="IsEnabled"></param>
    ''' <remarks></remarks>
    Public Sub UpdateControlState(IsEnabled As Boolean) Implements IDismControl.UpdateControlState
        If InvokeRequired Then
            Invoke(New UpdateControlStateHandler(AddressOf _UpdateControlState), IsEnabled)
        Else
            _UpdateControlState(IsEnabled)
        End If
    End Sub

    ''' <summary>
    ''' 更新信息
    ''' </summary>
    ''' <param name="Flags"></param>
    ''' <remarks></remarks>
    Public Sub UpdateInfo(Flags As WimInfoDetail) Implements IDismControl.UpdateInfo
        OnUpdateInfo(Flags)
    End Sub

    ''' <summary>
    ''' 更新控件状态
    ''' </summary>
    ''' <param name="IsEnabled"></param>
    ''' <remarks></remarks>
    Private Sub _UpdateControlState(IsEnabled As Boolean)
        Me.Enabled = IsEnabled
    End Sub

    ''' <summary>
    ''' 加载配置
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadConfig() Implements IDismControl.LoadConfig
        OnLoadConfig()
    End Sub

    ''' <summary>
    ''' 加载配置
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub OnLoadConfig()

    End Sub

    ''' <summary>
    ''' 更新信息
    ''' </summary>
    ''' <param name="Flags">信息标识</param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnUpdateInfo(Flags As WimInfoDetail)

    End Sub

    ''' <summary>
    ''' 执行指令
    ''' </summary>
    ''' <param name="e">Dism控件事件数据</param>
    ''' <remarks></remarks>
    Protected Sub OnExecute(e As DismControlEventArgs)
        RaiseEvent Execute(Me, e)
    End Sub

    ''' <summary>
    ''' 执行指令
    ''' </summary>
    ''' <param name="sender">触发事件的面板控件</param>
    ''' <param name="e">Dism控件事件数据</param>
    ''' <remarks></remarks>
    Protected Sub OnExecute(sender As IDismControl, e As DismControlEventArgs)
        RaiseEvent Execute(sender, e)
    End Sub

    ''' <summary>
    ''' 通报处理进度
    ''' </summary>
    ''' <param name="Current">已完成数量</param>
    ''' <param name="Total">总数</param>
    ''' <remarks></remarks>
    Protected Sub OnUpdateProgress(Current As Long, Total As Long)
        RaiseEvent UpdateProgress(Me, New UpdateProgressEventArgs(Current, Total))
    End Sub

    ''' <summary>
    ''' 通报处理进度
    ''' </summary>
    ''' <param name="IsCompleted">控件处理时间是否处完成</param>
    ''' <remarks></remarks>
    Protected Sub OnUpdateProgress(IsCompleted As Boolean)
        RaiseEvent UpdateProgress(Me, New UpdateProgressEventArgs(IsCompleted))
    End Sub

    ''' <summary>
    ''' 通报处理进度
    ''' </summary>
    ''' <param name="e">通报处理进度事件数据对象</param>
    ''' <remarks></remarks>
    Protected Sub OnUpdateProgress(e As UpdateProgressEventArgs)
        RaiseEvent UpdateProgress(Me, e)
    End Sub

    ''' <summary>
    ''' 获取或者设置控件的名称
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows Property Name As String Implements IDismControl.Name
        Get
            Return MyBase.Name
        End Get
        Set(value As String)
            MyBase.Name = value
        End Set
    End Property

    ''' <summary>
    ''' 获取或者设置控件停靠的位置和方式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows Property Dock As DockStyle Implements IDismControl.Dock
        Get
            Return MyBase.Dock
        End Get
        Set(value As DockStyle)
            MyBase.Dock = value
        End Set
    End Property

    ''' <summary>
    ''' 获取或者设置提示对话框的标题
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Title As String = "" Implements IDismControl.Title


End Class
