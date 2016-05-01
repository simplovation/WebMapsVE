<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ClientSide.aspx.cs" Inherits="Basics_ClientSide" Title="Map Basics - Client-Side" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE.Extenders" TagPrefix="MapExtenders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Map Basics - Client-Side
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
This example demonstrates using the MapActionExtender control to setup map manipulations in a completely declarative way. There's no need to write any JavaScript to do this stuff. All map manipulations done with the MapActionExtender control do not cause an asynchronous postback to occur in order for that action to take place. Other map events (such as: OnZoomEnd and OnEndPan) that get generated will still get passed up to the server.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<table>
    <tr>
        <td valign="top" style="width: 150px;">
        
            <asp:Panel runat="server" ID="pnlPan" GroupingText="Pan">
                <!--
                The MapActionExtender uses the Value property when implementing the Pan map Actions.
                The Value property will default to 50 when not set for the Pan map actions.
                When implementing Pan map events, the Value property is set to a numeric value representing
                the amount (in pixels) to move the map in the desired direction.
                -->
                <asp:LinkButton runat="server" ID="btnPanUp" Text="Up"></asp:LinkButton>
                <MapExtenders:MapActionExtender runat="server" id="MapActionExtender17" TargetControlID="btnPanUp" EventName="click" MapControlID="Map1" MapAction="PanUp" Value="50"></MapExtenders:MapActionExtender>
                &nbsp;&nbsp;
                <asp:LinkButton runat="server" ID="btnPanDown" Text="Down"></asp:LinkButton>
                <MapExtenders:MapActionExtender runat="server" id="MapActionExtender18" TargetControlID="btnPanDown" EventName="click" MapControlID="Map1" MapAction="PanDown" Value="50"></MapExtenders:MapActionExtender>
                <br />
                <asp:LinkButton runat="server" ID="btnPanLeft" Text="Left"></asp:LinkButton>
                <MapExtenders:MapActionExtender runat="server" id="MapActionExtender19" TargetControlID="btnPanLeft" EventName="click" MapControlID="Map1" MapAction="PanLeft" Value="50"></MapExtenders:MapActionExtender>
                &nbsp;&nbsp;
                <asp:LinkButton runat="server" ID="btnPanRight" Text="Right"></asp:LinkButton>
                <MapExtenders:MapActionExtender runat="server" id="MapActionExtender20" TargetControlID="btnPanRight" EventName="click" MapControlID="Map1" MapAction="PanRight" Value="50"></MapExtenders:MapActionExtender>
            </asp:Panel>
            
            <asp:Panel runat="server" ID="pnlZoom" GroupingText="Zoom">
                <asp:LinkButton runat="server" ID="btnZoomIn" Text="Zoom In"></asp:LinkButton>
                <MapExtenders:MapActionExtender runat="server" id="MapActionExtender1" TargetControlID="btnZoomIn" EventName="click" MapControlID="Map1" MapAction="ZoomIn"></MapExtenders:MapActionExtender>
                <br />
                <asp:LinkButton runat="server" ID="btnZoomOut" Text="Zoom Out"></asp:LinkButton>
                <MapExtenders:MapActionExtender runat="server" id="MapActionExtender2" TargetControlID="btnZoomOut" EventName="click" MapControlID="Map1" MapAction="ZoomOut"></MapExtenders:MapActionExtender>
            </asp:Panel>

            <asp:Panel runat="server" ID="pnlMapView" GroupingText="Map Style">
                <asp:LinkButton runat="server" ID="lbRoadStyle" Text="Road"></asp:LinkButton>
                <MapExtenders:MapActionExtender runat="server" id="MapActionExtender3" TargetControlID="lbRoadStyle" EventName="click" MapControlID="Map1" MapAction="SetMapStyleRoad"></MapExtenders:MapActionExtender>
                <br />
                <asp:LinkButton runat="server" ID="lbAerialStyle" Text="Aerial"></asp:LinkButton>
                <MapExtenders:MapActionExtender runat="server" id="MapActionExtender4" TargetControlID="lbAerialStyle" EventName="click" MapControlID="Map1" MapAction="SetMapStyleAerial"></MapExtenders:MapActionExtender>
                <br />
                <asp:LinkButton runat="server" ID="lbHybridStyle" Text="Hybrid"></asp:LinkButton>
                <MapExtenders:MapActionExtender runat="server" id="MapActionExtender5" TargetControlID="lbHybridStyle" EventName="click" MapControlID="Map1" MapAction="SetMapStyleHybrid"></MapExtenders:MapActionExtender>
                <br />
                <asp:LinkButton runat="server" ID="lbBirdseyeStyle" Text="Birdseye"></asp:LinkButton>
                <MapExtenders:MapActionExtender runat="server" id="MapActionExtender6" TargetControlID="lbBirdseyeStyle" EventName="click" MapControlID="Map1" MapAction="SetMapStyleBirdseye"></MapExtenders:MapActionExtender>
                <br />
                <asp:LinkButton runat="server" ID="lbShadedStyle" Text="Shaded"></asp:LinkButton>
                <MapExtenders:MapActionExtender runat="server" id="MapActionExtender16" TargetControlID="lbShadedStyle" EventName="click" MapControlID="Map1" MapAction="SetMapStyleShaded"></MapExtenders:MapActionExtender>
            </asp:Panel>

            <asp:Panel runat="server" ID="pnlShapes" GroupingText="Shapes">
                <asp:LinkButton runat="server" ID="lbShapesClearAll" Text="Clear All"></asp:LinkButton>
                <MapExtenders:MapActionExtender runat="server" id="MapActionExtender11" TargetControlID="lbShapesClearAll" EventName="click" MapControlID="Map1" MapAction="ClearAllShapes"></MapExtenders:MapActionExtender>
            </asp:Panel>
            
            <asp:Panel runat="server" ID="pnlTraffic" GroupingText="Traffic">
                <asp:LinkButton id="lbTrafficShow" runat="server" Text="Show Traffic"></asp:LinkButton>
                <MapExtenders:MapActionExtender runat="server" id="MapActionExtender12" TargetControlID="lbTrafficShow" EventName="click" MapControlID="Map1" MapAction="ShowTraffic"></MapExtenders:MapActionExtender>
                <br />
                <asp:LinkButton id="lbTrafficClear" runat="server" Text="Clear Traffic"></asp:LinkButton>
                <MapExtenders:MapActionExtender runat="server" id="MapActionExtender13" TargetControlID="lbTrafficClear" EventName="click" MapControlID="Map1" MapAction="ClearTraffic"></MapExtenders:MapActionExtender>
                <br />
                <small>
                If you don't see<br />traffic data, try<br />zooming in closer to<br />a major city, such as 'Chicago'.
                </small>
                <hr />
                <asp:LinkButton id="lbTrafficShowLegend" runat="server" Text="Show Legend"></asp:LinkButton><br />
                <MapExtenders:MapActionExtender runat="server" id="MapActionExtender14" TargetControlID="lbTrafficShowLegend" EventName="click" MapControlID="Map1" MapAction="ShowTrafficLegend"></MapExtenders:MapActionExtender>
                <asp:LinkButton id="lbTrafficHideLegend" runat="server" Text="Hide Legend"></asp:LinkButton><br />
                <MapExtenders:MapActionExtender runat="server" id="MapActionExtender15" TargetControlID="lbTrafficHideLegend" EventName="click" MapControlID="Map1" MapAction="HideTrafficLegend"></MapExtenders:MapActionExtender>
            </asp:Panel>
        </td>
        <td valign="top">

            <Simplovation:Map runat="server" ID="Map1" Width="500px" Height="450px" CssClass="map" />
            
        </td>
    </tr>
</table>

</asp:Content>

