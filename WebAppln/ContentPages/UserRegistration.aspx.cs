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
   // [PrincipalPermission(SecurityAction.Demand)]
    public partial class UserResgistration : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HideForm();               

               // DropDownGroup.Items.Insert(0, "----Select Group----");
                //ShowForm();
                showGroup();
                ViewData();
                btnSubmit.Visible = true;
            }
            
        }

        //protected void btnSubmit_Click(object sender, EventArgs e)          

        //{
        //    using (DLCountryiesDataContext registration = new DLCountryiesDataContext())
        //    {
        //        TblUserRegistration registration1 = new TblUserRegistration
        //        {
        //            UserFirstName = txtFirstName.Text.Trim(),
        //            UserLastName = txtLastName.Text.Trim(),
        //            UserEmail = txtEmail.Text.Trim(),
        //            Group=Convert.ToInt16(DropDownGroup.SelectedItem.Value)                   
                    
        //            //Active =1,
        //            //CreatedBy="XX",
        //            //CreatedOn=System.DateTime.Now,
        //            //UpdatedBy="YY",
        //            //UpdatedOn = System.DateTime.Now,
        //        };
        //        registration.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
        //        registration.TblUserRegistrations.InsertOnSubmit(registration1);
        //        registration.SubmitChanges();
        //        ClearForm();
        //        ViewData();
        //    }
        //}

        public void ViewData()
        {
            ClearForm();
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var registration =
                from c in db.TblUserRegistrations
                where c.Active.Equals(true)
                select c;

            GridView1.DataSource = registration;
            GridView1.DataBind();
        }

        public void showGroup()
        {
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var registration =
                from c in db.TblGroupCreations
                select c;

            if (registration.Count() > 0)
            {
                DropDownGroup.DataSource = registration;
                DropDownGroup.DataTextField = "GrpName";
                DropDownGroup.DataValueField = "GrpId";
                DropDownGroup.DataBind();
                DropDownGroup.Items.Insert(0, "----Select Group----");
            }
            
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            ViewData();
            HideForm();
        }

        private void HideForm()
        {
           // tblForm.Visible = false;
            tblGrid.Visible = true;
            //btnView.Visible = false;
           // btnAddNew.Visible = true;

        }
        private void ShowForm()
        {
            //tblForm.Visible = true;
            tblGrid.Visible = false;
           // btnView.Visible = true;
           // btnAddNew.Visible = false;
        }
        private void ClearForm()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            DropDownGroup.SelectedIndex = 0;

          //  DropDownGroup.Items.Insert(0, "----Select Group----");           


        }

        public void btnAddNew_Click(object sender, EventArgs e)
        {
            ShowForm();
            showGroup();
            btnSubmit.Visible = true;
        }
        public static bool IsExistEmail(string Email)
        {

            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            return db.TblUserRegistrations.Where(d => d.UserEmail == Email).Any();
        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text.Trim().Length > 0 && txtLastName.Text.Trim().Length > 0 && txtEmail.Text.Trim().Length > 0 && DropDownGroup.SelectedIndex > 0)
            {
                if (btnSubmit.Text.Equals("Submit"))
                {
                    if (!IsExistEmail(txtEmail.Text.Trim()))
                    {
                        using (AccreditationDataContext registration = new AccreditationDataContext())
                        {
                            TblUserRegistration registration1 = new TblUserRegistration
                            {
                                UserFirstName = txtFirstName.Text.Trim(),
                                UserLastName = txtLastName.Text.Trim(),
                                UserEmail = txtEmail.Text.Trim(),
                                Group = Convert.ToInt16(DropDownGroup.SelectedItem.Value)
                            };
                            registration.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
                            registration.TblUserRegistrations.InsertOnSubmit(registration1);
                            registration.SubmitChanges();
                            int i = 0;
                           // i = registration.spu_sendmail(txtEmail.Text.Trim());
                            //registration.ExecuteCommand(spu_sendmail, txtEmail.Text.Trim());
                            ClearForm();
                            ViewData();
                            ShowForm();
                            btnSubmit.Visible = true;
                            HideForm();

                           // Utilities.CreateMessageLabel(this, BLL.Constants.EmailNotification, true);
                        }
                    }
                    else
                    {
                       // Utilities.CreateMessageLabel(this, BLL.Constants.UnableToCreateEmail, false);
                    }
                }
                else
                {
                   // Utilities.CreateMessageLabel(this, BLL.Constants.NotInserted, false);
                }
                
            }
            else
            {
                Update((int)Session["UserId"], txtFirstName.Text, txtLastName.Text, txtEmail.Text,                    
                    Convert.ToInt32(DropDownGroup.SelectedItem.Value)

                    );
                btnSubmit.Text = "Submit";
            }
            ClearForm();
            ViewData();
            ShowForm();            
            HideForm();
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblUserId = (Label)e.Row.FindControl("lblUserId");
                Label lblUserFirstName = (Label)e.Row.FindControl("lblUserFirstName");
                Label lblUserLastName = (Label)e.Row.FindControl("lblUserLastName");
                Label lblUserEmail = (Label)e.Row.FindControl("lblUserEmail");
                Label lblGroupId = (Label)e.Row.FindControl("lblGroupId");
                Label lblGroupName = (Label)e.Row.FindControl("lblGroupName");
              
                DropDownList DropDownGroup = (DropDownList)e.Row.FindControl("DropDownGroup");

                if (lblUserId != null) lblUserId.Text = ((LINQ.TblUserRegistration)e.Row.DataItem).UserId.ToString();
                if (lblUserFirstName != null) lblUserFirstName.Text = ((LINQ.TblUserRegistration)e.Row.DataItem).UserFirstName.ToString();
                if (lblUserLastName != null) lblUserLastName.Text = ((LINQ.TblUserRegistration)e.Row.DataItem).UserLastName.ToString();
                if (lblUserEmail != null) lblUserEmail.Text = ((LINQ.TblUserRegistration)e.Row.DataItem).UserEmail.ToString();
                //if (lblGroup != null) lblGroup.Text = ((LINQ.TblUserRegistration)e.Row.DataItem).Group.ToString();
                if (lblGroupName != null) lblGroupName.Text = ((LINQ.TblUserRegistration)e.Row.DataItem).TblGroupCreation.GrpName.ToString();
                if (lblGroupId != null) lblGroupId.Text = ((LINQ.TblUserRegistration)e.Row.DataItem).TblGroupCreation.GrpId.ToString();

                
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                bool boolmsg = Delete(Convert.ToInt32(((Label)GridView1.Rows[e.RowIndex].FindControl("lblUserId")).Text));
                if (boolmsg)
                {
                    // Utilities.CreateMessageLabel(this, BLL.Constants.Delete, true);
                    ViewData();
                }
                else
                {
                    // Utilities.CreateMessageLabel(this, BLL.Constants.NotDeleted, false);
                }
            }
            catch (Exception ex)
            {
                // Utilities.CreateMessageLabel(this, BLL.Constants.DataBaseTransacFailed, true);
            }
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                Session["UserId"] = Convert.ToInt32(((Label)GridView1.Rows[e.NewEditIndex].FindControl("lblId")).Text);
                txtFirstName.Text = ((Label)GridView1.Rows[e.NewEditIndex].FindControl("lblUserFirstName")).Text;
                txtLastName.Text = ((Label)GridView1.Rows[e.NewEditIndex].FindControl("lblUserLastName")).Text;
                txtEmail.Text = ((Label)GridView1.Rows[e.NewEditIndex].FindControl("lblUserEmail")).Text;
                


                showGroup();
                string GroupName = ((Label)GridView1.Rows[e.NewEditIndex].FindControl("lblGroupName")).Text;
                for (int i = 0; i < DropDownGroup.Items.Count; i++)
                {
                    if (DropDownGroup.Items[i].Text == GroupName)
                        DropDownGroup.Items[i].Selected = true;
                }

                btnSubmit.Text = "Update";
                btnSubmit.CommandArgument = "Edit";               
            }
            catch (Exception a)
            {

            }
        }

        #region  Delete User
        public static bool Delete(int intDelUser)
        {
            bool boolMess = false;
            try
            {
                AccreditationDataContext objDb = new AccreditationDataContext();
                objDb.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];

                LINQ.TblUserRegistration ur = objDb.TblUserRegistrations.Where(D => D.UserId == intDelUser).Single();
                ur.Active = false;

                objDb.SubmitChanges();

                boolMess = true;
            }
            catch (Exception ex)
            {
                boolMess = false;
            }
            return boolMess;

        }
        #endregion

        #region Edit
        public static void Update(int UserId, string UserFirstName, string UserLastName, string UserEmail,int Group)
        {
            AccreditationDataContext objDB = new AccreditationDataContext();
            objDB.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            //string report = null;
            try
            {
                LINQ.TblUserRegistration urr = objDB.TblUserRegistrations.First(D => D.UserId == UserId);
                urr.UserFirstName = UserFirstName;
                urr.UserLastName = UserLastName;
                urr.UserEmail = UserEmail;
                urr.Group = Group;
                
                
                objDB.SubmitChanges();
              //  report = BLL.Constants.Update;
            }
            catch (Exception ex)
            {
              //  report = BLL.Constants.NotUpdated;
            }

          //  return report;
        }
        #endregion


        protected void btnFNameSearch_Click(object sender, EventArgs e)
        {

            showData();
                        
        }
        public void showData()
        {
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var registration =
                from c in db.TblUserRegistrations
                where c.UserFirstName.Contains(txtNameSearch.Text) && c.Active.Equals(true)
                select c;

            GridView1.DataSource = registration;
            GridView1.DataBind();   
        
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            showData();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        
    }
}
