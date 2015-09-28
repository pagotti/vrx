Imports System.Drawing
Imports System.Drawing.Design
Imports System.ComponentModel

''' <summary>
''' Represents a base control to draw text
''' </summary>
''' <remarks></remarks>
<DefaultBindingProperty("Text")>
Public Class ReportText
    Inherits ReportControl
    Implements IBaseTextControl

    Protected Overrides Sub OnControlPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnControlPaint(e)

        'Add your custom paint code here
        Dim maker As New TextMaker(e.Graphics) With {
            .Font = Me.Font,
            .Color = Me.ForeColor,
            .Align = Me.Alignment,
            .WordWrap = Me.WordWrap,
            .Trimming = Me.TrimmingMode,
            .Margin = BoxMarginConverter.FromPadding(Me.Padding),
            .Justify = Me.TextJustified
        }
        ' TODO: Check Autosize
        maker.Draw(Me.Text, e.ClipRectangle)

    End Sub

    Private Sub ResizeAsNeed()
        If (Me.FitContent) AndAlso
            (Me.Orientation = OrientationOption.Horizontal OrElse
             Me.Orientation = OrientationOption.UpsideDown) Then
            Dim t As New TextMaker(Me.CreateGraphics) With {
                .Font = Me.Font,
                .Align = Me.Alignment,
                .WordWrap = Me.WordWrap,
                .Trimming = Me.TrimmingMode,
                .Margin = BoxMarginConverter.FromPadding(Me.Padding)
            }
            If Me._wordWrap Then
                Me.Bounds = New Rectangle(Me.Bounds.Location,
                                          New Size(Me.Bounds.Width,
                                                   t.GetTextHeight(Me.Text, Me.Bounds.Width)))
            Else
                Me.Bounds = New Rectangle(Me.Bounds.Location,
                                          New Size(t.GetTextWidth(Me.Text),
                                                   t.GetTextHeight(Me.Text)))
            End If

        End If

    End Sub

#Region "User Properties"

    Private _trimmingMode As TextTrimmingOption = TextTrimmingOption.None
    <Category("Behavior"),
    Description("Indicates how text is trim when overflow the control's size"),
    DefaultValue(GetType(TextTrimmingOption), "None")>
    Public Property TrimmingMode As TextTrimmingOption
        Get
            Return _trimmingMode
        End Get
        Set(value As TextTrimmingOption)
            _trimmingMode = value
            RaisePropertyChanged()
        End Set
    End Property

    Private _textJustified As Boolean = False
    <Category("Behavior"),
    Description("Indicates that text value of field must be justified"),
    DefaultValue(False)>
    Public Property TextJustified As Boolean
        Get
            Return _textJustified
        End Get
        Set(value As Boolean)
            _textJustified = value
            RaisePropertyChanged()
        End Set
    End Property

    Private _wordWrap As Boolean = False
    <Category("Behavior"),
    Description("Indicates that word's text wraps"),
    DefaultValue(False)>
    Public Property WordWrap As Boolean
        Get
            Return _wordWrap
        End Get
        Set(value As Boolean)
            _wordWrap = value
            ResizeAsNeed()
            RaisePropertyChanged()
        End Set
    End Property

#End Region

#Region "PropertyChanged"


    ''' <summary>
    ''' Resize on certain properties changed
    ''' </summary>
    Protected Overrides Sub OnPropertyChanged(e As PropertyChangedEventArgs)
        If "Text;Font;Padding;Orientation;FitContent".
            IndexOf(e.PropertyName, StringComparison.InvariantCultureIgnoreCase) >= 0 Then
            ResizeAsNeed()
        End If

        MyBase.OnPropertyChanged(e)
    End Sub

#End Region

#Region "IBaseTextControl"

    Private ReadOnly Property Text1 As String Implements IBaseTextControl.Text
        Get
            Return Me.Text
        End Get
    End Property

    Private ReadOnly Property TextJustified1 As Boolean Implements IBaseTextControl.TextJustified
        Get
            Return Me.TextJustified
        End Get
    End Property

    Private ReadOnly Property TrimmingMode1 As TextTrimmingOption Implements IBaseTextControl.TrimmingMode
        Get
            Return Me.TrimmingMode
        End Get
    End Property

    Private ReadOnly Property WordWrap1 As Boolean Implements IBaseTextControl.WordWrap
        Get
            Return Me.WordWrap
        End Get
    End Property

#End Region

End Class
