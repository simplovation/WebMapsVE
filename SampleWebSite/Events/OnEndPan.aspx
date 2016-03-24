<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OnEndPan.aspx.cs" Inherits="Events_OnEndPan" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Map Events - OnEndPan
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
This event is basically fired when ever the map is moved. Just scroll the map around to trigger this event.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
<asp:UpdatePanel runat="server" ID="UpdatePanel_MapViewDisplay">
    <ContentTemplate>
        Center Latitude: <asp:Literal runat="server" ID="litMapLatitude"></asp:Literal><br />
        Center Longitude: <asp:Literal runat="server" ID="litMapLongitude"></asp:Literal>
    </ContentTemplate>
</asp:UpdatePanel>
<Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" OnEndPan="Map1_EndPan" />

</asp:Content>

