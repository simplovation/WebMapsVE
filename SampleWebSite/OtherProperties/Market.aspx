<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Market.aspx.cs" Inherits="OtherProperties_Market" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Map Properties - Market
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
The only non-English market supported is Japanese; this is because this is the only non-English market that Virtual Earth supports at this time. This property can only be set on the initial load of the page, and cannot be changed on an Asynchronous Postback.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
<br />
Select culture for localization:
<asp:DropDownList runat="server" ID="ddlMarket" AutoPostBack="true" OnSelectedIndexChanged="ddlMarket_SelectedIndexChanged">
    <asp:ListItem Text="Spanish - Spain (es-es)" Value="15" Selected="True"></asp:ListItem>
    <asp:ListItem Text="English - United States (en-us)" Value="1"></asp:ListItem>
    <asp:ListItem Text="French - France (fr-fr)" Value="10"></asp:ListItem>
    <asp:ListItem Text="Italian - Italy (it-it)" Value="12"></asp:ListItem>
    <asp:ListItem Text="Japanese - Japan (ja-jp)" Value="5"></asp:ListItem>
    

    <%-- 
    MS Virtual Earth claims support for these languages, but upon testing they do not seem to work.
    We added support to Web.Maps.VE for them so you can use them as soon as Microsoft finishes up
    the support for them within MS Virtual Earth.
    
    <asp:ListItem Text="English - Canada (en-ca)" Value="3"></asp:ListItem>
    <asp:ListItem Text="English - United Kingdom (en-gb)" Value="4"></asp:ListItem>
    <asp:ListItem Text="Czech - Czech Republic (cs-cz)" Value="6"></asp:ListItem>
    <asp:ListItem Text="Danish - Denmark (da-dk)" Value="7"></asp:ListItem>
    <asp:ListItem Text="Dutch - The Netherlands (nl-nl)" Value="8"></asp:ListItem>
    <asp:ListItem Text="Finnish - Finland (fi-fi)" Value="9"></asp:ListItem>
    <asp:ListItem Text="German - Germany (de-de)" Value="11"></asp:ListItem>
    <asp:ListItem Text="Norwegian - Norway (nb-no)" Value="13"></asp:ListItem>
    <asp:ListItem Text="Portuguese - Portugal (pt-pt)" Value="14"></asp:ListItem>
    <asp:ListItem Text="Swedish - Sweden (sv-se)" Value="16"></asp:ListItem>
    --%>
</asp:DropDownList>
<br />
<Simplovation:Map runat="server" ID="Map1" Width="700px" Height="450px" CssClass="map" Market="ja_jp" />

</asp:Content>

