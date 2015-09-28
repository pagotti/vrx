Imports VRX

Public Class TestForm

    Public SampleDataSet As New DataSet

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Using con As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source='" & My.Application.Info.DirectoryPath & "';Extended Properties='text;HDR=Yes;FMT=Delimited'"),
               da As New OleDb.OleDbDataAdapter("SELECT Code,Name,ZipCode FROM Cities#csv", con)
            Try
                da.Fill(SampleDataSet)

                ' Setup calculated fields to control groups
                SampleDataSet.Tables(0).Columns.Add(New DataColumn("InitialGroup", GetType(String), "Substring(Name,1,1)"))
                SampleDataSet.Tables(0).Columns.Add(New DataColumn("InitialSubGroup", GetType(String), "Substring(Name,1,2)"))

            Finally
                con.Close()

            End Try
        End Using

    End Sub

    Private Sub ReportFields_GetFieldValue(sender As Object, e As FieldValueEventArgs) Handles ReportField7.GetFieldValue, ReportField6.GetFieldValue, ReportField8.GetFieldValue
        ' through this event, return calculate values to fields.
        ' use e.Row to access the dataset row is printing
        ' and return value on e.Value
        e.Handled = True
        e.Value = "1"

    End Sub

End Class
