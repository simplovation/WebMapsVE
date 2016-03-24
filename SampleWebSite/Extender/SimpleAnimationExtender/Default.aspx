<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Extender_SimpleAnimationExtender_Default" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE.Extenders" TagPrefix="MapExtenders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
SimpleAnimationExtender
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
The SimpleAnimationExtender adds the ability to automatically move the map through a series of points on timed intervals. You can use this extender to show an animated slideshow of map locations. You can also attach Button, LinkButton or HyperLink controls to the extender to control animation actions (such as: First, Next, Previous, Last, Play, Stop).
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<h4 style="margin-bottom: 2px;"><asp:Label runat="server" ID="lblAnimationPointTitle"></asp:Label></h4>
<asp:Label runat="server" ID="lblAnimationPointDescription"></asp:Label><br />

<Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" />

<asp:Button runat="server" ID="btnFirst" Text="<< First"  />&nbsp;&nbsp;
<asp:Button runat="server" ID="btnPrevious" Text="< Previous" />&nbsp;&nbsp;
<asp:Button runat="server" ID="btnNext" Text="Next >"  />&nbsp;&nbsp;
<asp:Button runat="server" ID="btnLast" Text="Last >>"  />&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button runat="server" ID="btnPlay" Text="Play" />&nbsp;
<asp:Button runat="server" ID="btnStop" Text="Stop" />&nbsp;
<%-- You can also use LinkButton or HyperLink controls for the SimpleAnimationExtender Buttons --%>

<MapExtenders:SimpleAnimationExtender runat="server" id="SimpleAnimationExtender1" AutoPlay="true" TargetControlID="Map1"
    NextControlID="btnNext" PreviousControlID="btnPrevious" FirstControlID="btnFirst" LastControlID="btnLast"
    PlayControlID="btnPlay" StopControlID="btnStop"
    TitleControlID="lblAnimationPointTitle" DescriptionControlID="lblAnimationPointDescription">
    <Points>
        <MapExtenders:SimpleAnimationPoint Duration="1000" ZoomLevel="12" Title="Milwaukee" Description="This is Milwaukee. And the Description <strong>can</strong> contain HTML tags.">
            <LatLong Latitude="43.0438017760824" Longitude="-87.9180908203125" />
        </MapExtenders:SimpleAnimationPoint>
        <MapExtenders:SimpleAnimationPoint Duration="1000" ZoomLevel="10" Title="Chicago" Description="This is Chicago">
            <LatLong Latitude="41.874673839758" Longitude="-87.6681518554688" />
        </MapExtenders:SimpleAnimationPoint>
        <MapExtenders:SimpleAnimationPoint Duration="1000" ZoomLevel="10" Title="New York" Description="This is New York">
            <LatLong Latitude="40.7254049717561" Longitude="-73.9791870117188" />
        </MapExtenders:SimpleAnimationPoint>
        <MapExtenders:SimpleAnimationPoint Duration="1000" ZoomLevel="10" Title="Seattle / Title <span style='color:blue;'>can</span> also contain HTML tags" Description="This is Seattle">
            <LatLong Latitude="47.5969031811547" Longitude="-122.301177978516" />
        </MapExtenders:SimpleAnimationPoint>
    </Points>
</MapExtenders:SimpleAnimationExtender>

<hr />
<h3>Manipulate the SimpleAnimationExtender using JavaScript</h3>

<input type="button" value="Play" onclick="PlayAnimation();" />
&nbsp;&nbsp;

<input type="button" value="Stop" onclick="StopAnimation();" />
<br />

<input type="button" value="First" onclick="FirstAnimation();" />
&nbsp;&nbsp;

<input type="button" value="Next" onclick="NextAnimation();" />
&nbsp;&nbsp;

<input type="button" value="Previous" onclick="PreviousAnimation();" />
&nbsp;&nbsp;

<input type="button" value="Last" onclick="LastAnimation();" />
&nbsp;&nbsp;

<br />
<br />
<input type="button" value="Check Animation State" onclick="IsPlayingAnimation();" />

<br />
<br />
<input type="button" value="Display Current Point Title/Description" onclick="DisplayTitleDescAnimation();" />

<script type="text/javascript">
    function PlayAnimation(){
        $find("<%=SimpleAnimationExtender1.ClientID%>").Play();
    }
    function StopAnimation(){
        $find("<%=SimpleAnimationExtender1.ClientID%>").Stop();
    }
    function NextAnimation(){
        $find("<%=SimpleAnimationExtender1.ClientID%>").Next();
    }
    function PreviousAnimation(){
        $find("<%=SimpleAnimationExtender1.ClientID%>").Previous();
    }
    function FirstAnimation(){
        $find("<%=SimpleAnimationExtender1.ClientID%>").First();
    }
    function LastAnimation(){
        $find("<%=SimpleAnimationExtender1.ClientID%>").Last();
    }
    function IsPlayingAnimation(){
        if ($find("<%=SimpleAnimationExtender1.ClientID%>").IsPlaying())
        {
            alert("Currently Playing");
        }
        else
        {
            alert("Currently Stopped");
        }
    }
    function DisplayTitleDescAnimation(){
        var extender = $find("<%=SimpleAnimationExtender1.ClientID%>");
        alert(extender.GetCurrentPointTitle() + "\n" + extender.GetCurrentPointDescription());
    }
</script>

</asp:Content>

