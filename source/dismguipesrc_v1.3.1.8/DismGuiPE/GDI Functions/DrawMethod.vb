Imports System.Drawing
Imports System.Drawing.Drawing2D
''' <summary>
''' 封装一些常用的GDI绘图函数
''' </summary>
''' <remarks></remarks>
Public Class DrawMethod

    ''' <summary>
    ''' 绘制文本
    ''' </summary>
    ''' <param name="e">GDI+绘图图面</param>
    ''' <param name="Text">文本</param>
    ''' <param name="Font">字体</param>
    ''' <param name="Color">颜色</param>
    ''' <param name="Rect">绘制区域</param>
    ''' <param name="TextAlignment">对齐方式</param>
    ''' <remarks></remarks>
    Public Shared Sub DrawText(e As Graphics,
                               Text As String,
                               Font As Font,
                               Color As Color,
                               Rect As Rectangle,
                               TextAlignment As ContentAlignment)
        Dim sf As StringFormat = GetStringFormat(TextAlignment)
        Dim Brush As New SolidBrush(Color)
        e.DrawString(Text, Font, Brush, Rect, sf)
        Brush.Dispose()
        sf.Dispose()
    End Sub

    ''' <summary>
    ''' 绘制文本
    ''' </summary>
    ''' <param name="e">GDI+绘图图面</param>
    ''' <param name="Text">文本</param>
    ''' <param name="Font">字体</param>
    ''' <param name="Color">颜色</param>
    ''' <param name="Rect">绘制区域</param>
    ''' <param name="TextAlignment">对齐方式</param>
    ''' <param name="FormatFlags">文本字符串的显示和布局信息</param>
    ''' <remarks></remarks>
    Public Shared Sub DrawText(e As Graphics,
                               Text As String,
                               Font As Font,
                               Color As Color,
                               Rect As Rectangle,
                               TextAlignment As ContentAlignment,
                               FormatFlags As StringFormatFlags)
        Dim sf As StringFormat = GetStringFormat(TextAlignment)
        sf.FormatFlags = FormatFlags
        Dim Brush As New SolidBrush(Color)
        e.DrawString(Text, Font, Brush, Rect, sf)
        Brush.Dispose()
        sf.Dispose()
    End Sub

    ''' <summary>
    ''' 创建一个带圆角的矩形区域
    ''' </summary>
    ''' <param name="Rect">矩形区域</param>
    ''' <param name="Radius">圆角半径</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetRoundPath(Rect As Rectangle, Radius As Integer) As GraphicsPath

        Dim Path As New GraphicsPath
        Dim D As Integer = Radius + Radius
        Dim x1 As Integer = Rect.Left
        Dim y1 As Integer = Rect.Top
        Dim x2 As Integer = Rect.Right
        Dim y2 As Integer = Rect.Bottom

        Path.AddArc(New Rectangle(Rect.Location, New Size(D, D)), 180.0!, 90.0!)
        Path.AddLine(x1 + Radius, y1, x2 - Radius, y1)
        Path.AddArc(New Rectangle(x2 - D, y1, D, D), -90.0!, 90.0!)
        Path.AddLine(x2, y1 + Radius, x2, y2 - Radius)
        Path.AddArc(New Rectangle(x2 - D, y2 - D, D, D), 0.0!, 90.0!)
        Path.AddLine(x2 - Radius, y2, x1 + Radius, y2)
        Path.AddArc(New Rectangle(x1, y2 - D, D, D), 90.0!, 90.0!)
        Path.AddLine(x1, y2 - Radius, x1, y1 + Radius)
        Path.CloseAllFigures()

        Return Path
    End Function

    ''' <summary>
    ''' 获取文本字符串对齐方式
    ''' </summary>
    ''' <param name="TextAlignment">对齐方式</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetStringFormat(TextAlignment As ContentAlignment) As StringFormat
        Dim sf As New StringFormat
        Select Case TextAlignment
            Case ContentAlignment.BottomLeft
                sf.Alignment = StringAlignment.Near
                sf.LineAlignment = StringAlignment.Far
            Case ContentAlignment.BottomCenter
                sf.Alignment = StringAlignment.Center
                sf.LineAlignment = StringAlignment.Far
            Case ContentAlignment.BottomRight
                sf.Alignment = StringAlignment.Far
                sf.LineAlignment = StringAlignment.Far
            Case ContentAlignment.MiddleLeft
                sf.Alignment = StringAlignment.Near
                sf.LineAlignment = StringAlignment.Center
            Case ContentAlignment.MiddleCenter
                sf.Alignment = StringAlignment.Center
                sf.LineAlignment = StringAlignment.Center
            Case ContentAlignment.MiddleRight
                sf.Alignment = StringAlignment.Far
                sf.LineAlignment = StringAlignment.Center
            Case ContentAlignment.TopLeft
                sf.Alignment = StringAlignment.Near
                sf.LineAlignment = StringAlignment.Near
            Case ContentAlignment.TopCenter
                sf.Alignment = StringAlignment.Center
                sf.LineAlignment = StringAlignment.Near
            Case ContentAlignment.TopRight
                sf.Alignment = StringAlignment.Far
                sf.LineAlignment = StringAlignment.Near
            Case Else
                sf.Alignment = StringAlignment.Near
                sf.LineAlignment = StringAlignment.Near
        End Select
        Return sf
    End Function

End Class
