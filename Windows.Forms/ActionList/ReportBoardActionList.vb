Imports System.ComponentModel
Imports System.ComponentModel.Design

Public Class ReportBoardActionList
    Inherits DesignerActionList

    Public Sub New(component As IComponent)
        MyBase.New(component)

    End Sub

    ''' <summary>
    ''' Organize sections on board. Not required for work, just visual.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Organize()
        CType(Me.Component, ReportBoard).Organize()

    End Sub

    Public Overrides Function GetSortedActionItems() As DesignerActionItemCollection
        Dim items As New DesignerActionItemCollection()
        items.Add(New DesignerActionHeaderItem("Sections"))
        items.Add(New DesignerActionMethodItem(Me, "Organize", "Organize Sections"))

        Return items
    End Function


End Class
