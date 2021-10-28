<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TestWebForm1.aspx.vb" Inherits="WebApplication1.TestWebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MT Status</title>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server">  
    </asp:ScriptManager> 
        <div>Status Test</div>
         <div>  
  <%--      Page Time:  
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>  --%>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">  
            <ContentTemplate> 
                  Result:  
                <asp:Label ID="LabelResult" runat="server" Text=""></asp:Label>  
                <br />  
                  Test:  
                <asp:Label ID="LabelTest" runat="server" Text=""></asp:Label>  
                <br />  
                Time:  
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>  
                <br />  
                  Starting Balance:  
                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>  
                <br />  
                  Equity:  
                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>  
                <br />  
                  DD%:  
                <asp:Label ID="Label5" runat="server" Text=""></asp:Label>  
                <br />  
                <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />  
                <asp:Timer ID="Timer1" runat="server" Interval="60000" OnTick="Timer1_Tick">  
                </asp:Timer>  
            </ContentTemplate>  
        </asp:UpdatePanel>  
    </div>  
    </form>
</body>
</html>
