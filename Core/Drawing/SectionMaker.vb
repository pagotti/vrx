Imports System.Drawing
Imports System.Drawing.Drawing2D

''' <summary>
''' Maker for drawing section information
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class SectionMaker

    Private _graphics As Graphics
    Private Const BACK_COLOR_WIDTH As Integer = 48

    Public Property Mode As SectionOption = SectionOption.Undefined
    Public Property PageBreak As PageBreakOption = PageBreakOption.None
    Public Property GroupNumber As Integer = 0

    Public Sub New(graphics As Graphics)
        If graphics Is Nothing Then Throw New ArgumentNullException("graphics")
        Me._graphics = graphics
    End Sub

    Private Sub DrawSectionModeMark(rect As Rectangle)
        Using b As New SolidBrush(SectionHelper.ModeColor(Me.Mode))
            _graphics.FillRectangle(b, New Rectangle(rect.Width - BACK_COLOR_WIDTH,
                                                     rect.Y, BACK_COLOR_WIDTH, rect.Height))
        End Using

    End Sub

    Private Sub DrawSectionName(rect As Rectangle)
        Using context As New OrientationContext(_graphics, OrientationOption.Horizontal)
            Dim text As New TextMaker(Me._graphics) With {
                .Color = Drawing.Color.Black,
                .Font = New Font("Arial", 10, FontStyle.Italic),
                .Align = AlignmentOption.TopRight}
            Dim name As String = SectionHelper.ModeName(Me.Mode)
            If Me.Mode = SectionOption.HeaderGroup OrElse
                Me.Mode = SectionOption.FooterGroup Then
                name = String.Format("{0} [{1}]", name, Me.GroupNumber)
            End If
            text.Draw(name, context.FlipRectangle(rect))
        End Using

    End Sub

    ''' <summary>
    ''' Return the page break mark path
    ''' </summary>
    Private Function WavePath(start As Integer,
                              height As Integer,
                              width As Integer,
                              Optional waveCount As Integer = 30) As Drawing.Drawing2D.GraphicsPath
        Dim path As New Drawing.Drawing2D.GraphicsPath
        Dim lineStep As Integer = width \ waveCount
        For i = 0 To waveCount
            path.AddLine(lineStep * i, start, lineStep * i + lineStep \ 2, start + height)
        Next
        path.AddLine(width - 1, start, 0, start)
        Return path

    End Function

    Private Sub DrawPageBreak(rect As Rectangle)
        If Me.PageBreak <> PageBreakOption.None Then
            Using b As New SolidBrush(Color.White),
                  sp As New Pen(Brushes.Silver),
                  tp As New Pen(Brushes.Gray)

                sp.DashStyle = DashStyle.Dot
                tp.DashStyle = DashStyle.Dot

                If Me.PageBreak.HasFlag(PageBreakOption.Before) Then
                    _graphics.FillPath(b, WavePath(rect.Top, 5, rect.Width))
                    _graphics.DrawPath(sp, WavePath(rect.Top, 5, rect.Width))
                    _graphics.DrawPath(tp, WavePath(rect.Top, 6, rect.Width))

                End If

                If Me.PageBreak.HasFlag(PageBreakOption.After) Then
                    _graphics.FillPath(b, WavePath(rect.Bottom, -5, rect.Width))
                    _graphics.DrawPath(sp, WavePath(rect.Bottom, -5, rect.Width))
                    _graphics.DrawPath(tp, WavePath(rect.Bottom, -6, rect.Width))

                End If

            End Using

        End If

    End Sub

    Public Sub Draw(rect As Rectangle)
        DrawSectionModeMark(rect)
        DrawSectionName(rect)
        DrawPageBreak(rect)

    End Sub

End Class
