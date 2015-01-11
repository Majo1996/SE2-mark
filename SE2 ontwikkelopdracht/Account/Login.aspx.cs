using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using SE2_ontwikkelopdracht.Models;

namespace SE2_ontwikkelopdracht.Account
{
    public partial class Login : Page
    {

        DatabaseClass db = new DatabaseClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            string check = db.Logincheck(UserName.Text, Password.Text);
            if (check == "nope")
            {
                Label1.Text = "Verkeerde gebruikers naam of wachtwoord";
            }
            else
            {
                if (RememberMe.Checked == true)
                {
                    HttpCookie LogIn = new HttpCookie("LogIn");
                    // Set the cookie value.
                    LogIn.Value = check;
                    // Add the cookie.
                    Response.Cookies.Add(LogIn);
                    
                }
                //Create Session
                Session["Login"] = UserName.Text;
                Response.Redirect("/Startpagina.aspx");
            }
        }
    }
}