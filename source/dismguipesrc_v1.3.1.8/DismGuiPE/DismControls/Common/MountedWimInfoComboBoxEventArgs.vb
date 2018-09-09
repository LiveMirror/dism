''' <summary>
''' 表示已安装映像列表控件的事件数据对象
''' </summary>
''' <remarks></remarks>
Public Class MountedWimInfoComboBoxEventArgs
    Inherits System.EventArgs

    ''' <summary>
    ''' 创建已安装映像列表控件的事件数据对象
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

    End Sub

    ''' <summary>
    ''' 创建已安装映像列表控件的事件数据对象
    ''' </summary>
    ''' <param name="Data">子项列表数据</param>
    ''' <remarks></remarks>
    Public Sub New(Data As DataTable)
        Me.Data = Data
    End Sub

    ''' <summary>
    ''' 创建已安装映像列表控件的事件数据对象
    ''' </summary>
    ''' <param name="SelectedItem">选择项</param>
    ''' <remarks></remarks>
    Public Sub New(SelectedItem As String)
        Me.SelectedItem = SelectedItem
    End Sub

    ''' <summary>
    ''' 创建已安装映像列表控件的事件数据对象
    ''' </summary>
    ''' <param name="SelectedItem">选择项</param>
    ''' <param name="Data">子项列表数据</param>
    ''' <remarks></remarks>
    Public Sub New(SelectedItem As String, Data As DataTable)
        Me.SelectedItem = SelectedItem : Me.Data = Data
    End Sub

    ''' <summary>
    ''' 创建已安装映像列表控件的事件数据对象
    ''' </summary>
    ''' <param name="SelectedItem">选择项</param>
    ''' <param name="Data">子项列表数据</param>
    ''' <remarks></remarks>
    Public Sub New(SelectedItem As String, Data As DataTable, ListSelectedItemDetail As WimInfoDetail)
        Me.SelectedItem = SelectedItem : Me.Data = Data : Me.ListSelectedItemDetail = ListSelectedItemDetail
    End Sub

    ''' <summary>
    ''' 创建已安装映像列表控件的事件数据对象
    ''' </summary>
    ''' <param name="SelectedItem">选择项</param>
    ''' <param name="Data">子项列表数据</param>
    ''' <param name="Tag">附加数据</param>
    ''' <remarks></remarks>
    Public Sub New(SelectedItem As String, Data As DataTable, Tag As Object)
        Me.SelectedItem = SelectedItem : Me.Data = Data : Me.Tag = Tag
    End Sub

    ''' <summary>
    ''' 获取或者设置子列表数据
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Data As DataTable = Nothing

    ''' <summary>
    ''' 获取或者设置附加数据
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Tag As Object = Nothing

    ''' <summary>
    ''' 获取或者设置选择项
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SelectedItem As String = ""

    ''' <summary>
    ''' 获取或者设置子项映像信息标识
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ListSelectedItemDetail As WimInfoDetail = WimInfoDetail.None

End Class



''' <summary>
''' 映像信息标识
''' </summary>
''' <remarks></remarks>
Public Enum WimInfoDetail As Integer
    ''' <summary>
    ''' 无
    ''' </summary>
    ''' <remarks></remarks>
    None = 0
    ''' <summary>
    ''' .WIM 文件信息
    ''' </summary>
    ''' <remarks></remarks>
    WimInfo = 1
    ''' <summary>
    ''' 已安装映像信息
    ''' </summary>
    ''' <remarks></remarks>
    MountedWimInfo = 2
    ''' <summary>
    ''' 功能
    ''' </summary>
    ''' <remarks></remarks>
    Feature = 4
    ''' <summary>
    ''' 程序包
    ''' </summary>
    ''' <remarks></remarks>
    Package = 8
    ''' <summary>
    ''' 驱动
    ''' </summary>
    ''' <remarks></remarks>
    Driver = 16
    ''' <summary>
    ''' 版本
    ''' </summary>
    ''' <remarks></remarks>
    Edition = 32
    ''' <summary>
    ''' 应用
    ''' </summary>
    ''' <remarks></remarks>
    Application = 64
    ''' <summary>
    ''' Metro应用
    ''' </summary>
    ''' <remarks></remarks>
    MetroApps = 128
End Enum


Public Delegate Sub UpdateControlStateHandler(IsEnabled As Boolean)

Public Delegate Sub ShowWimInfoHandler(dt As DataTable)