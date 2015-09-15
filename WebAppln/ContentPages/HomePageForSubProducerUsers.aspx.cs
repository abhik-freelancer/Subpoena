using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Data.OleDb;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using LINQ;
using System.Security.Permissions;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Website.Pages
{
    // [PrincipalPermission(SecurityAction.Demand)]
    public partial class HomePageForSubProducerUsers : System.Web.UI.Page
    {
        public string sqlQuery = "";
        StringBuilder htmlTable = new StringBuilder();

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
        public TblGroupCreation CurrentUserGroup
        {
            get
            {
                AccreditationDataContext db = new AccreditationDataContext();
                db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
                var group = (from c in db.TblGroupCreations
                             where c.GrpId == int.Parse(Session["GroupId"].ToString())
                             select c).FirstOrDefault();
                return group;

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GroupId"] == null || Session["UserEmail"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                

                //HideForm();
               // ViewData();
            }

        }

        private void ViewData()
        {
            //<th>Case ID</th>
            //                   <th>State</th>
            //                   <th>Heading</th>
            //                   <th>Official Name</th>
            //                   <th>Detactive Name</th>
            //                   <th>Date</th>
            //                   <th>Status</th>
            //                   <th>Heading</th>

            //ClearForm();
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var subpoena =
                from c in db.TblSubpoenaFrms
                where (c.Status != "Submit" && c.DetectiveId == CurrentUser.UserId)
                select new
                {
                    c.CaseId,
                    state = db.TblStates.Where(x => x.StateId == c.StateId).FirstOrDefault().StateName,
                    c.SubpoenaName,
                    c.OfficialName,
                    c.Date,
                    c.Status,
                    c.PDFPath,
                    c.DetativeName
                };
            foreach (var xval in subpoena)
            {
                htmlTable.Append("<tr >");
                htmlTable.Append("<td>" + xval.CaseId + "</td>");
                htmlTable.Append("<td>" + xval.SubpoenaName + "</td>");
                htmlTable.Append("<td>" + xval.OfficialName + "</td>");
                htmlTable.Append("<td>" + xval.DetativeName + "</td>");
                htmlTable.Append("<td>" + xval.Date + "</td>");
                //htmlTable.Append("<td>" + xval.Status + "</td>");
                htmlTable.Append("<td>" + xval.PDFPath + "</td>");

                htmlTable.Append("</tr>");

            }
          //  DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });

            // GridView1.DataSource = subpoena;
            // GridView1.DataBind();
        }
     

        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var subpoena =
                from c in db.TblSubpoenaFrms
                where (c.Status != "Submit" && c.DetectiveId == CurrentUser.UserId)
                select c;
           

        }


        private void ViewNewSubpoena()
        {
            //ClearForm();
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var subpoena1 =
                from c in db.TblSubpoenaFrms
                where (c.Status == "new")
                select c;

            //GridView2.DataSource = subpoena1;
            // GridView2.DataBind();
        }
        private void HideForm()
        {
            // tblForm.Visible = true;
            //tblGrid.Visible = true;

        }


        protected void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // string attachment = "attachment;filename=ForDetective.xls";
                // Response.ClearContent();
                // Response.AddHeader("content-disposition", attachment);
                // Response.ContentType = "application/ms-excel";
                // //StringWriter sw = new StringWriter();
                //// HtmlTextWriter htw = new HtmlTextWriter(sw);
                // HtmlForm frm = new HtmlForm();

                // //this.GridView1.Columns[20].Visible = false;
                // //this.GridView1.Columns[21].Visible = false;
                // //this.GridView1.Parent.Controls.Add(frm);

                // frm.Attributes["runat"] = "server";
                // frm.Controls.Add(GridView1);
                // frm.RenderControl(htw);
                //// Response.Write(sw.ToString());
                // Response.End();
            }
            catch (Exception e213)
            {

            }
        }





    }
}
