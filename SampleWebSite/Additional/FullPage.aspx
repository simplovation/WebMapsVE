<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FullPage.aspx.cs" Inherits="Additional_FullPage" Title="Web.Maps.VE - Full Page Map" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

    <div id="divMapContainer" style="position: absolute; top: 0px; left: 0px; width: 100%; height: 100%;">
        <Simplovation:Map runat="server" ID="Map1" Width="100%" Height="100%" />
    </div>

    </div>
    </form>
</body>
</html>
