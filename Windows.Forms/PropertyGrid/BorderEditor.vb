Imports System.Drawing
Imports System.Drawing.Design
Imports System.Windows.Forms.Design

''' <summary>
''' Editor for border property
''' </summary>
''' <remarks></remarks>
Friend NotInheritable Class BorderEditor
    Inherits UITypeEditor

    Public Overrides Function GetEditStyle(context As ComponentModel.ITypeDescriptorContext) As UITypeEditorEditStyle
        Return UITypeEditorEditStyle.DropDown
    End Function

    ''' <summary>
    ''' Open border window on open
    ''' </summary>
    Public Overrides Function EditValue(context As ComponentModel.ITypeDescriptorContext, provider As IServiceProvider, value As Object) As Object
        If provider IsNot Nothing Then
            Dim editorService As IWindowsFormsEditorService
            editorService = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)
            Dim selectionControl As New BorderEditorControl(CType(value, BorderOption), editorService)
            editorService.DropDownControl(selectionControl)
            value = selectionControl.Border

        End If
        Return value

    End Function

    Public Overrides Function GetPaintValueSupported(context As ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function

    Public Overrides Sub PaintValue(e As PaintValueEventArgs)
        Dim area As New Rectangle(e.Bounds.Left + 2, e.Bounds.Top + 2, e.Bounds.Width - 5, e.Bounds.Height - 5)
        BorderEditorControl.PaintBorders(area, e.Graphics, CType(e.Value, BorderOption))

    End Sub


End Class
