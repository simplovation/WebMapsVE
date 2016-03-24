<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoadBaseTiles.aspx.cs" Inherits="OtherProperties_Fixed" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Map Properties - LoadBaseTiles
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
A Boolean value indicating whether or not to load the base map tiles. The default value is True.
<br /><br />
This example page demonstrates setting LoadBaseTiles to False; turning off the display of the MS Virtual Earth Base Tiles.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" LoadBaseTiles="false" />

</asp:Content>

