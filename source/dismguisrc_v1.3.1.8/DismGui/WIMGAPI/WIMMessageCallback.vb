Namespace WIMGAPI

    'DWORD
    'CALLBACK
    'WIMMessageCallback(
    '    DWORD  dwMessageId,
    '    WPARAM wParam,
    '    LPARAM lParam,
    '    PVOID  pvUserData
    '    );
    Public Delegate Function WIMMessageCallback(dwMessageId As UInt32,
                                                wParam As IntPtr,
                                                lParam As IntPtr,
                                                pvUserData As IntPtr) As UInt32

End Namespace
