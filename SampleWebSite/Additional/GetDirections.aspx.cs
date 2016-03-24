using System;
using System.Collections.Generic;
using Simplovation.Web.Maps.VE;

public partial class Additional_GetDirections : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnGetDirections_Click(object sender, EventArgs e)
    {
        // create our location array containing the two locations specified on the page
        List<object> locations = new List<object>();
        locations.Add(txtStart.Text);
        locations.Add(txtEnd.Text);

        //Map1.GetDirections(locations);

        // Set some custom RouteOptions, these are optional to set
        RouteOptions routeOptions = new RouteOptions();
        routeOptions.DistanceUnit = RouteDistanceUnit.Miles;
        routeOptions.DrawRoute = true;

        // Set the Route Mode
        if (ddlRouteMode.SelectedValue == "Driving")
        {
            routeOptions.RouteMode = RouteMode.Driving;
        }
        else
        {
            routeOptions.RouteMode = RouteMode.Walking;
        }

        // Semi-Transparent Red
        Color color = Color.Red;
        color.A = 0.7;
        routeOptions.RouteColor = color;

        routeOptions.RouteWeight = 4; //4 pixels
       
        // Tell the map to load the directions
        Map1.GetDirections(locations, routeOptions);

        // Display that the directions are loading
        lblDistance.Text = "Loading Directions...";
    }

    protected void btnClearDirections_Click(object sender, EventArgs e)
    {
        Map1.ClearDirections();
        lblDistance.Text = "";
        lblTime.Text = "";
        rptrDirections.DataSource = null;
        rptrDirections.DataBind();
    }

    // This Event is fired when the directions are loaded after calling the GetDirections method.
    protected void Map1_DirectionsLoaded(object sender, DirectionsLoadedEventArgs e)
    {
        // Show total length of Route
        lblDistance.Text = "Total Distance: " + e.Route.Distance.ToString("###,###,###.##") + " Miles";
        // Show total estimated Time to traverse route
        lblTime.Text = "Total Time: " + e.Route.Time.ToString() + " Seconds";

        // Show the directions using a Repeater control
        if (e.Route.RouteLegs.Count != 0) //Make sure routes have been returned
        {
            rptrDirections.DataSource = e.Route.RouteLegs[0].Itinerary.Items;
            rptrDirections.DataBind();
        }
    }
}