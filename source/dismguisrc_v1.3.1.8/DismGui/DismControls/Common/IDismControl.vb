''' <summary>
''' Dism面板控件必须实现的接口
''' </summary>
''' <remarks></remarks>
Public Interface IDismControl

    ''' <summary>
    ''' 通报处理进度事件
    ''' </summary>
    ''' <remarks></remarks>
    Event UpdateProgress As UpdateProgressEventHandler

    ''' <summary>
    ''' 执行指令事件
    ''' </summary>
    ''' <remarks></remarks>
    Event Execute As DismControlEventHandler

    ''' <summary>
    ''' 更新信息
    ''' </summary>
    ''' <param name="Flags">信息标识</param>
    ''' <remarks></remarks>
    Sub UpdateInfo(Flags As WimInfoDetail)

    ''' <summary>
    ''' 更新控件是否可用
    ''' </summary>
    ''' <param name="IsEnabled"></param>
    ''' <remarks></remarks>
    Sub UpdateControlState(IsEnabled As Boolean)

    ''' <summary>
    ''' 加载设置
    ''' </summary>
    ''' <remarks></remarks>
    Sub LoadConfig()

    ''' <summary>
    ''' 获取或者设置控件名称
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Name As String

    ''' <summary>
    ''' 获取或者设置控件停靠的位置和方式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Dock As System.Windows.Forms.DockStyle

    ''' <summary>
    ''' 获取或者设置提示对话框的标题
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Title As String

End Interface
