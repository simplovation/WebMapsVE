using System;

public partial class Additional_CustomInfoBoxStyles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsInAsyncPostBack)
        {
            Simplovation.Web.Maps.VE.Shape myShape = new Simplovation.Web.Maps.VE.Shape(new Simplovation.Web.Maps.VE.LatLong(43.0432999514445, -87.9091644287109));
            myShape.Title = "CustomInfoBoxStyles Example";
            myShape.Description = "When the CustomInfoBoxStylesEnabled property is set to True it allows custom CSS to be used to style the InfoBox popup. The default value is False which means it uses the Default InfoBox styles.";
            Map1.AddShape(myShape);
        }
    }

    protected void lbUseCustom_Click(object sender, EventArgs e)
    {
        Map1.CustomInfoBoxStylesEnabled = true;
    }

    protected void lbUseDefault_Click(object sender, EventArgs e)
    {
        Map1.CustomInfoBoxStylesEnabled = false;
    }
}