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
using System.Security.Permissions;
using System.Text;

namespace Website.Pages
{
   // [PrincipalPermission(SecurityAction.Demand)]
    public partial class PageforDetective : System.Web.UI.Page
    {
        public string sqlQuery = "";
        StringBuilder htmlTable = new StringBuilder();
        string[] holidays1 = new String[10];
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
                                            
            }
            ViewData();
            Createselecteddate();
        }

        private void Createselecteddate()
        {
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var subpoena =
                from c in db.TblSubpoenaFrms
                where (c.Status != "Submit" && c.DetectiveId == CurrentUser.UserId)
                select c;
            int i = 0;
            foreach (var item in subpoena)
            {
                holidays1[i] = item.Date.ToShortDateString();
                i++;
            }

        }

        void MonthChange(Object sender, MonthChangedEventArgs e)
        {

            if (e.NewDate.Month > e.PreviousDate.Month)
            {
               // Message.Text = "You moved forward one month.";
            }
            else
            {
              //  Message.Text = "You moved backwards one month.";
            }

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Createselecteddate();
            //lblDates.Text = "You selected these dates:<br />";

            //foreach (DateTime dt in MyCalendar.SelectedDates)
            //{
            //    lblDates.Text += dt.ToLongDateString() + "<br />";
            //}

        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            //string aHoliday;
            DateTime theDate = e.Day.Date;
           // aHoliday = holidays[theDate.Month, theDate.Day];
            for (int i = 0; i < holidays1.Length; i++)
                if (Convert.ToDateTime(holidays1[i]) == theDate)
                {
                    e.Day.IsSelectable = false;
                    //e.Cell. = false;
                    e.Cell.BackColor = System.Drawing.Color.Red;
                    // e.Cell.Controls.Add(aLabel);
                }

            //if (aHoliday != null)
            //{
            //    Label aLabel = new Label();
            //    aLabel.Text = " <br>" + aHoliday;
            //    e.Cell.BackColor = System.Drawing.Color.Yellow;
            //    e.Cell.Controls.Add(aLabel);
            //}

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
                where (c.Status != "New" && c.DetectiveId == CurrentUser.UserId)
                select new { c.CaseId,
                    state=db.TblStates.Where(x=>x.StateId==c.StateId).FirstOrDefault().StateName, 
                c.SubpoenaName,
                c.OfficialName,
                c.Date,
                c.Status,
                c.PDFPath,
                c.DetativeName
                };
            foreach(var xval in subpoena)
            {
                htmlTable.Append("<tr >");
                htmlTable.Append("<td>" + xval.CaseId + "</td>");
                htmlTable.Append("<td>" + xval.SubpoenaName + "</td>");
                htmlTable.Append("<td>" + xval.OfficialName + "</td>");
                htmlTable.Append("<td>" + xval.DetativeName + "</td>");
                htmlTable.Append("<td>" + xval.Date + "</td>");
                //htmlTable.Append("<td>" + xval.Status + "</td>");
                htmlTable.Append("<td>  <a href='../PdfReport/" + xval.PDFPath + "' target=\"_blank\">Pdf</a></td>");
              
                htmlTable.Append("</tr>"); 

            }
             DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });  
                 
           // GridView1.DataSource = subpoena;
           // GridView1.DataBind();
        }
        protected void bntSearch_Click(object sender, EventArgs e)
        {
            //ViewData();
            string subquery = " Status='Close'";
            if (txtCaseId.Text != "")
            {
                subquery += " and CaseId='" + txtCaseId.Text+"'";
            }
            if (txtDate.Text != "")
            {
                subquery += " and Date='" + txtDate.Text + "'";
            }
            if (txtStatus.Text != "")
            {
                subquery += " and Status='" + txtStatus.Text + "'";
            }
            if (txtOfficial.Text != "")
            {
                subquery += " and OfficialName='" + txtOfficial.Text + "'";
            }
            //if (txtCaseId.Text != "")
            //{
            //    subquery += " and CaseId='" + txtCaseId.Text + "'";
            //}


            sqlQuery = "SELECT  SubpoenaFrmId,CaseId, SubpoenaName, OfficialName, DetativeName, Date, PDFPath  FROM  (SELECT  ROW_NUMBER() OVER (ORDER BY   ##ID##   ##desc##) as row,* FROM TblSubpoenaFrm  WHERE  " + subquery + "  and  ##filters## ) L   Where   ##paging##  ";
        }

        //protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        //{
        //    AccreditationDataContext db = new AccreditationDataContext();
        //    db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
        //    var subpoena =
        //        from c in db.TblSubpoenaFrms
        //        where (c.Status != "Submit" && c.DetectiveId == CurrentUser.UserId)
        //        select c;
        //    foreach (var xval in subpoena)
        //    {
        //        DateTime dte = Calendar1.SelectedDate;

        //        if (e.Day.Date == xval.Date)
        //        {
        //            e.Day.IsSelectable = false;
        //            e.Cell.ForeColor = System.Drawing.Color.Red;
        //        }
        //        else
        //        {
        //            e.Cell.ForeColor = System.Drawing.Color.Green;
        //        }
        //    }

        //}


        private void ViewNewSubpoena()
        {
            //ClearForm();
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var subpoena1 =
                from c in db.TblSubpoenaFrms
                where (c.Status=="new")
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
