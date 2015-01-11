using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using Oracle.DataAccess.Client;
using System.Data;

namespace SE2_ontwikkelopdracht
{
    public partial class Startpagina : System.Web.UI.Page
    {
        DatabaseClass db = new DatabaseClass();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void GridView1_RowCommand(object sender, EventArgs e)
        {
           
            Response.Redirect("/Default.aspx");
        }

        protected void btnPlaats_Click(object sender, EventArgs e)
        {
            if(Session["LogIn"] != null)
            {
                Response.Redirect("/PlaatsAdvertentie.aspx");
            }
            else
            {
                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=\"\"JavaScript\"\">alert(\"Log eerst in!\")</SCRIPT>");
            }
            
        }

        protected void btnZoek_Click(object sender, EventArgs e)
        {
            
            if (TextBox1.Text != null)
            {
                DataSet ds1 = new DataSet();
                ds1 = db.GetInfo(TextBox1.Text);
                GridView1.DataSourceID = null;
                GridView1.DataSource = ds1;
                GridView1.DataBind();
            }

        }

        protected void lblAuto_Click(object sender, EventArgs e)
        {
            DataSet ds1 = new DataSet();
            ds1 = db.GetCat("1");
            GridView1.DataSourceID = null;
            GridView1.DataSource = ds1;
            GridView1.DataBind();
        }

        protected void lblOnderdelen_Click(object sender, EventArgs e)
        {
            DataSet ds1 = new DataSet();
            ds1 = db.GetCat("2");
            GridView1.DataSourceID = null;
            GridView1.DataSource = ds1;
            GridView1.DataBind();
        }

        protected void lblKeuken_Click(object sender, EventArgs e)
        {
            DataSet ds1 = new DataSet();
            ds1 = db.GetCat("3");
            GridView1.DataSourceID = null;
            GridView1.DataSource = ds1;
            GridView1.DataBind();
        }

        protected void lblTuin_Click(object sender, EventArgs e)
        {
            DataSet ds1 = new DataSet();
            ds1 = db.GetCat("4");
            GridView1.DataSourceID = null;
            GridView1.DataSource = ds1;
            GridView1.DataBind();
        }

        protected void lblBoek_Click(object sender, EventArgs e)
        {
            DataSet ds1 = new DataSet();
            ds1 = db.GetCat("5");
            GridView1.DataSourceID = null;
            GridView1.DataSource = ds1;
            GridView1.DataBind();
        }
    }
}