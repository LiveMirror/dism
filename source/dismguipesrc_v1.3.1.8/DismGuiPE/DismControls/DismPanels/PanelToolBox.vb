Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Drawing.Drawing2D
Public Class PanelToolBox
    Inherits DismPanelBase
    Friend WithEvents FLP As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents PanelBottom As System.Windows.Forms.Panel
    Friend WithEvents BtnEdit As System.Windows.Forms.Button

    Private mToolBox As New List(Of ToolBoxItemInfo)
    Private PathToolAll As String = "Tools\All\"
    Private PathConfigAll As String = "Tools\All\Config.Xml"
    Private PathEnvironment As String = IIf(System.Environment.Is64BitOperatingSystem, "Tools\x64\", "Tools\x86\")
    Private PathConfigEnvironment As String = IIf(System.Environment.Is64BitOperatingSystem, "Tools\x64\", "Tools\x86\") & "Config.Xml"

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.FLP = New System.Windows.Forms.FlowLayoutPanel()
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.PanelBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'FLP
        '
        Me.FLP.AutoScroll = True
        Me.FLP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FLP.Location = New System.Drawing.Point(0, 0)
        Me.FLP.Name = "FLP"
        Me.FLP.Size = New System.Drawing.Size(600, 260)
        Me.FLP.TabIndex = 0
        '
        'PanelBottom
        '
        Me.PanelBottom.Controls.Add(Me.BtnEdit)
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 260)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(600, 40)
        Me.PanelBottom.TabIndex = 1
        '
        'BtnEdit
        '
        Me.BtnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEdit.Location = New System.Drawing.Point(506, 7)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(80, 28)
        Me.BtnEdit.TabIndex = 9
        Me.BtnEdit.Text = "编辑信息"
        Me.BtnEdit.UseVisualStyleBackColor = True
        '
        'PanelToolBox
        '
        Me.Controls.Add(Me.FLP)
        Me.Controls.Add(Me.PanelBottom)
        Me.Name = "PanelToolBox"
        Me.Size = New System.Drawing.Size(600, 300)
        Me.PanelBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Protected Overrides Sub OnLoadConfig()
        LoadToolsInfo()
        ToolsLayout()
    End Sub

    Private Sub ToolsLayout()

        FLP.Controls.Clear()

        Dim g As Graphics = Graphics.FromHwnd(Me.Handle)

        Dim Max As Single = 0.0!, Temp As Single = 0.0!
        Dim MaxIcon As Integer = 0.0!
        '计算最长的字符串
        For Each e As ToolBoxItemInfo In mToolBox
            Temp = g.MeasureString(e.Name, Me.Font).Width
            If Temp > Max Then Max = Temp
            If e.Image IsNot Nothing Then
                If e.Image.Size.Width > MaxIcon Then MaxIcon = e.Image.Size.Width
            End If
        Next

        Dim Btn As Button
        For i As Integer = 0 To mToolBox.Count - 1
            Btn = New Button() With {.Name = "Btn" & i,
                                     .Text = mToolBox(i).Name,
                                     .Tag = mToolBox(i),
                                     .Image = mToolBox(i).Image,
                                     .ImageAlign = ContentAlignment.MiddleLeft,
                                     .TextImageRelation = TextImageRelation.ImageBeforeText,
                                     .Size = New Size(Max + MaxIcon + 12, 38),
                                     .TextAlign = ContentAlignment.MiddleLeft,
                                     .Visible = mToolBox(i).Visible}
            AddHandler Btn.Click, AddressOf Tool_Click
            FLP.Controls.Add(Btn)
        Next

    End Sub

    Private Sub Tool_Click(sender As Object, e As EventArgs)
        Dim tInfo As ToolBoxItemInfo = CType(sender, Button).Tag
        Shell32.ShellExecute(Nothing, vbNullString, tInfo.Path, vbNullString, vbNullString, Shell32.ShowWindow.Normal)

    End Sub

    Private Sub LoadToolsInfo()

        mToolBox.Clear()



        If Not IO.Directory.Exists("Tools\all") Then IO.Directory.CreateDirectory("Tools\all")
        If Not IO.Directory.Exists("Tools\x64") Then IO.Directory.CreateDirectory("Tools\x64")
        If Not IO.Directory.Exists("Tools\x86") Then IO.Directory.CreateDirectory("Tools\x86")

        Dim XConfigAll As XElement, XConfigEnvironment As XElement
        Dim WinDir As String = System.Environment.SystemDirectory()
        If Not WinDir.EndsWith("\") Then WinDir &= "\"
        mToolBox.Add(New ToolBoxItemInfo(WinDir & "Cmd.exe", "命令提示符"))

        If IO.File.Exists(PathConfigAll) Then
            Try
                XConfigAll = XElement.Load(PathConfigAll)
            Catch ex As Exception
                XConfigAll = <Config></Config>
                XConfigAll.Save(PathConfigAll)
            End Try
        Else
            XConfigAll = <Config></Config>
            XConfigAll.Save(PathConfigAll)
        End If

        If IO.File.Exists(PathConfigEnvironment) Then
            Try
                XConfigEnvironment = XElement.Load(PathConfigEnvironment)
            Catch ex As Exception
                XConfigEnvironment = <Config></Config>
                XConfigEnvironment.Save(PathConfigEnvironment)
            End Try
        Else
            XConfigEnvironment = <Config></Config>
            XConfigEnvironment.Save(PathConfigEnvironment)
        End If

        '加载版本通用的工具 .Bat .Cmd .Exe 
        Dim DInfo As IO.DirectoryInfo
        FindExecuteableFile(PathToolAll, mToolBox, XConfigAll)
        For Each Dir As String In IO.Directory.GetDirectories(PathToolAll)
            DInfo = New IO.DirectoryInfo(Dir)
            FindExecuteableFile(Dir, mToolBox, XConfigEnvironment, DInfo.Name)
        Next

        '加载对应系统位数的版本工具
        FindExecuteableFile(PathEnvironment, mToolBox, XConfigEnvironment)
        For Each Dir As String In IO.Directory.GetDirectories(PathEnvironment)
            DInfo = New IO.DirectoryInfo(Dir)
            FindExecuteableFile(Dir, mToolBox, XConfigEnvironment, DInfo.Name)
        Next

        XConfigAll.Save(PathConfigAll)
        XConfigEnvironment.Save(PathConfigEnvironment)

    End Sub

    Private Sub FindExecuteableFile(Directory As String, ToolsBox As List(Of ToolBoxItemInfo), Config As XElement, Optional Parent As String = "")
        Dim fInfo As IO.FileInfo
        Dim Temp As String = "", pName As String = "", tInfo As ToolBoxItemInfo = Nothing
        Dim Visible As Boolean = True

        For Each File As String In IO.Directory.GetFiles(Directory, "*.*")
            fInfo = New IO.FileInfo(File)
            If fInfo.Extension.ToLower = ".exe" Or fInfo.Extension.ToLower = ".bat" Or fInfo.Extension.ToLower = ".cmd" Then
                tInfo = New ToolBoxItemInfo(fInfo.FullName, GetDisplayName(Config, fInfo.Name, fInfo.Extension, Visible, Parent))
                tInfo.Visible = Visible
                mToolBox.Add(tInfo)
            End If
        Next
    End Sub

    Private Function GetDisplayName(Src As XElement, FileName As String, Extension As String, ByRef Visible As Boolean, Optional Parent As String = "") As String
        For Each x As XElement In Src.Elements
            If String.Compare(x.Attribute("ID").Value, IIf(Parent = "", FileName, Parent & "." & FileName), True) = 0 Then
                If IsNothing(x.Attribute("Visible")) Then x.Add(New XAttribute("Visible", "True"))
                Boolean.TryParse(x.Attribute("Visible").Value, Visible)
                Return x.Value
            End If
        Next
        Visible = True
        Dim e As XElement = <Item ID=<%= IIf(Parent = "", FileName, Parent & "." & FileName) %> Visible="True"><%= FileName.Substring(0, FileName.Length - Extension.Length) %></Item>
        Src.Add(e)
        Return e.Value
    End Function

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Dim f As New ToolBoxItemInfoEditor() With {.PathConfigAll = PathConfigAll, .PathConfigEnvironment = PathConfigEnvironment}
        If f.ShowDialog() = DialogResult.OK Then
            OnLoadConfig()
        End If
        f.Dispose()
        f = Nothing
    End Sub
End Class
