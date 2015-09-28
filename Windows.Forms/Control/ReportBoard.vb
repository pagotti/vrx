Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Linq

''' <summary>
''' Represents a container for sections and to define report behavior
''' </summary>
''' <remarks></remarks>
<DesignerAttribute(GetType(ReportBoardDesigner))>
Public Class ReportBoard
    Implements INotifyPropertyChanged

    ''' <summary>
    ''' prevent scroll flicker
    ''' </summary>
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000 ' Turn on WS_EX_COMPOSITED
            cp.Style = cp.Style And Not &H2000000 ' Turn off WS_CLIPCHILDREN
            Return cp
        End Get
    End Property

    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        MyBase.OnPaintBackground(e)

        Dim maker As New RuleMaker(e.Graphics)
        maker.Draw(Me.RuleStep, e.ClipRectangle)

    End Sub

#Region "User Properties"

    Private _output As OutputOption = OutputOption.ToAll
    <Category("Behavior"),
    Browsable(True),
    Description("Defines the options for report output"),
    DefaultValue(GetType(OutputOption), "ToAll")>
    Public Property Output As OutputOption
        Get
            Return _output
        End Get
        Set(value As OutputOption)
            _output = value
            RaisePropertyChanged()
        End Set
    End Property

    Private _title As String
    <Category("Behavior"),
    Browsable(True),
    Description("Defines de title of the report")>
    Public Property Title As String
        Get
            Return _title
        End Get
        Set(value As String)
            _title = value
            RaisePropertyChanged()
        End Set
    End Property

    Private _ruleStep As Integer = 0
    <Category("Behavior"),
    Description("Shows a rule on section if value greater than zero. Step value in milimeters."),
    DefaultValue(0)>
    Public Property RuleStep As Integer
        Get
            Return _ruleStep
        End Get
        Set(value As Integer)
            _ruleStep = Math.Max(0, value)
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

    Public Function GetSections() As IList(Of IBaseSection)
        Return Me.Controls.OfType(Of IBaseSection).ToList

    End Function

#End Region

    ''' <summary>
    ''' Organize sections in right visual order by section mode
    ''' </summary>
    Friend Sub Organize()

        Dim sections As List(Of ReportSection) =
            Me.Controls.OfType(Of ReportSection).ToList

        sections.Sort(New SectionComparer)

        sections.ForEach(Sub(s) Debug.WriteLine(s.Mode))

        Dim currentTop As Integer = 0
        For Each section As ReportSection In sections
            If section.Dock <> DockStyle.None Then
                section.Dock = DockStyle.None
            End If
            section.Top = currentTop
            section.Left = 0
            currentTop += section.Height
        Next

        Me.Refresh()

    End Sub

End Class
