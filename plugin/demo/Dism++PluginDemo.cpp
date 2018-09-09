// Dism++PluginDemo.cpp : ���� DLL Ӧ�ó���ĵ���������
//

#include "stdafx.h"

#include <Windows.h>

#include "Dism++API.h"
#include "Plugin.h"
#ifdef _AMD64_
#pragma comment(lib,"Dism++x64.lib")
#else
#pragma comment(lib,"Dism++x86.lib")
#endif

// һ�����������
HRESULT WINAPI HelloWorldCleanup(
	_In_ DismSession Session,
	_Reserved_ DWORD Flags,
	_In_ UINT64 *CleanUpSpace,
	_In_ DismCallBack CallBack,
	_In_ LPVOID UserData)
{
	
	MessageBoxW(
		nullptr,
		L"Hello Dism++",
		L"HelloWorld",
		MB_ICONINFORMATION);


	return S_OK;
}