''' <summary>
''' Builder for total section
''' </summary>
''' <remarks></remarks>
Friend Class TotalBuilder
    Inherits BaseSectionBuilder

    Public Sub New(section As IBaseSection, controller As ReportController)
        Me.Section = section
        Me.Controller = controller
    End Sub

    Protected Overrides Function CanBuild() As Boolean
        Return Me.Controller.HasData AndAlso Me.Controller.LastRow

    End Function

End Class
