using System;
using System.Web.UI.WebControls;
using Simplovation.Web.Maps.VE;

public partial class Events_OnChangeView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Map1_ChangeView(object sender, AsyncMapEventArgs e)
    {
        Literal litMapZoom = UpdatePanel_MapViewDisplay.ContentTemplateContainer.FindControl("litMapZoom") as Literal;
        Literal litMapLatitude = UpdatePanel_MapViewDisplay.ContentTemplateContainer.FindControl("litMapLatitude") as Literal;
        Literal litMapLongitude = UpdatePanel_MapViewDisplay.ContentTemplateContainer.FindControl("litMapLongitude") as Literal;
        
        if (litMapZoom != null)
        {
            litMapZoom.Text = e.zoomLevel.ToString();
        }

        if (litMapLatitude != null)
        {
            if (e.latlong == null)
            {
                litMapLatitude.Text = "?";
            }
            else
            {
                litMapLatitude.Text = e.latlong.Latitude.ToString();
            }
        }

        if (litMapLongitude != null)
        {
            if (e.latlong == null)
            {
                litMapLongitude.Text = "?";
            }
            else
            {
                litMapLongitude.Text = e.latlong.Longitude.ToString();
            }
        }
    }
}