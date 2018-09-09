Imports System.Runtime.InteropServices
Imports System.Text
Public Class Shell32

    Public Delegate Function BrowseCallbackProc(ByVal hwnd As IntPtr, ByVal uMsg As Integer, ByVal lParam As IntPtr, ByVal lpData As IntPtr) As Integer

    Public Const BFFM_INITIALIZED As UInt32 = 1
    Public Const BFFM_SETSELECTION As UInt32 = User32.WM_User + 102

    Public Enum ShowWindow As Integer
        Hide = 0
        Normal
        ShowMinimized
        ShowMaximized
        ShowNoActive
        Show
        Minimize
        ShowMinNoActive
        ShowNA
        Restore
        ShowDefault
    End Enum

    <Flags> _
    Public Enum BrowseInfoFlags As UInteger
        ''' <summary>
        ''' Only return file system directories. 
        ''' </summary>
        BIF_RETURNONLYFSDIRS = &H1
        ''' <summary>
        ''' Do not include network folders below the domain level in the dialog box's tree view control.
        ''' </summary>
        BIF_DONTGOBELOWDOMAIN = &H2
        ''' <summary>
        ''' Include a status area in the dialog box. 
        ''' The callback function can set the status text by sending messages to the dialog box. 
        ''' This flag is not supported when <bold>BIF_NEWDIALOGSTYLE</bold> is specified
        ''' </summary>
        BIF_STATUSTEXT = &H4
        ''' <summary>
        ''' Only return file system ancestors. 
        ''' An ancestor is a subfolder that is beneath the root folder in the namespace hierarchy. 
        ''' If the user selects an ancestor of the root folder that is not part of the file system, the OK button is grayed
        ''' </summary>
        BIF_RETURNFSANCESTORS = &H8
        ''' <summary>
        ''' Include an edit control in the browse dialog box that allows the user to type the name of an item.
        ''' </summary>
        BIF_EDITBOX = &H10
        ''' <summary>
        ''' If the user types an invalid name into the edit box, the browse dialog box calls the application's BrowseCallbackProc with the BFFM_VALIDATEFAILED message. 
        ''' This flag is ignored if <bold>BIF_EDITBOX</bold> is not specified.
        ''' </summary>
        BIF_VALIDATE = &H20
        ''' <summary>
        ''' Use the new user interface. 
        ''' Setting this flag provides the user with a larger dialog box that can be resized. 
        ''' The dialog box has several new capabilities, including: drag-and-drop capability within the 
        ''' dialog box, reordering, shortcut menus, new folders, delete, and other shortcut menu commands. 
        ''' </summary>
        BIF_NEWDIALOGSTYLE = &H40
        ''' <summary>
        ''' The browse dialog box can display URLs. The <bold>BIF_USENEWUI</bold> and <bold>BIF_BROWSEINCLUDEFILES</bold> flags must also be set. 
        ''' If any of these three flags are not set, the browser dialog box rejects URLs.
        ''' </summary>
        BIF_BROWSEINCLUDEURLS = &H80
        ''' <summary>
        ''' Use the new user interface, including an edit box. This flag is equivalent to <bold>BIF_EDITBOX | BIF_NEWDIALOGSTYLE</bold>
        ''' </summary>
        BIF_USENEWUI = (BIF_EDITBOX Or BIF_NEWDIALOGSTYLE)
        ''' <summary>
        ''' hen combined with <bold>BIF_NEWDIALOGSTYLE</bold>, adds a usage hint to the dialog box, in place of the edit box. <bold>BIF_EDITBOX</bold> overrides this flag.
        ''' </summary>
        BIF_UAHINT = &H100
        ''' <summary>
        ''' Do not include the New Folder button in the browse dialog box.
        ''' </summary>
        BIF_NONEWFOLDERBUTTON = &H200
        ''' <summary>
        ''' When the selected item is a shortcut, return the PIDL of the shortcut itself rather than its target.
        ''' </summary>
        BIF_NOTRANSLATETARGETS = &H400
        ''' <summary>
        ''' Only return computers. If the user selects anything other than a computer, the OK button is grayed.
        ''' </summary>
        BIF_BROWSEFORCOMPUTER = &H1000
        ''' <summary>
        ''' Only allow the selection of printers. If the user selects anything other than a printer, the OK button is grayed
        ''' </summary>
        BIF_BROWSEFORPRINTER = &H2000
        ''' <summary>
        ''' The browse dialog box displays files as well as folders.
        ''' </summary>
        BIF_BROWSEINCLUDEFILES = &H4000
        ''' <summary>
        ''' The browse dialog box can display shareable resources on remote systems.
        ''' </summary>
        BIF_SHAREABLE = &H8000
        ''' <summary>
        ''' Allow folder junctions such as a library or a compressed file with a .zip file name extension to be browsed.
        ''' </summary>
        BIF_BROWSEFILEJUNCTIONS = &H10000
    End Enum

    Public Enum OpenFileNameFlags As Integer
        OFN_READONLY = &H1
        OFN_OVERWRITEPROMPT = &H2
        OFN_HIDEREADONLY = &H4
        OFN_NOCHANGEDIR = &H8
        OFN_SHOWHELP = &H10
        OFN_ENABLEHOOK = &H20
        OFN_ENABLETEMPLATE = &H40
        OFN_ENABLETEMPLATEHANDLE = &H80
        OFN_NOVALIDATE = &H100
        OFN_ALLOWMULTISELECT = &H200
        OFN_EXTENSIONDIFFERENT = &H400
        OFN_PATHMUSTEXIST = &H800
        OFN_FILEMUSTEXIST = &H1000
        OFN_CREATEPROMPT = &H2000
        OFN_SHAREAWARE = &H4000
        OFN_NOREADONLYRETURN = &H8000
        OFN_NOTESTFILECREATE = &H10000
        OFN_NONETWORKBUTTON = &H20000
        ''' <summary>
        ''' Force no long names for 4.x modules
        ''' </summary>
        OFN_NOLONGNAMES = &H40000
        ''' <summary>
        ''' New look commdlg
        ''' </summary>
        OFN_EXPLORER = &H80000
        OFN_NODEREFERENCELINKS = &H100000
        ''' <summary>
        ''' Force long names for 3.x modules
        ''' </summary>
        OFN_LONGNAMES = &H200000
    End Enum

    <Flags()> _
    Public Enum SHGetFileInfoFlags As UInt32
        SmallIcon = &H1
        LargeIcon = &H0
        Icon = &H100
        DisplayName = &H200
        Typename = &H400
        SysIconIndex = &H4000
        UseFileAttributes = &H10
    End Enum

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure BROWSEINFO
        Public hwndOwner As IntPtr
        Public pidlRoot As IntPtr
        <MarshalAs(UnmanagedType.LPTStr)> Public pszDisplayName As String
        <MarshalAs(UnmanagedType.LPTStr)> Public lpszTitle As String
        <MarshalAs(UnmanagedType.U4)> Public ulFlags As BrowseInfoFlags
        <MarshalAs(UnmanagedType.FunctionPtr)> Public lpfn As BrowseCallbackProc
        Public lParam As IntPtr
        Public iImage As Integer
    End Structure


    <StructLayout(LayoutKind.Sequential)> _
    Public Structure SHFILEINFO
        Public hIcon As IntPtr
        Public iIcon As IntPtr
        Public dwAttributes As UInteger
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
        Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> _
        Public szTypeName As String
    End Structure

    '    HINSTANCE ShellExecute(
    '  _In_opt_  HWND hwnd,
    '  _In_opt_  LPCTSTR lpOperation,
    '  _In_      LPCTSTR lpFile,
    '  _In_opt_  LPCTSTR lpParameters,
    '  _In_opt_  LPCTSTR lpDirectory,
    '  _In_      INT nShowCmd
    ');

    <DllImport("shell32.dll", CharSet:=CharSet.Auto, SetLastError:=True, EntryPoint:="ShellExecute")> _
    Public Shared Function ShellExecute(ByVal hwnd As IntPtr,
                                        ByVal lpOperation As String,
                                        ByVal lpFile As String,
                                        ByVal lpParameters As String,
                                        ByVal lpDirectory As String,
                                        ByVal nShowCmd As ShowWindow) As Boolean

    End Function

    <DllImport("shell32.dll", CharSet:=CharSet.Auto, SetLastError:=True, EntryPoint:="SHGetFileInfo")> _
    Public Shared Function SHGetFileInfo(pszPath As String, dwFileAttributes As UInteger, ByRef psfi As SHFILEINFO, cbfileInfo As UInteger, uFlags As SHGetFileInfoFlags) As IntPtr
    End Function

    <DllImport("shell32.dll", CharSet:=CharSet.Auto, SetLastError:=True, EntryPoint:="SHBrowseForFolder")> _
    Public Shared Function SHBrowseForFolder(<MarshalAs(UnmanagedType.Struct)> ByRef lpFileOp As BROWSEINFO) As IntPtr

    End Function

    <DllImport("shell32.dll", CharSet:=CharSet.Auto, SetLastError:=True, EntryPoint:="SHGetPathFromIDList")> _
    Public Shared Function SHGetPathFromIDList(ByVal pidl As IntPtr, ByVal pszPath As StringBuilder) As IntPtr

    End Function


    'BOOL SHGetPathFromIDList(
    '  _In_   PCIDLIST_ABSOLUTE pidl,
    '  _Out_  LPTSTR pszPath
    ');
End Class

