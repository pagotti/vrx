Imports System.Threading.Tasks
Imports System.Collections.Generic
Imports System.Drawing.Printing
Imports System.Drawing

''' <summary>
''' Defines a report document
''' </summary>
''' <remarks></remarks>
Public Class ReportDocument
    Inherits PrintDocument

    Private _planner As IPlanningReport
    Private _pages As ICollection(Of PageInfo)
    Private _pageCount As Integer
    Private _sections As New List(Of IBaseSection)
    Private _data As DataTable

#Region "Constructors"

    Public Sub New()
        MyBase.New()

    End Sub

    Public Sub New(sections As IList(Of IBaseSection))
        Me.New()
        For Each s As IBaseSection In sections
            Me.Sections.Add(s)

        Next

    End Sub

    Public Sub New(sections As IList(Of IBaseSection), data As DataSet, dataMember As String)
        Me.New(sections)
        If data Is Nothing Then Throw New NullReferenceException("data can not be null")
        If String.IsNullOrEmpty(dataMember) Then
            Me._data = data.Tables(0)
        Else
            Me._data = data.Tables(dataMember)
        End If

    End Sub

    Public Sub New(sections As IList(Of IBaseSection), data As DataTable)
        Me.New(sections)
        If data Is Nothing Then Throw New NullReferenceException("data can not be null")
        Me._data = data

    End Sub

#End Region

#Region "Setup"

    Public Property Options As New ReportOptions

    Friend ReadOnly Property Sections As IList(Of IBaseSection)
        Get
            Return _sections
        End Get
    End Property

    Friend ReadOnly Property Data As DataTable
        Get
            Return _data
        End Get
    End Property

    Protected Overridable Function GetPlanner(e As PrintEventArgs) As IPlanningReport
        Return New BasePlanner(Me, e)
    End Function

#End Region

#Region "Print Loop"

    Private Function IsValidPage() As Boolean
        Select Case Me.PrinterSettings.PrintRange
            Case PrintRange.SomePages
                Return (_pageCount >= Me.PrinterSettings.FromPage AndAlso
                        _pageCount <= Me.PrinterSettings.ToPage)
        End Select
        ' TODO: Implement CurrentPage and Selection

        Return True

    End Function

    Protected Overrides Sub OnBeginPrint(e As PrintEventArgs)
        MyBase.OnBeginPrint(e)
        _planner = Me.GetPlanner(e)
        _pageCount = 0
        _pages = _planner.GetPages()

    End Sub

    Protected Overrides Sub OnPrintPage(e As PrintPageEventArgs)
        MyBase.OnPrintPage(e)

        Dim g As Graphics = e.Graphics

        If _pageCount < _pages.Count AndAlso IsValidPage() Then
            Dim page As ReportPage =
                ContentSerializer(Of ReportPage).DeSerialize(_pages(_pageCount).Filename)
            Dim m As PagePainter = New PagePainter(page)
            Dim args As New PrintPageEventArgs(g, e.MarginBounds,
                                               e.PageBounds,
                                               e.PageSettings)
            m.Paint(args)
            If args.Cancel Then e.Cancel = True
        End If

        _pageCount += 1
        e.HasMorePages = _pageCount < _pages.Count

    End Sub

#End Region

End Class
