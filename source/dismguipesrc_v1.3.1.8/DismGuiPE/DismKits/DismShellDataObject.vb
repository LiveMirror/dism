Imports System.ComponentModel
''' <summary>
''' 表示Dism的数据对象,用于附加到进程Process对象.
''' </summary>
''' <remarks></remarks>
Public Class DismShellDataObject
    Implements ISite

    Public ReadOnly Property Component As IComponent Implements ISite.Component
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property Container As IContainer Implements ISite.Container
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property DesignMode As Boolean Implements ISite.DesignMode
        Get
            Return False
        End Get
    End Property

    Public Property Name As String Implements ISite.Name

    Public Function GetService(serviceType As Type) As Object Implements IServiceProvider.GetService
        Return Nothing
    End Function

    Public Property Data As List(Of String) = Nothing

End Class