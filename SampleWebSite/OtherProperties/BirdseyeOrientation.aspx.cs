using System;

public partial class OtherProperties_Fixed : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnSetToNorth_Click(object sender, EventArgs e)
    {
        Map1.BirdseyeOrientation = Simplovation.Web.Maps.VE.Orientation.North;
    }

    protected void btnSetToSouth_Click(object sender, EventArgs e)
    {
        Map1.BirdseyeOrientation = Simplovation.Web.Maps.VE.Orientation.South;
    }

    protected void btnSetToEast_Click(object sender, EventArgs e)
    {
        Map1.BirdseyeOrientation = Simplovation.Web.Maps.VE.Orientation.East;
    }

    protected void btnSetToWest_Click(object sender, EventArgs e)
    {
        Map1.BirdseyeOrientation = Simplovation.Web.Maps.VE.Orientation.West;
    }
}