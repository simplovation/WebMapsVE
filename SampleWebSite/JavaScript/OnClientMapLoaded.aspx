<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OnClientMapLoaded.aspx.cs" Inherits="JavaScript_OnClientMapLoaded" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Advanced JavaScript - OnClientMapLoaded Property
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
The Map's OnClientMapLoaded property allows you to specify the JavaScript method you want to be called when the map has finished loading on the client.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" OnClientMapLoaded="ClientMapLoaded" />

<script type="text/javascript">
    function ClientMapLoaded(sender)
    {
        //The sender parameter gets passed the instance of the Map that has finished loading.
        alert("Map has finished loading");
    }
</script>

</asp:Content>

