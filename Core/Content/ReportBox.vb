Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Drawing

''' <summary>
''' Represent an information box to serialize in page cache process
''' </summary>
''' <remarks></remarks>
<Serializable>
Public Class ReportBox

    Public Sub New()
    End Sub

    Public Sub New(bounds As RectangleF, top As Single)
        Me.Bounds = bounds
        Me.Bounds.Offset(0, top)
    End Sub

    Public Bounds As RectangleF
    Public BackColor As Color
    Public ForeColor As Color
    Public Alignment As AlignmentOption
    Public Orientation As OrientationOption
    Public Margin As BoxMargin

    Public Border As BorderOption = BorderOption.None
    Public BorderStyle As BorderStyleOption
    Public BorderColor As Color
    Public BorderWeight As Integer

    Public Font As Font
    Public TrimmingMode As TextTrimmingOption
    Public TextJustified As Boolean
    Public WordWrap As Boolean
    Public Text As String

    Public Image As Bitmap

    Public Sub Paint(g As Graphics)
        If Not Me.BackColor.IsEmpty Then
            g.FillRectangle(New SolidBrush(Me.BackColor), Me.Bounds)

        End If

        If Not Me.Border = BorderOption.None Then
            Dim maker As New BorderMaker(g) With {
                .Border = Me.Border,
                .Style = Me.BorderStyle,
                .Color = Me.BorderColor,
                .Weight = Me.BorderWeight}
            maker.Draw(Rectangle.Truncate(Me.Bounds))

        End If

        If Not String.IsNullOrEmpty(Me.Text) Then
            Dim rect As Rectangle = Rectangle.Truncate(Me.Bounds)
            Using context As New OrientationContext(g, Me.Orientation, rect)
                Dim maker As New TextMaker(g) With {
                        .Font = Me.Font,
                        .Color = Me.ForeColor,
                        .Align = Me.Alignment,
                        .WordWrap = Me.WordWrap,
                        .Trimming = Me.TrimmingMode,
                        .Justify = Me.TextJustified,
                        .Margin = Me.Margin
                    }
                maker.Draw(Me.Text, context.FlipRectangle(rect))
            End Using

        End If

    End Sub

End Class
