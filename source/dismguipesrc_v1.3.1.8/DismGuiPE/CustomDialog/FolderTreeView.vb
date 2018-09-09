Imports System.IO
Imports System.ComponentModel
<DefaultEvent("SelectedPathChanged")> _
Public Class FolderTreeView
    Inherits TreeView
    Private components As System.ComponentModel.IContainer
    Private WithEvents ImgList As System.Windows.Forms.ImageList

    Private IsSetSelectPath As Boolean = False


    Public Event SelectedPathChanged As FolderTreeViewEventHandler


    Public Sub New()
        MyBase.New()
        InitializeComponent()
        MyBase.ImageList = ImgList
        MyBase.CheckBoxes = False
        MyBase.HideSelection = False
        'RefreshTree()
    End Sub

    Public Property SelectedPath As String
        Get
            If IsNothing(Me.SelectedNode) Then
                Return ""
            Else
                Dim Temp As String = Me.SelectedNode.FullPath
                If Not Temp.EndsWith("\") Then Temp &= "\"
                Return Temp
            End If
        End Get
        Set(value As String)
            SetSelectedPath(value)
        End Set
    End Property

    Private Sub SetSelectedPath(Path As String)
        'RefreshList()
        If Not Directory.Exists(Path) Then Return
        If Path.StartsWith("\\") Then Return
        Dim Temp As String = Path
        If Temp.EndsWith("\") Then Temp = Temp.Substring(0, Temp.Length - 1)
        Dim DList() As String = Temp.Split("\")
        If Nodes.Count = 0 Then RefreshList()
        Dim Index As Integer = 1
        Dim Node As TreeNode = Nothing
        Dim Match As TreeNode = Nothing
        For Each Node In Me.Nodes
            If String.Compare(Node.Text, DList(0), True) = 0 Then
                If DList.GetUpperBound(0) = 0 Then
                    IsSetSelectPath = True
                    Me.SelectedNode = Node
                    Node.EnsureVisible()
                    IsSetSelectPath = False
                    Return
                Else
                    IsSetSelectPath = True
                    Me.SelectedNode = FindSubNode(Node, DList, Index)
                    If Not IsNothing(Me.SelectedNode) Then Me.SelectedNode.EnsureVisible()
                    IsSetSelectPath = False
                End If
            End If
        Next
    End Sub

    Private Function FindSubNode(Node As TreeNode, Check() As String, ByRef Index As Integer) As TreeNode
        Dim Temp As TreeNode = Node
        Do
            Temp = FindNextNode(Temp, Check(Index))
            Index += 1
        Loop While (Not IsNothing(Temp)) And Index <= Check.GetUpperBound(0)
        Return Temp
    End Function

    Private Function FindNextNode(Node As TreeNode, Check As String) As TreeNode
        ListFolder(Node)
        For Each n As TreeNode In Node.Nodes
            If String.Compare(n.Text, Check, True) = 0 Then
                Return n
            End If
        Next
        Return Nothing
    End Function

    Public Sub RefreshList()
        ListDrives()
    End Sub

    Private Sub ListDrives()
        Nodes.Clear()
        Dim Node As TreeNode
        For Each d As DriveInfo In DriveInfo.GetDrives()
            If d.DriveType = DriveType.Fixed Or d.DriveType = DriveType.Removable Then
                Node = New TreeNode(d.Name.Replace("\", ""), 0, 0)
                Nodes.Add(Node)
                ListFolder(Node)
            ElseIf d.DriveType = DriveType.CDRom Then
                Node = New TreeNode(d.Name.Replace("\", ""), 2, 2)
                Nodes.Add(Node)
                ListFolder(Node)
            End If
        Next
    End Sub

    Private Sub ListFolder(Root As TreeNode, Optional IsFirstLevel As Boolean = True)
        Dim Temp As String = Root.FullPath
        If Not Temp.EndsWith("\") Then Temp &= "\"
        Dim Node As TreeNode
        Root.Nodes.Clear()
        Try
            For Each e As String In Directory.GetDirectories(Temp)
                Dim di As DirectoryInfo = New DirectoryInfo(e)
                Node = New TreeNode(di.Name, 1, 1)
                Root.Nodes.Add(Node)
                'If IsFirstLevel Then ListFolder(Node, False)
            Next
        Catch ex As Exception

        End Try
    End Sub


    Protected Overrides Sub OnBeforeExpand(e As TreeViewCancelEventArgs)
        If Not IsSetSelectPath Then Me.SelectedNode = e.Node
        MyBase.OnBeforeExpand(e)
    End Sub

    Protected Overrides Sub OnAfterSelect(e As TreeViewEventArgs)
        Dim Temp As String = e.Node.FullPath
        If Not Temp.EndsWith("\") Then Temp &= "\"
        RaiseEvent SelectedPathChanged(Me, New FolderTreeViewEventArgs() With {.SelectedPath = Temp})
        ListFolder(e.Node)
        MyBase.OnAfterSelect(e)
    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FolderTreeView))
        Me.ImgList = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'ImgList
        '
        Me.ImgList.ImageStream = CType(resources.GetObject("ImgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgList.Images.SetKeyName(0, "Drive.png")
        Me.ImgList.Images.SetKeyName(1, "folder.png")
        Me.ImgList.Images.SetKeyName(2, "CDROM.png")
        '
        'FolderTreeView
        '
        Me.LineColor = System.Drawing.Color.Black
        Me.ResumeLayout(False)

    End Sub

End Class

Public Class FolderTreeViewEventArgs
    Inherits System.EventArgs
    Public Property SelectedPath As String = ""
End Class

Public Delegate Sub FolderTreeViewEventHandler(sender As Object, e As FolderTreeViewEventArgs)