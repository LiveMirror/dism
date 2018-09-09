#pragma once
#include <Windows.h>
#include <comdef.h>


HRESULT WINAPI DismOpenPluginKey(PHKEY phPluginKey);

BOOL WINAPI DismIsNoviceMode();

HRESULT WINAPI DismGetFileFilter(LPBSTR pFileFilter);

LPCWSTR WINAPI DismMultiLanguage(LPCWSTR Str);

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//                                               需要实现以下接口，以便于整合至Dism++
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

MIDL_INTERFACE("4d420a2e-ea11-450a-b8a0-ab8ca7772043")
IDismPluginInfo: public IUnknown
{
	//获得插件的GUID，每个插件该值应该恒定
	virtual HRESULT WINAPI GetGUID(GUID* pPluginGUID) = 0;

	//获得插件的版本号
	virtual HRESULT WINAPI GetVersion(UINT16 Version[4]) = 0;

	//获得插件的图标，如果该接口未实现那么将使用系统自带的程序图标
	virtual HRESULT WINAPI GetIcon(HICON* pIcon) = 0;

	//获得插件的作者
	virtual HRESULT WINAPI GetAuthor(BSTR* pAuthor) = 0;

	//获得插件名称
	virtual HRESULT WINAPI GetName(BSTR* pPluginName) = 0;

	//获得插件名称
	virtual HRESULT WINAPI GetDescription(BSTR* pDescription) = 0;

	//获得插件官方网站
	virtual HRESULT WINAPI GetWebSite(BSTR* pWebSite) = 0;

	//检查插件的最新版本,并获得更新说明
	virtual HRESULT WINAPI CheckUpdate(UINT16 LatestVersion[4], BSTR* pUpdateDescription) = 0;

	//下载最新版本到指定目录
	virtual HRESULT WINAPI DownloadUpdate(LPCWSTR NewFileRootPath, DismCallBack CallBack, LPVOID UserData) = 0;
};

//映像处理插件，该插件显示在映像处理的插件扩展对话框中
MIDL_INTERFACE("836f8013-9fd3-40eb-b5f4-62d09d54dff2")
IDismImagePlugin: public IUnknown
{
	//显示对话框
	virtual HRESULT WINAPI DoModal(HWND Parent) = 0;

	//在窗口上插件显示的名称
	virtual HRESULT WINAPI GetName(BSTR* pPluginName) = 0;

	//在窗口上，该插件显示的说明
	virtual HRESULT WINAPI GetDescription(BSTR* pDescription) = 0;

	//获得插件的图标，如果该接口未实现那么将使用系统自带的程序图标
	virtual HRESULT WINAPI GetIcon(HICON* pIcon) = 0;
};

//如果你希望一个DLL同时支持多个插件，可以实现此接口
MIDL_INTERFACE("83302884-00ad-43e5-a5f8-57880563463b")
IDismImagePluginCollection: public IUnknown
{
	virtual HRESULT WINAPI get_Count(_Out_ long* pcount) = 0;

	virtual HRESULT WINAPI get_Item(_In_ long Index, _Out_ IDismImagePlugin** pDismImagePlugin) = 0;

	virtual HRESULT WINAPI get__NewEnum(_Out_ IUnknown** ppUnk) = 0;
};


//Dism++插件命令行支持
MIDL_INTERFACE("E9C1A683-7D97-4415-B5E9-18E228FB47DD")
IDismImagePluginCommandLine : public IUnknown
{
	//ppszArglist将传递命令参数，以NULL终止
	virtual HRESULT WINAPI put_CommandLine(_In_ LPCWSTR* ppszArglist) = 0;
};

//创建插件的接口,得到的接口都会通过Reaease 删除，如果当前系统不支持该插件，请不要返回S_OK
HRESULT WINAPI DismCreateInstance2(DismSession Session, const GUID& InstanceIID, void** ppInstance);