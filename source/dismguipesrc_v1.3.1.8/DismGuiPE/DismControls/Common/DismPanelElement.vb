''' <summary>
''' 表示用于管理Dism面板的基础单元
''' </summary>
''' <remarks></remarks>
Public Class DismPanelElement

    ''' <summary>
    ''' 获取或者设置单元按钮
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TaskButton As RadioButton

    ''' <summary>
    ''' 获取或者设置Dism面板控件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Panel As IDismControl

    ''' <summary>
    ''' 获取或者设置默认映像信息标识
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DefaultUpdateInfo As WimInfoDetail

    ''' <summary>
    ''' 获取或者设置单元名称
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Name As String = ""

    ''' <summary>
    ''' 获取或者设置单元文本
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Text As String = ""

    ''' <summary>
    ''' 创建Dism面板管理单元
    ''' </summary>
    ''' <param name="Name">单元名称</param>
    ''' <param name="DefaultUpdateInfo">默认映像信息</param>
    ''' <param name="Text">单元文本</param>
    ''' <param name="Panel">Dism面板控件</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Create(Name As String, DefaultUpdateInfo As WimInfoDetail, Text As String, Panel As IDismControl)
        Dim RB As New RadioButton() With {.Name = "RB_" & Name.ToUpper}
        RB.Appearance = Appearance.Button
        RB.BackColor = Color.White
        RB.FlatStyle = FlatStyle.Flat
        RB.FlatAppearance.BorderColor = Color.DodgerBlue
        RB.FlatAppearance.BorderSize = 1
        RB.FlatAppearance.CheckedBackColor = Color.LightSkyBlue
        RB.FlatAppearance.MouseDownBackColor = Color.DeepSkyBlue
        RB.FlatAppearance.MouseOverBackColor = Color.LightSkyBlue
        RB.Text = Text
        RB.TextAlign = ContentAlignment.MiddleCenter
        RB.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right

        Panel.Name = "Panel_" & Name
        Panel.Dock = DockStyle.Fill
        Panel.Title = Text
        Return New DismPanelElement() With {.Name = Name, .DefaultUpdateInfo = DefaultUpdateInfo, .TaskButton = RB, .Panel = Panel}
    End Function

End Class
