<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileDialog
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CBExtension = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.CBFileName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FTV = New DismGuiPE.FolderTreeView()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.FDG = New DismGuiPE.FileDataGridView()

        Me.Panel1.SuspendLayout()
        CType(Me.FDG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CBExtension)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.BtnCancel)
        Me.Panel1.Controls.Add(Me.BtnOK)
        Me.Panel1.Controls.Add(Me.CBFileName)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 375)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(784, 64)
        Me.Panel1.TabIndex = 0
        '
        'CBExtension
        '
        Me.CBExtension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBExtension.FormattingEnabled = True
        Me.CBExtension.Location = New System.Drawing.Point(78, 36)
        Me.CBExtension.Name = "CBExtension"
        Me.CBExtension.Size = New System.Drawing.Size(480, 20)
        Me.CBExtension.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "文件类型："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(672, 24)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(100, 32)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "取消"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(564, 23)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(100, 32)
        Me.BtnOK.TabIndex = 3
        Me.BtnOK.Text = "打开"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'CBFileName
        '
        Me.CBFileName.FormattingEnabled = True
        Me.CBFileName.Location = New System.Drawing.Point(78, 7)
        Me.CBFileName.Name = "CBFileName"
        Me.CBFileName.Size = New System.Drawing.Size(480, 20)
        Me.CBFileName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "文件名："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FTV
        '
        Me.FTV.Dock = System.Windows.Forms.DockStyle.Left
        Me.FTV.HideSelection = False
        Me.FTV.ImageIndex = 0
        Me.FTV.Location = New System.Drawing.Point(0, 0)
        Me.FTV.Name = "FTV"
        Me.FTV.SelectedImageIndex = 0
        Me.FTV.SelectedPath = ""
        Me.FTV.Size = New System.Drawing.Size(231, 375)
        Me.FTV.TabIndex = 1
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(231, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(4, 375)
        Me.Splitter1.TabIndex = 2
        Me.Splitter1.TabStop = False
        '
        'FDG
        '
        Me.FDG.AllowUserToAddRows = False
        Me.FDG.AllowUserToDeleteRows = False
        Me.FDG.AllowUserToResizeColumns = False
        Me.FDG.AllowUserToResizeRows = False
        Me.FDG.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.FDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FDG.Directory = ""
        Me.FDG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FDG.Filter = "所有文件（*.*）|*.*"
        Me.FDG.FilterIndex = 0
        Me.FDG.Location = New System.Drawing.Point(235, 0)
        Me.FDG.MultiSelect = False
        Me.FDG.Name = "FDG"
        Me.FDG.ReadOnly = True
        Me.FDG.RowHeadersVisible = False
        Me.FDG.RowHeadersWidth = 21
        Me.FDG.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.FDG.RowTemplate.Height = 23
        Me.FDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.FDG.Size = New System.Drawing.Size(549, 375)
        Me.FDG.TabIndex = 3
        '

        '
        'FileDialog
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(784, 439)
        Me.Controls.Add(Me.FDG)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.FTV)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FileDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "浏览文件对话框"
        Me.Panel1.ResumeLayout(False)
        CType(Me.FDG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents FTV As FolderTreeView
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents FDG As FileDataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CBFileName As System.Windows.Forms.ComboBox
    Friend WithEvents CBExtension As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label


End Class
