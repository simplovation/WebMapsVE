<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OnInitMode.aspx.cs" Inherits="Events_OnInitMode" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Map Events - OnInitMode
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
The OnInitMode event is fired when 2D or 3D map modes have finished loading.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<asp:UpdatePanel runat="server" ID="UpdatePanel1">
    <ContentTemplate>
        <asp:Label runat="server" ID="lblMessage" ForeColor="Blue" Text="OnInitMode not triggered yet"></asp:Label>
    </ContentTemplate>
</asp:UpdatePanel>
<Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" OnInitMode="Map1_InitMode" />

</asp:Content>

