<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReport
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
        Me.pnlHeaderReports = New System.Windows.Forms.Panel()
        Me.scReports = New System.Windows.Forms.SplitContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbRptCategory = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbRptDetails = New System.Windows.Forms.ListBox()
        CType(Me.scReports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scReports.Panel1.SuspendLayout()
        Me.scReports.Panel2.SuspendLayout()
        Me.scReports.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeaderReports
        '
        Me.pnlHeaderReports.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlHeaderReports.BackColor = System.Drawing.Color.LightBlue
        Me.pnlHeaderReports.Location = New System.Drawing.Point(2, 3)
        Me.pnlHeaderReports.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.pnlHeaderReports.Name = "pnlHeaderReports"
        Me.pnlHeaderReports.Size = New System.Drawing.Size(636, 49)
        Me.pnlHeaderReports.TabIndex = 2
        '
        'scReports
        '
        Me.scReports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.scReports.BackColor = System.Drawing.Color.LightBlue
        Me.scReports.Location = New System.Drawing.Point(0, 53)
        Me.scReports.Name = "scReports"
        '
        'scReports.Panel1
        '
        Me.scReports.Panel1.Controls.Add(Me.Label1)
        Me.scReports.Panel1.Controls.Add(Me.lbRptCategory)
        '
        'scReports.Panel2
        '
        Me.scReports.Panel2.BackColor = System.Drawing.Color.LightBlue
        Me.scReports.Panel2.Controls.Add(Me.Label2)
        Me.scReports.Panel2.Controls.Add(Me.lbRptDetails)
        Me.scReports.Size = New System.Drawing.Size(642, 300)
        Me.scReports.SplitterDistance = 185
        Me.scReports.SplitterWidth = 5
        Me.scReports.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(185, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Report Category :"
        '
        'lbRptCategory
        '
        Me.lbRptCategory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbRptCategory.BackColor = System.Drawing.Color.LightBlue
        Me.lbRptCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbRptCategory.FormattingEnabled = True
        Me.lbRptCategory.Items.AddRange(New Object() {"Purchase Reports", "Sales Reports"})
        Me.lbRptCategory.Location = New System.Drawing.Point(3, 25)
        Me.lbRptCategory.Margin = New System.Windows.Forms.Padding(3, 3, 0, 0)
        Me.lbRptCategory.Name = "lbRptCategory"
        Me.lbRptCategory.Size = New System.Drawing.Size(182, 366)
        Me.lbRptCategory.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(452, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Report Detail :"
        '
        'lbRptDetails
        '
        Me.lbRptDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbRptDetails.BackColor = System.Drawing.Color.LightBlue
        Me.lbRptDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbRptDetails.FormattingEnabled = True
        Me.lbRptDetails.Location = New System.Drawing.Point(0, 26)
        Me.lbRptDetails.Margin = New System.Windows.Forms.Padding(3, 3, 0, 0)
        Me.lbRptDetails.Name = "lbRptDetails"
        Me.lbRptDetails.Size = New System.Drawing.Size(618, 366)
        Me.lbRptDetails.TabIndex = 1
        '
        'frmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(642, 385)
        Me.Controls.Add(Me.scReports)
        Me.Controls.Add(Me.pnlHeaderReports)
        Me.Name = "frmReport"
        Me.Text = "Index To Reports"
        Me.scReports.Panel1.ResumeLayout(False)
        Me.scReports.Panel2.ResumeLayout(False)
        CType(Me.scReports, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scReports.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeaderReports As System.Windows.Forms.Panel
    Friend WithEvents scReports As System.Windows.Forms.SplitContainer
    Friend WithEvents lbRptCategory As System.Windows.Forms.ListBox
    Friend WithEvents lbRptDetails As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
