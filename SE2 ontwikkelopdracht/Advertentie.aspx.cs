using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE2_ontwikkelopdracht
{
    public partial class Advertentie : System.Web.UI.Page
    {
        DatabaseClass db = new DatabaseClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdvNr"].ToString() != null)
            {
                List<string> urls = db.GetURL(Session["AdvNr"].ToString());
                Img.ImageUrl = urls.First<string>();
            }
        }
    }
}