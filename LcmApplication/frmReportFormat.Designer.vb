<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportFormat
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
        Me.tcReportFormat = New System.Windows.Forms.TabControl()
        Me.tpFilternParams = New System.Windows.Forms.TabPage()
        Me.tcFilternParameters = New System.Windows.Forms.TabControl()
        Me.tpFilter = New System.Windows.Forms.TabPage()
        Me.tcFilter = New System.Windows.Forms.TabControl()
        Me.tpInvoiceNo = New System.Windows.Forms.TabPage()
        Me.tbInvoiceNoValue = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbDoesNotEndWith = New System.Windows.Forms.RadioButton()
        Me.rbEndsWith = New System.Windows.Forms.RadioButton()
        Me.rbDoestNotBeginWith = New System.Windows.Forms.RadioButton()
        Me.rbBeginsWith = New System.Windows.Forms.RadioButton()
        Me.rbDoestNotContain = New System.Windows.Forms.RadioButton()
        Me.rbContains = New System.Windows.Forms.RadioButton()
        Me.rbDoesNotEqual = New System.Windows.Forms.RadioButton()
        Me.rbEquals = New System.Windows.Forms.RadioButton()
        Me.rbAll = New System.Windows.Forms.RadioButton()
        Me.tpStatus = New System.Windows.Forms.TabPage()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.tpParameter = New System.Windows.Forms.TabPage()
        Me.lblFromDate = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblToDate = New System.Windows.Forms.Label()
        Me.tpCustomize = New System.Windows.Forms.TabPage()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnDefault = New System.Windows.Forms.Button()
        Me.tcReportFormat.SuspendLayout()
        Me.tpFilternParams.SuspendLayout()
        Me.tcFilternParameters.SuspendLayout()
        Me.tpFilter.SuspendLayout()
        Me.tcFilter.SuspendLayout()
        Me.tpInvoiceNo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tpParameter.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcReportFormat
        '
        Me.tcReportFormat.Controls.Add(Me.tpFilternParams)
        Me.tcReportFormat.Controls.Add(Me.tpCustomize)
        Me.tcReportFormat.Location = New System.Drawing.Point(3, 2)
        Me.tcReportFormat.Name = "tcReportFormat"
        Me.tcReportFormat.SelectedIndex = 0
        Me.tcReportFormat.Size = New System.Drawing.Size(485, 372)
        Me.tcReportFormat.TabIndex = 0
        '
        'tpFilternParams
        '
        Me.tpFilternParams.BackColor = System.Drawing.Color.LightBlue
        Me.tpFilternParams.Controls.Add(Me.tcFilternParameters)
        Me.tpFilternParams.ForeColor = System.Drawing.Color.LightBlue
        Me.tpFilternParams.Location = New System.Drawing.Point(4, 22)
        Me.tpFilternParams.Name = "tpFilternParams"
        Me.tpFilternParams.Padding = New System.Windows.Forms.Padding(3)
        Me.tpFilternParams.Size = New System.Drawing.Size(477, 346)
        Me.tpFilternParams.TabIndex = 0
        Me.tpFilternParams.Text = "Filter & Parameters"
        '
        'tcFilternParameters
        '
        Me.tcFilternParameters.Controls.Add(Me.tpFilter)
        Me.tcFilternParameters.Controls.Add(Me.tpParameter)
        Me.tcFilternParameters.Location = New System.Drawing.Point(0, 0)
        Me.tcFilternParameters.Name = "tcFilternParameters"
        Me.tcFilternParameters.SelectedIndex = 0
        Me.tcFilternParameters.Size = New System.Drawing.Size(606, 348)
        Me.tcFilternParameters.TabIndex = 0
        Me.tcFilternParameters.TabStop = False
        '
        'tpFilter
        '
        Me.tpFilter.BackColor = System.Drawing.Color.LightBlue
        Me.tpFilter.Controls.Add(Me.tcFilter)
        Me.tpFilter.Controls.Add(Me.ListBox1)
        Me.tpFilter.Location = New System.Drawing.Point(4, 22)
        Me.tpFilter.Name = "tpFilter"
        Me.tpFilter.Padding = New System.Windows.Forms.Padding(3)
        Me.tpFilter.Size = New System.Drawing.Size(598, 322)
        Me.tpFilter.TabIndex = 0
        Me.tpFilter.Text = "Filter"
        '
        'tcFilter
        '
        Me.tcFilter.Controls.Add(Me.tpInvoiceNo)
        Me.tcFilter.Controls.Add(Me.tpStatus)
        Me.tcFilter.Location = New System.Drawing.Point(163, 6)
        Me.tcFilter.Name = "tcFilter"
        Me.tcFilter.SelectedIndex = 0
        Me.tcFilter.Size = New System.Drawing.Size(310, 303)
        Me.tcFilter.TabIndex = 1
        '
        'tpInvoiceNo
        '
        Me.tpInvoiceNo.Controls.Add(Me.tbInvoiceNoValue)
        Me.tpInvoiceNo.Controls.Add(Me.GroupBox1)
        Me.tpInvoiceNo.Location = New System.Drawing.Point(4, 22)
        Me.tpInvoiceNo.Name = "tpInvoiceNo"
        Me.tpInvoiceNo.Padding = New System.Windows.Forms.Padding(3)
        Me.tpInvoiceNo.Size = New System.Drawing.Size(302, 277)
        Me.tpInvoiceNo.TabIndex = 0
        Me.tpInvoiceNo.Text = "TabPage1"
        Me.tpInvoiceNo.UseVisualStyleBackColor = True
        '
        'tbInvoiceNoValue
        '
        Me.tbInvoiceNoValue.Location = New System.Drawing.Point(7, 215)
        Me.tbInvoiceNoValue.Name = "tbInvoiceNoValue"
        Me.tbInvoiceNoValue.Size = New System.Drawing.Size(293, 20)
        Me.tbInvoiceNoValue.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbDoesNotEndWith)
        Me.GroupBox1.Controls.Add(Me.rbEndsWith)
        Me.GroupBox1.Controls.Add(Me.rbDoestNotBeginWith)
        Me.GroupBox1.Controls.Add(Me.rbBeginsWith)
        Me.GroupBox1.Controls.Add(Me.rbDoestNotContain)
        Me.GroupBox1.Controls.Add(Me.rbContains)
        Me.GroupBox1.Controls.Add(Me.rbDoesNotEqual)
        Me.GroupBox1.Controls.Add(Me.rbEquals)
        Me.GroupBox1.Controls.Add(Me.rbAll)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(9, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(290, 193)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'rbDoesNotEndWith
        '
        Me.rbDoesNotEndWith.AutoSize = True
        Me.rbDoesNotEndWith.Location = New System.Drawing.Point(153, 128)
        Me.rbDoesNotEndWith.Name = "rbDoesNotEndWith"
        Me.rbDoesNotEndWith.Size = New System.Drawing.Size(109, 17)
        Me.rbDoesNotEndWith.TabIndex = 8
        Me.rbDoesNotEndWith.TabStop = True
        Me.rbDoesNotEndWith.Text = "does not end with"
        Me.rbDoesNotEndWith.UseVisualStyleBackColor = True
        '
        'rbEndsWith
        '
        Me.rbEndsWith.AutoSize = True
        Me.rbEndsWith.Location = New System.Drawing.Point(153, 94)
        Me.rbEndsWith.Name = "rbEndsWith"
        Me.rbEndsWith.Size = New System.Drawing.Size(70, 17)
        Me.rbEndsWith.TabIndex = 7
        Me.rbEndsWith.TabStop = True
        Me.rbEndsWith.Text = "ends with"
        Me.rbEndsWith.UseVisualStyleBackColor = True
        '
        'rbDoestNotBeginWith
        '
        Me.rbDoestNotBeginWith.AutoSize = True
        Me.rbDoestNotBeginWith.Location = New System.Drawing.Point(153, 60)
        Me.rbDoestNotBeginWith.Name = "rbDoestNotBeginWith"
        Me.rbDoestNotBeginWith.Size = New System.Drawing.Size(117, 17)
        Me.rbDoestNotBeginWith.TabIndex = 6
        Me.rbDoestNotBeginWith.TabStop = True
        Me.rbDoestNotBeginWith.Text = "does not begin with"
        Me.rbDoestNotBeginWith.UseVisualStyleBackColor = True
        '
        'rbBeginsWith
        '
        Me.rbBeginsWith.AutoSize = True
        Me.rbBeginsWith.Location = New System.Drawing.Point(153, 28)
        Me.rbBeginsWith.Name = "rbBeginsWith"
        Me.rbBeginsWith.Size = New System.Drawing.Size(78, 17)
        Me.rbBeginsWith.TabIndex = 5
        Me.rbBeginsWith.TabStop = True
        Me.rbBeginsWith.Text = "begins with"
        Me.rbBeginsWith.UseVisualStyleBackColor = True
        '
        'rbDoestNotContain
        '
        Me.rbDoestNotContain.AutoSize = True
        Me.rbDoestNotContain.Location = New System.Drawing.Point(6, 164)
        Me.rbDoestNotContain.Name = "rbDoestNotContain"
        Me.rbDoestNotContain.Size = New System.Drawing.Size(104, 17)
        Me.rbDoestNotContain.TabIndex = 4
        Me.rbDoestNotContain.TabStop = True
        Me.rbDoestNotContain.Text = "does not contain"
        Me.rbDoestNotContain.UseVisualStyleBackColor = True
        '
        'rbContains
        '
        Me.rbContains.AutoSize = True
        Me.rbContains.Location = New System.Drawing.Point(6, 128)
        Me.rbContains.Name = "rbContains"
        Me.rbContains.Size = New System.Drawing.Size(65, 17)
        Me.rbContains.TabIndex = 3
        Me.rbContains.TabStop = True
        Me.rbContains.Text = "contains"
        Me.rbContains.UseVisualStyleBackColor = True
        '
        'rbDoesNotEqual
        '
        Me.rbDoesNotEqual.AutoSize = True
        Me.rbDoesNotEqual.Location = New System.Drawing.Point(6, 94)
        Me.rbDoesNotEqual.Name = "rbDoesNotEqual"
        Me.rbDoesNotEqual.Size = New System.Drawing.Size(95, 17)
        Me.rbDoesNotEqual.TabIndex = 2
        Me.rbDoesNotEqual.TabStop = True
        Me.rbDoesNotEqual.Text = "does not equal"
        Me.rbDoesNotEqual.UseVisualStyleBackColor = True
        '
        'rbEquals
        '
        Me.rbEquals.AutoSize = True
        Me.rbEquals.Location = New System.Drawing.Point(6, 60)
        Me.rbEquals.Name = "rbEquals"
        Me.rbEquals.Size = New System.Drawing.Size(56, 17)
        Me.rbEquals.TabIndex = 1
        Me.rbEquals.Text = "equals"
        Me.rbEquals.UseVisualStyleBackColor = True
        '
        'rbAll
        '
        Me.rbAll.AutoSize = True
        Me.rbAll.Checked = True
        Me.rbAll.Location = New System.Drawing.Point(6, 28)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(36, 17)
        Me.rbAll.TabIndex = 0
        Me.rbAll.TabStop = True
        Me.rbAll.Text = "All"
        Me.rbAll.UseVisualStyleBackColor = True
        '
        'tpStatus
        '
        Me.tpStatus.Location = New System.Drawing.Point(4, 22)
        Me.tpStatus.Name = "tpStatus"
        Me.tpStatus.Padding = New System.Windows.Forms.Padding(3)
        Me.tpStatus.Size = New System.Drawing.Size(302, 277)
        Me.tpStatus.TabIndex = 1
        Me.tpStatus.Text = "TabPage2"
        Me.tpStatus.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Items.AddRange(New Object() {"Invoice No", "Status"})
        Me.ListBox1.Location = New System.Drawing.Point(6, 6)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(151, 303)
        Me.ListBox1.TabIndex = 0
        '
        'tpParameter
        '
        Me.tpParameter.BackColor = System.Drawing.Color.LightBlue
        Me.tpParameter.Controls.Add(Me.lblFromDate)
        Me.tpParameter.Controls.Add(Me.dtpEndDate)
        Me.tpParameter.Controls.Add(Me.dtpStartDate)
        Me.tpParameter.Controls.Add(Me.lblToDate)
        Me.tpParameter.Location = New System.Drawing.Point(4, 22)
        Me.tpParameter.Name = "tpParameter"
        Me.tpParameter.Padding = New System.Windows.Forms.Padding(3)
        Me.tpParameter.Size = New System.Drawing.Size(598, 322)
        Me.tpParameter.TabIndex = 1
        Me.tpParameter.Text = "Parameter"
        '
        'lblFromDate
        '
        Me.lblFromDate.AutoSize = True
        Me.lblFromDate.BackColor = System.Drawing.Color.Transparent
        Me.lblFromDate.ForeColor = System.Drawing.Color.Black
        Me.lblFromDate.Location = New System.Drawing.Point(6, 53)
        Me.lblFromDate.Name = "lblFromDate"
        Me.lblFromDate.Size = New System.Drawing.Size(65, 13)
        Me.lblFromDate.TabIndex = 0
        Me.lblFromDate.Text = "From Date : "
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(91, 80)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpEndDate.TabIndex = 3
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(91, 53)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpStartDate.TabIndex = 2
        '
        'lblToDate
        '
        Me.lblToDate.AutoSize = True
        Me.lblToDate.BackColor = System.Drawing.Color.Transparent
        Me.lblToDate.ForeColor = System.Drawing.Color.Black
        Me.lblToDate.Location = New System.Drawing.Point(10, 80)
        Me.lblToDate.Name = "lblToDate"
        Me.lblToDate.Size = New System.Drawing.Size(55, 13)
        Me.lblToDate.TabIndex = 1
        Me.lblToDate.Text = "To Date : "
        '
        'tpCustomize
        '
        Me.tpCustomize.BackColor = System.Drawing.Color.LightBlue
        Me.tpCustomize.Location = New System.Drawing.Point(4, 22)
        Me.tpCustomize.Name = "tpCustomize"
        Me.tpCustomize.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCustomize.Size = New System.Drawing.Size(477, 346)
        Me.tpCustomize.TabIndex = 1
        Me.tpCustomize.Text = "Customize"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(495, 68)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(114, 28)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(495, 102)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(114, 28)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnDefault
        '
        Me.btnDefault.Location = New System.Drawing.Point(495, 190)
        Me.btnDefault.Name = "btnDefault"
        Me.btnDefault.Size = New System.Drawing.Size(114, 28)
        Me.btnDefault.TabIndex = 3
        Me.btnDefault.Text = "DEFAULT"
        Me.btnDefault.UseVisualStyleBackColor = True
        '
        'frmReportFormat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.ClientSize = New System.Drawing.Size(616, 375)
        Me.Controls.Add(Me.btnDefault)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.tcReportFormat)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReportFormat"
        Me.Text = "Report Format"
        Me.tcReportFormat.ResumeLayout(False)
        Me.tpFilternParams.ResumeLayout(False)
        Me.tcFilternParameters.ResumeLayout(False)
        Me.tpFilter.ResumeLayout(False)
        Me.tcFilter.ResumeLayout(False)
        Me.tpInvoiceNo.ResumeLayout(False)
        Me.tpInvoiceNo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tpParameter.ResumeLayout(False)
        Me.tpParameter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcReportFormat As System.Windows.Forms.TabControl
    Friend WithEvents tpFilternParams As System.Windows.Forms.TabPage
    Friend WithEvents tpCustomize As System.Windows.Forms.TabPage
    Friend WithEvents tcFilternParameters As System.Windows.Forms.TabControl
    Friend WithEvents tpFilter As System.Windows.Forms.TabPage
    Friend WithEvents tpParameter As System.Windows.Forms.TabPage
    Friend WithEvents lblToDate As System.Windows.Forms.Label
    Friend WithEvents lblFromDate As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnDefault As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents tcFilter As System.Windows.Forms.TabControl
    Friend WithEvents tpInvoiceNo As System.Windows.Forms.TabPage
    Friend WithEvents tpStatus As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbEquals As System.Windows.Forms.RadioButton
    Friend WithEvents rbAll As System.Windows.Forms.RadioButton
    Friend WithEvents rbDoesNotEndWith As System.Windows.Forms.RadioButton
    Friend WithEvents rbEndsWith As System.Windows.Forms.RadioButton
    Friend WithEvents rbDoestNotBeginWith As System.Windows.Forms.RadioButton
    Friend WithEvents rbBeginsWith As System.Windows.Forms.RadioButton
    Friend WithEvents rbDoestNotContain As System.Windows.Forms.RadioButton
    Friend WithEvents rbContains As System.Windows.Forms.RadioButton
    Friend WithEvents rbDoesNotEqual As System.Windows.Forms.RadioButton
    Friend WithEvents tbInvoiceNoValue As System.Windows.Forms.TextBox
End Class
