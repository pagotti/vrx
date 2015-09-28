Imports System.Drawing

''' <summary>
''' Maker for drawing rules on report board
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class RuleMaker

    Private _graphics As Graphics

    Public Sub New(graphics As Graphics)
        If graphics Is Nothing Then Throw New ArgumentNullException("graphics")
        Me._graphics = graphics
    End Sub

    Public Sub Draw(ruleStep As Integer, rect As Rectangle)
        If ruleStep > 0 Then
            Dim ruleOffset As Integer = rect.Left
            Dim rulePixelStep As Integer = GraphicHelper.ToPixelX(_graphics, ruleStep, GraphicsUnit.Millimeter)
            Dim ruleValue As Integer = 0
            Dim text As New TextMaker(Me._graphics) With {
                            .Color = Drawing.Color.Black,
                            .Font = New Font("Arial", 8, FontStyle.Italic),
                            .Align = AlignmentOption.BottomLeft}
            Using p As New Pen(Brushes.Black)
                p.DashStyle = Drawing2D.DashStyle.Dot
                While ruleOffset < rect.Right
                    ruleValue += ruleStep
                    ruleOffset += rulePixelStep
                    Dim textRect As Rectangle = New Rectangle(ruleOffset, rect.Top, ruleOffset, rect.Height)
                    _graphics.DrawLine(p, ruleOffset, rect.Top, ruleOffset, rect.Bottom)
                    text.Draw(String.Format("{0}", ruleValue), textRect)

                End While
            End Using

        End If

    End Sub

End Class
