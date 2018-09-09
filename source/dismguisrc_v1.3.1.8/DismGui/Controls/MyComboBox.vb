Imports System
Imports System.ComponentModel
Imports System.Reflection
Public Class MyComboBox
    Inherits ComboBox

    Private mDropDownItemHeight As Integer = 60
    Private mDrawItemHandler As DrawItemEventHandler = Nothing

    Private mDisplayMember As String = ""

    Public Sub New()
        MyBase.MaxDropDownItems = 5
        MyBase.DrawMode = Windows.Forms.DrawMode.OwnerDrawVariable

    End Sub

    Public Property DropDownItemHeight As Integer
        Get
            Return mDropDownItemHeight
        End Get
        Set(value As Integer)
            mDropDownItemHeight = value
            LayoutItems()
        End Set
    End Property

    Public Shadows Property DisplayMember As String
        Get
            Return mDisplayMember
        End Get
        Set(value As String)
            mDisplayMember = value
            MyBase.DisplayMember = mDisplayMember
        End Set
    End Property

    Public Shadows Property MaxDropDownItems As Integer
        Get
            Return MyBase.MaxDropDownItems
        End Get
        Set(value As Integer)
            MyBase.MaxDropDownItems = value
            LayoutItems()
        End Set
    End Property

    Public Shadows Property DropDownWidth As Integer
        Get
            Return MyBase.DropDownWidth
        End Get
        Set(value As Integer)
            If value < 1 Then Return
            MyBase.DropDownWidth = value
        End Set
    End Property

    <Browsable(False)> _
    Public Property DrawItemHandler As DrawItemEventHandler
        Get
            Return mDrawItemHandler
        End Get
        Set(value As DrawItemEventHandler)
            mDrawItemHandler = value
        End Set
    End Property

    Public Shadows Property DataSource As Object
        Get
            Return MyBase.DataSource
        End Get
        Set(value As Object)
            MyBase.DataSource = value
            MyBase.DisplayMember = mDisplayMember
            LayoutItems()
        End Set
    End Property

    Public Function Exists() As Boolean
        Return Exists(Me.Text)

    End Function

    Public Function Exists(Text As String) As Boolean
        Return Exists(Text, Me.DisplayMember)
    End Function

    Public Function Exists(Text As String, Member As String) As Boolean
        Return FindIndex(Text, Member) > -1
    End Function

    Public Function FindIndex(Value As Object, Member As String) As Integer
        If MyBase.Items.Count = 0 Then Return -1
        For i As Integer = 0 To MyBase.Items.Count - 1
            If Value.Equals(GetObjectValue(MyBase.Items(i), Member)) Then Return i
        Next
        Return -1
    End Function

    Public Function FindIndex(Value As Object) As Integer
        Return FindIndex(Value, Me.DisplayMember)
    End Function

    'Public Shadows Property Text As String
    '    Get
    '        Return MyBase.Text
    '    End Get
    '    Set(value As String)
    '        MyBase.Text = value
    '    End Set
    'End Property

    Protected Overrides Sub OnMeasureItem(e As MeasureItemEventArgs)
        e.ItemHeight = mDropDownItemHeight
        MyBase.OnMeasureItem(e)
    End Sub

    Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
        If mDrawItemHandler IsNot Nothing Then mDrawItemHandler(Me, e)
        MyBase.OnDrawItem(e)
    End Sub

    Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
        'Me.Text = MyBase.SelectedText
        MyBase.OnSelectedIndexChanged(e)
    End Sub

    Private Sub LayoutItems()
        Dim Count As Integer = MyBase.Items.Count
        If Count < MyBase.MaxDropDownItems Then
            MyBase.DropDownHeight = Count * mDropDownItemHeight + 3
        Else
            MyBase.DropDownHeight = MyBase.MaxDropDownItems * mDropDownItemHeight + 3
        End If
    End Sub

    Private Function GetObjectValue(Item As Object, Member As String) As Object
        If IsNothing(Member) OrElse Member = "" Then Return Item
        Dim T As Type = Item.GetType
        If T.IsValueType Then Return Item
        If T.IsClass Then
            Dim Ts() As Type = {}
            Dim pInfo As PropertyInfo = T.GetProperty(Member, Ts)
            If Not IsNothing(pInfo) Then Return pInfo.GetValue(Item, Nothing)

            Dim DefaultPropertyName As String = ""
            If HasDefaultProperty(T, DefaultPropertyName) Then
                Ts = {GetType(String)}
                pInfo = T.GetProperty(DefaultPropertyName, Ts)
                If Not IsNothing(pInfo) Then
                    Return pInfo.GetValue(Item, New Object() {Member})
                End If
            End If
        End If
        Return Item
    End Function

    Private Function HasDefaultProperty(T As Type, ByRef DefaultPropertyName As String) As Boolean
        For Each m As MemberInfo In T.GetDefaultMembers()
            If m.MemberType = MemberTypes.Property Then
                DefaultPropertyName = m.Name
                Return True
            End If
        Next
        Return False
    End Function

End Class
