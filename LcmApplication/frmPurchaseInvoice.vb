Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports System.Runtime.InteropServices

Public Class frmPurchaseInvoice
    Dim bDoEventCbbxCust As Boolean = False
    Dim TagMethod As String = System.Reflection.MethodBase.GetCurrentMethod.Name()
    Dim conn As New OdbcConnection("DSN=lcm-local")
    Dim disabledEvent As Boolean = False
    Dim vendorId As String = ""

    Private Sub frmPurchaseInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadDataAirlines()
        cbbxCurrPurc.SelectedIndex = 0
        dgvPurchaseInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvPurchaseInvoice.AutoResizeColumns()
 
    End Sub



    Private Sub loadDataAirlines()
        'stop click event on data load
        'bDoEventCbbxCust = False

        Dim sqlQuery As String
        sqlQuery = "select airline_cd, airline_nm from clx_air_mst"
        Logs.TraceLog("DSN=lcm-local", System.Reflection.MethodBase.GetCurrentMethod.Name())
        conn.Open()

        Dim daAirlinesMaster As New OdbcDataAdapter(sqlQuery, conn)
        Dim dt As New DataSet
        Logs.TraceLog(sqlQuery, System.Reflection.MethodBase.GetCurrentMethod.Name())
        daAirlinesMaster.Fill(dt, "clx_air_mst")
        conn.Close()

        cbbxAirlines.DataSource = dt.Tables("clx_air_mst").DefaultView
        cbbxAirlines.ValueMember = "airline_cd"
        cbbxAirlines.DisplayMember = "airline_nm"
        Dim dr As DataRow = dt.Tables("clx_air_mst").NewRow()
        dr(0) = "-1"
        dr(1) = "<All>"
        dt.Tables("clx_air_mst").Rows.InsertAt(dr, 0)
        cbbxAirlines.DataBindings.Add("DataSource", dt, dt.Tables("clx_air_mst").TableName)
        cbbxAirlines.DataBindings.Clear()
        'to show autocomplete

        'to show autocomplete
        With cbbxAirlines
            .AutoCompleteMode = AutoCompleteMode.Suggest
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With

        'ready for click event after load data
        bDoEventCbbxCust = True
    End Sub

    Private Sub loadPurchaseInvoice(sqlQuery As String)

        dgvPurchaseInvoice.DataSource = Nothing
        dgvPurchaseInvoice.Refresh()

        Logs.TraceLog("DSN=lcm-local", System.Reflection.MethodBase.GetCurrentMethod.Name())
        conn.Open()
        Dim daPurchaseInvoices As New OdbcDataAdapter(sqlQuery, conn)
        Logs.TraceLog(sqlQuery, System.Reflection.MethodBase.GetCurrentMethod.Name())
        Dim dsPurchaseInvoice As New DataSet("PurchaseJob")
        daPurchaseInvoices.Fill(dsPurchaseInvoice, "clx_purchase_job")
        dgvPurchaseInvoice.DataSource = dsPurchaseInvoice.Tables("clx_purchase_job").DefaultView
        'ejn.job_no, ejn.invoice_no, ejn.job_dt, ejn.cust_cd, cm.cust_nm, ejn.airline_cd, 
        'am.airline_nm, ejn.pod_final, nq.amount, nq.total_amt, cbc.AP, (nq.total_amt - cbc.AP)`SVC INCOME`
        Dim sJobNo As String
        Dim iAmount As Integer = 8
        Dim iARCell As Integer = 9
        Dim iAPCell As Integer = 10
        Dim iSrvIncmCell As Integer = 11
        'hide job no
        dgvPurchaseInvoice.Columns(0).HeaderText = "JOB NO"
        dgvPurchaseInvoice.Columns(1).HeaderText = "INVOICE NO"
        dgvPurchaseInvoice.Columns(2).HeaderText = "JOB DATE"
        dgvPurchaseInvoice.Columns(2).DefaultCellStyle.Format() = "dd MMM yy"
        dgvPurchaseInvoice.Columns(3).HeaderText = "CUST CD"
        dgvPurchaseInvoice.Columns(4).HeaderText = "CUST NAME"
        dgvPurchaseInvoice.Columns(5).HeaderText = "AIR CD"
        dgvPurchaseInvoice.Columns(6).HeaderText = "AIR NAME"
        dgvPurchaseInvoice.Columns(7).HeaderText = "DEST"
        dgvPurchaseInvoice.Columns(iAmount).HeaderText = "AMOUNT"
        dgvPurchaseInvoice.Columns(iARCell).HeaderText = "AR"
        dgvPurchaseInvoice.Columns(iAPCell).HeaderText = "AP"
        dgvPurchaseInvoice.Columns(iSrvIncmCell).HeaderText = "SVC INCOME"
        dgvPurchaseInvoice.Columns(0).Visible = False

        conn.Close()
        For i = 0 To dgvPurchaseInvoice.Rows.Count - 1
            If i Mod 2 = 0 Then
                dgvPurchaseInvoice.Rows(i).DefaultCellStyle.BackColor = Color.White
            Else
                dgvPurchaseInvoice.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
            End If
        Next

        'Dim dAmount As Double = 0
        'Dim dAmountAR As Double = 0
        'Dim dAmountAP As Double = 0
        'Dim dAmountSrv As Double = 0

        'For index As Integer = 0 To dgvPurchaseInvoice.RowCount - 1
        '    dAmount += Convert.ToDouble(dgvPurchaseInvoice.Rows(index).Cells(iAmount).Value)
        '    dAmountAR += Convert.ToDouble(dgvPurchaseInvoice.Rows(index).Cells(iARCell).Value)
        '    dAmountAP += Convert.ToDouble(dgvPurchaseInvoice.Rows(index).Cells(iAPCell).Value)
        '    dAmountSrv += Convert.ToDouble(dgvPurchaseInvoice.Rows(index).Cells(iSrvIncmCell).Value)
        'Next

        'Dim drSummary As DataRow
        'drSummary = dsPurchaseInvoice.Tables(0).NewRow
        'drSummary.Item(5) = "TOTAL: "
        'drSummary.Item(iAmount) = dAmount
        'drSummary.Item(iARCell) = dAmountAR
        'drSummary.Item(iAPCell) = dAmountAP
        'drSummary.Item(iSrvIncmCell) = dAmountSrv
        'Dim iNewRow As Integer = dgvPurchaseInvoice.Rows.Count + 1
        'dsPurchaseInvoice.Tables(0).Rows.InsertAt(drSummary, iNewRow)
        'dgvPurchaseInvoice.Rows(dgvPurchaseInvoice.Rows.Count - 2).DefaultCellStyle.Font = New Font(dgvPurchaseInvoice.DefaultCellStyle.Font, FontStyle.Bold)
        'Logs.TraceLog("Row Count: " & Convert.ToString(dgvPurchaseInvoice.Rows.Count - 1), System.Reflection.MethodBase.GetCurrentMethod.Name())
        'Logs.TraceLog("amount total: " & Convert.ToString(iARCell), System.Reflection.MethodBase.GetCurrentMethod.Name())

        
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        Dim sqlQuery As String
        Dim formatDateFrom As String
        Dim formatDateTo As String
        formatDateFrom = Format(CDate(dtpSIFrom.Value), "yyyy/MM/dd")
        formatDateTo = Format(CDate(dtpSITo.Value), "yyyy/MM/dd")

        
        sqlQuery = "select ejn.job_no, ejn.invoice_no, ejn.job_dt, ejn.cust_cd, cm.cust_nm, ejn.airline_cd, am.airline_nm, ejn.pod_final, nq.amount, nq.total_amt, cbc.AP, (nq.total_amt - cbc.AP)`SVC INCOME` " &
            "From (select ej.job_no, ej.invoice_no, ej.job_dt, ej.cust_cd, ag.airline_cd, ej.pod_final from clx_entry_job ej, clx_aga01 ag " &
            "where ag.job_no = ej.job_no and ag.slip_type = 'I' and ag.ins_dt BETWEEN '" & formatDateFrom & "' AND '" & formatDateTo & "' " & getVendorid() & ") ejn " &
            "inner join (SELECT seq, cbp.job_no, freight_cd, cust_kind, bill_dt, curr_cd, tax_cd, amt_tax, qty, exchange_rate, SUM(`amt_bill`)`amount`, SUM(qty * amt_bill)`total_amt` FROM lcm.clx_bill_prepaid cbp group by job_no) nq on ejn.job_no = nq.job_no " &
            "inner join clx_cust_mst cm on ejn.cust_cd = cm.cust_cd " &
            "inner join (SELECT airline_cd, airline_nm FROM clx_air_mst airmst) am on am.airline_cd = ejn.airline_cd " &
            "inner join (SELECT seq, job_no, freight_cd, cust_kind, cust_cd, bill_dt, curr_cd, tax_cd, amt_tax, qty, exchange_rate, amt_bill, remark, invoice_no, ins_dt, ins_id, upd_dt, upd_id, del_id, del_dt, SUM(qty * amt_bill)`AP` " &
            "FROM lcm.clx_bill_cost group by job_no) cbc on ejn.job_no = cbc.job_no"
        loadPurchaseInvoice(sqlQuery)
    End Sub


    Private Sub dgvPurchaseInvoice_CellStateChanged(sender As Object, e As DataGridViewCellStateChangedEventArgs) Handles dgvPurchaseInvoice.CellStateChanged
        'Logs.TraceLog("dgvPurchaseInvoice_CellStateChanged ", System.Reflection.MethodBase.GetCurrentMethod.Name())
        'For i = 0 To dgvPurchaseInvoice.Rows.Count - 1
        '    If i Mod 2 = 0 Then
        '        dgvPurchaseInvoice.Rows(i).DefaultCellStyle.BackColor = Color.White
        '    Else
        '        dgvPurchaseInvoice.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
        '    End If
        'Next
    End Sub
    Private Sub dtpSIFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpSIFrom.ValueChanged
        Logs.TraceLog("dtpSIFrom_ValueChanged ", System.Reflection.MethodBase.GetCurrentMethod.Name())
        'MessageBox.Show("No go!")
        'SendKeys.Send("{/}")
        SendKeys.Send("{Right}")
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

    Private Sub cbbxAirlines_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbxAirlines.SelectedIndexChanged
        If (bDoEventCbbxCust = True) Then
            'MsgBox(DirectCast(sender, ComboBox).SelectedValue.ToString)
            vendorId = DirectCast(sender, ComboBox).SelectedValue.ToString
        End If
    End Sub

    Public Function getVendorid() As String
        Dim sqlConditions = ""
        Logs.TraceLog("getVendorid = " & vendorId, System.Reflection.MethodBase.GetCurrentMethod.Name())
        If (Not vendorId.Equals("")) Then
            If (Not vendorId.Equals("-1")) Then
                sqlConditions = "and ag.airline_cd='" & vendorId & "' "
            End If
        End If
        Return sqlConditions
    End Function

    Private Sub dgvPurchaseInvoice_Sorted(sender As Object, e As EventArgs) Handles dgvPurchaseInvoice.Sorted
        Logs.TraceLog("dgvPurchaseInvoice_Sorted ", System.Reflection.MethodBase.GetCurrentMethod.Name())
        For i = 0 To dgvPurchaseInvoice.Rows.Count - 1
            If i Mod 2 = 0 Then
                dgvPurchaseInvoice.Rows(i).DefaultCellStyle.BackColor = Color.White
            Else
                dgvPurchaseInvoice.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
            End If
        Next
    End Sub
End Class