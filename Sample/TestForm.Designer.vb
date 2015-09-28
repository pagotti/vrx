<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.ReportBoard1 = New VRX.ReportBoard()
        Me.ReportSection9 = New VRX.ReportSection()
        Me.ReportText2 = New VRX.ReportText()
        Me.ReportSection8 = New VRX.ReportSection()
        Me.ReportText9 = New VRX.ReportText()
        Me.ReportField6 = New VRX.ReportField()
        Me.ReportSection7 = New VRX.ReportSection()
        Me.ReportText8 = New VRX.ReportText()
        Me.ReportField5 = New VRX.ReportField()
        Me.ReportSection6 = New VRX.ReportSection()
        Me.ReportField8 = New VRX.ReportField()
        Me.ReportText6 = New VRX.ReportText()
        Me.ReportSection5 = New VRX.ReportSection()
        Me.ReportField7 = New VRX.ReportField()
        Me.ReportText5 = New VRX.ReportText()
        Me.ReportSection4 = New VRX.ReportSection()
        Me.ReportText7 = New VRX.ReportText()
        Me.ReportField4 = New VRX.ReportField()
        Me.ReportSection3 = New VRX.ReportSection()
        Me.ReportText3 = New VRX.ReportText()
        Me.ReportSection1 = New VRX.ReportSection()
        Me.ReportField1 = New VRX.ReportField()
        Me.ReportField3 = New VRX.ReportField()
        Me.ReportField2 = New VRX.ReportField()
        Me.FooterSection = New VRX.ReportSection()
        Me.ReportText4 = New VRX.ReportText()
        Me.ReportSection2 = New VRX.ReportSection()
        Me.ReportText1 = New VRX.ReportText()
        Me.ReportBoard1.SuspendLayout()
        Me.ReportSection9.SuspendLayout()
        Me.ReportSection8.SuspendLayout()
        Me.ReportSection7.SuspendLayout()
        Me.ReportSection6.SuspendLayout()
        Me.ReportSection5.SuspendLayout()
        Me.ReportSection4.SuspendLayout()
        Me.ReportSection3.SuspendLayout()
        Me.ReportSection1.SuspendLayout()
        Me.FooterSection.SuspendLayout()
        Me.ReportSection2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReportBoard1
        '
        Me.ReportBoard1.AutoScroll = True
        Me.ReportBoard1.BackColor = System.Drawing.Color.White
        Me.ReportBoard1.Controls.Add(Me.ReportSection9)
        Me.ReportBoard1.Controls.Add(Me.ReportSection8)
        Me.ReportBoard1.Controls.Add(Me.ReportSection7)
        Me.ReportBoard1.Controls.Add(Me.ReportSection6)
        Me.ReportBoard1.Controls.Add(Me.ReportSection5)
        Me.ReportBoard1.Controls.Add(Me.ReportSection4)
        Me.ReportBoard1.Controls.Add(Me.ReportSection3)
        Me.ReportBoard1.Controls.Add(Me.ReportSection1)
        Me.ReportBoard1.Controls.Add(Me.FooterSection)
        Me.ReportBoard1.Controls.Add(Me.ReportSection2)
        Me.ReportBoard1.Location = New System.Drawing.Point(36, 13)
        Me.ReportBoard1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ReportBoard1.Name = "ReportBoard1"
        Me.ReportBoard1.Output = VRX.OutputOption.ToPreview
        Me.ReportBoard1.RuleStep = 20
        Me.ReportBoard1.Size = New System.Drawing.Size(1011, 545)
        Me.ReportBoard1.TabIndex = 4
        Me.ReportBoard1.Text = "ReportBoard1"
        Me.ReportBoard1.Title = Nothing
        '
        'ReportSection9
        '
        Me.ReportSection9.Controls.Add(Me.ReportText2)
        Me.ReportSection9.Location = New System.Drawing.Point(0, 71)
        Me.ReportSection9.Mode = VRX.SectionOption.Header
        Me.ReportSection9.Name = "ReportSection9"
        Me.ReportSection9.Size = New System.Drawing.Size(925, 54)
        Me.ReportSection9.TabIndex = 14
        Me.ReportSection9.Text = "ReportSection9"
        '
        'ReportText2
        '
        Me.ReportText2.Alignment = VRX.AlignmentOption.MiddleCenter
        Me.ReportText2.BackColor = System.Drawing.Color.White
        Me.ReportText2.Border = CType((((VRX.BorderOption.Top Or VRX.BorderOption.Left) _
            Or VRX.BorderOption.Right) _
            Or VRX.BorderOption.Bottom), VRX.BorderOption)
        Me.ReportText2.BorderColor = System.Drawing.Color.Orange
        Me.ReportText2.BorderWeight = 3
        Me.ReportText2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReportText2.Location = New System.Drawing.Point(3, 6)
        Me.ReportText2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ReportText2.Name = "ReportText2"
        Me.ReportText2.Padding = New System.Windows.Forms.Padding(10)
        Me.ReportText2.Size = New System.Drawing.Size(691, 41)
        Me.ReportText2.TabIndex = 0
        Me.ReportText2.Text = "Page Header"
        '
        'ReportSection8
        '
        Me.ReportSection8.Controls.Add(Me.ReportText9)
        Me.ReportSection8.Controls.Add(Me.ReportField6)
        Me.ReportSection8.Location = New System.Drawing.Point(0, 269)
        Me.ReportSection8.Mode = VRX.SectionOption.Total
        Me.ReportSection8.Name = "ReportSection8"
        Me.ReportSection8.Size = New System.Drawing.Size(925, 26)
        Me.ReportSection8.TabIndex = 13
        Me.ReportSection8.Text = "ReportSection8"
        '
        'ReportText9
        '
        Me.ReportText9.Alignment = VRX.AlignmentOption.MiddleRight
        Me.ReportText9.BackColor = System.Drawing.Color.White
        Me.ReportText9.Border = VRX.BorderOption.None
        Me.ReportText9.ForeColor = System.Drawing.Color.BlueViolet
        Me.ReportText9.Location = New System.Drawing.Point(387, 1)
        Me.ReportText9.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ReportText9.Name = "ReportText9"
        Me.ReportText9.Size = New System.Drawing.Size(190, 23)
        Me.ReportText9.TabIndex = 0
        Me.ReportText9.Text = "Total"
        '
        'ReportField6
        '
        Me.ReportField6.AggregateMode = VRX.AggregateOption.[Auto]
        Me.ReportField6.Alignment = VRX.AlignmentOption.MiddleRight
        Me.ReportField6.Border = CType((((VRX.BorderOption.Top Or VRX.BorderOption.Left) _
            Or VRX.BorderOption.Right) _
            Or VRX.BorderOption.Bottom), VRX.BorderOption)
        Me.ReportField6.ColumnName = ""
        Me.ReportField6.FormatString = Nothing
        Me.ReportField6.Location = New System.Drawing.Point(584, 1)
        Me.ReportField6.Name = "ReportField6"
        Me.ReportField6.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.ReportField6.Size = New System.Drawing.Size(111, 22)
        Me.ReportField6.TabIndex = 1
        Me.ReportField6.Text = "Ʃ<?>"
        '
        'ReportSection7
        '
        Me.ReportSection7.BackColor = System.Drawing.Color.White
        Me.ReportSection7.Controls.Add(Me.ReportText8)
        Me.ReportSection7.Controls.Add(Me.ReportField5)
        Me.ReportSection7.GroupNumber = 1
        Me.ReportSection7.Location = New System.Drawing.Point(0, 154)
        Me.ReportSection7.Mode = VRX.SectionOption.HeaderGroup
        Me.ReportSection7.Name = "ReportSection7"
        Me.ReportSection7.Size = New System.Drawing.Size(923, 29)
        Me.ReportSection7.TabIndex = 12
        Me.ReportSection7.Text = "ReportSection7"
        '
        'ReportText8
        '
        Me.ReportText8.Alignment = VRX.AlignmentOption.MiddleLeft
        Me.ReportText8.BackColor = System.Drawing.Color.White
        Me.ReportText8.Border = VRX.BorderOption.None
        Me.ReportText8.ForeColor = System.Drawing.Color.Blue
        Me.ReportText8.Location = New System.Drawing.Point(3, 2)
        Me.ReportText8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ReportText8.Name = "ReportText8"
        Me.ReportText8.Size = New System.Drawing.Size(144, 23)
        Me.ReportText8.TabIndex = 3
        Me.ReportText8.Text = "Internal Group"
        '
        'ReportField5
        '
        Me.ReportField5.Alignment = VRX.AlignmentOption.MiddleCenter
        Me.ReportField5.Border = CType((((VRX.BorderOption.Top Or VRX.BorderOption.Left) _
            Or VRX.BorderOption.Right) _
            Or VRX.BorderOption.Bottom), VRX.BorderOption)
        Me.ReportField5.ColumnName = "InitialSubGroup"
        Me.ReportField5.FormatString = Nothing
        Me.ReportField5.IsGroupField = True
        Me.ReportField5.Location = New System.Drawing.Point(153, 3)
        Me.ReportField5.Name = "ReportField5"
        Me.ReportField5.Size = New System.Drawing.Size(111, 22)
        Me.ReportField5.TabIndex = 2
        Me.ReportField5.Text = "[InitialSubGroup]"
        '
        'ReportSection6
        '
        Me.ReportSection6.Controls.Add(Me.ReportField8)
        Me.ReportSection6.Controls.Add(Me.ReportText6)
        Me.ReportSection6.Display = VRX.DisplayOption.Never
        Me.ReportSection6.Location = New System.Drawing.Point(0, 235)
        Me.ReportSection6.Mode = VRX.SectionOption.FooterGroup
        Me.ReportSection6.Name = "ReportSection6"
        Me.ReportSection6.Size = New System.Drawing.Size(923, 34)
        Me.ReportSection6.TabIndex = 11
        Me.ReportSection6.Text = "ReportSection6"
        '
        'ReportField8
        '
        Me.ReportField8.AggregateMode = VRX.AggregateOption.[Auto]
        Me.ReportField8.Alignment = VRX.AlignmentOption.MiddleCenter
        Me.ReportField8.Border = CType((((VRX.BorderOption.Top Or VRX.BorderOption.Left) _
            Or VRX.BorderOption.Right) _
            Or VRX.BorderOption.Bottom), VRX.BorderOption)
        Me.ReportField8.ColumnName = ""
        Me.ReportField8.FormatString = Nothing
        Me.ReportField8.Location = New System.Drawing.Point(584, 4)
        Me.ReportField8.Name = "ReportField8"
        Me.ReportField8.Size = New System.Drawing.Size(111, 22)
        Me.ReportField8.TabIndex = 2
        Me.ReportField8.Text = "Ʃ<?>"
        '
        'ReportText6
        '
        Me.ReportText6.Alignment = VRX.AlignmentOption.MiddleRight
        Me.ReportText6.BackColor = System.Drawing.Color.White
        Me.ReportText6.Border = VRX.BorderOption.None
        Me.ReportText6.ForeColor = System.Drawing.Color.Blue
        Me.ReportText6.Location = New System.Drawing.Point(387, 4)
        Me.ReportText6.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ReportText6.Name = "ReportText6"
        Me.ReportText6.Size = New System.Drawing.Size(190, 23)
        Me.ReportText6.TabIndex = 0
        Me.ReportText6.Text = "External Group Subtotal"
        '
        'ReportSection5
        '
        Me.ReportSection5.Controls.Add(Me.ReportField7)
        Me.ReportSection5.Controls.Add(Me.ReportText5)
        Me.ReportSection5.Display = VRX.DisplayOption.Never
        Me.ReportSection5.GroupNumber = 1
        Me.ReportSection5.Location = New System.Drawing.Point(0, 205)
        Me.ReportSection5.Mode = VRX.SectionOption.FooterGroup
        Me.ReportSection5.Name = "ReportSection5"
        Me.ReportSection5.Size = New System.Drawing.Size(923, 30)
        Me.ReportSection5.TabIndex = 10
        Me.ReportSection5.Text = "ReportSection5"
        '
        'ReportField7
        '
        Me.ReportField7.AggregateMode = VRX.AggregateOption.[Auto]
        Me.ReportField7.Alignment = VRX.AlignmentOption.MiddleCenter
        Me.ReportField7.Border = CType((((VRX.BorderOption.Top Or VRX.BorderOption.Left) _
            Or VRX.BorderOption.Right) _
            Or VRX.BorderOption.Bottom), VRX.BorderOption)
        Me.ReportField7.ColumnName = ""
        Me.ReportField7.FormatString = "0"
        Me.ReportField7.Location = New System.Drawing.Point(584, 4)
        Me.ReportField7.Name = "ReportField7"
        Me.ReportField7.Size = New System.Drawing.Size(111, 22)
        Me.ReportField7.TabIndex = 2
        Me.ReportField7.Text = "Ʃ<?>:0"
        '
        'ReportText5
        '
        Me.ReportText5.Alignment = VRX.AlignmentOption.MiddleRight
        Me.ReportText5.BackColor = System.Drawing.Color.White
        Me.ReportText5.Border = VRX.BorderOption.None
        Me.ReportText5.ForeColor = System.Drawing.Color.Blue
        Me.ReportText5.Location = New System.Drawing.Point(387, 4)
        Me.ReportText5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ReportText5.Name = "ReportText5"
        Me.ReportText5.Size = New System.Drawing.Size(190, 23)
        Me.ReportText5.TabIndex = 0
        Me.ReportText5.Text = "Internal Group Subtotal"
        '
        'ReportSection4
        '
        Me.ReportSection4.BackColor = System.Drawing.Color.White
        Me.ReportSection4.Controls.Add(Me.ReportText7)
        Me.ReportSection4.Controls.Add(Me.ReportField4)
        Me.ReportSection4.Location = New System.Drawing.Point(0, 125)
        Me.ReportSection4.Mode = VRX.SectionOption.HeaderGroup
        Me.ReportSection4.Name = "ReportSection4"
        Me.ReportSection4.Size = New System.Drawing.Size(922, 29)
        Me.ReportSection4.TabIndex = 9
        Me.ReportSection4.Text = "ReportSection4"
        '
        'ReportText7
        '
        Me.ReportText7.Alignment = VRX.AlignmentOption.MiddleLeft
        Me.ReportText7.BackColor = System.Drawing.Color.White
        Me.ReportText7.Border = VRX.BorderOption.None
        Me.ReportText7.ForeColor = System.Drawing.Color.Blue
        Me.ReportText7.Location = New System.Drawing.Point(3, 3)
        Me.ReportText7.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ReportText7.Name = "ReportText7"
        Me.ReportText7.Size = New System.Drawing.Size(144, 23)
        Me.ReportText7.TabIndex = 3
        Me.ReportText7.Text = "External Group"
        '
        'ReportField4
        '
        Me.ReportField4.Alignment = VRX.AlignmentOption.MiddleCenter
        Me.ReportField4.Border = CType((((VRX.BorderOption.Top Or VRX.BorderOption.Left) _
            Or VRX.BorderOption.Right) _
            Or VRX.BorderOption.Bottom), VRX.BorderOption)
        Me.ReportField4.ColumnName = "InitialGroup"
        Me.ReportField4.FormatString = Nothing
        Me.ReportField4.IsGroupField = True
        Me.ReportField4.Location = New System.Drawing.Point(153, 3)
        Me.ReportField4.Name = "ReportField4"
        Me.ReportField4.Size = New System.Drawing.Size(111, 22)
        Me.ReportField4.TabIndex = 2
        Me.ReportField4.Text = "[InitialGroup]"
        '
        'ReportSection3
        '
        Me.ReportSection3.BackColor = System.Drawing.Color.White
        Me.ReportSection3.Controls.Add(Me.ReportText3)
        Me.ReportSection3.Location = New System.Drawing.Point(0, 327)
        Me.ReportSection3.Mode = VRX.SectionOption.Summary
        Me.ReportSection3.Name = "ReportSection3"
        Me.ReportSection3.Size = New System.Drawing.Size(925, 85)
        Me.ReportSection3.TabIndex = 8
        Me.ReportSection3.Text = "ReportSection3"
        '
        'ReportText3
        '
        Me.ReportText3.Alignment = VRX.AlignmentOption.MiddleCenter
        Me.ReportText3.BackColor = System.Drawing.Color.White
        Me.ReportText3.Border = CType((((VRX.BorderOption.Top Or VRX.BorderOption.Left) _
            Or VRX.BorderOption.Right) _
            Or VRX.BorderOption.Bottom), VRX.BorderOption)
        Me.ReportText3.BorderColor = System.Drawing.Color.Maroon
        Me.ReportText3.BorderWeight = 3
        Me.ReportText3.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReportText3.Location = New System.Drawing.Point(3, 4)
        Me.ReportText3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ReportText3.Name = "ReportText3"
        Me.ReportText3.Padding = New System.Windows.Forms.Padding(10)
        Me.ReportText3.Size = New System.Drawing.Size(691, 52)
        Me.ReportText3.TabIndex = 2
        Me.ReportText3.Text = "Summary Page"
        '
        'ReportSection1
        '
        Me.ReportSection1.BackColor = System.Drawing.Color.White
        Me.ReportSection1.Controls.Add(Me.ReportField1)
        Me.ReportSection1.Controls.Add(Me.ReportField3)
        Me.ReportSection1.Controls.Add(Me.ReportField2)
        Me.ReportSection1.Location = New System.Drawing.Point(0, 183)
        Me.ReportSection1.Mode = VRX.SectionOption.Detail
        Me.ReportSection1.Name = "ReportSection1"
        Me.ReportSection1.Size = New System.Drawing.Size(923, 22)
        Me.ReportSection1.TabIndex = 6
        Me.ReportSection1.Text = "ReportSection1"
        '
        'ReportField1
        '
        Me.ReportField1.Alignment = VRX.AlignmentOption.MiddleCenter
        Me.ReportField1.Border = CType((((VRX.BorderOption.Top Or VRX.BorderOption.Left) _
            Or VRX.BorderOption.Right) _
            Or VRX.BorderOption.Bottom), VRX.BorderOption)
        Me.ReportField1.ColumnName = "Code"
        Me.ReportField1.FormatString = Nothing
        Me.ReportField1.Location = New System.Drawing.Point(3, 0)
        Me.ReportField1.Name = "ReportField1"
        Me.ReportField1.Size = New System.Drawing.Size(118, 22)
        Me.ReportField1.TabIndex = 1
        Me.ReportField1.Text = "[Code]"
        '
        'ReportField3
        '
        Me.ReportField3.Alignment = VRX.AlignmentOption.MiddleRight
        Me.ReportField3.Border = CType((((VRX.BorderOption.Top Or VRX.BorderOption.Left) _
            Or VRX.BorderOption.Right) _
            Or VRX.BorderOption.Bottom), VRX.BorderOption)
        Me.ReportField3.ColumnName = "ZipCode"
        Me.ReportField3.FormatString = Nothing
        Me.ReportField3.Location = New System.Drawing.Point(559, 0)
        Me.ReportField3.Name = "ReportField3"
        Me.ReportField3.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.ReportField3.Size = New System.Drawing.Size(135, 22)
        Me.ReportField3.TabIndex = 1
        Me.ReportField3.Text = "[ZipCode]"
        '
        'ReportField2
        '
        Me.ReportField2.Border = CType((((VRX.BorderOption.Top Or VRX.BorderOption.Left) _
            Or VRX.BorderOption.Right) _
            Or VRX.BorderOption.Bottom), VRX.BorderOption)
        Me.ReportField2.ColumnName = "Name"
        Me.ReportField2.FormatString = Nothing
        Me.ReportField2.Location = New System.Drawing.Point(119, 0)
        Me.ReportField2.Name = "ReportField2"
        Me.ReportField2.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.ReportField2.Size = New System.Drawing.Size(441, 22)
        Me.ReportField2.TabIndex = 1
        Me.ReportField2.Text = "[Name]"
        '
        'FooterSection
        '
        Me.FooterSection.BackColor = System.Drawing.Color.White
        Me.FooterSection.Controls.Add(Me.ReportText4)
        Me.FooterSection.Location = New System.Drawing.Point(0, 295)
        Me.FooterSection.Mode = VRX.SectionOption.Footer
        Me.FooterSection.Name = "FooterSection"
        Me.FooterSection.Size = New System.Drawing.Size(923, 32)
        Me.FooterSection.TabIndex = 5
        Me.FooterSection.Text = "ReportSection1"
        '
        'ReportText4
        '
        Me.ReportText4.Alignment = VRX.AlignmentOption.MiddleCenter
        Me.ReportText4.BackColor = System.Drawing.Color.White
        Me.ReportText4.Border = CType((((VRX.BorderOption.Top Or VRX.BorderOption.Left) _
            Or VRX.BorderOption.Right) _
            Or VRX.BorderOption.Bottom), VRX.BorderOption)
        Me.ReportText4.BorderColor = System.Drawing.Color.Maroon
        Me.ReportText4.ForeColor = System.Drawing.Color.BlueViolet
        Me.ReportText4.Location = New System.Drawing.Point(3, 4)
        Me.ReportText4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ReportText4.Name = "ReportText4"
        Me.ReportText4.Size = New System.Drawing.Size(692, 23)
        Me.ReportText4.TabIndex = 0
        Me.ReportText4.Text = "Page Footer"
        '
        'ReportSection2
        '
        Me.ReportSection2.Controls.Add(Me.ReportText1)
        Me.ReportSection2.Location = New System.Drawing.Point(0, 0)
        Me.ReportSection2.Mode = VRX.SectionOption.Title
        Me.ReportSection2.Name = "ReportSection2"
        Me.ReportSection2.Size = New System.Drawing.Size(923, 71)
        Me.ReportSection2.TabIndex = 7
        Me.ReportSection2.Text = "ReportSection2"
        '
        'ReportText1
        '
        Me.ReportText1.Alignment = VRX.AlignmentOption.MiddleCenter
        Me.ReportText1.BackColor = System.Drawing.Color.White
        Me.ReportText1.Border = CType((((VRX.BorderOption.Top Or VRX.BorderOption.Left) _
            Or VRX.BorderOption.Right) _
            Or VRX.BorderOption.Bottom), VRX.BorderOption)
        Me.ReportText1.BorderColor = System.Drawing.Color.Maroon
        Me.ReportText1.BorderWeight = 3
        Me.ReportText1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReportText1.Location = New System.Drawing.Point(3, 4)
        Me.ReportText1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ReportText1.Name = "ReportText1"
        Me.ReportText1.Padding = New System.Windows.Forms.Padding(10)
        Me.ReportText1.Size = New System.Drawing.Size(691, 60)
        Me.ReportText1.TabIndex = 1
        Me.ReportText1.Text = "Title Page"
        '
        'TestForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1226, 656)
        Me.Controls.Add(Me.ReportBoard1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "TestForm"
        Me.Text = "Form1"
        Me.ReportBoard1.ResumeLayout(False)
        Me.ReportSection9.ResumeLayout(False)
        Me.ReportSection8.ResumeLayout(False)
        Me.ReportSection7.ResumeLayout(False)
        Me.ReportSection6.ResumeLayout(False)
        Me.ReportSection5.ResumeLayout(False)
        Me.ReportSection4.ResumeLayout(False)
        Me.ReportSection3.ResumeLayout(False)
        Me.ReportSection1.ResumeLayout(False)
        Me.FooterSection.ResumeLayout(False)
        Me.ReportSection2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportBoard1 As VRX.ReportBoard
    Friend WithEvents ReportText2 As VRX.ReportText
    Friend WithEvents FooterSection As VRX.ReportSection
    Friend WithEvents ReportText4 As VRX.ReportText
    Friend WithEvents ReportSection1 As VRX.ReportSection
    Friend WithEvents ReportField1 As VRX.ReportField
    Friend WithEvents ReportField3 As VRX.ReportField
    Friend WithEvents ReportField2 As VRX.ReportField
    Friend WithEvents ReportSection2 As VRX.ReportSection
    Friend WithEvents ReportText1 As VRX.ReportText
    Friend WithEvents ReportSection3 As VRX.ReportSection
    Friend WithEvents ReportText3 As VRX.ReportText
    Friend WithEvents ReportSection5 As VRX.ReportSection
    Friend WithEvents ReportSection4 As VRX.ReportSection
    Friend WithEvents ReportField4 As VRX.ReportField
    Friend WithEvents ReportText5 As VRX.ReportText
    Friend WithEvents ReportSection7 As VRX.ReportSection
    Friend WithEvents ReportField5 As VRX.ReportField
    Friend WithEvents ReportSection6 As VRX.ReportSection
    Friend WithEvents ReportText6 As VRX.ReportText
    Friend WithEvents ReportSection8 As VRX.ReportSection
    Friend WithEvents ReportField6 As VRX.ReportField
    Friend WithEvents ReportField8 As VRX.ReportField
    Friend WithEvents ReportField7 As VRX.ReportField
    Friend WithEvents ReportText8 As VRX.ReportText
    Friend WithEvents ReportText7 As VRX.ReportText
    Friend WithEvents ReportText9 As VRX.ReportText
    Friend WithEvents ReportSection9 As VRX.ReportSection

End Class
