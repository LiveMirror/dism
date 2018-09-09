Public Class FolderDialog

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        FTV.RefreshList()

    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Public Property SelectedPath As String
        Get
            Return FTV.SelectedPath
        End Get
        Set(value As String)
            FTV.SelectedPath = value
        End Set
    End Property


    Private Sub FTV_SelectedPathChanged(sender As Object, e As FolderTreeViewEventArgs) Handles FTV.SelectedPathChanged
        lblPath.Text = FTV.SelectedPath
    End Sub
End Class