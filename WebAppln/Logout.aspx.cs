using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppln
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if (Session["userLogId"] != null && int.Parse(Session["userLogId"].ToString()) > 0)
                //{
                //    var currentUserLog = UserLog.Find(int.Parse(Session["userLogId"].ToString()));
                //    currentUserLog.User_Out = DateTime.Now;
                //    currentUserLog.Update();
                //}
                //Response.CreateCookie("HerculesAuthHash", "",
                //                      DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0)));
                //Response.RemoveCookie("HerculesAuthHash");
                Session["UserEmail"] = null;
                Session["GroupId"] = null;
                Session["UserRole"] = null;
                Session.Clear();
                Session.Remove("UserEmail");
                Session.Remove("GroupId");
                Session.Remove("UserRole");
                Response.Redirect("Login.aspx");
                return;
            }
            catch
            {

            }

        }
    }
}