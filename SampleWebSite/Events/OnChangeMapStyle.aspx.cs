using System;
using System.Web.UI.WebControls;
using Simplovation.Web.Maps.VE;

public partial class Events_OnChangeMapStyle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DisplayMapStyle();
        }
    }

    protected void Map1_ChangeMapStyle(object sender, AsyncMapEventArgs e)
    {
        DisplayMapStyle();
    }

    private void DisplayMapStyle()
    {
        Literal litMapStyle = UpdatePanel_MapStyleDisplay.ContentTemplateContainer.FindControl("litMapStyle") as Literal;
        if (litMapStyle != null)
        {
            if (Map1.MapStyle == Simplovation.Web.Maps.VE.MapStyle.Aerial)
                litMapStyle.Text = "Aerial";
            else if (Map1.MapStyle == Simplovation.Web.Maps.VE.MapStyle.Hybrid)
                litMapStyle.Text = "Hybrid";
            else if (Map1.MapStyle == Simplovation.Web.Maps.VE.MapStyle.Birdseye)
                litMapStyle.Text = "Birdseye";
            else
                litMapStyle.Text = "Road";
        }
    }
}