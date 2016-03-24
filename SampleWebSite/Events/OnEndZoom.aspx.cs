using System;
using System.Web.UI.WebControls;
using Simplovation.Web.Maps.VE;

public partial class Events_OnEndZoom : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Map1_EndZoom(object sender, AsyncMapEventArgs e)
    {
        Literal litMapZoom = UpdatePanel_MapZoomDisplay.ContentTemplateContainer.FindControl("litMapZoom") as Literal;

        if (litMapZoom != null)
        {
            litMapZoom.Text = e.zoomLevel.ToString();
        }
    }
}