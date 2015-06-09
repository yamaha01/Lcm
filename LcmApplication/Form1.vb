Public Class frmMainLcm
    Dim IsAlreadyResized As Boolean

    Private Sub frmMainLcm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'If Not IsAlreadyResized Then
        '    Me.WindowState = FormWindowState.Maximized
        '    IsAlreadyResized = True
        'End If
        Me.WindowState = FormWindowState.Maximized

        'frmReminders.MdiParent = Me
        'frmReminders.Show()
        'frmReminders.Location = New Point(0, 0)
        'openForm(frmSalesInvoices)
        'openForm(frmReport)
        'openForm(frmPurchaseInvoice)
    End Sub
    

    Private Sub btnGeneralLedger_Click(sender As Object, e As EventArgs) Handles btnGeneralLedger.Click
        openForm(frmReminders)
    End Sub

    Private Sub SalesInvoicesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesInvoicesToolStripMenuItem.Click
        openForm(frmSalesInvoices)
    End Sub

    Public Sub openForm(frmOpen As Form)
        frmOpen.MdiParent = Me
        frmOpen.Dock = DockStyle.Fill
        frmOpen.Show()
        frmOpen.Location = New Point(0, 0)
    End Sub

    Private Sub SalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesToolStripMenuItem.Click
        openForm(frmReport)
    End Sub

    Private Sub PurchasesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchasesToolStripMenuItem.Click
        openForm(frmPurchaseInvoice)
    End Sub

    Private Sub PurchaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchaseToolStripMenuItem.Click

    End Sub

    Private Sub CashAndBankToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CashAndBankToolStripMenuItem.Click

    End Sub

    Private Sub CustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerToolStripMenuItem.Click
        openForm(SalesPayment)
    End Sub

    Private Sub PurchasesPaymentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchasesPaymentToolStripMenuItem.Click

    End Sub

    Private Sub PurchasePaymentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchasePaymentToolStripMenuItem.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        openForm(PurchasePayment)
    End Sub

    Private Sub BankBookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BankBookToolStripMenuItem.Click
        openForm(BankBook)
    End Sub

    Private Sub OtherDepositToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OtherDepositToolStripMenuItem1.Click
        openForm(OtherDeposit)
    End Sub

    Private Sub OtherPaymentToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OtherPaymentToolStripMenuItem1.Click
        openForm(OtherWithdrawal)
    End Sub
End Class
