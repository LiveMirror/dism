Imports System.ComponentModel
''' <summary>
''' 表示FileOrFolder浏览目标
''' </summary>
''' <remarks></remarks>
Public Enum FileOrFolderBrowserStyle As Integer
    ''' <summary>
    ''' 文件夹
    ''' </summary>
    ''' <remarks></remarks>
    Folder = 0
    ''' <summary>
    ''' 打开文件
    ''' </summary>
    ''' <remarks></remarks>
    FileOpen = 1
    ''' <summary>
    ''' 保存文件
    ''' </summary>
    ''' <remarks></remarks>
    FileSave = 2
    ''' <summary>
    ''' 打开文件或者文件夹
    ''' </summary>
    ''' <remarks></remarks>
    FileOrFolderOpen = 3
    ''' <summary>
    ''' 保存文件或者文件夹
    ''' </summary>
    ''' <remarks></remarks>
    FileOrFolderSave = 4
End Enum

''' <summary>
''' 文件或文件夹选择器
''' </summary>
''' <remarks></remarks>
Public Class FileOrFolderSelector

    ''' <summary>
    ''' 文件或文件夹已经选定事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event FileOrFolderSelected(sender As Object, e As EventArgs)

    ''' <summary>
    ''' 获取或者设置浏览目标
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BrowserStyle As FileOrFolderBrowserStyle = FileOrFolderBrowserStyle.Folder

    ''' <summary>
    ''' 获取或者设置控件字体
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows Property Font As Font
        Get
            Return TBPath.Font
        End Get
        Set(value As Font)
            TBPath.Font = value
        End Set
    End Property

    ''' <summary>
    ''' 获取或者设置文件或者文件夹路径
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(True)> _
    Public Shadows Property Text As String
        Get
            Return TBPath.Text
        End Get
        Set(value As String)
            TBPath.Text = value
        End Set
    End Property

    ''' <summary>
    ''' 获取或者设置一个标识，指示输入框是否为只读。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property [ReadOnly] As Boolean
        Get
            Return TBPath.ReadOnly
        End Get
        Set(value As Boolean)
            TBPath.ReadOnly = value
        End Set
    End Property

    ''' <summary>
    ''' 获取或设置当前文件名筛选器字符串，该字符串决定对话框的“另存为文件类型”或“文件类型”框中出现的选择内容。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Filter As String = ""

    ''' <summary>
    ''' 获取或设置一个值，该值指示如果用户指定不存在的文件名，对话框是否显示警告。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CheckFileExists As Boolean = True

    ''' <summary>
    ''' 获取或设置一个值，该值指示对话框是否允许选择多个文件。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Multiselect As Boolean = False

    ''' <summary>
    ''' 获取或设置一个值，该值指示如果用户指定不存在的路径，对话框是否显示警告。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CheckPathExists As Boolean = True

    ''' <summary>
    ''' 获取或设置一个值，该值指示如果用户指定的文件名已存在，Save As 对话框是否显示警告。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OverwritePrompt As Boolean = True

    ''' <summary>
    ''' 显示浏览对话框
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowDialog()
        Dim e As New EventArgs()
        If Me.BrowserStyle = FileOrFolderBrowserStyle.Folder Then
            ShowFolderSelect(e)
        ElseIf Me.BrowserStyle = FileOrFolderBrowserStyle.FileOpen Then
            ShowFileOpen(e)
        ElseIf Me.BrowserStyle = FileOrFolderBrowserStyle.FileSave Then
            ShowFileSave(e)
        End If
    End Sub

#Region "控件内事件"

    ''' <summary>
    ''' 浏览按钮点击事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnBrowser_Click(sender As Object, e As EventArgs) Handles BtnBrowser.Click
        If Me.BrowserStyle = FileOrFolderBrowserStyle.Folder Then
            ShowFolderSelect(e)
        ElseIf Me.BrowserStyle = FileOrFolderBrowserStyle.FileOpen Then
            ShowFileOpen(e)
        ElseIf Me.BrowserStyle = FileOrFolderBrowserStyle.FileSave Then
            ShowFileSave(e)
        Else
            CM.Show(BtnBrowser, BtnBrowser.Size, ToolStripDropDownDirection.AboveLeft)
        End If
    End Sub

    ''' <summary>
    ''' 显示选择文件夹对话框
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ShowFolderSelect(e As EventArgs)
        Dim cd As New FolderDialog()
        If IO.Directory.Exists(TBPath.Text.Trim()) Then cd.SelectedPath = TBPath.Text.Trim()
        If cd.ShowDialog = DialogResult.OK Then
            TBPath.Text = cd.SelectedPath
            RaiseEvent FileOrFolderSelected(Me, e)
        End If
        cd.Dispose()
        cd = Nothing
    End Sub

    ''' <summary>
    ''' 显示打开文件对话框
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ShowFileOpen(e As EventArgs)
        Dim cd As New FileDialog()
        cd.Filter = Me.Filter
        'cd.Multiselect = Me.Multiselect
        'cd.CheckFileExists = Me.CheckFileExists
        'cd.CheckPathExists = Me.CheckPathExists
        cd.FilterIndex = 0
        Dim Temp As String = TBPath.Text.Trim()
        If Temp.LastIndexOf("\") >= 0 Then
            Temp = Temp.Substring(0, Temp.LastIndexOf("\"))
            If IO.Directory.Exists(Temp) Then cd.InitialDirectory = Temp
        End If
        If cd.ShowDialog = DialogResult.OK Then
            TBPath.Text = cd.FileName
            RaiseEvent FileOrFolderSelected(Me, e)
        End If
        cd.Dispose()
        cd = Nothing
    End Sub

    ''' <summary>
    ''' 显示保存文件对话框
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ShowFileSave(e As EventArgs)
        Dim cd As New FileDialog(False)
        cd.Filter = Filter
        'cd.CheckFileExists = Me.CheckFileExists
        'cd.OverwritePrompt = Me.OverwritePrompt
        'cd.CheckPathExists = Me.CheckPathExists
        cd.FilterIndex = 0
        Dim Temp As String = TBPath.Text.Trim()
        If Temp.LastIndexOf("\") >= 0 Then
            Temp = Temp.Substring(0, Temp.LastIndexOf("\"))
            If IO.Directory.Exists(Temp) Then cd.InitialDirectory = Temp
        End If
        If cd.ShowDialog = DialogResult.OK Then
            TBPath.Text = cd.FileName
            RaiseEvent FileOrFolderSelected(Me, e)
        End If
        cd.Dispose()
        cd = Nothing
    End Sub

    ''' <summary>
    ''' 控件大小调整事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Parent_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        TBPath.Location = New Point(0, (Me.Height - TBPath.Height) / 2)
    End Sub

    ''' <summary>
    ''' 弹出菜单 文件 点击事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CM_FileDialog_Click(sender As Object, e As EventArgs) Handles CM_FileDialog.Click
        If Me.BrowserStyle = FileOrFolderBrowserStyle.FileOrFolderOpen Then
            ShowFileOpen(e)
        Else
            ShowFileSave(e)
        End If
    End Sub

    ''' <summary>
    ''' 弹出对话框 文件夹 点击事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CM_FolderDialog_Click(sender As Object, e As EventArgs) Handles CM_FolderDialog.Click
        ShowFolderSelect(e)
    End Sub

#End Region

End Class
