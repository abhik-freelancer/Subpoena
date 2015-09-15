using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
//using BLL;
using LINQ;
using System.Security.Permissions;

namespace Website.Pages
{
    public partial class GroupList : System.Web.UI.Page
    {
        public string sqlQuery = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GroupId"] == null || Session["UserEmail"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (Request.QueryString["Type"] == "deleted")
            {
                Delete(int.Parse(Request.QueryString["DeleteId"].ToString()));
                Response.Redirect("GroupList.aspx");
                return;
            }
            else
            {

                sqlQuery = "SELECT  GrpId, GrpName, Address1, Address2, City, Zipcode  FROM  (SELECT  ROW_NUMBER() OVER (ORDER BY   ##ID##   ##desc##) as row,* FROM TblGroupCreation  WHERE  Active=1  and  ##filters## ) L   Where   ##paging##  ";
            }
        }

        protected void Anchor_Click(Object sender, EventArgs e)
        {
            //Code which needs to be executed on serverside
            Response.Write("<script>alert('Server Side Code is Executed')</script>");


        }


        #region  Delete Group
        public void Delete(int intDelGrp)
        {
            bool boolMess = false;
            try
            {
                AccreditationDataContext objDb = new AccreditationDataContext();
                objDb.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];

                LINQ.TblGroupCreation gc = objDb.TblGroupCreations.Where(D => D.GrpId == intDelGrp).Single();
                gc.Active = false;

                objDb.SubmitChanges();

                boolMess = true;
               // Console.WriteLine("ok");
               // Response.Redirect("GroupList.aspx");
            }
            catch (Exception ex)
            {
                boolMess = false;
            }

           
            return;
           // return boolMess;

        }
        #endregion

    }
}