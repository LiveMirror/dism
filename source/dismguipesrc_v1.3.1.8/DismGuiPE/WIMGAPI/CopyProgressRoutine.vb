Namespace WIMGAPI
    'DWORD CALLBACK CopyProgressRoutine(
    '_In_      LARGE_INTEGER TotalFileSize,
    '_In_      LARGE_INTEGER TotalBytesTransferred,
    '_In_      LARGE_INTEGER StreamSize,
    '_In_      LARGE_INTEGER StreamBytesTransferred,
    '_In_      DWORD dwStreamNumber,
    '_In_      DWORD dwCallbackReason,
    '_In_      HANDLE hSourceFile,
    '_In_      HANDLE hDestinationFile,
    '_In_opt_  LPVOID lpData
    ');
    Public Delegate Function CopyProgressRoutine(TotalFileSize As Long,
                                                 TotalBytesTransferred As Long,
                                                 StreamSize As Long,
                                                 StreamBytesTransferred As Long,
                                                 dwStreamNumber As Int32,
                                                 dwCallbackReason As Int32,
                                                 hSourceFile As IntPtr,
                                                 hDestinationFile As IntPtr,
                                                 lpData As IntPtr) As Int32
End Namespace
