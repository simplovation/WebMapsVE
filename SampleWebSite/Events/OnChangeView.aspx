<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OnChangeView.aspx.cs" Inherits="Events_OnChangeView" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Map Events - OnChangeView
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
This event is raised when ever the map view is changed. For example, both zooming and panning the map will raise this event.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
<asp:UpdatePanel runat="server" ID="UpdatePanel_MapViewDisplay">
    <ContentTemplate>
        Zoom: <asp:Literal runat="server" ID="litMapZoom"></asp:Literal><br />
        Center Latitude: <asp:Literal runat="server" ID="litMapLatitude"></asp:Literal><br />
        Center Longitude: <asp:Literal runat="server" ID="litMapLongitude"></asp:Literal>
    </ContentTemplate>
</asp:UpdatePanel>
<Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" OnChangeView="Map1_ChangeView" />

</asp:Content>

