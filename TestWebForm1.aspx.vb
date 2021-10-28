Imports System.Data.SqlClient
Imports System.IO

Public Class TestWebForm1
    Inherits System.Web.UI.Page
    Dim Data As String
    Dim con As SqlConnection ' New SqlConnection(Session("conString"))
    Dim cmd As SqlCommand 'New SqlCommand("", con)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        con = New SqlConnection(Session("conString"))
        cmd = New SqlCommand("", con)

        Data = getData()
        If Not IsPostBack Then
            ' Label1.Text = getData() ' DateTime.Now.ToString()
            Label2.Text = getData() ' DateTime.Now.ToString()
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '  Label1.Text = getData() ' DateTime.Now.ToString()
        'Label2.Text = Data ' DateTime.Now.ToString()
        Label2.Text = DateTime.Now.ToString()
        Label3.Text = getStartingBalance().ToString()
        Label4.Text = getEquity().ToString()
        Label5.Text = ddPer(getStartingBalance(), getEquity()).ToString() + " %"


        'cmd.CommandText = "select userName from [dbo].[usersTbl]"
        'con.Open()
        'LabelTest.Text = cmd.ExecuteScalar()
        'con.Close()

    End Sub
    Protected Sub Timer1_Tick(sender As Object, e As EventArgs)
        ' Label1.Text = getData() ' DateTime.Now.ToString()
        Data = getData()
        'Label2.Text = DateTime.Now.ToString() + ":     " + Data
        Label2.Text = DateTime.Now.ToString()
        Label3.Text = getStartingBalance().ToString()
        Label4.Text = getEquity().ToString()
        Label5.Text = ddPer(getStartingBalance(), getEquity()).ToString() + " %"
        If (ddPer(getStartingBalance(), getEquity()) < -10) Then
            'set failed result to DB as account DD is less than  10%
            cmd.CommandText = "UPDATE [dbo].[accountsTbl]  SET  [accResult] = 10 WHERE  accNumber=" + getActiveAccountForCurUser()
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            LabelResult.Text = "You failed as account DD exceeds 10%"
        End If
        If (ddPer(getStartingBalance(), getEquity()) < -5) Then

        End If
    End Sub
    Function getActiveAccountForCurUser() As String
        cmd.CommandText = "select [accNumber] from [accountsTbl] where [accNumber] =( select [accNumber] from [dbo].[usersTbl] where [userName]='" + Session("userName") + "')  and [accResult] is null"
        con.Open()
        Dim res As String
        Dim resObj As Object
        resObj = cmd.ExecuteScalar()
        If resObj Is Nothing Then
            res = "0"
        Else
            res = resObj.ToString
        End If

        con.Close()
        Return res
    End Function

    Function getData() As String
        Dim accNumber As String = Session("AccountNumber") '"2104242488"
        Return System.IO.File.ReadAllText(Server.MapPath("~/App_Data/" + accNumber + "_challengeMonitor.txt"))
    End Function
    Function ddPer(startingBalance As Double, equity As Double) As Double
        Return ((equity - startingBalance) / startingBalance) * 100
    End Function
    Function getStartingBalance() As Double
        Return Convert.ToDouble(Split(Data, ",")(1))
    End Function
    Function getEquity() As Double
        Return Convert.ToDouble(Split(Data, ",")(4))
    End Function
End Class