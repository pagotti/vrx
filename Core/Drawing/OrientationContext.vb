Imports System.Drawing

''' <summary>
''' Transformation helper to write text in direction other than horizontal
''' </summary>
''' <remarks></remarks>
Public Class OrientationContext
    Implements IDisposable

    Private _graphics As Drawing.Graphics
    Private _mode As OrientationOption

    Public Sub New(g As Drawing.Graphics, mode As OrientationOption, bounds As Rectangle)
        Me.New(g, mode)
        _graphics = g
        _mode = mode
        If Not mode = OrientationOption.Horizontal Then
            Select Case mode
                Case OrientationOption.LeftSide
                    g.TranslateTransform(0, bounds.Bottom)
                Case OrientationOption.UpsideDown
                    g.TranslateTransform(bounds.Right, 0)
                Case OrientationOption.RightSide
                    g.TranslateTransform(bounds.Right, 0)
            End Select
        End If

    End Sub

    Public Sub New(g As Drawing.Graphics, mode As OrientationOption)
        MyBase.New()
        _graphics = g
        _mode = mode
        If Not mode = OrientationOption.Horizontal Then
            Dim area As Drawing.SizeF = g.VisibleClipBounds.Size
            g.TranslateTransform(0, area.Height)
            If mode > OrientationOption.LeftSide Then
                g.TranslateTransform(area.Width, 0)
            End If
            If mode > OrientationOption.UpsideDown Then
                g.TranslateTransform(0, -area.Height)
            End If
            g.RotateTransform(-Me.GetAngle)
        End If

    End Sub

    ''' <summary>
    ''' Return a rectangle modified for drawing
    ''' </summary>
    Public Function FlipRectangle(rect As Rectangle) As Drawing.Rectangle
        Select Case _mode
            Case OrientationOption.LeftSide,
                OrientationOption.RightSide
                Return New Rectangle(rect.Location, New Size(rect.Height, rect.Width))
            Case Else
                Return rect
        End Select

    End Function

    ''' <summary>
    ''' Translate mode for angle
    ''' </summary>
    Private Function GetAngle() As Integer
        Select Case _mode
            Case OrientationOption.LeftSide
                Return 90
            Case OrientationOption.UpsideDown
                Return 180
            Case OrientationOption.RightSide
                Return 270
            Case Else
                Return 0
        End Select

    End Function

    Private Sub ExitContext()
        _graphics.ResetTransform()

    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
                ExitContext()
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
