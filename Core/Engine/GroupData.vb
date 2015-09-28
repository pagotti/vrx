''' <summary>
''' Represent a data group information
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class GroupData

    Public ReadOnly Fields As IList(Of IBaseFieldControl)

    Public Sub New(fields As List(Of IBaseFieldControl))
        Me.Fields = fields
    End Sub

    Public Property CurrentKey As Integer = 0

End Class
