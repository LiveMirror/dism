Imports System.ComponentModel
''' <summary>
''' .WIM 文件选择控件
''' </summary>
''' <remarks></remarks>
Public Class WimFileSelector

    Private mWimInfoComboBox As WimInfoComboBox = Nothing

    ''' <summary>
    ''' 已选定文件事件
    ''' </summary>
    ''' <remarks></remarks>
    Public Event FileSelected As EventHandler

    Public Property FilterIndex As Integer = 0

    ''' <summary>
    ''' 获取或者设置控件字体
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows Property Font As Font
        Get
            Return TBPath.Font
        End Get
        Set(value As Font)
            TBPath.Font = value
        End Set
    End Property

    ''' <summary>
    ''' 获取或者设置关联文本
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(True)> _
    Public Shadows Property Text As String
        Get
            Return TBPath.Text
        End Get
        Set(value As String)
            TBPath.Text = value
            If Not IsNothing(mWimInfoComboBox) Then mWimInfoComboBox.UpdateWimInfo(TBPath.Text)
        End Set
    End Property

    ''' <summary>
    ''' 获取或者设置一个标识，指示是否显示为保存文件对话框。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows Property ShowAsSaveFileDialog As Boolean = False

    ''' <summary>
    ''' 获取或者设置 .WIM 文件信息控件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WimInfoControl As WimInfoComboBox
        Get
            Return mWimInfoComboBox
        End Get
        Set(value As WimInfoComboBox)

            If IsNothing(mWimInfoComboBox) OrElse Not mWimInfoComboBox.Equals(value) Then
                mWimInfoComboBox = value
                If Not IsNothing(mWimInfoComboBox) Then mWimInfoComboBox.UpdateWimInfo(Me.Text)
            End If

        End Set
    End Property

    Public Property IsEsdFile As Boolean = False

#Region "控件内事件"

    ''' <summary>
    ''' 浏览 .WIM 文件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnBrowser_Click(sender As Object, e As EventArgs) Handles BtnBrowser.Click
        If Me.ShowAsSaveFileDialog Then
            ShowFileSave(e)
        Else
            ShowFileOpen(e)
        End If
    End Sub

    ''' <summary>
    ''' 显示保存文件对话框
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ShowFileSave(e As EventArgs)
        Dim cd As New FileDialog(False)
        If Not IsEsdFile Then
            cd.Filter = "映像文件(*.Wim)|*.Wim|映像分卷文件(*.SWM)|*.SWM|所有文件(*.*)|*.*"
        Else
            cd.Filter = "映像文件(*.Esd)|*.Esd|所有文件(*.*)|*.*"
        End If

        'cd.CheckFileExists = False
        cd.OverwritePrompt = False
        cd.FilterIndex = FilterIndex
        Dim Temp As String = TBPath.Text.Trim()
        If Temp.LastIndexOf("\") >= 0 Then
            Temp = Temp.Substring(0, Temp.LastIndexOf("\"))
            If IO.Directory.Exists(Temp) Then cd.InitialDirectory = Temp
        End If
        If cd.ShowDialog = DialogResult.OK Then
            TBPath.Text = cd.FileName
            If Not IsNothing(mWimInfoComboBox) Then mWimInfoComboBox.UpdateWimInfo(TBPath.Text)
            RaiseEvent FileSelected(Me, e)
        End If
        cd.Dispose()
        cd = Nothing
    End Sub

    ''' <summary>
    ''' 显示打开文件对话框
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ShowFileOpen(e As EventArgs)
        Dim cd As New FileDialog()
        If Not IsEsdFile Then
            cd.Filter = "映像文件(*.Wim)|*.Wim|映像分卷文件(*.SWM)|*.SWM|所有文件(*.*)|*.*"
        Else
            cd.Filter = "映像文件(*.Esd)|*.Esd|所有文件(*.*)|*.*"
        End If
        cd.FilterIndex = FilterIndex
        Dim Temp As String = TBPath.Text.Trim()
        If Temp.LastIndexOf("\") >= 0 Then
            Temp = Temp.Substring(0, Temp.LastIndexOf("\"))
            If IO.Directory.Exists(Temp) Then cd.InitialDirectory = Temp
        End If
        If cd.ShowDialog = DialogResult.OK Then
            TBPath.Text = cd.FileName
            If Not IsNothing(mWimInfoComboBox) Then mWimInfoComboBox.UpdateWimInfo(TBPath.Text)
            RaiseEvent FileSelected(Me, e)
        End If
        cd.Dispose()
        cd = Nothing
    End Sub

    ''' <summary>
    ''' 调整控件大小
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub WimFileSelector_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        TBPath.Location = New Point(0, (Me.Height - TBPath.Height) / 2)
    End Sub

    Private Sub TBPath_Validated(sender As Object, e As EventArgs) Handles TBPath.Validated
        If Not IsNothing(mWimInfoComboBox) Then mWimInfoComboBox.UpdateWimInfo(TBPath.Text)
    End Sub

#End Region



End Class
