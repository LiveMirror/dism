''' <summary>
''' 表示任务队列管理器
''' </summary>
''' <remarks></remarks>
<Serializable> Public Class DismQueueManager
    Inherits List(Of DismControlEventArgs)

    ''' <summary>
    ''' 交换队列位置
    ''' </summary>
    ''' <param name="Dest">目标索引</param>
    ''' <param name="Src">源索引</param>
    ''' <remarks></remarks>
    Public Sub Swap(Dest As Integer, Src As Integer)
        If Dest > Me.Count - 1 Or Src > Me.Count - 1 Or Dest = Src Then Return
        Dim Temp As DismControlEventArgs = Me(Dest)
        Me(Dest) = Me(Src)
        Me(Src) = Temp
    End Sub

    ''' <summary>
    ''' 将指定项移至任务队列首位
    ''' </summary>
    ''' <param name="Index">索引</param>
    ''' <remarks></remarks>
    Public Sub MoveToTop(Index As Integer)
        If Index > Me.Count - 1 Or Index <= 0 Then Return
        Swap(0, Index)
    End Sub

    ''' <summary>
    ''' 将指定项移至任务队列的末端
    ''' </summary>
    ''' <param name="Index">索引</param>
    ''' <remarks></remarks>
    Public Sub MoveToBottom(Index As Integer)
        If Index >= Me.Count - 1 Or Index < 0 Then Return
        Swap(Me.Count - 1, Index)
    End Sub

    ' ''' <summary>
    ' ''' 添加任务
    ' ''' </summary>
    ' ''' <param name="e">Dism面板控件事件数据</param>
    ' ''' <remarks></remarks>
    'Public Overloads Sub Add(e As DismControlEventArgs)
    '    Add(e)
    'End Sub

    ''' <summary>
    ''' 将队列填充到DataGridView控件之中
    ''' </summary>
    ''' <param name="DG">DataGridView控件</param>
    ''' <remarks></remarks>
    Public Sub FillDataGridView(DG As DataGridView)
        DG.Rows.Clear()
        For i As Integer = 0 To Count - 1
            DG.Rows.Add(Me(i).Date.ToString("yyyy-MM-dd HH:mm:ss"), Me(i).Mission.ToString, Me(i).Description, Me(i).HookMessage, Me(i).Arguments)
        Next
    End Sub

End Class
