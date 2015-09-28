Imports System.ComponentModel

Public Class PageSizeConverter
    Inherits ExpandableObjectConverter

    Public Overrides Function GetProperties(context As ITypeDescriptorContext, value As Object, attributes() As Attribute) As PropertyDescriptorCollection
        Return MyBase.GetProperties(context, value, attributes).Sort(New String() {"FromName", "Width", "Height"})
    End Function

    Public Overrides Function GetPropertiesSupported(context As ITypeDescriptorContext) As Boolean
        Return True
    End Function

    Public Overrides Function CanConvertFrom(context As ITypeDescriptorContext, sourceType As Type) As Boolean
        If sourceType.Equals(GetType(String)) Then
            Return True
        End If
        Return MyBase.CanConvertFrom(context, sourceType)
    End Function

    Public Overrides Function CanConvertTo(context As ITypeDescriptorContext, destinationType As Type) As Boolean
        If destinationType.Equals(GetType(String)) Then
            Return True
        End If
        Return MyBase.CanConvertTo(context, destinationType)
    End Function

    Public Overrides Function ConvertFrom(context As ITypeDescriptorContext, culture As Globalization.CultureInfo, value As Object) As Object
        If CanConvertFrom(context, value.GetType) Then
            Dim parsed() As String = CType(value, String).Split(";"c)
            If parsed IsNot Nothing AndAlso parsed.Length = 2 Then
                Return New PageSize With {
                    .WIdth = CInt(parsed(0)),
                    .Height = CInt(parsed(1))
                    }
            Else
                Return PageSize.Default
            End If
        End If
        Return MyBase.ConvertFrom(context, culture, value)
    End Function

    Public Overrides Function ConvertTo(context As ITypeDescriptorContext, culture As Globalization.CultureInfo, value As Object, destinationType As Type) As Object
        If CanConvertTo(context, destinationType) Then
            Return CType(value, PageSize).ToString
        End If
        Return MyBase.ConvertTo(context, culture, value, destinationType)
    End Function

End Class
