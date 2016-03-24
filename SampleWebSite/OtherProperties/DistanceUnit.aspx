<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DistanceUnit.aspx.cs" Inherits="OtherProperties_DistanceUnit" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Map Properties - DistanceUnit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
Setting the Maps DistanceUnit property defines what distance unit (Miles or Kilometers) for the map to show on the scale bar. This property can only be set on the initial load of the page, and cannot be changed on an Asynchronous Postback.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    
    <table>
        <tr>
            <td valign="top">
                <nobr>
                <asp:LinkButton runat="server" ID="lbSetMiles" Text="Set to Miles" OnClick="lbSetMiles_Click"></asp:LinkButton><br />
                <asp:LinkButton runat="server" ID="lbSetKilometers" Text="Set to Kilometers" OnClick="lbSetKilometers_Click"></asp:LinkButton>
                </nobr>
            </td>
            <td>
                <Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" />
            </td>
        </tr>
    </table>
    
</asp:Content>

