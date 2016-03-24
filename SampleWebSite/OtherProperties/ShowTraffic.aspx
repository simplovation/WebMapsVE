<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowTraffic.aspx.cs" Inherits="OtherProperties_ShowTraffic" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Map Properties - ShowTraffic
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
When set to True, local traffic data is shown on the map. The traffic data is only available at zoom levels 9 through 15, inclusively.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">
    
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    
    <Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map"
        ShowTraffic="true" Zoom="9" Latitude="41.894099558114" Longitude="-87.6763916015625" ShowTrafficLegend="true" TrafficLegendText="Traffic Data" />
    
    <br />
    This example also has the following properties set:<br />
    <strong>ShowTrafficLegend</strong>&nbsp;set to True<br />
    <strong>TrafficLegendText</strong>&nbsp;set to "Traffic Data"<br />
    The Traffic Legend and Traffic Legend Text are displayed in the bottom right corner of the map. By default the Traffic Legend is turned off.
</asp:Content>

