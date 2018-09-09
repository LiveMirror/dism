Namespace WIMGAPI
    Public Class WIM_MOUNT_LIST
        Public WimPath As String = ""
        Public MountPath As String = ""
        Public ImageIndex As UInt32 = 0
        Public MountedForRW As UInt32 = 0

    End Class

    'typedef struct _WIM_MOUNT_LIST
    '{
    '    WCHAR  WimPath[MAX_PATH];
    '    WCHAR  MountPath[MAX_PATH];
    '    DWORD  ImageIndex;
    '    BOOL   MountedForRW;
    '} WIM_MOUNT_LIST, *PWIM_MOUNT_LIST, *LPWIM_MOUNT_LIST,
    '  WIM_MOUNT_INFO_LEVEL0, *PWIM_MOUNT_INFO_LEVEL0, LPWIM_MOUNT_INFO_LEVEL0;
End Namespace
