''' <summary>
''' 表示在执行DismShell中的函数时出现的异常信息
''' </summary>
''' <remarks></remarks>
Public Class DismException

    ''' <summary>
    '''  获取或者设置退出代码
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ExitCode As Integer = 0

    ''' <summary>
    ''' 获取或者设置异常信息对象
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Exception As Exception = Nothing

    ''' <summary>
    ''' 创建在执行DismShell中的函数时出现的异常信息对象
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

    End Sub

    ''' <summary>
    ''' 创建在执行DismShell中的函数时出现的异常信息对象
    ''' </summary>
    ''' <param name="ExitCode">退出代码</param>
    ''' <remarks></remarks>
    Public Sub New(ExitCode As Integer)
        Me.ExitCode = ExitCode
    End Sub

    ''' <summary>
    ''' 创建在执行DismShell中的函数时出现的异常信息对象
    ''' </summary>
    ''' <param name="ExitCode">退出代码</param>
    ''' <param name="Exception">错误信息对象</param>
    ''' <remarks></remarks>
    Public Sub New(ExitCode As Integer, Exception As Exception)
        Me.ExitCode = ExitCode : Me.Exception = Exception
    End Sub

    ''' <summary>
    ''' 创建在执行DismShell中的函数时出现的异常信息对象
    ''' </summary>
    ''' <param name="ExitCode">退出代码</param>
    ''' <param name="Message">错误信息</param>
    ''' <remarks></remarks>
    Public Sub New(ExitCode As Integer, Message As String)
        Me.ExitCode = ExitCode : Me.Exception = New Exception(Message)
    End Sub

    ''' <summary>
    ''' 创建在执行DismShell中的函数时出现的异常信息对象
    ''' </summary>
    ''' <param name="ExitCode">退出代码</param>
    ''' <param name="Message">错误信息</param>
    ''' <param name="paramName">参数名称</param>
    ''' <remarks></remarks>
    Public Sub New(ExitCode As Integer, Message As String, paramName As String)
        Me.ExitCode = ExitCode : Me.Exception = New ArgumentException(Message, paramName)
    End Sub

    ''' <summary>
    ''' 将错误信息转化为字符串
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Dim Temp As String = "ExitCode: " & ExitCode
        If Me.Exception IsNot Nothing Then Temp = Temp & vbCrLf & Me.Exception.ToString()
        Return Temp
    End Function

    ''' <summary>
    ''' 获取错误信息
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Message As String
        Get
            Dim Temp As String = "ExitCode: " & ExitCode
            If Me.Exception IsNot Nothing Then Temp = Temp & vbCrLf & Me.Exception.Message
            Return Temp
        End Get
    End Property

    ''' <summary>
    ''' 定义不等于操作符
    ''' </summary>
    ''' <param name="Left">Dism错误对象</param>
    ''' <param name="Right">退出代码</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Operator <>(Left As DismException, Right As Integer) As Boolean
        Return Not (Left = Right)
    End Operator

    ''' <summary>
    ''' 定义等于操作符
    ''' </summary>
    ''' <param name="Left">Dism错误对象</param>
    ''' <param name="Right">错误代码</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Operator =(Left As DismException, Right As Integer) As Boolean
        Return ((Left IsNot Nothing) AndAlso Left.ExitCode = Right)
    End Operator


End Class
