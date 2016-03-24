<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EnableBirdseye.aspx.cs" Inherits="OtherProperties_Fixed" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Map Properties - EnableBirdseye
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
A Boolean value that specifies whether or not to enable the Birdseye map style in the map control. The default value is True.
<br /><br />
This example page demonstrates setting EnableBirdseye to False; turning off birdseye from being available to the user.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" EnableBirdseye="false" Latitude="43.0548408795765" Longitude="-87.945556640625" Zoom="10" />

</asp:Content>

