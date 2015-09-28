Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Linq

''' <summary>
''' Represents a container for report controls and define behaviors for the child controls
''' </summary>
''' <remarks></remarks>
<DesignerAttribute(GetType(ReportSectionDesigner))>
Public Class ReportSection
    Implements INotifyPropertyChanged
    Implements IBaseSection

    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        'dont call base to make background transparent
        'MyBase.OnPaintBackground(e)

        'Add your custom paint code here
        Dim bkMaker As New BackgroudMaker(e.Graphics)
        bkMaker.Draw(Me.BackColor, e.ClipRectangle)

        Dim maker As SectionMaker
        If TypeOf Me.Parent Is ReportBoard Then
            maker = New SectionMaker(e.Graphics) With {
                .Mode = Me.Mode,
                .PageBreak = Me.PageBreak,
                .GroupNumber = Me.GroupNumber
            }

        Else
            maker = New SectionMaker(e.Graphics)

        End If

        maker.Draw(e.ClipRectangle)

    End Sub

    ''' <summary>
    ''' Prevent scroll flicker
    ''' </summary>
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000 ' Turn on WS_EX_COMPOSITED
            cp.Style = cp.Style And Not &H2000000 ' Turn off WS_CLIPCHILDREN
            Return cp
        End Get
    End Property

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)

        ' resize sections bellow
        Dim baseBottom = Me.Bottom

        If TypeOf Me.Parent Is ReportBoard Then
            For Each section As ReportSection In
                CType(Me.Parent, ReportBoard).Controls.
                    OfType(Of ReportSection).
                    Where(Function(c) c.Top > Me.Top).
                    OrderBy(Function(c) c.Top)

                If section.Top < baseBottom Then
                    section.Top = baseBottom + 1
                End If
                baseBottom = section.Bottom

            Next

        End If

    End Sub

#Region "User Properties"

    Private _mode As SectionOption = SectionOption.Undefined
    <Category("Behavior"),
    Description("Defines the type of section"),
    DefaultValue(GetType(SectionOption), "Undefined")>
    Public Property Mode As SectionOption
        Get
            Return _mode
        End Get
        Set(value As SectionOption)
            _mode = value
            RaisePropertyChanged()
            If Not (_mode = SectionOption.HeaderGroup OrElse
                    _mode = SectionOption.FooterGroup) Then
                Me.GroupNumber = 0
            End If
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

    Private _pageBreak As PageBreakOption = PageBreakOption.None
    <Category("Behavior"),
    Description("Defines page break for the section"),
    DefaultValue(GetType(PageBreakOption), "None")>
    Public Property PageBreak As PageBreakOption
        Get
            Return _pageBreak
        End Get
        Set(value As PageBreakOption)
            _pageBreak = value
            RaisePropertyChanged()
        End Set
    End Property

    Private _growMode As GrowOption = GrowOption.None
    <Category("Behavior"),
    Description("Defines how section grow when controls was out of its border"),
    DefaultValue(GetType(GrowOption), "None")>
    Public Property GrowMode As GrowOption
        Get
            Return _growMode
        End Get
        Set(value As GrowOption)
            _growMode = value
            RaisePropertyChanged()
        End Set
    End Property

    Private _groupNumber As Integer = 0
    <Category("Behavior"),
    Description("Defines group number for header and footer group sections"),
    DefaultValue(0)>
    Public Property GroupNumber As Integer
        Get
            Return _groupNumber
        End Get
        Set(value As Integer)
            _groupNumber = Math.Max(0, value)
            RaisePropertyChanged()
        End Set
    End Property

#End Region

#Region "PropertyChanged"

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Protected Overridable Sub OnPropertyChanged(e As PropertyChangedEventArgs)
        Me.Invalidate()

    End Sub

    Friend Sub RaisePropertyChanged(<Runtime.CompilerServices.CallerMemberName>
                                    Optional caller As String = "")
        Dim changeArgs As New PropertyChangedEventArgs(caller)
        OnPropertyChanged(changeArgs)
        RaiseEvent PropertyChanged(Me, changeArgs)

    End Sub

#End Region

#Region "IBaseSection"

    Private ReadOnly Property BackColor1 As Color Implements IBaseSection.BackColor
        Get
            Return Me.BackColor
        End Get
    End Property

    Private ReadOnly Property Bounds1 As Rectangle Implements IBaseSection.Bounds
        Get
            Return Me.ClientRectangle
        End Get
    End Property

    Private ReadOnly Property Display1 As DisplayOption Implements IBaseSection.Display
        Get
            Return Me.Display
        End Get
    End Property

    Private Function GetControls() As ICollection(Of IBaseControl) Implements IBaseSection.GetControls
        Return Me.Controls.OfType(Of IBaseControl).ToList
    End Function

    Private ReadOnly Property GroupNumber1 As Integer Implements IBaseSection.GroupNumber
        Get
            Return Me.GroupNumber
        End Get
    End Property

    Private ReadOnly Property GrowMode1 As GrowOption Implements IBaseSection.GrowMode
        Get
            Return Me.GrowMode
        End Get
    End Property

    Private ReadOnly Property Mode1 As SectionOption Implements IBaseSection.Mode
        Get
            Return Me.Mode
        End Get
    End Property

    Private ReadOnly Property PageBreak1 As PageBreakOption Implements IBaseSection.PageBreak
        Get
            Return Me.PageBreak
        End Get
    End Property

#End Region

End Class
