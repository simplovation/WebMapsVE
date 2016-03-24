<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Fixed.aspx.cs" Inherits="OtherProperties_Fixed" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Map Properties - Fixed
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
Setting the Maps Fixed property to True restricts the map and doesn't allow the use to zoom in/out or scroll the map around. Use a fixed map when the user is going to print the map, or if you just don't want to offer any interactivity. This property can only be set on the initial load of the page, and cannot be changed on an Asynchronous Postback.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
 
<Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" Fixed="true" />

</asp:Content>

