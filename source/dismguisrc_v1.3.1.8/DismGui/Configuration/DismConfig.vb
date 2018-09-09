Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
''' <summary>
''' 配置文件类
''' </summary>
''' <remarks></remarks>
Public Class DismConfig

    Private Shared HasLoaded As Boolean = False
    Private Shared mHash As New Hashtable
    Private Shared Path As String = Application.ExecutablePath & ".cfg"

    ''' <summary>
    ''' 获取配置个数
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property Count As Integer
        Get
            If Not HasLoaded Then
                ReLoad()
                HasLoaded = True
            End If
            Return mHash.Count
        End Get
    End Property

    ''' <summary>
    ''' 重新载入配置文件
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub ReLoad()
        Dim IsGotSomeErrors As Boolean = False
        If Not HasLoaded Then HasLoaded = True
        If Not File.Exists(Path) Then Return
        Try
            Dim bf As New BinaryFormatter
            Dim fs As New FileStream(Path, FileMode.OpenOrCreate)
            Try
                mHash = bf.Deserialize(fs)
            Catch ex As Exception
                IsGotSomeErrors = True
            End Try
            fs.Close()
        Catch ex As Exception
            IsGotSomeErrors = True
        End Try
        If IsGotSomeErrors Then
            Try
                IO.File.Delete(Path)
            Catch ex As Exception

            End Try
        End If
    End Sub

    ''' <summary>
    ''' 将配置保存到文件中
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub Save()
        Dim bf As New BinaryFormatter
        Dim fs As New FileStream(Path, FileMode.OpenOrCreate)
        bf.Serialize(fs, mHash)
        fs.Flush()
        fs.Close()
    End Sub

    ''' <summary>
    ''' 清除所有配置
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub Clear()
        mHash.Clear()
    End Sub

    ''' <summary>
    ''' 获取配置值
    ''' </summary>
    ''' <param name="Name">名称</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetItem(Name As String) As Object
        If Not HasLoaded Then
            ReLoad()
            HasLoaded = True
        End If
        Return GetItem(Name, Nothing)
    End Function

    ''' <summary>
    ''' 获取配置值
    ''' </summary>
    ''' <param name="Name">名称</param>
    ''' <param name="Default">默认值</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetItem(Name As String, [Default] As Object) As Object
        If Not HasLoaded Then
            ReLoad()
            HasLoaded = True
        End If
        If mHash.ContainsKey(Name) Then
            Return mHash(Name)
        Else
            mHash.Add(Name, [Default])
            Return [Default]
        End If
    End Function

    ''' <summary>
    ''' 设置配置值
    ''' </summary>
    ''' <param name="Name">名称</param>
    ''' <param name="Value">值</param>
    ''' <remarks></remarks>
    Public Shared Sub SetItem(Name As String, Value As Object)
        If Not HasLoaded Then
            ReLoad()
            HasLoaded = True
        End If
        If mHash.ContainsKey(Name) Then
            mHash(Name) = Value
        Else
            mHash.Add(Name, Value)
        End If
    End Sub

End Class

