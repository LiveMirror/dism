Imports System.Runtime
Imports System.Runtime.InteropServices
Public Class Kernel32

    '    SW_HIDE (0)
    'Hides the window and activates another window.
    'SW_MAXIMIZE (3)
    'Maximizes the specified window.
    'SW_MINIMIZE (6)
    'Minimizes the specified window and activates the next top-level window in the z-order.
    'SW_RESTORE (9)
    'Activates and displays the window. If the window is minimized or maximized, Windows restores it to its original size and position. An application should specify this flag when restoring a minimized window.
    'SW_SHOW (5)
    'Activates the window and displays it in its current size and position.
    'SW_SHOWDEFAULT (10)
    'Sets the show state based on the SW_ flag specified in the STARTUPINFO structure passed to the CreateProcess function by the program that started the application. An application should call ShowWindow with this flag to set the initial show state of its main window.
    'SW_SHOWMAXIMIZED (3)
    'Activates the window and displays it as a maximized window.
    'SW_SHOWMINIMIZED (2)
    'Activates the window and displays it as a minimized window.
    'SW_SHOWMINNOACTIVE (7)
    'Displays the window as a minimized window. The active window remains active.
    'SW_SHOWNA (8)
    'Displays the window in its current state. The active window remains active.
    'SW_SHOWNOACTIVATE (4)
    'Displays a window in its most recent size and position. The active window remains active.
    'SW_SHOWNORMAL (1)

    Public Delegate Function CopyProgressRoutine(ByVal TotalFileSize As Long,
                                                 ByVal TotalBytesTransferred As Long,
                                                 ByVal StreamSize As Long,
                                                 ByVal StreamBytesTransferred As Long,
                                                 ByVal dwStreamNumber As Int32,
                                                 ByVal dwCallbackReason As Int32,
                                                 ByVal hSourceFile As IntPtr,
                                                 ByVal hDestinationFile As IntPtr,
                                                 ByVal lpData As IntPtr) As Int32
    '    BOOL WINAPI CopyFileEx(
    '  _In_      LPCTSTR lpExistingFileName,
    '  _In_      LPCTSTR lpNewFileName,
    '  _In_opt_  LPPROGRESS_ROUTINE lpProgressRoutine,
    '  _In_opt_  LPVOID lpData,
    '  _In_opt_  LPBOOL pbCancel,
    '  _In_      DWORD dwCopyFlags
    ');
    <DllImport("Kernel32", CharSet:=CharSet.Auto, SetLastError:=True, EntryPoint:="CopyFileEx")> _
    Public Shared Function CopyFileEx(ByVal lpExistingFileName As String,
                                      ByVal lpNewFileName As String,
                                      ByVal lpProgressRoutine As CopyProgressRoutine,
                                      ByVal lpData As IntPtr,
                                      ByRef pbCancel As Boolean,
                                      ByVal dwCopyFlags As Int32) As Boolean

    End Function



End Class
