<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LocationButton.aspx.cs" Inherits="OtherControls_LocationButton" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">Other Controls - LocationButton</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
The LocationButton control is an HtmlButton control with location specific properties that specify what map location to move the map to when it is clicked my the user.<br />
<small>For additional usage not shown on this page, see the "Basic Find" example, which shows using the LocationButton control to reposition the map to place a specific Shape in view by referencing the Shape's ClientID.</small>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<table>
    <tr>
        <td valign="top">
        
            <Simplovation:LocationButton runat="server" ID="LocationLink1" TargetMapID="Map1" Latitude="43.0438017760824" Longitude="-87.9180908203125" ZoomLevel="12">Milwaukee</Simplovation:LocationButton><br />
            <Simplovation:LocationButton runat="server" ID="LocationLink2" TargetMapID="Map1" Latitude="41.874673839758" Longitude="-87.6681518554688" ZoomLevel="10">Chicago</Simplovation:LocationButton><br />
            <Simplovation:LocationButton runat="server" ID="LocationLink3" TargetMapID="Map1" Latitude="40.7254049717561" Longitude="-73.9791870117188" ZoomLevel="10">New York</Simplovation:LocationButton><br />
            <Simplovation:LocationButton runat="server" ID="LocationLink4" TargetMapID="Map1" Latitude="47.5969031811547" Longitude="-122.301177978516" ZoomLevel="10">Seattle</Simplovation:LocationButton>
            <hr />
            You can also move the map to show a specific Shape by it's ClientID or Tag values.
            <br />
            <br />
            <Simplovation:LocationButton runat="server" ID="LocationLink5" TargetMapID="Map1" ShapeTag="TestShape">Show Pushpin</Simplovation:LocationButton>
        </td>
        <td>
        
            <Simplovation:Map runat="server" ID="Map1" Width="600px" Height="450px" CssClass="map">
                <Layers>
                    <Simplovation:ShapeLayer>
                        <Shapes>
                            <Simplovation:Shape Title="Test Pushpin" Description="A description for the Test pushpin." Tag="TestShape">
                                <Points>
                                    <Simplovation:LatLong Latitude="40.5137991550441" Longitude="-97.734375"></Simplovation:LatLong>
                                </Points>
                            </Simplovation:Shape>
                        </Shapes>
                    </Simplovation:ShapeLayer>
                </Layers>
            </Simplovation:Map>
        
        </td>
    </tr>
</table>

</asp:Content>

