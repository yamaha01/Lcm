Imports MySql.Data.MySqlClient

Public Class BankBook
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim ds As DataSet
    Public Function jokenconn() As MySqlConnection
        Dim urlDb As String
        Dim mySqlDb As New mySqlDB
        urlDb = mySqlDb.getUrlDatabase()
        Return New MySqlConnection(urlDb)
    End Function
    Private Sub inisialisasi()
        Me.DataGridViewBankBook.ColumnCount = 9
        Me.DataGridViewBankBook.Columns(0).Name = "Date"
        Me.DataGridViewBankBook.Columns(1).Name = "Source No"
        Me.DataGridViewBankBook.Columns(2).Name = "Cheque No"
        Me.DataGridViewBankBook.Columns(3).Name = "Description"
        Me.DataGridViewBankBook.Columns(4).Name = "Deposit"
        Me.DataGridViewBankBook.Columns(5).Name = "Withdrawal"
        Me.DataGridViewBankBook.Columns(6).Name = "Balance"
        Me.DataGridViewBankBook.Columns(7).Name = "Reconciled"
        Me.DataGridViewBankBook.Columns(8).Name = "CreatedOn"
        DataGridViewBankBook.Columns(0).ReadOnly = True
        DataGridViewBankBook.Columns(1).ReadOnly = True
        DataGridViewBankBook.Columns(2).ReadOnly = True
        DataGridViewBankBook.Columns(3).ReadOnly = True
        DataGridViewBankBook.Columns(4).ReadOnly = True
        DataGridViewBankBook.Columns(5).ReadOnly = True
        DataGridViewBankBook.Columns(6).ReadOnly = True
        DataGridViewBankBook.Columns(7).ReadOnly = True
        DataGridViewBankBook.Columns(8).ReadOnly = True
        formatKolomNumeric()
    End Sub
    Private Sub formatKolomNumeric()
        DataGridViewBankBook.Columns("Deposit").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewBankBook.Columns("Withdrawal").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewBankBook.Columns("Balance").DefaultCellStyle.Format = "N0" ' N(zero) for no digits to the right of 
        DataGridViewBankBook.Columns("Deposit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewBankBook.Columns("Withdrawal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewBankBook.Columns("Balance").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub
    Private Sub populateBank()
        Dim sql As String
        Try
            ds = New DataSet()
            Dim defaultdata As DataTable = New DataTable("bank")
            defaultdata.Columns.Add("bank_id")
            defaultdata.Columns.Add("bank_nm")
            defaultdata.Rows.Add("-1", "All")
            ds.Tables.Add(defaultdata)
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

    Private Function findBankBookByParam() As Integer
        Dim startDate As DateTime = DtFrom.Value
        Dim endDate As DateTime = DtTo.Value
        Me.DtFrom.Value = New Date(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0)
        Me.DtTo.Value = New Date(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59)
        Dim db As Integer
        Dim sql As String
        Dim cmd As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            sql = "select bb.trx_date, bb.cheque_no,bb.source_no,bb.description,bb.bank_name,bb.deposit,bb.withdrawal,bb.balance, bb.reconcile_date,bb.created_on from bank_book bb where 1 = 1"
            If CmbBank.SelectedValue <> "All" Then
                sql = sql + " and bb.bank_name = '" & CmbBank.SelectedValue & "'"
            End If
            sql = sql + " and bb.created_on BETWEEN @startDate AND @endDate"
            Logs.TraceLog("sqlQuery findBankBookByParam = " & sql, System.Reflection.MethodBase.GetCurrentMethod.Name())
            cmd.Connection = con
            cmd.CommandText = sql
            cmd.Parameters.AddWithValue("@startDate", DtFrom.Value)
            cmd.Parameters.AddWithValue("@endDate", DtTo.Value)
            da.SelectCommand = cmd
            da.Fill(publictable)
            DataGridViewBankBook.Rows.Clear()
            DataGridViewBankBook.Refresh()
            If publictable.Rows.Count > 0 Then
                Dim row As String()
                For Each oRecord As Object In publictable.Rows
                    row = New String() {oRecord("trx_date").ToString(), oRecord("source_no").ToString(), oRecord("cheque_no").ToString(), oRecord("description").ToString(), oRecord("deposit").ToString(), oRecord("withdrawal").ToString(), oRecord("balance").ToString(), oRecord("reconcile_date").ToString(), oRecord("created_on").ToString()}
                    DataGridViewBankBook.Rows.Add(row)
                Next
                For Each oItem As DataGridViewRow In DataGridViewBankBook.Rows
                    oItem.Cells(4).Value = CLng(oItem.Cells(4).Value)
                    oItem.Cells(5).Value = CLng(oItem.Cells(5).Value)
                    oItem.Cells(6).Value = CLng(oItem.Cells(6).Value)
                Next
            End If
        Catch ex As MySqlException
            MessageBox.Show("error : " + ex.ToString)
        Finally
            con.Close()
        End Try
        Return db
    End Function

    Private Sub CmbBank_Click(sender As Object, e As EventArgs) Handles CmbBank.Click
        populateBank()
    End Sub

    Private Sub BankBook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inisialisasi()
    End Sub

    Private Sub ButtonRefresh_Click(sender As Object, e As EventArgs) Handles ButtonRefresh.Click
        If CmbBank.SelectedIndex = -1 Then
            MessageBox.Show("Bank harus diisi!.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CmbBank.Focus()
        Else
            findBankBookByParam()
        End If
    End Sub
End Class