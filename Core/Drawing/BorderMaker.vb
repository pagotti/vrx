Imports System.Drawing

''' <summary>
''' Maker for drawing borders
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class BorderMaker

    Private _graphics As Graphics
    Public Property Border As BorderOption = BorderOption.Rectangle
    Public Property Style As BorderStyleOption = BorderStyleOption.Dot
    Public Property Color As Color = Color.Gray
    Public Property Weight As Integer = 1

    Public Sub New(graphics As Graphics)
        If graphics Is Nothing Then Throw New ArgumentNullException("graphics")
        Me._graphics = graphics
    End Sub

    Public Sub Draw(rect As Rectangle, Optional alpha As Integer = 255)
        If Border = BorderOption.None Then Return

        Dim path As Drawing2D.GraphicsPath =
            New BorderSelector(Me.Border).GetPath(rect, Me.Weight)
        If path.PointCount > 0 Then
            Using p As New Pen(Drawing.Color.FromArgb(alpha, Me.Color))
                p.Alignment = Drawing2D.PenAlignment.Center
                p.DashStyle = BorderStyleConverter.ToDashStyle(Me.Style)
                p.Width = Me.Weight
                Me._graphics.DrawPath(p, path)
            End Using
        End If

    End Sub

    Private Interface IFillPath
        Sub Append(path As Drawing2D.GraphicsPath, rect As Rectangle, penWidth As Integer)
    End Interface

    Private Class LeftBorder
        Implements IFillPath

        Public Sub Append(path As Drawing2D.GraphicsPath, rect As Rectangle, penWidth As Integer) Implements IFillPath.Append
            rect.Offset(penWidth \ 2, 0)
            path.AddLine(rect.Left, rect.Bottom, rect.Left, rect.Top)
        End Sub
    End Class

    Private Class TopBorder
        Implements IFillPath

        Public Sub Append(path As Drawing2D.GraphicsPath, rect As Rectangle, penWidth As Integer) Implements IFillPath.Append
            rect.Offset(0, penWidth \ 2)
            path.AddLine(rect.Left, rect.Top, rect.Right, rect.Top)
        End Sub
    End Class

    Private Class RightBorder
        Implements IFillPath

        Public Sub Append(path As Drawing2D.GraphicsPath, rect As Rectangle, penWidth As Integer) Implements IFillPath.Append
            rect.Offset(-(penWidth \ 2), 0)
            path.AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom)
        End Sub
    End Class

    Private Class BottomBorder
        Implements IFillPath

        Public Sub Append(path As Drawing2D.GraphicsPath, rect As Rectangle, penWidth As Integer) Implements IFillPath.Append
            rect.Offset(0, -(penWidth \ 2))
            path.AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom)
        End Sub
    End Class

    Private Class BorderSelector
        Private _borders As New List(Of IFillPath)

        Public Sub New(border As BorderOption)
            If border.HasFlag(BorderOption.Top) Then
                _borders.Add(New TopBorder())
            End If
            If border.HasFlag(BorderOption.Right) Then
                _borders.Add(New RightBorder())
            End If
            If border.HasFlag(BorderOption.Bottom) Then
                _borders.Add(New BottomBorder())
            End If
            If border.HasFlag(BorderOption.Left) Then
                _borders.Add(New LeftBorder())
            End If
        End Sub

        Public Function GetPath(rect As Rectangle, penWidth As Integer) As Drawing2D.GraphicsPath
            Dim result As New Drawing2D.GraphicsPath()
            For Each b As IFillPath In _borders
                result.StartFigure()
                b.Append(result, rect, penWidth)
                result.CloseFigure()
            Next
            Return result

        End Function

    End Class

End Class
