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
          
               /*if(RememberMe.Checked == true)
                {
                        FormsAuthentication.SetAuthCookie(LoginControl.UserName.ToLower(), LoginControl.RememberMeSet);
                }
                    //Create Session
                    Session["Login"] = LoginControl.UserName.ToLower();
                    e.Authenticated = true;
                */
        }
    }
}