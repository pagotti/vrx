''' <summary>
''' Comparer for order sections in build process
''' </summary>
''' <remarks></remarks>
Friend NotInheritable Class SectionBuilderComparer
    Implements IComparer(Of IBuildSection)

    Public Function Compare(x As IBuildSection, y As IBuildSection) As Integer Implements IComparer(Of IBuildSection).Compare
        Dim result As Integer = x.Section.Mode.CompareTo(y.Section.Mode)
        If x.Section.Mode = SectionOption.HeaderGroup AndAlso
           y.Section.Mode = SectionOption.HeaderGroup Then
            result = x.Section.GroupNumber.CompareTo(y.Section.GroupNumber)
        ElseIf x.Section.Mode = SectionOption.FooterGroup AndAlso
               y.Section.Mode = SectionOption.FooterGroup Then
            result = y.Section.GroupNumber.CompareTo(x.Section.GroupNumber)
        End If

        Return result

    End Function

End Class
