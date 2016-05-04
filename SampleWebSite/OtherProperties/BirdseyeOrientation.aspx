<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BirdseyeOrientation.aspx.cs" Inherits="OtherProperties_Fixed" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Map Properties - BirdseyeOrientation
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
A Orientation Enumeration value indicating the orientation of the bird's eye map. The default value is Orientation.North.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<asp:Button runat="server" ID="btnSetToNorth" OnClick="btnSetToNorth_Click" Text="Set to North" />
<asp:Button runat="server" ID="btnSetToSouth" OnClick="btnSetToSouth_Click" Text="Set to South" />
<asp:Button runat="server" ID="btnSetToEast" OnClick="btnSetToEast_Click" Text="Set to East" />
<asp:Button runat="server" ID="btnSetToWest" OnClick="btnSetToWest_Click" Text="Set to West" />
<asp:UpdatePanel runat="server" ID="up1">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSetToNorth" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSetToSouth" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSetToEast" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSetToWest" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
<br />
 
<Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" MapType="Birdseye" Latitude="43.0548408795765" Longitude="-87.945556640625" Zoom="10" />

</asp:Content>

