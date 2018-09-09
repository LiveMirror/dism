Public Class FileDialog

    Private mIsOpen As Boolean = True

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        LoadText()
    End Sub

    Public Sub New(IsOpen As Boolean)
        InitializeComponent()
        Me.IsOpen = IsOpen
    End Sub

    Private Sub LoadText()
        BtnOK.Text = IIf(mIsOpen, "打开", "保存")
        Me.Text = IIf(mIsOpen, "打开为", "另存为")
    End Sub

    Public Property FilterIndex As Integer
        Get
            Return FDG.FilterIndex
        End Get
        Set(value As Integer)
            FDG.FilterIndex = value
        End Set
    End Property

    Public Property OverwritePrompt As Boolean = True

    Public Property IsOpen As Boolean
        Get
            Return mIsOpen
        End Get
        Set(value As Boolean)
            mIsOpen = value
            LoadText()
        End Set
    End Property


    Public Property Filter As String
        Get
            Return FDG.Filter
        End Get
        Set(value As String)
            FDG.Filter = value
            FDG.FillExtension(CBExtension)
        End Set
    End Property

    Public Property InitialDirectory As String
        Get
            Return FTV.SelectedPath
        End Get
        Set(value As String)
            FTV.RefreshList()
            FTV.SelectedPath = value
        End Set
    End Property

    Public Property FileName As String
        Get
            Return FTV.SelectedPath & CBFileName.Text.Trim()
        End Get
        Set(value As String)
            Dim Temp As String = value.Substring(0, value.LastIndexOf("\"))
            If IO.Directory.Exists(Temp) Then Me.InitialDirectory = Temp
            If IO.File.Exists(value) Then
                CBFileName.Text = value.Substring(value.LastIndexOf("\") + 1)
            Else
                CBFileName.Text = ""
            End If
        End Set
    End Property

    Private Sub FTV_SelectedPathChanged(sender As Object, e As FolderTreeViewEventArgs) Handles FTV.SelectedPathChanged
        FDG.Directory = e.SelectedPath
        FDG.FillFileNames(CBFileName)
        If FDG.Rows.Count = 0 And Me.IsOpen Then CBFileName.Text = ""
    End Sub

    Private Sub FileDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.InitialDirectory = "" Then FTV.RefreshList()
        FDG.FillExtension(CBExtension)
    End Sub

    Private Sub CBExtension_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBExtension.SelectedIndexChanged
        If CBExtension.SelectedIndex = -1 Then Return
        FDG.FilterIndex = CBExtension.SelectedIndex
        FDG.Directory = FTV.SelectedPath
    End Sub

    Private Sub FDG_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles FDG.RowEnter
        If e.RowIndex = -1 Then
            CBFileName.Text = ""
            Return
        End If
        CBFileName.Text = FDG.Rows(e.RowIndex).Cells(1).Value.ToString
    End Sub


    Private Sub CBFileName_SelectedValueChanged(sender As Object, e As EventArgs) Handles CBFileName.SelectedValueChanged
        FDG.SetRowSelect(CBFileName.Text.Trim())
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        If Not IO.Directory.Exists(FTV.SelectedPath) Then Return
        If mIsOpen AndAlso Not IO.File.Exists(Me.FileName) Then Return
        Dim fName As String = CBFileName.Text.Trim()
        Dim Ext As String = ""
        If fName.LastIndexOf(".") >= 0 Then
            Ext = fName.Substring(fName.LastIndexOf("."))
        End If
        If Not FDG.CheckExtension("*.*") Then
            If Ext = "" OrElse Not FDG.CheckExtension("*" & Ext) Then
                CBFileName.Text = fName & FDG.GetExtension()
            End If
        End If

        If Not mIsOpen AndAlso IO.File.Exists(Me.FileName) AndAlso OverwritePrompt = True Then
            If MsgBox("文件已经存在！是否要覆盖？", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, Me.Text) <> MsgBoxResult.Yes Then Return
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()


    End Sub
End Class