<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPurchaseInvoice
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
        Me.components = New System.ComponentModel.Container()
        Me.msPurchaseInvoice = New System.Windows.Forms.MenuStrip()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dtpSITo = New System.Windows.Forms.DateTimePicker()
        Me.dtpSIFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbFilterByDate = New System.Windows.Forms.CheckBox()
        Me.cbOutStandingOnly = New System.Windows.Forms.CheckBox()
        Me.cbbxAirlines = New System.Windows.Forms.ComboBox()
        Me.lblCurrency = New System.Windows.Forms.Label()
        Me.cbbxCurrPurc = New System.Windows.Forms.ComboBox()
        Me.lblVendor = New System.Windows.Forms.Label()
        Me.lblFilter = New System.Windows.Forms.Label()
        Me.splPurchaseInvoices = New System.Windows.Forms.Splitter()
        Me.dgvPurchaseInvoice = New System.Windows.Forms.DataGridView()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.msPurchaseInvoice.SuspendLayout()
        CType(Me.dgvPurchaseInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'msPurchaseInvoice
        '
        Me.msPurchaseInvoice.AllowMerge = False
        Me.msPurchaseInvoice.AutoSize = False
        Me.msPurchaseInvoice.BackColor = System.Drawing.SystemColors.Control
        Me.msPurchaseInvoice.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.RefreshToolStripMenuItem})
        Me.msPurchaseInvoice.Location = New System.Drawing.Point(0, 0)
        Me.msPurchaseInvoice.Name = "msPurchaseInvoice"
        Me.msPurchaseInvoice.Size = New System.Drawing.Size(774, 27)
        Me.msPurchaseInvoice.Stretch = False
        Me.msPurchaseInvoice.TabIndex = 3
        Me.msPurchaseInvoice.Text = "MenuStrip1"
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
        'dtpSITo
        '
        Me.dtpSITo.CustomFormat = "dd/MM/yyyy"
        Me.dtpSITo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSITo.Location = New System.Drawing.Point(80, 222)
        Me.dtpSITo.Name = "dtpSITo"
        Me.dtpSITo.Size = New System.Drawing.Size(116, 20)
        Me.dtpSITo.TabIndex = 35
        '
        'dtpSIFrom
        '
        Me.dtpSIFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtpSIFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSIFrom.Location = New System.Drawing.Point(80, 198)
        Me.dtpSIFrom.Name = "dtpSIFrom"
        Me.dtpSIFrom.Size = New System.Drawing.Size(116, 20)
        Me.dtpSIFrom.TabIndex = 34
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 222)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "To :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 202)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "From :"
        '
        'cbFilterByDate
        '
        Me.cbFilterByDate.AutoSize = True
        Me.cbFilterByDate.Location = New System.Drawing.Point(6, 173)
        Me.cbFilterByDate.Name = "cbFilterByDate"
        Me.cbFilterByDate.Size = New System.Drawing.Size(88, 17)
        Me.cbFilterByDate.TabIndex = 31
        Me.cbFilterByDate.Text = "Filter by Date"
        Me.cbFilterByDate.UseVisualStyleBackColor = True
        '
        'cbOutStandingOnly
        '
        Me.cbOutStandingOnly.AutoSize = True
        Me.cbOutStandingOnly.Location = New System.Drawing.Point(6, 149)
        Me.cbOutStandingOnly.Name = "cbOutStandingOnly"
        Me.cbOutStandingOnly.Size = New System.Drawing.Size(109, 17)
        Me.cbOutStandingOnly.TabIndex = 30
        Me.cbOutStandingOnly.Text = "OutStanding Only"
        Me.cbOutStandingOnly.UseVisualStyleBackColor = True
        '
        'cbbxAirlines
        '
        Me.cbbxAirlines.FormattingEnabled = True
        Me.cbbxAirlines.Location = New System.Drawing.Point(3, 75)
        Me.cbbxAirlines.Name = "cbbxAirlines"
        Me.cbbxAirlines.Size = New System.Drawing.Size(193, 21)
        Me.cbbxAirlines.TabIndex = 25
        Me.cbbxAirlines.Tag = ""
        '
        'lblCurrency
        '
        Me.lblCurrency.Location = New System.Drawing.Point(2, 100)
        Me.lblCurrency.Name = "lblCurrency"
        Me.lblCurrency.Size = New System.Drawing.Size(196, 18)
        Me.lblCurrency.TabIndex = 29
        Me.lblCurrency.Text = "Currency"
        '
        'cbbxCurrPurc
        '
        Me.cbbxCurrPurc.DisplayMember = "aa"
        Me.cbbxCurrPurc.FormattingEnabled = True
        Me.cbbxCurrPurc.Items.AddRange(New Object() {"<All>", "IDR", "USD"})
        Me.cbbxCurrPurc.Location = New System.Drawing.Point(3, 121)
        Me.cbbxCurrPurc.Name = "cbbxCurrPurc"
        Me.cbbxCurrPurc.Size = New System.Drawing.Size(193, 21)
        Me.cbbxCurrPurc.TabIndex = 26
        '
        'lblVendor
        '
        Me.lblVendor.BackColor = System.Drawing.Color.Transparent
        Me.lblVendor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendor.Location = New System.Drawing.Point(2, 54)
        Me.lblVendor.Name = "lblVendor"
        Me.lblVendor.Size = New System.Drawing.Size(196, 18)
        Me.lblVendor.TabIndex = 28
        Me.lblVendor.Text = "Vendor :"
        '
        'lblFilter
        '
        Me.lblFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilter.Location = New System.Drawing.Point(2, 30)
        Me.lblFilter.Name = "lblFilter"
        Me.lblFilter.Size = New System.Drawing.Size(196, 18)
        Me.lblFilter.TabIndex = 27
        Me.lblFilter.Text = "Filters"
        Me.lblFilter.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'splPurchaseInvoices
        '
        Me.splPurchaseInvoices.BackColor = System.Drawing.Color.PowderBlue
        Me.splPurchaseInvoices.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.splPurchaseInvoices.Location = New System.Drawing.Point(0, 27)
        Me.splPurchaseInvoices.Name = "splPurchaseInvoices"
        Me.splPurchaseInvoices.Size = New System.Drawing.Size(200, 337)
        Me.splPurchaseInvoices.TabIndex = 36
        Me.splPurchaseInvoices.TabStop = False
        '
        'dgvPurchaseInvoice
        '
        Me.dgvPurchaseInvoice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvPurchaseInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPurchaseInvoice.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvPurchaseInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPurchaseInvoice.Location = New System.Drawing.Point(206, 27)
        Me.dgvPurchaseInvoice.MultiSelect = False
        Me.dgvPurchaseInvoice.Name = "dgvPurchaseInvoice"
        Me.dgvPurchaseInvoice.ReadOnly = True
        Me.dgvPurchaseInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPurchaseInvoice.Size = New System.Drawing.Size(1000, 324)
        Me.dgvPurchaseInvoice.TabIndex = 37
        '
        'frmPurchaseInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 364)
        Me.Controls.Add(Me.dgvPurchaseInvoice)
        Me.Controls.Add(Me.dtpSITo)
        Me.Controls.Add(Me.dtpSIFrom)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbFilterByDate)
        Me.Controls.Add(Me.cbOutStandingOnly)
        Me.Controls.Add(Me.cbbxAirlines)
        Me.Controls.Add(Me.lblCurrency)
        Me.Controls.Add(Me.cbbxCurrPurc)
        Me.Controls.Add(Me.lblVendor)
        Me.Controls.Add(Me.lblFilter)
        Me.Controls.Add(Me.splPurchaseInvoices)
        Me.Controls.Add(Me.msPurchaseInvoice)
        Me.Name = "frmPurchaseInvoice"
        Me.Text = "PurchaseInvoice"
        Me.msPurchaseInvoice.ResumeLayout(False)
        Me.msPurchaseInvoice.PerformLayout()
        CType(Me.dgvPurchaseInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents msPurchaseInvoice As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtpSITo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpSIFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbFilterByDate As System.Windows.Forms.CheckBox
    Friend WithEvents cbOutStandingOnly As System.Windows.Forms.CheckBox
    Friend WithEvents cbbxAirlines As System.Windows.Forms.ComboBox
    Friend WithEvents lblCurrency As System.Windows.Forms.Label
    Friend WithEvents cbbxCurrPurc As System.Windows.Forms.ComboBox
    Friend WithEvents lblVendor As System.Windows.Forms.Label
    Friend WithEvents lblFilter As System.Windows.Forms.Label
    Friend WithEvents splPurchaseInvoices As System.Windows.Forms.Splitter
    Friend WithEvents dgvPurchaseInvoice As System.Windows.Forms.DataGridView
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
