Imports System
Imports System.Runtime
Imports System.Runtime.InteropServices

Namespace WIMGAPI

    ''' <summary>
    ''' WIMGAPI
    ''' </summary>
    ''' <remarks></remarks>
    Public Class X86

        ''' <summary>
        ''' 动态链接库相对位置
        ''' </summary>
        ''' <remarks></remarks>
        Private Const DllName As String = "DISM\x86\WIMGAPI.DLL"

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMCreateFile", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMCreateFile(<MarshalAs(UnmanagedType.LPWStr)> WimPath As String,
                                             DesiredAccess As UInteger,
                                             CreationDisposition As UInteger,
                                             FlagsAndAttributes As UInteger,
                                             CompressionType As UInteger,
                                             ByRef CreationResult As CreationResult) As IntPtr

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMCloseHandle", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMCloseHandle(hObject As IntPtr) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMSetTemporaryPath", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMSetTemporaryPath(hWim As IntPtr,
                                                   <MarshalAs(UnmanagedType.LPWStr)> Path As String) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMSetReferenceFile", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMSetReferenceFile(hWim As IntPtr,
                                                   <MarshalAs(UnmanagedType.LPWStr)> Path As String,
                                                   dwFlags As References) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMSplitFile", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMSplitFile(hWim As IntPtr,
                                            <MarshalAs(UnmanagedType.LPWStr)> PartPath As String,
                                            ByRef PartSize As Long,
                                            dwFlags As UInt32) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMExportImage", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMExportImage(hImage As IntPtr,
                                              hWim As IntPtr,
                                              dwFlag As ExportFlags) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMDeleteImage", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMDeleteImage(hWim As IntPtr,
                                              dwImageIndex As UInt32) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMGetImageCount", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMGetImageCount(hWim As IntPtr) As UInt32

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMGetAttributes", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMGetAttributes(hWim As IntPtr, ByRef pWimInfo As Byte, cbWimInfo As UInt32) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMSetBootImage", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMSetBootImage(hWim As IntPtr, dwImageIndex As UInt32) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMCaptureImage", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMCaptureImage(hWim As IntPtr,
                                               <MarshalAs(UnmanagedType.LPWStr)> Path As String,
                                               dwCaptureFlags As FileFlags) As IntPtr

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMLoadImage", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMLoadImage(hWim As IntPtr, dwImageIndex As UInt32) As IntPtr

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMApplyImage", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMApplyImage(hImage As IntPtr,
                                             <MarshalAs(UnmanagedType.LPWStr)> Path As String,
                                             dwApplyFlags As FileFlags) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMGetImageInformation", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMGetImageInformation(hImage As IntPtr,
                                                      ByRef pImageInfo As IntPtr,
                                                      ByRef pcbImageInfo As UInt32) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMSetImageInformation", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMSetImageInformation(hImage As IntPtr,
                                                      pImageInfo As IntPtr,
                                                      pcbImageInfo As UInt32) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMGetMessageCallbackCount", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMGetMessageCallbackCount(hWim As IntPtr) As UInt32

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMRegisterMessageCallback", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMRegisterMessageCallback(hWim As IntPtr,
                                                          fpMessageProc As WIMMessageCallback,
                                                          pvUserData As IntPtr) As UInt32

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMUnregisterMessageCallback", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMUnregisterMessageCallback(hWim As IntPtr,
                                                            fpMessageProc As WIMMessageCallback) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMCopyFile", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMCopyFile(<MarshalAs(UnmanagedType.LPWStr)> ExistingFileName As String,
                                           <MarshalAs(UnmanagedType.LPWStr)> NewFileName As String,
                                           pProgressRoutine As CopyProgressRoutine,
                                           pvData As IntPtr,
                                           ByRef pbCancel As Boolean,
                                           dwCopyFlags As Int32) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMMountImage", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMMountImage(<MarshalAs(UnmanagedType.LPWStr)> MountPath As String,
                                             <MarshalAs(UnmanagedType.LPWStr)> WimFileName As String,
                                             dwImageIndex As UInt32,
                                             <MarshalAs(UnmanagedType.LPWStr)> TempPath As String) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMMountImageHandle", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMMountImageHandle(hImage As IntPtr,
                                                   <MarshalAs(UnmanagedType.LPWStr)> MountPath As String,
                                                   dwMountFlags As MountFlags) As Boolean

        End Function

        ''' <summary>
        ''' 重新挂载映像
        ''' </summary>
        ''' <param name="MountPath">挂载路径</param>
        ''' <param name="dwFlags">保留!一直为0.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMRemountImage", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMRemountImage(<MarshalAs(UnmanagedType.LPWStr)> MountPath As String,
                                               dwFlags As UInt32) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMCommitImageHandle", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMCommitImageHandle(hImage As IntPtr,
                                                    dwCommitFlags As UInt32,
                                                    phNewImageHandle As IntPtr) As Boolean

        End Function


        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMUnmountImage", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMUnmountImage(<MarshalAs(UnmanagedType.LPWStr)> MountPath As String,
                                               <MarshalAs(UnmanagedType.LPWStr)> WimFileName As String,
                                               dwImageIndex As UInt32,
                                               bCommitChanges As Boolean) As Boolean

        End Function

        ''' <summary>
        ''' 卸载映像
        ''' </summary>
        ''' <param name="hImage">映像句柄</param>
        ''' <param name="dwUnmountFlags">保留!总是为0.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMUnmountImageHandle", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMUnmountImageHandle(hImage As IntPtr,
                                                     dwUnmountFlags As Int32) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMGetMountedImages", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMGetMountedImages(ByRef pMountList As Byte, ByRef pcbMountListLength As Int32) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMGetMountedImageInfo", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMGetMountedImageInfo(fInfoLevelId As MOUNTED_IMAGE_INFO_LEVELS,
                                                      ByRef pdwImageCount As UInt32,
                                                      ByRef pMountInfo As Byte,
                                                      cbMountInfoLength As Int32,
                                                      ByRef pcbReturnLength As Int32) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMGetMountedImageInfoFromHandle", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMGetMountedImageInfoFromHandle(hImage As IntPtr,
                                                                fInfoLevelId As MOUNTED_IMAGE_INFO_LEVELS,
                                                                ByRef pMountInfo As Byte,
                                                                cbMountInfoLength As Int32,
                                                                ByRef pcbReturnLength As Int32) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMGetMountedImageHandle", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMGetMountedImageHandle(<MarshalAs(UnmanagedType.LPWStr)> MountPath As String,
                                                        dwFlags As FileFlags,
                                                        ByRef phWimHandle As IntPtr,
                                                        ByRef phImageHandle As IntPtr) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMDeleteImageMounts", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMDeleteImageMounts(dwDeleteFlags As UInt32) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMRegisterLogFile", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMRegisterLogFile(<MarshalAs(UnmanagedType.LPWStr)> LogFile As String,
                                                  dwFlags As UInt32) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMUnregisterLogFile", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMUnregisterLogFile(<MarshalAs(UnmanagedType.LPWStr)> LogFile As String) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMExtractImagePath", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMExtractImagePath(hImage As IntPtr,
                                                   <MarshalAs(UnmanagedType.LPWStr)> ImagePath As String,
                                                   <MarshalAs(UnmanagedType.LPWStr)> DestinationPath As String,
                                                   dwExtractFlags As UInt32) As Boolean

        End Function

        <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMCreateImageFile", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Public Shared Function WIMCreateImageFile(hImage As IntPtr,
                                                   <MarshalAs(UnmanagedType.LPWStr)> FilePath As String,
                                                   dwDesiredAccess As FileAccess,
                                                   dwCreationDisposition As FileMode,
                                                   dwFlagsAndAttributes As FileFlags) As IntPtr

        End Function



        'HANDLE
        'WINAPI
        'WIMFindFirstImageFile(
        '    _In_ HANDLE            hImage,
        '    _In_ PCWSTR            pwszFilePath,
        '    _Out_ PWIM_FIND_DATA   pFindFileData
        '    );

        'BOOL
        'WINAPI
        'WIMFindNextImageFile(
        '    _In_  HANDLE           hFindFile,
        '    _Out_ PWIM_FIND_DATA   pFindFileData
        '    );


        '//
        '// API for fast enumeration of image files
        '//
        'typedef
        'HRESULT
        '(CALLBACK * WIMEnumImageFilesCallback)(
        '    _In_ PWIM_FIND_DATA     pFindFileData, 
        '    _In_ PWIM_ENUM_FILE     pEnumFile, 
        '    _In_opt_ PVOID          pEnumContext
        '    );

        'BOOL
        'WINAPI
        'WIMEnumImageFiles(
        '    _In_ HANDLE                     hImage, 
        '    _In_opt_ PWIM_ENUM_FILE         pEnumFile, 
        '    _In_ WIMEnumImageFilesCallback  fpEnumImageCallback, 
        '    _In_opt_ PVOID                  pEnumContext
        '    );




        'BOOL
        'WINAPI
        'WIMReadImageFile(
        '    _In_                                            HANDLE        hImgFile,
        '    _Out_writes_bytes_to_(dwBytesToRead, *pdwBytesRead) PBYTE         pbBuffer,
        '    _In_                                            DWORD         dwBytesToRead,
        '    _Out_opt_                                       PDWORD        pdwBytesRead,
        '    _Inout_                                         LPOVERLAPPED  lpOverlapped
        '    );

        'BOOL
        'WINAPI
        'WIMInitFileIOCallbacks(
        '    _In_opt_ PVOID pCallbacks
        '    );

        'BOOL
        'WINAPI
        'WIMSetFileIOCallbackTemporaryPath(
        '    _In_opt_ PCWSTR pszPath
        '    );

        '//
        '// File I/O callback prototypes
        '//

        'typedef
        'PFILEIOCALLBACK_SESSION
        '(CALLBACK * FileIOCallbackOpenFile)(
        '    _In_ PCWSTR pszFileName
        '    );

        'typedef
        'BOOL
        '(CALLBACK * FileIOCallbackCloseFile)(
        '    _In_ PFILEIOCALLBACK_SESSION hFile
        '    );

        'typedef
        'BOOL
        '(CALLBACK * FileIOCallbackReadFile)(
        '    _In_ PFILEIOCALLBACK_SESSION hFile,
        '    _Out_ PVOID pBuffer,
        '    _In_ DWORD nNumberOfBytesToRead,
        '    _Out_ PDWORD pNumberOfBytesRead,
        '    _Inout_ LPOVERLAPPED pOverlapped
        '    );

        'typedef
        'BOOL
        '(CALLBACK * FileIOCallbackSetFilePointer)(
        '    _In_ PFILEIOCALLBACK_SESSION hFile,
        '    _In_ LARGE_INTEGER liDistanceToMove,
        '    _Out_ PLARGE_INTEGER pNewFilePointer,
        '    _In_ DWORD dwMoveMethod
        '    );

        'typedef
        'BOOL
        '(CALLBACK * FileIOCallbackGetFileSize)(
        '    _In_ HANDLE hFile,
        '    _Out_ PLARGE_INTEGER pFileSize
        '    );

        'typedef struct _SFileIOCallbackInfo
        '{
        '    FileIOCallbackOpenFile       pfnOpenFile;
        '    FileIOCallbackCloseFile      pfnCloseFile;
        '    FileIOCallbackReadFile       pfnReadFile;
        '    FileIOCallbackSetFilePointer pfnSetFilePointer;
        '    FileIOCallbackGetFileSize    pfnGetFileSize;
        '} SFileIOCallbackInfo;

        '#ifdef __cplusplus
        '}
        '#endif

        '#endif // _WIMGAPI_H_

    End Class
End Namespace
