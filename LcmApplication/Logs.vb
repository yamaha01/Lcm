Imports System.IO
Imports System

Public Class Logs

    Public Shared Function GetAppPath() As String
        Dim path As String
        path = System.IO.Path.GetDirectoryName( _
           System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        path = path.Substring(6)
        Return path
    End Function


    Public Shared Sub TraceLog(logMessage As String, callingMethod As String)
        'Using w As StreamWriter = File.AppendText(GetAppPath() + "\trace.log")
        '    w.Write(vbCrLf + "Log Entry : ")
        '    w.WriteLine("{0} {1} -------------------{2}", DateTime.Now.ToLongTimeString(), _
        '        DateTime.Now.ToLongDateString(), logMessage)
        'End Using
        Dim strFile As String = String.Format(GetAppPath() + "\trace.log", DateTime.Today.ToString("dd-MMM-yyyy"))
        File.AppendAllText(strFile, String.Format("{0} Debug [{1}] {2}{3}", _
                DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff tt"), callingMethod, logMessage, Environment.NewLine))

    End Sub

    Public Shared Sub DumpLog(r As StreamReader)
        Dim line As String
        line = r.ReadLine()
        While Not (line Is Nothing)
            Console.WriteLine(line)
            line = r.ReadLine()
        End While
    End Sub

End Class
