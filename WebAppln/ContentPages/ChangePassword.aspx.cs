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
                if (Session["GroupId"] == null || Session["UserEmail"] == null)
                {
                    Response.Redirect("../Login.aspx");
                }
                if (Request.QueryString["EditId"] != null && int.Parse(Request.QueryString["EditId"].ToString()) > 0)
                {
                    ViewData(int.Parse(Request.QueryString["EditId"].ToString()));
                }
                HideForm();
                //ViewData();
            }

        }
        public void ViewData(int editid)
        {
            //ClearForm();
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var group =
                (from c in db.TblPasswordChanges
                 where c.PasswordChangeId == editid
                 select c).FirstOrDefault();

            txtEmail.Text = group.EmailAddress;

            txtTempPassword.Text = group.TempPassword;
            txtNewPassword.Text = group.NewPassword;
            txtRetypPassword.Text = group.RetypePassword;
            //DropDownState.Text = group.Address1;
            //txtZipcode.Text = group.Zipcode;
            // DropDownCountry.Text = group.Address1;
            hdneditId.Value = editid.ToString();

        }
        public static bool IsExistEmail(string Email)
        {

            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            return db.TblPasswordChanges.Where(d => d.EmailAddress == Email).Any();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
                if (hdneditId.Value != null && hdneditId.Value != "" && int.Parse(hdneditId.Value.ToString()) > 0)
                {
                    AccreditationDataContext objDB = new AccreditationDataContext();
                    objDB.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
                    using (AccreditationDataContext group = new AccreditationDataContext())
                    {
                        LINQ.TblPasswordChange grp = objDB.TblPasswordChanges.First(D => D.PasswordChangeId == int.Parse(hdneditId.Value.ToString()));

                        grp.EmailAddress = txtEmail.Text.Trim();
                        grp.TempPassword = txtTempPassword.Text.Trim();
                        grp.NewPassword = txtNewPassword.Text.Trim();
                        grp.RetypePassword = txtRetypPassword.Text.Trim();
                      
                        grp.Active = true;
                        objDB.SubmitChanges();

                    }
                }else{

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
                              
                                // Utilities.CreateMessageLabel(this, BLL.Constants.Insert, true);
                            }
                        }

                    }
                }


                Response.Redirect("PasswordList.aspx");
                return;

        }

       

       
        protected void btnView_Click(object sender, EventArgs e)
        {
            //ViewData();
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
           // showData();
                        
        }

        //public void showData()
        //{
        //    AccreditationDataContext db = new AccreditationDataContext();
        //    db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
        //    var registration =
        //        from c in db.TblPasswordChanges
        //        where c.EmailAddress.Contains(txtEmailSearch.Text)
        //        select c;

         
        //}
        

   
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

     

    }
}
