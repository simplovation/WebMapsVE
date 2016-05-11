<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Map.aspx.cs" Inherits="JavaScript_Events_Map" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Advanced JavaScript - Map Event Handling
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
        <td>maptypechanged</td>
        <td><a href="#" onclick='attachevent("maptypechanged");'>Attach</a></td>
        <td><a href="#" onclick='detachevent("maptypechanged");'>Detach</a></td>
    </tr>
    <tr>
        <td>onchangeview</td>
        <td><a href="#" onclick='attachevent("onchangeview");'>Attach</a></td>
        <td><a href="#" onclick='detachevent("onchangeview");'>Detach</a></td>
    </tr>
    <tr>
        <td>onendzoom</td>
        <td><a href="#" onclick='attachevent("onendzoom");'>Attach</a></td>
        <td><a href="#" onclick='detachevent("onendzoom");'>Detach</a></td>
    </tr>
    <tr>
        <td>onerror</td>
        <td><a href="#" onclick='attachevent("onerror");'>Attach</a></td>
        <td><a href="#" onclick='detachevent("onerror");'>Detach</a></td>
    </tr>
     <tr>
        <td>oninitmode</td>
        <td><a href="#" onclick='attachevent("oninitmode");'>Attach</a></td>
        <td><a href="#" onclick='detachevent("oninitmode");'>Detach</a></td>
    </tr>
     <tr>
        <td>onmodenotavailable</td>
        <td><a href="#" onclick='attachevent("onmodenotavailable");'>Attach</a></td>
        <td><a href="#" onclick='detachevent("onmodenotavailable");'>Detach</a></td>
    </tr>
     <tr>
        <td>onobliqueenter</td>
        <td><a href="#" onclick='attachevent("onobliqueenter");'>Attach</a></td>
        <td><a href="#" onclick='detachevent("onobliqueenter");'>Detach</a></td>
    </tr>
     <tr>
        <td>onobliqueleave</td>
        <td><a href="#" onclick='attachevent("onobliqueleave");'>Attach</a></td>
        <td><a href="#" onclick='detachevent("onobliqueleave");'>Detach</a></td>
    </tr>
    <tr>
        <td>onstartzoom</td>
        <td><a href="#" onclick='attachevent("onstartzoom");'>Attach</a></td>
        <td><a href="#" onclick='detachevent("onstartzoom");'>Detach</a></td>
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
    // The js code below will attach the maptypechanged event handler
    // as soon as the page finishes loading.
    Sys.Application.add_load(myAppLoaded);
    function myAppLoaded()
    {
        attachevent("maptypechanged");
    }
    */
</script>

</asp:Content>

