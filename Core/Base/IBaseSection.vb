Imports System.Drawing

''' <summary>
''' Base interface for sections
''' </summary>
Public Interface IBaseSection
    ReadOnly Property Mode As SectionOption
    ReadOnly Property Display As DisplayOption
    ReadOnly Property PageBreak As PageBreakOption
    ReadOnly Property GrowMode As GrowOption
    ReadOnly Property GroupNumber As Integer
    ReadOnly Property Bounds As Rectangle
    ReadOnly Property BackColor As Color

    Function GetControls() As ICollection(Of IBaseControl)

End Interface
