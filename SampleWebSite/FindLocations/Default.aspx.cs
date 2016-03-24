using System;
using Simplovation.Web.Maps.VE;

public partial class FindLocations_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Map1_Click(object sender, AsyncMapEventArgs e)
    {
        Map1.FindLocations(e.latlong);
    }

    protected void Map1_FindLocationsLoaded(object sender, FindLocationsEventArgs e)
    {
        lblLatitude.Text = e.Location.Latitude.ToString();
        lblLongitude.Text = e.Location.Longitude.ToString();

        rptrPlaces.DataSource = e.Places;
        rptrPlaces.DataBind();
    }
}