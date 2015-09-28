Imports System.Drawing

''' <summary>
''' Maker for drawing a background
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class BackgroudMaker

    Private _graphics As Graphics

    Public Sub New(graphics As Graphics)
        If graphics Is Nothing Then Throw New ArgumentNullException("graphics")
        Me._graphics = graphics
    End Sub

    Public Sub Draw(backColor As Color, rect As Rectangle)
        Dim hasBackColor As Boolean = Not backColor.IsEmpty AndAlso Not backColor.Equals(Color.White)
        If hasBackColor Then
            Using bc As New SolidBrush(backColor)
                _graphics.FillRectangle(bc, rect)
            End Using
        End If

    End Sub

End Class
