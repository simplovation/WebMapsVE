<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="ContentPageTitle" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">Default Map</asp:Content>
<asp:Content ID="ContentPageDescription" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
    This is the default map with only the Height (450px), Width (700px) and CssClass (applies the gray border) properties set. Everything else is all still set to the default values.
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" BingKey="test" />

</asp:Content>

