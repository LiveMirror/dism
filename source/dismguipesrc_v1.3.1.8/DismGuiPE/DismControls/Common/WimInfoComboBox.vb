Imports System
Imports System.Threading
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
''' <summary>
''' .WIM 文件信息控件
''' </summary>
''' <remarks></remarks>
Public Class WimInfoComboBox

    ''' <summary>
    ''' 映像索引改变事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event SelectedIndexChanged(sender As Object, e As WimInfoComboBoxEventArgs)

    Private mItemHeightOffset As Integer = 6
    Private mWimFile As String = ""

#Region "属性"

    ''' <summary>
    ''' 获取或者设置控件提示标题
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ToolTipTitle As String
        Get
            Return TT.ToolTipTitle
        End Get
        Set(value As String)
            TT.ToolTipTitle = value
        End Set
    End Property

    ''' <summary>
    ''' 获取或者设置映像名称控件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageNameControl As TextBox = Nothing

    ''' <summary>
    ''' 获取或者设置映像描述控件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageDescriptionControl As TextBox = Nothing

    ''' <summary>
    ''' 获取或者设置下拉菜单显示最大项数
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MaxDropDownItems As Integer
        Get
            Return MCB.MaxDropDownItems
        End Get
        Set(value As Integer)
            MCB.MaxDropDownItems = value
        End Set
    End Property

    ''' <summary>
    ''' 获取或者设置项高偏移
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ItemHeightOffset As Integer
        Get
            Return mItemHeightOffset
        End Get
        Set(value As Integer)
            mItemHeightOffset = value
            WimInfoComboBox_Resize(Me, Nothing)
        End Set
    End Property

    ''' <summary>
    ''' 获取或者设置 .WIM 文件路径
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WimFile As String
        Get
            Return mWimFile
        End Get
        Set(value As String)
            mWimFile = value
            UpdateWimInfo()
        End Set
    End Property

    ''' <summary>
    ''' 获取或者设置映像索引
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(True)> _
    Public Shadows Property Text As String
        Get
            Return MCB.Text
        End Get
        Set(value As String)
            MCB.Text = value
        End Set
    End Property

    ''' <summary>
    ''' 获取或者设置下拉菜单的宽度（以像素为单位）
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DropDownWidth As Integer
        Get
            Return MCB.DropDownWidth
        End Get
        Set(value As Integer)
            MCB.DropDownWidth = value
        End Set
    End Property
    <Browsable(False)> _
    Public ReadOnly Property DataSource As DataTable
        Get
            Return MCB.DataSource
        End Get
    End Property

    Public ReadOnly Property Count As Integer
        Get
            Return MCB.Items.Count
        End Get
    End Property
#End Region

#Region "更新控件状态"
    ''' <summary>
    ''' 重载 Equals 函数
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Equals(Value As WimInfoComboBox) As Boolean
        If IsNothing(Value) Then Return False
        Return MyBase.Equals(Value)
    End Function
    ''' <summary>
    ''' 更新控件可用状态
    ''' </summary>
    ''' <param name="IsEnabled"></param>
    ''' <remarks></remarks>
    Public Sub UpdateControlState(IsEnabled As Boolean)
        If InvokeRequired Then
            Invoke(New UpdateControlStateHandler(AddressOf _UpdateControlState), IsEnabled)
        Else
            _UpdateControlState(IsEnabled)
        End If
    End Sub
    ''' <summary>
    ''' 更新控件可用状态
    ''' </summary>
    ''' <param name="IsEnabled"></param>
    ''' <remarks></remarks>
    Private Sub _UpdateControlState(IsEnabled As Boolean)
        Me.Enabled = IsEnabled
    End Sub

#End Region

#Region "更新列表"

    ''' <summary>
    ''' 更新映像文件信息
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateWimInfo()
        If Not IO.File.Exists(mWimFile) Then
            MCB.DataSource = Nothing
            Return
        End If
        ThreadPool.QueueUserWorkItem(AddressOf UpdateWimInfoProc)
    End Sub

    ''' <summary>
    ''' 更新映像文件信息
    ''' </summary>
    ''' <param name="WimFile">.WIM 文件路径</param>
    ''' <remarks></remarks>
    Public Sub UpdateWimInfo(WimFile As String)
        Me.WimFile = WimFile
        UpdateWimInfo()
    End Sub

    ''' <summary>
    ''' 更新映像文件信息处理过程
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateWimInfoProc()
        If Not IO.File.Exists(mWimFile) Then Return
        UpdateControlState(False)
        Dim dt As DataTable = DismShell.BuildWimInfoTable
        Try
            DismShell.GetWimInfo(mWimFile, dt)
        Catch ex As Exception

        End Try
        Invoke(New ShowWimInfoHandler(AddressOf ShowWimInfoProc), dt)
        UpdateControlState(True)
    End Sub

    ''' <summary>
    ''' 显示映像文件信息
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Sub ShowWimInfoProc(dt As DataTable)
        MCB.DataSource = dt
    End Sub

#End Region

#Region "控件内事件"

    ''' <summary>
    ''' 初始化控件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub WimInfoComboBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IsNothing(Parent) Then
            Dim w As Integer = Parent.Width - Me.Left - 6
            If w < 1 Then w = 1
            MCB.DropDownWidth = w
            AddHandler Parent.Resize, AddressOf Parent_Resize
        End If
    End Sub


    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        MCB.DrawItemHandler = AddressOf DrawItemProc

    End Sub


    ''' <summary>
    ''' 调整控件大小
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub WimInfoComboBox_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        BtnRefresh.Width = Me.Height
        MCB.ItemHeight = Me.Height - mItemHeightOffset
    End Sub

    ''' <summary>
    ''' 父容器大小调整事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Parent_Resize(sender As Object, e As EventArgs)
        Dim Temp As Control = TryCast(sender, Control)
        If Not IsNothing(Temp) Then
            Dim w As Integer = Parent.Width - Me.Left - 6
            If w < 1 Then w = 1
            MCB.DropDownWidth = w
        End If
    End Sub

    ''' <summary>
    ''' 映像索引变更事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MCB.SelectedIndexChanged
        If InvokeRequired Then
            Invoke(New EventHandler(AddressOf _SelectedIndexChangedProc), MCB, e)
        Else
            _SelectedIndexChangedProc(MCB, e)
        End If
    End Sub

    ''' <summary>
    ''' 映像索引变更事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub _SelectedIndexChangedProc(sender As Object, e As EventArgs)
        Dim Arg As New WimInfoComboBoxEventArgs() With {.Index = MCB.SelectedIndex}
        If MCB.SelectedIndex = -1 Then
            Arg.Name = ""
            Arg.Description = ""
        Else
            Dim dt As DataTable = TryCast(MCB.DataSource, DataTable)
            If dt IsNot Nothing Then
                Arg.Index = dt(MCB.SelectedIndex)!Index
                Arg.Name = dt(MCB.SelectedIndex)!Name
                Arg.Description = dt(MCB.SelectedIndex)!Description
            End If
        End If
        If Me.ImageNameControl IsNot Nothing Then Me.ImageNameControl.Text = Arg.Name
        If Me.ImageDescriptionControl IsNot Nothing Then Me.ImageDescriptionControl.Text = Arg.Description

        RaiseEvent SelectedIndexChanged(Me, Arg)
    End Sub

    ''' <summary>
    ''' 刷新映像文件信息
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        UpdateWimInfo()
    End Sub

    ''' <summary>
    ''' 绘制映像文件信息项
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DrawItemProc(sender As Object, e As DrawItemEventArgs)

        e.DrawBackground()
        e.DrawFocusRectangle()

        If e.Index < 0 Then Return

        Dim Ctrl As MyComboBox = TryCast(sender, MyComboBox)
        If Ctrl.DataSource Is Nothing Then Return

        Dim Rect As Rectangle = e.Bounds
        Rect.Offset(3, 3)
        Rect.Width -= 6
        Rect.Height -= 6

        If Ctrl.DropDownStyle = ComboBoxStyle.DropDownList AndAlso (e.State And DrawItemState.ComboBoxEdit) Then
            DrawMethod.DrawText(e.Graphics, Ctrl.Text, Ctrl.Font, Ctrl.ForeColor, Rect, ContentAlignment.MiddleLeft)
            Return
        End If

        Dim Path As GraphicsPath = DrawMethod.GetRoundPath(Rect, 3)
        e.Graphics.DrawPath(Pens.RoyalBlue, Path)
        Rect.Offset(3, 3)
        Rect.Width -= 6
        Rect.Height -= 6
        Dim hLine As Integer = Rect.Height / 4

        Try

            Dim dt As DataTable = TryCast(Ctrl.DataSource, DataTable)
            If dt IsNot Nothing Then
                Dim dr As DataRow = dt(e.Index)
                Dim HeaderLen As Integer = Math.Floor(e.Graphics.MeasureString("映像索引：", Ctrl.Font).Width) + 1
                Dim HeaderRect As New Rectangle(Rect.Location, New Size(Rect.Width, hLine))
                Dim TextRect As New Rectangle(HeaderRect.Location.X + HeaderLen, HeaderRect.Location.Y, HeaderRect.Width - HeaderLen, HeaderRect.Height)
                DrawMethod.DrawText(e.Graphics, "映像索引：", Ctrl.Font, Ctrl.ForeColor, HeaderRect, ContentAlignment.MiddleLeft, StringFormatFlags.NoWrap)
                DrawMethod.DrawText(e.Graphics, dr!Index.ToString, Ctrl.Font, Ctrl.ForeColor, TextRect, ContentAlignment.MiddleLeft)

                HeaderRect.Offset(0, hLine)
                TextRect.Offset(0, hLine)
                DrawMethod.DrawText(e.Graphics, "映像名称：", Ctrl.Font, Ctrl.ForeColor, HeaderRect, ContentAlignment.MiddleLeft, StringFormatFlags.NoWrap)
                DrawMethod.DrawText(e.Graphics, dr!Name, Ctrl.Font, Ctrl.ForeColor, TextRect, ContentAlignment.MiddleLeft, StringFormatFlags.NoWrap)

                HeaderRect.Offset(0, hLine)
                TextRect.Offset(0, hLine)
                DrawMethod.DrawText(e.Graphics, "映像大小：", Ctrl.Font, Ctrl.ForeColor, HeaderRect, ContentAlignment.MiddleLeft, StringFormatFlags.NoWrap)
                DrawMethod.DrawText(e.Graphics, dr!Size & " Bytes (" & GetSizeDescritpion(dr!Size) & ")", Ctrl.Font, Ctrl.ForeColor, TextRect, ContentAlignment.MiddleLeft, StringFormatFlags.NoWrap)

                HeaderRect.Offset(0, hLine)
                TextRect.Offset(0, hLine)
                DrawMethod.DrawText(e.Graphics, "映像描述：", Ctrl.Font, Ctrl.ForeColor, HeaderRect, ContentAlignment.MiddleLeft, StringFormatFlags.NoWrap)
                DrawMethod.DrawText(e.Graphics, dr!Description, Ctrl.Font, Ctrl.ForeColor, TextRect, ContentAlignment.MiddleLeft, StringFormatFlags.NoWrap)

            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 获取映像大小描述
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

End Class

''' <summary>
''' 表示映像文件信息事件数据
''' </summary>
''' <remarks></remarks>
Public Class WimInfoComboBoxEventArgs
    Inherits EventArgs

    ''' <summary>
    ''' 获取或者设置映像索引
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Index As Integer = -1

    ''' <summary>
    ''' 获取或者设置映像名称
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Name As String = ""

    ''' <summary>
    ''' 获取或者设置映像描述
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Description As String = ""

    ''' <summary>
    ''' 创建映像文件信息事件数据对象
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

    End Sub

    ''' <summary>
    ''' 创建映像文件信息事件数据对象
    ''' </summary>
    ''' <param name="Name">映像名称</param>
    ''' <remarks></remarks>
    Public Sub New(Name As String)
        Me.Name = Name
    End Sub

    ''' <summary>
    ''' 创建映像文件信息事件数据对象
    ''' </summary>
    ''' <param name="Name">映像名称</param>
    ''' <param name="Description">映像描述</param>
    ''' <remarks></remarks>
    Public Sub New(Name As String, Description As String)
        Me.Name = Name : Me.Description = Description
    End Sub

    ''' <summary>
    ''' 创建映像文件信息事件数据对象
    ''' </summary>
    ''' <param name="Name">映像名称</param>
    ''' <param name="Description">映像描述</param>
    ''' <param name="Index">映像索引</param>
    ''' <remarks></remarks>
    Public Sub New(Name As String, Description As String, Index As Integer)
        Me.Name = Name : Me.Description = Description : Me.Index = Index
    End Sub

End Class