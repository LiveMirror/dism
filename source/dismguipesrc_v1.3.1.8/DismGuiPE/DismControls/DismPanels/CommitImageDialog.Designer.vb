<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CommitImageDialog
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
        Me.BtnCommit = New System.Windows.Forms.Button()
        Me.BtnAppend = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnCommit
        '
        Me.BtnCommit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCommit.BackColor = System.Drawing.Color.White
        Me.BtnCommit.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.BtnCommit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnCommit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue
        Me.BtnCommit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCommit.Location = New System.Drawing.Point(12, 24)
        Me.BtnCommit.Name = "BtnCommit"
        Me.BtnCommit.Size = New System.Drawing.Size(260, 32)
        Me.BtnCommit.TabIndex = 0
        Me.BtnCommit.Text = "保存映像"
        Me.BtnCommit.UseVisualStyleBackColor = False
        '
        'BtnAppend
        '
        Me.BtnAppend.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAppend.BackColor = System.Drawing.Color.White
        Me.BtnAppend.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.BtnAppend.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnAppend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue
        Me.BtnAppend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAppend.Location = New System.Drawing.Point(12, 63)
        Me.BtnAppend.Name = "BtnAppend"
        Me.BtnAppend.Size = New System.Drawing.Size(260, 32)
        Me.BtnAppend.TabIndex = 1
        Me.BtnAppend.Text = "追加到现有 .WIM 文件"
        Me.BtnAppend.UseVisualStyleBackColor = False
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.BackColor = System.Drawing.Color.White
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.BtnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancel.Location = New System.Drawing.Point(12, 101)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(260, 32)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "取消操作"
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'CommitImageDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(284, 156)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnAppend)
        Me.Controls.Add(Me.BtnCommit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CommitImageDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "保存映像选项"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnCommit As System.Windows.Forms.Button
    Friend WithEvents BtnAppend As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
End Class
