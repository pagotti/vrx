''' <summary>
''' Builder for summary section
''' </summary>
''' <remarks></remarks>
Friend Class SummaryBuilder
    Inherits BaseSectionBuilder

    Public Sub New(section As IBaseSection, controller As ReportController)
        Me.Section = section
        Me.Controller = controller
    End Sub

    Protected Overrides Function CanBuild() As Boolean
        Return True

    End Function

End Class
