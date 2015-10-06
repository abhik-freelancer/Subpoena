using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using LINQ;
namespace WebAppln.ContentPages
{
    public partial class DetectiveVacationManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GroupId"] == null || Session["UserEmail"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!this.IsPostBack)
            {  
                this.BindGrid();
            }
            lblMsg.Text = string.Empty;
            showOutputMessage((int)BLL.Constants.MessageType.Blank, "");
        }
        
        #region show outdiv message
        public void showOutputMessage(int type, string message)
        {
            lblOutPutMsg.Text = message;
            switch (type)
            {
                case (int)BLL.Constants.MessageType.Success:
                    dvOutPutMsg.Attributes.Add("class", "successGeneric");
                    break;
                case (int)BLL.Constants.MessageType.Fail:
                    dvOutPutMsg.Attributes.Add("class", "errorGeneric");
                    break;
                default:
                    dvOutPutMsg.Attributes.Add("class", "blankGeneric");
                    break;
            }
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "hideMsgDiv", "autoHide('" + dvOutPutMsg.ClientID + "');", true);
        }
        #endregion

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

        private void BindGrid()
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["constrww"].ToString();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "SELECT"));
            parameters.Add(new SqlParameter("@Id", 0));
            parameters.Add(new SqlParameter("@DetectiveId", CurrentUser.UserId));
            parameters.Add(new SqlParameter("@FromDate", DateTime.Now)); 
            parameters.Add(new SqlParameter("@ToDate", DateTime.Now));
            parameters.Add(new SqlParameter("@VacationDescription", "")); 
            parameters.Add(new SqlParameter("@IsApproved", 1));

            DataSet dsDetective = SqlHelper.ExecuteDataset(conString, "SpdDetectiveVacationInsUpdDel", parameters.ToArray());
            GrdViewDetetiveVacation.DataSource = dsDetective.Tables[0];
            GrdViewDetetiveVacation.DataBind();
           
        }


        protected void Insert(object sender, EventArgs e)
        {
           
            string vacation = TextBoxDescription.Text;
           
            lblMsg.Text = string.Empty;
            try
            {
                DateTime fromDate = DateTime.Parse(txtAddFromDate.Text);
                DateTime toDate = DateTime.Parse(txtAddToDate.Text);
                string validateMsg = ValidateLeave("INSERT", 0, fromDate, toDate);
                if (fromDate > toDate)
                {
                    showOutputMessage((int)BLL.Constants.MessageType.Fail, validateMsg);
                    //lblMsg.Text = "Leave start date can not be later than leave end date";
                    return;
                }
                if (validateMsg.Length > 0)
                {
                    //lblMsg.Text = validateMsg;
                    showOutputMessage((int)BLL.Constants.MessageType.Fail, validateMsg);
                    return;
                }
                string conString = System.Configuration.ConfigurationManager.ConnectionStrings["constrww"].ToString();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Action", "INSERT"));
                parameters.Add(new SqlParameter("@Id", 0));
                parameters.Add(new SqlParameter("@DetectiveId", CurrentUser.UserId));
                parameters.Add(new SqlParameter("@FromDate", fromDate));
                parameters.Add(new SqlParameter("@ToDate", toDate));
                parameters.Add(new SqlParameter("@VacationDescription", vacation));
                parameters.Add(new SqlParameter("@IsApproved", 1));

                int i = SqlHelper.ExecuteNonQuery(conString, "SpdDetectiveVacationInsUpdDel", parameters.ToArray());
                showOutputMessage((int)BLL.Constants.MessageType.Success, "Vacation created successfully.");
                this.BindGrid();
            }
            catch
            {
                showOutputMessage((int)BLL.Constants.MessageType.Fail, "Please enter correct date.");
                return;
            }
        }

        private void UpdateRecord(string id, string employee, string position, string team)
        {
            
        }

        protected void GrdViewDetetiveVacation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GrdViewDetetiveVacation.EditIndex = -1;
            this.BindGrid();
        }

        protected void GrdViewDetetiveVacation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["constrww"].ToString();
            int id = Convert.ToInt32(GrdViewDetetiveVacation.DataKeys[e.RowIndex].Values[0]);
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action", "DELETE"));
            parameters.Add(new SqlParameter("@Id", id));
            parameters.Add(new SqlParameter("@DetectiveId", 0));
            parameters.Add(new SqlParameter("@FromDate", DateTime.Now));
            parameters.Add(new SqlParameter("@ToDate", DateTime.Now));
            parameters.Add(new SqlParameter("@VacationDescription", ""));
            parameters.Add(new SqlParameter("@IsApproved", 1));

            int i= SqlHelper.ExecuteNonQuery(conString, "SpdDetectiveVacationInsUpdDel", parameters.ToArray());
            showOutputMessage((int)BLL.Constants.MessageType.Success, "Vacation deleted successfully.");
            this.BindGrid();
        }

        protected void GrdViewDetetiveVacation_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GrdViewDetetiveVacation.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void GrdViewDetetiveVacation_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           
            GridViewRow row = GrdViewDetetiveVacation.Rows[e.RowIndex];
            int Id = Convert.ToInt32(GrdViewDetetiveVacation.DataKeys[e.RowIndex].Values[0]);
            string vacation = (row.FindControl("TextBoxEditDescription") as TextBox).Text;
            try
            {
                DateTime fromDate = DateTime.Parse((row.FindControl("txtFromDate") as TextBox).Text);
                DateTime toDate = DateTime.Parse((row.FindControl("txtToDate") as TextBox).Text);
                string validateMsg = ValidateLeave("UPDATE", Id, fromDate, toDate);
                lblMsg.Text = string.Empty;
                if (fromDate > toDate)
                {
                    showOutputMessage((int)BLL.Constants.MessageType.Fail, "Leave start date can not be later than leave end date");
                    //lblMsg.Text = "Leave start date can not be later than leave end date";
                    e.Cancel = true;
                    return;
                }
                if (validateMsg.Length > 0)
                {
                    //lblMsg.Text = validateMsg;
                    showOutputMessage((int)BLL.Constants.MessageType.Fail, validateMsg);
                    e.Cancel = true;
                    return;
                }
                string conString = System.Configuration.ConfigurationManager.ConnectionStrings["constrww"].ToString();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Action", "UPDATE"));
                parameters.Add(new SqlParameter("@Id", Id));
                parameters.Add(new SqlParameter("@DetectiveId", 0));
                parameters.Add(new SqlParameter("@FromDate", fromDate));
                parameters.Add(new SqlParameter("@ToDate", toDate));
                parameters.Add(new SqlParameter("@VacationDescription", vacation));
                parameters.Add(new SqlParameter("@IsApproved", 1));

                int i = SqlHelper.ExecuteNonQuery(conString, "SpdDetectiveVacationInsUpdDel", parameters.ToArray());
                GrdViewDetetiveVacation.EditIndex = -1;
                showOutputMessage((int)BLL.Constants.MessageType.Success, "Leave updated successfully");
                this.BindGrid();
            }
            catch
            {
                showOutputMessage((int)BLL.Constants.MessageType.Fail, "Please enter correct date.");
                //lblMsg.Text = "Leave start date can not be later than leave end date";
                e.Cancel = true;
                return;
            }
            
        }

        protected string ValidateLeave(string action, int Id, DateTime FromDate, DateTime ToDate)
        {
            string leaveValidateMsg = string.Empty;
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["constrww"].ToString();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Action",action));
            parameters.Add(new SqlParameter("@Id", Id));
            parameters.Add(new SqlParameter("@DetectiveId", CurrentUser.UserId));
            parameters.Add(new SqlParameter("@FromDate", FromDate));
            parameters.Add(new SqlParameter("@ToDate", ToDate));

            int outPut =(int) SqlHelper.ExecuteScalar(conString, "SpValidateDetectiveLeave", parameters.ToArray());
            if (outPut > 0)
            {
                leaveValidateMsg = "Selected dates are not available. Either you have leave or Subpoena on selected date(s)";
            }

            return leaveValidateMsg;
        }
      
    }
}