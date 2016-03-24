using System;
using System.Web;
using System.Web.UI.WebControls;
using Simplovation.Web.Maps.VE;

public partial class DynamicSearch_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.ScriptManager1.IsInAsyncPostBack)
        {
            // When in an Asynchronous Postback bind GridView1 to dsSchoolDistrict so School Districts get plotted on map
            // This keeps ALL School Districts from being plotted on the initial page load.
            GridView1.DataSource = dsSchoolDistrict;
        }
    }

    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        // Once the GridView below the map is bound to data; Add the School Districts to the map
        LoadSchoolDistrictsOnMap();
    }

    protected void Map1_MapLoaded(object sender, Simplovation.Web.Maps.VE.MapLoadedEventArgs e)
    {
        //Once map has loaded, then show the School Districts in the viewable area
        LoadSchoolDistrictsForView(e.MapView);
    }
        
    protected void Map1_ChangeView(object sender, AsyncMapEventArgs e)
    {
        //Show the School Districts in the viewable area
        LoadSchoolDistrictsForView(e.MapView);
    }

    protected void LoadSchoolDistrictsForView(LatLongRectangle mapView)
    {
        // Simulate some lag in the response time
        //int startDelay = DateTime.Now.Second; while((startDelay + 2) > DateTime.Now.Second) {}

        // Get the School Districts with the viewable area of the map
        double MinLat = mapView.MinLatitude;
        double MaxLat = mapView.MaxLatitude;

        double MinLng = mapView.MinLongitude;
        double MaxLng = mapView.MaxLongitude;

        dsSchoolDistrict.XPath = "schooldistricts/schooldistrict[" +
            "@latitude >= " + MinLat + " and " +
            "@latitude <= " + MaxLat + " and " +
            "@longitude >= " + MinLng + " and " +
            "@longitude <= " + MaxLng + "" +
            "]";

        GridView1.DataBind();
    }

    private void LoadSchoolDistrictsOnMap()
    {
        // Clear all existing shapes from the Map
        Map1.Layers.Clear();

        // Add new shapes to the map
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            Shape s = new Shape(new LatLong(double.Parse(GridView1.Rows[i].Cells[2].Text), double.Parse(GridView1.Rows[i].Cells[3].Text)));
            
            s.CustomIcon = new CustomIconSpecification();
            s.CustomIcon.Image = VirtualPathUtility.ToAbsolute("~/DynamicSearch/icon.png");

            s.Title = GridView1.Rows[i].Cells[0].Text; // School District Name
            s.Description = GridView1.Rows[i].Cells[1].Text; // School District Address

            s.Tag = s.Title;

            Map1.AddShape(s);
        }

        Literal lblShapeCount = UpdatePanel_DynamicMapSearch.FindControl("litTotalPointCount") as Literal;
        if (litTotalPointCount != null)
        {
            if (Map1.Layers.Count != 0)
                litTotalPointCount.Text = Map1.Layers[0].Shapes.Count.ToString();
            else
                litTotalPointCount.Text = "0";
        }
    }
}