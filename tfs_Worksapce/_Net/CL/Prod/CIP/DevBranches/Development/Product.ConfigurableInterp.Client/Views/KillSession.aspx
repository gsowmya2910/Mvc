<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KillSession.aspx.cs" Inherits="Product.ConfigurableInterp.Client.Views.KillSession" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>CoreLink - Configurable Interp</title>
    <script src="<%=VirtualPathUtility.ToAbsolute("~/Scripts")%>/jquery-1.10.2.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('#refresh').click(function () {
                $(this).attr('href', 'Account/LogOn?Region=' + $('#RegionCode').val());
            });
        });
    </script>
</head>
<body>
    <form id="Main" runat="server" target="_top">
    <asp:HiddenField ID="RegionCode" runat="server" />
    <p align="center">
        <img alt="" src="Content/Images/exhausted.jpg" width="70" height="70" />
        &nbsp;
        <font size="5">The Application has gone to sleep!</font>
    </p>
    <p align="center">
        The web server has not heard from you lately. In order to protect the integrity and security of your data, we have discontinued your application.
        <br />
        Please <a href="#" id="refresh" target="_top"><font size="4">click here</font></a> to start the current application over.
    </p>
    <hr />
    <p>
        <font size="5"><strong >Note:</strong> </font>
        <font size="4">You may have also gotten this error if you used a bookmark to navigate to this application.</font></p>
    </form>
</body>
</html>