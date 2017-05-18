<%@ Page Language="C#"  %>

<%@ OutputCache Location="None" VaryByParam="None" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<!--
 This will refresh the IIS timer 2 minutes before session timeout
-->
<meta http-equiv="refresh" content="<%=(Session.Timeout - 2) * 60 %>" /> 
</head>
</html>