<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="JavaScript.aspx.cs" Inherits="Basics_JavaScript" Title="Map Basics - JavaScript" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Map Basics - JavaScript
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
This example demonstrates the basics of manipulating the map from within client-side JavaScript code.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<table>
    <tr>
        <td valign="top" style="width: 250px;">
            <asp:Panel runat="server" ID="pnlPan" GroupingText="Pan">
                <a href="javascript:void(0);" onclick="PanVertically(-50);">Up</a>
                &nbsp;&nbsp;
                <a href="javascript:void(0);" onclick="PanVertically(50);">Down</a>
                <br />
                <a href="javascript:void(0);" onclick="PanHorizontally(-50);">Left</a>
                &nbsp;&nbsp;
                <a href="javascript:void(0);" onclick="PanHorizontally(50);">Right</a>
                <script type="text/javascript">
                    function PanVertically(v){
                        var map = $find("<%=Map1.ClientID%>");
                        map.Pan(0, v);
                    }
                    function PanHorizontally(v){
                        var map = $find("<%=Map1.ClientID%>");
                        map.Pan(v, 0);
                    }
                </script>
            </asp:Panel>
        
            <asp:Panel runat="server" ID="pnlZoom" GroupingText="Zoom">
                <a href="javascript:void(0);" onclick="ZoomIn();">Zoom In</a><br />
                <a href="javascript:void(0);" onclick="ZoomOut();">Zoom Out</a>
                <script type="text/javascript">
                    function ZoomIn()
                    {
                        var map = $find("<%=Map1.ClientID%>");
                        map.ZoomIn();
                    }
                    
                    function ZoomOut()
                    {
                        var map = $find("<%=Map1.ClientID%>");
                        map.ZoomOut();
                    }
                </script>
            </asp:Panel>

            <asp:Panel runat="server" ID="pnlMapView" GroupingText="Map Style">
                <a href="javascript:void(0);" onclick="SetMapType(Microsoft.Maps.MapTypeId.road);">Road</a><br />
                <a href="javascript:void(0);" onclick="SetMapType(Microsoft.Maps.MapTypeId.aerial);">Aerial</a><br />
                <script type="text/javascript">
                    function SetMapType(v)
                    {
                        var map = $find("<%=Map1.ClientID%>");
                        map.SetMapType(v);
                    }
                </script>
            </asp:Panel>

            <asp:Panel runat="server" ID="pnlShapes" GroupingText="Shapes">
                <a href="javascript:void(0);" onclick="ClearAllShapes();">Clear All</a>
                <script type="text/javascript">
                    function ClearAllShapes()
                    {
                        var map = $find("<%=Map1.ClientID%>");
                        map.DeleteAllShapes();
                    }
                </script>
            </asp:Panel>
                      
        </td>
        <td valign="top">
            <Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" BingKey="test">
                <Layers>
                    <Simplovation:ShapeLayer>
                        <Shapes>
                            <Simplovation:Shape Title="Test Pushpin" Description="A description for the Test pushpin.">
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

