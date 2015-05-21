<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCRPurchaseInvoicesListSummary
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
        Me.crvPurchaseInvoiceViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crvPurchaseInvoiceViewer
        '
        Me.crvPurchaseInvoiceViewer.ActiveViewIndex = -1
        Me.crvPurchaseInvoiceViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvPurchaseInvoiceViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvPurchaseInvoiceViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvPurchaseInvoiceViewer.Location = New System.Drawing.Point(0, 0)
        Me.crvPurchaseInvoiceViewer.Name = "crvPurchaseInvoiceViewer"
        Me.crvPurchaseInvoiceViewer.Size = New System.Drawing.Size(816, 399)
        Me.crvPurchaseInvoiceViewer.TabIndex = 0
        '
        'frmCRPurchaseInvoicesListSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(816, 399)
        Me.Controls.Add(Me.crvPurchaseInvoiceViewer)
        Me.Name = "frmCRPurchaseInvoicesListSummary"
        Me.Text = "frmCRPurchaseInvoicesListSummary"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crvPurchaseInvoiceViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
