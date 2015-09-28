Imports System.Drawing

Friend NotInheritable Class GraphicHelper

    ''' <summary>
    ''' Convert value from specified unit to pixel on horizontal resolution
    ''' </summary>
    Public Shared Function ToPixelX(graph As Graphics,
                                     value As Double,
                                     scale As GraphicsUnit) As Integer
        Select Case scale
            Case GraphicsUnit.Millimeter
                Return CInt(Math.Truncate(graph.DpiX * value / 25.4))

            Case GraphicsUnit.Inch
                Return CInt(Math.Truncate(graph.DpiX * value))

            Case GraphicsUnit.Point
                Return CInt(Math.Truncate(graph.DpiX * value / 72))

            Case GraphicsUnit.Document
                Return CInt(Math.Truncate(graph.DpiX * value / 300))

        End Select

        Return CInt(value)

    End Function

    ''' <summary>
    ''' Convert value from specified unit to pixel on vertical resolution
    ''' </summary>
    Public Shared Function ToPixelY(graph As Graphics,
                                     value As Double,
                                     scale As GraphicsUnit) As Integer
        Select Case scale
            Case GraphicsUnit.Millimeter
                Return CInt(Math.Truncate(graph.DpiY * value / 25.4))

            Case GraphicsUnit.Inch
                Return CInt(Math.Truncate(graph.DpiY * value))

            Case GraphicsUnit.Point
                Return CInt(Math.Truncate(graph.DpiY * value / 72))

            Case GraphicsUnit.Document
                Return CInt(Math.Truncate(graph.DpiY * value / 300))

        End Select

        Return CInt(value)

    End Function

End Class
