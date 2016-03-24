<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MiniMap.aspx.cs" Inherits="Extender_MiniMap" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE.Extenders" TagPrefix="MapExtenders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
MiniMapExtender
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
The MiniMapExtender adds Mini Map functionality to the Map. By Default it shows a Small Mini Map aligned to the Top Right corner of the Map.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" />
<MapExtenders:MiniMapExtender runat="server" ID="MiniMapExtender1" TargetControlID="Map1" HorizontalSide="Right" VerticalSide="Top"></MapExtenders:MiniMapExtender>



<br />
<h3>Manipulate Mini Map using JavaScript</h3>

<asp:Panel runat="server" ID="pnlMiniMapShow" GroupingText="Show/Hide Mini Map">
    <input type="button" value="Show" onclick="ShowMiniMap();" />
    &nbsp;&nbsp;&nbsp;
    <input type="button" value="Hide" onclick="HideMiniMap();" />
    <script type="text/javascript">
        function ShowMiniMap()
        {
            var miniMapExtender = $find("<%=MiniMapExtender1.ClientID%>");
            miniMapExtender.ShowMiniMap();
        }
        function HideMiniMap()
        {
            var miniMapExtender = $find("<%=MiniMapExtender1.ClientID%>");
            miniMapExtender.HideMiniMap();
        }
    </script>
</asp:Panel>

<asp:Panel runat="server" ID="pnlMiniMapSize" GroupingText="Change Mini Map Size">
    <input type="button" value="Small" onclick="SetMiniMapSmall();" />
    &nbsp;&nbsp;&nbsp;
    <input type="button" value="Large" onclick="SetMiniMapLarge();" />
    <script type="text/javascript">
        function SetMiniMapSmall()
        {
            var miniMapExtender = $find("<%=MiniMapExtender1.ClientID%>");
            miniMapExtender.SetMiniMapSize(VEMiniMapSize.Small);
        }
        function SetMiniMapLarge()
        {
            var miniMapExtender = $find("<%=MiniMapExtender1.ClientID%>");
            miniMapExtender.SetMiniMapSize(VEMiniMapSize.Large);
        }
    </script>
</asp:Panel>

<asp:Panel runat="server" ID="pnlMiniMapHorizontalSide" GroupingText="Horizontal Side">
    <input type="button" value="Left" onclick="SetHorizontalSide(Simplovation.Web.Maps.VE.Extenders.MiniMapHorizontalAlignment.Left);" />
    &nbsp;&nbsp;&nbsp;
    <input type="button" value="Center" onclick="SetHorizontalSide(Simplovation.Web.Maps.VE.Extenders.MiniMapHorizontalAlignment.Center);" />
    &nbsp;&nbsp;&nbsp;
    <input type="button" value="Right" onclick="SetHorizontalSide(Simplovation.Web.Maps.VE.Extenders.MiniMapHorizontalAlignment.Right);" />
    <script type="text/javascript">
        function SetHorizontalSide(value)
        {
            var miniMapExtender = $find("<%=MiniMapExtender1.ClientID%>");
            miniMapExtender.SetHorizontalSide(value);
        }
    </script>
</asp:Panel>

<asp:Panel runat="server" ID="Panel1" GroupingText="Vertical Side">
    <input type="button" value="Top" onclick="SetVerticalSide(Simplovation.Web.Maps.VE.Extenders.MiniMapVerticalAlignment.Top);" />
    &nbsp;&nbsp;&nbsp;
    <input type="button" value="Middle" onclick="SetVerticalSide(Simplovation.Web.Maps.VE.Extenders.MiniMapVerticalAlignment.Middle);" />
    &nbsp;&nbsp;&nbsp;
    <input type="button" value="Bottom" onclick="SetVerticalSide(Simplovation.Web.Maps.VE.Extenders.MiniMapVerticalAlignment.Bottom);" />
    <script type="text/javascript">
        function SetVerticalSide(value)
        {
            var miniMapExtender = $find("<%=MiniMapExtender1.ClientID%>");
            miniMapExtender.SetVerticalSide(value);
        }
    </script>
</asp:Panel>

<asp:Panel runat="server" ID="Panel2" GroupingText="Horizontal Offset">
    <input type="button" value="0px" onclick="SetHorizontalOffset(0);" />
    &nbsp;&nbsp;&nbsp;
    <input type="button" value="10px" onclick="SetHorizontalOffset(10);" />
    &nbsp;&nbsp;&nbsp;
    <input type="button" value="20px" onclick="SetHorizontalOffset(20);" />
    &nbsp;&nbsp;&nbsp;
    <script type="text/javascript">
        function SetHorizontalOffset(value) {
            var miniMapExtender = $find("<%=MiniMapExtender1.ClientID%>");
            miniMapExtender.SetHorizontalOffset(value);
        }
    </script>
</asp:Panel>

<asp:Panel runat="server" ID="Panel3" GroupingText="Vertical Offset">
    <input type="button" value="0px" onclick="SetVerticalOffset(0);" />
    &nbsp;&nbsp;&nbsp;
    <input type="button" value="10px" onclick="SetVerticalOffset(10);" />
    &nbsp;&nbsp;&nbsp;
    <input type="button" value="20px" onclick="SetVerticalOffset(20);" />
    &nbsp;&nbsp;&nbsp;
    <script type="text/javascript">
        function SetVerticalOffset(value) {
            var miniMapExtender = $find("<%=MiniMapExtender1.ClientID%>");
            miniMapExtender.SetVerticalOffset(value);
        }
    </script>
</asp:Panel>

</asp:Content>