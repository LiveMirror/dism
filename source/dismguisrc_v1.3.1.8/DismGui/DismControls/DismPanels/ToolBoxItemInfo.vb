Imports System.Runtime.InteropServices
Public Class ToolBoxItemInfo

    Public Path As String = ""
    Public Name As String = ""
    Public Image As Image = Nothing
    Public Visible As Boolean = True

    Public Sub New(Path As String, Name As String)
        Me.Path = Path : Me.Name = Name : Me.Image = GetFileIcon(Path)
    End Sub

    'Private  Function GetFileIcon(Path As String) As Image
    '    Dim info As New Shell32.SHFILEINFO
    '    Dim cbFileInfo As Integer = Marshal.SizeOf(info)
    '    Dim Flags As Shell32.SHGetFileInfoFlags = Shell32.SHGetFileInfoFlags.Icon Or
    '                                              Shell32.SHGetFileInfoFlags.UseFileAttributes Or
    '                                              Shell32.SHGetFileInfoFlags.SmallIcon
    '    Dim hIcon As IntPtr = Shell32.SHGetFileInfo(Path, 256, info, CUInt(cbFileInfo), Flags)
    '    If hIcon.Equals(IntPtr.Zero) Then Return Nothing
    '    If info.hIcon.Equals(IntPtr.Zero) Then Return Nothing
    '    Dim MyIcon As Icon = Icon.FromHandle(info.hIcon).Clone()
    '    User32.DestroyIcon(info.hIcon)
    '    Dim bm As Image = MyIcon.ToBitmap()
    '    MyIcon.Dispose()
    '    Return bm
    'End Function

    Private Shared Function GetFileIcon(Path As String) As Image
        Try
            Dim MyIcon As Icon = Icon.ExtractAssociatedIcon(Path)
            Dim bm As Bitmap = Nothing
            If Not IsNothing(MyIcon) Then
                bm = MyIcon.ToBitmap()
                MyIcon.Dispose()
            End If
            Return bm
        Catch ex As Exception

        End Try
        Return Nothing
    End Function

    'Private Shared Function GetFileIcon1(Path As String) As Image
    '    Try
    '        Dim MyIcon As Icon = Icon.ExtractAssociatedIcon(Path)
    '        If Not IsNothing(MyIcon) Then Return MyIcon.ToBitmap()
    '    Catch ex As Exception

    '    End Try
    '    Return Nothing
    'End Function

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