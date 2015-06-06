Imports MySql.Data.MySqlClient

Public Class ListGlAccount
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim ds As DataSet
    Public menuCalling As String
    Public Function jokenconn() As MySqlConnection
        'Return New MySqlConnection(connString)
        Dim urlDb As String
        Dim mySqlDb As New mySqlDB
        urlDb = mySqlDb.getUrlDatabase()
        Return New MySqlConnection(urlDb)
    End Function
    Private Sub ListGlAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BringToFront()
        inisialisasi()
        refreshGrid(Nothing, Nothing)
    End Sub
    Private Sub inisialisasi()

        Me.GridAccount.ColumnCount = 2
        Me.GridAccount.Columns(0).Name = "Account No"
        Me.GridAccount.Columns(1).Name = "Desc Account"
        GridAccount.Columns(0).ReadOnly = True
        GridAccount.Columns(1).ReadOnly = True
    End Sub
    Private Function refreshGrid(accNo As String, descAcc As String) As Integer
        Dim db As Integer
        Dim sql As String
        Dim cmd As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            sql = "select * from account where 1 = 1"

            If accNo <> "" Then
                sql = sql & " and no_acc like '" + accNo + "%'"
            End If
            If descAcc <> "" Then
                sql = sql & " and desc_acc like '" + descAcc + "%'"
            End If
            Logs.TraceLog("sqlQuery refreshGrid = " & sql, System.Reflection.MethodBase.GetCurrentMethod.Name())
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            da.Fill(publictable)
            GridAccount.Rows.Clear()
            GridAccount.Refresh()
            If publictable.Rows.Count > 0 Then
                Dim row As String()
                For Each oRecord As Object In publictable.Rows
                    row = New String() {oRecord("no_acc").ToString(), oRecord("desc_acc").ToString()}
                    GridAccount.Rows.Add(row)
                Next
            End If
        Catch ex As MySqlException
            MessageBox.Show("error : " + ex.ToString)
        Finally
            con.Close()
        End Try
        Return db
    End Function

    Private Sub filter_Click(sender As Object, e As EventArgs) Handles filter.Click
        refreshGrid(txtAccNo.Text, txtDescAcc.Text)
    End Sub

    Private Sub GridAccount_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridAccount.CellDoubleClick
        If menuCalling = "OtherDeposit" Then
            Dim rowIdx As Integer
            rowIdx = e.RowIndex
            OtherDeposit.addItemToListDep(GridAccount.Rows(rowIdx).Cells(0).Value, GridAccount.Rows(rowIdx).Cells(1).Value)
            Me.Close()
        ElseIf menuCalling = "OtherWithdrawal" Then
            Dim rowIdx As Integer
            rowIdx = e.RowIndex
            OtherDeposit.addItemToListDep(GridAccount.Rows(rowIdx).Cells(0).Value, GridAccount.Rows(rowIdx).Cells(1).Value)
            Me.Close()
        End If
    End Sub
End Class