<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowSwitch.aspx.cs" Inherits="OtherProperties_ShowSwitch" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Map Properties - ShowSwitch
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
Specifies whether to show the map mode switch on the dashboard control. This property can only be set on the initial load of the page, and cannot be changed on an Asynchronous Postback.<br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
    
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    
    <table>
        <tr>
            <td valign="top">
                <nobr>
                <asp:LinkButton runat="server" ID="lbSetTrue" Text="Set to True" OnClick="lbSetTrue_Click"></asp:LinkButton><br />
                <asp:LinkButton runat="server" ID="lbSetFalse" Text="Set to False" OnClick="lbSetFalse_Click"></asp:LinkButton>
                </nobr>
            </td>
            <td>
                <Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" />
            </td>
        </tr>
    </table>
</asp:Content>

