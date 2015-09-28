<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BorderEditorControl
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
        Me.LeftButtom = New System.Windows.Forms.Button()
        Me.TopButtom = New System.Windows.Forms.Button()
        Me.BottomButtom = New System.Windows.Forms.Button()
        Me.RightButtom = New System.Windows.Forms.Button()
        Me.BorderPanel = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'LeftButtom
        '
        Me.LeftButtom.BackColor = System.Drawing.SystemColors.Control
        Me.LeftButtom.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LeftButtom.Image = Global.VRX.My.Resources.Resources.LeftBorder
        Me.LeftButtom.Location = New System.Drawing.Point(0, 24)
        Me.LeftButtom.Margin = New System.Windows.Forms.Padding(0)
        Me.LeftButtom.Name = "LeftButtom"
        Me.LeftButtom.Size = New System.Drawing.Size(25, 25)
        Me.LeftButtom.TabIndex = 0
        Me.LeftButtom.UseVisualStyleBackColor = False
        '
        'TopButtom
        '
        Me.TopButtom.BackColor = System.Drawing.SystemColors.Control
        Me.TopButtom.FlatAppearance.BorderSize = 0
        Me.TopButtom.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.TopButtom.Image = Global.VRX.My.Resources.Resources.TopBorder
        Me.TopButtom.Location = New System.Drawing.Point(24, 0)
        Me.TopButtom.Margin = New System.Windows.Forms.Padding(0)
        Me.TopButtom.Name = "TopButtom"
        Me.TopButtom.Size = New System.Drawing.Size(25, 25)
        Me.TopButtom.TabIndex = 0
        Me.TopButtom.UseVisualStyleBackColor = False
        '
        'BottomButtom
        '
        Me.BottomButtom.BackColor = System.Drawing.SystemColors.Control
        Me.BottomButtom.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BottomButtom.Image = Global.VRX.My.Resources.Resources.BottomBorder
        Me.BottomButtom.Location = New System.Drawing.Point(24, 48)
        Me.BottomButtom.Margin = New System.Windows.Forms.Padding(0)
        Me.BottomButtom.Name = "BottomButtom"
        Me.BottomButtom.Size = New System.Drawing.Size(25, 25)
        Me.BottomButtom.TabIndex = 0
        Me.BottomButtom.UseVisualStyleBackColor = False
        '
        'RightButtom
        '
        Me.RightButtom.BackColor = System.Drawing.SystemColors.Control
        Me.RightButtom.FlatAppearance.BorderSize = 0
        Me.RightButtom.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.RightButtom.Image = Global.VRX.My.Resources.Resources.RightBorder
        Me.RightButtom.Location = New System.Drawing.Point(48, 24)
        Me.RightButtom.Margin = New System.Windows.Forms.Padding(0)
        Me.RightButtom.Name = "RightButtom"
        Me.RightButtom.Size = New System.Drawing.Size(25, 25)
        Me.RightButtom.TabIndex = 0
        Me.RightButtom.UseVisualStyleBackColor = False
        '
        'BorderPanel
        '
        Me.BorderPanel.Location = New System.Drawing.Point(26, 26)
        Me.BorderPanel.Name = "BorderPanel"
        Me.BorderPanel.Size = New System.Drawing.Size(21, 21)
        Me.BorderPanel.TabIndex = 1
        '
        'BorderEditorControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.BorderPanel)
        Me.Controls.Add(Me.TopButtom)
        Me.Controls.Add(Me.RightButtom)
        Me.Controls.Add(Me.BottomButtom)
        Me.Controls.Add(Me.LeftButtom)
        Me.Name = "BorderEditorControl"
        Me.Size = New System.Drawing.Size(76, 76)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LeftButtom As System.Windows.Forms.Button
    Friend WithEvents TopButtom As System.Windows.Forms.Button
    Friend WithEvents BottomButtom As System.Windows.Forms.Button
    Friend WithEvents RightButtom As System.Windows.Forms.Button
    Friend WithEvents BorderPanel As System.Windows.Forms.Panel

End Class
