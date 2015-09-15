using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using LINQ;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace WebAppln.ContentPages
{
    public partial class Dashboard : System.Web.UI.Page
    {
        public string eventlist = "";
        public TblUserRegistration CurrentUser
        {
            get
            {
                AccreditationDataContext db = new AccreditationDataContext();
                db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
                var user = (from c in db.TblUserRegistrations
                            where c.UserEmail == Session["UserEmail"].ToString()
                            select c).FirstOrDefault();
                return user;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GroupId"] == null || Session["UserEmail"] == null)
            {
                Response.Redirect("../Login.aspx");
            }

            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var stsubpoeanrs =
                from c in db.TblSubpoenaFrms
                where c.DetectiveId == CurrentUser.UserId
                select new { title = c.CaseId +'#' +(c.SubpoenaName != null ? c.SubpoenaName : "") + '#' + c.OfficialName +'#', start = (c.Date), end = (c.Date), allDay = false, url = "", className = ("fc-event-skin-green") };

             eventlist = JsonConvert.SerializeObject(stsubpoeanrs.Distinct(), Formatting.Indented);
           
        }
    }
}