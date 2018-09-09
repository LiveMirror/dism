<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WimFileSelector
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
        Me.TBPath = New System.Windows.Forms.TextBox()
        Me.TT = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'BtnBrowser
        '
        Me.BtnBrowser.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnBrowser.Location = New System.Drawing.Point(373, 0)
        Me.BtnBrowser.Name = "BtnBrowser"
        Me.BtnBrowser.Size = New System.Drawing.Size(50, 37)
        Me.BtnBrowser.TabIndex = 1
        Me.BtnBrowser.Text = "浏览"
        Me.BtnBrowser.UseVisualStyleBackColor = True
        '
        'TBPath
        '
        Me.TBPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBPath.Location = New System.Drawing.Point(0, 0)
        Me.TBPath.Name = "TBPath"
        Me.TBPath.Size = New System.Drawing.Size(373, 21)
        Me.TBPath.TabIndex = 0
        '
        'TT
        '
        Me.TT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'WimFileSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TBPath)
        Me.Controls.Add(Me.BtnBrowser)
        Me.Name = "WimFileSelector"
        Me.Size = New System.Drawing.Size(423, 37)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents BtnBrowser As System.Windows.Forms.Button
    Private WithEvents TBPath As System.Windows.Forms.TextBox
    Friend WithEvents TT As System.Windows.Forms.ToolTip

End Class
