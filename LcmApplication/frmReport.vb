Public Class frmReport
    Dim iCategory As Integer = 0
    Dim iDetails As Integer = 0
    Private Sub frmReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbRptCategory.Font = New Font("Arial", 10, FontStyle.Regular)

        lbRptDetails.Font = New Font("Arial", 10, FontStyle.Regular)

    End Sub

    Private Sub lbRptCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbRptCategory.SelectedIndexChanged
        'MessageBox.Show("List Box Index: " & DirectCast(sender, ListBox).SelectedIndex.ToString)
        iCategory = DirectCast(sender, ListBox).SelectedIndex.ToString
        lbRptDetails.Items.Clear()
        Select Case iCategory
            Case 0
                lbRptDetails.Items.Add("Purchase Invoices List Summary")
                lbRptDetails.Items.Add("Purchase Invoices List Detail")
                Debug.WriteLine("lbRptCategory Selected 0")
            Case 1
                lbRptDetails.Items.Add("Sales Invoices By Customer Summary")
                lbRptDetails.Items.Add("Sales Invoices By Customer Detail")
                Debug.WriteLine("lbRptCategory Selected 1")
            Case 2
                Debug.WriteLine("lbRptCategory Selected 2")
            Case Else
                Debug.WriteLine("lbRptCategory Selected Others")
        End Select
    End Sub

    Private Sub lbRptDetails_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbRptDetails.SelectedIndexChanged
        iDetails = DirectCast(sender, ListBox).SelectedIndex.ToString

        Select Case iCategory
            Case 0
                Debug.WriteLine("lbRptDetails Selected 0")
            Case 1
                Debug.WriteLine("lbRptDetails Selected 1")
            Case 2
                Debug.WriteLine("lbRptDetails Selected 2")
            Case Else
                Debug.WriteLine("lbRptDetails Selected Others")
        End Select
    End Sub

    Private Sub lbRptDetails_DoubleClick(sender As Object, e As EventArgs) Handles lbRptDetails.DoubleClick
        Debug.WriteLine("Cat, Details: " & iCategory & ", " & iDetails)
        Debug.WriteLine("ReportName: " & lbRptDetails.SelectedItem.ToString)
        'frmReportFormat.Show()
        frmReportFormat.reportCategory = iCategory
        frmReportFormat.reportDetail = iDetails
        frmReportFormat.ReportName = lbRptDetails.SelectedItem.ToString
        frmReportFormat.ShowDialog()
    End Sub

End Class