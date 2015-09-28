''' <summary>
''' Factory for section build process
''' </summary>
''' <remarks></remarks>
Friend Class SectionBuilderFactory

    Private _sections As IList(Of IBaseSection)
    Private _controller As ReportController

    Private _headerGroup As IList(Of IBuildSection)
    Private _footerGroup As IList(Of IBuildSection)

    Public Sub New(sections As IList(Of IBaseSection), controller As ReportController)
        _sections = sections
        _controller = controller
    End Sub

    Private Shared Function GetBuilder(section As IBaseSection, controller As ReportController) As IBuildSection
        Dim result As IBuildSection = Nothing

        Select Case section.Mode
            Case SectionOption.Header
                result = New HeaderBuilder(section, controller)
            Case SectionOption.Footer
                result = New FooterBuilder(section, controller)
            Case SectionOption.Detail
                result = New DetailBuilder(section, controller)
            Case SectionOption.HeaderGroup
                result = New GroupHeaderBuilder(section, controller)
            Case SectionOption.FooterGroup
                result = New GroupFooterBuilder(section, controller)
            Case SectionOption.Total
                result = New TotalBuilder(section, controller)
            Case SectionOption.Title
                result = New TitleBuilder(section, controller)
            Case SectionOption.Summary
                result = New SummaryBuilder(section, controller)
        End Select

        Return result

    End Function

    Private Function GetHeaderGroup(sections As IList(Of IBuildSection)) As IList(Of IBuildSection)
        Return sections.Where(Function(s) s.Section.Mode = SectionOption.HeaderGroup).
                        ToList
    End Function

    Private Function GetFooterGroup(sections As IList(Of IBuildSection)) As IList(Of IBuildSection)
        Return sections.Where(Function(s) s.Section.Mode = SectionOption.FooterGroup).
                        ToList
    End Function

    Public Function GetSection(mode As SectionOption) As IBuildSection
        If mode = SectionOption.FooterGroup OrElse mode = SectionOption.HeaderGroup Then
            Throw New ArgumentException("Not a single section", "mode")
        End If

        Return _sections.Where(Function(s) s.Mode = mode).
                         Select(Function(s) SectionBuilderFactory.GetBuilder(s, _controller)).
                         FirstOrDefault

    End Function

    Public ReadOnly Property HeaderGroup() As IList(Of IBuildSection)
        Get
            Return _headerGroup
        End Get
    End Property

    Public ReadOnly Property FooterGroup() As IList(Of IBuildSection)
        Get
            Return _footerGroup
        End Get
    End Property

    ''' <summary>
    ''' Setup sections for internal loop process
    ''' </summary>
    Public Function ForReportLoop() As IList(Of IBuildSection)
        Dim result As List(Of IBuildSection) =
            _sections.Select(Function(s) SectionBuilderFactory.GetBuilder(s, _controller)).
                      Where(Function(s) s.Section.Mode > SectionOption.Header AndAlso
                                        s.Section.Mode < SectionOption.Footer).
                      ToList

        result.Sort(New SectionBuilderComparer)

        _headerGroup = Me.GetHeaderGroup(result)
        _footerGroup = Me.GetFooterGroup(result)

        ' inicia os dados para as seções
        _controller.SetupSections(result)

        ' faz a ligação rodapé do grupo com cabeçalho do grupo
        For Each header As IBuildSection In _headerGroup
            Dim footer As IBuildSection =
                _footerGroup.First(Function(s) s.Section.GroupNumber.Equals(header.Section.GroupNumber))
            footer.Related = header
            header.Related = footer
        Next

        Return result

    End Function

End Class
