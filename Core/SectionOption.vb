Public Enum SectionOption
    Undefined
    Title
    Header

    HeaderGroup
    Detail
    FooterGroup
    Total

    Footer
    Summary

End Enum

Public Class SectionHelper

    Public Shared Function ModeColor(mode As SectionOption) As Drawing.Color
        Select Case mode
            Case SectionOption.Undefined
                Return Drawing.Color.LightGray
            Case SectionOption.Title, SectionOption.Summary
                Return Drawing.Color.LightSalmon
            Case SectionOption.Header, SectionOption.Footer
                Return Drawing.Color.LightYellow
            Case SectionOption.HeaderGroup, SectionOption.FooterGroup
                Return Drawing.Color.LightBlue
            Case SectionOption.Detail
                Return Drawing.Color.LightGreen
            Case SectionOption.Total
                Return Drawing.Color.LightCoral

        End Select

    End Function

    Public Shared Function ModeName(mode As SectionOption) As String
        Select Case mode
            Case SectionOption.Title
                Return "Title"
            Case SectionOption.Summary
                Return "Summary"
            Case SectionOption.Header
                Return "Header"
            Case SectionOption.Footer
                Return "Footer"
            Case SectionOption.HeaderGroup
                Return "Group's Header"
            Case SectionOption.FooterGroup
                Return "Group's Footer"
            Case SectionOption.Detail
                Return "Detail"
            Case SectionOption.Total
                Return "Total"

        End Select

        Return "Undefined"

    End Function

End Class