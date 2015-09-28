<Serializable>
Public Enum BorderStyleOption
    Solid
    Dash
    Dot
    DashDot
End Enum

Public Class BorderStyleConverter

    Public Shared Function ToDashStyle(style As BorderStyleOption) As System.Drawing.Drawing2D.DashStyle
        Select Case style
            Case BorderStyleOption.Solid
            Case BorderStyleOption.Dot
                Return Drawing.Drawing2D.DashStyle.Dot
            Case BorderStyleOption.Dash
                Return Drawing.Drawing2D.DashStyle.Dash
            Case BorderStyleOption.DashDot
                Return Drawing.Drawing2D.DashStyle.DashDot
        End Select
        Return Drawing.Drawing2D.DashStyle.Solid

    End Function

End Class
