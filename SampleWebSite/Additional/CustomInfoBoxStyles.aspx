<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CustomInfoBoxStyles.aspx.cs" Inherits="Additional_CustomInfoBoxStyles" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Custom Info Box Styles
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
When the CustomInfoBoxStylesEnabled property is set to True it allows custom CSS to be used to style the InfoBox popup. The default value is False which means it uses the Default InfoBox styles.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<style type="text/css">
/*
****** These commented out CSS styles mimics the Default Virtual Earth InfoBox Styles ******
Credit goes to the following page for these CSS styles: http://www.viawindowslive.com/Articles/VirtualEarth/VirtualEarth5CustomInfobox.aspx
    .customInfoBox-noBeak,.customInfoBox-with-rightBeak,.customInfoBox-with-leftBeak{border:solid 0px black;color:#676767;display:block;font-size:1.2em;position:absolute;z-index:500 !important;background:transparent;}
	.customInfoBox-with-rightBeak {padding:0px 19px 0px 0px;}
	.customInfoBox-with-leftBeak {padding:0px 0px 0px 19px;}
	.customInfoBox-noBeak {padding:0 4px}
	.customInfoBox-body {border:1px solid #888888;left:-3px;overflow:hidden;position:relative;top:-3px;width:255px;background:#FFFFFF;}
	.customInfoBox-shadow {float:left;position:relative;background:#BFBFBF;}
	.customInfoBox-previewArea {width:100%;background:#FFFFFF;}
	.customInfoBox-previewArea p {font-size:1.1em;margin:0px;padding:0px 12px 10px 0px;}
	.customInfoBox-previewArea div.firstChild {margin:12px;overflow:hidden;}
	.customInfoBox-previewArea .title {color:#000000;font-size:1.1em;font-weight:bold;margin:0px 0px 8px;}
	.customInfoBox-previewArea .ero-previewArea-image {display:block;float:left;height:80px;padding:3px 10px 5px 0px;position:relative;width:80px;}
	.customInfoBox-actionsBackground {margin:4px;background:#E4EDF3;}
	.customInfoBox-beak,.customInfoBox-progressAnimation {visibility:visible;}
	.customInfoBox-actions {padding:4px 8px 0px;}
	* html .customInfoBox-actions {padding-top:8px;}
	.customInfoBox-actions ul {list-style-image:none;margin:0;padding:0;list-style:none outside none;}
	.customInfoBox-actions ul a,.customInfoBox-actions ul a:link,.customInfoBox-actions ul a:visited {color:#0088E4;text-decoration:none;}
	.customInfoBox-actions ul a:hover {text-decoration:underline;}
	.customInfoBox-actions ul li {margin-bottom:4px;}
	.customInfoBox-paddingHack {font-size:8px;height:8px;width:1px;}
	.customInfoBox-beak {height:34px;position:absolute;top:10px;width:19px;}
	.customInfoBox-with-leftBeak .customInfoBox-beak {background:transparent url(http://maps.live.com/i/bin/1.3.20070327220207.22/ero/beakLeft.gif) no-repeat scroll 0;left:0px;}
	.customInfoBox-with-rightBeak .customInfoBox-beak {background:transparent url(http://maps.live.com/i/bin/1.3.20070327220207.22/ero/beakRight.gif) no-repeat scroll 0;right:4px;}
	.customInfoBox-noBeak .customInfoBox-beak {display:none;}
	.customInfoBox-progressAnimation {font-size:0;height:3px;overflow:hidden;position:absolute;width:13px;z-index:500;}
	.customInfoBox-progressAnimation div {font-size:0;height:100%;position:absolute;width:3px;background:#54CE43;}
	.customInfoBox-progressAnimation div.frame0 {left:-3px;}
	.customInfoBox-progressAnimation div.frame1 {left:0px;}
	.customInfoBox-progressAnimation div.frame2 {left:5px;}
	.customInfoBox-progressAnimation div.frame3 {left:10px;}
********************************************************************************************
*/

/* The below CSS styles are the Custom InfoBox Styles used on this page */
.customInfoBox-noBeak,.customInfoBox-with-rightBeak,.customInfoBox-with-leftBeak{border:solid 0px black;color:#676767;display:block;font-size:1.2em;position:absolute;z-index:500 !important;background:transparent;}
.customInfoBox-with-rightBeak {padding:0px 19px 0px 0px;}
.customInfoBox-with-leftBeak {padding:0px 0px 0px 19px;}
.customInfoBox-noBeak {padding:0 4px}
.customInfoBox-body {
    width:400px; /* <-- this sets the overall width of the InfoBox */
    border:1px solid #CECE77; /* <-- this is the border of the InfoBox */
    background:#FFFFCC; /* <-- this is one place where the background color of the InfoBox is defined */
    left:-3px;overflow:hidden;position:relative;top:-3px;
}
.customInfoBox-shadow{float:left;position:relative;
    background:none; /* <-- This is the color of the InfoBox's shadow */
}
.customInfoBox-previewArea {width:100%;
    background:#FFFFCC;  /* <-- this is one place where the background color of the InfoBox is defined */
}
.customInfoBox-previewArea p {font-size:1.1em;margin:0px;padding:0px 12px 10px 0px;}
.customInfoBox-previewArea div.firstChild{margin:4px;overflow:hidden;}
.customInfoBox-previewArea .title{color:#000000;font-size:1.1em;font-weight:bold;margin:0px 0px 8px;}
.customInfoBox-previewArea .ero-previewArea-image {display:block;float:left;height:80px;padding:3px 10px 5px 0px;position:relative;width:80px;}
.customInfoBox-actionsBackground {margin:4px;background:#E4EDF3;}
.customInfoBox-beak,.customInfoBox-progressAnimation {visibility:visible;}
.customInfoBox-actions {padding:4px 8px 0px;}
* html .customInfoBox-actions {padding-top:8px;}
.customInfoBox-actions ul {list-style-image:none;margin:0;padding:0;list-style:none outside none;}
.customInfoBox-actions ul a,.customInfoBox-actions ul a:link,.customInfoBox-actions ul a:visited {color:#0088E4;text-decoration:none;}
.customInfoBox-actions ul a:hover {text-decoration:underline;}
.customInfoBox-actions ul li {margin-bottom:4px;}
.customInfoBox-paddingHack {font-size:8px;height:8px;width:1px;}
.customInfoBox-beak {height:34px;position:absolute;top:10px;width:19px;}
.customInfoBox-with-leftBeak .customInfoBox-beak {background:transparent url(http://maps.live.com/i/bin/1.3.20070327220207.22/ero/beakLeft.gif) no-repeat scroll 0;left:0px;}
.customInfoBox-with-rightBeak .customInfoBox-beak {background:transparent url(http://maps.live.com/i/bin/1.3.20070327220207.22/ero/beakRight.gif) no-repeat scroll 0;right:4px;}
.customInfoBox-noBeak .customInfoBox-beak {display:none;}
.customInfoBox-progressAnimation {font-size:0;height:3px;overflow:hidden;position:absolute;width:13px;z-index:500;}
.customInfoBox-progressAnimation div{font-size:0;height:100%;position:absolute;width:3px;
    background:#FFD800; /* <-- this is the color of the little animated progress bar that is displayed on the top right of the pushpin just before the InfoBox is shown*/
}
.customInfoBox-progressAnimation div.frame0 {left:-3px;}
.customInfoBox-progressAnimation div.frame1 {left:0px;}
.customInfoBox-progressAnimation div.frame2 {left:5px;}
.customInfoBox-progressAnimation div.frame3 {left:10px;}
.ero{z-index:0;}
</style>

<table>
    <tr>
        <td valign="top">
            <nobr>
            <asp:LinkButton runat="server" ID="lbUseDefault" Text="Use Default" OnClick="lbUseDefault_Click"></asp:LinkButton><br />
            <asp:LinkButton runat="server" ID="lbUseCustom" Text="Use Custom" OnClick="lbUseCustom_Click"></asp:LinkButton>
            <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="lbUseCustom" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="lbUseDefault" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            </nobr>
        </td>
        <td>
            <Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" />        
        </td>
    </tr>
</table>

</asp:Content>

