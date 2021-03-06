﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE2_ontwikkelopdracht
{
    public partial class PlaatsAdvertentie : System.Web.UI.Page
    {
        DatabaseClass db = new DatabaseClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\Mark de Jong\Dropbox\";
            if(DropDownList1.Text != "Categorie" && TextBox1.Text != null && TextBox2.Text != null)
            {
                db.InsertAdv(Convert.ToString(catCheck(DropDownList1.SelectedValue)), Request.Cookies["LogIn"].Value, TextBox1.Text, TextBox2.Text);
                List<string> URLS = new List<string>();
                if(FileUpload1.FileName != "")
                {
                    
                    path += FileUpload1.FileName;
                    FileUpload1.SaveAs(path);
                    URLS.Add(path);
                }
                if (FileUpload2.FileName != "")
                {
                    
                    path += FileUpload2.FileName;
                    FileUpload2.SaveAs(path);
                    URLS.Add(path);
                }
                if (FileUpload3.FileName != "")
                {
                    
                    path += FileUpload2.FileName;
                    FileUpload2.SaveAs(path);
                    URLS.Add(path);
                }

                foreach(string s in URLS)
                {
                    db.InsertFoto(s);
                }
                Response.Write("<SCRIPT LANGUAGE=\"\"JavaScript\"\">alert(\"Advertentie geplaatst.\")</SCRIPT>");
            }
            else
            {
                Response.Write("<SCRIPT LANGUAGE=\"\"JavaScript\"\">alert(\"Vul alle velden in!\")</SCRIPT>");
            }
        }

        private int catCheck(string catnaam)
        {
            switch(catnaam)
            {
                case "Voertuigen":
                    return 1;
                    break;
                case "Auto onderdelen":
                    return 2;
                    break;
                case "Keuken":
                    return 3;
                    break;
                case "Tuin":
                    return 4;
                    break;
                case "Boeken":
                    return 5;
                    break;
                default:
                    return 1;
                    break;


            }
            
        }
    }
}