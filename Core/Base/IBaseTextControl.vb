''' <summary>
''' Interface for text
''' </summary>
''' <remarks></remarks>
Public Interface IBaseTextControl
    Inherits IBaseControl

    ReadOnly Property TrimmingMode As TextTrimmingOption
    ReadOnly Property TextJustified As Boolean
    ReadOnly Property WordWrap As Boolean
    ReadOnly Property Text As String

End Interface
