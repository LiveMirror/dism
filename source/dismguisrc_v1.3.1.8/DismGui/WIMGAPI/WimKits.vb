Imports System.Runtime.InteropServices
Namespace WIMGAPI
    Public Class WIMKits
        ''' <summary>
        ''' 最大路径Unicode编码字符数
        ''' </summary>
        ''' <remarks></remarks>
        Private Const MAX_PATH As Integer = 260

        Public Const WIM_COMMIT_FLAG_APPEND As UInt32 = 1               'WIMCommitImageHandle
        Public Const INVALID_CALLBACK_VALUE As UInt32 = &HFFFFFFFFUI    'WIMRegisterMessageCallback
        Public Const WIM_COPY_FILE_RETRY As UInt32 = &H1000000          'WIMCopyFile
        Public Const WIM_DELETE_MOUNTS_ALL As UInt32 = &H1              'WIMDeleteImageMounts
        Public Const WIM_LOGFILE_UTF8 As UInt32 = &H1                   'WIMRegisterLogfile

        Private Shared Is64Bit As Boolean = System.Environment.Is64BitOperatingSystem


        Public Shared Function CreateFile(WimPath As String,
                                          Access As FileAccess,
                                          Mode As FileMode) As IntPtr
            Dim Result As CreationResult = CreationResult.CreatedNew
            Dim hWim As IntPtr = IntPtr.Zero
            Dim RC As Integer = -1
            If Is64Bit Then
                hWim = X64.WIMCreateFile(WimPath, Access, Mode, 0UI, 0UI, Result)
            Else
                hWim = X86.WIMCreateFile(WimPath, Access, Mode, 0UI, 0UI, Result)
            End If
            RC = Marshal.GetLastWin32Error()
            Return hWim
        End Function

        Public Shared Function CloseHandle(hObject As IntPtr) As Boolean
            If Is64Bit Then
                Return X64.WIMCloseHandle(hObject)
            Else
                Return X86.WIMCloseHandle(hObject)
            End If
        End Function

        Public Shared Function LoadImage(hWim As IntPtr, ImageIndex As UInteger) As IntPtr
            Dim hImage As IntPtr = IntPtr.Zero
            If Is64Bit Then
                hImage = X64.WIMLoadImage(hWim, ImageIndex)
            Else
                hImage = X86.WIMLoadImage(hWim, ImageIndex)
            End If
            Return hImage
        End Function

        Public Shared Function GetImageInformation(hImage As IntPtr, ByRef pImageInfo As IntPtr, ByRef pcbImageInfo As UInt32) As Boolean
            If Is64Bit Then
                Return X64.WIMGetImageInformation(hImage, pImageInfo, pcbImageInfo)
            Else
                Return X86.WIMGetImageInformation(hImage, pImageInfo, pcbImageInfo)
            End If
        End Function

        Public Shared Function SetImageInformation(hImage As IntPtr, pImageInfo As IntPtr, pcbImageInfo As UInt32) As Boolean
            If Is64Bit Then
                Return X64.WIMSetImageInformation(hImage, pImageInfo, pcbImageInfo)
            Else
                Return X86.WIMSetImageInformation(hImage, pImageInfo, pcbImageInfo)
            End If
        End Function

        Public Shared Function GetMessageCallbackCount(hWim As IntPtr) As UInt32
            If Is64Bit Then
                Return X64.WIMGetMessageCallbackCount(hWim)
            Else
                Return X86.WIMGetMessageCallbackCount(hWim)
            End If
        End Function

        Public Shared Function RegisterMessageCallback(hWim As IntPtr, fpMessageProc As WIMMessageCallback, pvUserData As IntPtr) As UInt32
            If Is64Bit Then
                Return X64.WIMRegisterMessageCallback(hWim, fpMessageProc, pvUserData)
            Else
                Return X86.WIMRegisterMessageCallback(hWim, fpMessageProc, pvUserData)
            End If
        End Function

        Public Shared Function UnregisterMessageCallback(hWim As IntPtr, fpMessageProc As WIMMessageCallback) As UInt32
            If Is64Bit Then
                Return X64.WIMUnregisterMessageCallback(hWim, fpMessageProc)
            Else
                Return X86.WIMUnregisterMessageCallback(hWim, fpMessageProc)
            End If
        End Function

        Public Shared Function SetTemporaryPath(hWim As IntPtr, Path As String) As Boolean
            If Is64Bit Then
                Return X64.WIMSetTemporaryPath(hWim, Path)
            Else
                Return X86.WIMSetTemporaryPath(hWim, Path)
            End If
        End Function


        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMSetReferenceFile", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMSetReferenceFile(hWim As IntPtr,
        '                                               <MarshalAs(UnmanagedType.LPWStr)> Path As String,
        '                                               dwFlags As References) As Boolean

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMSplitFile", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMSplitFile(hWim As IntPtr,
        '                                        <MarshalAs(UnmanagedType.LPWStr)> PartPath As String,
        '                                        ByRef PartSize As Long,
        '                                        dwFlags As UInt32) As Boolean

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMExportImage", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMExportImage(hImage As IntPtr,
        '                                          hWim As IntPtr,
        '                                          dwFlag As ExportFlags) As Boolean

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMDeleteImage", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMDeleteImage(hWim As IntPtr,
        '                                          dwImageIndex As UInt32) As Boolean

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMGetImageCount", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMGetImageCount(hWim As IntPtr) As UInt32

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMGetAttributes", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMGetAttributes(hWim As IntPtr, ByRef pWimInfo As Byte, cbWimInfo As UInt32) As Boolean

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMSetBootImage", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMSetBootImage(hWim As IntPtr, dwImageIndex As UInt32) As Boolean

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMCaptureImage", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMCaptureImage(hWim As IntPtr,
        '                                           <MarshalAs(UnmanagedType.LPWStr)> Path As String,
        '                                           dwCaptureFlags As FileFlags) As IntPtr

        '    End Function



        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMApplyImage", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMApplyImage(hImage As IntPtr,
        '                                         <MarshalAs(UnmanagedType.LPWStr)> Path As String,
        '                                         dwApplyFlags As FileFlags) As Boolean

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMGetImageInformation", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMGetImageInformation(hImage As IntPtr,
        '                                                  pImageInfo As IntPtr,
        '                                                  ByRef pcbImageInfo As UInt32) As Boolean

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMSetImageInformation", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMSetImageInformation(hImage As IntPtr,
        '                                                  ByRef pImageInfo As Byte,
        '                                                  pcbImageInfo As UInt32) As Boolean

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMGetMessageCallbackCount", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMGetMessageCallbackCount(hWim As IntPtr) As UInt32

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMRegisterMessageCallback", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMRegisterMessageCallback(hWim As IntPtr,
        '                                                      fpMessageProc As WIMMessageCallback,
        '                                                      pvUserData As IntPtr) As UInt32

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMUnregisterMessageCallback", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMUnregisterMessageCallback(hWim As IntPtr,
        '                                                        fpMessageProc As WIMMessageCallback) As Boolean

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMCopyFile", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMCopyFile(<MarshalAs(UnmanagedType.LPWStr)> ExistingFileName As String,
        '                                       <MarshalAs(UnmanagedType.LPWStr)> NewFileName As String,
        '                                       pProgressRoutine As CopyProgressRoutine,
        '                                       pvData As IntPtr,
        '                                       ByRef pbCancel As Boolean,
        '                                       dwCopyFlags As Int32) As Boolean

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMMountImage", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMMountImage(<MarshalAs(UnmanagedType.LPWStr)> MountPath As String,
        '                                         <MarshalAs(UnmanagedType.LPWStr)> WimFileName As String,
        '                                         dwImageIndex As UInt32,
        '                                         <MarshalAs(UnmanagedType.LPWStr)> TempPath As String) As Boolean

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMMountImageHandle", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMMountImageHandle(hImage As IntPtr,
        '                                               <MarshalAs(UnmanagedType.LPWStr)> MountPath As String,
        '                                               dwMountFlags As MountFlags) As Boolean

        '    End Function

        '    ''' <summary>
        '    ''' 重新挂载映像
        '    ''' </summary>
        '    ''' <param name="MountPath">挂载路径</param>
        '    ''' <param name="dwFlags">保留!一直为0.</param>
        '    ''' <returns></returns>
        '    ''' <remarks></remarks>
        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMRemountImage", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMRemountImage(<MarshalAs(UnmanagedType.LPWStr)> MountPath As String,
        '                                           dwFlags As UInt32) As Boolean

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMCommitImageHandle", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMCommitImageHandle(hImage As IntPtr,
        '                                                dwCommitFlags As UInt32,
        '                                                phNewImageHandle As IntPtr) As Boolean

        '    End Function


        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMUnmountImage", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMUnmountImage(<MarshalAs(UnmanagedType.LPWStr)> MountPath As String,
        '                                           <MarshalAs(UnmanagedType.LPWStr)> WimFileName As String,
        '                                           dwImageIndex As UInt32,
        '                                           bCommitChanges As Boolean) As Boolean

        '    End Function

        '    ''' <summary>
        '    ''' 卸载映像
        '    ''' </summary>
        '    ''' <param name="hImage">映像句柄</param>
        '    ''' <param name="dwUnmountFlags">保留!总是为0.</param>
        '    ''' <returns></returns>
        '    ''' <remarks></remarks>
        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMUnmountImageHandle", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMUnmountImageHandle(hImage As IntPtr,
        '                                                 dwUnmountFlags As Int32) As Boolean

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMGetMountedImages", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMGetMountedImages(ByRef pMountList As Byte, ByRef pcbMountListLength As Int32) As Boolean

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMGetMountedImageInfo", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMGetMountedImageInfo(fInfoLevelId As MOUNTED_IMAGE_INFO_LEVELS,
        '                                                  ByRef pdwImageCount As UInt32,
        '                                                  ByRef pMountInfo As Byte,
        '                                                  cbMountInfoLength As Int32,
        '                                                  ByRef pcbReturnLength As Int32) As Boolean

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMGetMountedImageInfoFromHandle", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMGetMountedImageInfoFromHandle(hImage As IntPtr,
        '                                                            fInfoLevelId As MOUNTED_IMAGE_INFO_LEVELS,
        '                                                            ByRef pMountInfo As Byte,
        '                                                            cbMountInfoLength As Int32,
        '                                                            ByRef pcbReturnLength As Int32) As Boolean

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMGetMountedImageHandle", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMGetMountedImageHandle(<MarshalAs(UnmanagedType.LPWStr)> MountPath As String,
        '                                                    dwFlags As FileFlags,
        '                                                    ByRef phWimHandle As IntPtr,
        '                                                    ByRef phImageHandle As IntPtr) As Boolean

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMDeleteImageMounts", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMDeleteImageMounts(dwDeleteFlags As UInt32) As Boolean

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMRegisterLogFile", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMRegisterLogFile(<MarshalAs(UnmanagedType.LPWStr)> LogFile As String,
        '                                              dwFlags As UInt32) As Boolean

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMUnregisterLogFile", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMUnregisterLogFile(<MarshalAs(UnmanagedType.LPWStr)> LogFile As String) As Boolean

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMExtractImagePath", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMExtractImagePath(hImage As IntPtr,
        '                                               <MarshalAs(UnmanagedType.LPWStr)> ImagePath As String,
        '                                               <MarshalAs(UnmanagedType.LPWStr)> DestinationPath As String,
        '                                               dwExtractFlags As UInt32) As Boolean

        '    End Function

        '    <DllImport(DllName, ExactSpelling:=True, EntryPoint:="WIMCreateImageFile", CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        '    Public Shared Function WIMCreateImageFile(hImage As IntPtr,
        '                                               <MarshalAs(UnmanagedType.LPWStr)> FilePath As String,
        '                                               dwDesiredAccess As FileAccess,
        '                                               dwCreationDisposition As FileMode,
        '                                               dwFlagsAndAttributes As FileFlags) As IntPtr

        '    End Function


    End Class

End Namespace
