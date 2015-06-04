Imports MySql.Data.MySqlClient

Public Class PurchasePayment
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
    Private Sub populateVendor()
        Dim sql As String
        Try
            ds = New DataSet()
            con = jokenconn()
            con.Open()
            sql = "select distinct b.cust_cd,b.cust_nm from clx_bill_prepaid a inner join clx_cust_mst b on a.cust_cd = b.cust_cd order by b.cust_nm"
            Logs.TraceLog("sqlQuery populateVendor = " & sql, System.Reflection.MethodBase.GetCurrentMethod.Name())
            da = New MySqlDataAdapter(sql, con)
            da.Fill(ds, "supplier")
            con.Close()
            CmbVendor.DataSource = ds.Tables(0)
            CmbVendor.ValueMember = "cust_cd"
            CmbVendor.DisplayMember = "cust_nm"
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
            Sql = "select id from purchase_payment order by id desc limit 0,1"
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
        Dim formNoSystem As String = "VP/" + day + "/" + month + "/" + year + "/" + seq.ToString
        TextBoxVpNo.Text = formNoSystem


        Me.DataGridViewVP.ColumnCount = 5
        Me.DataGridViewVP.Columns(0).Name = "Invoice No"
        Me.DataGridViewVP.Columns(1).Name = "Invoice Date"
        Me.DataGridViewVP.Columns(2).Name = "Total Order"
        Me.DataGridViewVP.Columns(3).Name = "Owing"
        Me.DataGridViewVP.Columns(4).Name = "Payment Amount"
        DataGridViewVP.Columns(0).ReadOnly = True
        DataGridViewVP.Columns(1).ReadOnly = True
        DataGridViewVP.Columns(2).ReadOnly = True
        DataGridViewVP.Columns(3).ReadOnly = True
        formatKolomNumeric()
    End Sub
    Private Sub PurchasePayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inisialisasi()
        CmbVendor.Focus()
        idPrimary.Text = getPrimaryId().ToString
        
    End Sub
    Private Sub formatKolomNumeric()
        DataGridViewVP.Columns("Total Order").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewVP.Columns("Owing").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewVP.Columns("Payment Amount").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewVP.Columns("Total Order").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewVP.Columns("Owing").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewVP.Columns("Payment Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub CmbVendor_Click(sender As Object, e As EventArgs) Handles CmbVendor.Click
        populateVendor()
    End Sub
    Private Function findSupplierByKode(kode As String) As Integer

        Dim db As Integer
        Dim sql As String
        Dim cmd As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            sql = "select distinct b.address1,b.address2,b.cust_cd,b.cust_nm from clx_bill_prepaid a inner join clx_cust_mst b on a.cust_cd = b.cust_cd where b.cust_cd ='" & kode & "'"
            Logs.TraceLog("sqlQuery findSupplierByKode = " & sql, System.Reflection.MethodBase.GetCurrentMethod.Name())
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            da.Fill(publictable)
            If publictable.Rows.Count > 0 Then
                alamatVendor.Text = publictable.Rows(0).Item(0) + " " + publictable.Rows(0).Item(1)
                TextBoxKodeSupplier.Text = publictable.Rows(0).Item(2)
                TextBoxNamaSupplier.Text = publictable.Rows(0).Item(3)
            End If
        Catch ex As MySqlException
            MessageBox.Show("error : " + ex.ToString)
        Finally
            con.Close()
        End Try
        Return db
    End Function

    Private Function findInvoiceBySupplierKode(kode As String) As Integer

        Dim db As Integer
        Dim sql As String
        Dim cmd As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            sql = "select ejn.invoice_no as invoice_no, ejn.job_dt as purchaseInvoiceDate,nq.total_amt as totalOrder,IFNULL(pp.owing,nq.total_amt)as owing, '0' as payment_amount From (select ej.job_no, ej.invoice_no, ej.job_dt, ej.cust_cd, ag.airline_cd, ej.pod_final from clx_entry_job ej, clx_aga01 ag where ag.job_no = ej.job_no and ag.slip_type = 'I') ejn inner join (SELECT seq, cbp.job_no, freight_cd, cust_kind, bill_dt, curr_cd, tax_cd, amt_tax, qty, exchange_rate, SUM(`amt_bill`)`amount`, SUM(qty * amt_bill)`total_amt` FROM lcm.clx_bill_prepaid cbp group by job_no) nq on ejn.job_no = nq.job_no inner join clx_cust_mst cm on ejn.cust_cd = cm.cust_cd left join purchase_payment pp on pp.invoice_no = ejn.invoice_no and pp.is_history = 1 WHERE cm.cust_cd = '" & kode & "' and (pp.owing IS NULL or pp.owing <> 0 ) ORDER  BY ejn.job_dt asc"
            Logs.TraceLog("sqlQuery findInvoiceBySupplierKode = " & sql, System.Reflection.MethodBase.GetCurrentMethod.Name())
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            da.Fill(publictable)
            If publictable.Rows.Count > 0 Then
                Dim row As String()
                If DataGridViewVP.Columns.Count = 6 Then
                    DataGridViewVP.Columns.RemoveAt(5)
                End If
                DataGridViewVP.Rows.Clear()
                DataGridViewVP.Refresh()
                For Each oRecord As Object In publictable.Rows
                    row = New String() {oRecord("invoice_no").ToString(), oRecord("purchaseInvoiceDate").ToString(), oRecord("totalOrder").ToString(), oRecord("owing").ToString(), oRecord("payment_amount").ToString()}
                    DataGridViewVP.Rows.Add(row)
                Next
                Dim chk As New DataGridViewCheckBoxColumn()
                DataGridViewVP.Columns.Add(chk)
                chk.HeaderText = "Pay"
                chk.Name = "pay"
                DataGridViewVP.Refresh()
            End If
        Catch ex As MySqlException
            MessageBox.Show("error : " + ex.ToString)
        Finally
            con.Close()
        End Try
        Return db
    End Function

    Private Sub CmbVendor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CmbVendor.SelectionChangeCommitted
        findSupplierByKode(CmbVendor.SelectedValue)
        findInvoiceBySupplierKode(CmbVendor.SelectedValue)
        For Each oItem As DataGridViewRow In DataGridViewVP.Rows
            oItem.Cells(2).Value = CLng(oItem.Cells(2).Value)
            oItem.Cells(3).Value = CLng(oItem.Cells(3).Value)
            oItem.Cells(4).Value = CLng(oItem.Cells(4).Value)
        Next
    End Sub

    Private Sub DataGridViewVP_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewVP.CellContentClick
        If e.ColumnIndex = 5 Then
            If e.RowIndex >= 0 Then
                TextBoxNotes.Focus()
                If DataGridViewVP.Rows(e.RowIndex).Cells(5).Value = True Then
                    DataGridViewVP.Rows(e.RowIndex).Cells(4).Value = DataGridViewVP.Rows(e.RowIndex).Cells(3).Value
                    'MessageBox.Show("Checked", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    DataGridViewVP.Rows(e.RowIndex).Cells(4).Value = "0"
                    'MessageBox.Show("UnChecked", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

    Private Sub DataGridViewVP_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewVP.CellEndEdit
        If e.ColumnIndex = 4 Then
            Dim iColumn As Integer = DataGridViewVP.CurrentCell.ColumnIndex
            Dim iRows As Integer = DataGridViewVP.CurrentCell.RowIndex
            DataGridViewVP.Rows(iRows).Cells(5).Value = True
            Dim payment As Long
            payment = DataGridViewVP.Rows(iRows).Cells(iColumn).Value
            Dim owing As Long
            owing = DataGridViewVP.Rows(iRows).Cells(3).Value
            If payment > owing Then
                MessageBox.Show("Pembayaran lebih besar dari pada owing", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                DataGridViewVP.Rows(iRows).Cells(iColumn).Value = owing
            End If
            DataGridViewVP.Rows(iRows).Cells(iColumn).Value = CLng(DataGridViewVP.Rows(iRows).Cells(iColumn).Value)

        End If
    End Sub

    Private Sub ButtonSaveNew_Click(sender As Object, e As EventArgs) Handles ButtonSaveNew.Click

        Dim temp As Integer = insertVP()
        If temp <> 0 Then
            'clearAllFIeld()
            'inisialisasi()
            'Me.idPrimary.Text = getPrimaryId().ToString
            refresh()
        End If
        
    End Sub
    Private Sub clearAllFIeld()
        TextBoxKodeSupplier.Text = ""
        TextBoxNamaSupplier.Text = ""
        alamatVendor.Text = ""
        TextBoxVpNo.Text = ""
        DataGridViewVP.Rows.Clear()
        TextBoxNotes.Text = ""
        CmbVendor.SelectedIndex = -1
    End Sub
    Private Function insertVP() As Integer
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
            If TextBoxVpNo.Text = "" Then
                MessageBox.Show("Purchase Payment No harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBoxVpNo.Focus()
                Return 0
            End If

            If CmbVendor.SelectedIndex = -1 Then
                MessageBox.Show("Vendor / Supplier harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbVendor.Focus()
                Return 0
            End If

            If DataGridViewVP.Rows.Count = 0 Then
                MessageBox.Show("Items harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return 0
            End If

            ' Insert VP Header
            'Dim session As Session = Login.getSession()
            'removeSeparatorBeforeInsert()
            sqlCommand.Connection = con
            sqlCommand.Transaction = transaction
            sqlCommand.Parameters.Add("@kode_supplier", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@nama_supplier", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@alamat_supplier", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@invoice_no", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@form_no_invoice", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@invoice_date", MySqlDbType.DateTime)
            sqlCommand.Parameters.Add("@payment_date", MySqlDbType.DateTime)
            sqlCommand.Parameters.Add("@form_no", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@total_order", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@owing", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@payment_amount", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@notes", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@is_history", MySqlDbType.Int16)
            For Each oItem As DataGridViewRow In DataGridViewVP.Rows
                If oItem.Cells(5).Value = True Then
                    pilih = 1
                    ' update purchase payment ubah is history menjadi 0 karena trx ini hanya sebagai history saja
                    sql = "UPDATE purchase_payment SET is_history = 0 WHERE form_no_invoice = @form_no_invoice"
                    sqlCommand.CommandText = sql
                    sqlCommand.Parameters("@form_no_invoice").Value = oItem.Cells(0).Value
                    sqlCommand.ExecuteNonQuery()

                    ' insert dengan is history menjadi 1
                    sql = "INSERT INTO purchase_payment(kode_supplier,nama_supplier,alamat_supplier,invoice_no,form_no_invoice,invoice_date,payment_date,form_no,total_order,owing,payment_amount,notes,is_history) VALUES (@kode_supplier,@nama_supplier,@alamat_supplier,@invoice_no,@form_no_invoice,@invoice_date,@payment_date,@form_no,@total_order,@owing,@payment_amount,@notes,@is_history)"
                    sqlCommand.CommandText = sql
                    'Dim PoNumber As String
                    'Dim RINumber As String
                    'If oItem.Cells(0).Value = "" Then
                    '    Continue For
                    'End If
                    sqlCommand.Parameters("@kode_supplier").Value = TextBoxKodeSupplier.Text
                    sqlCommand.Parameters("@nama_supplier").Value = TextBoxNamaSupplier.Text
                    sqlCommand.Parameters("@alamat_supplier").Value = alamatVendor.Text
                    sqlCommand.Parameters("@invoice_no").Value = oItem.Cells(0).Value
                    sqlCommand.Parameters("@form_no_invoice").Value = TextBoxVpNo.Text
                    sqlCommand.Parameters("@invoice_date").Value = CDate(oItem.Cells(1).Value)
                    sqlCommand.Parameters("@payment_date").Value = CDate(DateTimePickerPaymentDate.Value)
                    sqlCommand.Parameters("@form_no").Value = TextBoxVpNo.Text
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

                    If owing = 0 Then
                        ' update purchase order header ubah status menjadi 2 karena sudah di received barang nya
                        sql = "UPDATE purchase_invoice_header SET status_invoice = 2 WHERE form_no = @form_no_invoice"
                        sqlCommand.CommandText = sql
                        sqlCommand.Parameters("@form_no_invoice").Value = oItem.Cells(0).Value
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
            'rowEffected = sqlCommand.ExecuteNonQuery()
            'sqlCommand.CommandText = queryGetIdentity
            'Dim ID As Long
            'ID = sqlCommand.ExecuteScalar()
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

        Dim temp As Integer = insertVP()
        If temp <> 0 Then
            'Me.Close()
            refresh()
        End If

    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub refresh()
        'clearAllFIeld()
        DataGridViewVP.Rows.Clear()
        inisialisasi()
        Me.idPrimary.Text = getPrimaryId().ToString
        findSupplierByKode(CmbVendor.SelectedValue)
        findInvoiceBySupplierKode(CmbVendor.SelectedValue)
        For Each oItem As DataGridViewRow In DataGridViewVP.Rows
            oItem.Cells(2).Value = CLng(oItem.Cells(2).Value)
            oItem.Cells(3).Value = CLng(oItem.Cells(3).Value)
            oItem.Cells(4).Value = CLng(oItem.Cells(4).Value)
        Next
    End Sub

    Private Sub CmbBank_Click(sender As Object, e As EventArgs) Handles CmbBank.Click
        populateBank()
    End Sub
End Class