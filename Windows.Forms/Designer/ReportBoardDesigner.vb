Imports System.Drawing
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design
Imports System.Security.Permissions

''' <summary>
''' Designer for report board
''' </summary>
''' <remarks></remarks>
<PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")>
Public Class ReportBoardDesigner
    Inherits ScrollableControlDesigner

    Protected Overrides Sub OnPaintAdornments(ByVal pe As System.Windows.Forms.PaintEventArgs)
        pe.Graphics.DrawRectangle(Pens.Gray, 0, 0, Me.Control.Size.Width - 1, Me.Control.Size.Height - 1)
    End Sub

    Private _actionLists As DesignerActionListCollection
    Public Overrides ReadOnly Property ActionLists As DesignerActionListCollection
        Get
            If _actionLists Is Nothing Then
                _actionLists = New DesignerActionListCollection()
                _actionLists.Add(New ReportBoardActionList(Me.Component))
            End If
            Return _actionLists
        End Get
    End Property

    Public Overrides Function CanParent(controlDesigner As ControlDesigner) As Boolean
        Return (TypeOf controlDesigner Is ReportSectionDesigner)

    End Function

    Public Overrides Function CanParent(control As Control) As Boolean
        Return (TypeOf control Is ReportSection)

    End Function

End Class
