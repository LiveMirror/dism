Imports System.Runtime.InteropServices
Public Class User32

    Private Const DllName As String = "User32.dll"
    Private Const DCharSet As CharSet = CharSet.Auto
    Private Const DSetLastError As Boolean = True

    Public Const WM_User As UInt32 = &H400

    <DllImport(DllName, CharSet:=DCharSet, SetLastError:=DSetLastError, EntryPoint:="SendMessage")> _
    Public Shared Function SendMessage(ByVal hwnd As IntPtr, ByVal uMsg As UInt32, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr

    End Function

    <DllImport(DllName, CharSet:=DCharSet, SetLastError:=DSetLastError, EntryPoint:="SendMessage")> _
    Public Shared Function SendMessage(ByVal hwnd As IntPtr, ByVal uMsg As UInt32, ByVal wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lParam As String) As IntPtr

    End Function

    <DllImport(DllName, CharSet:=DCharSet, SetLastError:=DSetLastError, EntryPoint:="SendMessage")> _
    Public Shared Function SendMessage(ByVal hwnd As IntPtr, ByVal uMsg As UInt32, ByVal wParam As Integer, ByVal lParam As IntPtr) As IntPtr

    End Function

    <DllImport(DllName, CharSet:=DCharSet, SetLastError:=DSetLastError, EntryPoint:="DestroyIcon")> _
    Public Shared Function DestroyIcon(ByVal hIcon As IntPtr) As Boolean

    End Function

    'BOOL WINAPI DestroyIcon(
    '  _In_  HICON hIcon
    ');

End Class
