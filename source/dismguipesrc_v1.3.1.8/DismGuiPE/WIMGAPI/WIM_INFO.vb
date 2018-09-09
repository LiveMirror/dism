Namespace WIMGAPI
    Public Class WIM_INFO
        Public WimPath As String = ""
        Public Guid As Guid = Guid.Empty
        Public ImageCount As UInt32 = 0
        Public CompressionType As FileCompress = FileCompress.None
        Public PartNumber As UInt16 = 0
        Public TotalParts As UInt16 = 0
        Public BootIndex As UInt32 = 0
        Public WimAttributes As Attributes
        Public WimFlagsAndAttr As FileFlags
    End Class

    '    //
    '// The WIM_INFO structure used by WIMGetAttributes:
    '//
    'typedef struct _WIM_INFO
    '{
    '    WCHAR  WimPath[MAX_PATH];
    '    GUID   Guid;
    '    DWORD  ImageCount;
    '    DWORD  CompressionType;
    '    USHORT PartNumber;
    '    USHORT TotalParts;
    '    DWORD  BootIndex;
    '    DWORD  WimAttributes;
    '    DWORD  WimFlagsAndAttr;
    '} WIM_INFO, *PWIM_INFO, *LPWIM_INFO;

End Namespace
