Imports System.Windows.Forms
Imports System.ComponentModel

''' <summary>
''' Represent a base control to draw data
''' </summary>
''' <remarks></remarks>
<DefaultBindingProperty("Text")>
Public Class ReportField
    Inherits ReportText
    Implements IBaseFieldControl

    Public Event GetFieldValue(sender As Object, e As FieldValueEventArgs)

#Region "User Properties"

    Private _columnName As String
    <Category("Data"),
    Description("Indicates the field column name on data source"),
    Bindable(True)>
    Public Property ColumnName As String
        Get
            Return _columnName
        End Get
        Set(value As String)
            _columnName = value
            RaisePropertyChanged()
        End Set
    End Property

    Private _aggregateMode As AggregateOption = AggregateOption.None
    <Category("Data"),
    Description("Indicates how field values are aggregate in report"),
    DefaultValue(AggregateOption.None)>
    Public Property AggregateMode As AggregateOption
        Get
            Return _aggregateMode
        End Get
        Set(value As AggregateOption)
            _aggregateMode = value
            RaisePropertyChanged()
        End Set
    End Property

    Dim _formatString As String
    <Category("Behavior"),
    Description("Indicates Format String to apply on value of field")>
    Public Property FormatString As String
        Get
            Return _formatString
        End Get
        Set(value As String)
            _formatString = value
            RaisePropertyChanged()
        End Set
    End Property

    Dim _hideDuplicates As Boolean = False
    <Category("Behavior"),
    Description("Indicates that value is not repeated if is the same of preview record"),
    DefaultValue(False)>
    Public Property HideDuplicates As Boolean
        Get
            Return _hideDuplicates
        End Get
        Set(value As Boolean)
            _hideDuplicates = value
            RaisePropertyChanged()
        End Set
    End Property

    Dim _isGroupField As Boolean = False
    <Category("Behavior"),
    Description("Indicates that control is part of a group formula when is in a group header section"),
    DefaultValue(False)>
    Public Property IsGroupField As Boolean
        Get
            Return _isGroupField
        End Get
        Set(value As Boolean)
            _isGroupField = value
            RaisePropertyChanged()
        End Set
    End Property

    Dim _groupOrder As Integer = 0
    <Category("Behavior"),
    Description("If this control is a group field, indicates an order index for formulas with than one field"),
    DefaultValue(0)>
    Public Property GroupOrder As Integer
        Get
            Return _groupOrder
        End Get
        Set(value As Integer)
            _groupOrder = value
            RaisePropertyChanged()
        End Set
    End Property

    ''' <summary>
    ''' Text property
    ''' </summary>
    ''' <remarks>
    ''' Ʃ - indicates an aggregate field
    ''' [field name] 
    ''' ? - indicates value from GetFieldValue event
    ''' : - after indicates a format string
    ''' </remarks>
    <Browsable(False)>
    Public Overrides Property Text As String
        Get
            Return String.Concat(
                If(Not Me._aggregateMode = AggregateOption.None,
                   "Ʃ",
                   String.Empty),
                If(Not String.IsNullOrEmpty(Me._columnName),
                   String.Format("[{0}]", Me._columnName),
                   "<?>"),
                If(Not String.IsNullOrEmpty(Me._formatString),
                   String.Concat(":", _formatString),
                   String.Empty)
            )
        End Get
        Set(value As String)
            MyBase.Text = value
        End Set
    End Property

#End Region

#Region "User Events"

    Public Overridable Function OnGetFieldValue(row As DataRow) As Object
        Dim args As New FieldValueEventArgs(row)
        RaiseEvent GetFieldValue(Me, args)

        If args.Handled Then
            Return args.Value
        Else
            Return Nothing
        End If

    End Function

#End Region

#Region "IBaseFieldControl"

    Private ReadOnly Property AggregateMode1 As AggregateOption Implements IBaseFieldControl.AggregateMode
        Get
            Return Me.AggregateMode
        End Get
    End Property

    Private ReadOnly Property ColumnName1 As String Implements IBaseFieldControl.ColumnName
        Get
            Return Me.ColumnName
        End Get
    End Property

    Private ReadOnly Property FormatString1 As String Implements IBaseFieldControl.FormatString
        Get
            Return Me.FormatString
        End Get
    End Property

    Private ReadOnly Property HideDuplicates1 As Boolean Implements IBaseFieldControl.HideDuplicates
        Get
            Return Me.HideDuplicates
        End Get
    End Property

    Private ReadOnly Property GroupColumnIndex As Integer Implements IBaseFieldControl.GroupColumnIndex
        Get
            If Me._isGroupField Then Return Me._groupOrder Else Return -1
        End Get
    End Property

    Private Function GetFieldValue1(row As DataRow) As Object Implements IBaseFieldControl.GetFieldValue
        Return OnGetFieldValue(row)
    End Function

#End Region

End Class
