Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design
Imports System.Security.Permissions

''' <summary>
''' Designer for sections
''' </summary>
''' <remarks></remarks>
<PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")>
Public Class ReportSectionDesigner
    Inherits ScrollableControlDesigner

    Protected Overrides Sub OnPaintAdornments(ByVal pe As System.Windows.Forms.PaintEventArgs)
        Using p As New Pen(Brushes.Black)
            p.DashStyle = Drawing2D.DashStyle.Dot
            pe.Graphics.DrawRectangle(p, 0, 0, Me.Control.Size.Width - 1, Me.Control.Size.Height - 1)
        End Using

    End Sub

    ''' <summary>
    ''' Only ReportControl on sections
    ''' </summary>    
    Public Overrides Function CanParent(controlDesigner As ControlDesigner) As Boolean
        Return (TypeOf controlDesigner Is ReportControlDesigner)

    End Function

    Public Overrides Function CanParent(control As Control) As Boolean
        Return (TypeOf control Is ReportControl)

    End Function

    ''' <summary>
    ''' Prevents size left/up and move sections
    ''' </summary>
    Public Overrides ReadOnly Property SelectionRules As SelectionRules
        Get
            Return Windows.Forms.Design.SelectionRules.RightSizeable Or
                Windows.Forms.Design.SelectionRules.BottomSizeable Or
                Windows.Forms.Design.SelectionRules.Locked
        End Get
    End Property

End Class
