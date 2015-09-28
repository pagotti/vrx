Imports System.Runtime.Serialization

''' <summary>
''' Throws if defined formula group is invalid for report
''' </summary>
''' <remarks></remarks>
Public Class InvalidGroupFormulaException
    Inherits ApplicationException

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(message As String, innerException As Exception)
        MyBase.New(message, innerException)
    End Sub

    Public Sub New(info As SerializationInfo, context As StreamingContext)
        MyBase.New(info, context)
    End Sub

End Class
