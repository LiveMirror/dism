Namespace WIMGAPI

    'WIMCreateFile
    ''' <summary>
    ''' 访问文件的方式
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum FileAccess As UInteger
        ''' <summary>
        ''' 只读
        ''' </summary>
        ''' <remarks></remarks>
        Read = &H80000000UI
        ''' <summary>
        ''' 读写
        ''' </summary>
        ''' <remarks></remarks>
        Write = &H40000000UI
        ''' <summary>
        ''' 映像可被WIMMountImageHandle挂载
        ''' </summary>
        ''' <remarks></remarks>
        Mount = &H20000000UI
    End Enum

    'WIMCreateFile
    ''' <summary>
    ''' 打开文件的方式
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum FileMode As UInteger
        ''' <summary>
        ''' 创建一个新的文件.若文件已经存在,则调用失败.
        ''' </summary>
        ''' <remarks></remarks>
        CreateNew = 1
        ''' <summary>
        ''' 创建一个新的文件.若文件已经存在,则会覆盖该文件.
        ''' </summary>
        ''' <remarks></remarks>
        CreateAlways = 2
        ''' <summary>
        ''' 打开一个文件.若文件不存在,则调用失败.
        ''' </summary>
        ''' <remarks></remarks>
        OpenExisting = 3
        ''' <summary>
        ''' 打开一个文件.若文件不存在,则创建它.
        ''' </summary>
        ''' <remarks></remarks>
        OpenAlways = 4
    End Enum

    'WIMCreateFile
    ''' <summary>
    ''' 压缩方式
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum FileCompress As UInteger
        ''' <summary>
        ''' 不压缩
        ''' </summary>
        ''' <remarks></remarks>
        None = 0
        ''' <summary>
        ''' 快速
        ''' </summary>
        ''' <remarks></remarks>
        Xpress
        ''' <summary>
        ''' 最大压缩
        ''' </summary>
        ''' <remarks></remarks>
        LZX
        ''' <summary>
        ''' 这个要问微软:)
        ''' </summary>
        ''' <remarks></remarks>
        LZMS
    End Enum

    'WIMCreateFile
    ''' <summary>
    ''' 表示文件是通过哪种方式打开的
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum CreationResult As UInteger
        ''' <summary>
        ''' 新建
        ''' </summary>
        ''' <remarks></remarks>
        CreatedNew = 0
        ''' <summary>
        ''' 打开已存在的
        ''' </summary>
        ''' <remarks></remarks>
        OpenedExisting
    End Enum

    'WIMCreateFile, WIMCaptureImage, WIMApplyImage, WIMMountImageHandle
    ''' <summary>
    ''' 文件标志
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum FileFlags As UInteger
        ''' <summary>
        ''' 保留.千万别使用这个!
        ''' </summary>
        ''' <remarks></remarks>
        Reserved = &H1
        ''' <summary>
        ''' 生成新文件的数据完整性的信息,验证并更新现有的文件.
        ''' </summary>
        ''' <remarks></remarks>
        Verify = &H2
        ''' <summary>
        ''' 指定该映像将被顺序地读出用于高速缓存或提高性能的目的
        ''' </summary>
        ''' <remarks></remarks>
        Index = &H4
        ''' <summary>
        ''' 应用映像但不实际创建目录或文件,可用于获取映像中的文件和目录的列表.
        ''' </summary>
        ''' <remarks></remarks>
        NoApply = &H8
        ''' <summary>
        ''' 禁止恢复目录的安全信息.
        ''' </summary>
        ''' <remarks></remarks>
        NoDiracl = &H10
        ''' <summary>
        ''' 禁止恢复文件的安全信息
        ''' </summary>
        ''' <remarks></remarks>
        NoFileacl = &H20
        ''' <summary>
        ''' 打开文件为可同时读取和写入模式.
        ''' </summary>
        ''' <remarks></remarks>
        ShareWrite = &H40
        ''' <summary>
        ''' 应用映像操作过程中发送一个WIM_MSG_FILEINFO消息
        ''' </summary>
        ''' <remarks></remarks>
        FileInfo = &H80
        ''' <summary>
        ''' 禁止自动修正边界和特征链接.
        ''' 原文:Disables automatic path fixups for junctions and symbolic links.
        ''' </summary>
        ''' <remarks></remarks>
        NoRPFix = &H100
        ''' <summary>
        ''' 以只读的方式装载映像.
        ''' </summary>
        ''' <remarks></remarks>
        MountReadOnly = &H200
        ''' <summary>
        ''' 快速装载映像.
        ''' </summary>
        ''' <remarks></remarks>
        MountFast = &H400
        ''' <summary>
        ''' 以上一个老版本的方式装载映像.
        ''' </summary>
        ''' <remarks></remarks>
        MountLegacy = &H800
        ''' <summary>
        ''' 这个请问微软:)
        ''' </summary>
        ''' <remarks></remarks>
        ApplyCIEA = &H1000
    End Enum

    'WIMGetMountedImageList flags
    Public Enum MountFlags As UInteger
        Mounted = &H1
        Mounting = &H2
        Remountable = &H4
        Invalid = &H8
        NoWIM = &H10
        NoMountDir = &H20
        MountDirReplaced = &H40
        ReadWrite = &H1000
    End Enum

    'WIMSetReferenceFile
    Public Enum References As UInteger
        Append = &H10000
        Replace = &H20000
    End Enum

    'WIMExportImage
    Public Enum ExportFlags As UInteger
        AllowDuplicates = &H1
        OnlyResources = &H2
        OnlyMetadata = &H4
        VerifySource = &H8
        VerifyDestination = &H10
    End Enum

    'WIMMessageCallback Notifications:
    '''<summary>
    '''映像消息
    '''</summary>
    Public Enum Message As UInteger
        WM_APP = &H8000

        WIM_MSG = WM_APP + &H1476

        WIM_MSG_TEXT

        '''<summary>
        ''' 表示应用一个映像的进度。
        '''Indicates an update in the progress of an image application.
        '''</summary>
        WIM_MSG_PROGRESS

        '''<summary>
        '''让调用者能够防止在捕获或者应用一个文件或者目录时访问该文件或者目录.
        '''Enables the caller to prevent a file or a directory from being captured or applied.
        '''</summary>
        WIM_MSG_PROCESS

        '''<summary>
        ''' 表示在捕获映像的时候收集该卷的信息
        '''Indicates that volume information is being gathered during an image capture.
        '''</summary>
        WIM_MSG_SCANNING

        '''<summary>
        ''' 表示捕获或者应用映像的文件数
        '''Indicates the number of files that will be captured or applied.
        '''</summary>
        WIM_MSG_SETRANGE

        '''<summary>
        ''' 表示已经捕获或者应用的文件数
        '''Indicates the number of files that have been captured or applied.
        '''</summary>
        WIM_MSG_SETPOS

        '''<summary>
        ''' 表示该文件不被捕获或者应用
        '''Indicates that a file has been either captured or applied.
        '''</summary>
        WIM_MSG_STEPIT

        '''<summary>
        ''' 让调用者能够防止在捕获一个文件资源时压缩该文件资源.
        '''Enables the caller to prevent a file resource from being compressed during a capture.
        '''</summary>
        WIM_MSG_COMPRESS

        '''<summary>
        ''' 警告调用者：在捕获或者应用映像的时候
        '''Alerts the caller that an error has occurred while capturing or applying an image.
        '''</summary>
        WIM_MSG_ERROR

        '''<summary>
        ''' 让调用者能够在特定的边界对齐文件
        '''Enables the caller to align a file resource on a particular alignment boundary.
        '''</summary>
        WIM_MSG_ALIGNMENT

        WIM_MSG_RETRY
        WIM_MSG_SPLIT
        WIM_MSG_FILEINFO
        WIM_MSG_INFO
        WIM_MSG_WARNING
        WIM_MSG_CHK_PROCESS
        WIM_MSG_WARNING_OBJECTID
        WIM_MSG_STALE_MOUNT_DIR
        WIM_MSG_STALE_MOUNT_FILE
        WIM_MSG_MOUNT_CLEANUP_PROGRESS
        WIM_MSG_CLEANUP_SCANNING_DRIVE
        WIM_MSG_IMAGE_ALREADY_MOUNTED
        WIM_MSG_CLEANUP_UNMOUNTING_IMAGE
        WIM_MSG_QUERY_ABORT
        WIM_MSG_IO_RANGE_START_REQUEST_LOOP
        WIM_MSG_IO_RANGE_END_REQUEST_LOOP
        WIM_MSG_IO_RANGE_REQUEST
        WIM_MSG_IO_RANGE_RELEASE
        WIM_MSG_VERIFY_PROGRESS
        WIM_MSG_COPY_BUFFER
        WIM_MSG_METADATA_EXCLUDE
        WIM_MSG_GET_APPLY_ROOT
        WIM_MSG_MDPAD
        WIM_MSG_STEPNAME
        WIM_MSG_PERFILE_COMPRESS
        WIM_MSG_CHECK_CI_EA_PREREQUISITE_NOT_MET
        WIM_MSG_JOURNALING_ENABLED

        'WIMMessageCallback Return codes
        WIM_MSG_SUCCESS = &H0
        WIM_MSG_DONE = &HFFFFFFF0UI
        WIM_MSG_SKIP_ERROR = &HFFFFFFFEUI
        WIM_MSG_ABORT_IMAGE = &HFFFFFFFFUI

    End Enum

    'WIM_INFO dwFlags values:
    Public Enum Attributes As UInteger
        Normal = 0
        ResourceOnly = &H1
        MetadataOnly = &H2
        VerifyData = &H4
        RPFIX = &H8
        Spanned = &H10
        [ReadOnly] = &H20
    End Enum

    'Define enumeration for WIMGetMountedImageInfo to determine structure to use...
    Public Enum MOUNTED_IMAGE_INFO_LEVELS As UInteger
        MountedImageInfoLevel0 = 0
        MountedImageInfoLevel1
        MountedImageInfoLevelInvalid
    End Enum


    '未转换
    '// An abstract type implemented by the caller when using File I/O callbacks.
    '//
    'typedef VOID * PFILEIOCALLBACK_SESSION;

    '//
    '// The WIM_IO_RANGE_CALLBACK structure is used in conjunction with the
    '// FileIOCallbackReadFile callback and the WIM_MSG_IO_RANGE_REQUEST and
    '// WIM_MSG_IO_RANGE_RELEASE message callbacks.  A pointer to a
    '// WIM_IO_RANGE_REQUEST is passed in WPARAM to the callback for both messages.
    '//
    'typedef struct _WIM_IO_RANGE_CALLBACK
    '{
    '    //
    '    // The callback session that corresponds to the file that is being queried.
    '    //
    '    PFILEIOCALLBACK_SESSION pSession;

    '    // Filled in by WIMGAPI for both messages:
    '    LARGE_INTEGER Offset, Size;

    '    // Filled in by the callback for WIM_MSG_IO_RANGE_REQUEST (set to TRUE to
    '    // indicate data in the specified range is available, and FALSE to indicate
    '    // it is not yet available):
    '    BOOL Available;
    '} WIM_IO_RANGE_CALLBACK, *PWIM_IO_RANGE_CALLBACK;


    '//
    '// Abstract (opaque) type for WIM files used with
    '// WIMEnumImageFiles API
    '//
    'typedef VOID * PWIM_ENUM_FILE;


    '#if defined(__cplusplus)
    'typedef struct _WIM_FILE_FIND_DATA : public _WIN32_FIND_DATAW
    '{
    '#Else
    'typedef struct _WIM_FILE_FIND_DATA
    '{
    '    WIN32_FIND_DATAW;
    '#End If

    '    BYTE bHash[20];
    '    PSECURITY_DESCRIPTOR pSecurityDescriptor;
    '    PWSTR *ppszAlternateStreamNames;
    '    PBYTE pbReparseData;
    '    DWORD cbReparseData;
    '} WIM_FIND_DATA, *PWIM_FIND_DATA;

    '//

End Namespace