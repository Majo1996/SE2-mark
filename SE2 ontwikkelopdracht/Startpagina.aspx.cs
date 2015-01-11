using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace SE2_ontwikkelopdracht
{
    public partial class Startpagina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, EventArgs e)
        {
           
            Response.Redirect("/Default.aspx");
        }

        protected void btnPlaats_Click(object sender, EventArgs e)
        {
            Response.Redirect("/default.aspx");
        }

    }
}