using System;

public partial class OtherProperties_Market : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlMarket_SelectedIndexChanged(sender, e);
    }

    protected void ddlMarket_SelectedIndexChanged(object sender, EventArgs e)
    {
        Map1.Market = (Simplovation.Web.Maps.VE.Market)int.Parse(ddlMarket.SelectedValue);
    }
}