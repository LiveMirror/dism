Public Class ToolBoxItemInfo

    Public Path As String = ""
    Public Name As String = ""
    Public Image As Image = Nothing
    Public Visible As Boolean = True

    Public Sub New(Path As String, Name As String)
        Me.Path = Path : Me.Name = Name : Me.Image = GetFileIcon(Path)
    End Sub

    Private Shared Function GetFileIcon(Path As String) As Image

        Try
            Dim MyIcon As Icon = Icon.ExtractAssociatedIcon(Path)
            If Not IsNothing(MyIcon) Then
                Dim MyImage As Bitmap = MyIcon.ToBitmap()
                'Dim bm As New Bitmap(16, 24)
                'Dim g As Graphics = Graphics.FromImage(bm)
                'g.DrawImage(MyImage, 0, 0, bm.Width, bm.Height)
                'MyImage.Dispose()
                Return MyImage
            End If
        Catch ex As Exception

        End Try
        Return Nothing
    End Function

    Private Shared Function GetFileIcon1(Path As String) As Image
        Try
            Dim MyIcon As Icon = Icon.ExtractAssociatedIcon(Path)
            If Not IsNothing(MyIcon) Then Return MyIcon.ToBitmap()
        Catch ex As Exception

        End Try
        Return Nothing
    End Function

    'Private Shared Function GetFileIcon2(Path As String) As Image

    '    Dim IconCount As Integer = Shell32.ExtractIconEx(Path, -1, Nothing, Nothing, 0)

    '    If IconCount > 0 Then
    '        Dim LargeIcon(IconCount - 1) As IntPtr
    '        Dim SmallIcon(IconCount - 1) As IntPtr
    '        IconCount = Shell32.ExtractIconEx(Path, 0, LargeIcon, SmallIcon, IconCount)
    '        If SmallIcon(0) <> IntPtr.Zero Then
    '            Return Icon.FromHandle(SmallIcon(0)).ToBitmap
    '        ElseIf LargeIcon(0) <> IntPtr.Zero Then
    '            Return Icon.FromHandle(LargeIcon(0)).ToBitmap
    '        Else
    '            Return Nothing
    '        End If
    '    Else
    '        Return Nothing
    '    End If
    'End Function
End Class