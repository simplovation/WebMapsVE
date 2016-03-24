<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager runat="server" ID="sm1"></asp:ScriptManager>
        <Simplovation:Map runat="server" ID="Map1" BingKey="AqhAh5p8XpV4EhCYI8c98JnXxSLLbv3vqVkbg7JpZUlwhoMkVpBVqslfUc7W4Bhv" OnClientMapLoaded="Map1_Loaded"></Simplovation:Map>
    
        <script type="text/javascript">
            function Map1_Loaded(sender) {
                sender.addHandler("oncredentialserror", function() { alert("invalid credentials"); });
                sender.addHandler("oncredentialsvalid", function() { alert("credentials are valid"); });
            }
        </script>
    </div>
    </form>
</body>
</html>
