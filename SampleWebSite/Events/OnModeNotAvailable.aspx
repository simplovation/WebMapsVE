<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OnModeNotAvailable.aspx.cs" Inherits="Events_OnModeNotAvailable" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Map Events - OnModeNotAvailable
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
The OnModeNotAvailable events is triggered when the map mode fails to change to 3D mode. This event is typically triggered when the Virtual Earth 3D client software is not installed. Use this event to determine whether the client computer has the client Virtual Earth 3D software installed.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<asp:UpdatePanel runat="server" ID="UpdatePanel1">
    <ContentTemplate>
        <asp:Label runat="server" ID="lblMessage" ForeColor="Red" Text=""></asp:Label>
    </ContentTemplate>
</asp:UpdatePanel>
<Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" OnModeNotAvailable="Map1_ModeNotAvailable" />

</asp:Content>
