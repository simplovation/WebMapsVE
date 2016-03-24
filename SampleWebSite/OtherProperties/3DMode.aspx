<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="3DMode.aspx.cs" Inherits="OtherProperties_3DMode" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">Other Properties - 3D Mode</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<table>
    <tr>
        <td>
        
            <Simplovation:Map runat="server" ID="Map1" Width="550px" Height="450px" CssClass="map" MapMode="Mode3D" OnChangeView="Map1_ChangeView" />        
            
        </td>
        <td valign="top">
        
        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <ContentTemplate>
                        
                Altitude&nbsp;<asp:Label runat="server" ID="lblAltitude"></asp:Label><br />
                Pitch:&nbsp;<asp:Label runat="server" ID="lblPitch"></asp:Label><br />
                Heading:&nbsp;<asp:Label runat="server" id="lblHeading"></asp:Label>
                        
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="lbSetAltitude" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="lbSetPitch" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="lbSetHeading" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        
        <asp:LinkButton runat="server" ID="lbSetAltitude" OnClick="lbSetAltitude_Click" Text="Set Altitude to 5000"></asp:LinkButton><br />
        <asp:LinkButton runat="server" ID="lbSetPitch" OnClick="lbSetPitch_Click" Text="Set Pitch to -40"></asp:LinkButton><br />
        <asp:LinkButton runat="server" ID="lbSetHeading" OnClick="lbSetHeading_Click" Text="Set Heading to 90"></asp:LinkButton><br />
        
        </td>
    </tr>
</table>


</asp:Content>