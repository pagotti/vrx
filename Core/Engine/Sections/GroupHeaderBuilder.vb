''' <summary>
''' Builder for header group section
''' </summary>
''' <remarks></remarks>
Friend Class GroupHeaderBuilder
    Inherits BaseSectionBuilder

    Public Sub New(section As IBaseSection, controller As ReportController)
        Me.Section = section
        Me.Controller = controller

    End Sub

    Protected Overrides Function Build() As SectionBuilderResult
        Me.Controller.ResetAggregations(Me)
        Return MyBase.Build()

    End Function

    Protected Overrides Function CanBuild() As Boolean
        Dim result As Boolean = Me.Controller.HasData

        If result Then
            result = Me.Controller.GetHeaderGroupKey(Me.Section) <>
                     Me.Controller.GetCurrentGroupKey(Me.Section)
        End If

        Return result

    End Function

End Class
