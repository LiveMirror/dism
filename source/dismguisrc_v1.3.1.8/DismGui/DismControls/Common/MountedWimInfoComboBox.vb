Imports System
Imports System.IO
Imports System.Threading
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
''' <summary>
''' 已安装映像列表控件
''' </summary>
''' <remarks></remarks>
Public Class MountedWimInfoComboBox

    ''' <summary>
    ''' 定义查询子项信息列表的事件句柄
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Delegate Sub QuerySelectedItemDetailHandler(e As MountedWimInfoComboBoxEventArgs)
    Private Delegate Function GetMCBTextHandler() As String


    ''' <summary>
    ''' 选择项已改变事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event SelectedItemChanged(sender As Object, e As MountedWimInfoComboBoxEventArgs)

    Private mItemHeightOffset As Integer = 6    '项高度偏移
    Private mReadOnly As Boolean = False        '是否是只读
    Private mWithOnlineImage As Boolean = True  '是否添加在线映像信息

    Public Event UpdateSelectedItemDetailProgress(sender As Object, e As UpdateProgressEventArgs)


#Region "属性"

    ''' <summary>
    ''' 获取或者设置选择项的索引
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(False)> _
    Public Property SelectedIndex As Integer
        Get
            Return MCB.SelectedIndex
        End Get
        Set(value As Integer)
            MCB.SelectedIndex = value
        End Set
    End Property

    ''' <summary>
    ''' 获取或者设置子项映像信息标识
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ListSelectedItemDetail As WimInfoDetail = WimInfoDetail.None

    ''' <summary>
    ''' 获取或者设置一个标识，指示在刷新挂载目录的时候是否添加本机映像。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WithOnlineImage As Boolean
        Get
            Return mWithOnlineImage
        End Get
        Set(value As Boolean)
            mWithOnlineImage = value
        End Set
    End Property

    ''' <summary>
    ''' 获取或者设置控件是否是只读模式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property [ReadOnly] As Boolean
        Get
            Return mReadOnly
        End Get
        Set(value As Boolean)
            mReadOnly = value
            UpdateMCBState(value)
        End Set
    End Property

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
    ''' 获取或者设置下拉列表最大项数
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
    ''' 获取或者设置项高度偏移
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
            MountedWimInfoComboBox_Resize(Me, Nothing)
        End Set
    End Property

    ''' <summary>
    ''' 获取或者设置选中项
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

#End Region

#Region "更新挂载目录"

    ''' <summary>
    ''' 更新已安装映像列表
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateMountedWimInfo()
        ThreadPool.QueueUserWorkItem(AddressOf QueryMountedWimInfoProc)
    End Sub

    ''' <summary>
    ''' 更新已安装映像列表
    ''' </summary>
    ''' <param name="WithOnlineImage">是否包含在线映像</param>
    ''' <remarks></remarks>
    Public Sub UpdateMountedWimInfo(WithOnlineImage As Boolean)
        mWithOnlineImage = WithOnlineImage
        UpdateMountedWimInfo()
    End Sub

    ''' <summary>
    ''' 更新已安装映像列表
    ''' </summary>
    ''' <param name="IsReadOnly">是否只读</param>
    ''' <param name="WithOnlineImage">是否包含在线映像</param>
    ''' <remarks></remarks>
    Public Sub UpdateMountedWimInfo(ByVal IsReadOnly As Boolean, WithOnlineImage As Boolean)
        mReadOnly = IsReadOnly
        UpdateMCBState(mReadOnly)
        UpdateMountedWimInfo(WithOnlineImage)
    End Sub

    ''' <summary>
    ''' 查询已安装映像信息
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub QueryMountedWimInfoProc()
        UpdateControlState(False)
        Dim dt As DataTable = DismShell.BuildMountedWimInfoTable
        Try
            DismShell.GetMountedWimInfo(dt)
            If mWithOnlineImage Then
                Dim dr As DataRow = dt.NewRow
                dr = dt.NewRow()
                dr!MountDir = "/Online"
                dr!ImageFile = "本机映像"
                dr!ImageIndex = 0
                dr!MountedForRW = True
                dr!Status = "确定"
                dt.Rows.InsertAt(dr, 0)
            End If
        Catch ex As Exception

        End Try
        Invoke(New ShowWimInfoHandler(AddressOf ShowMountedWimInfoProc), dt)
        UpdateControlState(True)
    End Sub

    ''' <summary>
    ''' 现在已安装映像信息
    ''' </summary>
    ''' <param name="dt">查询到的数据</param>
    ''' <remarks></remarks>
    Private Sub ShowMountedWimInfoProc(dt As DataTable)
        MCB.DataSource = dt
    End Sub

#End Region

#Region "更新按钮状态"

    ''' <summary>
    ''' 更新控件可用状态
    ''' </summary>
    ''' <param name="IsEnabled"></param>
    ''' <remarks></remarks>
    Public Sub UpdateControlState(ByVal IsEnabled As Boolean)
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
    Private Sub _UpdateControlState(ByVal IsEnabled As Boolean)
        Me.Enabled = IsEnabled
    End Sub

#End Region

#Region "更新子项映像信息"

    ''' <summary>
    ''' 更新子项映像信息
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateSelectedItemDetail()
        MCB_SelectedIndexChanged(MCB, Nothing)
    End Sub

#End Region

#Region "控件内事件"

    ''' <summary>
    ''' 控件初始化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MountedWimInfoComboBox_Load(sender As Object, e As EventArgs) Handles Me.Load
        MCB.DrawItemHandler = AddressOf DrawItemProc
    End Sub

    ''' <summary>
    ''' 控件大小调整
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MountedWimInfoComboBox_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        MCB.DropDownWidth = If(Me.Width > 0, Me.Width, 1)
        MCB.ItemHeight = Me.Height - 6
        BtnRefresh.Width = Me.Height
    End Sub

    ''' <summary>
    ''' 刷新已安装映像列表
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        UpdateMountedWimInfo()
    End Sub

    ''' <summary>
    ''' 浏览指定的离线映像
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnBrowser_Click(sender As Object, e As EventArgs) Handles BtnBrowser.Click
        Dim cd As New FolderBrowserDialog()
        If Directory.Exists(MCB.Text) Then cd.SelectedPath = MCB.Text
        If cd.ShowDialog = DialogResult.OK Then
            MCB.Text = cd.SelectedPath
            UpdateSelectedItemDetail()
        End If
        cd.Dispose()
        cd = Nothing
    End Sub

    ''' <summary>
    ''' 已选映像项改变事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MCB.SelectedIndexChanged
        Dim Image As String = ""
        If InvokeRequired Then
            Image = Invoke(New GetMCBTextHandler(AddressOf GetMCBText))
        Else
            Image = GetMCBText()
        End If
        If Image = "" Or Me.ListSelectedItemDetail = WimInfoDetail.None Then Return
        ThreadPool.QueueUserWorkItem(AddressOf QuerySelectedItemDetailProc, Image)

    End Sub

    Private Function GetMCBText() As String
        Return MCB.Text.Trim
    End Function

    ''' <summary>
    ''' 查询子项信息处理过程
    ''' </summary>
    ''' <param name="Image"></param>
    ''' <remarks></remarks>
    Private Sub QuerySelectedItemDetailProc(Image As String)
        RaiseEvent UpdateSelectedItemDetailProgress(Me, New UpdateProgressEventArgs(0, 100))
        UpdateControlState(False)
        Dim dt As DataTable = Nothing
        Dim e As New MountedWimInfoComboBoxEventArgs() With {.ListSelectedItemDetail = Me.ListSelectedItemDetail, .SelectedItem = Image}
        Select Case Me.ListSelectedItemDetail
            Case WimInfoDetail.Feature
                dt = DismShell.BuildFeaturesTable
                Try
                    DismShell.GetFeatures(dt, Image)
                Catch ex As Exception

                End Try
                e.Data = dt
            Case WimInfoDetail.Package
                dt = DismShell.BuildPackagesTable
                Try
                    DismShell.GetPackages(dt, Image)
                Catch ex As Exception

                End Try
                e.Data = dt
            Case WimInfoDetail.Driver
                dt = DismShell.BuildDriversTable
                Try
                    DismShell.GetDrivers(dt, Image)
                Catch ex As Exception

                End Try
                e.Data = dt
            Case WimInfoDetail.Edition
                dt = DismShell.BuildTargetEditionsTable
                Dim Edition As String = ""
                Try
                    DismShell.GetCurrentEdition(Edition, Image)
                Catch ex As Exception

                End Try
                Try
                    DismShell.GetTargetEditions(dt, Image)
                Catch ex As Exception

                End Try
                e.Data = dt
                e.Tag = Edition
            Case WimInfoDetail.Application
                dt = DismShell.BuildAppsTable
                Try
                    DismShell.GetApplications(dt, Image)
                Catch ex As Exception

                End Try
                e.Data = dt
            Case WimInfoDetail.MetroApps
                dt = DismShell.BuildMetroAppsInfoTable
                Try
                    DismShell.GetMetroAppsInfo(dt, Image)
                Catch ex As Exception

                End Try
                e.Data = dt
        End Select
        OnSelectedItemChanged(e)
        UpdateControlState(True)
        RaiseEvent UpdateSelectedItemDetailProgress(Me, New UpdateProgressEventArgs(True))
    End Sub

    ''' <summary>
    ''' 在通报已安装映像选择项改变之前，进行线程间通讯安全处理
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnSelectedItemChanged(e As MountedWimInfoComboBoxEventArgs)
        If InvokeRequired Then
            Invoke(New QuerySelectedItemDetailHandler(AddressOf _OnSelectedItemChanged), e)
        Else
            _OnSelectedItemChanged(e)
        End If
    End Sub

    ''' <summary>
    ''' 通报已安装选择项已改变
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub _OnSelectedItemChanged(e As MountedWimInfoComboBoxEventArgs)
        RaiseEvent SelectedItemChanged(Me, e)
    End Sub

    ''' <summary>
    ''' 更新已安装映像列表状态
    ''' </summary>
    ''' <param name="IsReadOnly">是否为只读</param>
    ''' <remarks></remarks>
    Private Sub UpdateMCBState(IsReadOnly As Boolean)
        If IsReadOnly And MCB.DropDownStyle <> ComboBoxStyle.DropDownList Then MCB.DropDownStyle = ComboBoxStyle.DropDownList
        If (Not IsReadOnly) And MCB.DropDownStyle <> ComboBoxStyle.DropDown Then MCB.DropDownStyle = ComboBoxStyle.DropDown
    End Sub

    ''' <summary>
    ''' 绘制控件下拉菜单
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DrawItemProc(sender As Object, e As DrawItemEventArgs)

        e.DrawBackground()
        e.DrawFocusRectangle()
        If e.Index < 0 Then Return
        Dim Ctrl As MyComboBox = TryCast(sender, MyComboBox)
        Dim dt As DataTable = TryCast(Ctrl.DataSource, DataTable)
        If dt Is Nothing Then Return
        Dim dr As DataRow = Nothing
        Dim Rect As Rectangle = e.Bounds
        Rect.Offset(3, 3)
        Rect.Width -= 6
        Rect.Height -= 6

        If e.State And DrawItemState.ComboBoxEdit Then
            DrawMethod.DrawText(e.Graphics, Ctrl.Text, Ctrl.Font, Ctrl.ForeColor, Rect, ContentAlignment.MiddleLeft)
            Return
        End If

        Dim Path As GraphicsPath = DrawMethod.GetRoundPath(Rect, 3)
        e.Graphics.DrawPath(Pens.RoyalBlue, Path)
        Rect.Offset(3, 3)
        Rect.Width -= 6
        Rect.Height -= 6
        Dim hLine As Integer = Rect.Height / 5
        Try
            dr = dt(e.Index)
            Dim HeaderLen As Integer = Math.Floor(e.Graphics.MeasureString("挂载目录：", Ctrl.Font).Width) + 1
            Dim HeaderRect As New Rectangle(Rect.Location, New Size(Rect.Width, hLine))
            Dim TextRect As New Rectangle(HeaderRect.Location.X + HeaderLen, HeaderRect.Location.Y, HeaderRect.Width - HeaderLen, HeaderRect.Height)
            DrawMethod.DrawText(e.Graphics, "安装目录：", Ctrl.Font, Ctrl.ForeColor, HeaderRect, ContentAlignment.MiddleLeft)
            DrawMethod.DrawText(e.Graphics, dr!MountDir, Ctrl.Font, Ctrl.ForeColor, TextRect, ContentAlignment.MiddleLeft)

            HeaderRect.Offset(0, hLine)
            TextRect.Offset(0, hLine)
            DrawMethod.DrawText(e.Graphics, "映像文件：", Ctrl.Font, Ctrl.ForeColor, HeaderRect, ContentAlignment.MiddleLeft)
            DrawMethod.DrawText(e.Graphics, dr!ImageFile, Ctrl.Font, Ctrl.ForeColor, TextRect, ContentAlignment.MiddleLeft)

            HeaderRect.Offset(0, hLine)
            TextRect.Offset(0, hLine)
            DrawMethod.DrawText(e.Graphics, "映像索引：", Ctrl.Font, Ctrl.ForeColor, HeaderRect, ContentAlignment.MiddleLeft)
            DrawMethod.DrawText(e.Graphics, dr!ImageIndex.ToString(), Ctrl.Font, Ctrl.ForeColor, TextRect, ContentAlignment.MiddleLeft)

            HeaderRect.Offset(0, hLine)
            TextRect.Offset(0, hLine)
            DrawMethod.DrawText(e.Graphics, "是否可写：", Ctrl.Font, Ctrl.ForeColor, HeaderRect, ContentAlignment.MiddleLeft)
            DrawMethod.DrawText(e.Graphics, IIf(dr!MountedForRW, "是", "否"), Ctrl.Font, Ctrl.ForeColor, TextRect, ContentAlignment.MiddleLeft)

            HeaderRect.Offset(0, hLine)
            TextRect.Offset(0, hLine)
            DrawMethod.DrawText(e.Graphics, "安装状态：", Ctrl.Font, Ctrl.ForeColor, HeaderRect, ContentAlignment.MiddleLeft)
            DrawMethod.DrawText(e.Graphics, dr!Status, Ctrl.Font, Ctrl.ForeColor, TextRect, ContentAlignment.MiddleLeft)
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        Path.Dispose()
    End Sub

#End Region

End Class
