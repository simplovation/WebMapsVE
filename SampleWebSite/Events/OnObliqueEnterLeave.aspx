<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OnObliqueEnterLeave.aspx.cs" Inherits="Events_OnObliqueEnterLeave" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Map Events - OnObliqueEnter and OnObliqueLeave
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
The OnObliqueEnter event is fired when birdseye imagery is available, and the OnObliqueLeave event is fired when birdseye imagery is no longer available.<br />
Try zooming in closer to Chicago, some green text will appear above the map when birdseye imagery becomes available. Then zoom out and red text will appear in the same place.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
<asp:UpdatePanel runat="server" ID="UpdatePanel_MapObliqueDisplay">
    <ContentTemplate>
        <asp:Literal runat="server" ID="litMapObliqueMessage"></asp:Literal><br />
    </ContentTemplate>
</asp:UpdatePanel>
<Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" OnObliqueEnter="Map1_ObliqueEnter" OnObliqueLeave="Map1_ObliqueLeave" />

</asp:Content>

