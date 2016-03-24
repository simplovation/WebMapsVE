using System;

public partial class OtherProperties_DashboardSize : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lbNormal_Click(object sender, EventArgs e)
    {
        Map1.DashboardSize = Simplovation.Web.Maps.VE.DashboardSize.Normal;
    }

    protected void lbSmall_Click(object sender, EventArgs e)
    {
        Map1.DashboardSize = Simplovation.Web.Maps.VE.DashboardSize.Small;
    }

    protected void lbTiny_Click(object sender, EventArgs e)
    {
        Map1.DashboardSize = Simplovation.Web.Maps.VE.DashboardSize.Tiny;
    }
}