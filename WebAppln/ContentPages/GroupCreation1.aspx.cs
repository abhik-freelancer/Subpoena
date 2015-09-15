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

namespace Website.Pages
{
    //[PrincipalPermission(SecurityAction.Demand)]
    public partial class GroupCreation1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["GroupId"] == null || Session["UserEmail"] == null)
                {
                    Response.Redirect("../Login.aspx");
                }
                HideForm();
               
                showState();
                showCountry();
                // ShowForm();  
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
                (from c in db.TblGroupCreations
                 where c.GrpId == editid
                 select c).FirstOrDefault();

            txtGroupName.Text = group.GrpName;

            txtAddress1.Text = group.Address1;
            txtAddress2.Text = group.Address2;
            txtCity.Text = group.City;
            //DropDownState.Text = group.Address1;
            txtZipcode.Text = group.Zipcode;
            // DropDownCountry.Text = group.Address1;
            hdneditId.Value = editid.ToString();


            var state =
                from c in db.TblStates
                select c;

            if (state.Count() > 0)
            {
                DropDownState.DataSource = state;
                DropDownState.DataTextField = "StateName";
                DropDownState.DataValueField = "StateId";
                DropDownState.DataBind();
                DropDownState.Items.Insert(0, new ListItem("----Select State----", "0"));
                DropDownState.SelectedValue = group.StateId.ToString();
                DropDownState.DataBind();
            }

            var country =
                from c in db.TblCounties
                select c;

            if (country.Count() > 0)
            {
                DropDownCountry.DataSource = country;
                DropDownCountry.DataTextField = "CountyName";
                DropDownCountry.DataValueField = "CountyId";
                DropDownCountry.DataBind();
                DropDownCountry.Items.Insert(0, new ListItem("----Select Country----", "0"));
                DropDownCountry.SelectedValue = group.CountryId.ToString();
                DropDownCountry.DataBind();
            }

        }

        public void showState()
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
                DropDownState.Items.Insert(0, new ListItem("----Select State----", "0"));

            }

        }
        public void showCountry()
        {
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var country =
                from c in db.TblCountries
                select c;

            if (country.Count() > 0)
            {
                DropDownCountry.DataSource = country;
                DropDownCountry.DataTextField = "CountryName";
                DropDownCountry.DataValueField = "CountryId";
                DropDownCountry.DataBind();
                DropDownCountry.Items.Insert(0, new ListItem("----Select Country----", "0"));

            }

        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            // ViewData();
            HideForm();
        }

        public void HideForm()
        {
            //tblForm.Visible = false;
            //  tblGrid.Visible = true;
            // btnView.Visible = false;
            //btnAddNew.Visible = true;

        }
        public void ShowForm()
        {
            //tblForm.Visible = true;
            //tblGrid.Visible = false;
            // btnView.Visible = true;
            // btnAddNew.Visible = false;
        }
        public void ClearForm()
        {
            txtGroupName.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtZipcode.Text = string.Empty;
            DropDownState.SelectedIndex = 0;
            DropDownCountry.SelectedIndex = 0;

        }

        public void btnAddNew_Click(object sender, EventArgs e)
        {
            ShowForm();
            showState();
            showCountry();
            btnSubmit1.Visible = true;
        }

        public static bool IsExistGroup(string GroupName, int editid)
        {

            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            if (editid > 0 && db.TblGroupCreations.Where(d => d.GrpName == GroupName).Count() == 1)
            {
                return true;
            }

            return db.TblGroupCreations.Where(d => d.GrpName == GroupName).Any();

        }

        protected void btnSubmit1_Click(object sender, EventArgs e)
        {
            //if (DropDownCountry.SelectedIndex > 0 && DropDownState.SelectedIndex > 0 && txtGroupName.Text.Trim() != string.Empty && txtAddress1.Text.Trim() != string.Empty && txtCity.Text.Trim() != string.Empty)
            ////if (txtGroupName.Text.Trim().Length > 0 && txtLastName.Text.Trim().Length > 0 && txtEmail.Text.Trim().Length > 0 && Convert.ToInt16(DropDownGroup.SelectedItem.Value)>0)
            //{
            if (btnSubmit1.Text.Equals("Submit"))
            {


                if (hdneditId.Value != null && hdneditId.Value != "" && int.Parse(hdneditId.Value.ToString()) > 0)
                {

                    AccreditationDataContext objDB = new AccreditationDataContext();
                    objDB.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
                    using (AccreditationDataContext group = new AccreditationDataContext())
                    {
                        LINQ.TblGroupCreation grp = objDB.TblGroupCreations.First(D => D.GrpId == int.Parse(hdneditId.Value.ToString()));
                        if (grp.GrpName.Trim() == txtGroupName.Text.Trim())
                        {
                            grp.GrpName = txtGroupName.Text.Trim();
                            grp.Address1 = txtAddress1.Text.Trim();
                            grp.Address2 = txtAddress2.Text.Trim();
                            grp.City = txtCity.Text.Trim();
                            grp.StateId = Convert.ToInt16(DropDownState.SelectedItem.Value);
                            grp.Zipcode = txtZipcode.Text;
                            grp.CountryId = Convert.ToInt16(DropDownCountry.SelectedItem.Value);
                            grp.Active = true;
                            objDB.SubmitChanges();
                        }
                        else
                        {
                            if (!IsExistGroup(txtGroupName.Text.Trim(), int.Parse(hdneditId.Value.ToString())))
                            {
                                grp.GrpName = txtGroupName.Text.Trim();
                                grp.Address1 = txtAddress1.Text.Trim();
                                grp.Address2 = txtAddress2.Text.Trim();
                                grp.City = txtCity.Text.Trim();
                                grp.StateId = Convert.ToInt16(DropDownState.SelectedItem.Value);
                                grp.Zipcode = txtZipcode.Text;
                                grp.CountryId = Convert.ToInt16(DropDownCountry.SelectedItem.Value);
                                grp.Active = true;
                                objDB.SubmitChanges();
                            }
                            else
                            {
                                Response.Write("<script>alert('This Group Name Already exist.')</script>");
                                return;
                                //Utilities.CreateMessageLabel(this, BLL.Constants.UnableToCreateGroup, false);
                            }
                        }

                    }

                }
                else
                {
                    if (!IsExistGroup(txtGroupName.Text.Trim(), 0))
                    {
                        using (AccreditationDataContext group = new AccreditationDataContext())
                        {
                            TblGroupCreation group1 = new TblGroupCreation
                            {
                                GrpName = txtGroupName.Text.Trim(),
                                Address1 = txtAddress1.Text.Trim(),
                                Address2 = txtAddress2.Text.Trim(),
                                City = txtCity.Text.Trim(),
                                StateId = Convert.ToInt16(DropDownState.SelectedItem.Value),
                                Zipcode = txtZipcode.Text,
                                CountryId = Convert.ToInt16(DropDownCountry.SelectedItem.Value),
                                Active = true,
                            };
                            group.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
                            group.TblGroupCreations.InsertOnSubmit(group1);
                            group.SubmitChanges();


                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('This Group Name Already exist.')</script>");
                        return;
                        //Utilities.CreateMessageLabel(this, BLL.Constants.UnableToCreateGroup, false);
                    }

                }



            }



            Response.Redirect("GroupList.aspx");
            return;
        }




        protected void btnGrpSearch_Click(object sender, EventArgs e)
        {

            showData();
        }
        public void showData()
        {
            //AccreditationDataContext db = new AccreditationDataContext();
            //db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            //var group =
            //    from c in db.TblGroupCreations
            //    where c.GrpName.Contains(txtGrpSearch.Text) && c.Active.Equals(true)
            //    select c;

            //GridView1.DataSource = group;
            //GridView1.DataBind(); 

        }




        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
        }



        #region  Delete Group
        public static bool Delete(int intDelGrp)
        {
            bool boolMess = false;
            try
            {
                AccreditationDataContext objDb = new AccreditationDataContext();
                objDb.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];

                LINQ.TblGroupCreation gc = objDb.TblGroupCreations.Where(D => D.GrpId == intDelGrp).Single();
                gc.Active = false;

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
        public static void Update(int GrpId, string GrpName, string Address1, string Address2,
                                    string City, int StateId,/*int Zipcode,*/ int CountryId)
        {
            AccreditationDataContext objDB = new AccreditationDataContext();
            objDB.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            //string report = null;
            try
            {
                LINQ.TblGroupCreation grp = objDB.TblGroupCreations.First(D => D.GrpId == GrpId);
                grp.GrpName = GrpName;
                grp.Address1 = Address1;
                grp.Address2 = Address2;
                grp.City = City;
                grp.StateId = StateId;
                // grp.Zipcode = Zipcode;
                grp.CountryId = CountryId;

                objDB.SubmitChanges();
                // report = BLL.Constants.Update;
            }
            catch (Exception ex)
            {
                //  report = BLL.Constants.NotUpdated;
            }

            //  return report;
        }
        #endregion




    }
    //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{

    //}

}
