Public Class StartForm

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim report As New TestForm()
        Dim dp As New VRX.ReportDocument(report.ReportBoard1.GetSections,
                                         report.SampleDataSet.Tables(0))

        Dim f As New PrintPreviewDialog With {.Document = dp}

        ' if you want customize preview, use Preview Form as sample.
        'Dim f As New Preview(dp)

        f.ShowDialog()

    End Sub
End Class