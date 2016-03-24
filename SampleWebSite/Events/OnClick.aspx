<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OnClick.aspx.cs" Inherits="Events_OnClick" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Map Events - OnClick
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
This sample demonstrates adding a Pushpin each time the user clicks a point on the map.<br />
a) Left-Click on the map to add a pushpin<br />
b) Left-Click on a pushpin to center the map on that pushpin<br />
c) Right-Click on a pushpin to remove that pushpin from the map
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" OnClick="Map1_OnClick" />

</asp:Content>

