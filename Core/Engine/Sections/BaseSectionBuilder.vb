Imports System.Drawing

''' <summary>
''' Base class for all section builders
''' </summary>
''' <remarks></remarks>
Public MustInherit Class BaseSectionBuilder
    Implements IBuildSection

    Protected Section As IBaseSection
    Protected Controller As ReportController

    Protected Overridable Function Build() As SectionBuilderResult Implements IBuildSection.Build
        Dim result As New SectionBuilderResult()

        result.Boxes = New List(Of ReportBox)
        result.Bounds = Section.Bounds
        result.Bounds.Offset(Controller.PageBounds.Left, Controller.CurrentTop)

        ' section background
        AddBackground(result)

        ' build section controls
        For Each ctr As IBaseControl In Me.Section.GetControls
            If (ctr.Display And Me.Controller.Action) <> 0 Then
                Dim box As ReportBox = Me.GetBox(ctr)
                box.Bounds.Offset(Controller.PageBounds.Left, Controller.CurrentTop)
                If Controller.Options.AllowOutOffMargin OrElse
                    (box.Bounds.Left >= 0 AndAlso box.Bounds.Right <= Controller.PageBounds.Right) Then
                    result.Boxes.Add(box)
                End If
            End If

        Next

        Return result
    End Function

    Protected MustOverride Function CanBuild() As Boolean Implements IBuildSection.CanBuild

    Protected Property Related As IBuildSection Implements IBuildSection.Related

    Protected Overridable Function GetBox(ctr As IBaseControl) As ReportBox
        Dim box As ReportBox = BoxConverter.From(ctr)
        If TypeOf ctr Is IBaseFieldControl Then
            Dim field As IBaseFieldControl = DirectCast(ctr, IBaseFieldControl)
            If field.AggregateMode = AggregateOption.None Then
                box.Text = Me.Controller.GetFieldValue(field)
            Else
                box.Text = Me.Controller.GetAggregateValue(Me.Section, field)
            End If

        End If

        Return box

    End Function

    Private ReadOnly Property Section1 As IBaseSection Implements IBuildSection.Section
        Get
            Return Me.Section
        End Get
    End Property

    Private Sub AddBackground(result As SectionBuilderResult)
        If Not Section.BackColor.IsEmpty AndAlso
           Not Section.BackColor.Equals(Color.White) Then
            result.Boxes.Add(New ReportBox() With {.Bounds = result.Bounds,
                                                   .BackColor = Section.BackColor})
        End If
    End Sub

End Class
