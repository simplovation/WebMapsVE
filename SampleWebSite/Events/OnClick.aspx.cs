using System;
using Simplovation.Web.Maps.VE;

public partial class Events_OnClick : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Map1_OnClick(object sender, AsyncMapEventArgs e)
    {
        if (e.leftMouseButton)
        {
            if (e.Shape == null)
            {
                //Add pushpin where the user clicked.
                Simplovation.Web.Maps.VE.Shape shape = new Simplovation.Web.Maps.VE.Shape(e.latlong);
                shape.Title = "OnClick Shape";
                shape.Description = "Lat: " + e.latlong.Latitude.ToString() + "<br/>Lng: " + e.latlong.Longitude.ToString();
                
                Map1.AddShape(shape);
            }
            else
            {
                //Center on the pushpin the user clicked
                Map1.LatLong = e.Shape.Points[0];
            }
        }
        else if (e.rightMouseButton)
        {
            if (e.Shape != null)
            {
                //If the user right-clicked on a pushpin, remove it from the map
                Map1.DeleteShape(e.Shape);
            }
        }
    }
}