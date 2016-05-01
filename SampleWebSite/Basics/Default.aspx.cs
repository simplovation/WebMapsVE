using System;
using Simplovation.Web.Maps.VE;
using System.Web;

public partial class Basics_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void lbZoomIn_Click(object sender, EventArgs e)
    {
        Map1.Zoom++;
    }

    protected void lbZoomOut_Click(object sender, EventArgs e)
    {
        Map1.Zoom--;
    }

    protected void lbMapViewRoad_Click(object sender, EventArgs e)
    {
        Map1.MapStyle = Simplovation.Web.Maps.VE.MapStyle.Road;
    }

    protected void lbMapViewAerial_Click(object sender, EventArgs e)
    {
        Map1.MapStyle = Simplovation.Web.Maps.VE.MapStyle.Aerial;
    }

    protected void lbMapViewHybrid_Click(object sender, EventArgs e)
    {
        Map1.MapStyle = Simplovation.Web.Maps.VE.MapStyle.Hybrid;
    }

    protected void lbMapViewBirdseye_Click(object sender, EventArgs e)
    {
        Map1.MapStyle = Simplovation.Web.Maps.VE.MapStyle.Birdseye;
    }

    protected void lbMapViewShaded_Click(object sender, EventArgs e)
    {
        Map1.MapStyle = Simplovation.Web.Maps.VE.MapStyle.Shaded;
    }

    protected void lbShapesPushpin_Click(object sender, EventArgs e)
    {
        Simplovation.Web.Maps.VE.Shape s = new Simplovation.Web.Maps.VE.Shape(Map1.LatLong);

        s.Title = "Pushpin";
        s.Description = "Added " + DateTime.Now.ToString();
        s.MoreInfoURL = "~/MorePushpinInfo.aspx";
        s.PhotoURL = "~/images/PushpinImage.png";

        Map1.AddShape(s);
    }

    protected void lbShapesCustomPushpin_Click(object sender, EventArgs e)
    {
        Simplovation.Web.Maps.VE.Shape s = new Simplovation.Web.Maps.VE.Shape(Map1.LatLong);
        s.Title = "Custom Pushpin";
        
        s.Description = "<div>Added:&nbsp;" + DateTime.Now.ToString() + "</div>";

        s.MoreInfoURL = "~/MorePushpinInfo.aspx";

        // Set a CustomIcon for the Shape to use
        s.CustomIcon = new CustomIconSpecification();
        s.CustomIcon.Image = VirtualPathUtility.ToAbsolute("~/DynamicSearch/icon.png");

        /*
        // Add HTML to be used for the Custom Icon that this Pushpin Shape will use
        s.CustomIcon = new CustomIconSpecification("<div style='background-color: lightblue; color: black; border: solid 1px red; padding: 2px; font-weight: bold;'>" + (Map1.Layers[0].Shapes.Count + 1) + "</div>");
        */

        Map1.AddShape(s);
    }

    protected void lbShapesPolyline_Click(object sender, EventArgs e)
    {
        Simplovation.Web.Maps.VE.LatLong[] points = new Simplovation.Web.Maps.VE.LatLong[4];
        points[0] = new Simplovation.Web.Maps.VE.LatLong(Map1.Latitude - 4, Map1.Longitude);
        points[1] = new Simplovation.Web.Maps.VE.LatLong(Map1.Latitude - 8, Map1.Longitude);
        points[2] = new Simplovation.Web.Maps.VE.LatLong(Map1.Latitude - 8, Map1.Longitude + 7);
        points[3] = new Simplovation.Web.Maps.VE.LatLong(Map1.Latitude - 4, Map1.Longitude + 4);

        Simplovation.Web.Maps.VE.Shape s = new Simplovation.Web.Maps.VE.Shape(Simplovation.Web.Maps.VE.ShapeType.Polyline, points);

        Map1.AddShape(s);
    }

    protected void lbShapesPolygon_Click(object sender, EventArgs e)
    {
        Simplovation.Web.Maps.VE.LatLong[] points = new Simplovation.Web.Maps.VE.LatLong[6];
        points[0] = new Simplovation.Web.Maps.VE.LatLong(46.1950421086602, -97.03125);
        points[1] = new Simplovation.Web.Maps.VE.LatLong(46.0122238406324, -104.326171875);
        points[2] = new Simplovation.Web.Maps.VE.LatLong(43.1330611624061, -104.326171875);
        points[3] = new Simplovation.Web.Maps.VE.LatLong(42.9403392336318, -96.943359375);
        points[4] = new Simplovation.Web.Maps.VE.LatLong(45.2748864370489, -96.767578125);
        points[5] = new Simplovation.Web.Maps.VE.LatLong(45.7061792853308, -97.3828125);

        Simplovation.Web.Maps.VE.Shape s = new Simplovation.Web.Maps.VE.Shape(Simplovation.Web.Maps.VE.ShapeType.Polygon, points);

        s.FillColor = Simplovation.Web.Maps.VE.Color.Red;
        s.FillColor.A = 0.5; // make sure the color is semi-transparent

        s.LineColor = Simplovation.Web.Maps.VE.Color.Blue;
        
        s.LineWidth = 2; // make the line width 2 pixels

        Map1.AddShape(s);
    }

    protected void lbShapesClearAll_Click(object sender, EventArgs e)
    {
        Map1.Layers.Clear();
    }

    protected void lbTrafficShow_Click(object sender, EventArgs e)
    {
        Map1.ShowTraffic = true;
    }

    protected void lbTrafficClear_Click(object sender, EventArgs e)
    {
        Map1.ShowTraffic = false;
    }

    protected void lbTrafficShowLegend_Click(object sender, EventArgs e)
    {
        Map1.ShowTrafficLegend = true;
    }

    protected void lbTrafficHideLegend_Click(object sender, EventArgs e)
    {
        Map1.ShowTrafficLegend = false;
    }

    protected void lbMapSizeIncreaseWidth_Click(object sender, EventArgs e)
    {
        Map1.Width = new System.Web.UI.WebControls.Unit(Map1.Width.Value + 100);
    }

    protected void lbMapSizeIncreaseHeight_Click(object sender, EventArgs e)
    {
        Map1.Height = new System.Web.UI.WebControls.Unit(Map1.Height.Value + 100);
    }

    protected void lbMapSizeDecreaseWidth_Click(object sender, EventArgs e)
    {
        Map1.Width = new System.Web.UI.WebControls.Unit(Map1.Width.Value - 100);
    }

    protected void lbMapSizeDecreaseHeight_Click(object sender, EventArgs e)
    {
        Map1.Height = new System.Web.UI.WebControls.Unit(Map1.Height.Value - 100);
    }
}