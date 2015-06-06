﻿Imports MySql.Data.MySqlClient

Public Class OtherDeposit
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
        Me.DataGridViewOtherDeposit.ColumnCount = 6
        Me.DataGridViewOtherDeposit.Columns(0).Name = "Account No"
        Me.DataGridViewOtherDeposit.Columns(1).Name = "Account Name"
        Me.DataGridViewOtherDeposit.Columns(2).Name = "Amount"
        Me.DataGridViewOtherDeposit.Columns(3).Name = "Memo"
        Me.DataGridViewOtherDeposit.Columns(4).Name = "Department"
        Me.DataGridViewOtherDeposit.Columns(5).Name = "Project"
        DataGridViewOtherDeposit.Columns(0).ReadOnly = True
        DataGridViewOtherDeposit.Columns(1).ReadOnly = True
        DataGridViewOtherDeposit.Columns(2).ReadOnly = True
        DataGridViewOtherDeposit.Columns(3).ReadOnly = True
        DataGridViewOtherDeposit.Columns(4).ReadOnly = True
        DataGridViewOtherDeposit.Columns(5).ReadOnly = True
        formatKolomNumeric()
        DataGridViewOtherDeposit.ClearSelection()
        Dim idx As Integer = DataGridViewOtherDeposit.RowCount
        idx = idx - 1
        If idx >= 0 Then
            DataGridViewOtherDeposit.Rows(idx).Cells(0).Selected = True
            DataGridViewOtherDeposit.CurrentCell = Me.DataGridViewOtherDeposit(0, idx)
            DataGridViewOtherDeposit.NotifyCurrentCellDirty(True)
        Else
            DataGridViewOtherDeposit.NotifyCurrentCellDirty(True)
        End If
    End Sub

    Private Sub formatKolomNumeric()
        DataGridViewOtherDeposit.Columns("Amount").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewOtherDeposit.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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
        insertDeposit()
    End Sub

    Private Function insertDeposit() As Integer
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
            removeSeparatorBeforeInsert()
            sqlCommand.Connection = con
            sqlCommand.Transaction = transaction
            sqlCommand.Parameters.Add("@bank_name", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@voucher_no", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@trx_date", MySqlDbType.DateTime)
            sqlCommand.Parameters.Add("@memo", MySqlDbType.VarChar)
            sqlCommand.Parameters.Add("@amount", MySqlDbType.Int64)
            sqlCommand.Parameters.Add("@created_on", MySqlDbType.DateTime)
            ' insert header
            sql = "INSERT INTO other_deposit_header(bank_name,voucher_no,trx_date,memo,amount,created_on) VALUES (@bank_name,@voucher_no,@trx_date,@memo,@amount,@created_on)"
            sqlCommand.CommandText = sql
            sqlCommand.Parameters("@bank_name").Value = CmbBank.SelectedValue
            sqlCommand.Parameters("@voucher_no").Value = TextBoxVoucherNo.Text
            sqlCommand.Parameters("@trx_date").Value = CDate(DtDepositDate.Value)
            sqlCommand.Parameters("@memo").Value = txtMemo.Text
            sqlCommand.Parameters("@amount").Value = txtAmount.Text
            sqlCommand.Parameters("@created_on").Value = DateTime.Now
            sqlCommand.ExecuteNonQuery()
            sqlCommand.CommandText = queryGetIdentity
            Dim ID As Long
            ID = sqlCommand.ExecuteScalar()
            For Each oItem As DataGridViewRow In DataGridViewOtherDeposit.Rows
                ' Insert Detail

            Next
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

    Private Sub DataGridViewOtherDeposit_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewOtherDeposit.CellDoubleClick
        If e.ColumnIndex = 0 Then
            ListGlAccount.Show()
        End If
    End Sub

    Private Sub DataGridViewOtherDeposit_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridViewOtherDeposit.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Me.rowIndex = e.RowIndex
            Me.ContextMenuStrip1.Show(Me.DataGridViewOtherDeposit, e.Location)
            ContextMenuStrip1.Show(Cursor.Position)
        End If
    End Sub

    Private Sub ToolStripMenuItemDeleteRows_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            If Not Me.DataGridViewOtherDeposit.Rows(Me.rowIndex).IsNewRow Then
                Me.DataGridViewOtherDeposit.Rows.RemoveAt(Me.rowIndex)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ToolStripMenuItemAddRows_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        DataGridViewOtherDeposit.ClearSelection()
        Dim idx As Integer = DataGridViewOtherDeposit.RowCount
        idx = idx - 1
        If idx >= 0 Then
            DataGridViewOtherDeposit.Rows(idx).Cells(0).Selected = True
            DataGridViewOtherDeposit.CurrentCell = Me.DataGridViewOtherDeposit(0, idx)
            DataGridViewOtherDeposit.NotifyCurrentCellDirty(True)
        Else
            DataGridViewOtherDeposit.NotifyCurrentCellDirty(True)
        End If
    End Sub

    
End Class