// Dism++PluginDemo.cpp : 定义 DLL 应用程序的导出函数。
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

// 一个清理插件入口
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