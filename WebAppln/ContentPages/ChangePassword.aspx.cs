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


namespace Website.Pages
{
  //  [PrincipalPermission(SecurityAction.Demand)]
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                HideForm();
                ViewData();
            }

        }
        public static bool IsExistEmail(string Email)
        {

            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            return db.TblPasswordChanges.Where(d => d.EmailAddress == Email).Any();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim().Length > 0 && txtTempPassword.Text.Trim().Length > 0 && txtNewPassword.Text.Trim().Length > 0 && txtRetypPassword.Text.Trim().Length > 0)
            {
                if (!IsExistEmail(txtEmail.Text.Trim()))
                {
                    if (string.Compare(txtNewPassword.Text.Trim(), txtRetypPassword.Text.Trim()).Equals(0))
                    {
                        using (AccreditationDataContext passwordchange = new AccreditationDataContext())
                        {
                            TblPasswordChange passwordchange1 = new TblPasswordChange
                            {
                                EmailAddress = txtEmail.Text.Trim(),
                                TempPassword = txtTempPassword.Text.Trim(),
                                NewPassword = txtNewPassword.Text.Trim(),
                                RetypePassword = txtRetypPassword.Text.Trim(),
                            };
                            passwordchange.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
                            passwordchange.TblPasswordChanges.InsertOnSubmit(passwordchange1);
                            passwordchange.SubmitChanges();
                            ClearForm();
                            ViewData();
                            HideForm();
                           // Utilities.CreateMessageLabel(this, BLL.Constants.Insert, true);
                        }
                    }
                    else
                    {
                       // Utilities.CreateMessageLabel(this, BLL.Constants.UnableToChangePassword, false);
                    }
                }
                else
                {
                   // Utilities.CreateMessageLabel(this, BLL.Constants.PasswordChnaged, false);
                }
            }
            else
            {
               // Utilities.CreateMessageLabel(this, BLL.Constants.NotInserted, false);
            }

        }

        private void ViewData()
        {
            ClearForm();
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var passwordchange =
                from c in db.TblPasswordChanges
                select c;

            GridView1.DataSource = passwordchange;
            GridView1.DataBind();
        }

       
        protected void btnView_Click(object sender, EventArgs e)
        {
            ViewData();
            HideForm();
        }

        private void HideForm()
        {
           // tblForm.Visible = false;
           // tblGrid.Visible = true;
           // btnView.Visible = false;
            //btnAddNew.Visible = true;

        }
        private void ShowForm()
        {
           // tblForm.Visible = true;
           // tblGrid.Visible = false;
            //btnView.Visible = true;
            //btnAddNew.Visible = false;
        }
        private void ClearForm()
        {
            txtEmail.Text = "";
            txtTempPassword.Text = "";
            txtNewPassword.Text = "";
            txtRetypPassword.Text = "";


        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ShowForm();            
            btnSubmit.Visible = true;
        }

        protected void btnEmailSearch_Click(object sender, EventArgs e)
        {
            showData();
                        
        }

        public void showData()
        {
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var registration =
                from c in db.TblPasswordChanges
                where c.EmailAddress.Contains(txtEmailSearch.Text)
                select c;

            GridView1.DataSource = registration;
            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            showData();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPasswordChangeId = (Label)e.Row.FindControl("lblPasswordChangeId");
                Label lblEmailAddress = (Label)e.Row.FindControl("lblEmailAddress");
                Label lblTempPassword = (Label)e.Row.FindControl("lblTempPassword");
                Label lblNewPassword = (Label)e.Row.FindControl("lblNewPassword");
                Label lblRetypePassword = (Label)e.Row.FindControl("lblRetypePassword");


                if (lblPasswordChangeId != null) lblPasswordChangeId.Text = ((LINQ.TblPasswordChange)e.Row.DataItem).PasswordChangeId.ToString();

                if (lblEmailAddress != null) lblEmailAddress.Text = Convert.ToString(((LINQ.TblPasswordChange)e.Row.DataItem).EmailAddress);
                if (lblTempPassword != null) lblTempPassword.Text = Convert.ToString(((LINQ.TblPasswordChange)e.Row.DataItem).TempPassword);
                if (lblNewPassword != null) lblNewPassword.Text = Convert.ToString(((LINQ.TblPasswordChange)e.Row.DataItem).NewPassword);
                if (lblRetypePassword != null) lblRetypePassword.Text = Convert.ToString(((LINQ.TblPasswordChange)e.Row.DataItem).RetypePassword);
                
            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }






    }
}
