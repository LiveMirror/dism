<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MountedWimInfoComboBox
    Inherits System.Windows.Forms.UserControl

    'UserControl 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.BtnBrowser = New System.Windows.Forms.Button()
        Me.BtnRefresh = New System.Windows.Forms.Button()
        Me.TT = New System.Windows.Forms.ToolTip(Me.components)
        Me.MCB = New DismGuiPE.MyComboBox()
        Me.SuspendLayout()
        '
        'BtnBrowser
        '
        Me.BtnBrowser.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnBrowser.Location = New System.Drawing.Point(510, 0)
        Me.BtnBrowser.Name = "BtnBrowser"
        Me.BtnBrowser.Size = New System.Drawing.Size(50, 28)
        Me.BtnBrowser.TabIndex = 2
        Me.BtnBrowser.Text = "浏览"
        Me.TT.SetToolTip(Me.BtnBrowser, "浏览映像")
        Me.BtnBrowser.UseVisualStyleBackColor = True
        '
        'BtnRefresh
        '
        Me.BtnRefresh.BackgroundImage = Global.DismGuiPE.My.Resources.Resources.Refresh
        Me.BtnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnRefresh.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnRefresh.Location = New System.Drawing.Point(475, 0)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(35, 28)
        Me.BtnRefresh.TabIndex = 1
        Me.TT.SetToolTip(Me.BtnRefresh, "刷新已装载映像列表")
        Me.BtnRefresh.UseVisualStyleBackColor = True
        '
        'TT
        '
        Me.TT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'MCB
        '
        Me.MCB.DisplayMember = "MountDir"
        Me.MCB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MCB.DrawItemHandler = Nothing
        Me.MCB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.MCB.DropDownHeight = 3
        Me.MCB.DropDownItemHeight = 100
        Me.MCB.FormattingEnabled = True
        Me.MCB.IntegralHeight = False
        Me.MCB.Location = New System.Drawing.Point(0, 0)
        Me.MCB.MaxDropDownItems = 5
        Me.MCB.Name = "MCB"
        Me.MCB.Size = New System.Drawing.Size(475, 22)
        Me.MCB.TabIndex = 0
        '
        'MountedWimInfoComboBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.MCB)
        Me.Controls.Add(Me.BtnRefresh)
        Me.Controls.Add(Me.BtnBrowser)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "MountedWimInfoComboBox"
        Me.Size = New System.Drawing.Size(560, 28)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents TT As System.Windows.Forms.ToolTip
    Private WithEvents BtnBrowser As System.Windows.Forms.Button
    Private WithEvents BtnRefresh As System.Windows.Forms.Button
    Private WithEvents MCB As DismGuiPE.MyComboBox

End Class
