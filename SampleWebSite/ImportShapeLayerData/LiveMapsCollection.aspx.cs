using System;
using Simplovation.Web.Maps.VE;

public partial class ImportShapeLayerData_LiveMapsCollection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Map1.ImportShapeLayerDataLoaded += new Map.ImportShapeLayerDataLoadedEventHandler(Map1_ImportShapeLayerDataLoaded);

        if (!ScriptManager1.IsInAsyncPostBack)
        {
            ShapeSourceSpecification shapeSource = new ShapeSourceSpecification(DataType.VECollection, "546E7E30AC2C5011!451");

            Map1.ImportShapeLayerData(shapeSource, true);
        }
    }

    protected void Map1_ImportShapeLayerDataLoaded(object sender, ImportShapeLayerDataEventArgs e)
    {
        lblMessage.Text = "Collection loaded. There are " + e.ShapeLayer.Shapes.Count.ToString() + " items in this list.";
    }
}
