''' <summary>
''' Represents a field value aggregation information
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class AggregatedFieldData

    Public ReadOnly Field As IBaseFieldControl
    Public AggregatedValue As Decimal

    Public Sub New(field As IBaseFieldControl)
        Me.Field = field
    End Sub

End Class
