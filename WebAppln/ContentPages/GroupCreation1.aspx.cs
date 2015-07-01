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
                HideForm();
               // ShowForm();               
                ViewData();
                showState();
                showCountry();
               
            }

        }

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    using (AccreditationDataContext group = new AccreditationDataContext())
        //    {
        //        TblGroupCreation group1 = new TblGroupCreation
        //        {
        //            GrpName = txtGroupName.Text.Trim(),
        //            Address1 = txtAddress1.Text.Trim(),
        //            Address2 = txtAddress2.Text.Trim(),
        //            City = txtCity.Text.Trim(),
        //            StateId = Convert.ToInt16(DropDownState.SelectedItem.Value),
        //            Zipcode = 700152,
        //            //Zipcode = txtZipcode.Text.ToString(),
        //            CountryId = Convert.ToInt16(DropDownCountry.SelectedItem.Value),


        //            //Active =1,
        //            //CreatedBy="XX",
        //            //CreatedOn=System.DateTime.Now,
        //            //UpdatedBy="YY",
        //            //UpdatedOn = System.DateTime.Now,
        //        };
        //        group.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
        //        group.TblGroupCreations.InsertOnSubmit(group1);
        //        group.SubmitChanges();
        //        ClearForm();
        //        ViewData();

        //        //{                    
        //        //    db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
        //        //    var group =
        //        //        from c in db.TblGroupCreations
        //        //        where (c.StateId == Convert.ToInt32(e.CommandArgument.ToString()))
        //        //        select c;
        //        //    lblID.Text = e.CommandArgument.ToString();
        //        //    foreach (TblGroupCreation cntry in country)
        //        //    {
        //        //         = cntry.CountryName;
        //        //        txtCountryCode.Text = cntry.CountryCode;
        //        //    }
        //        //    btnSave.Visible = false;
        //        //    btnUpdate.Visible = true;
        //        //}



        //    }
        //}
        public void ViewData()
        {
            ClearForm();
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var group =
                from c in db.TblGroupCreations
                where c.Active.Equals(true)
                select c;

            GridView1.DataSource = group;
            GridView1.DataBind();
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
                DropDownState.Items.Insert(0, "----Select State----");

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
                DropDownCountry.Items.Insert(0, "----Select Country----");

            }

        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            ViewData();
            HideForm();
        }

        public void HideForm()
        {
            //tblForm.Visible = false;
            tblGrid.Visible = true;
           // btnView.Visible = false;
            //btnAddNew.Visible = true;

        }
        public void ShowForm()
        {
            //tblForm.Visible = true;
            tblGrid.Visible = false;
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

        public static bool IsExistGroup(string GroupName)
        {
            
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            return db.TblGroupCreations.Where(d => d.GrpName == GroupName).Any();
        }

        protected void btnSubmit1_Click(object sender, EventArgs e)
        {
            if (DropDownCountry.SelectedIndex > 0 && DropDownState.SelectedIndex > 0 && txtGroupName.Text.Trim() != string.Empty && txtAddress1.Text.Trim() != string.Empty && txtCity.Text.Trim() != string.Empty)
            //if (txtGroupName.Text.Trim().Length > 0 && txtLastName.Text.Trim().Length > 0 && txtEmail.Text.Trim().Length > 0 && Convert.ToInt16(DropDownGroup.SelectedItem.Value)>0)
            {
                if (btnSubmit1.Text.Equals("Submit"))
                {
                    if (!IsExistGroup(txtGroupName.Text.Trim()))
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
                                //Zipcode = txtZipcode.ToString(),
                                CountryId = Convert.ToInt16(DropDownCountry.SelectedItem.Value),
                            };
                            group.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
                            group.TblGroupCreations.InsertOnSubmit(group1);
                            group.SubmitChanges();
                            ClearForm();
                            ViewData();
                            HideForm();
                            //Utilities.CreateMessageLabel(this, BLL.Constants.Insert, true);
                            
                        }

                    }
                    else
                    {
                        //Utilities.CreateMessageLabel(this, BLL.Constants.UnableToCreateGroup, false);
                    }
                }
                else
                {
                    //Utilities.CreateMessageLabel(this, BLL.Constants.NotInserted, false);
                }
            }
                 else 
                {
                    Update((int)Session["GrpId"], txtGroupName.Text, txtAddress1.Text, txtAddress2.Text,
                        txtCity.Text, Convert.ToInt32(DropDownState.SelectedItem.Value),
                        Convert.ToInt32(DropDownCountry.SelectedItem.Value)
                        );
                            btnSubmit1.Text = "Submit";
                }
                            ClearForm();
                            ViewData();
                            HideForm();
     }
            
        
       protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        // try
        //{
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblGrpId = (Label)e.Row.FindControl("lblGrpId");
                Label lblGrpName = (Label)e.Row.FindControl("lblGrpName");
                Label lblAddress1 = (Label)e.Row.FindControl("lblAddress1");
                Label lblAddress2 = (Label)e.Row.FindControl("lblAddress2");
                Label lblCity = (Label)e.Row.FindControl("lblCity");
                Label lblStateId = (Label)e.Row.FindControl("lblStateId");
                Label lblStateName = (Label)e.Row.FindControl("lblStateName");
                //Label lblZipCode = (Label)e.Row.FindControl("lblZipCode");
                Label lblCountryName = (Label)e.Row.FindControl("lblCountryName");
                Label lblCountryid = (Label)e.Row.FindControl("lblCountryid");
                Label lblActive = (Label)e.Row.FindControl("lblActive");
                Label lblCreatedBy = (Label)e.Row.FindControl("lblCreatedBy");
                Label lblCreatedOn = (Label)e.Row.FindControl("lblCreatedOn");
                Label lblUpdatedBy = (Label)e.Row.FindControl("lblUpdatedBy");
                Label lblUpdatedOn = (Label)e.Row.FindControl("lblUpdatedOn");



                DropDownList DropDownState = (DropDownList)e.Row.FindControl("DropDownState");

                DropDownList DropDownCountry = (DropDownList)e.Row.FindControl("DropDownCountry");

                if (lblGrpId != null) lblGrpId.Text = ((LINQ.TblGroupCreation)e.Row.DataItem).GrpId.ToString();
                if (lblGrpName != null) lblGrpName.Text = ((LINQ.TblGroupCreation)e.Row.DataItem).GrpName.ToString();
                if (lblAddress1 != null) lblAddress1.Text = Convert.ToString(((LINQ.TblGroupCreation)e.Row.DataItem).Address1);
                if (lblAddress2 != null) lblAddress2.Text = Convert.ToString(((LINQ.TblGroupCreation)e.Row.DataItem).Address2);
                if (lblCity != null) lblCity.Text = Convert.ToString(((LINQ.TblGroupCreation)e.Row.DataItem).City);

                if (lblStateId != null) lblStateId.Text = ((LINQ.TblGroupCreation)e.Row.DataItem).TblState.StateId.ToString();
                if (lblStateName != null) lblStateName.Text = ((LINQ.TblGroupCreation)e.Row.DataItem).TblState.StateName.ToString();
                // if (ZipCode != null) ZipCode.Text = Convert.ToString(((LINQ.TblGroupCreation)e.Row.DataItem).ZipCode);
                if (lblCountryName != null) lblCountryName.Text = ((LINQ.TblGroupCreation)e.Row.DataItem).TblCountry.CountryName.ToString();
                if (lblCountryid != null) lblCountryid.Text = ((LINQ.TblGroupCreation)e.Row.DataItem).TblCountry.CountryId.ToString();
                if (lblActive != null) lblActive.Text = ((LINQ.TblGroupCreation)e.Row.DataItem).TblCountry.Active.ToString();

                //if (lblCreatedBy != null) lblCreatedBy.Text = ((LINQ.TblGroupCreation)e.Row.DataItem).CreatedBy.ToString();
                //if (lblCreatedOn != null) lblCreatedOn.Text = ((LINQ.TblGroupCreation)e.Row.DataItem).CreatedOn.ToString();
                //if (lblUpdatedBy != null) lblUpdatedBy.Text = ((LINQ.TblGroupCreation)e.Row.DataItem).UpdatedBy.ToString();
                //if (lblUpdatedOn != null) lblUpdatedOn.Text = ((LINQ.TblGroupCreation)e.Row.DataItem).UpdatedOn.ToString();
            }

           //}
           // catch (Exception e1)
           // {
           //     // Throw an HttpException with customized message.
           //     throw new HttpException("not an integer");
           // }
        }

        protected void btnGrpSearch_Click(object sender, EventArgs e)
        {

            showData();
        }
        public void showData()
        {
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var group =
                from c in db.TblGroupCreations
                where c.GrpName.Contains(txtGrpSearch.Text) && c.Active.Equals(true)
                select c;

            GridView1.DataSource = group;
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                bool boolmsg = Delete(Convert.ToInt32(((Label)GridView1.Rows[e.RowIndex].FindControl("lblGrpId")).Text)); 
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
                Session["GrpId"] = Convert.ToInt32(((Label)GridView1.Rows[e.NewEditIndex].FindControl("lblGrpId")).Text);

                txtGroupName.Text = ((Label)GridView1.Rows[e.NewEditIndex].FindControl("lblGrpName")).Text;
                txtAddress1.Text = ((Label)GridView1.Rows[e.NewEditIndex].FindControl("lblAddress1")).Text;
                txtAddress2.Text = ((Label)GridView1.Rows[e.NewEditIndex].FindControl("lblAddress2")).Text;
                txtCity.Text = ((Label)GridView1.Rows[e.NewEditIndex].FindControl("lblCity")).Text;
                //txtZipcode.Text = ((Label)GridView1.Rows[e.NewEditIndex].FindControl("lblZipCode")).Text;

                showState();
                string StateName = ((Label)GridView1.Rows[e.NewEditIndex].FindControl("lblStateName")).Text;
                for (int i = 0; i < DropDownState.Items.Count; i++)
                {
                    if (DropDownState.Items[i].Text == StateName)
                        DropDownState.Items[i].Selected = true;
                }
                showCountry();
                string CountryName = ((Label)GridView1.Rows[e.NewEditIndex].FindControl("lblCountryName")).Text;
                for (int i = 0; i < DropDownCountry.Items.Count; i++)
                {
                    if (DropDownCountry.Items[i].Text == CountryName)
                        DropDownCountry.Items[i].Selected = true;
                }



                btnSubmit1.Text = "Update";
                btnSubmit1.CommandArgument = "Edit";
                
                
            }
            catch (Exception a)
            {

            }
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
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.PageIndex = 0;
            if ((SortExpression == e.SortExpression) && (SortDirection == SortDirection.Ascending))
            {
                e.SortDirection = SortDirection.Descending;
            }
            using (AccreditationDataContext db = new AccreditationDataContext())
            {
                {
                    GridView1.DataSource = ColumnSort(e.SortExpression, e.SortDirection.ToString());
                    GridView1.DataBind();
                }
                SortExpression = e.SortExpression;
                SortDirection = e.SortDirection;
            }
        }

        public static IEnumerable<LINQ.TblGroupCreation> ColumnSort(string sortExpression, string direction)
        {
            AccreditationDataContext dbContext = new AccreditationDataContext();
            dbContext.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            IEnumerable<LINQ.TblGroupCreation> bgs = null;
            switch (sortExpression)
            {
                case "GrpName":
                    if (direction.ToUpper().Contains("ASC"))
                        bgs = from d in dbContext.TblGroupCreations where d.Active.Equals(true) orderby d.GrpName ascending select d;
                    else
                        bgs = from d in dbContext.TblGroupCreations where d.Active.Equals(true) orderby d.GrpName descending select d;
                    return bgs;                

                case "StateName":
                    if (direction.ToUpper().Contains("ASC"))
                        bgs = from d in dbContext.TblGroupCreations where d.Active.Equals(true) orderby d.TblState.StateName ascending select d;
                    else
                        bgs = from d in dbContext.TblGroupCreations where d.Active.Equals(true) orderby d.TblState.StateName descending select d;
                    return bgs;
                case "CountryName":
                    if (direction.ToUpper().Contains("ASC"))
                        bgs = from d in dbContext.TblGroupCreations where d.Active.Equals(true) orderby d.TblCountry.CountryName ascending select d;
                    else
                        bgs = from d in dbContext.TblGroupCreations where d.Active.Equals(true) orderby d.TblCountry.CountryName descending select d;
                    return bgs;
                default:
                    bgs = from d in dbContext.TblGroupCreations where d.Active.Equals(true) orderby d.GrpName ascending select d;
                    return bgs;

            }
        }
        public string SortExpression
        {
            get
            {
                return (string)ViewState["SortExpression"] ?? String.Empty;
            }
            set
            {
                ViewState["SortExpression"] = value;
            }
        }

        public SortDirection SortDirection
        {
            get
            {
                object o = ViewState["SortDirection"];
                return o != null ? (SortDirection)o : SortDirection.Ascending;
            }
            set
            {
                ViewState["SortDirection"] = value;
            }
        }


        //public DataTable GetDataFromDataBase(string searchtext)
        //{
        //    //DataTable _objdt = new DataTable();
        //    //string querystring = "";
        //    //querystring = "select * from TblGroupCreation";
        //    //if (querystring != "")
        //    //{
        //    //    querystring += " where GrpName like '%" + txtGrpSearch.Text + "%';";
        //    //}
        //    //OleDbConnection _objcon = new OleDbConnection(connectionstring);
        //    //OleDbDataAdapter _objda = new OleDbDataAdapter(querystring, _objcon);
        //    //_objcon.Open();
        //    //_objda.Fill(_objdt);
        //    //return _objdt;
        //} 
         
        //    {
        //else       
        //Utilities.CreateMessageLabel(this, BLL.Constants.BlankField, false);
        //    }

        
    }
        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
           
        //}
      
    }
