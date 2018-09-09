<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileOrFolderSelector
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
        Me.TBPath = New System.Windows.Forms.TextBox()
        Me.BtnBrowser = New System.Windows.Forms.Button()
        Me.CM = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CM_FileDialog = New System.Windows.Forms.ToolStripMenuItem()
        Me.CM_FolderDialog = New System.Windows.Forms.ToolStripMenuItem()
        Me.CM.SuspendLayout()
        Me.SuspendLayout()
        '
        'TBPath
        '
        Me.TBPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBPath.Location = New System.Drawing.Point(0, 0)
        Me.TBPath.Name = "TBPath"
        Me.TBPath.Size = New System.Drawing.Size(382, 21)
        Me.TBPath.TabIndex = 2
        '
        'BtnBrowser
        '
        Me.BtnBrowser.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnBrowser.Location = New System.Drawing.Point(382, 0)
        Me.BtnBrowser.Name = "BtnBrowser"
        Me.BtnBrowser.Size = New System.Drawing.Size(50, 29)
        Me.BtnBrowser.TabIndex = 3
        Me.BtnBrowser.Text = "浏览"
        Me.BtnBrowser.UseVisualStyleBackColor = True
        '
        'CM
        '
        Me.CM.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CM_FileDialog, Me.CM_FolderDialog})
        Me.CM.Name = "CM"
        Me.CM.Size = New System.Drawing.Size(153, 70)
        '
        'CM_FileDialog
        '
        Me.CM_FileDialog.Name = "CM_FileDialog"
        Me.CM_FileDialog.Size = New System.Drawing.Size(152, 22)
        Me.CM_FileDialog.Text = "打开文件"
        '
        'CM_FolderDialog
        '
        Me.CM_FolderDialog.Name = "CM_FolderDialog"
        Me.CM_FolderDialog.Size = New System.Drawing.Size(152, 22)
        Me.CM_FolderDialog.Text = "打开文件夹"
        '
        'FileOrFolderSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TBPath)
        Me.Controls.Add(Me.BtnBrowser)
        Me.Name = "FileOrFolderSelector"
        Me.Size = New System.Drawing.Size(432, 29)
        Me.CM.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents TBPath As System.Windows.Forms.TextBox
    Private WithEvents BtnBrowser As System.Windows.Forms.Button
    Friend WithEvents CM As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CM_FileDialog As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CM_FolderDialog As System.Windows.Forms.ToolStripMenuItem

End Class
