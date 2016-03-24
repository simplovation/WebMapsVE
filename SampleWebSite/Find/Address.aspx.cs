using System;
using Simplovation.Web.Maps.VE;

public partial class Find_Address : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        FindArguments findArgs = new FindArguments();

        findArgs.Where = txtWhere.Text;

        Map1.Find(findArgs);
    }

    protected void Map1_FindLoaded(object sender, FindEventArgs e)
    {
        rptrFindResults.DataSource = e.Places;
        rptrFindResults.DataBind();
    }
}