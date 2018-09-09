<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.PDISM_Features = New System.Windows.Forms.Panel()
        Me.PDISM_Buffer = New System.Windows.Forms.Panel()
        Me.FSScratchDir = New DismGui.FileOrFolderSelector()
        Me.ChkScratchDirActived = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDriveFreeSpace = New System.Windows.Forms.Label()
        Me.BtnScratchDirDefault = New System.Windows.Forms.Button()
        Me.lblDriveAlert = New System.Windows.Forms.Label()
        Me.PDISM_Parameters = New System.Windows.Forms.Panel()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.PDISM_Progress = New System.Windows.Forms.Panel()
        Me.PBProc = New System.Windows.Forms.ProgressBar()
        Me.lblProc = New System.Windows.Forms.Label()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.TBDISM_Output = New System.Windows.Forms.TextBox()
        Me.PDISM_Buffer.SuspendLayout()
        Me.PDISM_Progress.SuspendLayout()
        Me.SuspendLayout()
        '
        'PDISM_Features
        '
        Me.PDISM_Features.AutoScroll = True
        Me.PDISM_Features.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.PDISM_Features.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PDISM_Features.Dock = System.Windows.Forms.DockStyle.Left
        Me.PDISM_Features.Location = New System.Drawing.Point(0, 0)
        Me.PDISM_Features.Name = "PDISM_Features"
        Me.PDISM_Features.Size = New System.Drawing.Size(146, 591)
        Me.PDISM_Features.TabIndex = 2
        '
        'PDISM_Buffer
        '
        Me.PDISM_Buffer.BackColor = System.Drawing.Color.Khaki
        Me.PDISM_Buffer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PDISM_Buffer.Controls.Add(Me.FSScratchDir)
        Me.PDISM_Buffer.Controls.Add(Me.ChkScratchDirActived)
        Me.PDISM_Buffer.Controls.Add(Me.Label1)
        Me.PDISM_Buffer.Controls.Add(Me.lblDriveFreeSpace)
        Me.PDISM_Buffer.Controls.Add(Me.BtnScratchDirDefault)
        Me.PDISM_Buffer.Controls.Add(Me.lblDriveAlert)
        Me.PDISM_Buffer.Dock = System.Windows.Forms.DockStyle.Top
        Me.PDISM_Buffer.Location = New System.Drawing.Point(146, 0)
        Me.PDISM_Buffer.Name = "PDISM_Buffer"
        Me.PDISM_Buffer.Size = New System.Drawing.Size(638, 59)
        Me.PDISM_Buffer.TabIndex = 7
        '
        'FSScratchDir
        '
        Me.FSScratchDir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FSScratchDir.BrowserStyle = DismGui.FileOrFolderBrowserStyle.Folder
        Me.FSScratchDir.CheckFileExists = True
        Me.FSScratchDir.CheckPathExists = True
        Me.FSScratchDir.Filter = ""
        Me.FSScratchDir.Location = New System.Drawing.Point(113, 4)
        Me.FSScratchDir.Multiselect = False
        Me.FSScratchDir.Name = "FSScratchDir"
        Me.FSScratchDir.OverwritePrompt = True
        Me.FSScratchDir.ReadOnly = True
        Me.FSScratchDir.Size = New System.Drawing.Size(455, 24)
        Me.FSScratchDir.TabIndex = 1
        '
        'ChkScratchDirActived
        '
        Me.ChkScratchDirActived.AutoSize = True
        Me.ChkScratchDirActived.Location = New System.Drawing.Point(13, 9)
        Me.ChkScratchDirActived.Name = "ChkScratchDirActived"
        Me.ChkScratchDirActived.Size = New System.Drawing.Size(108, 16)
        Me.ChkScratchDirActived.TabIndex = 7
        Me.ChkScratchDirActived.Text = "指定暂存目录："
        Me.ChkScratchDirActived.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "所在驱动器剩余空间："
        '
        'lblDriveFreeSpace
        '
        Me.lblDriveFreeSpace.AutoSize = True
        Me.lblDriveFreeSpace.Location = New System.Drawing.Point(155, 36)
        Me.lblDriveFreeSpace.Name = "lblDriveFreeSpace"
        Me.lblDriveFreeSpace.Size = New System.Drawing.Size(0, 12)
        Me.lblDriveFreeSpace.TabIndex = 2
        '
        'BtnScratchDirDefault
        '
        Me.BtnScratchDirDefault.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnScratchDirDefault.Location = New System.Drawing.Point(574, 4)
        Me.BtnScratchDirDefault.Name = "BtnScratchDirDefault"
        Me.BtnScratchDirDefault.Size = New System.Drawing.Size(50, 24)
        Me.BtnScratchDirDefault.TabIndex = 4
        Me.BtnScratchDirDefault.Text = "默认"
        Me.BtnScratchDirDefault.UseVisualStyleBackColor = True
        '
        'lblDriveAlert
        '
        Me.lblDriveAlert.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDriveAlert.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblDriveAlert.ForeColor = System.Drawing.Color.Red
        Me.lblDriveAlert.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblDriveAlert.Location = New System.Drawing.Point(356, 36)
        Me.lblDriveAlert.Name = "lblDriveAlert"
        Me.lblDriveAlert.Size = New System.Drawing.Size(275, 12)
        Me.lblDriveAlert.TabIndex = 6
        Me.lblDriveAlert.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PDISM_Parameters
        '
        Me.PDISM_Parameters.BackColor = System.Drawing.SystemColors.Control
        Me.PDISM_Parameters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PDISM_Parameters.Dock = System.Windows.Forms.DockStyle.Top
        Me.PDISM_Parameters.Location = New System.Drawing.Point(146, 59)
        Me.PDISM_Parameters.MinimumSize = New System.Drawing.Size(4, 316)
        Me.PDISM_Parameters.Name = "PDISM_Parameters"
        Me.PDISM_Parameters.Size = New System.Drawing.Size(638, 316)
        Me.PDISM_Parameters.TabIndex = 8
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(146, 375)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(638, 6)
        Me.Splitter1.TabIndex = 9
        Me.Splitter1.TabStop = False
        '
        'PDISM_Progress
        '
        Me.PDISM_Progress.Controls.Add(Me.PBProc)
        Me.PDISM_Progress.Controls.Add(Me.lblProc)
        Me.PDISM_Progress.Controls.Add(Me.BtnClear)
        Me.PDISM_Progress.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PDISM_Progress.Location = New System.Drawing.Point(146, 559)
        Me.PDISM_Progress.Name = "PDISM_Progress"
        Me.PDISM_Progress.Size = New System.Drawing.Size(638, 32)
        Me.PDISM_Progress.TabIndex = 10
        '
        'PBProc
        '
        Me.PBProc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PBProc.Location = New System.Drawing.Point(0, 0)
        Me.PBProc.MarqueeAnimationSpeed = 20
        Me.PBProc.Maximum = 1000
        Me.PBProc.Name = "PBProc"
        Me.PBProc.Size = New System.Drawing.Size(525, 32)
        Me.PBProc.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.PBProc.TabIndex = 0
        '
        'lblProc
        '
        Me.lblProc.BackColor = System.Drawing.Color.LightSkyBlue
        Me.lblProc.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblProc.Location = New System.Drawing.Point(525, 0)
        Me.lblProc.Name = "lblProc"
        Me.lblProc.Size = New System.Drawing.Size(43, 32)
        Me.lblProc.TabIndex = 1
        Me.lblProc.Text = "100%"
        Me.lblProc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblProc.Visible = False
        '
        'BtnClear
        '
        Me.BtnClear.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClear.Location = New System.Drawing.Point(568, 0)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(70, 32)
        Me.BtnClear.TabIndex = 2
        Me.BtnClear.Text = "清除显示"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'TBDISM_Output
        '
        Me.TBDISM_Output.BackColor = System.Drawing.Color.Black
        Me.TBDISM_Output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBDISM_Output.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TBDISM_Output.ForeColor = System.Drawing.Color.Lime
        Me.TBDISM_Output.Location = New System.Drawing.Point(146, 381)
        Me.TBDISM_Output.MaxLength = 2147483647
        Me.TBDISM_Output.Multiline = True
        Me.TBDISM_Output.Name = "TBDISM_Output"
        Me.TBDISM_Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TBDISM_Output.Size = New System.Drawing.Size(638, 178)
        Me.TBDISM_Output.TabIndex = 11
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 591)
        Me.Controls.Add(Me.TBDISM_Output)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.PDISM_Parameters)
        Me.Controls.Add(Me.PDISM_Buffer)
        Me.Controls.Add(Me.PDISM_Progress)
        Me.Controls.Add(Me.PDISM_Features)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 630)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DISM图像界面"
        Me.PDISM_Buffer.ResumeLayout(False)
        Me.PDISM_Buffer.PerformLayout()
        Me.PDISM_Progress.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PDISM_Features As System.Windows.Forms.Panel
    Friend WithEvents PDISM_Buffer As System.Windows.Forms.Panel
    Friend WithEvents PDISM_Parameters As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents PDISM_Progress As System.Windows.Forms.Panel
    Friend WithEvents PBProc As System.Windows.Forms.ProgressBar
    Friend WithEvents BtnClear As System.Windows.Forms.Button
    Friend WithEvents lblProc As System.Windows.Forms.Label
    Friend WithEvents TBDISM_Output As System.Windows.Forms.TextBox
    Friend WithEvents FSScratchDir As DismGui.FileOrFolderSelector
    Friend WithEvents lblDriveFreeSpace As System.Windows.Forms.Label
    Friend WithEvents BtnScratchDirDefault As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblDriveAlert As System.Windows.Forms.Label
    Friend WithEvents ChkScratchDirActived As System.Windows.Forms.CheckBox

End Class
