Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

''' <summary>
''' Editor control for border property
''' </summary>
''' <remarks></remarks>
Friend NotInheritable Class BorderEditorControl

    Public Property Border As BorderOption
    Private editorService As IWindowsFormsEditorService

    Public Sub New()
        MyBase.New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Border = BorderOption.None

    End Sub

    Public Sub New(border As BorderOption, service As IWindowsFormsEditorService)
        MyBase.New()

        Me.InitializeComponent()

        Me.editorService = service
        Me.Border = border

    End Sub

    Friend Shared Sub PaintBorders(area As Rectangle, graphics As Graphics, value As BorderOption)
        Dim currentBorder As BorderOption = CType(value, BorderOption)

        Using p As New Pen(Brushes.LightGray)
            graphics.DrawRectangle(p, area)
        End Using

        Using p As New Pen(Brushes.Black)
            If currentBorder.HasFlag(BorderOption.Top) Then
                graphics.DrawLine(p, area.Left, area.Top, area.Right, area.Top)
            End If
            If currentBorder.HasFlag(BorderOption.Left) Then
                graphics.DrawLine(p, area.Left, area.Top, area.Left, area.Bottom)
            End If
            If currentBorder.HasFlag(BorderOption.Right) Then
                graphics.DrawLine(p, area.Right, area.Top, area.Right, area.Bottom)
            End If
            If currentBorder.HasFlag(BorderOption.Bottom) Then
                graphics.DrawLine(p, area.Left, area.Bottom, area.Right, area.Bottom)
            End If

        End Using

    End Sub

    Private Sub UpdateBorder(value As BorderOption)
        If Me.Border.HasFlag(value) Then
            Me.Border = Me.Border And (Not value)
        Else
            Me.Border = Me.Border Or value
        End If
        BorderPanel.Refresh()

    End Sub

    Private Sub BorderPanel_Paint(sender As Object, e As PaintEventArgs) Handles BorderPanel.Paint
        Dim area As Rectangle = e.ClipRectangle
        area.Inflate(-4, -4)
        PaintBorders(area, e.Graphics, Me.Border)

    End Sub

    Private Sub BottomButtom_Click(sender As Object, e As EventArgs) Handles BottomButtom.Click
        UpdateBorder(BorderOption.Bottom)

    End Sub

    Private Sub LeftButtom_Click(sender As Object, e As EventArgs) Handles LeftButtom.Click
        UpdateBorder(BorderOption.Left)

    End Sub

    Private Sub RightButtom_Click(sender As Object, e As EventArgs) Handles RightButtom.Click
        UpdateBorder(BorderOption.Right)

    End Sub

    Private Sub TopButtom_Click(sender As Object, e As EventArgs) Handles TopButtom.Click
        UpdateBorder(BorderOption.Top)

    End Sub

End Class
