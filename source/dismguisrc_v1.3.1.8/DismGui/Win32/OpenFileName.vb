Imports System.Runtime.InteropServices
<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)> _
Public Class OpenFileName

    Public structSize As Integer = 0
    Public dlgOwner As IntPtr = IntPtr.Zero
    Public instance As IntPtr = IntPtr.Zero
    Public filter As String = Nothing
    Public customFilter As String = Nothing
    Public maxCustFilter As Integer = 0
    Public filterIndex As Integer = 0
    Public file As String = Nothing
    Public maxFile As Integer = 0
    Public fileTitle As String = Nothing
    Public maxFileTitle As Integer = 0
    Public initialDir As String = Nothing
    Public title As String = Nothing
    Public flags As Shell32.OpenFileNameFlags = 0
    Public fileOffset As Short = 0
    Public fileExtension As Short = 0
    Public defExt As String = Nothing
    Public custData As IntPtr = IntPtr.Zero
    Public hook As IntPtr = IntPtr.Zero
    Public templateName As String = Nothing
    Public reservedPtr As IntPtr = IntPtr.Zero
    Public reservedInt As Integer = 0
    Public flagsEx As Integer = 0

End Class 'OpenFileName