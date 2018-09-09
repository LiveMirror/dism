Imports System.Runtime.InteropServices
Public Class FileDataGridView
    Inherits DataGridView
    Private mDirectory As String = ""
    Private mFilter As String = "所有文件（*.*）|*.*"
    Private mFilterCollection As New List(Of FilterElement)
    Private mFilterIndex As Integer = 0
    Private mList As New List(Of String)

    Private Structure FilterElement
        Public Extension As String
        Public Description As String
    End Structure

    Public Sub New()
        MyBase.New()
        MyBase.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        MyBase.RowHeadersVisible = True
        MyBase.RowHeadersWidth = 21
        MyBase.AllowUserToAddRows = False
        MyBase.AllowUserToDeleteRows = False
        MyBase.AllowUserToResizeColumns = False
        MyBase.ReadOnly = True
        MyBase.AllowUserToResizeRows = False
        MyBase.MultiSelect = False
        MyBase.CellBorderStyle = DataGridViewCellBorderStyle.None

        SplitFilters()
    End Sub


    Public Property Directory As String
        Get
            Return mDirectory
        End Get
        Set(value As String)
            mDirectory = value
            ListFiles()
        End Set
    End Property


    Public Property Filter As String
        Get
            Return mFilter
        End Get
        Set(value As String)
            mFilter = value
            SplitFilters()
            ListFiles()
        End Set
    End Property

    Public Property FilterIndex As Integer
        Get
            Return mFilterIndex
        End Get
        Set(value As Integer)
            mFilterIndex = value
            ListFiles()
        End Set
    End Property

    Private Sub SplitFilters()
        mFilterCollection.Clear()
        Dim fs() As String = mFilter.Split("|")
        For i As Integer = 0 To fs.GetUpperBound(0) Step 2
            mFilterCollection.Add(New FilterElement() With {.Extension = fs(i + 1), .Description = fs(i)})
        Next
    End Sub

    Private Sub ListFiles()
        mList.Clear()
        Me.DataSource = Nothing
        If Not IO.Directory.Exists(mDirectory) Then Return
        If mFilterCollection.Count = 0 Then
            ListFiles("*.*")
        Else
            Dim Exts() As String = mFilterCollection(mFilterIndex).Extension.Split(";")
            If Exts.Contains("*.*") Then
                ListFiles("*.*")
            Else
                For Each e As String In Exts
                    ListFiles(e)
                Next
            End If
        End If
        mList.Sort(AddressOf SortProc)
        Dim dt As New DataTable
        dt.Columns.Add("FileIcon", GetType(Image))
        dt.Columns.Add("FileName", GetType(String))
        dt.Columns.Add("FileExtension", GetType(String))
        dt.Columns.Add("FileSize", GetType(String))
        dt.Columns.Add("FileModified", GetType(String))
        Dim dr As DataRow = Nothing
        For Each f As String In mList
            Dim fInfo As New IO.FileInfo(f)
            dr = dt.NewRow()
            dr("FileIcon") = GetFileIcon(f)
            dr("FileName") = fInfo.Name
            dr("FileExtension") = fInfo.Extension
            dr("FileSize") = GetSizeDescritpion(fInfo.Length)
            dr("FileModified") = fInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss")
            dt.Rows.Add(dr)
        Next
        Me.DataSource = dt
        For Each Col As DataGridViewColumn In Me.Columns
            Select Case Col.Index
                Case 0
                    Col.HeaderText = ""
                    Col.Width = 20
                    Col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    Col.SortMode = DataGridViewColumnSortMode.NotSortable
                    CType(Col, DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Normal
                Case 1
                    Col.HeaderText = "名称"
                    Col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Case 2
                    Col.HeaderText = "类型"
                    Col.Width = 60
                Case 3
                    Col.HeaderText = "大小"
                    Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Col.Width = 80
                Case 4
                    Col.HeaderText = "修改日期"
                    Col.Width = 130
            End Select
        Next
        Me.Update()
    End Sub

    Private Function GetFileIcon(Path As String) As Image
        Dim info As New Shell32.SHFILEINFO
        Dim cbFileInfo As Integer = Marshal.SizeOf(info)
        Dim Flags As Shell32.SHGetFileInfoFlags = Shell32.SHGetFileInfoFlags.Icon Or
                                                  Shell32.SHGetFileInfoFlags.UseFileAttributes Or
                                                  Shell32.SHGetFileInfoFlags.SmallIcon
        Dim hIcon As IntPtr = Shell32.SHGetFileInfo(Path, 256, info, CUInt(cbFileInfo), Flags)
        If hIcon.Equals(IntPtr.Zero) Then Return Nothing
        If info.hIcon.Equals(IntPtr.Zero) Then Return Nothing
        Dim MyIcon As Icon = Icon.FromHandle(info.hIcon).Clone()
        User32.DestroyIcon(info.hIcon)
        Dim bm As Image = MyIcon.ToBitmap()
        MyIcon.Dispose()
        Return bm
    End Function

    Public Function GetExtension() As String
        Dim Exts() As String = mFilterCollection(mFilterIndex).Extension.Split(";")
        Return Exts(0).Replace("*", "")
    End Function
    Public Function CheckExtension(Ext As String) As Boolean
        For Each e As String In mFilterCollection(mFilterIndex).Extension.Split(";")
            If String.Compare(e, Ext, True) = 0 Then Return True
        Next
        Return False
    End Function

    Private Function SortProc(x As String, y As String) As Integer
        Return String.Compare(x, y, True)
    End Function


    Private Sub ListFiles(SearchPattern As String)
        Try
            mList.AddRange(IO.Directory.GetFiles(mDirectory, SearchPattern))
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Public Sub FillFileNames(CB As ComboBox)
        CB.Items.Clear()
        For Each e As String In mList
            Dim fi As New IO.FileInfo(e)
            CB.Items.Add(fi.Name)
        Next
        CB.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        CB.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub

    Public Sub FillExtension(CB As ComboBox)
        CB.Items.Clear()
        For Each e As FilterElement In mFilterCollection
            CB.Items.Add(e.Description)
        Next
        CB.SelectedIndex = mFilterIndex
    End Sub

    Public Sub SetRowSelect(FileName As String)
        For Each R As DataGridViewRow In Me.Rows
            If String.Compare(R.Cells(1).Value.ToString, FileName) = 0 Then
                R.Selected = True
            End If

        Next
    End Sub

    Private Function GetSizeDescritpion(Value As Long) As String
        Dim wSize As ULong = Value
        Dim Level As Integer = 0
        Dim Formatter() As String = {"{0}B",
                                     "{0:F2}KB",
                                     "{0:F2}MB",
                                     "{0:F2}GB",
                                     "{0:F2}TB",
                                     "{0:F2}PB",
                                     "{0:F2}EB",
                                     "{0:F2}ZB",
                                     "{0:F2}YB",
                                     "{0:F2}NB",
                                     "{0:F2}DB"}
        If wSize < 1024 Then Return wSize.ToString & "B"
        Dim Result As Double = CDbl(wSize)
        Dim Unit As Double = 1024.0
        Do While Result >= Unit And Level < 10
            Level += 1
            Result /= Unit
        Loop

        Return String.Format(Formatter(Level), Result)


        '1 kilobyte kB = 1000 (103) byte 
        '1 megabyte MB = 1 000 000 (106) byte 
        '1 gigabyte GB = 1 000 000 000 (109) byte 
        '1 terabyte TB = 1 000 000 000 000 (1012) byte 
        '1 petabyte PB = 1 000 000 000 000 000 (1015) byte 
        '1 exabyte EB = 1 000 000 000 000 000 000 (1018) byte 
        '1 zettabyte ZB = 1 000 000 000 000 000 000 000 (1021) byte 
        '1 yottabyte YB = 1 000 000 000 000 000 000 000 000 (1024) byte 
        '1 nonabyte NB = 1 000 000 000 000 000 000 000 000 000 (1027) byte 
        '1 doggabyte DB = 1 000 000 000 000 000 000 000 000 000 000 (1030) byte 
    End Function

    Protected Overrides Sub OnDataError(displayErrorDialogIfNoHandler As Boolean, e As DataGridViewDataErrorEventArgs)
        'MyBase.OnDataError(displayErrorDialogIfNoHandler, e)
    End Sub
End Class
