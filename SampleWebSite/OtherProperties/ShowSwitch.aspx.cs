using System;

public partial class OtherProperties_ShowSwitch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lbSetTrue_Click(object sender, EventArgs e)
    {
        Map1.ShowSwitch = true;
    }

    protected void lbSetFalse_Click(object sender, EventArgs e)
    {
        Map1.ShowSwitch = false;
    }
}