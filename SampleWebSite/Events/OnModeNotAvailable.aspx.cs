using System;
using Simplovation.Web.Maps.VE;

public partial class Events_OnModeNotAvailable : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Map1_ModeNotAvailable(object sender, AsyncMapEventArgs e)
    {
        lblMessage.Text = "ModeNotAvailable Triggered";
    }
}