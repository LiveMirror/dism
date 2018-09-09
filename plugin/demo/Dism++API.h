#pragma once

#include <Windows.h>
#include <comdef.h>


////////////////////////////////////////////////////////////////
//                     枚举


enum DismPackageState
{
	DismPackageStateUnknown = 0,
	DismPackageStateNotPresent,
	DismPackageStateUnintallRequested,
	DismPackageStateStaged,              //暂存
	DismPackageStateStaging,             //正在暂存
	DismPackageStateInstalled,           //更新已经安装
	DismPackageStateInstallRequested,    //安装挂起
	DismPackageStateSuperseded,          //该更新已经被取代
	DismPackageStatePartiallInstalled,   //部分安装
	DismPackageStateRemoved,             //已经删除
	DismPackageStatePermanent,           //永久固化更新包
};
enum DismFeatureState
{
	DismFeatureStateUnknown = 0,
	DismFeatureStateNotPresent,
	DismFeatureStateUnintallRequested,   //该功能已经关闭但是未生效
	DismFeatureStateDisable,             //该功能已经关闭
	DismFeatureStateStaging,
	DismFeatureStateEnable,              //该功能被启动
	DismFeatureStateEnableRequested,     //该功能已经启动，但是未生效
	DismFeatureStateSuperseded,          //该功能已经被取代
	DismFeatureStatePartiallInstalled,   //该功能部分安装
	DismFeatureStateRemoved              //该功能已经删除
};

enum DismFullyOfflineInstallableState
{
	DismPackageFullyOfflineUnknow = 0,
	DismPackageFullyOfflineInatallable,
	DismPackageFullyOfflineNotInatallable,
};



enum DismDriverSinStatus
{
	DismDriverSinStatusUnknow = 0,
	DismDriverSinStatusUnsigned,
	DismDriverSinStatusSinged
};


enum DriverShowEnum
{
	DriverShowAll = 0,
	DriverShowInbox = 1,
	DriverShowOutOfBox = 2
};


enum DismMountedImageStatus
{
	DismMountedImageStatusValid = 0,
	DismMountedImageStatusMounting = 1,
	DismMountedImageStatusInvalid = 2,
	DismMountedImageStatusNeedsRemount = 4
};

enum DismImageFileTpye
{
	WimImageFile,
	VhdImageFile
};

//WIM或者esd文件的压缩类型
enum DismCompressTpye
{
	//未知压缩类型
	Compress_Unknown = -1,

	//仅存储，不压缩文件
	Compress_None = 0,

	//此压缩方式支持WIMBOOT启动
	Compress_XpressHuffman = 1,

	//快速压缩，可以节省压缩时间并且可以减少提交占用
	Compress_Xpress = 2,

	//最大压缩，可以节省空间
	Compress_LZX = 3,

	//极限压缩，非常耗费时间，但是体积最小
	Compress_LZMS = 4,
};


enum DismServiceStartType
{
	//启动类型未知，可能是系统启动项，也可能是Dism无法识别的其他启动类型，为了安全性Dism++无法修改启动类型未知的项目
	DismServiceStartTypeUnknown = -1,
	//该服务已经关闭
	DismServiceStartTypeDisable,
	//该服务为手动启动
	DismServiceStartTypeManual,
	//该服务是自动启动
	DismServiceStartTypeAuto,
	//该服务是延迟启动，注意有_不可延迟标记的无法修改为延迟启动，会返回参数错误
	DismServiceStartTypeDelayed
};

enum DismSystemStatus
{
	//状态未知
	DismSystemStatusUnknown = -1,
	//准备就绪
	DismSystemStatusReady,
	//该系统不支持Dism++
	DismSystemStatusNotSupported,
	//找不到系统，目标目录无法访问或者路径不存在
	DismSystemStatusCannotFind,
	//挂载已经失效，需要删除
	DismSystemStatusNeedRemove,
	//请稍等
	DismSystemStatusWait
};


enum DismEnvironmentType
{
	DismEnvironmentDefault = 0, //32位系统获得32位目录，64位系统获取64位路径
	DismEnvironment64Only,    //仅仅获取64位路径，对于32位系统会失败！
	DismEnvironment86Only,    //总是返回32位路径
};


enum DismImageHealthState
{
	DismImageHealthy = 0,      //映像十分健康不需要修复
	DismImageRepairable = 1,   //映像已经受损，但是可以修复
	DismImageNonRepairable = 2 //映像已经收到致命问题，不可修复
};

enum DismServiceType
{
	DismSystemService,    //系统服务
	DismAppService,       //第三方应用程序
	DismDriverService,    //驱动程序
};


////////////////////////////////////////////////////////////////
//                      结构定义

#pragma pack(push, 1)

struct DismSystem
{
	//系统状态
	DismSystemStatus Status;

	/*
	操作系统CPU体系，可能值为：
	PROCESSOR_ARCHITECTURE_AMD64     x64体系
	PROCESSOR_ARCHITECTURE_INTEL     x86体系
	PROCESSOR_ARCHITECTURE_UNKNOWN   未知体系*/
	long Architecture;

	//在线指示
#define _联机映像      0x1     //如果为联机映像那么该标记为1 否则为0

	//存在形式
#define _本地硬盘      0x2  //映像存放于本地
#define _挂载映像      0x4  //映像是来自WIM或者VHD挂载的

	//使用的技术
#define _WIMBOOT       0x8  //映像使用了WIMBOOT技术
#define _VHD装载       0x10  //映像来自VHD装载
#define _CompactOs     0x20  //映像使用了CompactOs技术
#define _WinPE         0x40
	//用户自定义区 24~31  Dism++API可以保证不会使用这块区域，你可以自行添加新的定义
	DWORD Flags;       //Flags拥有以上组合标志

	BSTR RootPath;       //系统安装位置

	//系统版本号 比如6.3.9600.17041
	UINT16 Version[4];


	BSTR ProductName;    //操作系统名称
	BSTR EditionID;      //系统具体版本

	BSTR InstallationType;      //系统安装类型
	DWORD DefaultLanguage;      //默认显示语言
	DWORD InstallLanguage;      //系统安装语言
	BSTR InstallLanguageFallback;//语言回退列表
	DWORD ProductType;          //授权类型 WinNT、LanmanNT 或者 ServerNT
	BSTR ExtendPath;            //映像扩展路径，用于保存WIM路径以及VHD路径 多字符字符串
};


struct DismPackage
{
	VARIANT_BOOL IsApplicable;
	DismPackageState State;
	wchar_t RestartRequired[40];

	wchar_t ReleaseType[40];
	wchar_t Identity[MAX_PATH];
	wchar_t Name[MAX_PATH];
	wchar_t Description[512];
	wchar_t ProductName[MAX_PATH];
	wchar_t ProductVersion[MAX_PATH];
	wchar_t Company[MAX_PATH];
	wchar_t Copyright[MAX_PATH];
	wchar_t SupportInformation[512];
	wchar_t InstallPackageName[MAX_PATH];
	wchar_t InstallLocation[MAX_PATH];
	wchar_t InstallClient[MAX_PATH];
	wchar_t InstallUserName[50];

	//暂无
	FILETIME CreationTime;
	FILETIME LastUpdateTime;
	FILETIME InstallTime;

	wchar_t FullyOfflineInstallable[MAX_PATH];
	wchar_t ScavengeSequence[40];
};

struct DismFeature
{
	DismFeatureState State;
	wchar_t RestartRequired[40];
	wchar_t Name[MAX_PATH];
	wchar_t DisplayName[512];
	wchar_t Description[512];
	//DWORD ParentFeatureNameCount;
	wchar_t ParentFeatureName[40];
};

struct DismCapability
{
	DismFeatureState State;
	DWORD DownloadSize;
	DWORD InstallSize;

	wchar_t Name[MAX_PATH];
	wchar_t ID[MAX_PATH];
	wchar_t DisplayName[512];
	wchar_t Description[512];
};


struct DismDriver
{
	VARIANT_BOOL InBox;
	VARIANT_BOOL BootCritical;
	VARIANT_BOOL SigStatus;
	wchar_t LocaleName[0x55];
	wchar_t InfProviderName[0x104];
	wchar_t CatalogFile[0x104];
	wchar_t InfPath[0x104];
	wchar_t PublishedInfName[256];
	GUID ClassGuid;
	wchar_t ClassName[0x104];
	wchar_t ClassDescription[256];
	UINT16 Version[4];
	FILETIME Date;
};


struct DismMountedImage
{
	BSTR MountDir;
	BSTR ImagePath;
	DWORD Index;
	VARIANT_BOOL ReadWritable;
	DismMountedImageStatus Status;
};

struct DismImageInfo
{
	//系统体系
	long Architecture;

	//创建日期
	FILETIME CreationTime;

	//展开空间
	UINT64 Space;

	//系统版本号
	UINT16 Version[4];

	//////////////////////////////////////////////////
	//        你可以修改以下信息 来设置映像信息

	//映像名称
	BSTR Name;

	//映像说明
	BSTR Description;

	//显示名称
	BSTR DisplayName;

	//显示说明
	BSTR DisplayDescription;

	//映像版本标记
	BSTR Flags;
};

struct DismImageFileInfo
{
	//启动下标
	int BootIndex;

	//文件类型
	DismImageFileTpye Type;

	//文件唯一标识
	GUID FileGUID;

	//压缩类型
	DismCompressTpye Compression;

	//映像数量
	DWORD ImageInfoCount;

	//映像
	DismImageInfo ImageInfo[0];
};

struct DismService
{
	DismServiceType Type;
	/*
	服务启动类型,可能值为
	SERVICE_AUTO_START
	SERVICE_BOOT_START
	SERVICE_DEMAND_START
	SERVICE_DISABLED
	SERVICE_SYSTEM_START
	*/
	//延迟启动
#define SERVICE_Delay_START 5
	DWORD dwStartType;

#define _系统保护 0x00000001
#define _不可延迟 0x00000002
#define _系统服务 0x00000004
	//服务Flags 拥有以上状态
	DWORD Flags;

	//服务名称
	BSTR Name;

	//对应服务显示名称
	BSTR DisplayName;

	//对应服务显示描述
	BSTR Description;

	//对应服务路径
	BSTR ImagePath;

	//对应服务的登录状态
	BSTR ObjectName;
};


struct AppxPackage
{
	BSTR FullName;
	BSTR InstalledLocation;
	BSTR Users;
};



#pragma pack(pop)



typedef struct CCbsHostProxy* DismSession;


#define DISM_MSG_PROGRESS   38008     //进度信息wParam为当前完成百分比
#define DISM_MSG_PROCESS    38009     //指示该文件是否应该被捕获wParam = (PWSTR) pszFullPath   lParam = (PBOOL) pfProcessFile
#define DISM_MSG_SCANNING   38010     //扫描的文件数量与文件夹 wParam=(BOOL)IsDirector   lParam=(UINT)Count
#define DISM_MGS_RemoveInfo 37001     //指示该文件或者文件夹需要处理   wParam=(DWORD)Type    lParam=(LPCWSTR)FilePath
#define Dism_MSG_QUERY_ABORT 38030    //是否需要中断该操作？返回-1 则中断当前操作，返回S_OK那么函数正常进行 

//Dism回掉函数，用于返回进度等信息dwMessageId，有以上几种消息  UserData是你传入的指针 如果函数正常进行，请返回 ERROR_SUCCESS
typedef DWORD(WINAPI *DismCallBack)(DWORD dwMessageId, WPARAM wParam, LPARAM lParam, PVOID UserData);


///////////////////////////////////////////////基础函数支持////////////////////////////////////////////////
//
//

//获取指定的注册表键值,调用后需要使用RegClose关闭
HRESULT WINAPI DismRegOpenKeyEx(DismSession Session, HKEY hKey, LPCWSTR lpSubKey, REGSAM samDesired, PHKEY phkResult);

//创建键值
HRESULT WINAPI DismRegCreateKeyEx(DismSession Session, HKEY hKey, LPCWSTR lpSubKey, REGSAM samDesired, PHKEY phkResult, LPDWORD lpdwDisposition);

//获取指定的注册表键值,调用后需要使用RegClose关闭
HRESULT WINAPI DismRegOpenKey(DismSession Session, HKEY hKey, LPCWSTR lpSubKey, PHKEY phkResult);

//转换指定的环境变量
HRESULT WINAPI DismExpandEnvironmentStrings(DismSession Session, LPCWSTR lpSrc, LPBSTR lpDst);

#define DismLogLevelSilent      0    //不输出任何信息
#define DismLogLevelFailure     1    //仅错误
#define DismLogLevelWarning     2    //错误和警告
#define DismLogLevelInformation 3    //错误、警告和信息
#define DismLogLevelDebug       4    //以上所有内容和调试输出
//写入日志
HRESULT WINAPI DismWriteLog(DWORD LogLevel, LPCWSTR LogName, LPCWSTR LogValue);

//释放Dism接口调用后的空间
HRESULT WINAPI DismFreeMemory(void* pStruct);

//根据会话获得系统信息
HRESULT WINAPI DismGetSystemInfoBySession(DismSession Session, DismSystem** Info);

//根据路径获得系统信息
HRESULT WINAPI DismGetSystemInfoByPath(LPCWSTR RootPath, DismSystem** Info);

//将指定错误代码转换为对应文本。
HRESULT WINAPI DismFormatMessage(HRESULT hr, LPBSTR ppErrorMessage);

//获取临时目录
LPCWSTR WINAPI DismGetScratchDir();

BOOL WINAPI DismUnloadRegMount(LPCWSTR RootPath);

//
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////



/////////////////////////////////////////////////////更新包命令///////////////////////////////////////////////
//
//

//添加更新包
HRESULT WINAPI DismAddPackage(DismSession Session, LPCWSTR PackageFilePath, DismCallBack CallBack, LPVOID UserData);

//删除更新包
HRESULT WINAPI DismRemovePackage(DismSession Session, LPCWSTR PackageName, DismCallBack CallBack, LPVOID UserData);

//获取更新包信息
//HRESULT WINAPI DismGetPackage(DismSession Session, LPCWSTR PackageIdentity, DismPackage** ppPackageInfo);

//获取所有更新包
HRESULT WINAPI DismGetPackages(DismSession Session, DismPackage** ppPackages, DWORD* pCount, DismCallBack CallBack, LPVOID UserData);

//
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////





//////////////////////////////////////////////////功能包命令/////////////////////////////////////////////////////
//

HRESULT WINAPI DismChangeFeatures(DismSession Session,
	LPCWSTR FeatureNames,  //需要关闭的功能名称
#define DismLimitAccess 0x00000001   //NT6.1无效 打开功能时不要从微软服务器中下载文件 PS：如果这样设定可能会应该不能下载到文件而打开失败
	DWORD ChangeFlags,   //关闭标志，支持以上状态
	LPCWSTR SourcePaths,  //NT6.1无效 指定启用源，在启动功能时优先从源复制文件,多个源以NULL分割
	DismCallBack CallBack, LPVOID UserData);

//获取功能状态
HRESULT WINAPI DismGetFeatures(DismSession Session, DismFeature** ppFeature, LPDWORD pCount, DismCallBack CallBack, LPVOID UserData);

//
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




//////////////////////////////////////////////////系统修复命令///////////////////////////////////////////////////////
//
//

//扫描系统是否受损
HRESULT WINAPI DismScanHealth(DismSession Session, DismImageHealthState* pImageHealthState, DismCallBack CallBack, PVOID UserData);

//恢复系统受损
HRESULT WINAPI DismRestoreHealth(DismSession Session, LPCWSTR SourcePaths, DismCallBack CallBack, PVOID UserData);

//
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



//////////////////////////////////////////////////可选功能///////////////////////////////////////////////////////
//
//
//仅从本地获取
#define CapabilityFlagsPackageStore 0x1
//从安装源中获取
#define CapabilityFlagsLocalSouce   0x2
//从云端获取
#define CapabilityFlagsCloud        0x4

//获取所有可选功能状态
HRESULT WINAPI DismGetCapabilities(DismSession Session, DWORD CapabilityFlags, DismCapability** ppCapabilitites, DWORD* pCount);

//删除可选功能
HRESULT WINAPI DismRemoveCapability(DismSession Session, LPCWSTR CapabilityName, DismCallBack CallBack, LPVOID UserData);

//添加可选功能
HRESULT WINAPI DismAddCapability(DismSession Session, LPCWSTR CapabilityName, DismCallBack CallBack, LPVOID UserData);
//
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



/////////////////////////////////////////////////服务命令支持//////////////////////////////////////////////////////
//
//

//获取所有服务
HRESULT WINAPI DismGetServices(DismSession Session, DismService** ppService, DWORD *pCount, DismCallBack CallBack, LPVOID pUserData);

//删除服务
HRESULT WINAPI DismRemoveService(DismSession Session, LPCWSTR Name);

//修改服务启动类型
HRESULT WINAPI DismSetServiceStart(DismSession Session, LPCWSTR Name, DWORD StartType);

//
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////


/////////////////////////////////////////////////驱动包命令//////////////////////////////////////////////////////
//
//

//添加驱动包
HRESULT WINAPI DismAddDriver(DismSession Session, LPCWSTR DriverPath);

//删除驱动包
HRESULT WINAPI DismRemoveDriver(DismSession Session, LPCWSTR DriverName);

//获取所有驱动包
HRESULT WINAPI DismGetDrivers(DismSession Session, DismDriver** ppDrivers, DWORD* pCount, DriverShowEnum DriverShow, DismCallBack CallBack, LPVOID UserData);

//
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////



/////////////////////////////////////////////清理相关////////////////////////////////////////////////////////
//
//

//清理过期不需要的更新
HRESULT WINAPI DismComponentCleanup(DismSession Session, DWORD Reserved, UINT64 *CleanUpSpace, DismCallBack CallBack, LPVOID UserData);

//清理过期以及不使用的驱动
HRESULT WINAPI DismDriverCleanup(DismSession Session, DWORD Reserved, UINT64 *CleanUpSpace, DismCallBack CallBack, LPVOID UserData);

//清理不需要的Metro App
HRESULT WINAPI DismAppxsCleanup(DismSession Session, DWORD Reserved, UINT64 *CleanUpSpace, DismCallBack CallBack, LPVOID UserData);

//开启紧凑型系统
HRESULT WINAPI DismCompactOs(DismSession Session, DWORD Reserved, UINT64 *CleanUpSpace, DismCallBack CallBack, LPVOID UserData);

//使用NTFS硬链接合并相同文件，缩小系统体积
HRESULT WINAPI DismHardLinkMerge(DismSession Session, DWORD Reserved, UINT64 *CleanUpSpace, DismCallBack CallBack, LPVOID UserData);

//清除Windows事件日志
HRESULT WINAPI DismEventLogCleanup(DismSession Session, DWORD Reserved, UINT64 *CleanUpSpace, DismCallBack CallBack, LPVOID UserData);

//
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////



///////////////////////////////////////////////WIM处理命令//////////////////////////////////////////////////
//
//

HRESULT WINAPI DismGetMountedImages(DismMountedImage** ppMountedImages, DWORD* pCount);

//获取WIM、esd、VHD的文件信息
HRESULT WINAPI DismGetImageFileInfo(LPCWSTR ImageFilePath, DismImageFileInfo** ppFileInfo);

//修改WIM、esd的文件信息
HRESULT WINAPI DismSetImageFileInfo(LPCWSTR ImageFilePath, DWORD ImageIndex, DismImageInfo* pImageInfo);




#define _ExportCreate            0x00000001	//覆盖目标文件
/*
导出指定映像，当DesImageFile存在时CompressTpye将忽略
SourceImageFile：需要导出的映像路径
SourceIndex    ：需要导出映像的下标
DesImageFile   ：用于存放目标映像，如果不存在那么会使用CompressTpye指定的压缩等级创建该文件，如果该文件已经存在，那么CompressTpye参数将忽略
CompressTpye   ：压缩等级
ExportFlags    ：导出标记，可以使用以上组合
*/
HRESULT WINAPI DismExportImage(LPCWSTR SourceImageFile, DWORD SourceIndex, LPCWSTR DesImageFile, DWORD ExportFlags, DismCompressTpye CompressTpye, DismCallBack CallBack, LPVOID pUserData);

//删除WIM 文件中的映像
HRESULT WINAPI DismDeleteImage(LPCWSTR FilePath, DWORD DeleteIndex);

//将指定下标的WIM文件设置为可启动，如果indxe为-1 那么清除启动标志
HRESULT WINAPI DismSetBootImage(LPCWSTR FilePath, DWORD BootIndex);

#define _CommitAppend               0x00000001
#define _CommitVerify               0x00000002
#define _CommitNoDirAcl             0x00000010
#define _CommitNoFileAcl            0x00000020
#define _CommitNoRpFix              0x00000100

//提交挂载映像更改CommitFlags 拥有以上属性
HRESULT WINAPI DismCommitImage(LPCWSTR MountPath, DWORD CommitFlags, DismCallBack CallBack, LPVOID UserData);


#define _MountFlagReadOnly       0x00000200     //如果该标记存在那么为可写挂载，否则为只读挂载
#define _MountFlagOptimize       0x00000400
#define _MountFlagCheckIntegrity 0x00000002
//挂载指定下标映像，其中Flags拥有以上属性
HRESULT WINAPI DismMountImage(LPCWSTR ImageFilePath, DWORD MountIndex, DWORD MountFlags, LPCWSTR MountPath, DismCallBack CallBack, LPVOID UserData);


#define _ApplyFlags_Verify  0x00000002   //校验数据
#define _ApplyFlags_WIMBoot 0x00002000   //释放WIMBoot 映像
#define _ApplyFlags_Compact 0x00004000   //释放紧凑型映像
HRESULT WINAPI DismApplyImage(LPCWSTR ImageFilePath, DWORD ApplyIndex, DWORD ApplyFlags, LPCWSTR ApplyPath, DismCallBack CallBack, LPVOID UserData);


//卸载指定目录的挂载映像
HRESULT WINAPI DismUnmountImage(LPCWSTR MountPath, DismCallBack CallBack, LPVOID UserData);


//解密加密的WIM文件
HRESULT WINAPI DismDecryptWimFile(LPCWSTR FilePath, LPCWSTR PublicKey, BOOL TestKey/* 如果为TRUE 那么仅测试Key能否解密此文件*/);

#define _CaptureNew                0x80000000	//总是新建文件，删除当前文件。默认情况如果文件已经存在则打开文件。
#define _CaptureSnapshot           0x40000000	//为目标产生快照，使用该标志可以捕获正在使用的文件，一般用于捕获在线系统。
#define _CaptureBootable           0x20000000	//仅WIM文件支持,将Windows PE卷映像标记为能够引导
#define _CaptureReserved           0x00000001	//仅WIM文件支持
#define _CaptureVerify             0x00000002	//仅WIM文件支持
#define _CaptureIndex              0x00000004	//仅WIM文件支持
#define _CaptureNoApply            0x00000008	//仅WIM文件支持
#define _CaptureNoDirAcl           0x00000010	//仅WIM文件支持
#define _CaptureNoFileAcl          0x00000020	//仅WIM文件支持
#define _CaptureShareWrite         0x00000040	//仅WIM文件支持
#define _CaptureFileInfo           0x00000080	//仅WIM文件支持
#define _CaptureNoRpFix            0x00000100	//仅WIM文件支持
#define _CaptureApplyCiEa          0x00001000	//仅WIM文件支持
//#define _CaptureWIMBoot            0x00002000	//仅WIM文件支持，生成的文件允许够使用 WIMBoot 配置。
/*将某个路径捕获为WIM、esd、VHD(X)文件 （esd、VHD(X)暂未支持）
注意DismCompressTpye参数仅仅WIM文件有效 而且仅仅在新建文件中发挥作用*/
HRESULT WINAPI DismCaptureImage(LPCWSTR CapturePath, LPCWSTR ImageFilePath, DismCompressTpye CompressTpye, DWORD CaptureFlags, DismCallBack CallBack, LPVOID UserData, DismImageInfo* pImageInfo);

//映像拆分
HRESULT WINAPI DismSplitFile(LPCWSTR ImageFilePath, LPCWSTR SplitFilePath, UINT64 SplitSize, DismCallBack CallBack, LPVOID UserData);

//将一个esd文件转换为ISO文件
HRESULT WINAPI DismConversionESD2ISO(LPCWSTR szWimFilePath, LPCWSTR szISOPath, DismCompressTpye CompressTpye, DismCallBack CallBack, LPVOID UserData);

//
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////



//Appx支持
HRESULT WINAPI DismGetAllUsersAppx(DismSession Session, AppxPackage** ppPackage, DWORD* pCount);

HRESULT WINAPI DismRemoveAppx(DismSession Session, LPCWSTR FullName);


enum REConfigCode
{
	//仅启动RE
	RunREOnly = -2,

	//仅对RE进行初始化配置
	InitializeRE = -1,

	//在RE中运行自定义工具（仅一次）
	RunCustomToolOnce,

	//执行系统还原（将Windows.bt中的文件移动到当前系统）
	SystemRestore,

	//保留，Dism++中暂未使用此功能。
	Reservation1,

	//在RE中运行自定义工具（持久启动项）
	RunCustomTool,

	MaxREConfigCode,
};

/*RE支持
Code: 任务执行动作

BootID:  Code为 RunCustomToolOnce或者 RunCustomTool时有效。引导菜单，随机输入一个32位值，不要跟其他人冲突，用于产生引导菜单

FilePath：Code为 RunCustomToolOnce或者 RunCustomTool时有效，在RE中需要启动的文件路径

CallBack：可选，回调函数，用于输出处理进度

UserData：可选，此值将传入 回调函数的UserData产生中，供调用者使用
*/
HRESULT WINAPI WinREConfig2(REConfigCode Code, DWORD BootID, LPCWSTR FilePath, DismCallBack CallBack, LPVOID UserData);