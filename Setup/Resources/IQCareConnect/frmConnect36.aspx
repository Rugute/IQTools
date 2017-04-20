<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmConnect36.aspx.cs" Inherits="frmConnect36"
    EnableViewState="true"  %>


<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html lang="en-US" xml:lang="en-US" xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>International Quality Care Patient Management and Monitoring System</title>
    <link rel="stylesheet" type="text/css" href="Style/styles.css" />
   
</head>
<script language="javascript" type="text/javascript">

    function fnHelp() {
        var path = frmLogin.CallHelp().value;
        window.location.href = path;
        //window.showHelp("./IQCareHelp/IQCareARUserManualSep2010.chm")
    }
    function CloseWindow() {
        window.focus();
    }
    function openHelp() {
        var path = '/IQCareHelp/index.html';
        if (window.location.href.toLowerCase().indexOf("iqcare") > -1) {
            path = '/IQCare' + path;
        }
        window.open(path);
    }
</script>
<body>
   
</body>
</html>