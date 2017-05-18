<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowStatus.aspx.cs" Inherits="Product.ConfigurableInterp.Client.Views.ShowStatus" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Debug</title>
    <style>
        body {
            background-color: linen;
        }

        h4 {
            color: maroon;
            padding-bottom:0;
            margin-bottom: 0;
        } 
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h4 runat="server" id="currentUserDisplay">Welcome:n/a</h4>
        <h4>Roles:</h4> 
        <asp:BulletedList ID="RolesBulletedList" runat="server">
        </asp:BulletedList>

        <br />
        <h4>Application</h4>
        <asp:GridView ID="ApplicationGridView" runat="server" HeaderStyle-BackColor="Gainsboro" BorderStyle="Solid" BorderColor="Black" EnableViewState="false" >
        </asp:GridView>

        <br />
        <h4>Session</h4>
        <asp:GridView ID="SessionGridView" runat="server" HeaderStyle-BackColor="Gainsboro" BorderStyle="Solid" BorderColor="Black" EnableViewState="false" >
        </asp:GridView>
        
        <br />
        <h4>Request.ServerVariables</h4>
        <asp:GridView ID="ServerVariablesGridView" runat="server" HeaderStyle-BackColor="Gainsboro" BorderStyle="Solid" BorderColor="Black" EnableViewState="false" >
        </asp:GridView>

        <br />
        <h4>Request.Form Variables</h4>
        <asp:GridView ID="RequestFormGridView" runat="server" HeaderStyle-BackColor="Gainsboro" BorderStyle="Solid" BorderColor="Black" EnableViewState="false" >
        </asp:GridView>
        
        <br />
        <h4>Request.QueryString Variables</h4>
        <asp:GridView ID="RequestQueryStringGridView" runat="server" HeaderStyle-BackColor="Gainsboro" BorderStyle="Solid" BorderColor="Black" EnableViewState="false" >
        </asp:GridView>
        
        
    </div>
    </form>
</body>
</html>