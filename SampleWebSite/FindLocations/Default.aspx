<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="FindLocations_Default" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">Reverse Geocode - Basic FindLocations</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
This is a basic sample of using the FindLocations method. Just click on a location of the map, and that lat/long will be reverse geocoded, with the results displayed to the right of the map.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<table>
    <tr>
        <td valign="top">
        
            <Simplovation:Map runat="server" ID="Map1" Width="500px" Height="450px" CssClass="map" OnClick="Map1_Click" OnFindLocationsLoaded="Map1_FindLocationsLoaded" />
        
        </td>
        <td valign="top">
        
            <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                <ContentTemplate>
                    <strong>Clicked Location</strong><br />
                    Lat:&nbsp;<asp:Label runat="server" ID="lblLatitude"></asp:Label><br />
                    Lng:&nbsp;<asp:Label runat="server" ID="lblLongitude"></asp:Label><br />
                    
                    <hr />
                
                    <asp:Repeater runat="server" ID="rptrPlaces">
                        <HeaderTemplate>
                            <strong>Place</strong><br />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("Name") %><br />
                            Lat:&nbsp;<%# Eval("LatLong.Latitude") %><br />
                            Lng:&nbsp;<%# Eval("LatLong.Longitude") %><br />
                            Match Code:&nbsp;<%# Eval("MatchCode") %><br />
                            Match Confidence:&nbsp;<%# Eval("MatchConfidence") %><br />
                            Score:&nbsp;<%# Eval("Score") %>
                        </ItemTemplate>
                        <SeparatorTemplate>
                            <hr />
                        </SeparatorTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
        
        </td>
    </tr>
</table>


</asp:Content>

