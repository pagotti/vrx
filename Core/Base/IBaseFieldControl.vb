''' <summary>
''' Inteface for a database field
''' </summary>
''' <remarks></remarks>
Public Interface IBaseFieldControl
    Inherits IBaseTextControl

    ReadOnly Property ColumnName As String
    ReadOnly Property GroupColumnIndex As Integer
    ReadOnly Property AggregateMode As AggregateOption
    ReadOnly Property FormatString As String
    ReadOnly Property HideDuplicates As Boolean

    Function GetFieldValue(row As DataRow) As Object

End Interface
