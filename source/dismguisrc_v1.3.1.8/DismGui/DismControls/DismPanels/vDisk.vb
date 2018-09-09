Public Class vDisk
    Private mInitialDirectory As String = ""
    Private mFileName As String = Guid.NewGuid.ToString & ".vhd"
    Private mPath As String = ""
    Private mEmptyDriveLetter As String = GetEmptyDriveLetter()
    Public ReadOnly Property InitialDirectory As String
        Get
            Return mInitialDirectory
        End Get
    End Property

    Public ReadOnly Property Path As String
        Get
            Return mPath
        End Get
    End Property

    Public ReadOnly Property Drive As String
        Get
            Return mEmptyDriveLetter & ":\"
        End Get
    End Property

    Public Sub New(InitialDirectory As String)
        mInitialDirectory = InitialDirectory
        If Not mInitialDirectory.EndsWith("\") Then mInitialDirectory &= "\"
        mPath = mInitialDirectory & mFileName
    End Sub

    Public Shared Function GetEmptyDriveLetter() As String
        Dim dis() As IO.DriveInfo = IO.DriveInfo.GetDrives()
        If IsNothing(dis) OrElse dis.Length = 0 Then Return "Z"
        Dim lsExists() As String = (From e As IO.DriveInfo In dis Select e.Name.Substring(0, 1).ToUpper).ToArray
        Dim ls As Char() = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        For i As Integer = ls.GetUpperBound(0) To 0 Step -1
            If Not lsExists.Contains(ls(i)) Then Return ls(i)
        Next
        Return ""
    End Function

    Public Function Create(Maximum As Integer, Optional Expandable As Boolean = True)
        Dim Temp As String = "CREATE VDISK FILE=""" & mPath & """ MAXIMUM=" & Maximum & " TYPE=" & IIf(Expandable, "EXPANDABLE", "FIXED") & " NOERR" & vbCrLf &
                             "SELECT VDISK FILE=""" & mPath & """" & vbCrLf &
                             "ATTACH VDISK" & vbCrLf &
                             "CLEAN" & vbCrLf &
                             "CREATE PARTITION PRIMARY" & vbCrLf &
                             "FORMAT FS=NTFS QUICK" & vbCrLf &
                             "ASSIGN LETTER=" & mEmptyDriveLetter & vbCrLf &
                             "EXIT"
        Dim ExitCode As Integer = Execute(Temp)
        Return ExitCode
    End Function

    Public Function Clean() As Integer
        Dim Temp As String = "SELECT VDISK FILE=""" & mPath & """" & vbCrLf &
                             "ATTACH VDISK" & vbCrLf &
                             "CLEAN" & vbCrLf &
                             "CREATE PARTITION PRIMARY" & vbCrLf &
                             "FORMAT FS=NTFS QUICK" & vbCrLf &
                             "ASSIGN LETTER=" & mEmptyDriveLetter & vbCrLf &
                             "EXIT"
        Dim ExitCode As Integer = Execute(Temp)
        Return ExitCode
    End Function

    Public Function Kill() As Integer
        Dim Temp As String = "SELECT VDISK FILE=""" & mPath & """" & vbCrLf &
                             "DETACH VDISK" & vbCrLf &
                             "EXIT"
        Dim ExitCode As Integer = Execute(Temp)
        If IO.File.Exists(mPath) Then IO.File.Delete(mPath)
        Return ExitCode
    End Function

    Private Function Execute(Arguments As String) As Integer

        Dim Temp As String = Application.StartupPath
        If Not Temp.EndsWith("\") Then Temp &= "\"
        Temp = Temp & Guid.NewGuid.ToString() & ".dps"
        Dim fs As New IO.FileStream(Temp, IO.FileMode.OpenOrCreate)
        Dim Byt() As Byte = System.Text.Encoding.Default.GetBytes(Arguments)
        fs.Write(Byt, 0, Byt.Length)
        fs.Flush()
        fs.Close()

        Dim p As New Process()
        With p.StartInfo
            .FileName = "Diskpart.exe"
            .CreateNoWindow = True
            .UseShellExecute = False
            .Arguments = "/s """ & Temp & """"
        End With
        p.Start()
        p.WaitForExit()
        Dim ExitCode As Integer = p.ExitCode
        p.Dispose()

        If IO.File.Exists(Temp) Then IO.File.Delete(Temp)
        Return ExitCode
    End Function
End Class
