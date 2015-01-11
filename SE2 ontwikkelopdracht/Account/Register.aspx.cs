using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using SE2_ontwikkelopdracht.Models;

namespace SE2_ontwikkelopdracht.Account
{
    public partial class Register : Page
    {
        DatabaseClass db = new DatabaseClass();
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            db.InsertAcc(UserName.Text, Password.Text);
        }
    }
}