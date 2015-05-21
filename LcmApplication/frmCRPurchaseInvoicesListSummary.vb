Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmCRPurchaseInvoicesListSummary
    'this is id for pdf file that open
    Dim idPdfFileOpen As Integer 'Global variable

    Private Property _dtpStartDate As DateTimePicker

    Private Property _dtpEndDate As DateTimePicker

    Private Property _invoiceNoConditions As Integer

    Private Property _invoiceNoStringValue As String

    Private Property _reportName As String


    Public Property reportName As String
        Get
            Return Me._reportName
        End Get
        Set(value As String)
            Me._reportName = value
        End Set
    End Property

    Public Property InvoiceNoStringValue As String
        Get
            Return Me._invoiceNoStringValue
        End Get
        Set(value As String)
            Me._invoiceNoStringValue = value
        End Set
    End Property

    Public Property InvoiceNoConditions As Integer
        Get
            Return Me._invoiceNoConditions
        End Get
        Set(value As Integer)
            Me._invoiceNoConditions = value
        End Set
    End Property


    Public Property DtpStartDate As DateTimePicker
        Get
            Return Me._dtpStartDate
        End Get
        Set(value As DateTimePicker)
            Me._dtpStartDate = value
        End Set
    End Property

    Public Property DtpEndDate As DateTimePicker
        Get
            Return Me._dtpEndDate
        End Get
        Set(value As DateTimePicker)
            Me._dtpEndDate = value
        End Set
    End Property

    Private Sub frmCRPurchaseInvoicesListSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmReportFormat.Dispose()
        frmReportFormat.Close()
        Dim formatStartDate As String
        Dim formatEndDate As String
        formatStartDate = Format(CDate(_dtpStartDate.Value), "yyyy/MM/dd")
        formatEndDate = Format(CDate(_dtpEndDate.Value), "yyyy/MM/dd")
        'getInvConditions()
        Dim sqlQuery As String
        sqlQuery = "select distinct ejn.invoice_no as InvoiceNo, ejn.ins_dt as InvDate, ejn.airline_cd as AirCd, " &
            "am.airline_nm as VendorName, ejn.cwt as Toonage, nq.total_amt as AR, cbc.AP as AP, " &
            "ejn.ins_dt as DueDate, (nq.total_amt - cbc.AP)`SvcIncome`, clcbcr.Refund as `Refund` " &
            "from (select ej.job_no, ej.invoice_no, ej.job_dt, ej.cust_cd, ej.cwt, ag.airline_cd, ag.ins_dt, ej.pod_final from clx_entry_job ej, clx_aga01 ag " &
            "where ag.job_no = ej.job_no and ag.slip_type = 'I' and ag.ins_dt BETWEEN '" & formatStartDate & "' AND '" & formatEndDate & "') ejn " &
            "inner join (SELECT seq, cbp.job_no, freight_cd, cust_kind, bill_dt, curr_cd, tax_cd, amt_tax, qty, exchange_rate, SUM(`amt_bill`)`amount`, SUM(qty * amt_bill)`total_amt` FROM lcm.clx_bill_prepaid cbp group by job_no) nq on ejn.job_no = nq.job_no " &
            "inner join clx_cust_mst cm on ejn.cust_cd = cm.cust_cd " &
            "inner join (SELECT airmst.airline_cd, airline_nm FROM clx_air_mst airmst) am on am.airline_cd = ejn.airline_cd " &
            "inner join (SELECT seq, job_no, freight_cd, cust_kind, cust_cd, bill_dt, curr_cd, tax_cd, amt_tax, qty, exchange_rate, amt_bill, remark, invoice_no, ins_dt, ins_id, upd_dt, upd_id, del_id, del_dt, SUM(qty * amt_bill)`AP` " &
            "FROM lcm.clx_bill_cost where freight_cd != 'ZF' group by job_no) cbc on ejn.job_no = cbc.job_no " & getInvConditions() &
            "left join (SELECT cbcr.freight_cd, cbcr.job_no, cbcr.qty, cbcr.amt_bill, SUM(qty * amt_bill)`Refund` FROM lcm.clx_bill_cost cbcr where cbcr.freight_cd = 'ZF' group by cbcr.job_no) clcbcr on ejn.job_no = clcbcr.job_no order by ejn.invoice_no "
        Logs.TraceLog("sqlQuery = " & sqlQuery, System.Reflection.MethodBase.GetCurrentMethod.Name())
        Dim myReport As New ReportDocument
        Dim myDataPur As DataSet = New DataSet("myDataPur")

        Dim myAdapter As New Odbc.OdbcDataAdapter
        Dim MyConnection As New Odbc.OdbcConnection("DSN=lcm-local")
        Dim MyCommand As New Odbc.OdbcCommand

        Try
            MyConnection.Open()
            'condition where invoice no and username are the same
            MyCommand.CommandText = sqlQuery

            MyCommand.Connection = MyConnection
            myAdapter.SelectCommand = MyCommand
            myAdapter.Fill(myDataPur)
            'myDataTable = myData.Tables.Add("Invoices")
            myReport.Load("D:\Works\Projects\visual studio 2013\Lcm\LcmApplication\LcmApplication\crPurchaseInvoicesListSummary.rpt")
            myReport.Database.Tables(0).SetDataSource(myDataPur.Tables(0))
            'set title
            'myReport.SetParameterValue("CompanyName", "PT LOGISTA CAHAYA MULTITRANS")
            myReport.SetParameterValue("CompanyName", "PT LOGISTA CAHAYA MULTITRANS")
            myReport.SetParameterValue("reportName", reportName)
            myReport.SetParameterValue("reportDate", "From " & Format(CDate(_dtpStartDate.Value), "dd MMM yyyy") & " To " & Format(CDate(_dtpEndDate.Value), "dd MMM yyyy"))

            Logs.TraceLog("myDataPurchase.Rows.Count: " & myDataPur.Tables(0).Rows.Count, System.Reflection.MethodBase.GetCurrentMethod.Name())
            Dim pFields As New ParameterFields()
            Dim pField As New ParameterField()
            Dim disVal As New ParameterDiscreteValue()
            Dim rVal As New ParameterRangeValue()
            'pField.ParameterFieldName = "amount"

            crvPurchaseInvoiceViewer.ReportSource = myReport
            exportToPdf(myReport, "PurchaseInvoices.pdf")

            'idPdfFileOpen = System.Diagnostics.Process.Start("D:\PurchaseInvoices.pdf").Id
            System.Diagnostics.Process.Start("D:\PurchaseInvoices.pdf")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        MyConnection.Close()
    End Sub

    Public Sub LaunchPDF(ByVal strFile As String)
        If strFile.Trim.Length <> 0 AndAlso System.IO.File.Exists(strFile.Trim) Then
            Try
                Process.Start(strFile.Trim)
            Catch ex As System.ComponentModel.Win32Exception
                MessageBox.Show("To view a report after it has been turned into a PDF, your computer must have Adobe Reader." & _
                                vbCr & "Please download and install Adobe Reader from http://www.adobe.com.", "")
            Catch ex As Exception
                MessageBox.Show("Unable to view PDF." & vbCr & "Error: " & ex.Message, "")
            End Try

        End If
    End Sub

    Public Function getInvConditions() As String

        Dim sInvCond As String = ""
        Logs.TraceLog("_invoiceNoConditions = " & _invoiceNoConditions, System.Reflection.MethodBase.GetCurrentMethod.Name())
        Logs.TraceLog("_invoiceNoStringValue = " & _invoiceNoStringValue, System.Reflection.MethodBase.GetCurrentMethod.Name())
        If (_invoiceNoConditions) >= 1 Then
            Select Case _invoiceNoConditions
                Case 1
                    'equals
                    sInvCond = "AND ejn.invoice_no = '" & _invoiceNoStringValue & "' "
                    Debug.WriteLine("invoice no 1")
                Case 2
                    'does not equals
                    sInvCond = "AND ejn.invoice_no != '" & _invoiceNoStringValue & "' "
                    Debug.WriteLine("invoice no 2")
                Case 3
                    'contains
                    sInvCond = "AND ejn.invoice_no like '%" & _invoiceNoStringValue & "%' "
                    Debug.WriteLine("invoice no 3")
                Case 4
                    'does not contains
                    sInvCond = "AND ejn.invoice_no not like '%" & _invoiceNoStringValue & "%' "
                    Debug.WriteLine("invoice no 4")
                Case 5
                    'begins with
                    sInvCond = "AND ejn.invoice_no like '" & _invoiceNoStringValue & "%' "
                    Debug.WriteLine("invoice no 5")
                Case 6
                    'does not begin with
                    sInvCond = "AND ejn.invoice_no not like '" & _invoiceNoStringValue & "% "
                    Debug.WriteLine("invoice no 6")
                Case 7
                    'ends with
                    sInvCond = "AND ejn.invoice_no like '%" & _invoiceNoStringValue & "' "
                    Debug.WriteLine("invoice no 7")
                Case Else
                    'does not end with
                    sInvCond = "AND ejn.invoice_no not like '%" & _invoiceNoStringValue & "' "
                    Debug.WriteLine("Not between 1 - 7, inclusive")
            End Select
            Logs.TraceLog("sInvCond = " & sInvCond, System.Reflection.MethodBase.GetCurrentMethod.Name())
            Return sInvCond
        End If

    End Function

    Public Sub exportToPdf(cryRpt As ReportDocument, ByVal strFileName As String)
        Try
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New  _
            DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
            CrDiskFileDestinationOptions.DiskFileName = _
                                        "D:\" & strFileName
            CrExportOptions = cryRpt.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With
            cryRpt.Export()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub frmCRPurchaseInvoicesListSummary_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        'Logs.TraceLog("idPdfFileOpen = " & idPdfFileOpen, System.Reflection.MethodBase.GetCurrentMethod.Name())
        'System.Diagnostics.Process.GetProcessById(idPdfFileOpen).Kill()
    End Sub
End Class