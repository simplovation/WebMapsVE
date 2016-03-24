<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DashboardSize.aspx.cs" Inherits="OtherProperties_DashboardSize" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Map Properties - DashboardSize
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
Sets the map dashboard size (Normal, Small and Tiny). This property can only be set on the initial load of the page, and cannot be changed on an Asynchronous Postback.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
    
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    
    <table>
        <tr>
            <td valign="top">
                <nobr>
                <asp:LinkButton runat="server" ID="lbNormal" Text="Normal" OnClick="lbNormal_Click"></asp:LinkButton><br />
                <asp:LinkButton runat="server" ID="lbSmall" Text="Small" OnClick="lbSmall_Click"></asp:LinkButton><br />
                <asp:LinkButton runat="server" ID="lbTiny" Text="Tiny" OnClick="lbTiny_Click"></asp:LinkButton>
                </nobr>
            </td>
            <td>
                <Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" />
            </td>
        </tr>
    </table>
</asp:Content>

