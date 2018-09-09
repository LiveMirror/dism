<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FolderDialog
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

        Me.FTV = New FolderTreeView()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'FTV
        '
        Me.FTV.HideSelection = False
        Me.FTV.ImageIndex = 0
        Me.FTV.Location = New System.Drawing.Point(0, 24)
        Me.FTV.Name = "FTV"
        Me.FTV.SelectedImageIndex = 0
        Me.FTV.SelectedPath = ""
        Me.FTV.ShowNodeToolTips = True
        Me.FTV.Size = New System.Drawing.Size(401, 315)
        Me.FTV.TabIndex = 0
        '
        'lblPath
        '
        Me.lblPath.AutoEllipsis = True
        Me.lblPath.Location = New System.Drawing.Point(0, 7)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lblPath.Size = New System.Drawing.Size(401, 12)
        Me.lblPath.TabIndex = 1
        Me.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(200, 347)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(80, 32)
        Me.BtnOK.TabIndex = 2
        Me.BtnOK.Text = "确定"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(298, 347)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(80, 32)
        Me.BtnCancel.TabIndex = 3
        Me.BtnCancel.Text = "取消"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'FolderDialog
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(401, 384)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.FTV)
        Me.Controls.Add(Me.lblPath)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FolderDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "浏览文件夹"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FTV As FolderTreeView
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
End Class
