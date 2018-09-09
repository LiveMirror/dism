Imports System.Runtime.InteropServices
Imports System.Text
Public Class MyCommonDialog

    Public Const MAX_PATH As Integer = 260

    Public Property Filter As String = "所有文件(*.*)|*.*"
    Public Property FilterIndex As Integer = 1

    Public Property InitialDirectory As String = ""

    Public Property Multiselect As Boolean = False

    Public Property CheckFileExists As Boolean = True

    Public Property CheckPathExists As Boolean = True

    Public Property OverwritePrompt As Boolean = True

    Public Property FileName As String = ""

    Public Property SelectedPath As String = ""

    Public Property BrowseFolderTitle As String = "浏览文件夹"

    Public Function ShowFileOpen() As DialogResult
        Dim ofn As New OpenFileName
        ofn.structSize = Marshal.SizeOf(ofn)
        ofn.title = "打开"
        ofn.fileTitle = New Char(MAX_PATH - 1) {}
        ofn.maxFileTitle = ofn.fileTitle.Length
        ofn.defExt = "*"
        ofn.maxFile = MAX_PATH
        ofn.file = New Char(MAX_PATH - 1) {}

        If IO.Directory.Exists(Me.InitialDirectory) Then
            ofn.initialDir = Me.InitialDirectory
        Else
            ofn.initialDir = ""
        End If
        ofn.filter = Me.Filter.Replace("|", Chr(0)) & Chr(0)
        ofn.filterIndex = Me.FilterIndex
        If Me.CheckFileExists Then ofn.flags = ofn.flags Or Shell32.OpenFileNameFlags.OFN_FILEMUSTEXIST
        If Me.CheckPathExists Then ofn.flags = ofn.flags Or Shell32.OpenFileNameFlags.OFN_PATHMUSTEXIST
        'If Me.OverwritePrompt Then ofn.flags = ofn.flags Or Shell32.OpenFileNameFlags.OFN_OVERWRITEPROMPT
        If Me.Multiselect Then ofn.flags = ofn.flags Or Shell32.OpenFileNameFlags.OFN_ALLOWMULTISELECT
        If Comdlg32.GetOpenFileName(ofn) Then
            Me.FileName = ofn.file
            Return DialogResult.OK
        Else
            Return DialogResult.Cancel
        End If
    End Function

    Public Function ShowFileSave() As DialogResult
        Dim ofn As New OpenFileName
        ofn.structSize = Marshal.SizeOf(ofn)
        ofn.title = "保存"
        ofn.fileTitle = New Char(MAX_PATH - 1) {}

        ofn.maxFileTitle = ofn.fileTitle.Length
        ofn.defExt = "*"
        ofn.maxFile = MAX_PATH
        Dim chrs(MAX_PATH - 1) As Char
        Me.FileName.CopyTo(0, chrs, 0, Me.FileName.Length)
        ofn.file = chrs
        If IO.Directory.Exists(Me.InitialDirectory) Then
            ofn.initialDir = Me.InitialDirectory
        Else
            ofn.initialDir = ""
        End If
        ofn.filter = Me.Filter.Replace("|", Chr(0)) & Chr(0)
        ofn.filterIndex = Me.FilterIndex
        If Me.CheckFileExists Then ofn.flags = ofn.flags Or Shell32.OpenFileNameFlags.OFN_FILEMUSTEXIST
        If Me.CheckPathExists Then ofn.flags = ofn.flags Or Shell32.OpenFileNameFlags.OFN_PATHMUSTEXIST
        If Me.OverwritePrompt Then ofn.flags = ofn.flags Or Shell32.OpenFileNameFlags.OFN_OVERWRITEPROMPT
        If Comdlg32.GetSaveFileName(ofn) Then
            Me.FileName = ofn.file
            Return DialogResult.OK
        Else
            Return DialogResult.Cancel
        End If
    End Function

    Public Function ShowBrowseFolder() As DialogResult
        Dim lpIDList As IntPtr = IntPtr.Zero
        Dim tBInfo As New Shell32.BROWSEINFO
        With tBInfo
            .lpszTitle = Me.BrowseFolderTitle
            .pidlRoot = IntPtr.Zero
            .ulFlags = Shell32.BrowseInfoFlags.BIF_RETURNONLYFSDIRS Or
                       Shell32.BrowseInfoFlags.BIF_DONTGOBELOWDOMAIN Or
                       Shell32.BrowseInfoFlags.BIF_STATUSTEXT
            .lpfn = AddressOf BroweCallbackProc
            .lParam = Marshal.StringToCoTaskMemAnsi(Me.SelectedPath)
        End With
        lpIDList = Shell32.SHBrowseForFolder(tBInfo)
        Marshal.FreeHGlobal(tBInfo.lParam)
        If lpIDList <> IntPtr.Zero Then
            Dim sb As New StringBuilder(MAX_PATH)
            Dim Result As IntPtr = Shell32.SHGetPathFromIDList(lpIDList, sb)
            If Result <> IntPtr.Zero Then
                Me.SelectedPath = sb.ToString
                OLE32.CoTaskMemFree(Result)
                Return DialogResult.OK
            End If
        End If
        Return DialogResult.Cancel
    End Function

    Private Function BroweCallbackProc(ByVal hwnd As IntPtr, ByVal uMsg As Integer, ByVal lParam As IntPtr, ByVal lpData As IntPtr) As Integer
        Select Case uMsg
            Case Shell32.BFFM_INITIALIZED
                User32.SendMessage(hwnd, Shell32.BFFM_SETSELECTION, 1, lpData)
        End Select
        Return 0
    End Function

End Class
