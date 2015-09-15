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
            if(txtUserName.Text !="" && txtPassword.Text !="")
            {
            AccreditationDataContext objDb = new AccreditationDataContext();
            objDb.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            //LINQ.User client = objDb.Users.Where(D => D.UserName == txtUserName.Text).Single();
            var user = objDb.TblUserRegistrations.Where(D => D.UserEmail == txtUserName.Text.Trim() && D.Active==true).FirstOrDefault();
            if (user != null)
            {
                if (user.HashPass == DbConnection.GetHash(txtPassword.Text))
                {
                    Session["UserEmail"] = txtUserName.Text.Trim();
                    Session["GroupId"] = user.Group;
                    Session["UserRole"] = user.userRole;
                    if (user.userRole == "Detective")
                    {
                        Session["HomePage"] = "PageforDetective.aspx";
                        Response.Redirect("ContentPages/PageforDetective.aspx");
                    }
                    else if (user.userRole == "subpoenaproducer")
                    {
                        Session["HomePage"] = "HomePageForSubProducerUsers.aspx";
                        Response.Redirect("ContentPages/HomePageForSubProducerUsers.aspx");

                    }
                    else if (user.userRole == "Otherusers")
                    {
                        Session["HomePage"] = "OtherUsers.aspx";
                        Response.Redirect("ContentPages/OtherUsers.aspx");

                    }
                    else if (user.userRole == "SuperAdmin" || user.userRole == "Admin")
                    {
                        Session["HomePage"] = "AdminUsers.aspx";
                        Response.Redirect("ContentPages/AdminUsers.aspx");

                    }
                    else if (user.userRole == "GroupLeader")
                    {
                        Session["HomePage"] = "Dashboard.aspx";
                        Response.Redirect("ContentPages/Dashboard.aspx");

                    }
                }
                else
                {
                    lbFailureText.Text = "OOPS! Password mismatch";

                }
            }
            else
            {
                lbFailureText.Text = "This is not active";

            }

            }
            else
            {
                lbFailureText.Text = "Please Enter Username/Password";

            }
               

        }
    }
}