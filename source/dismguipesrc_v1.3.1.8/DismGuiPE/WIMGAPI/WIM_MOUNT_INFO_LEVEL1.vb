Namespace WIMGAPI
    Public Class WIM_MOUNT_INFO_LEVEL1
        Public WimPath As String = ""
        Public MountPath As String = ""
        Public ImageIndex As UInt32 = 0
        Public MountFlags As MountFlags
    End Class
    'typedef struct _WIM_MOUNT_INFO_LEVEL1
    '{
    '    WCHAR  WimPath[MAX_PATH];
    '    WCHAR  MountPath[MAX_PATH];
    '    DWORD  ImageIndex;
    '    DWORD  MountFlags;
    '} WIM_MOUNT_INFO_LEVEL1, *PWIM_MOUNT_INFO_LEVEL1, *LPWIM_MOUNT_INFO_LEVEL1;
End Namespace
