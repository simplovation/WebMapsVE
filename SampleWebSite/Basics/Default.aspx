<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Basics_Default" Title="Map Basics - Server-Side" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Map Basics - Server-Side
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
This example demonstrates how to manipulate the map from server-side code. Absolutely no JavaScript required.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<table>
    <tr>
        <td valign="top">
        
            <div style="text-align: left;">
            
                <table>
                    <tr>
                        <td valign="top">
                            <nobr>
                                <asp:Panel runat="server" ID="pnlZoom" GroupingText="Zoom">
                                    <asp:LinkButton ID="lbZoomIn" runat="server" Text="Zoom In" OnClick="lbZoomIn_Click"></asp:LinkButton><br />
                                    <asp:LinkButton ID="lbZoomOut" runat="server" Text="Zoom Out" OnClick="lbZoomOut_Click"></asp:LinkButton>
                                </asp:Panel>
                                
                                <asp:Panel runat="server" ID="pnlMapView" GroupingText="Map Style">
                                    <asp:LinkButton ID="lbMapViewRoad" runat="server" Text="Road" OnClick="lbMapViewRoad_Click"></asp:LinkButton><br />
                                    <asp:LinkButton ID="lbMapViewAerial" runat="server" Text="Aerial" OnClick="lbMapViewAerial_Click"></asp:LinkButton><br />
                                    <asp:LinkButton ID="lbMapViewHybrid" runat="server" Text="Hybrid" OnClick="lbMapViewHybrid_Click"></asp:LinkButton><br />
                                    <asp:LinkButton ID="lbMapViewBirdseye" runat="server" Text="Birdseye" OnClick="lbMapViewBirdseye_Click"></asp:LinkButton><br />
                                    <asp:LinkButton ID="lbMapViewShaded" runat="server" Text="Shaded" OnClick="lbMapViewShaded_Click"></asp:LinkButton>
                                </asp:Panel>
                                
                                <asp:Panel runat="server" ID="pnlMapNav" GroupingText="Nav Control">
                                    <asp:LinkButton ID="lbMapNavToggle" runat="server" Text="Toggle Dashboard" OnClick="lbMapNavToggle_Click"></asp:LinkButton>
                                </asp:Panel>
                               
                                <asp:Panel runat="server" ID="pnlShapes" GroupingText="Shapes">
                                    <asp:LinkButton id="lbShapesPushpin" runat="server" Text="Add Pushpin" OnClick="lbShapesPushpin_Click"></asp:LinkButton><br />
                                    <asp:LinkButton id="lbShapesPolyline" runat="server" Text="Add Polyline" OnClick="lbShapesPolyline_Click"></asp:LinkButton><br />
                                    <asp:LinkButton id="lbShapesPolygon" runat="server" Text="Add Polygon" OnClick="lbShapesPolygon_Click"></asp:LinkButton>
                                    <hr />
                                    <asp:LinkButton id="lbShapesCustomPushpin" runat="server" Text="Add Custom Pushpin" OnClick="lbShapesCustomPushpin_Click"></asp:LinkButton><br />
                                    <hr />
                                    <asp:LinkButton id="lbShapesClearAll" runat="server" Text="Clear All" OnClick="lbShapesClearAll_Click"></asp:LinkButton>
                                </asp:Panel>
                                
                                <asp:Panel runat="server" ID="pnlMapSize" GroupingText="Map Size">
                                    <asp:LinkButton ID="lbMapSizeIncreaseWidth" runat="server" Text="Increase Width" OnClick="lbMapSizeIncreaseWidth_Click"></asp:LinkButton><br />
                                    <asp:LinkButton ID="lbMapSizeIncreaseHeight" runat="server" Text="Increase Height" OnClick="lbMapSizeIncreaseHeight_Click"></asp:LinkButton><br />
                                    <asp:LinkButton ID="lbMapSizeDecreaseWidth" runat="server" Text="Decrease Width" OnClick="lbMapSizeDecreaseWidth_Click"></asp:LinkButton><br />
                                    <asp:LinkButton ID="lbMapSizeDecreaseHeight" runat="server" Text="Decrease Height" OnClick="lbMapSizeDecreaseHeight_Click"></asp:LinkButton><br />
                                </asp:Panel>
                                
                                <asp:Panel runat="server" ID="pnlTraffic" GroupingText="Traffic">
                                    <asp:LinkButton id="lbTrafficShow" runat="server" Text="Show Traffic" OnClick="lbTrafficShow_Click"></asp:LinkButton><br />
                                    <asp:LinkButton id="lbTrafficClear" runat="server" Text="Clear Traffic" OnClick="lbTrafficClear_Click"></asp:LinkButton><br />
                                    <small>
                                    If you don't see<br />traffic data, try<br />zooming in closer to<br />a major city, such as 'Chicago'.
                                    </small>
                                    <hr />
                                    <asp:LinkButton id="lbTrafficShowLegend" runat="server" Text="Show Legend" OnClick="lbTrafficShowLegend_Click"></asp:LinkButton><br />
                                    <asp:LinkButton id="lbTrafficHideLegend" runat="server" Text="Hide Legend" OnClick="lbTrafficHideLegend_Click"></asp:LinkButton><br />
                                </asp:Panel>
                            </nobr>
                        </td>
                    </tr>
                </table>
                
            </div>

            <asp:UpdatePanel runat="server" ID="UpdatePanel_ZoomButtons" UpdateMode="Conditional">
                <ContentTemplate></ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="lbZoomIn" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="lbZoomOut" EventName="Click" />
                    
                    <asp:AsyncPostBackTrigger ControlID="lbMapViewRoad" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="lbMapViewAerial" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="lbMapViewHybrid" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="lbMapViewBirdseye" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="lbMapViewShaded" EventName="Click" />
                    
                    <asp:AsyncPostBackTrigger ControlID="lbMapMode2D" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="lbMapMode3D" EventName="Click" />
                    
                    <asp:AsyncPostBackTrigger ControlID="lbMapNavToggle" EventName="Click" />
                    
                    <asp:AsyncPostBackTrigger ControlID="lbShapesPushpin" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="lbShapesPolyline" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="lbShapesPolygon" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="lbShapesCustomPushpin" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="lbShapesClearAll" EventName="Click" />
                    
                    <asp:AsyncPostBackTrigger ControlID="lbMapSizeIncreaseWidth" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="lbMapSizeIncreaseHeight" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="lbMapSizeDecreaseWidth" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="lbMapSizeDecreaseHeight" EventName="Click" />
                    
                    <asp:AsyncPostBackTrigger ControlID="lbTrafficShow" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="lbTrafficClear" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="lbTrafficShowLegend" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="lbTrafficHideLegend" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>

        </td>
        <td valign="top">
            <Simplovation:Map runat="server" ID="Map1" Width="500px" Height="450px" CssClass="map" />
        </td>
    </tr>
</table>

</asp:Content>

