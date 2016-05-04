using System;
using System.Web.UI.WebControls;
using Simplovation.Web.Maps.VE;

public partial class Events_OnChangeMapStyle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DisplayMapType();
        }
    }

    protected void Map1_ChangeMapType(object sender, AsyncMapEventArgs e)
    {
        DisplayMapType();
    }

    private void DisplayMapType()
    {
        Literal litMapStyle = UpdatePanel_MapTypeDisplay.ContentTemplateContainer.FindControl("litMapType") as Literal;
        if (litMapStyle != null)
        {
            if (Map1.MapType == Simplovation.Web.Maps.VE.MapType.Aerial)
                litMapStyle.Text = "Aerial";
            else if (Map1.MapType == Simplovation.Web.Maps.VE.MapType.Hybrid)
                litMapStyle.Text = "Hybrid";
            else if (Map1.MapType == Simplovation.Web.Maps.VE.MapType.Birdseye)
                litMapStyle.Text = "Birdseye";
            else
                litMapStyle.Text = "Road";
        }
    }
}