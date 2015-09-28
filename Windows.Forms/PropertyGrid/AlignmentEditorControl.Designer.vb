<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AlignmentEditorControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TopRight = New System.Windows.Forms.RadioButton()
        Me.MiddleLeft = New System.Windows.Forms.RadioButton()
        Me.MiddleCenter = New System.Windows.Forms.RadioButton()
        Me.MiddleRight = New System.Windows.Forms.RadioButton()
        Me.BottomLeft = New System.Windows.Forms.RadioButton()
        Me.BottomCenter = New System.Windows.Forms.RadioButton()
        Me.BottomRight = New System.Windows.Forms.RadioButton()
        Me.TopCenter = New System.Windows.Forms.RadioButton()
        Me.TopLeft = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'TopRight
        '
        Me.TopRight.Appearance = System.Windows.Forms.Appearance.Button
        Me.TopRight.Image = Global.VRX.My.Resources.Resources.AlignTopRight
        Me.TopRight.Location = New System.Drawing.Point(53, 3)
        Me.TopRight.Name = "TopRight"
        Me.TopRight.Size = New System.Drawing.Size(23, 23)
        Me.TopRight.TabIndex = 2
        Me.TopRight.TabStop = True
        Me.TopRight.UseVisualStyleBackColor = True
        '
        'MiddleLeft
        '
        Me.MiddleLeft.Appearance = System.Windows.Forms.Appearance.Button
        Me.MiddleLeft.Image = Global.VRX.My.Resources.Resources.AlignMiddleLeft
        Me.MiddleLeft.Location = New System.Drawing.Point(3, 27)
        Me.MiddleLeft.Name = "MiddleLeft"
        Me.MiddleLeft.Size = New System.Drawing.Size(23, 23)
        Me.MiddleLeft.TabIndex = 2
        Me.MiddleLeft.TabStop = True
        Me.MiddleLeft.UseVisualStyleBackColor = True
        '
        'MiddleCenter
        '
        Me.MiddleCenter.Appearance = System.Windows.Forms.Appearance.Button
        Me.MiddleCenter.Image = Global.VRX.My.Resources.Resources.AlignMiddleCenter
        Me.MiddleCenter.Location = New System.Drawing.Point(28, 27)
        Me.MiddleCenter.Name = "MiddleCenter"
        Me.MiddleCenter.Size = New System.Drawing.Size(23, 23)
        Me.MiddleCenter.TabIndex = 2
        Me.MiddleCenter.TabStop = True
        Me.MiddleCenter.UseVisualStyleBackColor = True
        '
        'MiddleRight
        '
        Me.MiddleRight.Appearance = System.Windows.Forms.Appearance.Button
        Me.MiddleRight.Image = Global.VRX.My.Resources.Resources.AlignMiddleRight
        Me.MiddleRight.Location = New System.Drawing.Point(53, 27)
        Me.MiddleRight.Name = "MiddleRight"
        Me.MiddleRight.Size = New System.Drawing.Size(23, 23)
        Me.MiddleRight.TabIndex = 2
        Me.MiddleRight.TabStop = True
        Me.MiddleRight.UseVisualStyleBackColor = True
        '
        'BottomLeft
        '
        Me.BottomLeft.Appearance = System.Windows.Forms.Appearance.Button
        Me.BottomLeft.Image = Global.VRX.My.Resources.Resources.AlignBottomLeft
        Me.BottomLeft.Location = New System.Drawing.Point(3, 51)
        Me.BottomLeft.Name = "BottomLeft"
        Me.BottomLeft.Size = New System.Drawing.Size(23, 23)
        Me.BottomLeft.TabIndex = 2
        Me.BottomLeft.TabStop = True
        Me.BottomLeft.UseVisualStyleBackColor = True
        '
        'BottomCenter
        '
        Me.BottomCenter.Appearance = System.Windows.Forms.Appearance.Button
        Me.BottomCenter.Image = Global.VRX.My.Resources.Resources.AlignBottomCenter
        Me.BottomCenter.Location = New System.Drawing.Point(28, 51)
        Me.BottomCenter.Name = "BottomCenter"
        Me.BottomCenter.Size = New System.Drawing.Size(23, 23)
        Me.BottomCenter.TabIndex = 2
        Me.BottomCenter.TabStop = True
        Me.BottomCenter.UseVisualStyleBackColor = True
        '
        'BottomRight
        '
        Me.BottomRight.Appearance = System.Windows.Forms.Appearance.Button
        Me.BottomRight.Image = Global.VRX.My.Resources.Resources.AlignBottomRight
        Me.BottomRight.Location = New System.Drawing.Point(53, 51)
        Me.BottomRight.Name = "BottomRight"
        Me.BottomRight.Size = New System.Drawing.Size(23, 23)
        Me.BottomRight.TabIndex = 2
        Me.BottomRight.TabStop = True
        Me.BottomRight.UseVisualStyleBackColor = True
        '
        'TopCenter
        '
        Me.TopCenter.Appearance = System.Windows.Forms.Appearance.Button
        Me.TopCenter.Image = Global.VRX.My.Resources.Resources.AlignTopCenter
        Me.TopCenter.Location = New System.Drawing.Point(28, 3)
        Me.TopCenter.Name = "TopCenter"
        Me.TopCenter.Size = New System.Drawing.Size(23, 23)
        Me.TopCenter.TabIndex = 2
        Me.TopCenter.TabStop = True
        Me.TopCenter.UseVisualStyleBackColor = True
        '
        'TopLeft
        '
        Me.TopLeft.Appearance = System.Windows.Forms.Appearance.Button
        Me.TopLeft.Image = Global.VRX.My.Resources.Resources.AlignTopLeft
        Me.TopLeft.Location = New System.Drawing.Point(3, 3)
        Me.TopLeft.Name = "TopLeft"
        Me.TopLeft.Size = New System.Drawing.Size(23, 23)
        Me.TopLeft.TabIndex = 2
        Me.TopLeft.TabStop = True
        Me.TopLeft.UseVisualStyleBackColor = True
        '
        'AlignmentEditorControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.BottomRight)
        Me.Controls.Add(Me.BottomCenter)
        Me.Controls.Add(Me.MiddleRight)
        Me.Controls.Add(Me.MiddleCenter)
        Me.Controls.Add(Me.BottomLeft)
        Me.Controls.Add(Me.TopRight)
        Me.Controls.Add(Me.MiddleLeft)
        Me.Controls.Add(Me.TopCenter)
        Me.Controls.Add(Me.TopLeft)
        Me.Name = "AlignmentEditorControl"
        Me.Size = New System.Drawing.Size(76, 76)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TopLeft As System.Windows.Forms.RadioButton
    Friend WithEvents TopCenter As System.Windows.Forms.RadioButton
    Friend WithEvents TopRight As System.Windows.Forms.RadioButton
    Friend WithEvents MiddleLeft As System.Windows.Forms.RadioButton
    Friend WithEvents MiddleCenter As System.Windows.Forms.RadioButton
    Friend WithEvents MiddleRight As System.Windows.Forms.RadioButton
    Friend WithEvents BottomLeft As System.Windows.Forms.RadioButton
    Friend WithEvents BottomCenter As System.Windows.Forms.RadioButton
    Friend WithEvents BottomRight As System.Windows.Forms.RadioButton

End Class
