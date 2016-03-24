<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GeoRSS.aspx.cs" Inherits="ImportShapeLayerData_GeoRSS" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
ImportShapeLayerData - Add GeoRSS Layer
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
This example demonstrates how to use the Map.ImportShapeLayerData method to import GeoRSS data to the map.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
 
<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<asp:UpdatePanel runat="server" ID="up1">
    <ContentTemplate>
        <asp:Label runat="server" ID="lblMessage"></asp:Label>
    </ContentTemplate>
</asp:UpdatePanel>

<Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" />

</asp:Content>

