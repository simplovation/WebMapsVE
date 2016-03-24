using System;
using System.Web.UI.WebControls;
using Simplovation.Web.Maps.VE;

public partial class Events_OnObliqueEnterLeave : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Map1_ObliqueEnter(object sender, AsyncMapEventArgs e)
    {
        Literal litMapObliqueMessage = UpdatePanel_MapObliqueDisplay.ContentTemplateContainer.FindControl("litMapObliqueMessage") as Literal;

        if (litMapObliqueMessage != null)
        {
            litMapObliqueMessage.Text = "<span style='color: green;'>Birdseye Imagery Available</span>";
        }
    }

    protected void Map1_ObliqueLeave(object sender, AsyncMapEventArgs e)
    {
        Literal litMapObliqueMessage = UpdatePanel_MapObliqueDisplay.ContentTemplateContainer.FindControl("litMapObliqueMessage") as Literal;

        if (litMapObliqueMessage != null)
        {
            litMapObliqueMessage.Text = "<span style='color: red;'>Birdseye Imagery NOT Available</span>";
        }
    }
}