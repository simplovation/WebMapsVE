<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Mouse.aspx.cs" Inherits="JavaScript_Events_Mouse" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Advanced JavaScript - Mouse Event Handling
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

<table>
    <tr>
        <td valign="top">
            <textarea id="txtMessages" rows="27" cols="20"></textarea>
        </td>
        <td valign="top">
            <Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map"/>
        </td>
    </tr>
</table>
<table border="1">
    <tr>
        <th>Event</th>
        <th>Attach</th>
        <th>Detach</th>
    </tr>
    <tr>
        <td>click</td>
        <td><a href="#" onclick='attachevent("click");'>Attach</a></td>
        <td><a href="#" onclick='detachevent("click");'>Detach</a></td>
    </tr>
    <tr>
        <td>double click (dblclick)</td>
        <td><a href="#" onclick='attachevent("dblclick");'>Attach</a></td>
        <td><a href="#" onclick='detachevent("dblclick");'>Detach</a></td>
    </tr>
    <tr>
        <td>mousedown</td>
        <td><a href="#" onclick='attachevent("mousedown");'>Attach</a></td>
        <td><a href="#" onclick='detachevent("mousedown");'>Detach</a></td>
    </tr>
    <tr>
        <td>mousemove</td>
        <td><a href="#" onclick='attachevent("mousemove");'>Attach</a></td>
        <td><a href="#" onclick='detachevent("mousemove");'>Detach</a></td>
    </tr>
    <tr>
        <td>mouseout</td>
        <td><a href="#" onclick='attachevent("mouseout");'>Attach</a></td>
        <td><a href="#" onclick='detachevent("mouseout");'>Detach</a></td>
    </tr>
     <tr>
        <td>mouseup</td>
        <td><a href="#" onclick='attachevent("mouseup");'>Attach</a></td>
        <td><a href="#" onclick='detachevent("mouseup");'>Detach</a></td>
    </tr>
     <tr>
        <td>onmousewheel</td>
        <td><a href="#" onclick='attachevent("onmousewheel");'>Attach</a></td>
        <td><a href="#" onclick='detachevent("onmousewheel");'>Detach</a></td>
    </tr>
</table>

<script type="text/javascript">
    function MyEventHandler(sender, eventArgs)
    {
        // A Virtual Earth MapEvent object gets passed in the eventArgs parameter.
        var txt = $get("txtMessages");
        txt.value = eventArgs.eventName + "\n" + txt.value;
    }
    
    function attachevent(evtName)
    {
        $find("<%=Map1.ClientID%>").addHandler(evtName, MyEventHandler);
    }
    
    function detachevent(evtName)
    {
        $find("<%=Map1.ClientID%>").removeHandler(evtName, MyEventHandler);
    }

    /*
    // The js code below will attach the onchangemapstyle event handler
    // as soon as the page finishes loading.
    Sys.Application.add_load(myAppLoaded);
    function myAppLoaded()
    {
        attachevent("onchangemapstyle");
    }
    */
</script>

</asp:Content>

