Imports System.Drawing
Imports System.Drawing.Design
Imports System.ComponentModel
Imports System.Windows.Forms

''' <summary>
''' Represent a base control with common properties and for extend controls
''' </summary>
<DesignerAttribute(GetType(ReportControlDesigner))>
Public Class ReportControl
    Inherits Control
    Implements INotifyPropertyChanged
    Implements IBaseControl

    Protected Overrides Sub OnPaint(e As Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'Add your custom paint code here
        Dim rect As New Rectangle(Me.ClientRectangle.Location,
                                  New Size(ClientRectangle.Width - 1, ClientRectangle.Height - 1))

        If Not Me.Border = BorderOption.None Then
            Dim maker As New BorderMaker(e.Graphics) With {
                .Border = Me.Border,
                .Style = Me.BorderStyle,
                .Color = Me.BorderColor,
                .Weight = Me.BorderWeight}
            maker.Draw(rect, 192)

        End If

        Using context As New OrientationContext(e.Graphics, Me.Orientation)
            Dim args As New PaintEventArgs(e.Graphics, context.FlipRectangle(rect))
            Me.OnControlPaint(args)

        End Using

    End Sub

    ''' <summary>
    ''' Allow extend controls to draw with right text orientation
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnControlPaint(e As Windows.Forms.PaintEventArgs)
    End Sub

#Region "User Properties"
    ' Already in Base
    ' Font, ForeColor, BackColor

    Private _alignment As AlignmentOption = AlignmentOption.TopLeft
    <Category("Appearance"),
    Description("Determines the content alignment of control"),
    Editor(GetType(AlignmentEditor), GetType(UITypeEditor)),
    DefaultValue(GetType(AlignmentOption), "TopLeft")>
    Public Property Alignment As AlignmentOption
        Get
            Return _alignment
        End Get
        Set(value As AlignmentOption)
            _alignment = value
            RaisePropertyChanged()
        End Set
    End Property

    Private _border As BorderOption = BorderOption.None
    <Category("Appearance"),
    Browsable(True),
    Editor(GetType(BorderEditor), GetType(UITypeEditor)),
    Description("Indicates the border visibility of control")>
    Public Property Border As BorderOption
        Get
            Return _border
        End Get
        Set(value As BorderOption)
            _border = value
            RaisePropertyChanged()
        End Set
    End Property

    Private _borderStyle As BorderStyleOption = BorderStyleOption.Solid
    <Category("Appearance"),
    Description("Indicates the style of visible borders of control"),
    DefaultValue(GetType(BorderStyleOption), "Solid")>
    Public Property BorderStyle As BorderStyleOption
        Get
            Return _borderStyle
        End Get
        Set(value As BorderStyleOption)
            _borderStyle = value
            RaisePropertyChanged()
        End Set
    End Property

    Private _borderColor As Color = Color.Black
    <Category("Appearance"),
    Description("Indicates the color of visible borders of control"),
    DefaultValue(GetType(Color), "Black")>
    Public Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
            RaisePropertyChanged()
        End Set
    End Property

    Private _borderWeight As Integer = 1
    <Category("Appearance"),
    Description("Indicates the weight of visible borders of control"),
    DefaultValue(1)>
    Public Property BorderWeight As Integer
        Get
            Return _borderWeight
        End Get
        Set(value As Integer)
            _borderWeight = Math.Max(0, value)
            RaisePropertyChanged()
        End Set
    End Property

    Private _display As DisplayOption = DisplayOption.Always
    <Category("Behavior"),
    Description("Indicates the visibility of content"),
    DefaultValue(GetType(DisplayOption), "Always")>
    Public Property Display As DisplayOption
        Get
            Return _display
        End Get
        Set(value As DisplayOption)
            _display = value
            RaisePropertyChanged()
        End Set
    End Property

    Private _orientation As OrientationOption = OrientationOption.Horizontal
    <Category("Behavior"),
    Description("Indicates the orientation of content"),
    DefaultValue(GetType(OrientationOption), "Horizontal")>
    Public Property Orientation As OrientationOption
        Get
            Return _orientation
        End Get
        Set(value As OrientationOption)
            _orientation = value
            RaisePropertyChanged()
        End Set
    End Property

    Private _fitContent As Boolean
    <Category("Behavior"),
    Description("Indicates that control will be resize in width and height to fit content"),
    DefaultValue(False)>
    Public Property FitContent As Boolean
        Get
            Return _fitContent
        End Get
        Set(value As Boolean)
            _fitContent = value
            RaisePropertyChanged()
        End Set
    End Property

#End Region

#Region "PropertyChanged"

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Protected Overridable Sub OnPropertyChanged(e As PropertyChangedEventArgs)
        Me.Invalidate()

    End Sub

    Friend Sub RaisePropertyChanged(<Runtime.CompilerServices.CallerMemberName> Optional caller As String = "")
        Dim changeArgs As New PropertyChangedEventArgs(caller)
        OnPropertyChanged(changeArgs)
        RaiseEvent PropertyChanged(Me, changeArgs)
    End Sub

    Protected Overrides Sub OnPaddingChanged(e As EventArgs)
        RaisePropertyChanged("Padding")
        MyBase.OnPaddingChanged(e)
    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        RaisePropertyChanged("Text")
        MyBase.OnTextChanged(e)
    End Sub

    Protected Overrides Sub OnFontChanged(e As EventArgs)
        RaisePropertyChanged("Font")
        MyBase.OnFontChanged(e)
    End Sub

#End Region

#Region "IBaseControl"

    Private ReadOnly Property Alignment1 As AlignmentOption Implements IBaseControl.Alignment
        Get
            Return Me.Alignment
        End Get
    End Property

    Private ReadOnly Property BackColor1 As Color Implements IBaseControl.BackColor
        Get
            Return Me.BackColor
        End Get
    End Property

    Private ReadOnly Property Border1 As BorderOption Implements IBaseControl.Border
        Get
            Return Me.Border
        End Get
    End Property

    Private ReadOnly Property BorderColor1 As Color Implements IBaseControl.BorderColor
        Get
            Return Me.BorderColor
        End Get
    End Property

    Private ReadOnly Property BorderStyle1 As BorderStyleOption Implements IBaseControl.BorderStyle
        Get
            Return Me.BorderStyle
        End Get
    End Property

    Private ReadOnly Property BorderWeight1 As Integer Implements IBaseControl.BorderWeight
        Get
            Return Me.BorderWeight
        End Get
    End Property

    Private ReadOnly Property Bounds1 As Rectangle Implements IBaseControl.Bounds
        Get
            Dim result As Rectangle = Me.ClientRectangle
            result.Offset(Me.Location)
            Return result
        End Get
    End Property

    Private ReadOnly Property Display1 As DisplayOption Implements IBaseControl.Display
        Get
            Return Me.Display
        End Get
    End Property

    Private ReadOnly Property FitContent1 As Boolean Implements IBaseControl.FitContent
        Get
            Return Me.FitContent
        End Get
    End Property

    Private ReadOnly Property Font1 As Font Implements IBaseControl.Font
        Get
            Return Me.Font
        End Get
    End Property

    Private ReadOnly Property ForeColor1 As Color Implements IBaseControl.ForeColor
        Get
            Return Me.ForeColor
        End Get
    End Property

    Private ReadOnly Property Orientation1 As OrientationOption Implements IBaseControl.Orientation
        Get
            Return Me.Orientation
        End Get
    End Property

    Private ReadOnly Property Padding1 As BoxMargin Implements IBaseControl.Padding
        Get
            Return BoxMarginConverter.FromPadding(Me.Padding)
        End Get
    End Property

#End Region

End Class
