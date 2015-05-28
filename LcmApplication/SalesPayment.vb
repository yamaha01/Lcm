﻿Imports MySql.Data.MySqlClient

Public Class SalesPayment
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim ds As DataSet
    Public kodeSupplier As String
    Private rowIndex As Integer = 0
    Public listSelectVP = New List(Of PoVO)
    Public Function jokenconn() As MySqlConnection
        Dim urlDb As String
        Dim mySqlDb As New mySqlDB
        urlDb = mySqlDb.getUrlDatabase()
        Return New MySqlConnection(urlDb)
    End Function
    Private Sub populateCust()
        Dim sql As String
        Try
            ds = New DataSet()
            con = jokenconn()
            con.Open()
            sql = "select distinct b.cust_cd,b.cust_nm from clx_entry_job a inner join clx_cust_mst b on a.cust_cd = b.cust_cd order by b.cust_nm"
            Logs.TraceLog("sqlQuery populateCust = " & sql, System.Reflection.MethodBase.GetCurrentMethod.Name())
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "customer")
            con.Close()
            CmbCustomer.DataSource = ds.Tables(0)
            CmbCustomer.ValueMember = "cust_cd"
            CmbCustomer.DisplayMember = "cust_nm"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub populateBank()
        Dim sql As String
        Try
            ds = New DataSet()
            con = jokenconn()
            con.Open()
            sql = "select bank_id,bank_nm from bank order by bank_nm asc"
            Logs.TraceLog("sqlQuery populateBank = " & sql, System.Reflection.MethodBase.GetCurrentMethod.Name())
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "bank")
            con.Close()
            CmbBank.DataSource = ds.Tables(0)
            CmbBank.ValueMember = "bank_nm"
            CmbBank.DisplayMember = "bank_nm"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Function getPrimaryId() As Integer
        Dim nonqueryCommand As MySqlCommand
        Dim idPrimary As Integer
        Try
            con = jokenconn()
            con.Open()
            nonqueryCommand = con.CreateCommand()
            Dim Sql As String
            Sql = "select id from sales_payment order by id desc limit 0,1"
            Dim scalarCommand As New MySqlCommand(Sql, con)
            idPrimary = scalarCommand.ExecuteScalar()
            idPrimary = idPrimary + 1
            con.Close()
        Catch ex As MySqlException
            Console.WriteLine("Error: " & ex.ToString())
        Finally
            con.Close()
        End Try
        Return idPrimary
    End Function
    Private Sub inisialisasi()
        Dim now As DateTime = DateTime.Now
        Dim day As String = now.Day
        Dim month As String = now.Month
        Dim year As String = now.Year
        Dim seq As Integer
        seq = getPrimaryId()
        Dim formNoSystem As String = "SP/" + day + "/" + month + "/" + year + "/" + seq.ToString
        TextBoxSPNo.Text = formNoSystem


        Me.DataGridViewSP.ColumnCount = 5
        Me.DataGridViewSP.Columns(0).Name = "Invoice No"
        Me.DataGridViewSP.Columns(1).Name = "Invoice Date"
        Me.DataGridViewSP.Columns(2).Name = "Total Order"
        Me.DataGridViewSP.Columns(3).Name = "Owing"
        Me.DataGridViewSP.Columns(4).Name = "Payment Amount"
        DataGridViewSP.Columns(0).ReadOnly = True
        DataGridViewSP.Columns(1).ReadOnly = True
        DataGridViewSP.Columns(2).ReadOnly = True
        DataGridViewSP.Columns(3).ReadOnly = True
        formatKolomNumeric()
    End Sub
    Private Sub formatKolomNumeric()
        DataGridViewSP.Columns("Total Order").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewSP.Columns("Owing").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewSP.Columns("Payment Amount").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewSP.Columns("Total Order").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewSP.Columns("Owing").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewSP.Columns("Payment Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub
    Private Sub SalesPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inisialisasi()
        CmbCustomer.Focus()
        idPrimary.Text = getPrimaryId().ToString
    End Sub

    Private Sub CmbCustomer_Click(sender As Object, e As EventArgs) Handles CmbCustomer.Click
        populateCust()
    End Sub
    Private Function findCustomerByKode(kode As String) As Integer

        Dim db As Integer
        Dim sql As String
        Dim cmd As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            sql = "select distinct b.address1,b.address2,b.cust_cd,b.cust_nm from clx_entry_job a inner join clx_cust_mst b on a.cust_cd = b.cust_cd where b.cust_cd ='" & kode & "'"
            Logs.TraceLog("sqlQuery findCustomerByKode = " & sql, System.Reflection.MethodBase.GetCurrentMethod.Name())
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            da.Fill(publictable)
            If publictable.Rows.Count > 0 Then
                alamatCustomer.Text = publictable.Rows(0).Item(0) + " " + publictable.Rows(0).Item(1)
                TextBoxKodeCustomer.Text = publictable.Rows(0).Item(2)
                TextBoxNamaCustomer.Text = publictable.Rows(0).Item(3)
            End If
        Catch ex As MySqlException
            MessageBox.Show("error : " + ex.ToString)
        Finally
            con.Close()
        End Try
        Return db
    End Function
    Private Function findInvoiceByCustomerKode(kode As String) As Integer

        Dim db As Integer
        Dim sql As String
        Dim cmd As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            'sql = "select pih.sales_invoice_no,pih.sales_invoice_date , pih.total_order,IFNULL(pp.owing,pih.total_order)as owing, '0' as payment_amount from sales_invoice_header pih left join sales_payment pp on pih.sales_invoice_no = pp.invoice_no and pp.is_history = 1 where pih.kode_customer = '" & kode & "' and pih.status_sales_invoice = 1"
            sql = "SELECT ej.invoice_no AS sales_invoice_no,ag.ins_dt AS sales_invoice_date,nq.total_amt  AS total_order,IFNULL(pp.owing,nq.total_amt)as owing,'0' as payment_amount FROM lcm.clx_entry_job ej INNER JOIN clx_cust_mst cm ON ej.cust_cd = cm.cust_cd INNER JOIN (SELECT seq,cbp.job_no,freight_cd,cust_kind,bill_dt,curr_cd,tax_cd,amt_tax,qty,exchange_rate,Sum(`amt_bill`)    `amount`, Sum(qty * amt_bill)`total_amt` FROM   lcm.clx_bill_prepaid cbp GROUP  BY job_no) nq ON ej.job_no = nq.job_no INNER JOIN clx_aga01 ag ON ag.job_no = ej.job_no left join sales_payment pp on ej.invoice_no = pp.invoice_no and pp.is_history = 1 WHERE  ag.slip_type = 'I' and cm.cust_cd = '" & kode & "' and (pp.owing IS NULL or pp.owing <> 0 ) ORDER  BY ag.ins_dt asc"
            Logs.TraceLog("sqlQuery findInvoiceByCustomerKode = " & sql, System.Reflection.MethodBase.GetCurrentMethod.Name())
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            da.Fill(publictable)
            If publictable.Rows.Count > 0 Then
                Dim row As String()
                If DataGridViewSP.Columns.Count = 6 Then
                    DataGridViewSP.Columns.RemoveAt(5)
                End If
                DataGridViewSP.Rows.Clear()
                DataGridViewSP.Refresh()
                For Each oRecord As Object In publictable.Rows
                    row = New String() {oRecord("sales_invoice_no").ToString(), oRecord("sales_invoice_date").ToString(), oRecord("total_order").ToString(), oRecord("owing").ToString(), oRecord("payment_amount").ToString()}
                    DataGridViewSP.Rows.Add(row)
                Next
                Dim chk As New DataGridViewCheckBoxColumn()
                DataGridViewSP.Columns.Add(chk)
                chk.HeaderText = "Pay"
                chk.Name = "pay"
                DataGridViewSP.Refresh()
            End If
        Catch ex As MySqlException
            MessageBox.Show("error : " + ex.ToString)
        Finally
            con.Close()
        End Try
        Return db
    End Function

    Private Sub CmbCustomer_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CmbCustomer.SelectionChangeCommitted
        findCustomerByKode(CmbCustomer.SelectedValue)
        findInvoiceByCustomerKode(CmbCustomer.SelectedValue)
        For Each oItem As DataGridViewRow In DataGridViewSP.Rows
            oItem.Cells(2).Value = CLng(oItem.Cells(2).Value)
            oItem.Cells(3).Value = CLng(oItem.Cells(3).Value)
            oItem.Cells(4).Value = CLng(oItem.Cells(4).Value)
        Next
    End Sub

    Private Sub DataGridViewSP_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSP.CellContentClick
        If e.ColumnIndex = 5 Then
            If e.RowIndex >= 0 Then
                TextBoxNotes.Focus()
                If DataGridViewSP.Rows(e.RowIndex).Cells(5).Value = True Then
                    DataGridViewSP.Rows(e.RowIndex).Cells(4).Value = DataGridViewSP.Rows(e.RowIndex).Cells(3).Value
                    'MessageBox.Show("Checked", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    DataGridViewSP.Rows(e.RowIndex).Cells(4).Value = "0"
                    'MessageBox.Show("UnChecked", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

    Private Sub DataGridViewSP_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSP.CellEndEdit
        If e.ColumnIndex = 4 Then
            Dim iColumn As Integer = DataGridViewSP.CurrentCell.ColumnIndex
            Dim iRows As Integer = DataGridViewSP.CurrentCell.RowIndex
            DataGridViewSP.Rows(iRows).Cells(5).Value = True
            Dim payment As Long
            payment = DataGridViewSP.Rows(iRows).Cells(iColumn).Value
            Dim owing As Long
            owing = DataGridViewSP.Rows(iRows).Cells(3).Value
            If payment > owing Then
                MessageBox.Show("Pembayaran lebih besar dari pada owing", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                DataGridViewSP.Rows(iRows).Cells(iColumn).Value = owing
            End If
            DataGridViewSP.Rows(iRows).Cells(iColumn).Value = CLng(DataGridViewSP.Rows(iRows).Cells(iColumn).Value)

        End If
    End Sub

    Private Sub clearAllFIeld()
        TextBoxKodeCustomer.Text = ""
        TextBoxNamaCustomer.Text = ""
        alamatCustomer.Text = ""
        TextBoxSPNo.Text = ""
        DataGridViewSP.Rows.Clear()
        TextBoxNotes.Text = ""
        CmbCustomer.SelectedIndex = -1
    End Sub

    Private Sub refresh()
        'clearAllFIeld()
        DataGridViewSP.Rows.Clear()
        inisialisasi()
        Me.idPrimary.Text = getPrimaryId().ToString
        findCustomerByKode(CmbCustomer.SelectedValue)
        findInvoiceByCustomerKode(CmbCustomer.SelectedValue)
        For Each oItem As DataGridViewRow In DataGridViewSP.Rows
            oItem.Cells(2).Value = CLng(oItem.Cells(2).Value)
            oItem.Cells(3).Value = CLng(oItem.Cells(3).Value)
            oItem.Cells(4).Value = CLng(oItem.Cells(4).Value)
        Next
    End Sub

    Private Function insertSP() As Integer
        Dim rowEffected As Integer = 0
        Dim sqlCommand As New MySqlCommand
        Dim sql As String
        Dim pilih As Integer
        Dim now As DateTime = DateTime.Now
        Dim transaction As MySqlTransaction
        Dim queryGetIdentity As String = "Select @@Identity"
        con = jokenconn()
        con.Open()
        ' Start a local transaction
        transaction = con.BeginTransaction(IsolationLevel.ReadCommitted)
        Try

            'validasi
            If TextBoxSPNo.Text = "" Then
                MessageBox.Show("Sales Payment No harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBoxSPNo.Focus()
                Return 0
            End If

            If CmbCustomer.SelectedIndex = -1 Then
                MessageBox.Show("Customer / Konsumen harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbCustomer.Focus()
                Return 0
            End If

            If CmbBank.SelectedIndex = -1 Then
                MessageBox.Show("Bank harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbBank.Focus()
                Return 0
            End If

            If DataGridViewSP.Rows.Count = 0 Then
                MessageBox.Show("Items harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return 0
            End If

            ' Insert SP Header
            'Dim session As Session = Login.getSession()
            'removeSeparatorBeforeInsert()
            sqlCommand.Connection = con
            sqlCommand.Transaction = transaction
            sqlCommand.Parameters.Add("@kode_customer", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@nama_customer", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@alamat_customer", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@invoice_no", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@invoice_date", MySqlDbType.DateTime)
            sqlCommand.Parameters.Add("@sales_payment_no", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@payment_date", MySqlDbType.DateTime)
            sqlCommand.Parameters.Add("@total_order", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@owing", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@payment_amount", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@notes", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@is_history", MySqlDbType.Int16)
            'inisialisasi parameter bank book
            sqlCommand.Parameters.Add("@trx_date", MySqlDbType.DateTime)
            sqlCommand.Parameters.Add("@cheque_no", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@source_no", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@description", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@bank_name", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@deposit", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@withdrawal", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@balance", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@reconcile_date", MySqlDbType.DateTime)
            sqlCommand.Parameters.Add("@created_on", MySqlDbType.DateTime)

            For Each oItem As DataGridViewRow In DataGridViewSP.Rows
                If oItem.Cells(5).Value = True Then
                    pilih = 1
                    ' update sales payment ubah is history menjadi 0 karena trx ini hanya sebagai history saja
                    sql = "UPDATE sales_payment SET is_history = 0 WHERE invoice_no = @invoice_no"
                    sqlCommand.CommandText = sql
                    sqlCommand.Parameters("@invoice_no").Value = oItem.Cells(0).Value
                    sqlCommand.ExecuteNonQuery()

                    ' insert dengan is history menjadi 1
                    sql = "INSERT INTO sales_payment(kode_customer,nama_customer,alamat_customer,invoice_no,sales_payment_no,invoice_date,payment_date,total_order,owing,payment_amount,notes,is_history) VALUES (@kode_customer,@nama_customer,@alamat_customer,@invoice_no,@sales_payment_no,@invoice_date,@payment_date,@total_order,@owing,@payment_amount,@notes,@is_history)"
                    sqlCommand.CommandText = sql
                    'Dim PoNumber As String
                    'Dim RINumber As String
                    'If oItem.Cells(0).Value = "" Then
                    '    Continue For
                    'End If
                    sqlCommand.Parameters("@kode_customer").Value = TextBoxKodeCustomer.Text
                    sqlCommand.Parameters("@nama_customer").Value = TextBoxNamaCustomer.Text
                    sqlCommand.Parameters("@alamat_customer").Value = alamatCustomer.Text
                    sqlCommand.Parameters("@invoice_no").Value = oItem.Cells(0).Value
                    sqlCommand.Parameters("@sales_payment_no").Value = TextBoxSPNo.Text
                    sqlCommand.Parameters("@invoice_date").Value = CDate(oItem.Cells(1).Value)
                    sqlCommand.Parameters("@payment_date").Value = CDate(DateTimePickerPaymentDate.Value)
                    Dim owing As Long = oItem.Cells(3).Value
                    Dim totalOrder As Long = oItem.Cells(2).Value
                    Dim payment As Long = oItem.Cells(4).Value
                    owing = owing - payment
                    sqlCommand.Parameters("@total_order").Value = oItem.Cells(2).Value
                    sqlCommand.Parameters("@owing").Value = owing
                    sqlCommand.Parameters("@payment_amount").Value = oItem.Cells(4).Value
                    sqlCommand.Parameters("@notes").Value = TextBoxNotes.Text
                    sqlCommand.Parameters("@is_history").Value = 1
                    sqlCommand.ExecuteNonQuery()

                    'insert ke table bankbook
                    sql = "INSERT INTO bank_book(trx_date,cheque_no,source_no,description,bank_name,deposit,withdrawal,balance,reconcile_date,created_on) VALUES (@trx_date,@cheque_no,@source_no,@description,@bank_name,@deposit,@withdrawal,@balance,@reconcile_date,@created_on)"
                    sqlCommand.CommandText = sql
                    sqlCommand.Parameters("@trx_date").Value = CDate(oItem.Cells(1).Value)
                    sqlCommand.Parameters("@cheque_no").Value = Nothing
                    sqlCommand.Parameters("@source_no").Value = oItem.Cells(0).Value
                    sqlCommand.Parameters("@description").Value = "Sales Payment : " + oItem.Cells(0).Value + " for " + TextBoxNamaCustomer.Text
                    sqlCommand.Parameters("@bank_name").Value = CmbBank.SelectedValue
                    sqlCommand.Parameters("@deposit").Value = oItem.Cells(4).Value
                    sqlCommand.Parameters("@withdrawal").Value = 0
                    sqlCommand.Parameters("@balance").Value = oItem.Cells(4).Value
                    sqlCommand.Parameters("@reconcile_date").Value = Nothing
                    sqlCommand.Parameters("@created_on").Value = DateTime.Now
                    sqlCommand.ExecuteNonQuery()

                    If owing = 0 Then
                        ' update sales order header ubah status menjadi 2 karena sudah di received barang nya
                        sql = "UPDATE sales_invoice_header SET status_sales_invoice = 2 WHERE sales_invoice_no = @invoice_no"
                        sqlCommand.CommandText = sql
                        sqlCommand.Parameters("@invoice_no").Value = oItem.Cells(0).Value
                        'sqlCommand.ExecuteNonQuery()
                    End If



                Else
                    'MessageBox.Show("Pilih salah satu invoice!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    'Return 0
                End If
            Next

            If pilih <> 1 Then
                MessageBox.Show("Pilih salah satu invoice!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return 0
            End If



            transaction.Commit()
            con.Close()
            MessageBox.Show("Data has been saved", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return 1
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Try
                transaction.Rollback()
            Catch ex2 As Exception
                ' This catch block will handle any errors that may have occurred 
                ' on the server that would cause the rollback to fail, such as 
                ' a closed connection.
                Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType())
                Console.WriteLine("  Message: {0}", ex2.Message)
            End Try
        Finally
            con.Close()
        End Try
        Return rowEffected
    End Function

    Private Sub ButtonSaveClose_Click(sender As Object, e As EventArgs) Handles ButtonSaveClose.Click

        Dim temp As Integer = insertSP()
        If temp <> 0 Then
            'Me.Close()
            'closeForm(Me)
            refresh()
        End If

    End Sub

    Public Sub openForm(frmOpen As Form)
        frmOpen.MdiParent = Me
        frmOpen.Dock = DockStyle.Fill
        frmOpen.Show()
        frmOpen.Location = New Point(0, 0)
    End Sub
    Public Sub closeForm(frmOpen As Form)
        frmOpen.MdiParent = Me
        frmOpen.Dock = DockStyle.Fill
        frmOpen.Close()
        frmOpen.Location = New Point(0, 0)
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub ButtonSaveNew_Click(sender As Object, e As EventArgs) Handles ButtonSaveNew.Click

        Dim temp As Integer = insertSP()
        If temp <> 0 Then
            'clearAllFIeld()
            'inisialisasi()
            ' Me.idPrimary.Text = getPrimaryId().ToString
            refresh()
        End If

    End Sub

    Private Sub CmbBank_Click(sender As Object, e As EventArgs) Handles CmbBank.Click
        populateBank()
    End Sub
End Class