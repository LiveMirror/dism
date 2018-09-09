<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UnmountImageDialog
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
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnAppend = New System.Windows.Forms.Button()
        Me.BtnCommit = New System.Windows.Forms.Button()
        Me.BtnDiscard = New System.Windows.Forms.Button()
        Me.SuspendLayout()
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
        Me.BtnCancel.Location = New System.Drawing.Point(12, 139)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(260, 32)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "取消操作"
        Me.BtnCancel.UseVisualStyleBackColor = False
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
        Me.BtnAppend.TabIndex = 4
        Me.BtnAppend.Text = "卸载并追加到现有 .WIM 文件"
        Me.BtnAppend.UseVisualStyleBackColor = False
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
        Me.BtnCommit.TabIndex = 3
        Me.BtnCommit.Text = "卸载并保存映像"
        Me.BtnCommit.UseVisualStyleBackColor = False
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDiscard.BackColor = System.Drawing.Color.White
        Me.BtnDiscard.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.BtnDiscard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnDiscard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue
        Me.BtnDiscard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDiscard.Location = New System.Drawing.Point(12, 101)
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(260, 32)
        Me.BtnDiscard.TabIndex = 6
        Me.BtnDiscard.Text = "卸载但不保存映像"
        Me.BtnDiscard.UseVisualStyleBackColor = False
        '
        'UnmountImageDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(284, 188)
        Me.Controls.Add(Me.BtnDiscard)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnAppend)
        Me.Controls.Add(Me.BtnCommit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UnmountImageDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "卸载映像选项"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnAppend As System.Windows.Forms.Button
    Friend WithEvents BtnCommit As System.Windows.Forms.Button
    Friend WithEvents BtnDiscard As System.Windows.Forms.Button
End Class
