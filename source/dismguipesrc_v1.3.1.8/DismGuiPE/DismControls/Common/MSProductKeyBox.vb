Imports System.Text.RegularExpressions
''' <summary>
''' 微软序列号文本控件，继承于TextBox。
''' </summary>
''' <remarks></remarks>
Public Class MSProductKeyBox
    Inherits TextBox

    Private Const WM_RBUTTONDOWN As Integer = &H204 '鼠标右键按下事件
    Private Const WM_PASTE As Integer = &H302       '粘贴事件

    ''' <summary>
    ''' 创建微软序列号文本控件
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New()
    End Sub

    ''' <summary>
    ''' 重写按键事件
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
        Dim KeyCode As Integer = Asc(e.KeyChar)

        '允许复制组合键 Ctrl+C
        If KeyCode = 3 Then Return

        '允许粘贴组合键 Ctrl+V
        If KeyCode = 22 Then Return

        '允许剪切组合键 Ctrl+X
        If KeyCode = 24 Then Return

        '允许删除和退格键
        If KeyCode = Keys.Delete Or KeyCode = Keys.Back Then

            '若最后一个字符是 “-” 那么删除它
            If Me.Text.EndsWith("-") Then
                Me.Text = Me.Text.Remove(Me.Text.Length - 1, 1)
                Me.SelectionStart = Me.TextLength
            End If
            Return
        End If

        '如果字符串长度大于或者等于29，那么禁止再输入。
        If Me.TextLength >= 29 Then
            e.Handled = True
            Return
        End If

        '允许数字输入
        If KeyCode >= Keys.D0 And KeyCode <= Keys.D9 Then
            '如果长度够，那么自动补充“-”
            If Me.Text.Length = 5 Or Me.Text.Length = 11 Or Me.Text.Length = 17 Or Me.Text.Length = 23 Then
                Me.Text &= "-"
                Me.SelectionStart = Me.TextLength
            End If
            Return
        End If

        '允许输入大写字母
        If KeyCode >= Keys.A And KeyCode <= Keys.Z Then
            '如果长度够，那么自动补充“-”
            If Me.Text.Length = 5 Or Me.Text.Length = 11 Or Me.Text.Length = 17 Or Me.Text.Length = 23 Then
                Me.Text &= "-"
                Me.SelectionStart = Me.TextLength
            End If
            Return
        End If

        '允许输入小写字母并且自动转换为大写字母
        If KeyCode >= (Keys.A + 32) And KeyCode <= (Keys.Z + 32) Then
            e.KeyChar = Chr(KeyCode - 32)
            '如果长度够，那么自动补充“-”
            If Me.Text.Length = 5 Or Me.Text.Length = 11 Or Me.Text.Length = 17 Or Me.Text.Length = 23 Then
                Me.Text &= "-"
                Me.SelectionStart = Me.TextLength
            End If
            Return
        End If
        e.Handled = True
    End Sub

    ''' <summary>
    ''' 拦截消息
    ''' </summary>
    ''' <param name="m"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub WndProc(ByRef m As Message)
        '如果检测到粘贴消息，使用正则表达式检查粘贴的Key是否合法，若不合法拦截该事件。
        If m.Msg = WM_PASTE Then
            Try
                Dim Temp As String = Clipboard.GetText().Trim()
                If Temp.Length <> 29 Then Return
                Temp = Temp.ToUpper()
                Dim R As New Regex("[A-Z0-9]{5,5}\-[A-Z0-9]{5,5}\-[A-Z0-9]{5,5}\-[A-Z0-9]{5,5}\-[A-Z0-9]{5,5}")
                Dim RM As Match = R.Match(Temp)
                If IsNothing(RM) OrElse Not RM.Success Then Return
            Catch ex As Exception

            End Try
        End If
        MyBase.WndProc(m)
    End Sub
End Class
