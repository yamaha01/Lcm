Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmCRSalesInvoicesListSummary
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

    Private Sub frmCRSalesInvoicesListSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim cryRpt As New ReportDocument
        'cryRpt.Load("D:\Works\Projects\visual studio 2013\Lcm\LcmApplication\LcmApplication\crSalesInvoicesListSummary.rpt")
        frmReportFormat.Dispose()
        frmReportFormat.Close()
        Dim formatStartDate As String
        Dim formatEndDate As String
        formatStartDate = Format(CDate(_dtpStartDate.Value), "yyyy/MM/dd")
        formatEndDate = Format(CDate(_dtpEndDate.Value), "yyyy/MM/dd")

        Dim sqlQuery As String
        sqlQuery = "SELECT ej.invoice_no as InvoiceNo, ag.ins_dt as JobDate, ej.cust_cd as CustCode, cm.cust_nm as CustName, " &
            "ej.pod_final as Dest, nq.amount as Amount, ej.gwt as Gwt, nq.total_amt as InvoiceAmount, ej.cbm as Cbm, " &
            " ej.sell_frt as SellFrt, ej.cost_frt as CostFrt, ag.due_date as DueDate " &
        "from lcm.clx_entry_job ej inner join clx_cust_mst cm on ej.cust_cd = cm.cust_cd " &
        "inner join (SELECT seq, cbp.job_no, freight_cd, cust_kind, bill_dt, curr_cd, tax_cd, " &
        "amt_tax, qty, exchange_rate, SUM(`amt_bill`)`amount`, SUM(qty * amt_bill)`total_amt` FROM lcm.clx_bill_prepaid cbp group by job_no) nq on ej.job_no = nq.job_no " &
        "inner join clx_aga01 ag on ag.job_no = ej.job_no where ag.slip_type = 'I' and " &
        "ag.ins_dt BETWEEN '" & formatStartDate & "' AND '" & formatEndDate & "' " & getInvConditions() & "order by invoice_no"
        ' & getInvConditions().Trim 
        'Dim objcon = New SqlConnection("data source=(local);initial catalog=hesabres;user id='sa';password='Maysam7026'")
        Logs.TraceLog("sqlQuery = " & sqlQuery, System.Reflection.MethodBase.GetCurrentMethod.Name())
        Dim myReport As New ReportDocument
        'Dim myData As New DataSet
        Dim myData As DataSet = New DataSet("myData")


        'Dim conn As New Odbc.OdbcConnection
        'Dim cmd As New Odbc.OdbcCommand
        Dim myAdapter As New Odbc.OdbcDataAdapter
        Dim MyConnection As New Odbc.OdbcConnection("DSN=lcm-local")
        Dim MyCommand As New Odbc.OdbcCommand
        'Dim myDataTable As DataTable

        Try
            MyConnection.Open()
            'condition where invoice no and username are the same
            MyCommand.CommandText = sqlQuery

            MyCommand.Connection = MyConnection
            myAdapter.SelectCommand = MyCommand
            myAdapter.Fill(myData)
            'myDataTable = myData.Tables.Add("Invoices")
            myReport.Load("D:\Works\Projects\visual studio 2013\Lcm\LcmApplication\LcmApplication\crSalesInvoicesListSummary.rpt")
            myReport.Database.Tables(0).SetDataSource(myData.Tables(0))
            'set title
            myReport.SetParameterValue("CompanyName", "PT LOGISTA CAHAYA MULTITRANS")
            myReport.SetParameterValue("reportName", reportName)
            myReport.SetParameterValue("reportDate", "From " & Format(CDate(_dtpStartDate.Value), "dd MMM yyyy") & " To " & Format(CDate(_dtpEndDate.Value), "dd MMM yyyy"))
            Logs.TraceLog("myDataTable.Rows.Count: " & myData.Tables(0).Rows.Count, System.Reflection.MethodBase.GetCurrentMethod.Name())
            Dim pFields As New ParameterFields()
            Dim pField As New ParameterField()
            Dim disVal As New ParameterDiscreteValue()
            Dim rVal As New ParameterRangeValue()
            pField.ParameterFieldName = "amount"

            crvSalesInvoiceViewer.ReportSource = myReport
            exportToPdf(myReport, "SalesInvoices.pdf")
            idPdfFileOpen = System.Diagnostics.Process.Start("D:\SalesInvoices.pdf").Id
            'System.Diagnostics.Process.Start("D:\Test1.pdf")

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

    Public Function getInvConditions() As String
        Dim sInvCond As String = ""
        Logs.TraceLog("_invoiceNoConditions = " & _invoiceNoConditions, System.Reflection.MethodBase.GetCurrentMethod.Name())
        Logs.TraceLog("_invoiceNoStringValue = " & _invoiceNoStringValue, System.Reflection.MethodBase.GetCurrentMethod.Name())
        If (_invoiceNoConditions) >= 1 Then
            Select Case _invoiceNoConditions
                Case 1
                    'equals
                    sInvCond = "AND ej.invoice_no = '" & _invoiceNoStringValue & "' "
                    Debug.WriteLine("invoice no 1")
                Case 2
                    'does not equals
                    sInvCond = "AND ej.invoice_no != '" & _invoiceNoStringValue & "' "
                    Debug.WriteLine("invoice no 2")
                Case 3
                    'contains
                    sInvCond = "AND ej.invoice_no like '%" & _invoiceNoStringValue & "%' "
                    Debug.WriteLine("invoice no 3")
                Case 4
                    'does not contains
                    sInvCond = "AND ej.invoice_no not like '%" & _invoiceNoStringValue & "%' "
                    Debug.WriteLine("invoice no 4")
                Case 5
                    'begins with
                    sInvCond = "AND ej.invoice_no like '" & _invoiceNoStringValue & "%' "
                    Debug.WriteLine("invoice no 5")
                Case 6
                    'does not begin with
                    sInvCond = "AND ej.invoice_no not like '" & _invoiceNoStringValue & "% "
                    Debug.WriteLine("invoice no 6")
                Case 7
                    'ends with
                    sInvCond = "AND ej.invoice_no like '%" & _invoiceNoStringValue & "' "
                    Debug.WriteLine("invoice no 7")
                Case Else
                    'does not end with
                    sInvCond = "AND ej.invoice_no not like '%" & _invoiceNoStringValue & "' "
                    Debug.WriteLine("Not between 1 - 7, inclusive")
            End Select


        End If
        Logs.TraceLog("sInvCond = " & sInvCond, System.Reflection.MethodBase.GetCurrentMethod.Name())
        Return sInvCond
    End Function

    Private Sub frmCRSalesInvoicesListSummary_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Logs.TraceLog("idPdfFileOpen = " & idPdfFileOpen, System.Reflection.MethodBase.GetCurrentMethod.Name())
        'System.Diagnostics.Process.GetProcessById(idPdfFileOpen).Kill()
    End Sub
End Class