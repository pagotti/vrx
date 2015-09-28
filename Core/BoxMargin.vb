Imports System.ComponentModel

<Serializable>
Public Structure BoxMargin

    Public Sub New(all As Integer)
        Me.All = all
    End Sub

    Public Sub New(left As Integer, top As Integer, right As Integer, bottom As Integer)
        Me.Left = left
        Me.Top = top
        Me.Right = right
        Me.Bottom = bottom
    End Sub

    <NotifyParentProperty(True),
    DefaultValue(0)>
    Public Property All As Integer
        Get
            If Me.Left = Me.Top AndAlso
                Me.Top = Me.Right AndAlso
                Me.Right = Me.Bottom Then
                Return Me.Left
            Else
                Return -1
            End If
        End Get
        Set(value As Integer)
            Me.Left = value
            Me.Right = value
            Me.Top = value
            Me.Bottom = value
        End Set
    End Property

    <NotifyParentProperty(True),
    DefaultValue(0)>
    Public Property Left As Integer

    <NotifyParentProperty(True),
    DefaultValue(0)>
    Public Property Top As Integer

    <NotifyParentProperty(True),
    DefaultValue(0)>
    Public Property Right As Integer

    <NotifyParentProperty(True),
    DefaultValue(0)>
    Public Property Bottom As Integer

    Public Overrides Function ToString() As String
        Return String.Format("{0}; {1}; {2}; {3}", Me.Left, Me.Top, Me.Right, Me.Bottom)

    End Function

    Public ReadOnly Property Horizontal As Integer
        Get
            Return Left + Right
        End Get
    End Property

    Public ReadOnly Property Vertical As Integer
        Get
            Return Top + Bottom
        End Get
    End Property

    Public Shared Function Empty() As BoxMargin
        Return New BoxMargin(0)
    End Function

End Structure
