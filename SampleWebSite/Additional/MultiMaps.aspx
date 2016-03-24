<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MultiMaps.aspx.cs" Inherits="Basics_MultiMaps" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Multiple Maps on the Same Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
You can place multiple maps on the same page. There is no restriction to the number of maps that can be loaded.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<table>
    <tr>
        <td>
            <Simplovation:Map runat="server" ID="Map1" Width="300px" Height="300px" CssClass="map" />        
        </td>
        <td>
            <Simplovation:Map runat="server" ID="Map2" Width="400px" Height="300px" CssClass="map" />        
        </td>
    </tr>
    <tr>
        <td>
            <Simplovation:Map runat="server" ID="Map3" Width="300px" Height="300px" CssClass="map" />        
        </td>
        <td>
            <Simplovation:Map runat="server" ID="Map4" Width="400px" Height="300px" CssClass="map" />        
        </td>
    </tr>
</table>

</asp:Content>

