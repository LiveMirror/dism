Imports Microsoft.Win32
Public Class PanelAbout
    Inherits DismPanelBase
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblLicense As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LnkTarget As System.Windows.Forms.LinkLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Protected Overrides Sub OnLoadConfig()
        lblVersion.Text = Application.ProductVersion.ToString()
    End Sub

    Public Sub New()

        InitializeComponent()

    End Sub

    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblLicense = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LnkTarget = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "作    者："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "联系方式："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "软件版本："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(84, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Mac / netps"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(84, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 12)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "dirms@163.com"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "版权声明："
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(84, 62)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(0, 12)
        Me.lblVersion.TabIndex = 6
        '
        'lblLicense
        '
        Me.lblLicense.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLicense.Location = New System.Drawing.Point(84, 85)
        Me.lblLicense.Name = "lblLicense"
        Me.lblLicense.Size = New System.Drawing.Size(491, 101)
        Me.lblLicense.TabIndex = 7
        Me.lblLicense.Text = "对使用该软件产生的任何后果,本人不负任何责任！请慎用！" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "若有Bug请反馈到邮箱。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "若有改进意见也请发往邮箱。"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 195)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "参考资料："
        '
        'LnkTarget
        '
        Me.LnkTarget.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LnkTarget.AutoSize = True
        Me.LnkTarget.Location = New System.Drawing.Point(84, 195)
        Me.LnkTarget.Name = "LnkTarget"
        Me.LnkTarget.Size = New System.Drawing.Size(341, 12)
        Me.LnkTarget.TabIndex = 9
        Me.LnkTarget.TabStop = True
        Me.LnkTarget.Text = "http://technet.microsoft.com/zh-cn/library/hh825099.aspx"
        '
        'PanelAbout
        '
        Me.Controls.Add(Me.LnkTarget)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblLicense)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PanelAbout"
        Me.Size = New System.Drawing.Size(600, 300)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Sub LnkTarget_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkTarget.LinkClicked
        If Not (e.Button = Windows.Forms.MouseButtons.Left) Then Return
        Try


            Dim Key As RegistryKey = Registry.ClassesRoot.OpenSubKey("http\shell\open\command\")
            Dim s As String = Key.GetValue("").ToString
            Key.Close()

            Dim App As String = ""
            If s.IndexOf(" -") > 0 Then
                App = s.Substring(0, s.IndexOf(" -"))
            ElseIf s.IndexOf(" %") Then
                App = s.Substring(0, s.IndexOf(" %"))
            End If

            Do While App.StartsWith("""")
                App = App.Remove(0, 1)
            Loop
            Do While App.EndsWith("""")
                App = App.Substring(0, App.Length - 1)
            Loop

            System.Diagnostics.Process.Start(App, LnkTarget.Text.Substring(e.Link.Start, e.Link.Length))

        Catch ex As Exception

        End Try

    End Sub

End Class
