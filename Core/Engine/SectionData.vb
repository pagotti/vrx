''' <summary>
''' Define a class for keep section data during report generation
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class SectionData

    Private _groupingFields As List(Of IBaseFieldControl)
    Private _aggregatedFields As List(Of AggregatedFieldData)

    Public ReadOnly Section As IBaseSection
    Public Property GroupingKey As Integer

    Public Sub New(section As IBaseSection, fields As IList(Of IBaseFieldControl))
        Me.Section = section
        Me._groupingFields = New List(Of IBaseFieldControl)
        Me._aggregatedFields = New List(Of AggregatedFieldData)
        Me.AddFields(fields)
        If section.Mode = SectionOption.HeaderGroup AndAlso
            Me._groupingFields.Count = 0 Then
            Throw New InvalidGroupFormulaException()
        End If

    End Sub

    Private Sub AddFields(fields As IList(Of IBaseFieldControl))
        For Each field As IBaseFieldControl In fields
            If Not field.AggregateMode = AggregateOption.None Then
                Me._aggregatedFields.Add(New AggregatedFieldData(field))
            End If
            If field.GroupColumnIndex >= 0 Then
                Me._groupingFields.Add(field)
            End If

        Next

    End Sub

    Public ReadOnly Property GroupingFields As IList(Of IBaseFieldControl)
        Get
            Return Me._groupingFields
        End Get
    End Property

    Public ReadOnly Property AggregatedFields As IList(Of AggregatedFieldData)
        Get
            Return Me._aggregatedFields
        End Get
    End Property

    Public ReadOnly Property GroupAggregatedFields As IEnumerable(Of AggregatedFieldData)
        Get
            Return Me._aggregatedFields.Where(Function(d) d.Field.AggregateMode = AggregateOption.Auto OrElse
                                                          d.Field.AggregateMode = AggregateOption.Group)
        End Get
    End Property

    Public Sub ResetGroupAggregateValue()
        For Each data As AggregatedFieldData In Me.GroupAggregatedFields
            data.AggregatedValue = 0
        Next

    End Sub

End Class
