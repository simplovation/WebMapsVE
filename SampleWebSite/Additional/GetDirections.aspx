<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GetDirections.aspx.cs" Inherits="Additional_GetDirections" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Get Directions via the GetDirections method
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<table>
    <tr>
        <td colspan='2'>
            <nobr>
            <asp:UpdatePanel runat="server" ID="UpdatePanel_Addresses">
                <ContentTemplate>
                    Starting Address:&nbsp;<asp:TextBox runat="server" ID="txtStart" Text="1600 Amphitheatre Parkway, Mountain View, CA, 94043" Width="700px"></asp:TextBox><br />
                    Ending Address:&nbsp;<asp:TextBox runat="server" ID="txtEnd" Text="One Microsoft Way, Redmond, WA, 98052" Width="700px"></asp:TextBox><br />
                    Route Mode:&nbsp;<asp:DropDownList runat="server" ID="ddlRouteMode">
                        <asp:ListItem Value="Driving" Text="Driving"></asp:ListItem>
                        <asp:ListItem Value="Walking" Text="Walking"></asp:ListItem>
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
            </nobr><br />
            <asp:Button runat="server" ID="btnGetDirections" Text="Get Directions" OnClick="btnGetDirections_Click" />
            &nbsp;
            <asp:Button runat="server" ID="btnClearDirections" Text="Clear Directions" OnClick="btnClearDirections_Click" />
        </td>
    </tr>
    <tr>
        <td valign="top">
            <div style="width: 254px; color: White; background-color: Black; padding: 1px; font-weight: bold;">Directions</div>
            <div style="overflow: auto; width: 250px; height: 396px; border: solid 1px black; padding: 2px;">
                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                    <ContentTemplate>
                        <asp:Label runat="server" ID="lblDistance" Text="Start by clicking the 'GetDirections' button."></asp:Label><br />
                        <asp:Label runat="server" ID="lblTime" Text=""></asp:Label>
                        <hr />
                        <asp:Repeater runat="server" ID="rptrDirections">
                            <ItemTemplate>
                                <strong>Distance:</strong>&nbsp;<%# ((double)Eval("Distance")).ToString("###,###,##0.00") %>&nbsp;Miles<br />
                                <strong>Time:</strong>&nbsp;<%# ((int)Eval("Time")).ToString() %>&nbsp;seconds<br />
                                <%# Eval("Text") %>
                            </ItemTemplate>
                            <SeparatorTemplate>
                                <hr />
                            </SeparatorTemplate>
                        </asp:Repeater>
                        
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnGetDirections" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnClearDirections" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </td>
        <td>
            <Simplovation:Map runat="server" ID="Map1" Width="700px" Height="425px" CssClass="map" OnDirectionsLoaded="Map1_DirectionsLoaded" />
        </td>
    </tr>
</table>




</asp:Content>

