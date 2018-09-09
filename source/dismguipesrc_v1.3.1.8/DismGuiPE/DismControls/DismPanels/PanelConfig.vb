Public Class PanelConfig
    Inherits DismPanelBase
    Friend WithEvents CBDismSelector As System.Windows.Forms.ComboBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TBDismPath As System.Windows.Forms.TextBox
    Friend WithEvents BtnApply As System.Windows.Forms.Button

    Protected Overrides Sub OnLoadConfig()
        CBDismSelector.SelectedIndex = DismConfig.GetItem("DismSelector", 1)
        TBDismPath.Text = DismShell.DismPath
    End Sub

    Public Sub New()
        InitializeComponent()

    End Sub

    Private Sub InitializeComponent()
        Me.BtnApply = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBDismSelector = New System.Windows.Forms.ComboBox()
        Me.TBDismPath = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'BtnApply
        '
        Me.BtnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnApply.Location = New System.Drawing.Point(506, 264)
        Me.BtnApply.Name = "BtnApply"
        Me.BtnApply.Size = New System.Drawing.Size(80, 28)
        Me.BtnApply.TabIndex = 9
        Me.BtnApply.Text = "应用"
        Me.BtnApply.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 12)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "DISM组件优先选择："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CBDismSelector
        '
        Me.CBDismSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBDismSelector.FormattingEnabled = True
        Me.CBDismSelector.Items.AddRange(New Object() {"系统自带", "程序内置"})
        Me.CBDismSelector.Location = New System.Drawing.Point(129, 13)
        Me.CBDismSelector.Name = "CBDismSelector"
        Me.CBDismSelector.Size = New System.Drawing.Size(81, 20)
        Me.CBDismSelector.TabIndex = 11
        '
        'TBDismPath
        '
        Me.TBDismPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBDismPath.Location = New System.Drawing.Point(216, 13)
        Me.TBDismPath.Name = "TBDismPath"
        Me.TBDismPath.ReadOnly = True
        Me.TBDismPath.Size = New System.Drawing.Size(369, 21)
        Me.TBDismPath.TabIndex = 12
        '
        'PanelConfig
        '
        Me.Controls.Add(Me.TBDismPath)
        Me.Controls.Add(Me.CBDismSelector)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnApply)
        Me.Name = "PanelConfig"
        Me.Size = New System.Drawing.Size(600, 300)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Sub BtnApply_Click(sender As Object, e As EventArgs) Handles BtnApply.Click
        DismConfig.SetItem("DismSelector", CBDismSelector.SelectedIndex)
        DismShell.UpdateDismExecutePath()
        DismConfig.Save()
        TBDismPath.Text = DismShell.DismPath
    End Sub


End Class
