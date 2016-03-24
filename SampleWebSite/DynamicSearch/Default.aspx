<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="DynamicSearch_Default" Title="Untitled Page" %>
<%@ Register Assembly="Simplovation.Web.Maps.VE" Namespace="Simplovation.Web.Maps.VE" TagPrefix="Simplovation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_PageTitle" Runat="Server">
Dynamic Map Search Example
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_PageDescription" Runat="Server">
This is a simple example demonstrating how to implement dynamic searching capabilities using the viewable map area as your location criteria in your search.<br />
The data that is used in this example is a partial list of the school districts within the state of Wisconsin.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Main" Runat="Server">

    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

    <asp:XmlDataSource ID="dsSchoolDistrict" runat="server" DataFile="~/App_Data/DynamicSearch/SchoolDistricts.xml" XPath="schooldistricts/schooldistrict"></asp:XmlDataSource>

    <asp:UpdatePanel runat="server" ID="UpdatePanel_DynamicMapSearch">
        <ContentTemplate>
            <strong>Total Points Plotted:</strong>&nbsp;<asp:Literal runat="server" ID="litTotalPointCount"></asp:Literal>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <Simplovation:Map runat="server" ID="Map1" Width="700px" Height="500px" CssClass="map"
        AsyncPostbackPassShapes="false"
        Latitude="43.0889491834659"
        Longitude="-88.0128479003906"
        Zoom="11"
        OnChangeView="Map1_ChangeView"
        OnMapLoaded="Map1_MapLoaded"
        />
    
    <br />
    <asp:UpdateProgress runat="server" ID="UpdateProgress1" DisplayAfter="0">
        <ProgressTemplate>
            <div style="background-color: Red;">
                <strong>Loading School Districts...</strong>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    
    <asp:UpdatePanel runat="server" ID="UpdatePanel_GridView">
        <ContentTemplate>
        
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnDataBound="GridView1_DataBound">
                <HeaderStyle BackColor="#353535" ForeColor="#ffffff" />
                <RowStyle BorderWidth="1px" BorderColor="#353535" BorderStyle="solid" />
                <Columns>
                    <%--
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                    <asp:CommandField ShowSelectButton="true" />
                    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
                    {
                        // Get the Tag of the Shape that corresponds to the Row in the GridView
                        var shapeTag = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text;

                        // var jsScript = string.Format("ShowSchoolInfoBox({0});", shapeTag);
                    }
                    --%>
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="address" HeaderText="address" SortExpression="address" />
                    <asp:BoundField DataField="latitude" HeaderText="latitude" SortExpression="latitude" />
                    <asp:BoundField DataField="longitude" HeaderText="longitude" SortExpression="longitude" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <nobr>
                                <a href="javascript:ShowSchoolInfoBox('<%# Eval("Name") %>');">Show InfoBox</a>
                            </nobr>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
    
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <script type="text/javascript">
        function ShowSchoolInfoBox(tag)
        {
            var map = $find("<%=Map1.ClientID%>");
        
            map.HideInfoBox();
        
            var shape = map.GetShapeByTag(tag);
            map.ShowInfoBox(shape);
        }
    </script>
    
</asp:Content>

