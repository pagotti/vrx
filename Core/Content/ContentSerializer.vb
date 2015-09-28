Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

''' <summary>
''' Serialize and deserialize control information for cache in files
''' </summary>
''' <typeparam name="T"></typeparam>
''' <remarks></remarks>
Public Class ContentSerializer(Of T)

    Public Shared Sub Serialize(filename As String, obj As T)
        Dim stream As Stream = File.Open(filename, FileMode.Create)
        Dim bFormatter As BinaryFormatter = New BinaryFormatter()
        bFormatter.Serialize(stream, obj)
        stream.Close()

    End Sub

    Public Shared Function DeSerialize(filename As String) As T
        If String.IsNullOrEmpty(filename) Then Throw New ArgumentNullException("filename")
        Dim obj As T
        Dim stream As Stream = File.Open(filename, FileMode.Open)
        Dim bFormatter As BinaryFormatter = New BinaryFormatter()
        obj = CType(bFormatter.Deserialize(stream), T)
        stream.Close()
        Return obj

    End Function

End Class
