<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCRSalesInvoicesListSummary
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
        Me.crvSalesInvoiceViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crvSalesInvoiceViewer
        '
        Me.crvSalesInvoiceViewer.ActiveViewIndex = -1
        Me.crvSalesInvoiceViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvSalesInvoiceViewer.AutoScroll = True
        Me.crvSalesInvoiceViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvSalesInvoiceViewer.CausesValidation = False
        Me.crvSalesInvoiceViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvSalesInvoiceViewer.Location = New System.Drawing.Point(0, 0)
        Me.crvSalesInvoiceViewer.Name = "crvSalesInvoiceViewer"
        Me.crvSalesInvoiceViewer.Size = New System.Drawing.Size(816, 399)
        Me.crvSalesInvoiceViewer.TabIndex = 0
        '
        'frmCRSalesInvoicesListSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(816, 399)
        Me.Controls.Add(Me.crvSalesInvoiceViewer)
        Me.Name = "frmCRSalesInvoicesListSummary"
        Me.Text = "frmCRSalesInvoicesListSummary"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crvSalesInvoiceViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
