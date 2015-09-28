Imports System.Drawing.Printing

''' <summary>
''' Interface for define and extend report planners
''' </summary>
''' <remarks></remarks>
Public Interface IPlanningReport
    Function GetPages() As ICollection(Of PageInfo)

End Interface
