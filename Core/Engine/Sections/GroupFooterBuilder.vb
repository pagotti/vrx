''' <summary>
''' Builder for group footer section
''' </summary>
''' <remarks></remarks>
Friend Class GroupFooterBuilder
    Inherits BaseSectionBuilder

    Public Sub New(section As IBaseSection, controller As ReportController)
        Me.Section = section
        Me.Controller = controller
    End Sub

    Protected Overrides Function CanBuild() As Boolean
        Dim result As Boolean = Me.Controller.HasData

        If result Then
            result = Me.Controller.LastRow OrElse
                Me.Controller.GetFooterGroupKey(Me.Related.Section) <>
                Me.Controller.GetHeaderGroupKey(Me.Related.Section)
        End If

        Return result

    End Function

End Class
