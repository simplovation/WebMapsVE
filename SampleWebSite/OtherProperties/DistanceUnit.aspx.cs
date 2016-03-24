using System;

public partial class OtherProperties_DistanceUnit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lbSetKilometers_Click(object sender, EventArgs e)
    {
        Map1.DistanceUnit = Simplovation.Web.Maps.VE.DistanceUnit.Kilometers;
    }

    protected void lbSetMiles_Click(object sender, EventArgs e)
    {
        Map1.DistanceUnit = Simplovation.Web.Maps.VE.DistanceUnit.Miles;
    }
}