''' <summary>
''' Builder for footer section
''' </summary>
''' <remarks></remarks>
Friend Class FooterBuilder
    Inherits BaseSectionBuilder

    Public Sub New(section As IBaseSection, controller As ReportController)
        Me.Section = section
        Me.Controller = controller
    End Sub

    Protected Overrides Function CanBuild() As Boolean
        Return True

    End Function

End Class
