Imports System.Drawing

''' <summary>
''' Maker for drawing text information
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class TextMaker

    Private _graphics As Graphics
    Public Property Font As Font = New Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular)
    Public Property Color As Color = Color.Black
    Public Property Align As AlignmentOption = AlignmentOption.TopLeft
    Public Property WordWrap As Boolean = False
    Public Property Trimming As TextTrimmingOption = TextTrimmingOption.None
    Public Property Margin As BoxMargin = BoxMargin.Empty
    Public Property Justify As Boolean = False

    Public Sub New(graphics As Graphics)
        If graphics Is Nothing Then Throw New ArgumentNullException("graphics")
        Me._graphics = graphics
    End Sub

    ''' <summary>
    ''' Return height for a text when in autosize mode.
    ''' </summary>
    Public Function GetTextHeight(text As String, width As Integer) As Integer
        Dim formatter As New TextFormatter(Me.Align, Me.WordWrap, Me.Trimming, Me.Justify)
        Dim textSize As Size = Me._graphics.MeasureString(text, Me.Font,
                                                          width - Margin.Horizontal,
                                                          formatter.Format).ToSize
        Return textSize.Height + Me.Margin.Vertical + 1

    End Function

    Public Function GetTextHeight(text As String) As Integer
        Dim textSize As Size = Me._graphics.MeasureString(text, Me.Font).ToSize
        Return textSize.Height + Me.Margin.Vertical + 1

    End Function

    ''' <summary>
    ''' Return a width for a text
    ''' </summary>
    Public Function GetTextWidth(text As String) As Integer
        Dim textSize As Size = Me._graphics.MeasureString(text, Me.Font).ToSize
        Return textSize.Width + Me.Margin.Horizontal + 1

    End Function

    Public Sub Draw(text As String, rect As Rectangle)
        If Me._graphics Is Nothing Then Return
        If String.IsNullOrEmpty(text) Then Return

        Dim formatter As New TextFormatter(Me.Align, Me.WordWrap, Me.Trimming, Me.Justify)
        Using b = New SolidBrush(Me.Color)
            If Me.Justify AndAlso Me.WordWrap Then
                rect = Me.GetPaddingRect(rect)
                Dim ranges As IList(Of WordRange) = WordRange.GetRanges(text, _graphics, Me.Font)
                formatter.Format.SetMeasurableCharacterRanges(ranges.Select(Function(r) r.Range).ToArray)
                ' lista de palavras por linha
                Dim rows As IList(Of Integer) = _graphics.
                    MeasureCharacterRanges(text, Me.Font, rect, formatter.Format).
                    Select(Function(rg) rg.GetBounds(_graphics)).
                    GroupBy(Function(r) CInt(r.Top)).
                    Select(Function(g, r) g.Count).
                    ToList()

                Dim y As Single = rect.Top
                Dim lineHeight As Single = Me.Font.GetHeight(_graphics)
                Dim wordIndex As Integer = 0

                For r As Integer = 0 To rows.Count - 1
                    If y + lineHeight > rect.Bottom Then Exit For
                    Dim wordCount As Integer = rows(r)
                    ' calculates width of all words on each line
                    Dim rowWidth As Single = Enumerable.Range(0, wordCount).
                                                        Sum(Function(i) ranges(wordIndex + i).Width)
                    Dim wordSpacing As Single = Math.Max(0, (rect.Width - rowWidth) / (wordCount - 1))
                    Dim x As Single = rect.Left
                    For col As Integer = 1 To wordCount
                        Dim range As WordRange = ranges(wordIndex)
                        Me._graphics.DrawString(range.Word, Me.Font, b, x, y)
                        x = x + range.Width + wordSpacing
                        wordIndex += 1
                        If wordSpacing = 0 Then Exit For
                    Next
                    y += lineHeight
                Next

            Else
                Me._graphics.DrawString(text, Me.Font, b, Me.GetPaddingRect(rect), formatter.Format)

            End If

        End Using

    End Sub

    ''' <summary>
    ''' Calculates a retangle with padding
    ''' </summary>
    Private Function GetPaddingRect(rect As Rectangle) As Rectangle
        rect.Size = New Size(rect.Size.Width - Me.Margin.Horizontal,
                             rect.Size.Height - Me.Margin.Vertical)
        rect.Offset(Me.Margin.Left, Me.Margin.Top)
        Return rect

    End Function

    ''' <summary>
    ''' Internal struct for justified text drawing
    ''' </summary>
    ''' <remarks></remarks>
    Private Structure WordRange
        Public Range As CharacterRange
        Public Word As String
        Public Width As Single

        Public Shared Function GetRange(text As String,
                                 charRange As CharacterRange,
                                 g As Graphics, f As Font) As WordRange
            Dim result As New WordRange
            result.Range = charRange
            result.Word = text.Substring(result.Range.First, result.Range.Length)
            result.Width = g.MeasureString(result.Word, f).Width
            Return result

        End Function

        Public Shared Function GetRanges(text As String,
                                  g As Graphics, f As Font) As IList(Of WordRange)
            Dim nextPos As Integer = 0
            Dim curPos As Integer = 0
            Dim ranges As New List(Of WordRange)
            While (nextPos > -1)
                nextPos = text.IndexOf(" ", curPos)
                If (nextPos <> -1) Then
                    ranges.Add(GetRange(text,
                                        New CharacterRange(curPos, nextPos - curPos),
                                        g, f))
                    curPos = nextPos + 1
                End If
            End While
            ranges.Add(GetRange(text,
                                New CharacterRange(curPos, text.Length - curPos),
                                g, f))
            Return ranges

        End Function

    End Structure

    ''' <summary>
    ''' Internal class for text formatting
    ''' </summary>
    ''' <remarks></remarks>
    Private Class TextFormatter
        Private _format As StringFormat
        Public ReadOnly Property Format() As StringFormat
            Get
                Return _format
            End Get
        End Property

        Public Sub New(align As AlignmentOption,
                       wordWrap As Boolean,
                       trimming As TextTrimmingOption,
                       justify As Boolean)

            _format = New StringFormat()

            If Not wordWrap Then
                _format.FormatFlags = _format.FormatFlags Or
                    StringFormatFlags.NoWrap
            End If

            _format.Trimming = StringTrimming.None
            Select Case trimming
                Case TextTrimmingOption.Character
                    _format.Trimming = StringTrimming.Character
                Case TextTrimmingOption.Word
                    _format.Trimming = StringTrimming.Word
                Case TextTrimmingOption.CharacterEllipsis
                    _format.Trimming = StringTrimming.EllipsisCharacter
                Case TextTrimmingOption.WordEllipsis
                    _format.Trimming = StringTrimming.EllipsisWord
            End Select

            _format.LineAlignment = VerticalAlignment(align)
            If justify Then
                _format.Alignment = StringAlignment.Near
            Else
                _format.Alignment = HorizontalAlignment(align)
            End If

        End Sub

        Private Function HorizontalAlignment(align As AlignmentOption) As StringAlignment
            If (align And (AlignmentOption.TopLeft Or
                           AlignmentOption.MiddleLeft Or
                           AlignmentOption.BottomLeft)) <> 0 Then
                Return StringAlignment.Near
            ElseIf (align And (AlignmentOption.TopRight Or
                               AlignmentOption.MiddleRight Or
                               AlignmentOption.BottomRight)) <> 0 Then
                Return StringAlignment.Far
            Else
                Return StringAlignment.Center
            End If

        End Function

        Private Function VerticalAlignment(align As AlignmentOption) As StringAlignment
            If (align And (AlignmentOption.TopCenter Or
                           AlignmentOption.TopLeft Or
                           AlignmentOption.TopRight)) <> 0 Then
                Return StringAlignment.Near
            ElseIf (align And (AlignmentOption.BottomCenter Or
                               AlignmentOption.BottomLeft Or
                               AlignmentOption.BottomRight)) <> 0 Then
                Return StringAlignment.Far
            Else
                Return StringAlignment.Center
            End If

        End Function

    End Class

End Class
