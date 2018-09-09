#pragma once
#include <Windows.h>
#include <comdef.h>


HRESULT WINAPI DismOpenPluginKey(PHKEY phPluginKey);

BOOL WINAPI DismIsNoviceMode();

HRESULT WINAPI DismGetFileFilter(LPBSTR pFileFilter);

LPCWSTR WINAPI DismMultiLanguage(LPCWSTR Str);

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//                                               ��Ҫʵ�����½ӿڣ��Ա���������Dism++
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

MIDL_INTERFACE("4d420a2e-ea11-450a-b8a0-ab8ca7772043")
IDismPluginInfo: public IUnknown
{
	//��ò����GUID��ÿ�������ֵӦ�ú㶨
	virtual HRESULT WINAPI GetGUID(GUID* pPluginGUID) = 0;

	//��ò���İ汾��
	virtual HRESULT WINAPI GetVersion(UINT16 Version[4]) = 0;

	//��ò����ͼ�꣬����ýӿ�δʵ����ô��ʹ��ϵͳ�Դ��ĳ���ͼ��
	virtual HRESULT WINAPI GetIcon(HICON* pIcon) = 0;

	//��ò��������
	virtual HRESULT WINAPI GetAuthor(BSTR* pAuthor) = 0;

	//��ò������
	virtual HRESULT WINAPI GetName(BSTR* pPluginName) = 0;

	//��ò������
	virtual HRESULT WINAPI GetDescription(BSTR* pDescription) = 0;

	//��ò���ٷ���վ
	virtual HRESULT WINAPI GetWebSite(BSTR* pWebSite) = 0;

	//����������°汾,����ø���˵��
	virtual HRESULT WINAPI CheckUpdate(UINT16 LatestVersion[4], BSTR* pUpdateDescription) = 0;

	//�������°汾��ָ��Ŀ¼
	virtual HRESULT WINAPI DownloadUpdate(LPCWSTR NewFileRootPath, DismCallBack CallBack, LPVOID UserData) = 0;
};

//ӳ���������ò����ʾ��ӳ����Ĳ����չ�Ի�����
MIDL_INTERFACE("836f8013-9fd3-40eb-b5f4-62d09d54dff2")
IDismImagePlugin: public IUnknown
{
	//��ʾ�Ի���
	virtual HRESULT WINAPI DoModal(HWND Parent) = 0;

	//�ڴ����ϲ����ʾ������
	virtual HRESULT WINAPI GetName(BSTR* pPluginName) = 0;

	//�ڴ����ϣ��ò����ʾ��˵��
	virtual HRESULT WINAPI GetDescription(BSTR* pDescription) = 0;

	//��ò����ͼ�꣬����ýӿ�δʵ����ô��ʹ��ϵͳ�Դ��ĳ���ͼ��
	virtual HRESULT WINAPI GetIcon(HICON* pIcon) = 0;
};

//�����ϣ��һ��DLLͬʱ֧�ֶ�����������ʵ�ִ˽ӿ�
MIDL_INTERFACE("83302884-00ad-43e5-a5f8-57880563463b")
IDismImagePluginCollection: public IUnknown
{
	virtual HRESULT WINAPI get_Count(_Out_ long* pcount) = 0;

	virtual HRESULT WINAPI get_Item(_In_ long Index, _Out_ IDismImagePlugin** pDismImagePlugin) = 0;

	virtual HRESULT WINAPI get__NewEnum(_Out_ IUnknown** ppUnk) = 0;
};


//Dism++���������֧��
MIDL_INTERFACE("E9C1A683-7D97-4415-B5E9-18E228FB47DD")
IDismImagePluginCommandLine : public IUnknown
{
	//ppszArglist�����������������NULL��ֹ
	virtual HRESULT WINAPI put_CommandLine(_In_ LPCWSTR* ppszArglist) = 0;
};

//��������Ľӿ�,�õ��Ľӿڶ���ͨ��Reaease ɾ���������ǰϵͳ��֧�ָò�����벻Ҫ����S_OK
HRESULT WINAPI DismCreateInstance2(DismSession Session, const GUID& InstanceIID, void** ppInstance);