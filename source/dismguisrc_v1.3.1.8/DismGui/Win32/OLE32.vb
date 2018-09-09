Imports System.Runtime.InteropServices
Public Class OLE32
    <DllImport("ole32.dll", Charset:=CharSet.Auto, SetLastError:=True)> _
    Public Shared Sub CoTaskMemFree(ByVal addr As IntPtr)
    End Sub
End Class
