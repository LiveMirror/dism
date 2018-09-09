''' <summary>
''' 表示异步操作数据对象
''' </summary>
''' <remarks></remarks>
<Serializable> Public Class DismAsyncObject
    Public sender As IDismControl
    Public e As DismControlEventArgs
    Public [Date] As Date = Now

    Public Sub New(sender As IDismControl, e As DismControlEventArgs)
        Me.sender = sender : Me.e = e
    End Sub

End Class