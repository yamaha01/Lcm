Imports MySql.Data.MySqlClient

Public Class OtherWithdrawal
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim ds As DataSet
    Private rowIndex As Integer = 0
    Public Function jokenconn() As MySqlConnection
        Dim urlDb As String
        Dim mySqlDb As New mySqlDB
        urlDb = mySqlDb.getUrlDatabase()
        Return New MySqlConnection(urlDb)
    End Function
    Private Sub inisialisasi()
        Me.DataGridViewOtherWithdrawal.ColumnCount = 6
        Me.DataGridViewOtherWithdrawal.Columns(0).Name = "Account No"
        Me.DataGridViewOtherWithdrawal.Columns(1).Name = "Account Name"
        Me.DataGridViewOtherWithdrawal.Columns(2).Name = "Amount"
        Me.DataGridViewOtherWithdrawal.Columns(3).Name = "Memo"
        Me.DataGridViewOtherWithdrawal.Columns(4).Name = "Department"
        Me.DataGridViewOtherWithdrawal.Columns(5).Name = "Project"
        DataGridViewOtherWithdrawal.Columns(0).ReadOnly = True
        DataGridViewOtherWithdrawal.Columns(1).ReadOnly = True
        formatKolomNumeric()
        DataGridViewOtherWithdrawal.ClearSelection()
        Dim idx As Integer = DataGridViewOtherWithdrawal.RowCount
        idx = idx - 1
        If idx >= 0 Then
            DataGridViewOtherWithdrawal.Rows(idx).Cells(0).Selected = True
            DataGridViewOtherWithdrawal.CurrentCell = Me.DataGridViewOtherWithdrawal(0, idx)
            DataGridViewOtherWithdrawal.NotifyCurrentCellDirty(True)
        Else
            DataGridViewOtherWithdrawal.NotifyCurrentCellDirty(True)
        End If
        txtAmount.Text = 0
    End Sub
    Private Sub hitungTotalHarga(rowIdx As Integer)
        Dim amount As Long
        Dim totalAmount As Long
        amount = DataGridViewOtherWithdrawal.Rows(rowIdx).Cells(2).Value
        totalAmount = CLng(txtAmount.Text)
        totalAmount = totalAmount + amount
        txtAmount.Text = CStr(totalAmount)
    End Sub

    Private Sub formatKolomNumeric()
        DataGridViewOtherWithdrawal.Columns("Amount").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewOtherWithdrawal.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub OtherDeposit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inisialisasi()
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

    Private Sub CmbBank_Click(sender As Object, e As EventArgs) Handles CmbBank.Click
        populateBank()
    End Sub

    Private Sub ButtonSaveNew_Click(sender As Object, e As EventArgs) Handles ButtonSaveNew.Click
        insertWithdrawal()
    End Sub
    Private Sub clearAllFIeld()
        txtAmount.Text = "0"
        txtMemo.Text = ""
        TextBoxVoucherNo.Text = ""
        DataGridViewOtherWithdrawal.Rows.Clear()
        CmbBank.SelectedIndex = -1
        inisialisasi()
    End Sub
    Private Function insertWithdrawal() As Integer
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
            If CmbBank.SelectedIndex = -1 Then
                MessageBox.Show("Bank harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CmbBank.Focus()
                Return 0
            End If

            If TextBoxVoucherNo.Text = "" Then
                MessageBox.Show("Voucher No harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBoxVoucherNo.Focus()
                Return 0
            End If

            If txtAmount.Text = "" Then
                MessageBox.Show("Amount harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAmount.Focus()
                Return 0
            End If

            'If DataGridViewOtherDeposit.Rows.Count = 0 Then
            'MessageBox.Show("Detail harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'Return 0
            'End If

            ' Insert Other Deposit Header
            'Dim session As Session = Login.getSession()

            sqlCommand.Connection = con
            sqlCommand.Transaction = transaction
            sqlCommand.Parameters.Add("@bank_name", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@voucher_no", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@trx_date", MySqlDbType.DateTime)
            sqlCommand.Parameters.Add("@memo", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@amount", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@created_on", MySqlDbType.DateTime)
            'param detail
            sqlCommand.Parameters.Add("@header_id", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@acc_no", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@desc_acc", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@dep", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@proj", MySqlDbType.VarChar)
            'inisialisasi parameter bank book
            sqlCommand.Parameters.Add("@cheque_no", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@source_no", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@description", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@deposit", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@withdrawal", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@balance", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@reconcile_date", MySqlDbType.DateTime)


            ' insert header
            sql = "INSERT INTO other_withdrawal_header(bank_name,voucher_no,trx_date,memo,amount,created_on) VALUES (@bank_name,@voucher_no,@trx_date,@memo,@amount,@created_on)"
            sqlCommand.CommandText = sql
            sqlCommand.Parameters("@bank_name").Value = CmbBank.SelectedValue
            sqlCommand.Parameters("@voucher_no").Value = TextBoxVoucherNo.Text
            sqlCommand.Parameters("@trx_date").Value = CDate(DtDepositDate.Value)
            sqlCommand.Parameters("@memo").Value = txtMemo.Text
            Dim temp As String
            temp = txtAmount.Text
            temp = temp.Replace(",", "")
            sqlCommand.Parameters("@amount").Value = temp
            sqlCommand.Parameters("@created_on").Value = DateTime.Now
            sqlCommand.ExecuteNonQuery()
            sqlCommand.CommandText = queryGetIdentity
            Dim ID As Long
            ID = sqlCommand.ExecuteScalar()

            'dapetin balance
            sql = "select IFNULL(balance,0) as balance from bank_book WHERE bank_name = @bank_name order by id desc limit 0,1"
            sqlCommand.CommandText = sql
            sqlCommand.Parameters("@bank_name").Value = CmbBank.SelectedValue
            Dim balance As Long = sqlCommand.ExecuteScalar()
            Dim balanceInput As Long
            balanceInput = balance - CLng(temp)

            'insert ke table bankbook
            sql = "INSERT INTO bank_book(trx_date,cheque_no,source_no,description,bank_name,deposit,withdrawal,balance,reconcile_date,created_on) VALUES (@trx_date,@cheque_no,@source_no,@description,@bank_name,@deposit,@withdrawal,@balance,@reconcile_date,@created_on)"
            sqlCommand.CommandText = sql
            sqlCommand.Parameters("@trx_date").Value = DateTime.Now
            sqlCommand.Parameters("@cheque_no").Value = Nothing
            sqlCommand.Parameters("@source_no").Value = TextBoxVoucherNo.Text
            sqlCommand.Parameters("@description").Value = "Other Payment : " + CmbBank.SelectedValue + " for " + TextBoxVoucherNo.Text
            sqlCommand.Parameters("@bank_name").Value = CmbBank.SelectedValue
            sqlCommand.Parameters("@deposit").Value = 0
            sqlCommand.Parameters("@withdrawal").Value = temp
            sqlCommand.Parameters("@balance").Value = balanceInput
            sqlCommand.Parameters("@reconcile_date").Value = Nothing
            sqlCommand.Parameters("@created_on").Value = DateTime.Now
            sqlCommand.ExecuteNonQuery()

            For Each oItem As DataGridViewRow In DataGridViewOtherWithdrawal.Rows
                ' Insert Detail
                If oItem.Cells(0).Value = "" Then
                    Continue For
                End If
                sql = "INSERT INTO other_withdrawal_detail(header_id,account_no,account_name,amount,memo,department,project,created_on) VALUES (@header_id,@acc_no,@desc_acc,@amount,@memo,@dep,@proj,@created_on)"
                sqlCommand.CommandText = sql
                sqlCommand.Parameters("@header_id").Value = ID
                sqlCommand.Parameters("@acc_no").Value = oItem.Cells(0).Value
                sqlCommand.Parameters("@desc_acc").Value = oItem.Cells(1).Value
                sqlCommand.Parameters("@amount").Value = oItem.Cells(2).Value
                sqlCommand.Parameters("@memo").Value = oItem.Cells(3).Value
                sqlCommand.Parameters("@dep").Value = oItem.Cells(4).Value
                sqlCommand.Parameters("@proj").Value = oItem.Cells(5).Value
                sqlCommand.Parameters("@created_on").Value = DateTime.Now
                sqlCommand.ExecuteNonQuery()
            Next
            transaction.Commit()
            con.Close()
            MessageBox.Show("Data has been saved", "Info Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            clearAllFIeld()
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
    Public Sub addItemToListWith(noAcc As String, descAcc As String)
        Dim idx As Integer = DataGridViewOtherWithdrawal.RowCount
        idx = idx - 1
        If idx < 0 Then
            MessageBox.Show("Please add row first before add items.")
            Return
        End If
        DataGridViewOtherWithdrawal.Rows(idx).Cells(2).Selected = True
        DataGridViewOtherWithdrawal.CurrentCell = Me.DataGridViewOtherWithdrawal(2, idx)
        DataGridViewOtherWithdrawal.BeginEdit(True)
        'DataGridViewPO.EndEdit()

        DataGridViewOtherWithdrawal.Rows(idx).Cells(0).Value = noAcc
        DataGridViewOtherWithdrawal.Rows(idx).Cells(1).Value = descAcc

        DataGridViewOtherWithdrawal.Rows(idx).Cells(0).ReadOnly = True
        DataGridViewOtherWithdrawal.Rows(idx).Cells(1).ReadOnly = True
    End Sub

    Private Sub removeSeparator(txtBox As TextBox)
        Dim temp As String
        temp = txtBox.Text
        temp = temp.Replace(",", "")
        txtBox.Text = temp
    End Sub

    Private Sub removeSeparatorBeforeInsert()
        removeSeparator(txtAmount)
    End Sub

    Private Sub txtAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAmount.Text = FormatNumber(txtAmount.Text.ToString, 0, TriState.True)
            txtAmount.SelectAll()
        End If
    End Sub

    Private Sub txtAmount_Leave(sender As Object, e As EventArgs) Handles txtAmount.Leave
        txtAmount.Text = FormatNumber(txtAmount.Text.ToString, 0, TriState.True)
    End Sub

    Private Sub DataGridViewOtherDeposit_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewOtherWithdrawal.CellDoubleClick
        If e.ColumnIndex = 0 Then
            ListGlAccount.menuCalling = "OtherWithdrawal"
            ListGlAccount.Show()
        End If
    End Sub

    Private Sub DataGridViewOtherDeposit_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewOtherWithdrawal.CellEndEdit
        If e.ColumnIndex = 0 Then
            ListGlAccount.menuCalling = "OtherWithdrawal"
            ListGlAccount.Show()
        ElseIf e.ColumnIndex = 2 Then

            hitungTotalHarga(e.RowIndex)
            formatKolomNumeric()
        End If
    End Sub

    Private Sub DataGridViewOtherDeposit_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridViewOtherWithdrawal.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Me.rowIndex = e.RowIndex
            Me.ContextMenuStrip1.Show(Me.DataGridViewOtherWithdrawal, e.Location)
            ContextMenuStrip1.Show(Cursor.Position)
        End If
    End Sub

    Private Sub ToolStripMenuItemDeleteRows_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            If Not Me.DataGridViewOtherWithdrawal.Rows(Me.rowIndex).IsNewRow Then
                Me.DataGridViewOtherWithdrawal.Rows.RemoveAt(Me.rowIndex)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ToolStripMenuItemAddRows_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click

    End Sub


    Private Sub DataGridViewOtherDeposit_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridViewOtherWithdrawal.EditingControlShowing
        e.CellStyle.BackColor = Color.Aquamarine
    End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged
        txtAmount.Text = FormatNumber(txtAmount.Text.ToString, 0, TriState.True)
    End Sub
End Class