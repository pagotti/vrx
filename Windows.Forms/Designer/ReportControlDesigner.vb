Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design
Imports System.Security.Permissions

''' <summary>
''' Designer for all report controls
''' </summary>
''' <remarks></remarks>
<PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")>
Public Class ReportControlDesigner
    Inherits ControlDesigner

    Protected Overrides Sub OnPaintAdornments(ByVal pe As System.Windows.Forms.PaintEventArgs)
        Using p As New Pen(Brushes.Black)
            p.DashStyle = Drawing2D.DashStyle.Dot
            pe.Graphics.DrawRectangle(p, 0, 0, Me.Control.Size.Width - 1, Me.Control.Size.Height - 1)
        End Using

    End Sub

    ''' <summary>
    ''' Prevent size changing for wordwrap with autosize
    ''' </summary>
    Public Overrides ReadOnly Property SelectionRules As SelectionRules
        Get
            Dim fitPropDesc As PropertyDescriptor =
                TypeDescriptor.GetProperties(Component)("FitContent")
            Dim wrapPropDesc As PropertyDescriptor =
                TypeDescriptor.GetProperties(Component)("WordWrap")

            If (fitPropDesc IsNot Nothing) AndAlso (wrapPropDesc IsNot Nothing) AndAlso
                fitPropDesc.PropertyType = GetType(Boolean) AndAlso
                fitPropDesc.IsBrowsable AndAlso
                DirectCast(fitPropDesc.GetValue(Component), Boolean) Then

                If DirectCast(wrapPropDesc.GetValue(Component), Boolean) Then
                    Return SelectionRules.Moveable Or
                        SelectionRules.LeftSizeable Or
                        SelectionRules.RightSizeable
                Else
                    Return SelectionRules.Moveable
                End If

            Else
                Return MyBase.SelectionRules

            End If

        End Get
    End Property

End Class
