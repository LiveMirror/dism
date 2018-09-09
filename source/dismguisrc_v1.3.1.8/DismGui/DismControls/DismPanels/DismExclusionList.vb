''' <summary>
''' 表示捕获映像时的排除列表
''' </summary>
''' <remarks></remarks>
Public Class DismExclusionList

    '排除列表存放目录
    Private ExclusionListDir As String = IIf(Application.StartupPath.EndsWith("\"),
                                             Application.StartupPath,
                                             Application.StartupPath & "\") & "ExclusionList"
    '对象ID
    Private ID As Guid = Guid.NewGuid()

    '排除列表存放路径
    Private mFileName As String = ExclusionListDir & "\" & ID.ToString() & ".txt"

    ''' <summary>
    ''' 排除项类型
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ExclusionItemType
        ''' <summary>
        ''' 要排除的文件和文件夹
        ''' </summary>
        ''' <remarks></remarks>
        Normal = 0
        ''' <summary>
        ''' 替代默认排除列表
        ''' </summary>
        ''' <remarks></remarks>
        Exception
        ''' <summary>
        ''' 启用压缩参数时排除的特定文件和文件夹（也可以指定文件类型）
        ''' </summary>
        ''' <remarks></remarks>
        Compress
    End Enum

    '具体定义请参照：http://technet.microsoft.com/zh-cn/library/hh825006.aspx

    Private mExclusionList As New List(Of String)           '定义要排除的文件和文件夹
    Private mExclusionExceptionList As New List(Of String)  '替代默认排除列表
    Private mCompressExclusionList As New List(Of String)   '使你可以在使用 /Compress 参数时定义要排除的特定文件和文件夹（也可以指定文件类型）

    ''' <summary>
    ''' 创建捕获映像时的排除列表对象
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        If Not IO.Directory.Exists(ExclusionListDir) Then IO.Directory.CreateDirectory(ExclusionListDir)
    End Sub

    ''' <summary>
    ''' 获取一个标识，指示排除项列表是否为空.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsEmpty As Boolean
        Get
            Return (mExclusionList.Count + mExclusionExceptionList.Count + mCompressExclusionList.Count) = 0
        End Get
    End Property

    ''' <summary>
    ''' 获取排除列表文件路径
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FileName As String
        Get
            Return mFileName
        End Get
    End Property

    ''' <summary>
    ''' 获取排除列表项
    ''' </summary>
    ''' <param name="et">排除列表类型</param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Default Public ReadOnly Property Items(et As ExclusionItemType) As String()
        Get
            Select Case et
                Case ExclusionItemType.Normal
                    Return mExclusionList.ToArray()
                Case ExclusionItemType.Exception
                    Return mExclusionExceptionList.ToArray()
                Case ExclusionItemType.Compress
                    Return mCompressExclusionList.ToArray()
                Case Else
                    Return mExclusionList.ToArray()
            End Select
        End Get
    End Property

    ''' <summary>
    ''' 添加排除项
    ''' </summary>
    ''' <param name="et">排除列表类型</param>
    ''' <param name="Exclusion">排除路径、相对路径或文件类型</param>
    ''' <remarks></remarks>
    Public Sub Add(et As ExclusionItemType, Exclusion As String)
        Select Case et
            Case ExclusionItemType.Normal
                mExclusionList.Add(Exclusion)
            Case ExclusionItemType.Exception
                mExclusionExceptionList.Add(Exclusion)
            Case ExclusionItemType.Compress
                mCompressExclusionList.Add(Exclusion)
            Case Else
                mExclusionList.Add(Exclusion)
        End Select
    End Sub

    ''' <summary>
    ''' 删除排除项
    ''' </summary>
    ''' <param name="et">排除列表类型</param>
    ''' <param name="Exclusion">排除路径、相对路径或文件类型</param>
    ''' <remarks></remarks>
    Public Sub Remove(et As ExclusionItemType, Exclusion As String)
        Select Case et
            Case ExclusionItemType.Normal
                mExclusionList.Remove(Exclusion)
            Case ExclusionItemType.Exception
                mExclusionExceptionList.Remove(Exclusion)
            Case ExclusionItemType.Compress
                mCompressExclusionList.Remove(Exclusion)
            Case Else
                mExclusionList.Remove(Exclusion)
        End Select
    End Sub

    ''' <summary>
    ''' 删除排除项
    ''' </summary>
    ''' <param name="et">排除列表类型</param>
    ''' <param name="Index">索引</param>
    ''' <remarks></remarks>
    Public Sub RemoveAt(et As ExclusionItemType, Index As Integer)
        Select Case et
            Case ExclusionItemType.Normal
                mExclusionList.RemoveAt(Index)
            Case ExclusionItemType.Exception
                mExclusionExceptionList.RemoveAt(Index)
            Case ExclusionItemType.Compress
                mCompressExclusionList.RemoveAt(Index)
            Case Else
                mExclusionList.RemoveAt(Index)
        End Select
    End Sub

    ''' <summary>
    ''' 清除排除项
    ''' </summary>
    ''' <param name="et">排除列表类型</param>
    ''' <remarks></remarks>
    Public Sub Clear(et As ExclusionItemType)
        Select Case et
            Case ExclusionItemType.Normal
                mExclusionList.Clear()
            Case ExclusionItemType.Exception
                mExclusionExceptionList.Clear()
            Case ExclusionItemType.Compress
                mCompressExclusionList.Clear()
            Case Else
                mExclusionList.Clear()
        End Select
    End Sub

    ''' <summary>
    ''' 清除排除项
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()
        mExclusionList.Clear()
        mExclusionExceptionList.Clear()
        mCompressExclusionList.Clear()
    End Sub

    ''' <summary>
    ''' 查找排除项
    ''' </summary>
    ''' <param name="et">排除列表类型</param>
    ''' <param name="Exclusion">排除路径、相对路径或文件类型</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FindIndex(et As ExclusionItemType, Exclusion As String) As Integer
        Select Case et
            Case ExclusionItemType.Normal
                For i As Integer = 0 To mExclusionList.Count - 1
                    If String.Compare(Exclusion, mExclusionList(i), True) = 0 Then Return i
                Next
            Case ExclusionItemType.Exception
                For i As Integer = 0 To mExclusionExceptionList.Count - 1
                    If String.Compare(Exclusion, mExclusionExceptionList(i), True) = 0 Then Return i
                Next
            Case ExclusionItemType.Compress
                For i As Integer = 0 To mCompressExclusionList.Count - 1
                    If String.Compare(Exclusion, mCompressExclusionList(i), True) = 0 Then Return i
                Next
            Case Else
                For i As Integer = 0 To mExclusionList.Count - 1
                    If String.Compare(Exclusion, mExclusionList(i), True) = 0 Then Return i
                Next
        End Select
        Return -1
    End Function

    ''' <summary>
    ''' 将排除列表写入文件
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SaveToFile()
        Dim fs As New IO.FileStream(mFileName, IO.FileMode.OpenOrCreate, IO.FileAccess.ReadWrite)
        Dim Temp As String = "[ExclusionList]" & vbCrLf
        For Each e As String In mExclusionList
            Temp &= (e & vbCrLf)
        Next
        Temp &= ("[ExclusionException]" & vbCrLf)
        For Each e As String In mExclusionExceptionList
            Temp &= (e & vbCrLf)
        Next
        Temp &= ("[CompressionExclusionList]" & vbCrLf)
        For Each e As String In mCompressExclusionList
            Temp &= (e & vbCrLf)
        Next
        Dim Byt() As Byte = System.Text.Encoding.Unicode.GetBytes(Temp)
        fs.Write(Byt, 0, Byt.Length)
        fs.Flush()
        fs.Close()
        Erase Byt
    End Sub

    ''' <summary>
    ''' 从文件加载排除列表
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadFromFile()

    End Sub

    ''' <summary>
    ''' 释放资源
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub Finalize()
        Dim Files() As String = IO.Directory.GetFiles(ExclusionListDir)
        For Each e As String In Files
            Try
                IO.File.Delete(e)
            Catch ex As Exception

            End Try
        Next
        MyBase.Finalize()
    End Sub

End Class
