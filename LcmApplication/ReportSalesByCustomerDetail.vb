Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class ReportSalesByCustomerDetail
    Dim con As MySqlConnection
    Dim da As New MySqlDataAdapter
    Dim ds As DataSet
    Public Function jokenconn() As MySqlConnection
        Dim urlDb As String
        Dim mySqlDb As New mySqlDB
        urlDb = mySqlDb.getUrlDatabase()
        Return New MySqlConnection(urlDb)
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim startDate As DateTime = StartDatePicker.Value
        Dim endDate As DateTime = EndDatePicker.Value
        Me.StartDatePicker.Value = New Date(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0)
        Me.EndDatePicker.Value = New Date(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59)
        print()
    End Sub
    Private Sub print()
        Dim myData As New DataSet
        Dim myDataDetail As New DataSet
        Dim conn As New MySqlConnection
        Dim sqlCommand As New MySqlCommand
        Dim myAdapter As New MySqlDataAdapter
        Dim sql As String
        Try
            sql = "select invoice_no, invoice_date, nama_customer,notes, total_order from sales_payment where payment_date BETWEEN @startDate AND @endDate order by nama_customer "

            con = jokenconn()
            con.Open()
            sqlCommand.Connection = con
            sqlCommand.CommandText = sql
            sqlCommand.Parameters.AddWithValue("@startDate", StartDatePicker.Value)
            sqlCommand.Parameters.AddWithValue("@endDate", EndDatePicker.Value)

            myAdapter.SelectCommand = sqlCommand
            myAdapter.Fill(myData)
            Dim myReport As New ReportDocument
            myReport.Load("D:\Personal\IT_Solution\Lcm\LcmApplication\SalesByCustomerDetail.rpt")
            myReport.SetDataSource(myData)
            myReport.SetParameterValue("date", StartDatePicker.Value + " - " + EndDatePicker.Value)
            PreviewPrint.CrystalReportViewer1.ReportSource = myReport
            PreviewPrint.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Report could not be created", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub
End Class