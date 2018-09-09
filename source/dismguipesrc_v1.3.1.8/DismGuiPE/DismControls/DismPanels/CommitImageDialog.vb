﻿Public Class CommitImageDialog

    Public Property Commit As DismCommitFlags = DismCommitFlags.Cancel

    Private Sub BtnAppend_Click(sender As Object, e As EventArgs) Handles BtnAppend.Click
        Me.Commit = DismCommitFlags.Append
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Commit = DismCommitFlags.Cancel
        Me.Close()
    End Sub

    Private Sub BtnCommit_Click(sender As Object, e As EventArgs) Handles BtnCommit.Click
        Me.Commit = DismCommitFlags.Commit
        Me.Close()
    End Sub
End Class
