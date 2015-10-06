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
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace WebAppln.ContentPages
{
    public partial class CalendarDashboard : System.Web.UI.Page
    {
        public string sqlQuery = "";
        StringBuilder htmlTable = new StringBuilder();
        int detectiveId = 0;
        DataTable dtCalendar = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GroupId"] == null || Session["UserEmail"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                showState();
                showCounty();
                ShowGroup();
                ShowDetectiveuser();
                getDetectiveCalendarDetails(DateTime.Today);
            }
            if (CurrentUser.userRole == "Detective")
            {
                dvSelection.Style.Add("display", "none");
            }
            
        }
        #region Drop Down
        private void showState()
        {
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var state =
                from c in db.TblStates
                select c;

            if (state.Count() > 0)
            {
                DrpDwnState.DataSource = state;
                DrpDwnState.DataTextField = "StateName";
                DrpDwnState.DataValueField = "StateId";
                DrpDwnState.DataBind();
                DrpDwnState.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select State----", "0"));
                //DrpDwnState.SelectedValue = CurrentUserGroup.StateId.ToString();
                //DrpDwnState.DataBind();
            }

        }
        private void showCounty()
        {
            if (Convert.ToInt16(DrpDwnState.SelectedItem.Value) != 0)
            {
                AccreditationDataContext db = new AccreditationDataContext();
                db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
                var county =
                    from c in db.TblCounties
                    select c;

                if (county.Count() > 0)
                {
                    DrpDwnCounty.DataSource = county;
                    DrpDwnCounty.DataTextField = "CountyName";
                    DrpDwnCounty.DataValueField = "CountyId";
                    DrpDwnCounty.DataBind();

                    //DrpDwnCounty.SelectedValue = CurrentUserGroup.CountryId.ToString();
                    //DrpDwnCounty.DataBind();
                }
            }
            DrpDwnCounty.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select county----", "0"));
        }
        private void ShowDetectiveuser()
        {
            if (Convert.ToInt16(DropDownGroup.SelectedItem.Value) != 0)
            {
                AccreditationDataContext db = new AccreditationDataContext();
                db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
                var userdetactive =
                    from c1 in db.TblUserRegistrations
                    from c2 in db.TblGroupCreations.Where(x => x.GrpId == c1.Group && c1.userRole == "Detective" /*&& x.CountryId == CurrentUserGroup.CountryId && x.StateId == CurrentUserGroup.StateId*/)
                    select new { c1.UserId, Username = c1.UserFirstName + " " + c1.UserLastName };

                if (userdetactive.Count() > 0)
                {
                    DropDownDetective.DataSource = userdetactive;
                    DropDownDetective.DataTextField = "Username";
                    DropDownDetective.DataValueField = "UserId";
                    DropDownDetective.DataBind();

                }
                //else
                //{
                //    DropDownDetective.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select detective----", "0"));

                //}

            }
            DropDownDetective.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select detective----", "0"));
        }
        private void ShowGroup()
        {
            if (Convert.ToInt16(DrpDwnCounty.SelectedItem.Value) != 0)
            {
                AccreditationDataContext db = new AccreditationDataContext();
                db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
                var Group =
                    from c in db.TblGroupCreations
                    select c;

                if (Group.Count() > 0)
                {
                    DropDownGroup.DataSource = Group;
                    DropDownGroup.DataTextField = "GrpName";
                    DropDownGroup.DataValueField = "GrpId";
                    DropDownGroup.DataBind();

                    //    DropDownGroup.SelectedValue = CurrentUserGroup.StateId.ToString();
                    // DropDownGroup.DataBind();
                }
            }
            DropDownGroup.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select Group----", "0"));
        }
        protected void PopulateDetective()
        {
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var userdetactive =
                from c1 in db.TblUserRegistrations
                from c2 in db.TblGroupCreations.Where(x => x.GrpId == c1.Group && c1.userRole == "Detective" && x.GrpId == Convert.ToInt16(DropDownGroup.SelectedItem.Value) && x.StateId == Convert.ToInt16(DrpDwnState.SelectedItem.Value))
                select new { c1.UserId, Username = c1.UserFirstName + " " + c1.UserLastName };


            DropDownDetective.DataSource = userdetactive;
            DropDownDetective.DataTextField = "Username";
            DropDownDetective.DataValueField = "UserId";
            DropDownDetective.DataBind();
            DropDownDetective.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select detective----", "0"));
        }
        protected void PopulateState()
        {
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var userState =
                from c1 in db.TblCounties
                where c1.StateId == Convert.ToInt16(DrpDwnState.SelectedItem.Value)
                select c1;
            DrpDwnCounty.DataSource = userState;
            DrpDwnCounty.DataTextField = "CountyName";
            DrpDwnCounty.DataValueField = "CountyId";
            DrpDwnCounty.DataBind();
            DrpDwnCounty.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select County----", "0"));
        }
        protected void PupulateGroup()
        {
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var Group =
                from c in db.TblGroupCreations
                where c.CountryId == Convert.ToInt32(DrpDwnCounty.SelectedItem.Value)
                select c;

         //   if (Group.Count() >= 0)
           // {
                DropDownGroup.DataSource = Group;
                DropDownGroup.DataTextField = "GrpName";
                DropDownGroup.DataValueField = "GrpId";
                DropDownGroup.DataBind();
                DropDownGroup.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select Group----", "0"));
                //    DropDownGroup.SelectedValue = CurrentUserGroup.StateId.ToString();
                //DropDownGroup.DataBind();
            //}

        }
        protected void OnchangeDrpDwnState(object sender, EventArgs e)
        {
            PopulateState();
            PupulateGroup();
            PopulateDetective();
        }
        protected void OnchangeDrpDwnCounty(object sender, EventArgs e)
        {
            PupulateGroup();
            PopulateDetective();
        }
        protected void OnchangeDrpDwnGroup(object sender, EventArgs e)
        {
            PopulateDetective();
        }
        protected void OnchangeDropDownDetective(object sender, EventArgs e)
        {
          getDetectiveCalendarDetails(DateTime.Today);
        }
        #endregion
        private void getDetectiveId()
        {
            if (CurrentUser.userRole == "Detective")
            {
                detectiveId = CurrentUser.UserId;
            }
            else
            {
                detectiveId = Convert.ToInt16(DropDownDetective.SelectedItem.Value);
            }
        }
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


        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            //getDetectiveCalendarDetails(e.Day.Date);
            e.Cell.Width = 100;
            e.Cell.Height = 100;
            foreach (DataRow item in dtCalendar.Rows)
            {
                //string[] status = item.Key.ToString().Split('@');
                Label engagement = new Label();
                HtmlTable engagement1 = new HtmlTable();
                HtmlTableRow tr = new HtmlTableRow();
                HtmlTableCell tc = new HtmlTableCell();
                Literal lineBreak = new Literal();


                if (e.Day.Date.ToString() == item["LeaveDate"].ToString())
                {

                    switch (int.Parse(item["SubPoenaStatus"].ToString()))
                    {
                        case (int)BLL.Constants.Status.NEW:

                             tc.Width = "180";
                            tc.Height = "20";
                            tc.BgColor = "Yellow";
                            //tc.InnerText = item["DayType"].ToString();
                            tc.InnerHtml = Server.HtmlDecode(item["DayType"].ToString());
                            tr.Cells.Add(tc);
                            engagement1.Rows.Add(tr);
                            lineBreak.Text = "<br />";
                            e.Cell.Controls.Add(lineBreak);
                            e.Cell.Controls.Add(engagement1);
                            e.Cell.HorizontalAlign = HorizontalAlign.Left;
                            break;
                        case (int)BLL.Constants.Status.MAYBE:
                            tc.Width = "180";
                            tc.Height = "20";
                            tc.BgColor = "LightBlue";
                            //tc.InnerText = item["DayType"].ToString();
                            tc.InnerHtml = Server.HtmlDecode(item["DayType"].ToString());
                            tr.Cells.Add(tc);
                            engagement1.Rows.Add(tr);
                            lineBreak.Text = "<br />";
                            e.Cell.Controls.Add(lineBreak);
                            e.Cell.Controls.Add(engagement1);
                            e.Cell.HorizontalAlign = HorizontalAlign.Left;
                            break;
                        case (int)BLL.Constants.Status.YES:
                            tc.Width = "180";
                            tc.Height = "20";
                            tc.BgColor = "LightGreen";
                           // tc.InnerText = item["DayType"].ToString();
                            tc.InnerHtml = Server.HtmlDecode(item["DayType"].ToString()); 
                           tr.Cells.Add(tc);
                            engagement1.Rows.Add(tr);
                            lineBreak.Text = "<br />";
                            e.Cell.Controls.Add(lineBreak);
                            e.Cell.Controls.Add(engagement1);
                            e.Cell.HorizontalAlign = HorizontalAlign.Left;
                            break;
                        case (int)BLL.Constants.Status.NO:
                            tc.Width = "180";
                            tc.Height = "20";
                            tc.BgColor = "Tomato";
                            // tc.InnerText = item["DayType"].ToString();
                            tc.InnerHtml = Server.HtmlDecode(item["DayType"].ToString());
                            tr.Cells.Add(tc);
                            engagement1.Rows.Add(tr);
                            lineBreak.Text = "<br />";
                            e.Cell.Controls.Add(lineBreak);
                            e.Cell.Controls.Add(engagement1);
                            e.Cell.HorizontalAlign = HorizontalAlign.Left;
                            //engagement = new Label();
                            //engagement.Text ="&nbsp";
                            //engagement.Width = e.Cell.Width;
                            //engagement.BackColor = System.Drawing.Color.Red;
                            //engagement.ToolTip = item.Value.ToString();
                            //e.Cell.Controls.Add(engagement);
                            break;
                            
                        case 100: //Leave
                            tc.Width = "180";
                            tc.Height = "20";
                            tc.BgColor = "SandyBrown";
                            tc.InnerHtml = Server.HtmlDecode(item["DayType"].ToString());
                           // tc.InnerHtml = Server.HtmlDecode("<br/> <b>siplu</b>");
                            tr.Cells.Add(tc);
                            engagement1.Rows.Add(tr);
                            lineBreak.Text = "<br />";
                            e.Cell.Controls.Add(lineBreak);
                            e.Cell.Controls.Add(engagement1);
                            e.Cell.HorizontalAlign = HorizontalAlign.Left;
                            //engagement = new Label();
                            //engagement.Text ="&nbsp";
                            //engagement.Width = e.Cell.Width;
                            //engagement.BackColor = System.Drawing.Color.Red;
                            //engagement.ToolTip = item.Value.ToString();
                            //e.Cell.Controls.Add(engagement);
                            break;

                    }
                    //e.Cell.ToolTip = item.Value.ToString();
                }
            }
           
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            getDetectiveCalendarDetails(Calendar1.SelectedDate);
        }

        private void getDetectiveCalendarDetails(DateTime calendarDate)
        {
            getDetectiveId();
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["constrww"].ToString();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@DetectiveId", detectiveId));
            parameters.Add(new SqlParameter("@FromDate", calendarDate));
            
            DataSet dsDetective = SqlHelper.ExecuteDataset(conString, "SpDetectiveCalendar", parameters.ToArray());
            dtCalendar = dsDetective.Tables[0];
        }

        protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            getDetectiveCalendarDetails(e.NewDate);
        }
    }
}