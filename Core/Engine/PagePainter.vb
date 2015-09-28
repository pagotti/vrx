Imports System.Drawing
Imports System.Drawing.Printing

''' <summary>
''' Defines a painter for draw box objects on a device (preview or print)
''' </summary>
Public Class PagePainter

    Private _page As ReportPage
    Public Sub New(page As ReportPage)
        _page = page
    End Sub

    Public Sub Paint(e As PrintPageEventArgs)
        For Each box As ReportBox In _page.Boxes
            box.Paint(e.Graphics)
        Next

    End Sub

End Class
