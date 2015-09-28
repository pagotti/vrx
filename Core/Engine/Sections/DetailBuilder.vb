Imports System.Drawing

''' <summary>
''' Builder for detail section
''' </summary>
''' <remarks></remarks>
Friend Class DetailBuilder
    Inherits BaseSectionBuilder

    Public Sub New(section As IBaseSection, controller As ReportController)
        Me.Section = section
        Me.Controller = controller
    End Sub

    Protected Overrides Function Build() As SectionBuilderResult
        Me.Controller.UpdateAggregations()
        Return MyBase.Build()

    End Function

    Protected Overrides Function CanBuild() As Boolean
        Return Me.Controller.HasData

    End Function

End Class
