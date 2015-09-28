Imports System.Drawing
Imports System.Drawing.Design
Imports System.Windows.Forms.Design

''' <summary>
''' Editor for alignment property
''' </summary>
''' <remarks></remarks>
Friend NotInheritable Class AlignmentEditor
    Inherits UITypeEditor

    Public Overrides Function GetEditStyle(context As ComponentModel.ITypeDescriptorContext) As UITypeEditorEditStyle
        Return UITypeEditorEditStyle.DropDown
    End Function

    Public Overrides Function EditValue(context As ComponentModel.ITypeDescriptorContext, provider As IServiceProvider, value As Object) As Object
        If provider IsNot Nothing Then
            Dim editorService As IWindowsFormsEditorService
            editorService = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)
            Dim selectionControl As New AlignmentEditorControl(CType(value, AlignmentOption), editorService)
            editorService.DropDownControl(selectionControl)
            value = selectionControl.Alignment

        End If
        Return value

    End Function

End Class
