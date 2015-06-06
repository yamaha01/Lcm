Imports MySql.Data.MySqlClient

Public Class ListGlAccount
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection
    Dim ds As DataSet
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
        refreshGrid()
    End Sub
    Private Sub inisialisasi()

        Me.GridAccount.ColumnCount = 2
        Me.GridAccount.Columns(0).Name = "Account No"
        Me.GridAccount.Columns(1).Name = "Desc Account"
        GridAccount.Columns(0).ReadOnly = True
        GridAccount.Columns(1).ReadOnly = True
    End Sub
    Private Function refreshGrid() As Integer

        Dim db As Integer
        Dim sql As String
        Dim cmd As New MySqlCommand
        Dim publictable As New DataTable
        Try
            con = jokenconn()
            sql = "select * from account"
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
End Class