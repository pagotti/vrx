Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

''' <summary>
''' Editor control for alignment property
''' </summary>
''' <remarks></remarks>
Friend NotInheritable Class AlignmentEditorControl

    Private _alignment As AlignmentOption
    Public Property Alignment As AlignmentOption
        Get
            Return _alignment
        End Get
        Set(value As AlignmentOption)
            _alignment = value
            Select Case value
                Case AlignmentOption.TopLeft
                    TopLeft.Checked = True
                Case AlignmentOption.TopCenter
                    TopCenter.Checked = True
                Case AlignmentOption.TopRight
                    TopRight.Checked = True
                Case AlignmentOption.MiddleLeft
                    MiddleLeft.Checked = True
                Case AlignmentOption.MiddleCenter
                    MiddleCenter.Checked = True
                Case AlignmentOption.MiddleRight
                    MiddleRight.Checked = True
                Case AlignmentOption.BottomLeft
                    BottomLeft.Checked = True
                Case AlignmentOption.BottomCenter
                    BottomCenter.Checked = True
                Case AlignmentOption.BottomRight
                    BottomRight.Checked = True
            End Select
        End Set
    End Property

    Private editorService As IWindowsFormsEditorService

    Public Sub New()
        MyBase.New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Alignment = AlignmentOption.TopLeft

    End Sub

    Public Sub New(alignment As AlignmentOption, service As IWindowsFormsEditorService)
        MyBase.New()

        Me.InitializeComponent()

        Me.editorService = service
        Me.Alignment = alignment

        AddHandler TopLeft.CheckedChanged, AddressOf CheckedChanged
        AddHandler TopCenter.CheckedChanged, AddressOf CheckedChanged
        AddHandler TopRight.CheckedChanged, AddressOf CheckedChanged
        AddHandler MiddleLeft.CheckedChanged, AddressOf CheckedChanged
        AddHandler MiddleCenter.CheckedChanged, AddressOf CheckedChanged
        AddHandler MiddleRight.CheckedChanged, AddressOf CheckedChanged
        AddHandler BottomLeft.CheckedChanged, AddressOf CheckedChanged
        AddHandler BottomCenter.CheckedChanged, AddressOf CheckedChanged
        AddHandler BottomRight.CheckedChanged, AddressOf CheckedChanged

    End Sub

    Private Sub CheckedChanged(sender As Object, e As EventArgs)
        Me._alignment =
            CType([Enum].Parse(GetType(AlignmentOption),
                               CType(sender, RadioButton).Name), 
                  AlignmentOption)
        editorService.CloseDropDown()

    End Sub

End Class
