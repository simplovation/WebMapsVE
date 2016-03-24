using System;
using Simplovation.Web.Maps.VE;

public partial class OtherProperties_3DMode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Map1_ChangeView(object sender, AsyncMapEventArgs e)
    {
        lblAltitude.Text = Map1.Altitude.ToString();
        lblPitch.Text = Map1.Pitch.ToString();
        lblHeading.Text = Map1.Heading.ToString();
    }

    protected void lbSetAltitude_Click(object sender, EventArgs e)
    {
        Map1.Altitude = 5000;
    }

    protected void lbSetPitch_Click(object sender, EventArgs e)
    {
        Map1.Pitch = -40;
    }

    protected void lbSetHeading_Click(object sender, EventArgs e)
    {
        Map1.Heading = 90;
    }
}