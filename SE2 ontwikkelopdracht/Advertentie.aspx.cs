using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

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
                if(urls.First<string>() != null)
                {
                    Img1.ImageUrl = urls.First<string>();
                    urls.Remove(Img1.ImageUrl);
                }
                if (urls.First<string>() != null)
                {
                    Img2.ImageUrl = urls.First<string>();
                    urls.Remove(Img2.ImageUrl);
                }
                if (urls.First<string>() != null)
                {
                    Img3.ImageUrl = urls.First<string>();
                    urls.Remove(Img3.ImageUrl);
                }
                string temp = Session["AdvNr"].ToString();
                TextBox1.Text = db.GetOmschrijving(temp);
                string sql = "SELECT DBI292158.ACCOUNT.NAAM, DBI292158.BOD.BEDRAG FROM DBI292158.ACCOUNT INNER JOIN DBI292158.BOD ON DBI292158.ACCOUNT.ACCOUNTNR = DBI292158.BOD.ACCOUNTNR WHERE DBI292158.BOD.ADVERTENTIENR = '"+ temp+ "'";
                DataSet ds2 = new DataSet();
                ds2 = db.GetInfo(sql);
                GridView1.DataSourceID = null;
                GridView1.DataSource = ds2;
                GridView1.DataBind();
                
            }
        }

        protected void btnBied_Click(object sender, EventArgs e)
        {
            if(Session["LogIn"] != null)
            {
                db.Bied(Request.Cookies["LogIn"].Value, Session["AdvNr"].ToString(), TextBox3.Text + "." + TextBox2.Text);
                Response.Write("<SCRIPT LANGUAGE=\"\"JavaScript\"\">alert(\"Bod geplaatst!\")</SCRIPT>");
            }
            else
            {
                Response.Write("<SCRIPT LANGUAGE=\"\"JavaScript\"\">alert(\"Log eerst in!\")</SCRIPT>");
            }
        }
    }
}