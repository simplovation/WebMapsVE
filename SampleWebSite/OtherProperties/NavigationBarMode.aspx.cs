using System;

public partial class OtherProperties_NavigationBarMode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lbNormal_Click(object sender, EventArgs e)
    {
        Map1.NavigationBarMode = Simplovation.Web.Maps.VE.NavigationBarMode.Normal;
    }

    protected void lbCompact_Click(object sender, EventArgs e)
    {
        Map1.NavigationBarMode = Simplovation.Web.Maps.VE.NavigationBarMode.Compact;
    }
}