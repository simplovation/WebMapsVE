using System;
using System.Web.UI.WebControls;
using Simplovation.Web.Maps.VE;

public partial class Events_OnEndPan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Map1_EndPan(object sender, AsyncMapEventArgs e)
    {
        Literal litMapLatitude = UpdatePanel_MapViewDisplay.ContentTemplateContainer.FindControl("litMapLatitude") as Literal;
        Literal litMapLongitude = UpdatePanel_MapViewDisplay.ContentTemplateContainer.FindControl("litMapLongitude") as Literal;

        if (litMapLatitude != null)
        {
            litMapLatitude.Text = e.latlong.Latitude.ToString();
        }

        if (litMapLongitude != null)
        {
            litMapLongitude.Text = e.latlong.Longitude.ToString();
        }
    }
}