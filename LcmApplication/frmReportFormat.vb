Public Class frmReportFormat
    Private _reportCategory As Integer
    Private _reportDetail As Integer

    Private Property _reportName As String

    Public Property reportName As String
        Get
            Return Me._reportName
        End Get
        Set(value As String)
            Me._reportName = value
        End Set
    End Property

    Public Property reportCategory As Integer

        Get
            Return _reportCategory
        End Get

        Set(ByVal Value As Integer)
            _reportCategory = Value
        End Set

    End Property

    Public Property reportDetail As Integer

        Get
            Return _reportDetail
        End Get

        Set(ByVal Value As Integer)
            _reportDetail = Value
        End Set

    End Property


    Private Sub frmReportFormat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        'tcFilternParameters.TabPages. = 2

        'MessageBox.Show("Cat, Details: " & reportCategory & ", " & reportDetail)
        tcFilternParameters.SelectedTab = tpParameter
    End Sub


    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If (reportCategory = 0) Then
            If reportDetail = 0 Then
                frmCRPurchaseInvoicesListSummary.DtpStartDate = dtpStartDate
                frmCRPurchaseInvoicesListSummary.DtpEndDate = dtpEndDate
                frmCRPurchaseInvoicesListSummary.reportName = reportName
                frmCRPurchaseInvoicesListSummary.InvoiceNoStringValue = tbInvoiceNoValue.Text
                frmMainLcm.openForm(frmCRPurchaseInvoicesListSummary)
            End If
        ElseIf (reportCategory = 1) Then
            If reportDetail = 0 Then
                frmCRSalesInvoicesListSummary.DtpStartDate = dtpStartDate
                frmCRSalesInvoicesListSummary.DtpEndDate = dtpEndDate
                frmCRSalesInvoicesListSummary.reportName = reportName
                frmCRSalesInvoicesListSummary.InvoiceNoStringValue = tbInvoiceNoValue.Text
                frmMainLcm.openForm(frmCRSalesInvoicesListSummary)
            End If
        End If

    End Sub

    Private Sub dtpStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.ValueChanged

        If (dtpStartDate.Value.Date <= dtpStartDate.MaxDate) Or (dtpStartDate.Value.Month <= 12) Then
            SendKeys.Send("{Right}")
        End If
    End Sub

    Private Sub dtpEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpEndDate.ValueChanged
        If (dtpEndDate.Value.Date <= dtpEndDate.MaxDate) Or (dtpEndDate.Value.Month <= 12) Then
            SendKeys.Send("{Right}")
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        'MsgBox(DirectCast(sender, ListBox).SelectedIndex)
        Dim iIndex As Integer = DirectCast(sender, ListBox).SelectedIndex
        If iIndex = 0 Then
            tcFilter.SelectedTab = tpInvoiceNo
        ElseIf iIndex = 1 Then
            tcFilter.SelectedTab = tpStatus
        End If
    End Sub

    Private Sub radioButton_CheckedChanged(sender As Object, e As EventArgs) Handles rbAll.CheckedChanged, rbEquals.CheckedChanged, rbDoesNotEqual.CheckedChanged, rbEndsWith.CheckedChanged, rbDoestNotContain.CheckedChanged, rbDoestNotBeginWith.CheckedChanged, rbDoesNotEndWith.CheckedChanged, rbContains.CheckedChanged, rbBeginsWith.CheckedChanged
        Dim rb As RadioButton = DirectCast(sender, RadioButton)
        If (rbAll.Checked <> True) Then
            If rb.Checked Then
                If (rbBeginsWith.Checked) Then
                    frmCRPurchaseInvoicesListSummary.InvoiceNoConditions = 5
                    frmCRSalesInvoicesListSummary.InvoiceNoConditions = 5
                    Logs.TraceLog("InvoiceNoStringValue = " & tbInvoiceNoValue.Text, System.Reflection.MethodBase.GetCurrentMethod.Name())
                End If
                'MessageBox.Show(rb.Name)
            End If
        End If

    End Sub
End Class