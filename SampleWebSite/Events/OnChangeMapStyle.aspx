<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OnChangeMapStyle.aspx.cs" Inherits="Events_OnChangeMapStyle" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Map Events - OnChangeMapStyle
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
This event is raised when ever the Style (Road, Aerial or Hybrid) is changed.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
<br />
<asp:UpdatePanel runat="server" ID="UpdatePanel_MapStyleDisplay">
    <ContentTemplate>
        Map Style: <asp:Literal runat="server" ID="litMapStyle"></asp:Literal>
    </ContentTemplate>
</asp:UpdatePanel>
<Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" OnChangeMapStyle="Map1_ChangeMapStyle" />

</asp:Content>

