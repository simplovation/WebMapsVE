<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BingMapsKey.aspx.cs" Inherits="Basics_BingMapsKey" Title="Map Basics - Server-Side" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Map Basics - Bing Maps Key
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
This example demonstrates how to setup the map to use a Bing Maps Key for service authentication.<br />
<br />
For information on obtaining a Bing Maps Key, see the <a href="http://msdn.microsoft.com/en-us/library/ff428642.aspx" target="_blank">Getting a Bing Maps Key</a> article in MSDN.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<p>
Set the Map.BingKey property equal to your Bing Maps Key, and the control will use it when authenticating with the service.
</p>
<p>
<strong>Set Bing Maps Key</strong><br /><br />
&lt;Simplovation:Map runat="server" ID="Map1" BingKey="[Bing Maps Key Here]" /&gt;
</p>

<p>
<strong>Also, Handle Client-Side Authentication Events</strong><br /><br />
&lt;Simplovation:Map runat="server" ID="Map1"<br />
&nbsp;&nbsp;&nbsp;&nbsp;BingKey="[Bing Maps Key Here]"<br />
&nbsp;&nbsp;&nbsp;&nbsp;OnClientMapLoaded="Map1_Loaded" /&gt;
<br />
&lt;script type="text/javascript"&gt;<br />
&nbsp;&nbsp;&nbsp;&nbsp;function Map1_Loaded(sender) {<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//// Handle Client-Side Bing Maps API events for the credentials<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//sender.addHandler("oncredentialserror", function() { alert("invalid credentials"); });<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//sender.addHandler("oncredentialsvalid", function() { alert("credentials are valid"); });<br />
&nbsp;&nbsp;&nbsp;&nbsp;}<br />
&lt;/script&gt;
</p>

<%-- 
<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<Simplovation:Map runat="server" ID="Map1"
    BingKey="[Bing Maps Key Here]"
    OnClientMapLoaded="Map1_Loaded"
    Width="500px" Height="450px" CssClass="map" />

<script type="text/javascript">
    function Map1_Loaded(sender) {
        // Handle Client-Side Bing Maps API events for the credentials
        sender.addHandler("oncredentialserror", function() { alert("invalid credentials"); });
        sender.addHandler("oncredentialsvalid", function() { alert("credentials are valid"); });
    }
</script>
--%>

</asp:Content>

