﻿Imports MySql.Data.MySqlClient

Class mySqlDB
    'MySQL    
    Public conn As MySqlConnection
    Public Function getUrlDatabase() As String        
        'Return "Server=139.194.211.23;Port = 3306;Database=ims;Uid=root;Pwd=root;"
        Return "Server=127.0.0.1;Port = 3306;Database=lcm;Uid=root;Pwd=root;"
    End Function
    Public Function checkDB() As String
        Dim sReturn As String = ""        
        conn = New MySqlConnection
        Try
            conn.ConnectionString = getUrlDatabase()
            conn.Open()
            conn.Close()
            sReturn = "Database connected."
        Catch ex As Exception
            sReturn = "Failed to connect to Database.." & ": " & ex.Message
            If (conn.State = Data.ConnectionState.Open) Then
                conn.Close()
            End If
        End Try
        conn = Nothing
        Return sReturn
    End Function
    Public Function connectDB() As MySqlConnection       
        conn = New MySqlConnection
        Try
            conn.ConnectionString = getUrlDatabase()
            conn.Open()            
        Catch ex As Exception

        End Try       
        Return conn
    End Function
End Class
