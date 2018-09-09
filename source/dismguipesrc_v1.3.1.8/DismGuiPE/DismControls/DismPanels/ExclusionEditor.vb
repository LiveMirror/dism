''' <summary>
''' 排除列表编辑对话框
''' </summary>
''' <remarks></remarks>
Public Class ExclusionEditor

    ''' <summary>
    ''' 获取或者设置指定的文件夹路径
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StartPath As String
        Get
            Return lblPath.Text
        End Get
        Set(value As String)
            lblPath.Text = value
        End Set
    End Property

    ''' <summary>
    ''' 获取或者设置排除列表
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ExclusionList As DismExclusionList = Nothing

    ''' <summary>
    ''' 初始化排除列表编辑对话框
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ExclusionEditor_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadTreeView(lblPath.Text)
        If IsNothing(Me.ExclusionList) Then Me.ExclusionList = New DismExclusionList
        LoadExclusionList()
    End Sub

    ''' <summary>
    ''' 加载所有排除列表
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadExclusionList()

        LoadNormalList()
        LoadExceptionList()
        LoadCompressList()

    End Sub

    ''' <summary>
    ''' 加载排除列表
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadNormalList()
        LBExclusionList.Items.Clear()
        LBExclusionList.Items.AddRange(Me.ExclusionList.Items(DismExclusionList.ExclusionItemType.Normal))
        LBExclusionList.SelectedIndex = LBExclusionList.Items.Count - 1
    End Sub

    ''' <summary>
    ''' 加载代替默认排除列表
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadExceptionList()
        LBExceptionList.Items.Clear()
        LBExceptionList.Items.AddRange(Me.ExclusionList.Items(DismExclusionList.ExclusionItemType.Exception))
        LBExceptionList.SelectedIndex = LBExceptionList.Items.Count - 1
    End Sub

    ''' <summary>
    ''' 加载压缩时排除列表
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadCompressList()
        LBCompressList.Items.Clear()
        LBCompressList.Items.AddRange(Me.ExclusionList.Items(DismExclusionList.ExclusionItemType.Compress))
        LBCompressList.SelectedIndex = LBCompressList.Items.Count - 1
    End Sub

    ''' <summary>
    ''' 加载目录树根节点
    ''' </summary>
    ''' <param name="StartPath">指定的文件夹路径</param>
    ''' <remarks></remarks>
    Private Sub LoadTreeView(StartPath As String)
        TVDirectory.Nodes.Clear()

        Dim Dirs() As String = GetDirectories(StartPath)
        Dim Files() As String = GetFiles(StartPath)
        Dim dInfo As IO.DirectoryInfo
        Dim fInfo As IO.FileInfo
        Dim NewNode As TreeNode
        For i As Integer = 0 To Dirs.GetUpperBound(0)
            dInfo = New IO.DirectoryInfo(Dirs(i))
            NewNode = New TreeNode(dInfo.Name) With {.Tag = 1}
            TVDirectory.Nodes.Add(NewNode)
            FillNode(NewNode, StartPath)
        Next
        For i As Integer = 0 To Files.GetUpperBound(0)
            fInfo = New IO.FileInfo(Files(i))
            NewNode = New TreeNode(fInfo.Name)
            TVDirectory.Nodes.Add(NewNode)
        Next
    End Sub

    ''' <summary>
    ''' 根据节点在目录树的路径，填充其所有子节点。
    ''' </summary>
    ''' <param name="Node">节点</param>
    ''' <param name="StartPath">指定的文件夹路径</param>
    ''' <remarks></remarks>
    Private Sub FillNode(Node As TreeNode, StartPath As String)
        If IsNothing(Node.Tag) Then Return
        If Node.Nodes.Count Then Return
        Dim Temp As String = GetNodePath(Node, StartPath)
        Dim Dirs() As String = GetDirectories(Temp)
        Dim Files() As String = GetFiles(Temp)
        Dim dInfo As IO.DirectoryInfo = Nothing
        Dim fInfo As IO.FileInfo = Nothing
        Dim NewNode As TreeNode = Nothing
        For i As Integer = 0 To Dirs.GetUpperBound(0)
            dInfo = New IO.DirectoryInfo(Dirs(i))
            NewNode = New TreeNode(dInfo.Name) With {.Tag = 1}
            Node.Nodes.Add(NewNode)
        Next
        For i As Integer = 0 To Files.GetUpperBound(0)
            fInfo = New IO.FileInfo(Files(i))
            NewNode = New TreeNode(fInfo.Name)
            Node.Nodes.Add(NewNode)
        Next
    End Sub

    ''' <summary>
    ''' 获取目录树节点路径
    ''' </summary>
    ''' <param name="Node">节点</param>
    ''' <param name="StartPath">指定的文件夹路径</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetNodePath(Node As TreeNode, StartPath As String) As String
        Dim Temp As String = StartPath
        If Not Temp.EndsWith("\") Then Temp &= "\"
        Return Temp & Node.FullPath
    End Function

    ''' <summary>
    ''' 在选择目录树一个项之前，填充所有子节点和其子节点
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TVDirectory_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles TVDirectory.BeforeSelect
        If IsNothing(e.Node.Tag) Then Return
        FillNode(e.Node, lblPath.Text)
        For Each Node As TreeNode In e.Node.Nodes
            If Not IsNothing(Node.Tag) Then
                FillNode(Node, lblPath.Text)
            End If
        Next
    End Sub

    ''' <summary>
    ''' 获取指定路径的文件夹列表
    ''' </summary>
    ''' <param name="StartPath">指定的文件夹路径</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetDirectories(StartPath As String) As String()
        Try
            Return IO.Directory.GetDirectories(StartPath)
        Catch ex As Exception
            Return New String() {}
        End Try
    End Function

    ''' <summary>
    ''' 获取指定路径的文件列表
    ''' </summary>
    ''' <param name="StartPath">指定的文件夹路径</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetFiles(StartPath As String) As String()
        Try
            Return IO.Directory.GetFiles(StartPath)
        Catch ex As Exception
            Return New String() {}
        End Try
    End Function

    ''' <summary>
    ''' 添加一个排除列表项
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnExclusionAdd_Click(sender As Object, e As EventArgs) Handles BtnExclusionAdd.Click
        If Not IsNothing(TVDirectory.SelectedNode) Then
            Dim Temp As String = GetNodePath(TVDirectory.SelectedNode, "")
            Dim Index As Integer = Me.ExclusionList.FindIndex(DismExclusionList.ExclusionItemType.Normal, Temp)
            If Index = -1 Then
                Me.ExclusionList.Add(DismExclusionList.ExclusionItemType.Normal, Temp)
                LoadNormalList()
            Else
                LBExclusionList.SelectedIndex = Index
            End If
        End If
    End Sub

    ''' <summary>
    ''' 删除一个排除列表项
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnExclusionRemove_Click(sender As Object, e As EventArgs) Handles BtnExclusionRemove.Click
        If LBExclusionList.SelectedIndex = -1 Then
            MsgBox("选择一个排除列表项。", MsgBoxStyle.Critical, "排除列表项")
            Return
        End If
        Me.ExclusionList.RemoveAt(DismExclusionList.ExclusionItemType.Normal, LBExclusionList.SelectedIndex)
        LoadNormalList()
    End Sub

    ''' <summary>
    ''' 清除所有排除列表项
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnExclusionClear_Click(sender As Object, e As EventArgs) Handles BtnExclusionClear.Click
        Me.ExclusionList.Clear(DismExclusionList.ExclusionItemType.Normal)
        LoadNormalList()
    End Sub

    ''' <summary>
    ''' 添加一个自定义的排除列表项
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnExclusionAddExt_Click(sender As Object, e As EventArgs) Handles BtnExclusionAddExt.Click

        Dim Temp As String = InputBox("请输入一个排除列表项：", "排除列表项")
        If Temp = "" Then Return

        Dim Index As Integer = Me.ExclusionList.FindIndex(DismExclusionList.ExclusionItemType.Normal, Temp)
        If Index = -1 Then
            Me.ExclusionList.Add(DismExclusionList.ExclusionItemType.Normal, Temp)
            LoadNormalList()
        Else
            LBExclusionList.SelectedIndex = Index
        End If

    End Sub

    ''' <summary>
    ''' 添加一个代替默认列表项
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnExceptionAdd_Click(sender As Object, e As EventArgs) Handles BtnExceptionAdd.Click
        If Not IsNothing(TVDirectory.SelectedNode) Then
            Dim Temp As String = GetNodePath(TVDirectory.SelectedNode, "")
            Dim Index As Integer = Me.ExclusionList.FindIndex(DismExclusionList.ExclusionItemType.Exception, Temp)
            If Index = -1 Then
                Me.ExclusionList.Add(DismExclusionList.ExclusionItemType.Exception, Temp)
                LoadExceptionList()
            Else
                LBExceptionList.SelectedIndex = Index
            End If
        End If
    End Sub

    ''' <summary>
    ''' 删除一个代替默认排除列表项
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnExceptionRemove_Click(sender As Object, e As EventArgs) Handles BtnExceptionRemove.Click
        If LBExceptionList.SelectedIndex = -1 Then
            MsgBox("选择一个代替默认列表项。", MsgBoxStyle.Critical, "代替默认列表项")
            Return
        End If
        Me.ExclusionList.RemoveAt(DismExclusionList.ExclusionItemType.Exception, LBExceptionList.SelectedIndex)
        LoadExceptionList()
    End Sub

    ''' <summary>
    ''' 清除所有代替默认排除列表项
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnExceptionClear_Click(sender As Object, e As EventArgs) Handles BtnExceptionClear.Click
        Me.ExclusionList.Clear(DismExclusionList.ExclusionItemType.Exception)
        LoadExceptionList()
    End Sub

    ''' <summary>
    ''' 添加一个自定义的代替默认排除列表项
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnExceptionAddExt_Click(sender As Object, e As EventArgs) Handles BtnExceptionAddExt.Click

        Dim Temp As String = InputBox("请输入一个代替默认排除列表项：", "代替默认排除列表项")
        If Temp = "" Then Return

        Dim Index As Integer = Me.ExclusionList.FindIndex(DismExclusionList.ExclusionItemType.Exception, Temp)
        If Index = -1 Then
            Me.ExclusionList.Add(DismExclusionList.ExclusionItemType.Exception, Temp)
            LoadExceptionList()
        Else
            LBExceptionList.SelectedIndex = Index
        End If

    End Sub

    ''' <summary>
    ''' 添加一个压缩时的排除项
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCompressAdd_Click(sender As Object, e As EventArgs) Handles BtnCompressAdd.Click
        If Not IsNothing(TVDirectory.SelectedNode) Then
            Dim Temp As String = GetNodePath(TVDirectory.SelectedNode, "")
            Dim Index As Integer = Me.ExclusionList.FindIndex(DismExclusionList.ExclusionItemType.Compress, Temp)
            If Index = -1 Then
                Me.ExclusionList.Add(DismExclusionList.ExclusionItemType.Compress, Temp)
                LoadCompressList()
            Else
                LBCompressList.SelectedIndex = Index
            End If
        End If
    End Sub

    ''' <summary>
    ''' 删除一个压缩时的排除项
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCompressRemove_Click(sender As Object, e As EventArgs) Handles BtnCompressRemove.Click
        If LBCompressList.SelectedIndex = -1 Then
            MsgBox("选择一个排除项。", MsgBoxStyle.Critical, "排除项")
            Return
        End If
        Me.ExclusionList.RemoveAt(DismExclusionList.ExclusionItemType.Compress, LBCompressList.SelectedIndex)
        LoadCompressList()
    End Sub

    ''' <summary>
    ''' 清除所有压缩时的排除项
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCompressClear_Click(sender As Object, e As EventArgs) Handles BtnCompressClear.Click
        Me.ExclusionList.Clear(DismExclusionList.ExclusionItemType.Compress)
        LoadCompressList()
    End Sub

    ''' <summary>
    ''' 添加一个自定义的压缩时的排除项
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCompressAddExt_Click(sender As Object, e As EventArgs) Handles BtnCompressAddExt.Click

        Dim Temp As String = InputBox("请输入一个压缩排除项：", "压缩排除项")
        If Temp = "" Then Return

        Dim Index As Integer = Me.ExclusionList.FindIndex(DismExclusionList.ExclusionItemType.Compress, Temp)
        If Index = -1 Then
            Me.ExclusionList.Add(DismExclusionList.ExclusionItemType.Compress, Temp)
            LoadCompressList()
        Else
            LBCompressList.SelectedIndex = Index
        End If

    End Sub

    ''' <summary>
    ''' 点击确定关闭对话框
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Me.Close()
    End Sub


End Class