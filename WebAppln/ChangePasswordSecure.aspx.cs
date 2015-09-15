using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LINQ;

namespace WebAppln
{
    public partial class ChangePasswordSecure : System.Web.UI.Page
    {
        string Querystring = "";
      
        protected void Page_Load(object sender, EventArgs e)
        {
            Querystring = Request.QueryString["Userid"];
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            AccreditationDataContext objDb = new AccreditationDataContext();
            objDb.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            //LINQ.User client = objDb.Users.Where(D => D.UserName == txtUserName.Text).Single();
            var user = objDb.TblUserRegistrations.Where(D => D.UserEmail == Querystring.Trim()).FirstOrDefault();
            if (txtnewPassword.Text == txtconfirmmpass.Text)
            {
                if (user.TempPass == txttempass.Text)
                {
                    user.TempPass = "";
                    user.HashPass = DbConnection.GetHash(txtnewPassword.Text);
                    user.Active = true;
                    objDb.SubmitChanges();
                    Response.Redirect("Login.aspx");
                    return;
                }
                else
                {
                    lbFailureText.Text = "Wrong temporary password";

                }

            }
            else
            {

                lbFailureText.Text = "Please confirm password does not match";
            }

        }
    }
}