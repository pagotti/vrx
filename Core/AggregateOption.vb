''' <summary>
''' Options for aggregate fields values
''' </summary>
''' <remarks></remarks>
Public Enum AggregateOption
    None

    ''' <summary>
    ''' For control on group footer, Group, for other location, General
    ''' </summary>
    Auto

    ''' <summary>
    ''' Aggregate reset on start only
    ''' </summary>
    General

    ''' <summary>
    ''' Aggregate reset on group start
    ''' </summary>
    Group

End Enum
