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
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Collections.Generic;
using BLL;

namespace Website.Pages
{
   // [PrincipalPermission(SecurityAction.Demand)]
    public partial class PageforDetective : System.Web.UI.Page
    {
        public string sqlQuery = "";
        StringBuilder htmlTable = new StringBuilder();
        DataTable dtCalendar = new DataTable();

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
                getDetectiveCalendarDetails(DateTime.Today);                     
            }
            sqlQuery = "SELECT  SubpoenaFrmId,CaseId, SubpoenaName, OfficialName, DetativeName, convert(varchar(10),[DATE],110) 'Date' , PDFPath  FROM  (SELECT  ROW_NUMBER() OVER (ORDER BY   ##ID##   ##desc##) as row,* FROM TblSubpoenaFrm  WHERE  DetectiveId = " + CurrentUser.UserId + "  and  ##filters## ) L   Where   ##paging##  ";
            ViewData();
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
            getDetectiveCalendarDetails(Calendar1.SelectedDate);
        }

        private void getDetectiveCalendarDetails(DateTime calendarDate)
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["constrww"].ToString();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@DetectiveId", CurrentUser.UserId));
            parameters.Add(new SqlParameter("@FromDate", calendarDate));

            DataSet dsDetective = SqlHelper.ExecuteDataset(conString, "SpDetectiveCalendar", parameters.ToArray());
            dtCalendar = dsDetective.Tables[0];
        }

        protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            getDetectiveCalendarDetails(e.NewDate);
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            foreach (DataRow item in dtCalendar.Rows)
            {
                Label engagement = new Label();
                HtmlTable engagement1 = new HtmlTable();
                HtmlTableRow tr = new HtmlTableRow();
                HtmlTableCell tc = new HtmlTableCell();

                Literal lineBreak = new Literal();
                if (e.Day.Date.ToString() == item["LeaveDate"].ToString())
                {
                    string CalDayStatus = Constants.Status.NEW.ToString();
                    switch (int.Parse(item["SubPoenaStatus"].ToString()))
                    {
                        case (int)BLL.Constants.Status.NEW:
                            tc.Width = "30";
                            tc.Height = "7";
                            tc.BgColor = "Yellow";
                            //tc.Attributes.Add("title", Server.HtmlDecode(item["DayType"].ToString()));
                            tc.Attributes.Add("title", Server.HtmlDecode(item["DayType"].ToString().Replace("<b>", "").Replace("</b>", "").Replace("<u>", "").Replace("</u>", "").Replace("<br/>", " : ")));
                            tr.Cells.Add(tc);
                            engagement1.Rows.Add(tr);
                            e.Cell.Controls.Add(engagement1);
                            break;
                        case (int)BLL.Constants.Status.MAYBE:
                            tc.Width = "30";
                            tc.Height = "7";
                            tc.BgColor = "Blue";
                            tc.Attributes.Add("title", Server.HtmlDecode(item["DayType"].ToString().Replace("<b>", "").Replace("</b>", "").Replace("<u>", "").Replace("</u>", "").Replace("<br/>", " : ")));
                            tr.Cells.Add(tc);
                            engagement1.Rows.Add(tr);
                            e.Cell.Controls.Add(engagement1);
                            break;
                        case (int)BLL.Constants.Status.YES:
                            tc.Width = "30";
                            tc.Height = "7";
                            tc.BgColor = "Green";
                            tc.Attributes.Add("title", Server.HtmlDecode(item["DayType"].ToString().Replace("<b>", "").Replace("</b>", "").Replace("<u>", "").Replace("</u>", "").Replace("<br/>", " : ")));
                            // tc.Attributes.Add("title", Server.HtmlDecode(item["DayType"].ToString()));
                            tr.Cells.Add(tc);
                            engagement1.Rows.Add(tr);
                            e.Cell.Controls.Add(engagement1);
                            break;
                        case (int)BLL.Constants.Status.NO:
                            tc.Width = "30";
                            tc.Height = "7";
                            tc.BgColor = "Red";
                            tc.Attributes.Add("title", Server.HtmlDecode(item["DayType"].ToString().Replace("<b>", "").Replace("</b>", "").Replace("<u>", "").Replace("</u>", "").Replace("<br/>", " : ")));
                            tr.Cells.Add(tc);
                            engagement1.Rows.Add(tr);
                            e.Cell.Controls.Add(engagement1);
                            break;
                        case 100: //Leave
                            tc.Width = "30";
                            tc.Height = "7";
                            tc.BgColor = "SandyBrown";
                            tc.Attributes.Add("title", Server.HtmlDecode(item["DayType"].ToString().Replace("<b>", "").Replace("</b>", "").Replace("<u>", "").Replace("</u>", "").Replace("<br/>", " : ")));
                            tr.Cells.Add(tc);
                            engagement1.Rows.Add(tr);
                            e.Cell.Controls.Add(engagement1);
                            break;
                    }
                }
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
                where (c.Status != ((int)BLL.Constants.Status.NEW).ToString() && c.DetectiveId == CurrentUser.UserId)
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
                htmlTable.Append("<td>" + xval.Date.ToString("MM-dd-yyyy") + "</td>");
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
        //    //ViewData();
        //   // string subquery = " Status='Close'";
        //    string subquery = " Status='" + ((int)BLL.Constants.Status.CLOSE).ToString() + "'";
        //    if (txtCaseId.Text != "")
        //    {
        //        subquery += " and CaseId='" + txtCaseId.Text+"'";
        //    }
        //    if (txtDate.Text != "")
        //    {
        //        subquery += " and Date='" + txtDate.Text + "'";
        //    }
        //    if (txtStatus.Text != "")
        //    {
        //        subquery += " and Status='" + txtStatus.Text + "'";
        //    }
        //    if (txtOfficial.Text != "")
        //    {
        //        subquery += " and OfficialName='" + txtOfficial.Text + "'";
        //    }
        //    //if (txtCaseId.Text != "")
        //    //{
        //    //    subquery += " and CaseId='" + txtCaseId.Text + "'";
        //    //}


        //    sqlQuery = "SELECT  SubpoenaFrmId,CaseId, SubpoenaName, OfficialName, DetativeName, Date, PDFPath  FROM  (SELECT  ROW_NUMBER() OVER (ORDER BY   ##ID##   ##desc##) as row,* FROM TblSubpoenaFrm  WHERE  " + subquery + "  and  ##filters## ) L   Where   ##paging##  ";
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
            //var subpoena1 =
            //    from c in db.TblSubpoenaFrms
            //    where (c.Status=="new")
            //    select c;
            var subpoena1 =
                from c in db.TblSubpoenaFrms
                where (c.Status == ((int)BLL.Constants.Status.NEW).ToString())
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
