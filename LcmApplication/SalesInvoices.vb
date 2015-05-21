Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports System.Runtime.InteropServices
Imports System.Text

Public Class frmSalesInvoices
    Dim bDoEventCbbxCust As Boolean = False
    Dim TagMethod As String = System.Reflection.MethodBase.GetCurrentMethod.Name()
    Dim conn As New OdbcConnection("DSN=lcm-local")
    Dim custId As String = ""

    Private Sub frmSalesInvoices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'loadDataInvoices()
        Logs.TraceLog("DSN=lcm-local", System.Reflection.MethodBase.GetCurrentMethod.Name())

        loadDataCustomer()

        cbbxCurrency.SelectedIndex = 0
        dgvSalesInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvSalesInvoice.AutoResizeColumns()

    End Sub

    Private Sub loadDataInvoices(sqlQuery As String)
        dgvSalesInvoice.DataSource = Nothing
        dgvSalesInvoice.Refresh()

        Logs.TraceLog("DSN=lcm-local", System.Reflection.MethodBase.GetCurrentMethod.Name())
        conn.Open()
        Dim daSalesInvoices As New OdbcDataAdapter(sqlQuery, conn)
        Logs.TraceLog(sqlQuery, System.Reflection.MethodBase.GetCurrentMethod.Name())
        Dim dsSalesInvoice As New DataSet("EntryJob")
        daSalesInvoices.Fill(dsSalesInvoice, "clx_entry_job")
        dgvSalesInvoice.DataSource = dsSalesInvoice.Tables("clx_entry_job").DefaultView
        'ej.job_no, ej.invoice_no, ej.job_dt, ej.cust_cd, cm.cust_nm, ag.airline_cd, ej.awb_no, 
        'ej.service_type, ej.pod_final, nq.amount, ej.gwt, ej.cwt, ej.cbm, ej.sell_frt, ej.cost_frt, ej.remarks
        Dim sJobNo As String
        Dim iAmountCell As Integer = 9
        'hide job no
        dgvSalesInvoice.Columns(0).HeaderText = "JOB NO"
        dgvSalesInvoice.Columns(1).HeaderText = "INVOICE NO"
        dgvSalesInvoice.Columns(2).HeaderText = "JOB DATE"
        dgvSalesInvoice.Columns(2).DefaultCellStyle.Format() = "dd MMM yy"
        dgvSalesInvoice.Columns(3).HeaderText = "CUST NO"
        dgvSalesInvoice.Columns(4).HeaderText = "CUST NAME"
        dgvSalesInvoice.Columns(5).HeaderText = "AIR CD"
        dgvSalesInvoice.Columns(6).HeaderText = "AWB"
        dgvSalesInvoice.Columns(7).HeaderText = "TYPE"
        dgvSalesInvoice.Columns(8).HeaderText = "DEST"
        dgvSalesInvoice.Columns(iAmountCell).HeaderText = "AMOUNT"
        dgvSalesInvoice.Columns(10).HeaderText = "GWT"
        dgvSalesInvoice.Columns(11).HeaderText = "CWT"
        dgvSalesInvoice.Columns(12).HeaderText = "CBM"
        dgvSalesInvoice.Columns(13).HeaderText = "SELL FRT"
        dgvSalesInvoice.Columns(14).HeaderText = "COST FRT"
        dgvSalesInvoice.Columns(15).HeaderText = "COST AMNT"
        dgvSalesInvoice.Columns(16).HeaderText = "REMARKS"
        dgvSalesInvoice.Columns(0).Visible = False

        conn.Close()
        For i = 0 To dgvSalesInvoice.Rows.Count - 1
            If i Mod 2 = 0 Then
                dgvSalesInvoice.Rows(i).DefaultCellStyle.BackColor = Color.White
            Else
                dgvSalesInvoice.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
            End If
        Next

        'Dim dAmount As Double = 0
        'For index As Integer = 0 To dgvSalesInvoice.RowCount - 1
        '    dAmount += Convert.ToDouble(dgvSalesInvoice.Rows(index).Cells(iAmountCell).Value)
        'Next

        'Dim drSummary As DataRow
        'drSummary = dsSalesInvoice.Tables(0).NewRow
        'drSummary.Item(5) = "TOTAL: "
        'drSummary.Item(iAmountCell) = dAmount
        'Dim iNewRow As Integer = dgvSalesInvoice.Rows.Count + 1
        'dsSalesInvoice.Tables(0).Rows.InsertAt(drSummary, iNewRow)

        'dgvSalesInvoice.Rows(dgvSalesInvoice.Rows.Count - 2).DefaultCellStyle.Font = New Font(dgvSalesInvoice.DefaultCellStyle.Font, FontStyle.Bold)
        'Logs.TraceLog("Row Count: " & Convert.ToString(dgvSalesInvoice.Rows.Count - 1), System.Reflection.MethodBase.GetCurrentMethod.Name())
        'Logs.TraceLog("amount total: " & Convert.ToString(dAmount), System.Reflection.MethodBase.GetCurrentMethod.Name())


    End Sub

    Private Sub loadDataCustomer()
        'stop click event on data load
        bDoEventCbbxCust = False

        Dim sqlQuery As String
        sqlQuery = "select cust_cd, cust_nm from clx_cust_mst"
        Logs.TraceLog("DSN=lcm-local", System.Reflection.MethodBase.GetCurrentMethod.Name())
        conn.Open()

        Dim daCustMaster As New OdbcDataAdapter(sqlQuery, conn)
        Dim dt As New DataSet
        Logs.TraceLog(sqlQuery, System.Reflection.MethodBase.GetCurrentMethod.Name())
        'Dim dsCustMaster As New DataSet("CustMaster")
        'daCustMaster.Fill(dsCustMaster, "clx_cust_mst")
        daCustMaster.Fill(dt, "clx_cust_mst")
        conn.Close()

        cbbxCustomer.DataSource = dt.Tables("clx_cust_mst").DefaultView
        cbbxCustomer.ValueMember = "cust_cd"
        cbbxCustomer.DisplayMember = "cust_nm"
        Dim dr As DataRow = dt.Tables("clx_cust_mst").NewRow()
        dr(0) = "-1"
        dr(1) = "<All>"
        dt.Tables("clx_cust_mst").Rows.InsertAt(dr, 0)
        cbbxCustomer.DataBindings.Add("DataSource", dt, dt.Tables("clx_cust_mst").TableName)
        cbbxCustomer.DataBindings.Clear()

        'to show autocomplete
        With cbbxCustomer
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With

        'ready for click event after load data
        bDoEventCbbxCust = True
    End Sub


    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        Dim sqlQuery As String
        Dim formatDateFrom As String
        Dim formatDateTo As String
        formatDateFrom = Format(CDate(dtpSIFrom.Value), "yyyy/MM/dd")
        formatDateTo = Format(CDate(dtpSITo.Value), "yyyy/MM/dd")

        'sqlQuery = "SELECT job_no, invoice_no, job_dt, ej.cust_cd, cust_nm FROM lcm.clx_entry_job ej, clx_cust_mst cm where job_dt BETWEEN '" &
        '    formatDateFrom & "' AND '" & formatDateTo & "' AND (ej.cust_cd = cm.cust_cd) order by invoice_no"
        'SELECT invoice_no, job_dt, ej.cust_cd, cust_nm FROM lcm.clx_entry_job ej, clx_cust_mst cm where 
        '(job_dt >= '2015/01/01' and job_dt <= '2015/03/09') and (ej.cust_cd = cm.cust_cd) order by invoice_no "
        sqlQuery = "SELECT ej.job_no, ej.invoice_no, ej.job_dt, ej.cust_cd, cm.cust_nm, ag.airline_cd, ej.awb_no, " &
            "ej.service_type, ej.pod_final, nq.amount, ej.gwt, ej.cwt, ej.cbm, ej.sell_frt, ej.cost_frt, nq.cost_amount, ej.remarks " &
        "from lcm.clx_entry_job ej inner join clx_cust_mst cm on ej.cust_cd = cm.cust_cd " &
        "inner join (SELECT seq, cbp.job_no, freight_cd, cust_kind, bill_dt, curr_cd, tax_cd, " &
        "amt_tax, qty, exchange_rate, SUM(`amt_bill`)`amount`, SUM(qty * amt_bill)`cost_amount`  FROM lcm.clx_bill_prepaid cbp group by job_no) nq on ej.job_no = nq.job_no " &
        "inner join clx_aga01 ag on ag.job_no = ej.job_no where ag.slip_type = 'I' and " &
        "ag.ins_dt BETWEEN '" & formatDateFrom & "' AND '" & formatDateTo & "' " & getCustid() & "order by invoice_no"
        loadDataInvoices(sqlQuery)
    End Sub

    Private Sub cbbxCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbxCustomer.SelectedIndexChanged
        If (bDoEventCbbxCust = True) Then
            'MsgBox(DirectCast(sender, ComboBox).SelectedValue.ToString)
            custId = DirectCast(sender, ComboBox).SelectedValue.ToString
        End If
    End Sub

    Public Shared Function handleQuote(data As String) As String
        Dim value As String
        value = "'" & data.Replace(data, data & "'")
        Return value
    End Function

    Private Sub dgvSalesInvoice_ColumnSortModeChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles dgvSalesInvoice.ColumnSortModeChanged
        
    End Sub

    Private Sub dgvSalesInvoice_CellStateChanged(sender As Object, e As DataGridViewCellStateChangedEventArgs) Handles dgvSalesInvoice.CellStateChanged
        
    End Sub

    Private Sub dtpSIFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpSIFrom.ValueChanged
        'If (dtpSIFrom.Value.Date <= dtpSIFrom.MaxDate) Or (dtpSIFrom.Value.Month <= 12) Then
        'MessageBox.Show("No go!")
        'SendKeys.Send("{/}")
        SendKeys.Send("{Right}")

        'End If
    End Sub

    Private Sub dtpSITo_ValueChanged(sender As Object, e As EventArgs) Handles dtpSITo.ValueChanged
        'If (dtpSITo.Value.Date <= dtpSITo.MaxDate) Or (dtpSITo.Value.Month <= 12) Then
        'MessageBox.Show("No go!")
        'SendKeys.Send("{/}")
        SendKeys.Send("{Right}")

        'End If
    End Sub

    Private Sub dtpSIFrom_DropDown(sender As Object, e As EventArgs) Handles dtpSIFrom.DropDown
        RemoveHandler dtpSIFrom.ValueChanged, AddressOf dtpSIFrom_ValueChanged
    End Sub

    Private Sub dtpSIFrom_CloseUp(sender As Object, e As EventArgs) Handles dtpSIFrom.CloseUp
        AddHandler dtpSIFrom.ValueChanged, AddressOf dtpSIFrom_ValueChanged
        Call dtpSIFrom_ValueChanged(sender, EventArgs.Empty)
    End Sub

    Private Sub dtpSITo_DropDown(sender As Object, e As EventArgs) Handles dtpSITo.DropDown
        RemoveHandler dtpSITo.ValueChanged, AddressOf dtpSITo_ValueChanged
    End Sub

    Private Sub dtpSITo_CloseUp(sender As Object, e As EventArgs) Handles dtpSITo.CloseUp
        AddHandler dtpSITo.ValueChanged, AddressOf dtpSITo_ValueChanged
        Call dtpSITo_ValueChanged(sender, EventArgs.Empty)
    End Sub

    Private Sub dgvSalesInvoice_Sorted(sender As Object, e As EventArgs) Handles dgvSalesInvoice.Sorted
        For i = 0 To dgvSalesInvoice.Rows.Count - 1
            If i Mod 2 = 0 Then
                dgvSalesInvoice.Rows(i).DefaultCellStyle.BackColor = Color.White
            Else
                dgvSalesInvoice.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
            End If
        Next
    End Sub


    Public Function getCustid() As String
        Dim sqlConditions = ""
        Logs.TraceLog("getCustid = " & custId, System.Reflection.MethodBase.GetCurrentMethod.Name())
        If (Not custId.Equals("")) Then
            If (Not custId.Equals("-1")) Then
                sqlConditions = "and ej.cust_cd='" & custId & "' "
            End If
        End If
        Return sqlConditions
    End Function
End Class