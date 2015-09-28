Imports System.Drawing.Printing

Public Class Preview

    Private _page As Integer = 0
    Private _total As Integer = 0

    Private Sub PrevButton_Click(sender As Object, e As EventArgs) Handles PrevButton.Click
        If _page > 0 Then _page -= 1
        PrintPreviewControl1.StartPage = _page

    End Sub

    Private Sub NextButton_Click(sender As Object, e As EventArgs) Handles NextButton.Click
        If _page < _total - 1 Then _page += 1
        PrintPreviewControl1.StartPage = _page

    End Sub

    Public Sub New(d As PrintDocument)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        PrintPreviewControl1.Document = d
        AddHandler PrintPreviewControl1.Document.PrintPage, AddressOf Me.OnPrintPage

    End Sub

    Private Sub OnPrintPage(sender As Object, e As PrintPageEventArgs)
        _total += 1
    End Sub


End Class