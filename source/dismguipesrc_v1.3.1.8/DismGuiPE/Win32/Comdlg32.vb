Imports System.Runtime.InteropServices
Public Class Comdlg32
    <DllImport("comdlg32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Public Shared Function GetOpenFileName(<[In], Out> ByVal ofn As OpenFileName) As Boolean
    End Function

    <DllImport("Comdlg32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Public Shared Function GetSaveFileName(<[In], Out> ByVal lpofn As OpenFileName) As Boolean
    End Function

End Class
