<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DraggablePushpins.aspx.cs" Inherits="Additional_DraggablePushpins" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Map Properties - Draggable Pushpins
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
A boolean value indicating whether the Shape is is draggable on the Map by using the mouse. The default value is False.
<br /><br />
This example page demonstrates setting Draggable to True; enabling a Pushpin to be draggable by the mouse.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" Latitude="43.0548408795765" Longitude="-87.945556640625" Zoom="10">
    <Layers>
        <Simplovation:ShapeLayer>
            <Shapes>
                <Simplovation:Shape Draggable="true">
                    <Points>
                        <Simplovation:LatLong Latitude="43.0548408795765" Longitude="-87.945556640625" />
                    </Points>
                </Simplovation:Shape>
                <Simplovation:Shape Draggable="true">
                    <Points>
                        <Simplovation:LatLong Latitude="43.0548408795765" Longitude="-88.145556640625" />
                    </Points>
                </Simplovation:Shape>
            </Shapes>
        </Simplovation:ShapeLayer>
    </Layers>
</Simplovation:Map>

</asp:Content>


