Public Class AddFeature

    Private mArguments As String = ""

    Public Property FeatureName As String
        Get
            Return TBFeatureName.Text.Trim
        End Get
        Set(value As String)
            TBFeatureName.Text = value
        End Set
    End Property

    Public ReadOnly Property Arguments As String
        Get
            Return mArguments
        End Get
    End Property

    Public Property Image As String = ""

    Private Sub BtnRemoveSource_Click(sender As Object, e As EventArgs) Handles BtnRemoveSource.Click
        If LBSource.SelectedIndex > -1 Then
            LBSource.Items.RemoveAt(LBSource.SelectedIndex)
        End If
    End Sub

    Private Sub BtnAddSource_Click(sender As Object, e As EventArgs) Handles BtnAddSource.Click
        Dim Temp As String = DismConfig.GetItem("FeatureSource", "")
        Dim cd As New FolderBrowserDialog
        If IO.Directory.Exists(Temp) Then cd.SelectedPath = Temp
        If cd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Temp = cd.SelectedPath
            If Not Exists(Temp) Then
                LBSource.Items.Add(Temp)
                DismConfig.SetItem("FeatureSource", Temp)
                DismConfig.Save()
            End If
        End If
        cd.Dispose()
        cd = Nothing
    End Sub

    Private Function Exists(Text As String) As Boolean
        For Each Item As String In LBSource.Items
            If String.Compare(Item, Text, True) = 0 Then Return True
        Next
        Return False
    End Function

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Dim fn As String = TBFeatureName.Text.Trim()
        If fn = "" Then
            MsgBox("功能名称不能为空！", MsgBoxStyle.Critical, Me.Text)
            Return
        End If
        Dim SourceList() As String = Nothing
        If LBSource.Items.Count Then
            ReDim SourceList(LBSource.Items.Count - 1)
            LBSource.Items.CopyTo(SourceList, 0)
        End If
        mArguments = DismShell.CreateEnableFeatureArguments(Image, fn, SourceList, ChkAll.Checked, ChkLimitAccess.Checked)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

End Class