<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalesInvoices
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
        Me.msSalesInvoice = New System.Windows.Forms.MenuStrip()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.splSalesInvoices = New System.Windows.Forms.Splitter()
        Me.lblFilter = New System.Windows.Forms.Label()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.cbbxCurrency = New System.Windows.Forms.ComboBox()
        Me.lblCurrency = New System.Windows.Forms.Label()
        Me.cbbxCustomer = New System.Windows.Forms.ComboBox()
        Me.cbOutStandingOnly = New System.Windows.Forms.CheckBox()
        Me.cbFilterByDate = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpSIFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpSITo = New System.Windows.Forms.DateTimePicker()
        Me.dgvSalesInvoice = New System.Windows.Forms.DataGridView()
        Me.msSalesInvoice.SuspendLayout()
        CType(Me.dgvSalesInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'msSalesInvoice
        '
        Me.msSalesInvoice.AllowMerge = False
        Me.msSalesInvoice.AutoSize = False
        Me.msSalesInvoice.BackColor = System.Drawing.SystemColors.Control
        Me.msSalesInvoice.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.RefreshToolStripMenuItem})
        Me.msSalesInvoice.Location = New System.Drawing.Point(0, 0)
        Me.msSalesInvoice.Name = "msSalesInvoice"
        Me.msSalesInvoice.Size = New System.Drawing.Size(866, 27)
        Me.msSalesInvoice.Stretch = False
        Me.msSalesInvoice.TabIndex = 1
        Me.msSalesInvoice.Text = "MenuStrip1"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(40, 23)
        Me.NewToolStripMenuItem.Text = "&New"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 23)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(50, 23)
        Me.DeleteToolStripMenuItem.Text = "&Delete"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(57, 23)
        Me.RefreshToolStripMenuItem.Text = "&Refresh"
        '
        'splSalesInvoices
        '
        Me.splSalesInvoices.BackColor = System.Drawing.Color.PowderBlue
        Me.splSalesInvoices.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.splSalesInvoices.Location = New System.Drawing.Point(0, 27)
        Me.splSalesInvoices.Name = "splSalesInvoices"
        Me.splSalesInvoices.Size = New System.Drawing.Size(200, 345)
        Me.splSalesInvoices.TabIndex = 0
        Me.splSalesInvoices.TabStop = False
        '
        'lblFilter
        '
        Me.lblFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilter.Location = New System.Drawing.Point(3, 28)
        Me.lblFilter.Name = "lblFilter"
        Me.lblFilter.Size = New System.Drawing.Size(196, 18)
        Me.lblFilter.TabIndex = 3
        Me.lblFilter.Text = "Filters"
        Me.lblFilter.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCustomer
        '
        Me.lblCustomer.BackColor = System.Drawing.Color.Transparent
        Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomer.Location = New System.Drawing.Point(3, 52)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(196, 18)
        Me.lblCustomer.TabIndex = 4
        Me.lblCustomer.Text = "Customer :"
        '
        'cbbxCurrency
        '
        Me.cbbxCurrency.DisplayMember = "aa"
        Me.cbbxCurrency.FormattingEnabled = True
        Me.cbbxCurrency.Items.AddRange(New Object() {"<All>", "IDR", "USD"})
        Me.cbbxCurrency.Location = New System.Drawing.Point(3, 119)
        Me.cbbxCurrency.Name = "cbbxCurrency"
        Me.cbbxCurrency.Size = New System.Drawing.Size(193, 21)
        Me.cbbxCurrency.TabIndex = 0
        '
        'lblCurrency
        '
        Me.lblCurrency.Location = New System.Drawing.Point(3, 98)
        Me.lblCurrency.Name = "lblCurrency"
        Me.lblCurrency.Size = New System.Drawing.Size(196, 18)
        Me.lblCurrency.TabIndex = 6
        Me.lblCurrency.Text = "Currency"
        '
        'cbbxCustomer
        '
        Me.cbbxCustomer.FormattingEnabled = True
        Me.cbbxCustomer.Location = New System.Drawing.Point(3, 73)
        Me.cbbxCustomer.Name = "cbbxCustomer"
        Me.cbbxCustomer.Size = New System.Drawing.Size(193, 21)
        Me.cbbxCustomer.TabIndex = 0
        Me.cbbxCustomer.Tag = ""
        '
        'cbOutStandingOnly
        '
        Me.cbOutStandingOnly.AutoSize = True
        Me.cbOutStandingOnly.Location = New System.Drawing.Point(6, 147)
        Me.cbOutStandingOnly.Name = "cbOutStandingOnly"
        Me.cbOutStandingOnly.Size = New System.Drawing.Size(109, 17)
        Me.cbOutStandingOnly.TabIndex = 8
        Me.cbOutStandingOnly.Text = "OutStanding Only"
        Me.cbOutStandingOnly.UseVisualStyleBackColor = True
        '
        'cbFilterByDate
        '
        Me.cbFilterByDate.AutoSize = True
        Me.cbFilterByDate.Location = New System.Drawing.Point(6, 171)
        Me.cbFilterByDate.Name = "cbFilterByDate"
        Me.cbFilterByDate.Size = New System.Drawing.Size(88, 17)
        Me.cbFilterByDate.TabIndex = 9
        Me.cbFilterByDate.Text = "Filter by Date"
        Me.cbFilterByDate.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 200)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "From :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 220)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "To :"
        '
        'dtpSIFrom
        '
        Me.dtpSIFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtpSIFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSIFrom.Location = New System.Drawing.Point(80, 196)
        Me.dtpSIFrom.Name = "dtpSIFrom"
        Me.dtpSIFrom.Size = New System.Drawing.Size(116, 20)
        Me.dtpSIFrom.TabIndex = 12
        '
        'dtpSITo
        '
        Me.dtpSITo.CustomFormat = "dd/MM/yyyy"
        Me.dtpSITo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSITo.Location = New System.Drawing.Point(80, 220)
        Me.dtpSITo.Name = "dtpSITo"
        Me.dtpSITo.Size = New System.Drawing.Size(116, 20)
        Me.dtpSITo.TabIndex = 13
        '
        'dgvSalesInvoice
        '
        Me.dgvSalesInvoice.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSalesInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSalesInvoice.Location = New System.Drawing.Point(206, 27)
        Me.dgvSalesInvoice.MultiSelect = False
        Me.dgvSalesInvoice.Name = "dgvSalesInvoice"
        Me.dgvSalesInvoice.ReadOnly = True
        Me.dgvSalesInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSalesInvoice.Size = New System.Drawing.Size(660, 324)
        Me.dgvSalesInvoice.TabIndex = 14
        '
        'frmSalesInvoices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(866, 372)
        Me.Controls.Add(Me.dgvSalesInvoice)
        Me.Controls.Add(Me.dtpSITo)
        Me.Controls.Add(Me.dtpSIFrom)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbFilterByDate)
        Me.Controls.Add(Me.cbOutStandingOnly)
        Me.Controls.Add(Me.cbbxCustomer)
        Me.Controls.Add(Me.lblCurrency)
        Me.Controls.Add(Me.cbbxCurrency)
        Me.Controls.Add(Me.lblCustomer)
        Me.Controls.Add(Me.lblFilter)
        Me.Controls.Add(Me.splSalesInvoices)
        Me.Controls.Add(Me.msSalesInvoice)
        Me.MainMenuStrip = Me.msSalesInvoice
        Me.Name = "frmSalesInvoices"
        Me.Text = "SalesInvoices"
        Me.msSalesInvoice.ResumeLayout(False)
        Me.msSalesInvoice.PerformLayout()
        CType(Me.dgvSalesInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents msSalesInvoice As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents splSalesInvoices As System.Windows.Forms.Splitter
    Friend WithEvents lblFilter As System.Windows.Forms.Label
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents cbbxCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents lblCurrency As System.Windows.Forms.Label
    Friend WithEvents cbbxCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents cbOutStandingOnly As System.Windows.Forms.CheckBox
    Friend WithEvents cbFilterByDate As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpSIFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpSITo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvSalesInvoice As System.Windows.Forms.DataGridView
End Class
