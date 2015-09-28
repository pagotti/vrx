Imports System.Drawing

''' <summary>
''' Base interface for all controls
''' </summary>
Public Interface IBaseControl

    ReadOnly Property Bounds As Rectangle
    ReadOnly Property Font As Font
    ReadOnly Property BackColor As Color
    ReadOnly Property ForeColor As Color
    ReadOnly Property Padding As BoxMargin

    ReadOnly Property Alignment As AlignmentOption
    ReadOnly Property Border As BorderOption
    ReadOnly Property BorderStyle As BorderStyleOption
    ReadOnly Property BorderColor As Color
    ReadOnly Property BorderWeight As Integer
    ReadOnly Property Display As DisplayOption
    ReadOnly Property Orientation As OrientationOption
    ReadOnly Property FitContent As Boolean

End Interface
