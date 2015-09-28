Imports System.Linq
Imports System.Drawing
Imports System.Drawing.Printing

''' <summary>
''' Plan section sequence to draw
''' </summary>
Public Class BasePlanner
    Implements IPlanningReport

    Private _report As ReportDocument
    Private _controller As ReportController

    Public Sub New(report As ReportDocument, e As PrintEventArgs)
        _report = report
        _controller = New ReportController() With {
            .FirstPage = False,
            .PageNumber = 0,
            .Data = report.Data,
            .Options = report.Options,
            .Action = FromPrintAction(e.PrintAction)
        }

        _controller.SetBounds(report.DefaultPageSettings)

    End Sub

    Private Sub CheckLayout(headerGroup As IList(Of IBuildSection),
                            footerGroup As IList(Of IBuildSection))
        If _report.Sections.Count = 0 Then Throw New InvalidLayoutException("No sections setup")

        If headerGroup.Count <> footerGroup.Count Then
            Throw New InvalidLayoutException("Header group count must be same as footer group count")
        ElseIf headerGroup.Zip(footerGroup, Function(f, s) f.Section.GroupNumber - s.Section.GroupNumber).Sum <> 0 Then
            Throw New InvalidLayoutException("Groups have invalid number setup")
        End If

    End Sub

    Public Function GetPages() As ICollection(Of PageInfo) Implements IPlanningReport.GetPages

        Dim factory As New SectionBuilderFactory(_report.Sections, Me._controller)
        Dim sections As IList(Of IBuildSection) = factory.ForReportLoop()
        Me.CheckLayout(factory.HeaderGroup, factory.FooterGroup)

        Dim pages As New List(Of PageInfo)

        ' add title, if exists
        Dim title As IBuildSection =
            factory.GetSection(SectionOption.Title)
        If title IsNot Nothing Then
            Me._controller.StartPage()
            pages.Add(GetNewPageInfo(title))
        End If

        ' calculate footer height
        Dim footer As IBuildSection =
            factory.GetSection(SectionOption.Footer)
        Dim footerHeight As Integer = 0
        If footer IsNot Nothing Then
            footerHeight = footer.Section.Bounds.Height
        End If
        Me._controller.FooterLocation = New PointF(0, Me._controller.PageBounds.Bottom - footerHeight)

        ' start page
        Me._controller.StartPage()

        ' report loop on following order:
        ' page header, sections (group header, detail, group footer)
        ' total, if last page
        ' page footer
        Dim header As IBuildSection =
            factory.GetSection(SectionOption.Header)
        Dim page As New ReportPage

        Do
            Dim section As SectionBuilderResult = GetSectionBuilder(header)
            If CanFit(section, page) Then
                BuildSection(section, page)
                If sections.Count > 0 Then
                    Do
                        For Each builder As IBuildSection In sections
                            section = GetSectionBuilder(builder)
                            If CanFit(section, page) Then
                                BuildSection(section, page)
                            Else
                                Exit For
                            End If

                        Next

                        If Not Me._controller.MustBreakPage Then
                            ' update group controls
                            Me._controller.UpdateGroupKey()
                            Me._controller.NextRow()
                        End If

                    Loop While Me._controller.HasData AndAlso
                               Not Me._controller.MustBreakPage

                End If

            End If

            Me._controller.StartFooter()

            page.Boxes.AddRange(GetSectionBoxes(GetSectionBuilder(footer)))
            pages.Add(GetNewPageInfo(page))
            page = New ReportPage

            Me._controller.NextPage()

        Loop While Me._controller.HasData AndAlso sections.Count > 0

        ' page summary, if exists
        Dim summary As IBuildSection =
            factory.GetSection(SectionOption.Summary)
        If summary IsNot Nothing Then
            pages.Add(GetNewPageInfo(summary))
        End If

        Return pages

    End Function

    ''' <summary>
    ''' Build a section, and add height on controller
    ''' </summary>
    Private Sub BuildSection(section As SectionBuilderResult, page As ReportPage)
        If section IsNot Nothing Then
            page.Boxes.AddRange(section.Boxes)
            Me._controller.AddHeight(section.Bounds.Height)

        End If

    End Sub

    ''' <summary>
    ''' On build a section, return true or false if can't fit.
    ''' </summary>
    Private Function CanFit(section As SectionBuilderResult, page As ReportPage) As Boolean
        If section IsNot Nothing Then
            If Not Me._controller.FitOnPage(section.Bounds.Height) Then
                Me._controller.ForcePageBreak = True
                Return False
            End If
        End If

        Return True

    End Function

    ''' <summary>
    ''' Generate a cached page file for a title or summary page section
    ''' </summary>
    Private Function GetNewPageInfo(section As IBuildSection) As PageInfo
        If section Is Nothing Then Throw New NullReferenceException()

        Dim page As New ReportPage
        page.Boxes.AddRange(GetSectionBoxes(GetSectionBuilder(section)))
        Return GetNewPageInfo(page)

    End Function

    ''' <summary>
    ''' Generate a cached page file for a report page
    ''' </summary>
    Private Function GetNewPageInfo(page As ReportPage) As PageInfo
        Dim pageFilename As String = System.IO.Path.GetTempFileName
        ContentSerializer(Of ReportPage).Serialize(pageFilename, page)
        Return New PageInfo() With {.Filename = pageFilename}

    End Function

    Private Function GetSectionBoxes(result As SectionBuilderResult) As ICollection(Of ReportBox)
        If (result IsNot Nothing) Then
            Return result.Boxes
        End If
        Return New List(Of ReportBox)

    End Function

    ''' <summary>
    ''' Return a builder result if the builder can build or null
    ''' </summary>
    Private Function GetSectionBuilder(builder As IBuildSection) As SectionBuilderResult
        If (builder IsNot Nothing) AndAlso builder.CanBuild() Then
            Dim result As SectionBuilderResult = builder.Build()
            Return result

        End If

        Return Nothing

    End Function

    ''' <summary>
    ''' Translate print action in display options
    ''' </summary>
    Private Function FromPrintAction(action As PrintAction) As DisplayOption
        Select Case action
            Case PrintAction.PrintToFile
                Return DisplayOption.OnFile
            Case PrintAction.PrintToPreview
                Return DisplayOption.OnPreview
            Case PrintAction.PrintToPrinter
                Return DisplayOption.OnReport
            Case Else
                Return DisplayOption.Never
        End Select

    End Function

End Class
