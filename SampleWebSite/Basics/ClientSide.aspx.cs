using System;
using Simplovation.Web.Maps.VE;

public partial class Basics_ClientSide : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Shape s = new Shape(Map1.LatLong);
        s.Title = "Pushpin 001";
        Map1.AddShape(s);
    }
}