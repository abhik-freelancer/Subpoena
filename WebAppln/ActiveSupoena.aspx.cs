using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LINQ;

namespace WebAppln
{
    public partial class ActiveSupoena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string subpoeanaId = Request.QueryString["subpoeanaId"];
            string status = Request.QueryString["Status"];
             AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var stsubpoeanrs =
                (from c in db.TblSubpoenaFrms
                 where c.SubpoenaFrmId == int.Parse(subpoeanaId)
                 select c).FirstOrDefault();
            if (status == "Yes")
            {
                stsubpoeanrs.Status = "Close";
                stsubpoeanrs.UpdatedOn = DateTime.Now;
                db.SubmitChanges();
                lblMessage.Text = "Accepted subpoena";

            }
            else
            {
                stsubpoeanrs.Status = "Rejected";
                stsubpoeanrs.UpdatedOn = DateTime.Now;
                db.SubmitChanges();
                lblMessage.Text = "Rejected subpoena";
            }

        }
    }
}