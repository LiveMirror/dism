Public Class AddMetroApp

    Public Property Arguments As DismControlEventArgs = Nothing
    Public Property Image As String = ""


    Private Sub BtnRemoveSource_Click(sender As Object, e As EventArgs) Handles BtnRemove.Click
        If DependencyPackagePath.SelectedIndex >= 0 Then DependencyPackagePath.Items.RemoveAt(DependencyPackagePath.SelectedIndex)
    End Sub

    Private Sub BtnAddSource_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Dim cd As New OpenFileDialog()
        cd.Multiselect = True
        cd.Filter = "Metro应用文件(*.appx,*.appxbundle)|*.appx;*.appxbundle"
        If cd.ShowDialog = Windows.Forms.DialogResult.OK Then
            DependencyPackagePath.Items.AddRange(cd.FileNames)
        End If
        cd.Dispose()
        cd = Nothing
    End Sub

    Private Sub RBFolderPath_CheckedChanged(sender As Object, e As EventArgs) Handles RBFolderPath.CheckedChanged
        FolderPath.Enabled = RBFolderPath.Checked
    End Sub

    Private Sub RBPackagePath_CheckedChanged(sender As Object, e As EventArgs) Handles RBPackagePath.CheckedChanged
        GBExport.Enabled = RBPackagePath.Checked
    End Sub

    Private Sub ChkDependencyPackagePath_CheckedChanged(sender As Object, e As EventArgs) Handles ChkDependencyPackagePath.CheckedChanged
        DependencyPackagePath.Enabled = ChkDependencyPackagePath.Checked
        BtnAdd.Enabled = ChkDependencyPackagePath.Checked
        BtnRemove.Enabled = ChkDependencyPackagePath.Checked
        BtnClear.Enabled = ChkDependencyPackagePath.Checked
    End Sub

    Private Sub ChkCustomDataPath_CheckedChanged(sender As Object, e As EventArgs) Handles ChkCustomDataPath.CheckedChanged
        CustomDataPath.Enabled = ChkCustomDataPath.Checked
    End Sub

    Private Sub ChkLicensePath_CheckedChanged(sender As Object, e As EventArgs) Handles ChkLicensePath.CheckedChanged
        LicensePath.Enabled = ChkLicensePath.Checked
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        DependencyPackagePath.Items.Clear()
    End Sub

    Private Sub AddMetroApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RBFolderPath.Checked = DismConfig.GetItem("MetroAppFolderPathSelected", True)
        FolderPath.Text = DismConfig.GetItem("MetroAppFolderPath", "")
        RBPackagePath.Checked = DismConfig.GetItem("MetroAppPackagePathSelected", False)
        PackagePath.Text = DismConfig.GetItem("MetroAppPackagePath", "")
        ChkDependencyPackagePath.Checked = DismConfig.GetItem("MetroAppDependencyPackagePathSelected", False)
        ChkCustomDataPath.Checked = DismConfig.GetItem("MetroAppCustomDataPathSelected", False)
        CustomDataPath.Text = DismConfig.GetItem("MetroAppCustomDataPath", "")
        ChkLicensePath.Checked = DismConfig.GetItem("MetroAppLicensePathSelected", False)
        LicensePath.Text = DismConfig.GetItem("MetroAppLicensePath", "")
        ChkSkipLicense.Checked = DismConfig.GetItem("MetroAppSkipLicense", False)
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Dim Temp As String = ""
        Dim pDir As String = FolderPath.Text.Trim()
        If RBFolderPath.Checked Then
            If Not IO.Directory.Exists(pDir) Then
                MsgBox("Metro应用所在的目录不存在！", MsgBoxStyle.Critical, Me.Text)
                Return
            End If
            Me.Arguments = New DismControlEventArgs With {.Arguments = DismShell.CreateAddMetroPackage(Me.Image, pDir, ChkSkipLicense.Checked)}
            Me.Arguments.Mission = DismMissionFlags.AddProvisionedAppxPackage
            Me.Arguments.Description = "添加Metro应用"
            DismConfig.SetItem("MetroAppFolderPathSelected", RBFolderPath.Checked)
            DismConfig.SetItem("MetroAppFolderPath", pDir)
            DismConfig.SetItem("MetroAppPackagePathSelected", RBPackagePath.Checked)
            DismConfig.Save()
        Else
            Dim pFileName As String = PackagePath.Text.Trim()
            If Not IO.File.Exists(pFileName) Then
                MsgBox("Metro应用文件不存在！", MsgBoxStyle.Critical, Me.Text)
                Return
            End If
            Dim DList() As String = Nothing

            If ChkDependencyPackagePath.Checked Then
                If DependencyPackagePath.Items.Count Then
                    ReDim DList(DependencyPackagePath.Items.Count - 1)
                    DependencyPackagePath.Items.CopyTo(DList, 0)
                End If
            End If
            Dim cDataPath As String = CustomDataPath.Text.Trim
            If Not ChkCustomDataPath.Checked Then cDataPath = ""

            Dim License As String = LicensePath.Text.Trim()
            If Not ChkLicensePath.Checked Then License = ""

            Me.Arguments = New DismControlEventArgs
            Me.Arguments.Mission = DismMissionFlags.AddProvisionedAppxPackage
            Me.Arguments.Arguments = DismShell.CreateAddMetroPackage(Me.Image, pFileName, DList, License, cDataPath, ChkSkipLicense.Checked)
            Me.Arguments.Description = "添加Metro应用"
            DismConfig.SetItem("MetroAppFolderPathSelected", RBFolderPath.Checked)
            DismConfig.SetItem("MetroAppPackagePathSelected", RBPackagePath.Checked)
            DismConfig.SetItem("MetroAppPackagePath", PackagePath.Text.Trim())
            DismConfig.SetItem("MetroAppCustomDataPathSelected", ChkCustomDataPath.Checked)
            DismConfig.SetItem("MetroAppCustomDataPath", CustomDataPath.Text.Trim())
            DismConfig.SetItem("MetroAppLicensePathSelected", ChkLicensePath.Checked)
            DismConfig.SetItem("MetroAppLicensePath", LicensePath.Text.Trim)
            DismConfig.SetItem("MetroAppSkipLicense", ChkSkipLicense.Checked)

            DismConfig.Save()
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class