<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WimInfoComboBox
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
        Me.BtnRefresh = New System.Windows.Forms.Button()
        Me.TT = New System.Windows.Forms.ToolTip(Me.components)
        Me.MCB = New DismGuiPE.MyComboBox()
        Me.SuspendLayout()
        '
        'BtnRefresh
        '
        Me.BtnRefresh.BackgroundImage = Global.DismGuiPE.My.Resources.Resources.Refresh
        Me.BtnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnRefresh.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnRefresh.Location = New System.Drawing.Point(245, 0)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(35, 25)
        Me.BtnRefresh.TabIndex = 1
        Me.TT.SetToolTip(Me.BtnRefresh, "刷新 .WIM 文件信息")
        Me.BtnRefresh.UseVisualStyleBackColor = True
        '
        'TT
        '
        Me.TT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'MCB
        '
        Me.MCB.DisplayMember = "Index"
        Me.MCB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MCB.DrawItemHandler = Nothing
        Me.MCB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.MCB.DropDownHeight = 3
        Me.MCB.DropDownItemHeight = 90
        Me.MCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MCB.FormattingEnabled = True
        Me.MCB.IntegralHeight = False
        Me.MCB.Location = New System.Drawing.Point(0, 0)
        Me.MCB.MaxDropDownItems = 3
        Me.MCB.Name = "MCB"
        Me.MCB.Size = New System.Drawing.Size(245, 22)
        Me.MCB.TabIndex = 0
        '
        'WimInfoComboBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.MCB)
        Me.Controls.Add(Me.BtnRefresh)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "WimInfoComboBox"
        Me.Size = New System.Drawing.Size(280, 25)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents MCB As DismGuiPE.MyComboBox
    Private WithEvents BtnRefresh As System.Windows.Forms.Button
    Friend WithEvents TT As System.Windows.Forms.ToolTip

End Class
