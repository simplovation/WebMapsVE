<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddControl.aspx.cs" Inherits="JavaScript_AddControl" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Advanced JavaScript - Add Control
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map"
 OnClientMapLoaded="Map1_ClientLoaded" />
 
<!-- Below is a DIV that will be overlaid over the Map -->
<div id="CustomMapControl" style="display: none; border: solid 1px black; background-color: #CCCCCC; color: Black; padding: 4px;">
    Some <strong>Content</strong> for<br />the Custom Control.<br />
    <input type="button" value="Zoom In" onclick="$find('<%=Map1.ClientID %>').ZoomIn();" />
    &nbsp;
    <input type="button" value="Zoom Out" onclick="$find('<%=Map1.ClientID %>').ZoomOut();" />
</div>

<script type="text/javascript">
    function Map1_ClientLoaded(sender) {
        var map = sender; // <-- Web.Maps.VE Map object reference

        // Get reference to the DIV to use as the "Custom Control"
        var div = $get("CustomMapControl");

        // Set the DIV's location over the Map
        // This will position it 75 pixels down from the top,
        // and 50 pixels left from the edge of the Map.
        div.style.top = "75px";
        div.style.left = "50px";


        // Because of a timing issue of when Bing Maps fires the "loaded" event
        // and when Custom Controls can be added, we need to delay the actual adding
        // of the Custom Control by a small amount. In this case we're "delaying" it
        // by 100 milliseconds (or 1/10th of a second).
        window.setTimeout(function() {
            // Add the Custom Control
            map.AddControl(div);

            // Make it visible
            div.style.display = "";
        }, 100);
    }
</script>

</asp:Content>

