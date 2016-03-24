using System;
using System.Web.UI;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Simplovation.Web.Maps.VE v3.00.00 Sample Website";
    }
}