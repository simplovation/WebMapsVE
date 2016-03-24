using System;
using Simplovation.Web.Maps.VE;

public partial class Events_OnMapLoaded : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Map1_MapLoaded(object sender, MapLoadedEventArgs e)
    {
        lblMessage.Text = "The map has finished loading.";
        lblMessage.ForeColor = System.Drawing.Color.Red;
    }
}