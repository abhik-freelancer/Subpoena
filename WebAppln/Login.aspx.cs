using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LINQ;
namespace WebAppln
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_SignIn_Click(object sender, EventArgs e)
        {
            AccreditationDataContext objDb = new AccreditationDataContext();
            objDb.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            //LINQ.User client = objDb.Users.Where(D => D.UserName == txtUserName.Text).Single();
            int cnt = objDb.Users.Where(D => D.UserName == txtUserName.Text).Count();
            if(cnt==1)
            {
                Response.Redirect("ContentPages/Dashboard.aspx");
            }
               

        }
    }
}