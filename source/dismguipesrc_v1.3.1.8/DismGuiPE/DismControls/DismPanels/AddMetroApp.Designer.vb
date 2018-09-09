<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddMetroApp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddMetroApp))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ChkSkipLicense = New System.Windows.Forms.CheckBox()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.RBFolderPath = New System.Windows.Forms.RadioButton()
        Me.RBPackagePath = New System.Windows.Forms.RadioButton()
        Me.GBExport = New System.Windows.Forms.GroupBox()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.ChkLicensePath = New System.Windows.Forms.CheckBox()
        Me.ChkCustomDataPath = New System.Windows.Forms.CheckBox()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.DependencyPackagePath = New System.Windows.Forms.ListBox()
        Me.BtnRemove = New System.Windows.Forms.Button()
        Me.ChkDependencyPackagePath = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TT = New System.Windows.Forms.ToolTip(Me.components)
        Me.LicensePath = New DismGuiPE.FileOrFolderSelector()
        Me.CustomDataPath = New DismGuiPE.FileOrFolderSelector()
        Me.PackagePath = New DismGuiPE.FileOrFolderSelector()
        Me.FolderPath = New DismGuiPE.FileOrFolderSelector()
        Me.Panel1.SuspendLayout()
        Me.GBExport.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ChkSkipLicense)
        Me.Panel1.Controls.Add(Me.BtnCancel)
        Me.Panel1.Controls.Add(Me.BtnOK)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 329)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(530, 39)
        Me.Panel1.TabIndex = 1
        '
        'ChkSkipLicense
        '
        Me.ChkSkipLicense.AutoSize = True
        Me.ChkSkipLicense.Location = New System.Drawing.Point(26, 11)
        Me.ChkSkipLicense.Name = "ChkSkipLicense"
        Me.ChkSkipLicense.Size = New System.Drawing.Size(210, 16)
        Me.ChkSkipLicense.TabIndex = 18
        Me.ChkSkipLicense.Text = "/SkipLicense (忽略应用许可信息)"
        Me.ChkSkipLicense.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(429, 6)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(80, 28)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "取消"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(343, 6)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(80, 28)
        Me.BtnOK.TabIndex = 0
        Me.BtnOK.Text = "确定"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'RBFolderPath
        '
        Me.RBFolderPath.AutoSize = True
        Me.RBFolderPath.Checked = True
        Me.RBFolderPath.Location = New System.Drawing.Point(14, 12)
        Me.RBFolderPath.Name = "RBFolderPath"
        Me.RBFolderPath.Size = New System.Drawing.Size(89, 16)
        Me.RBFolderPath.TabIndex = 8
        Me.RBFolderPath.TabStop = True
        Me.RBFolderPath.Text = "指定文件夹:"
        Me.TT.SetToolTip(Me.RBFolderPath, "/FolderPath 包含主要应用包(.appx)和任何相关程序包的解包程序包文件以及许可证文件的文件夹。")
        Me.RBFolderPath.UseVisualStyleBackColor = True
        '
        'RBPackagePath
        '
        Me.RBPackagePath.AutoSize = True
        Me.RBPackagePath.Location = New System.Drawing.Point(14, 41)
        Me.RBPackagePath.Name = "RBPackagePath"
        Me.RBPackagePath.Size = New System.Drawing.Size(77, 16)
        Me.RBPackagePath.TabIndex = 10
        Me.RBPackagePath.Text = "指定文件:"
        Me.TT.SetToolTip(Me.RBPackagePath, "/PackagePath 指定 .appx 或 .appxbundle 文件。")
        Me.RBPackagePath.UseVisualStyleBackColor = True
        '
        'GBExport
        '
        Me.GBExport.Controls.Add(Me.BtnClear)
        Me.GBExport.Controls.Add(Me.LicensePath)
        Me.GBExport.Controls.Add(Me.CustomDataPath)
        Me.GBExport.Controls.Add(Me.ChkLicensePath)
        Me.GBExport.Controls.Add(Me.ChkCustomDataPath)
        Me.GBExport.Controls.Add(Me.BtnAdd)
        Me.GBExport.Controls.Add(Me.DependencyPackagePath)
        Me.GBExport.Controls.Add(Me.BtnRemove)
        Me.GBExport.Controls.Add(Me.ChkDependencyPackagePath)
        Me.GBExport.Controls.Add(Me.Label1)
        Me.GBExport.Controls.Add(Me.PackagePath)
        Me.GBExport.Enabled = False
        Me.GBExport.Location = New System.Drawing.Point(14, 44)
        Me.GBExport.Name = "GBExport"
        Me.GBExport.Size = New System.Drawing.Size(504, 279)
        Me.GBExport.TabIndex = 11
        Me.GBExport.TabStop = False
        '
        'BtnClear
        '
        Me.BtnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClear.Enabled = False
        Me.BtnClear.Location = New System.Drawing.Point(327, 52)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(52, 25)
        Me.BtnClear.TabIndex = 20
        Me.BtnClear.Text = "清除"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'ChkLicensePath
        '
        Me.ChkLicensePath.AutoSize = True
        Me.ChkLicensePath.Location = New System.Drawing.Point(12, 247)
        Me.ChkLicensePath.Name = "ChkLicensePath"
        Me.ChkLicensePath.Size = New System.Drawing.Size(102, 16)
        Me.ChkLicensePath.TabIndex = 17
        Me.ChkLicensePath.Text = "/LicensePath:"
        Me.TT.SetToolTip(Me.ChkLicensePath, "指定包含应用程序许可证的 .xml 文件的位置。")
        Me.ChkLicensePath.UseVisualStyleBackColor = True
        '
        'ChkCustomDataPath
        '
        Me.ChkCustomDataPath.AutoSize = True
        Me.ChkCustomDataPath.Location = New System.Drawing.Point(12, 219)
        Me.ChkCustomDataPath.Name = "ChkCustomDataPath"
        Me.ChkCustomDataPath.Size = New System.Drawing.Size(120, 16)
        Me.ChkCustomDataPath.TabIndex = 16
        Me.ChkCustomDataPath.Text = "/CustomDataPath:"
        Me.TT.SetToolTip(Me.ChkCustomDataPath, "应用程序的 OEM 自定义数据。")
        Me.ChkCustomDataPath.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAdd.Enabled = False
        Me.BtnAdd.Location = New System.Drawing.Point(443, 52)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(52, 25)
        Me.BtnAdd.TabIndex = 14
        Me.BtnAdd.Text = "添加"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'DependencyPackagePath
        '
        Me.DependencyPackagePath.Enabled = False
        Me.DependencyPackagePath.FormattingEnabled = True
        Me.DependencyPackagePath.ItemHeight = 12
        Me.DependencyPackagePath.Location = New System.Drawing.Point(12, 79)
        Me.DependencyPackagePath.Name = "DependencyPackagePath"
        Me.DependencyPackagePath.Size = New System.Drawing.Size(483, 124)
        Me.DependencyPackagePath.TabIndex = 15
        '
        'BtnRemove
        '
        Me.BtnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRemove.Enabled = False
        Me.BtnRemove.Location = New System.Drawing.Point(385, 52)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New System.Drawing.Size(52, 25)
        Me.BtnRemove.TabIndex = 13
        Me.BtnRemove.Text = "删除"
        Me.BtnRemove.UseVisualStyleBackColor = True
        '
        'ChkDependencyPackagePath
        '
        Me.ChkDependencyPackagePath.AutoSize = True
        Me.ChkDependencyPackagePath.Location = New System.Drawing.Point(12, 57)
        Me.ChkDependencyPackagePath.Name = "ChkDependencyPackagePath"
        Me.ChkDependencyPackagePath.Size = New System.Drawing.Size(162, 16)
        Me.ChkDependencyPackagePath.TabIndex = 12
        Me.ChkDependencyPackagePath.Text = "/DependencyPackagePath:"
        Me.TT.SetToolTip(Me.ChkDependencyPackagePath, "依赖程序包路径。")
        Me.ChkDependencyPackagePath.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 12)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "/PackagePath:"
        Me.TT.SetToolTip(Me.Label1, ".appx 或 .appxbundle 文件路径。")
        '
        'TT
        '
        Me.TT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TT.ToolTipTitle = "添加Metro应用"
        '
        'LicensePath
        '
        Me.LicensePath.BrowserStyle = DismGuiPE.FileOrFolderBrowserStyle.FileOpen
        Me.LicensePath.CheckFileExists = True
        Me.LicensePath.CheckPathExists = True
        Me.LicensePath.Enabled = False
        Me.LicensePath.Filter = "Metro应用许可文件(*.xml)|*.xml"
        Me.LicensePath.Location = New System.Drawing.Point(138, 247)
        Me.LicensePath.Multiselect = False
        Me.LicensePath.Name = "LicensePath"
        Me.LicensePath.OverwritePrompt = True
        Me.LicensePath.ReadOnly = True
        Me.LicensePath.Size = New System.Drawing.Size(357, 22)
        Me.LicensePath.TabIndex = 19
        '
        'CustomDataPath
        '
        Me.CustomDataPath.BrowserStyle = DismGuiPE.FileOrFolderBrowserStyle.FileOpen
        Me.CustomDataPath.CheckFileExists = True
        Me.CustomDataPath.CheckPathExists = True
        Me.CustomDataPath.Enabled = False
        Me.CustomDataPath.Filter = "Metro数据文件(*.Dat)|*.Dat"
        Me.CustomDataPath.Location = New System.Drawing.Point(138, 219)
        Me.CustomDataPath.Multiselect = False
        Me.CustomDataPath.Name = "CustomDataPath"
        Me.CustomDataPath.OverwritePrompt = True
        Me.CustomDataPath.ReadOnly = True
        Me.CustomDataPath.Size = New System.Drawing.Size(357, 22)
        Me.CustomDataPath.TabIndex = 18
        '
        'PackagePath
        '
        Me.PackagePath.BrowserStyle = DismGuiPE.FileOrFolderBrowserStyle.FileOpen
        Me.PackagePath.CheckFileExists = True
        Me.PackagePath.CheckPathExists = True
        Me.PackagePath.Filter = "Metro应用文件(*.appx,*.appxbundle)|*.appx;*.appxbundle"
        Me.PackagePath.Location = New System.Drawing.Point(96, 20)
        Me.PackagePath.Multiselect = False
        Me.PackagePath.Name = "PackagePath"
        Me.PackagePath.OverwritePrompt = True
        Me.PackagePath.ReadOnly = True
        Me.PackagePath.Size = New System.Drawing.Size(399, 22)
        Me.PackagePath.TabIndex = 10
        '
        'FolderPath
        '
        Me.FolderPath.BrowserStyle = DismGuiPE.FileOrFolderBrowserStyle.Folder
        Me.FolderPath.CheckFileExists = True
        Me.FolderPath.CheckPathExists = True
        Me.FolderPath.Filter = ""
        Me.FolderPath.Location = New System.Drawing.Point(106, 12)
        Me.FolderPath.Multiselect = False
        Me.FolderPath.Name = "FolderPath"
        Me.FolderPath.OverwritePrompt = True
        Me.FolderPath.ReadOnly = True
        Me.FolderPath.Size = New System.Drawing.Size(403, 22)
        Me.FolderPath.TabIndex = 9
        '
        'AddMetroApp
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(530, 368)
        Me.Controls.Add(Me.RBPackagePath)
        Me.Controls.Add(Me.GBExport)
        Me.Controls.Add(Me.FolderPath)
        Me.Controls.Add(Me.RBFolderPath)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddMetroApp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "添加Metro应用"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GBExport.ResumeLayout(False)
        Me.GBExport.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents RBFolderPath As System.Windows.Forms.RadioButton
    Friend WithEvents FolderPath As DismGuiPE.FileOrFolderSelector
    Friend WithEvents RBPackagePath As System.Windows.Forms.RadioButton
    Friend WithEvents GBExport As System.Windows.Forms.GroupBox
    Friend WithEvents PackagePath As DismGuiPE.FileOrFolderSelector
    Friend WithEvents ChkDependencyPackagePath As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents BtnAdd As System.Windows.Forms.Button
    Private WithEvents DependencyPackagePath As System.Windows.Forms.ListBox
    Private WithEvents BtnRemove As System.Windows.Forms.Button
    Friend WithEvents LicensePath As DismGuiPE.FileOrFolderSelector
    Friend WithEvents CustomDataPath As DismGuiPE.FileOrFolderSelector
    Friend WithEvents ChkLicensePath As System.Windows.Forms.CheckBox
    Friend WithEvents ChkCustomDataPath As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSkipLicense As System.Windows.Forms.CheckBox
    Private WithEvents BtnClear As System.Windows.Forms.Button
    Friend WithEvents TT As System.Windows.Forms.ToolTip
End Class
