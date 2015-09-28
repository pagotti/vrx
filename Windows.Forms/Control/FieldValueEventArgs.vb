Public Class FieldValueEventArgs
    Inherits EventArgs

    Public ReadOnly Row As DataRow
    Public Property Value As Object
    Public Property Handled As Boolean

    Public Sub New(row As DataRow)
        Me.Row = row
        Me.Handled = False
    End Sub

End Class
