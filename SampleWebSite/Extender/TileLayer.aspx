<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TileLayer.aspx.cs" Inherits="Extender_TileLayer" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE.Extenders" TagPrefix="MapExtenders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
TileLayerExtender
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
The TileLayerExtender allows the integration of custom tile layer images to be as simple as possible.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map"
     Zoom="10" Latitude="43.4080405599441" Longitude="-88.7118530273438" />

<MapExtenders:TileLayerExtender runat="server" ID="TileLayerExtender1" TargetControlID="Map1">
    <TileSources>
        <Simplovation:TileSourceSpecification ID="DodgeCounty"
            TileSource="~/images/TileLayers/DodgeCounty/%4.png"
            Opacity="0.5" />
            
        <%--
        Here's another example of adding a Tile Layer to the page. There is no license
        granted to use this tile layer, it is only shown here as an example of how the
        TileLayerExtender works.
        
        This layer was used by Keith Kinnan in the following post:
        http://blogs.msdn.com/keithkin/archive/2007/05/01/virtual-earth-api-using-tile-layers.aspx
        
        <Simplovation:TileSourceSpecification ID="SeattleTransit"
            TileSource="http://jbhatia1.members.winisp.net/SeattleTransit/%4.png"
            NumServers="1"
            MinZoom="2"
            MaxZoom="16"
            Opacity="0.8"
            ZIndex="100">
            <Bounds>
                <Simplovation:LatLongRectangle>
                    <TopLeftLatLong Latitude="49" Longitude="-123" />
                    <BottomRightLatLong Latitude="47" Longitude="-47" />
                </Simplovation:LatLongRectangle>
            </Bounds>
        </Simplovation:TileSourceSpecification>
        --%>
    </TileSources>
</MapExtenders:TileLayerExtender>

<br />
The Map of Dodge County Wisconsin that was used for this sample can be found here: <a href="http://www.dodgecounty.com/maps.html">http://www.dodgecounty.com/maps.html</a>
<br />
<br />
For information on using MapCruncher to generate Tile Layer Images go here: <a href="http://dev.live.com/virtualearth/mapcruncher/">http://dev.live.com/virtualearth/mapcruncher/</a>

</asp:Content>