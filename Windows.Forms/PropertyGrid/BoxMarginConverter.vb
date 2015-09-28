Imports System.Windows.Forms

''' <summary>
''' Translator between padding and box margin
''' </summary>
''' <remarks></remarks>
Public Class BoxMarginConverter

    Public Shared Function FromPadding(value As Padding) As BoxMargin
        Return New BoxMargin(value.Left, value.Top, value.Right, value.Bottom)
    End Function

    Public Shared Function ToPadding(value As BoxMargin) As Padding
        Return New Padding(value.Left, value.Top, value.Right, value.Bottom)
    End Function

End Class
