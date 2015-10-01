using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
//using BLL;
using LINQ;
using System.Security.Permissions;
using System.Net.Mail;
using System.Configuration;
using System.Net;


namespace Website.Pages
{
    // [PrincipalPermission(SecurityAction.Demand)]
    public partial class UserResgistration : System.Web.UI.Page
    {

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
            showGroup();
            
                btnSubmit.Visible = true;
                if (Request.QueryString["EditId"] != null && int.Parse(Request.QueryString["EditId"].ToString()) > 0)
                {
                    ViewData(int.Parse(Request.QueryString["EditId"].ToString()));
                }
            }

        }
        public void ViewData(int editid)
        {
            //ClearForm();
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var group =
                (from c in db.TblUserRegistrations
                 where c.UserId == editid
                 select c).FirstOrDefault();

            txtFirstName.Text = group.UserFirstName;

            txtLastName.Text = group.UserLastName;
            txtEmail.Text = group.UserEmail;
            // DropDownGroup. = Convert.ToInt16(DropDownGroup.SelectedItem.Value);
            //DropDownState.Text = group.Address1;
            // txtZipcode.Text =Convert.ToInt16(DropDownGroup.SelectedItem.Value);
            // DropDownCountry.Text = group.Address1;
            hdneditId.Value = editid.ToString();

            var registration =
              from c in db.TblGroupCreations
              select c;

            if (registration.Count() > 0)
            {
                DropDownGroup.DataSource = registration;
                DropDownGroup.DataTextField = "GrpName";
                DropDownGroup.DataValueField = "GrpId";
                DropDownGroup.DataBind();
                DropDownGroup.Items.Insert(0, new ListItem("----Select group----", "0"));
                DropDownGroup.SelectedValue = group.Group.ToString();
                DropDownGroup.DataBind();
            }

            DropdownUserrole.SelectedValue = group.userRole.ToString();
            // DropdownUserrole.DataBind();

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
                DropDownGroup.Items.Insert(0, new ListItem("----Select group----", "0"));
            }

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            // ViewData();
            HideForm();
        }

        private void HideForm()
        {
            // tblForm.Visible = false;
            //tblGrid.Visible = true;
            //btnView.Visible = false;
            // btnAddNew.Visible = true;

        }
        private void ShowForm()
        {
            //tblForm.Visible = true;
            //tblGrid.Visible = false;
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
        public static bool IsExistEmail(string Email, int editid)
        {

            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            if (editid > 0 && db.TblUserRegistrations.Where(d => d.UserEmail == Email).Count() == 1)
            {
                return true;
            }
            return db.TblUserRegistrations.Where(d => d.UserEmail == Email).Any();
        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //if (txtFirstName.Text.Trim().Length > 0 && txtLastName.Text.Trim().Length > 0 && txtEmail.Text.Trim().Length > 0 && DropDownGroup.SelectedIndex > 0)
            //{
            if (btnSubmit.Text.Equals("Submit"))
            {

                if (hdneditId.Value != null && hdneditId.Value != "" && int.Parse(hdneditId.Value.ToString()) > 0)
                {
                    AccreditationDataContext objDB = new AccreditationDataContext();
                    objDB.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
                    using (AccreditationDataContext group = new AccreditationDataContext())
                    {
                        LINQ.TblUserRegistration grp = objDB.TblUserRegistrations.First(D => D.UserId == int.Parse(hdneditId.Value.ToString()));
                        if (grp.UserEmail.Trim() == txtEmail.Text.Trim())
                        {
                            grp.UserFirstName = txtFirstName.Text.Trim();
                            grp.UserLastName = txtLastName.Text.Trim();
                            grp.UserEmail = txtEmail.Text.Trim();
                            grp.Group = Convert.ToInt16(DropDownGroup.SelectedItem.Value);
                            grp.UpdatedOn = DateTime.Now;
                            grp.UpdatedBy = Session["UeseEmail"].ToString();
                            grp.userRole = DropdownUserrole.SelectedItem.Value;
                            //grp.Active = true;

                            objDB.SubmitChanges();
                        }
                        else
                        {
                            if (!IsExistEmail(txtEmail.Text.Trim(), int.Parse(hdneditId.Value.ToString())))
                            {
                                grp.UserFirstName = txtFirstName.Text.Trim();
                                grp.UserLastName = txtLastName.Text.Trim();
                                grp.UserEmail = txtEmail.Text.Trim();
                                grp.Group = Convert.ToInt16(DropDownGroup.SelectedItem.Value);
                                grp.UpdatedOn = DateTime.Now;
                                grp.UpdatedBy = Session["UeseEmail"].ToString();
                                grp.userRole = DropdownUserrole.SelectedItem.Text;
                                // grp.Active = true;
                                objDB.SubmitChanges();
                            }
                            else
                            {
                                Response.Write("<script>alert('This Email Already exist.')</script>");
                                return;
                                //Utilities.CreateMessageLabel(this, BLL.Constants.UnableToCreateGroup, false);
                            }

                        }
                    }
                }
                else
                {
                    if (!IsExistEmail(txtEmail.Text.Trim(), 0))
                    {
                        string temppass = CreateRandomPassword(6);
                        using (AccreditationDataContext registration = new AccreditationDataContext())
                        {
                            TblUserRegistration registration1 = new TblUserRegistration
                            {
                                UserFirstName = txtFirstName.Text.Trim(),
                                UserLastName = txtLastName.Text.Trim(),
                                UserEmail = txtEmail.Text.Trim(),
                                Group = Convert.ToInt16(DropDownGroup.SelectedItem.Value),
                                CreatedBy = Session["UserEmail"].ToString(),
                                CreatedOn = DateTime.Now,
                                Active = false,
                                userRole = DropdownUserrole.SelectedItem.Text,
                                TempPass = temppass,
                                HashPass = ""
                            };
                            registration.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
                            registration.TblUserRegistrations.InsertOnSubmit(registration1);
                            registration.SubmitChanges();
                            SendMail(txtEmail.Text.Trim(), txtFirstName.Text, temppass);

                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('This Email Already exist.')</script>");
                        return;
                        //Utilities.CreateMessageLabel(this, BLL.Constants.UnableToCreateGroup, false);
                    }
                } //--


            }



            Response.Redirect("UserRegList.aspx");
            return;

        }

        private static string CreateRandomPassword(int passwordLength)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
        
        /***********************************************************
         * @method SendMail
         * @created By Abhik Ghosh
         * @Date 29/09/2015
         * @version 1.0
         * @abhik@websnipeit.com
         * ********************************************************/
        protected void SendMail(string YourEmail, string name, string temppass)
        {
            string to = YourEmail;// "friend.rahul.rch@gmail.com";//ConfigurationManager.AppSettings["DomainName"];
            string smtpName = "a2plcpnl0051.prod.iad2.secureserver.net";//ConfigurationManager.AppSettings["DomainName"];
            string from = "rahul@websnipeit.com";//ConfigurationManager.AppSettings["VerificationSenderEmail"];
            string password = "rAhhul@15";// ConfigurationManager.AppSettings["EmailPassword"];
            string SiteRoot = ConfigurationManager.AppSettings["SiteRoot"];
            string subject = "==Temporary password==";
            string Body = "";
            Body += " <html>";
            Body += "<body>";
            Body += "<table>";
            Body += "<tr>";
            Body += "<td>User Name : </td><td> " + YourEmail + "</td>";
            Body += "</tr>";
            Body += "<tr>";
            Body += "<td>Password : </td><td>" + temppass + "</td>";
            Body += "</tr>";
            Body += "<tr>";
            Body += "<td colspan=2> <a href='" + SiteRoot + "ChangePasswordSecure.aspx?Userid=" + YourEmail + "'>Click here for change password</a> </td>";
            Body += "</tr>";
            Body += "</table>";
            Body += "</body>";
            Body += "</html>";
            using (MailMessage mm = new MailMessage(from, to))
            {
                mm.Subject = subject;
                mm.Body = Body;
                //if (fuAttachment.HasFile)
                //{
                //    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
                //    mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
                //}
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = smtpName; //"smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(from, password);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
                //         ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
            }
        }
        /*********************************************************************/

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
        public static void Update(int UserId, string UserFirstName, string UserLastName, string UserEmail, int Group)
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
            //AccreditationDataContext db = new AccreditationDataContext();
            //db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            //var registration =
            //    from c in db.TblUserRegistrations
            //    where c.UserFirstName.Contains(txtNameSearch.Text) && c.Active.Equals(true)
            //    select c;


        }


        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        protected void onChangeDropDownState(object sender, EventArgs e)
        {
            var a =DropDownState.SelectedIndex;

            if (Convert.ToInt16(DropDownState.SelectedItem.Value) != 0)
            {
                AccreditationDataContext db = new AccreditationDataContext();
                db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
                var userState =
                    from c1 in db.TblCounties
                    where c1.StateId == Convert.ToInt16(DropDownState.SelectedItem.Value)
                    select c1;
                DropDownCounty.DataSource = userState;
                DropDownCounty.DataTextField = "CountyName";
                DropDownCounty.DataValueField = "CountyId";
                DropDownCounty.DataBind();
                DropDownCounty.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select County----", "0"));
            }
        }
        protected void onChangeDropDownCounty(object sender, EventArgs e)
        {
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var Group =
                from c in db.TblGroupCreations
                where c.CountryId == Convert.ToInt32(DropDownCounty.SelectedItem.Value)
                select c;

            if (Group.Count() > 0)
            {
                DropDownGroup.DataSource = Group;
                DropDownGroup.DataTextField = "GrpName";
                DropDownGroup.DataValueField = "GrpId";
                DropDownGroup.DataBind();
                DropDownGroup.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select Group----", "0"));
                //    DropDownGroup.SelectedValue = CurrentUserGroup.StateId.ToString();
                //DropDownGroup.DataBind();
            }
        }
        private void showState()
        {
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var state =
                from c in db.TblStates
                select c;

            if (state.Count() > 0)
            {
                DropDownState.DataSource = state;
                DropDownState.DataTextField = "StateName";
                DropDownState.DataValueField = "StateId";
                DropDownState.DataBind();
                DropDownState.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select State----", "0"));
                //DrpDwnState.SelectedValue = CurrentUserGroup.StateId.ToString();
                //DrpDwnState.DataBind();
            }

        }
        private void showCounty()
        {
            if (Convert.ToInt16(DropDownState.SelectedItem.Value) != 0)
            {
                AccreditationDataContext db = new AccreditationDataContext();
                db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
                var county =
                    from c in db.TblCounties
                    select c;

                if (county.Count() > 0)
                {
                    DropDownCounty.DataSource = county;
                    DropDownCounty.DataTextField = "CountyName";
                    DropDownCounty.DataValueField = "CountyId";
                    DropDownCounty.DataBind();
                    DropDownCounty.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select county----", "0"));
                    //DrpDwnCounty.SelectedValue = CurrentUserGroup.CountryId.ToString();
                    //DrpDwnCounty.DataBind();
                }
            }
           
        }
    }
}
