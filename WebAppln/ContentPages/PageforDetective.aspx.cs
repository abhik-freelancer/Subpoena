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
    public partial class PageforDetective : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HideForm();
                ViewData(); 
            }

        }

        private void ViewData()
        {
            //ClearForm();
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var subpoena =
                from c in db.TblSubpoenaFrms
                where (c.Status != "new")
                select c;

            GridView1.DataSource = subpoena;
            GridView1.DataBind();
        }
        private void ViewNewSubpoena()
        {
            //ClearForm();
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var subpoena1 =
                from c in db.TblSubpoenaFrms
                where (c.Status=="new")
                select c;

            GridView2.DataSource = subpoena1;
            GridView2.DataBind();
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

        protected void btnSearchSubpoena_Click(object sender, EventArgs e)
        {

        }

        protected void btnNewSubpoena_Click(object sender, EventArgs e)
        {
            ViewNewSubpoena();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSubpoenaFrmId = (Label)e.Row.FindControl("lblSubpoenaFrmId");
                Label lblCaseId = (Label)e.Row.FindControl("lblCaseId");
                Label lblStateId = (Label)e.Row.FindControl("lblStateId");
                Label lblStateName = (Label)e.Row.FindControl("lblStateName");
                Label lblCountyName = (Label)e.Row.FindControl("lblCountyName");
                Label lblCountyid = (Label)e.Row.FindControl("lblCountyid");
                Label lblOfficialName = (Label)e.Row.FindControl("lblOfficialName");
                Label lbldeDetetiveName = (Label)e.Row.FindControl("lbldeDetetiveName");
                Label lblDate = (Label)e.Row.FindControl("lblDate");
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");

                Label lblActive = (Label)e.Row.FindControl("lblActive");
                Label lblCreatedBy = (Label)e.Row.FindControl("lblCreatedBy");
                Label lblCreatedOn = (Label)e.Row.FindControl("lblCreatedOn");
                Label lblUpdatedBy = (Label)e.Row.FindControl("lblUpdatedBy");
                Label lblUpdatedOn = (Label)e.Row.FindControl("lblUpdatedOn");



                DropDownList DropDownState = (DropDownList)e.Row.FindControl("DropDownState");

                DropDownList DropDownCountry = (DropDownList)e.Row.FindControl("DropDownCountry");

                if (lblSubpoenaFrmId != null) lblSubpoenaFrmId.Text = ((LINQ.TblSubpoenaFrm)e.Row.DataItem).SubpoenaFrmId.ToString();
                if (lblCaseId != null) lblCaseId.Text = ((LINQ.TblSubpoenaFrm)e.Row.DataItem).CaseId.ToString();
                //if (lblStateId != null) lblStateId.Text = ((LINQ.TblSubpoenaFrm)e.Row.DataItem).TblState.StateId.ToString();
                //if (lblStateName != null) lblStateName.Text = ((LINQ.TblSubpoenaFrm)e.Row.DataItem).TblState.StateName.ToString();
                if (lblCountyid != null) lblCountyid.Text = ((LINQ.TblSubpoenaFrm)e.Row.DataItem).TblCounty.CountyId.ToString();
                if (lblCountyName != null) lblCountyName.Text = ((LINQ.TblSubpoenaFrm)e.Row.DataItem).TblCounty.CountyName.ToString();                
                if (lblOfficialName != null) lblOfficialName.Text = Convert.ToString(((LINQ.TblSubpoenaFrm)e.Row.DataItem).OfficialName);
                if (lbldeDetetiveName != null) lbldeDetetiveName.Text = Convert.ToString(((LINQ.TblSubpoenaFrm)e.Row.DataItem).DetativeName);
                if (lblDate != null) lblDate.Text = Convert.ToString(((LINQ.TblSubpoenaFrm)e.Row.DataItem).Date);
                if (lblStatus != null) lblStatus.Text = Convert.ToString(((LINQ.TblSubpoenaFrm)e.Row.DataItem).Status);
                if (lblActive != null) lblActive.Text = ((LINQ.TblSubpoenaFrm)e.Row.DataItem).Active.ToString();


            }


        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void PageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadnSetGridPageSize();
            ViewData();

        }
        private void LoadnSetGridPageSize()
        {
            AccreditationDataContext objDB = new AccreditationDataContext();
            objDB.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            int cnt = Convert.ToInt16(((from D in objDB.TblSubpoenaFrms
                                        select D)).Count());


            
            var subpoena =
                from c in objDB.TblSubpoenaFrms
                where (c.Status != "new")
                select c;
            //GridView1.DataSource = subpoena;
            //GridView1.DataBind();


            //var subpoena =
            //    from c in objDB.TblSubpoenaFrms
            //    where c.ContactName.Contains(txtBrokerName.Text) && c.TaxSSN.Contains(txtTaxId.Text)
            //    && c.Active.Equals(true)
            //    select c;

            GridView1.PageSize = DrpPageSize.SelectedValue.Equals("4",
                StringComparison.InvariantCultureIgnoreCase)
                ? cnt
                : int.Parse(DrpPageSize.SelectedValue);
            GridView1.DataSource = subpoena;
            GridView1.DataBind();
        }



    }
}
