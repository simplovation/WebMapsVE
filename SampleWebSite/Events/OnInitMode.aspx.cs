using System;
using Simplovation.Web.Maps.VE;

public partial class Events_OnInitMode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Map1_InitMode(object sender, AsyncMapEventArgs e)
    {
        lblMessage.Text = "Map Initialized - " + Map1.MapMode.ToString();
    }
}