<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OnEndZoom.aspx.cs" Inherits="Events_OnEndZoom" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Map Events - OnEndZoom
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
This event is raised after the map has finished zooming.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
<asp:UpdatePanel runat="server" ID="UpdatePanel_MapZoomDisplay">
    <ContentTemplate>
        Zoom: <asp:Literal runat="server" ID="litMapZoom"></asp:Literal><br />
    </ContentTemplate>
</asp:UpdatePanel>
<Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" OnEndZoom="Map1_EndZoom" />

</asp:Content>

