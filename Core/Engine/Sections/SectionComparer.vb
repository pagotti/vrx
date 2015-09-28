''' <summary>
''' Comparer for right section order in visual board
''' </summary>
Public NotInheritable Class SectionComparer
    Implements IComparer(Of IBaseSection)

    Public Function Compare(x As IBaseSection, y As IBaseSection) As Integer Implements IComparer(Of IBaseSection).Compare
        Dim result As Integer = x.Mode.CompareTo(y.Mode)
        If x.Mode = SectionOption.HeaderGroup AndAlso
           y.Mode = SectionOption.HeaderGroup Then
            result = x.GroupNumber.CompareTo(y.GroupNumber)
        ElseIf x.Mode = SectionOption.FooterGroup AndAlso
               y.Mode = SectionOption.FooterGroup Then
            result = y.GroupNumber.CompareTo(x.GroupNumber)
        End If

        Return result

    End Function

End Class
