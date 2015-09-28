Imports System.Drawing
Imports System.Globalization

''' <summary>
''' Define a controller for the report engine
''' This controls data on report generation and its options
''' </summary>
''' <remarks></remarks>
Public Class ReportController
    Private _currentTop As Single = 0
    Private _sectionData As New Dictionary(Of IBaseSection, SectionData)

    Private _groupFields As New Dictionary(Of IBaseSection, GroupData)
    Private _aggregatedFields As New List(Of AggregatedFieldData)

    Public FirstPage As Boolean
    Public PageNumber As Integer    
    Public PageBounds As RectangleF
    Public PageMargin As PointF
    Public Options As ReportOptions

    Public ForcePageBreak As Boolean
    Public FooterLocation As PointF
    Public Data As DataTable
    Public CurrentRow As Integer = 0
    Public Action As DisplayOption

    Public Sub SetBounds(pageSettings As Drawing.Printing.PageSettings)
        Dim pageMargin As PointF

        If Me.Options.IgnorePrinterHardMargins Then
            pageMargin = New PointF(pageSettings.Margins.Left, pageSettings.Margins.Top)
        Else
            pageMargin = New PointF(
               Math.Max(pageSettings.Margins.Left, pageSettings.HardMarginX) - pageSettings.HardMarginX,
               Math.Max(pageSettings.Margins.Top, pageSettings.HardMarginY) - pageSettings.HardMarginY)
        End If

        Me.PageBounds = New RectangleF(
            pageSettings.Bounds.Left + pageMargin.X,
            pageSettings.Bounds.Top + pageMargin.Y,
            pageSettings.Bounds.Width - pageMargin.X - pageSettings.Margins.Right,
            pageSettings.Bounds.Height - pageMargin.Y - pageSettings.Margins.Bottom)

    End Sub

    Public Sub StartPage()
        ForcePageBreak = False
        _currentTop = PageBounds.Top

    End Sub

    Public Sub StartFooter()
        _currentTop = FooterLocation.Y

    End Sub

    Public ReadOnly Property CurrentTop As Single
        Get
            Return _currentTop
        End Get
    End Property

    Public Function MustBreakPage() As Boolean
        Return ForcePageBreak OrElse _currentTop > FooterLocation.Y

    End Function

    Public Function IsOnTop() As Boolean
        Return _currentTop.Equals(PageBounds.Top)

    End Function

    Public Function FitOnPage(height As Single) As Boolean
        Return Not _currentTop + height > FooterLocation.Y

    End Function

    Public Sub AddHeight(height As Single)
        Me._currentTop += height

    End Sub

    Public Sub NextPage()
        PageNumber += 1
        StartPage()
        If FirstPage Then FirstPage = False

    End Sub

    Public ReadOnly Property HasData As Boolean
        Get
            If Me.Data IsNot Nothing Then
                Return CurrentRow < Me.Data.Rows.Count
            Else
                Return False
            End If
        End Get
    End Property

    Public Sub NextRow()
        Me.CurrentRow += 1

    End Sub

    Public Function LastRow() As Boolean
        Return Me.CurrentRow = Me.Data.Rows.Count - 1

    End Function

    Public Sub UpdateGroupKey()
        If Me.HasData Then
            For Each data As KeyValuePair(Of IBaseSection, SectionData) In
                Me._sectionData.Where(Function(pair) pair.Key.Mode = SectionOption.HeaderGroup)
                data.Value.GroupingKey = CalculatedGroupKey(data.Value.GroupingFields)
            Next

        End If

    End Sub

    Public Sub ResetAggregations(build As IBuildSection)
        If build.Section.Mode = SectionOption.HeaderGroup Then
            Me._sectionData(build.Section).ResetGroupAggregateValue()
            Me._sectionData(build.Related.Section).ResetGroupAggregateValue()

        End If

    End Sub

    Public Sub UpdateAggregations()
        If Me.HasData Then
            Dim row As Integer = Me.CurrentRow
            Dim aggregatedFields As IList(Of AggregatedFieldData) =
                Me._sectionData.SelectMany(Function(s) s.Value.AggregatedFields).ToList
            For Each data As AggregatedFieldData In aggregatedFields
                Dim value As Decimal = 0
                If Decimal.TryParse(GetFieldValue(data.Field), value) Then
                    data.AggregatedValue += value
                End If

            Next

        End If

    End Sub

    Public Sub SetupSections(sections As IList(Of IBuildSection))
        For Each s As IBuildSection In sections
            Dim fields As List(Of IBaseFieldControl) =
                s.Section.GetControls.OfType(Of IBaseFieldControl).ToList()
            Me._sectionData.Add(s.Section, New SectionData(s.Section, fields))

        Next

    End Sub

    Public Function GetAggregateValue(section As IBaseSection, field As IBaseFieldControl) As String
        Return String.Format(String.Concat("{0:", field.FormatString, "}"),
                             Me._sectionData(section).AggregatedFields.First(Function(f) f.Field.Equals(field)).AggregatedValue)

    End Function

    Public Function GetCurrentGroupKey(section As IBaseSection) As Integer
        Return Me._sectionData(section).GroupingKey

    End Function

    Public Function GetFooterGroupKey(section As IBaseSection) As Integer
        Return CalculatedGroupKey(section, Me.CurrentRow + 1)

    End Function

    Public Function GetHeaderGroupKey(section As IBaseSection) As Integer
        Return CalculatedGroupKey(section, Me.CurrentRow)

    End Function

    Private Function CalculatedGroupKey(section As IBaseSection, row As Integer) As Integer
        Return CalculatedGroupKey(Me._sectionData(section).GroupingFields, row)

    End Function

    Private Function CalculatedGroupKey(fields As IList(Of IBaseFieldControl)) As Integer
        Return CalculatedGroupKey(fields, Me.CurrentRow)

    End Function

    Private Function CalculatedGroupKey(fields As IList(Of IBaseFieldControl), row As Integer) As Integer
        ' TODO: field name separator needed
        Return String.Concat(fields.Select(Function(c) GetFieldValue(c, row))).GetHashCode

    End Function

    Public Function GetFieldValue(field As IBaseFieldControl) As String
        Return GetFieldValue(field, Me.CurrentRow)

    End Function

    Public Function GetFieldValue(field As IBaseFieldControl, row As Integer) As String
        Dim result As String = String.Empty

        If Not String.IsNullOrEmpty(field.ColumnName) Then
            If Me.Data.Columns.Contains(field.ColumnName) AndAlso
                row < Me.Data.Rows.Count Then
                result = String.Format(String.Concat("{0:", field.FormatString, "}"),
                                       Me.Data.Rows(row).Item(field.ColumnName))
                Return result
            End If
        Else
            result = String.Format(String.Concat("{0:", field.FormatString, "}"),
                                   field.GetFieldValue(Me.Data.Rows(row)))
        End If

        Return result

    End Function

End Class
