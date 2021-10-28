Imports System.Data.SqlClient


Public Class TestWebForm2
    Inherits System.Web.UI.Page
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        con = New SqlConnection(Session("conString"))
        cmd = New SqlCommand("", con)
        showResult()
    End Sub
    Sub showResult()
        'show account reason
        Dim msg As String = ""
        cmd.CommandText = "Select [accReason] from [accountsTbl] where [accNumber]=" & getAccountNumber() & " and [accResult] is null"
        con.Open()
        Dim accReason As String = Convert.ToInt32(cmd.ExecuteScalar())
        con.Close()
        Select Case accReason
            Case 1
                msg += "Challenge #1"
            Case 2
                msg += "Challenge #2"
            Case 3
                msg += "Real Account"
        End Select

        cmd.CommandText = "Select accResult from accountsTbl where accNumber=" & getAccountNumber()
        con.Open()
        Dim Res As Object = cmd.ExecuteScalar()
        con.Close()
        If (Res Is DBNull.Value) Then
            'Challange in progress yet
            'get number of below 5%
            cmd.CommandText = "Select [accDailyDDcounter] from [accountsTbl] where [accNumber]=" & getAccountNumber() &
                       " and [accResult] is null"
            con.Open()
            Dim accDailyDDcounter As String = Convert.ToInt32(cmd.ExecuteScalar())
            con.Close()
            If (accDailyDDcounter <> 0) Then
                msg += "You are below 5% for daily calculation, minute# " & accDailyDDcounter & " of 1440"
            End If
        Else 'challange ends as it have a result
            Select Case Convert.ToInt32(Res)
                Case 10
                    msg += "Sorry you lost the challenge as DD whent below 10%"
                Case 5
                    msg += "Sorry you lost the challenge as DD whent below 5% for a day period"
                Case 1
                    msg += "Congratulations, you passed the challenge successfully !!"
            End Select
        End If
        Label1.Text = msg
    End Sub
    'functions
    Function getAccountNumber() As Integer
        Return 2104242490   'for now 2104242488 
    End Function




End Class