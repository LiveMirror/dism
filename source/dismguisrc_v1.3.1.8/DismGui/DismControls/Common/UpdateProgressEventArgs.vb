''' <summary>
''' 表示通报处理进度事件数据
''' </summary>
''' <remarks></remarks>
Public Class UpdateProgressEventArgs
    Inherits EventArgs

    ''' <summary>
    ''' 获取或者设置已完成数量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Current As Long = 0

    ''' <summary>
    ''' 获取或者设置总数量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Total As Long = 0

    ''' <summary>
    ''' 获取或者设置一个标识，指示Dism面板控件是否处于繁忙状态
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsCompleted As Boolean = False

    Public Property IsLoop As Boolean = True

    ''' <summary>
    ''' 创建通报处理进度事件数据对象
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

    End Sub

    ''' <summary>
    ''' 创建通报处理进度事件数据对象
    ''' </summary>
    ''' <param name="IsCompleted">事件是否完成</param>
    ''' <remarks></remarks>
    Public Sub New(IsCompleted As Boolean)
        Me.IsCompleted = IsCompleted
    End Sub

    ''' <summary>
    ''' 创建通报处理进度事件数据对象
    ''' </summary>
    ''' <param name="Current">已完成数量</param>
    ''' <remarks></remarks>
    Public Sub New(Current As Long)
        Me.Current = Current
    End Sub

    ''' <summary>
    ''' 创建通报处理进度事件数据对象
    ''' </summary>
    ''' <param name="Current">已完成数量</param>
    ''' <param name="Total">总数量</param>
    ''' <remarks></remarks>
    Public Sub New(Current As Long, Total As Long)
        Me.Current = Current : Me.Total = Total
    End Sub


End Class

''' <summary>
''' 定义通报处理进度事件的句柄
''' </summary>
''' <param name="sender">Dism面板控件</param>
''' <param name="e">通报处理进度事件数据</param>
''' <remarks></remarks>
Public Delegate Sub UpdateProgressEventHandler(sender As IDismControl, e As UpdateProgressEventArgs)