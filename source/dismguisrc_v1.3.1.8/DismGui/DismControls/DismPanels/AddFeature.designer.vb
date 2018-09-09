<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddFeature
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

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddFeature))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TBFeatureName = New System.Windows.Forms.TextBox()
        Me.BtnRemoveSource = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.LBSource = New System.Windows.Forms.ListBox()
        Me.BtnAddSource = New System.Windows.Forms.Button()
        Me.ChkAll = New System.Windows.Forms.CheckBox()
        Me.ChkLimitAccess = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "功能名称："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "功 能 库："
        '
        'TBFeatureName
        '
        Me.TBFeatureName.Location = New System.Drawing.Point(72, 16)
        Me.TBFeatureName.Name = "TBFeatureName"
        Me.TBFeatureName.Size = New System.Drawing.Size(428, 21)
        Me.TBFeatureName.TabIndex = 0
        '
        'BtnRemoveSource
        '
        Me.BtnRemoveSource.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRemoveSource.Location = New System.Drawing.Point(378, 44)
        Me.BtnRemoveSource.Name = "BtnRemoveSource"
        Me.BtnRemoveSource.Size = New System.Drawing.Size(52, 25)
        Me.BtnRemoveSource.TabIndex = 1
        Me.BtnRemoveSource.Text = "删除"
        Me.BtnRemoveSource.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(419, 259)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(80, 28)
        Me.BtnCancel.TabIndex = 7
        Me.BtnCancel.Text = "取消"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(333, 259)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(80, 28)
        Me.BtnOK.TabIndex = 6
        Me.BtnOK.Text = "确定"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'LBSource
        '
        Me.LBSource.FormattingEnabled = True
        Me.LBSource.ItemHeight = 12
        Me.LBSource.Location = New System.Drawing.Point(12, 71)
        Me.LBSource.Name = "LBSource"
        Me.LBSource.Size = New System.Drawing.Size(488, 172)
        Me.LBSource.TabIndex = 3
        '
        'BtnAddSource
        '
        Me.BtnAddSource.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddSource.Location = New System.Drawing.Point(449, 44)
        Me.BtnAddSource.Name = "BtnAddSource"
        Me.BtnAddSource.Size = New System.Drawing.Size(52, 25)
        Me.BtnAddSource.TabIndex = 2
        Me.BtnAddSource.Text = "添加"
        Me.BtnAddSource.UseVisualStyleBackColor = True
        '
        'ChkAll
        '
        Me.ChkAll.AutoSize = True
        Me.ChkAll.Location = New System.Drawing.Point(12, 249)
        Me.ChkAll.Name = "ChkAll"
        Me.ChkAll.Size = New System.Drawing.Size(108, 16)
        Me.ChkAll.TabIndex = 4
        Me.ChkAll.Text = "启用所有父功能"
        Me.ChkAll.UseVisualStyleBackColor = True
        '
        'ChkLimitAccess
        '
        Me.ChkLimitAccess.AutoSize = True
        Me.ChkLimitAccess.Location = New System.Drawing.Point(12, 271)
        Me.ChkLimitAccess.Name = "ChkLimitAccess"
        Me.ChkLimitAccess.Size = New System.Drawing.Size(204, 16)
        Me.ChkLimitAccess.TabIndex = 5
        Me.ChkLimitAccess.Text = "禁止联系Windows Update获取功能"
        Me.ChkLimitAccess.UseVisualStyleBackColor = True
        '
        'AddFeature
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(511, 297)
        Me.Controls.Add(Me.ChkLimitAccess)
        Me.Controls.Add(Me.ChkAll)
        Me.Controls.Add(Me.BtnAddSource)
        Me.Controls.Add(Me.LBSource)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnRemoveSource)
        Me.Controls.Add(Me.TBFeatureName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddFeature"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "启用功能"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents BtnRemoveSource As System.Windows.Forms.Button
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents TBFeatureName As System.Windows.Forms.TextBox
    Private WithEvents BtnCancel As System.Windows.Forms.Button
    Private WithEvents BtnOK As System.Windows.Forms.Button
    Private WithEvents BtnAddSource As System.Windows.Forms.Button
    Private WithEvents LBSource As System.Windows.Forms.ListBox
    Private WithEvents ChkAll As System.Windows.Forms.CheckBox
    Private WithEvents ChkLimitAccess As System.Windows.Forms.CheckBox
End Class
