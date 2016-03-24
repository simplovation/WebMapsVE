<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Keyboard.aspx.cs" Inherits="JavaScript_Events_Keyboard" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Advanced JavaScript - Keyboard Event Handling
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
        <td>onkeypress</td>
        <td><a href="#" onclick='attachevent("onkeypress");'>Attach</a></td>
        <td><a href="#" onclick='detachevent("onkeypress");'>Detach</a></td>
    </tr>
    <tr>
        <td>onkeydown</td>
        <td><a href="#" onclick='attachevent("onkeydown");'>Attach</a></td>
        <td><a href="#" onclick='detachevent("onkeydown");'>Detach</a></td>
    </tr>
    <tr>
        <td>onkeyup</td>
        <td><a href="#" onclick='attachevent("onkeyup");'>Attach</a></td>
        <td><a href="#" onclick='detachevent("onkeyup");'>Detach</a></td>
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

