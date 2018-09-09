<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExclusionEditor
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExclusionEditor))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TVDirectory = New System.Windows.Forms.TreeView()
        Me.LBExclusionList = New System.Windows.Forms.ListBox()
        Me.LBExceptionList = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LBCompressList = New System.Windows.Forms.ListBox()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.BtnExclusionAdd = New System.Windows.Forms.Button()
        Me.BtnExclusionAddExt = New System.Windows.Forms.Button()
        Me.BtnExceptionAddExt = New System.Windows.Forms.Button()
        Me.BtnCompressAddExt = New System.Windows.Forms.Button()
        Me.BtnExclusionRemove = New System.Windows.Forms.Button()
        Me.BtnExclusionClear = New System.Windows.Forms.Button()
        Me.BtnExceptionAdd = New System.Windows.Forms.Button()
        Me.BtnExceptionRemove = New System.Windows.Forms.Button()
        Me.BtnExceptionClear = New System.Windows.Forms.Button()
        Me.BtnCompressAdd = New System.Windows.Forms.Button()
        Me.BtnCompressRemove = New System.Windows.Forms.Button()
        Me.BtnCompressClear = New System.Windows.Forms.Button()
        Me.TT = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(326, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "排除项："
        '
        'TVDirectory
        '
        Me.TVDirectory.Location = New System.Drawing.Point(12, 29)
        Me.TVDirectory.Name = "TVDirectory"
        Me.TVDirectory.Size = New System.Drawing.Size(280, 432)
        Me.TVDirectory.TabIndex = 0
        '
        'LBExclusionList
        '
        Me.LBExclusionList.FormattingEnabled = True
        Me.LBExclusionList.ItemHeight = 12
        Me.LBExclusionList.Location = New System.Drawing.Point(328, 29)
        Me.LBExclusionList.Name = "LBExclusionList"
        Me.LBExclusionList.Size = New System.Drawing.Size(337, 172)
        Me.LBExclusionList.TabIndex = 5
        '
        'LBExceptionList
        '
        Me.LBExceptionList.FormattingEnabled = True
        Me.LBExceptionList.ItemHeight = 12
        Me.LBExceptionList.Location = New System.Drawing.Point(328, 231)
        Me.LBExceptionList.Name = "LBExceptionList"
        Me.LBExceptionList.Size = New System.Drawing.Size(337, 100)
        Me.LBExceptionList.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(328, 216)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "代替默认排除列表项："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(328, 346)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "压缩排除项："
        '
        'LBCompressList
        '
        Me.LBCompressList.FormattingEnabled = True
        Me.LBCompressList.ItemHeight = 12
        Me.LBCompressList.Location = New System.Drawing.Point(328, 361)
        Me.LBCompressList.Name = "LBCompressList"
        Me.LBCompressList.Size = New System.Drawing.Size(337, 100)
        Me.LBCompressList.TabIndex = 15
        '
        'lblPath
        '
        Me.lblPath.Location = New System.Drawing.Point(15, 15)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(276, 14)
        Me.lblPath.TabIndex = 7
        '
        'BtnExclusionAdd
        '
        Me.BtnExclusionAdd.Location = New System.Drawing.Point(294, 32)
        Me.BtnExclusionAdd.Name = "BtnExclusionAdd"
        Me.BtnExclusionAdd.Size = New System.Drawing.Size(32, 24)
        Me.BtnExclusionAdd.TabIndex = 1
        Me.BtnExclusionAdd.Text = ">>"
        Me.BtnExclusionAdd.UseVisualStyleBackColor = True
        '
        'BtnExclusionAddExt
        '
        Me.BtnExclusionAddExt.Location = New System.Drawing.Point(646, 9)
        Me.BtnExclusionAddExt.Name = "BtnExclusionAddExt"
        Me.BtnExclusionAddExt.Size = New System.Drawing.Size(20, 20)
        Me.BtnExclusionAddExt.TabIndex = 4
        Me.BtnExclusionAddExt.Text = "+"
        Me.BtnExclusionAddExt.UseVisualStyleBackColor = True
        '
        'BtnExceptionAddExt
        '
        Me.BtnExceptionAddExt.Location = New System.Drawing.Point(646, 211)
        Me.BtnExceptionAddExt.Name = "BtnExceptionAddExt"
        Me.BtnExceptionAddExt.Size = New System.Drawing.Size(20, 20)
        Me.BtnExceptionAddExt.TabIndex = 9
        Me.BtnExceptionAddExt.Text = "+"
        Me.BtnExceptionAddExt.UseVisualStyleBackColor = True
        '
        'BtnCompressAddExt
        '
        Me.BtnCompressAddExt.Location = New System.Drawing.Point(646, 341)
        Me.BtnCompressAddExt.Name = "BtnCompressAddExt"
        Me.BtnCompressAddExt.Size = New System.Drawing.Size(20, 20)
        Me.BtnCompressAddExt.TabIndex = 14
        Me.BtnCompressAddExt.Text = "+"
        Me.BtnCompressAddExt.UseVisualStyleBackColor = True
        '
        'BtnExclusionRemove
        '
        Me.BtnExclusionRemove.Location = New System.Drawing.Point(294, 62)
        Me.BtnExclusionRemove.Name = "BtnExclusionRemove"
        Me.BtnExclusionRemove.Size = New System.Drawing.Size(32, 24)
        Me.BtnExclusionRemove.TabIndex = 2
        Me.BtnExclusionRemove.Text = "<<"
        Me.BtnExclusionRemove.UseVisualStyleBackColor = True
        '
        'BtnExclusionClear
        '
        Me.BtnExclusionClear.Location = New System.Drawing.Point(294, 92)
        Me.BtnExclusionClear.Name = "BtnExclusionClear"
        Me.BtnExclusionClear.Size = New System.Drawing.Size(32, 24)
        Me.BtnExclusionClear.TabIndex = 3
        Me.BtnExclusionClear.Text = "C"
        Me.BtnExclusionClear.UseVisualStyleBackColor = True
        '
        'BtnExceptionAdd
        '
        Me.BtnExceptionAdd.Location = New System.Drawing.Point(294, 231)
        Me.BtnExceptionAdd.Name = "BtnExceptionAdd"
        Me.BtnExceptionAdd.Size = New System.Drawing.Size(32, 24)
        Me.BtnExceptionAdd.TabIndex = 6
        Me.BtnExceptionAdd.Text = ">>"
        Me.BtnExceptionAdd.UseVisualStyleBackColor = True
        '
        'BtnExceptionRemove
        '
        Me.BtnExceptionRemove.Location = New System.Drawing.Point(294, 261)
        Me.BtnExceptionRemove.Name = "BtnExceptionRemove"
        Me.BtnExceptionRemove.Size = New System.Drawing.Size(32, 24)
        Me.BtnExceptionRemove.TabIndex = 7
        Me.BtnExceptionRemove.Text = "<<"
        Me.BtnExceptionRemove.UseVisualStyleBackColor = True
        '
        'BtnExceptionClear
        '
        Me.BtnExceptionClear.Location = New System.Drawing.Point(294, 291)
        Me.BtnExceptionClear.Name = "BtnExceptionClear"
        Me.BtnExceptionClear.Size = New System.Drawing.Size(32, 24)
        Me.BtnExceptionClear.TabIndex = 8
        Me.BtnExceptionClear.Text = "C"
        Me.BtnExceptionClear.UseVisualStyleBackColor = True
        '
        'BtnCompressAdd
        '
        Me.BtnCompressAdd.Location = New System.Drawing.Point(294, 361)
        Me.BtnCompressAdd.Name = "BtnCompressAdd"
        Me.BtnCompressAdd.Size = New System.Drawing.Size(32, 24)
        Me.BtnCompressAdd.TabIndex = 11
        Me.BtnCompressAdd.Text = ">>"
        Me.BtnCompressAdd.UseVisualStyleBackColor = True
        '
        'BtnCompressRemove
        '
        Me.BtnCompressRemove.Location = New System.Drawing.Point(294, 391)
        Me.BtnCompressRemove.Name = "BtnCompressRemove"
        Me.BtnCompressRemove.Size = New System.Drawing.Size(32, 24)
        Me.BtnCompressRemove.TabIndex = 12
        Me.BtnCompressRemove.Text = "<<"
        Me.BtnCompressRemove.UseVisualStyleBackColor = True
        '
        'BtnCompressClear
        '
        Me.BtnCompressClear.Location = New System.Drawing.Point(294, 421)
        Me.BtnCompressClear.Name = "BtnCompressClear"
        Me.BtnCompressClear.Size = New System.Drawing.Size(32, 24)
        Me.BtnCompressClear.TabIndex = 13
        Me.BtnCompressClear.Text = "C"
        Me.BtnCompressClear.UseVisualStyleBackColor = True
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(584, 467)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(80, 28)
        Me.BtnOK.TabIndex = 16
        Me.BtnOK.Text = "确定"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'ExclusionEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 502)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCompressClear)
        Me.Controls.Add(Me.BtnCompressRemove)
        Me.Controls.Add(Me.BtnCompressAdd)
        Me.Controls.Add(Me.BtnExceptionClear)
        Me.Controls.Add(Me.BtnExceptionRemove)
        Me.Controls.Add(Me.BtnExceptionAdd)
        Me.Controls.Add(Me.BtnExclusionClear)
        Me.Controls.Add(Me.BtnExclusionRemove)
        Me.Controls.Add(Me.BtnCompressAddExt)
        Me.Controls.Add(Me.BtnExceptionAddExt)
        Me.Controls.Add(Me.BtnExclusionAddExt)
        Me.Controls.Add(Me.BtnExclusionAdd)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.LBCompressList)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LBExceptionList)
        Me.Controls.Add(Me.LBExclusionList)
        Me.Controls.Add(Me.TVDirectory)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ExclusionEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "排除项"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TVDirectory As System.Windows.Forms.TreeView
    Friend WithEvents LBExclusionList As System.Windows.Forms.ListBox
    Friend WithEvents LBExceptionList As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LBCompressList As System.Windows.Forms.ListBox
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents BtnExclusionAdd As System.Windows.Forms.Button
    Friend WithEvents BtnExclusionAddExt As System.Windows.Forms.Button
    Friend WithEvents BtnExceptionAddExt As System.Windows.Forms.Button
    Friend WithEvents BtnCompressAddExt As System.Windows.Forms.Button
    Friend WithEvents BtnExclusionRemove As System.Windows.Forms.Button
    Friend WithEvents BtnExclusionClear As System.Windows.Forms.Button
    Friend WithEvents BtnExceptionAdd As System.Windows.Forms.Button
    Friend WithEvents BtnExceptionRemove As System.Windows.Forms.Button
    Friend WithEvents BtnExceptionClear As System.Windows.Forms.Button
    Friend WithEvents BtnCompressAdd As System.Windows.Forms.Button
    Friend WithEvents BtnCompressRemove As System.Windows.Forms.Button
    Friend WithEvents BtnCompressClear As System.Windows.Forms.Button
    Friend WithEvents TT As System.Windows.Forms.ToolTip
    Friend WithEvents BtnOK As System.Windows.Forms.Button
End Class
