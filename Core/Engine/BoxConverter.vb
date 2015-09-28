''' <summary>
''' Box builder for report controls
''' </summary>
''' <remarks></remarks>
Friend NotInheritable Class BoxConverter

    Public Shared Function [From](ctr As IBaseControl) As ReportBox
        Dim result As ReportBox = New ReportBox() With {
            .Alignment = ctr.Alignment,
            .BackColor = ctr.BackColor,
            .Border = ctr.Border,
            .BorderColor = ctr.BorderColor,
            .BorderStyle = ctr.BorderStyle,
            .BorderWeight = ctr.BorderWeight,
            .Bounds = ctr.Bounds,
            .Font = ctr.Font,
            .ForeColor = ctr.ForeColor,
            .Margin = ctr.Padding,
            .Orientation = ctr.Orientation
        }

        If TypeOf ctr Is IBaseTextControl Then
            With CType(ctr, IBaseTextControl)
                result.Text = .Text
                result.TextJustified = .TextJustified
                result.TrimmingMode = .TrimmingMode
                result.WordWrap = .WordWrap
            End With
        End If

        Return result

    End Function

End Class
