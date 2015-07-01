using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Data.OleDb;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using LINQ;
using System.Security.Permissions;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

namespace Website.Pages
{
   // [PrincipalPermission(SecurityAction.Demand)]
    public partial class OtherUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // HideForm();
               // ShowForm();               
                ViewData();
               // GridViewUser.Visible = true;
               // showState();
               // showCountry();
               
            }

        }
        public void ViewData()
        {
           // ClearForm();
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var users =
                from c in db.TblSubpoenaFrms 
                select c;
            
           // GridView  GridViewUser=new GridView();
            GridView1.DataSource = users;
            GridView1.DataBind();
        }

                ////protected void btnSubmit_Click(object sender, EventArgs e)
                ////{
                ////    DataTable _objdt = new DataTable();
                ////    _objdt = GetDataFromDataBase(txtCaseId.Text);
                ////    if (_objdt.Rows.Count > 0)
                ////    {
                ////        GridView1.DataSource = _objdt;
                ////        GridView1.DataBind();
                ////    }
                ////}

                ////public DataTable GetDataFromDataBase(string searchtext)
                ////{
                ////    DataTable _objdt = new DataTable();
                ////    string querystring = "";
                ////    querystring = "select * from tblSubpoenaFrm";
                ////    if (querystring != "")
                ////    {
                ////        querystring += " where CaseId like '%" + txtCaseId.Text + "%';";
                ////    }
                ////    OleDbConnection _objcon = new OleDbConnection(connectionstring);
                ////    OleDbDataAdapter _objda = new OleDbDataAdapter(querystring, _objcon);
                ////    _objcon.Open();
                ////    _objda.Fill(_objdt);
                ////    return _objdt;
                ////}

                ////protected void btnExportxls_Click(object sender, EventArgs e)
                ////{
                ////    ExportGridToExcel();
                ////}
                ////private void ExportGridToExcel()
                ////{

                ////    try
                ////    {
                ////        DataTable dt1 = (DataTable)ViewState["dtList"];
                ////        if (dt1 == null)
                ////        {
                ////            throw new Exception("No Records to Export");
                ////        }
                ////        string Path = "D:\\ImportExcelFromDatabase\\myexcelfile_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + ".xls";
                ////        FileInfo FI = new FileInfo(Path);
                ////        StringWriter stringWriter = new StringWriter();
                ////        HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWriter);
                ////        DataGrid DataGrd = new DataGrid();
                ////        DataGrd.DataSource = dt1;
                ////        DataGrd.DataBind();

                ////        DataGrd.RenderControl(htmlWrite);
                ////        string directory = Path.Substring(0, Path.LastIndexOf("\\"));// GetDirectory(Path);
                ////        if (!Directory.Exists(directory))
                ////        {
                ////            Directory.CreateDirectory(directory);
                ////        }

                ////        System.IO.StreamWriter vw = new System.IO.StreamWriter(Path, true);
                ////        stringWriter.ToString().Normalize();
                ////        vw.Write(stringWriter.ToString());
                ////        vw.Flush();
                ////        vw.Close();
                ////       // WriteAttachment(FI.Name, "application/vnd.ms-excel", stringWriter.ToString());
                ////    }
                ////    catch (Exception ex)
                ////    {
                ////        //throw new Exception(ex.Message);
                ////    }
                ////    //FileInfo FI = new FileInfo(Path);
                ////    //StringWriter stringWriter = new StringWriter();
                ////    //HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWriter);
                ////    //DataGrid DataGrd = new DataGrid();
                ////    //DataGrd.DataSource = dt1;
                ////    //DataGrd.DataBind();

                ////    //DataGrd.RenderControl(htmlWrite);
                ////    //string directory = Path.Substring(0, Path.LastIndexOf("\\"));// GetDirectory(Path);
                ////    //if (!Directory.Exists(directory))
                ////    //{
                ////    //    Directory.CreateDirectory(directory);
                ////    //}

                ////    //System.IO.StreamWriter vw = new System.IO.StreamWriter(Path, true);
                ////    //stringWriter.ToString().Normalize();
                ////    //vw.Write(stringWriter.ToString());
                ////    //vw.Flush();
                ////    //vw.Close();
                ////    //WriteAttachment(FI.Name, "application/vnd.ms-excel", stringWriter.ToString());

                ////    //Response.Clear();
                ////    //Response.Buffer = true;
                ////    //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
                ////    //Response.Charset = "";
                ////    //Response.ContentType = "application/vnd.ms-excel";
                ////    //using (StringWriter sw = new StringWriter())
                ////    //{
                ////    //    HtmlTextWriter hw = new HtmlTextWriter(sw);

                ////    //    //To Export all pages
                ////    //    GridView1.AllowPaging = false;
                ////    //    this.BindGrid();

                ////    //    GridView1.HeaderRow.BackColor = Color.White;
                ////    //    foreach (TableCell cell in GridView1.HeaderRow.Cells)
                ////    //    {
                ////    //        cell.BackColor = GridView1.HeaderStyle.BackColor;
                ////    //    }
                ////    //    foreach (GridViewRow row in GridView1.Rows)
                ////    //    {
                ////    //        row.BackColor = Color.White;
                ////    //        foreach (TableCell cell in row.Cells)
                ////    //        {
                ////    //            if (row.RowIndex % 2 == 0)
                ////    //            {
                ////    //                cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                ////    //            }
                ////    //            else
                ////    //            {
                ////    //                cell.BackColor = GridView1.RowStyle.BackColor;
                ////    //            }
                ////    //            cell.CssClass = "textmode";
                ////    //        }
                ////    //    }

                ////    //    GridView1.RenderControl(hw);

                ////    //    //style to format numbers to string
                ////    //    string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                ////    //    Response.Write(style);
                ////    //    Response.Output.Write(sw.ToString());
                ////    //    Response.Flush();
                ////    //    Response.End();
                ////    //}

                ////    //Response.Clear();
                ////    //Response.Buffer = true;
                ////    //Response.ClearContent();
                ////    //Response.ClearHeaders();
                ////    //Response.Charset = "";
                ////    //string FileName = "Vithal" + DateTime.Now + ".xls";
                ////    //StringWriter strwritter = new StringWriter();
                ////    //HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                ////    //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                ////    //Response.ContentType = "application/vnd.ms-excel";
                ////    //Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                ////    //GridView1.GridLines = GridLines.Both;
                ////    //GridView1.HeaderStyle.Font.Bold = true;
                ////    // GridView1.RenderControl(htmltextwrtter);
                ////    //Response.Write(strwritter.ToString());
                ////    //Response.End();

                ////}
                ////private void BindGrid()
                ////{
                ////    string strConnString = ConfigurationManager.ConnectionStrings["SqlProviderConnection"].ConnectionString;
                ////    using (SqlConnection con = new SqlConnection(strConnString))
                ////    {
                ////        using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblSubpoenaFrm"))
                ////        {
                ////            using (SqlDataAdapter sda = new SqlDataAdapter())
                ////            {
                ////                cmd.Connection = con;
                ////                sda.SelectCommand = cmd;
                ////                using (DataTable dt = new DataTable())
                ////                {
                ////                    sda.Fill(dt);
                ////                    GridView1.DataSource = dt;
                ////                    GridView1.DataBind();
                ////                }
                ////            }
                ////        }
                ////    }
                ////}

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //GridView1.PageIndex =e.Newpageindex;
            //this.BindGrid();
        }

                protected void GridViewUser_RowDataBound(object sender, GridViewRowEventArgs e)
                {
            
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        Label lblSubpoenaFrmId = (Label)e.Row.FindControl("lblSubpoenaFrmId");
                        Label lblCaseId = (Label)e.Row.FindControl("lblCaseId");
                        Label lblStateId = (Label)e.Row.FindControl("lblStateId");
                        Label lblStateName = (Label)e.Row.FindControl("lblStateName");
                        Label lblCountyid = (Label)e.Row.FindControl("lblCountyid");
                        Label lblCountyName = (Label)e.Row.FindControl("lblCountyName");                
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
                       // if (lblStateId != null) lblStateId.Text = ((LINQ.TblSubpoenaFrm)e.Row.DataItem).TblState.StateId.ToString();
                      // if (lblStateName != null) lblStateName.Text = ((LINQ.TblSubpoenaFrm)e.Row.DataItem).TblState.StateName.ToString();
                        if (lblCountyid != null) lblCountyid.Text = ((LINQ.TblSubpoenaFrm)e.Row.DataItem).TblCounty.CountyId.ToString();
                        if (lblCountyName != null) lblCountyName.Text = ((LINQ.TblSubpoenaFrm)e.Row.DataItem).TblCounty.CountyName.ToString();                
                        if (lblOfficialName != null) lblOfficialName.Text = Convert.ToString(((LINQ.TblSubpoenaFrm)e.Row.DataItem).OfficialName);
                        if (lbldeDetetiveName != null) lbldeDetetiveName.Text = Convert.ToString(((LINQ.TblSubpoenaFrm)e.Row.DataItem).DetativeName);
                        if (lblDate != null) lblDate.Text = Convert.ToString(((LINQ.TblSubpoenaFrm)e.Row.DataItem).Date);
                        if (lblStatus != null) lblStatus.Text = Convert.ToString(((LINQ.TblSubpoenaFrm)e.Row.DataItem).Status);                
                        if (lblActive != null) lblActive.Text = ((LINQ.TblSubpoenaFrm)e.Row.DataItem).Active.ToString();

                
                    }

            
                }

                protected void btnSubmit_Click(object sender, EventArgs e)
                
                {
                    showData();
                    
                }
                public void showData()
                {
                    AccreditationDataContext db = new AccreditationDataContext();
                    db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];

                    var group =
                        from c in db.TblSubpoenaFrms
                        where c.CaseId.Contains(txtCaseId.Text) && c.OfficialName.Contains(txtOfficial.Text) && c.Status.Contains(txtStatus.Text)
                        && c.DetativeName.Contains(txtDetactive.Text) && c.Active.Equals(true)

                        select c;

                    GridView1.DataSource = group;
                    GridView1.DataBind();  

                }
                protected void btnExportxls_Click(object sender, EventArgs e)
                
                {
                    try
                    {
                        string attachment = "attachment;filename=ForOther.xls";
                        Response.ClearContent();
                        Response.AddHeader("content-disposition", attachment);
                        Response.ContentType = "application/ms-excel";
                        StringWriter sw = new StringWriter();
                        HtmlTextWriter htw = new HtmlTextWriter(sw);
                        HtmlForm frm = new HtmlForm();

                        //this.GridView1.Columns[20].Visible = false;
                        //this.GridView1.Columns[21].Visible = false;
                        //this.GridView1.Parent.Controls.Add(frm);

                        frm.Attributes["runat"] = "server";
                        frm.Controls.Add(GridView1);
                        frm.RenderControl(htw);
                        Response.Write(sw.ToString());
                        Response.End();
                    }
                    catch (Exception e213)
                    {

                    }
                    
                    
                    //try
                    //{
                    //    AccreditationDataContext db = new AccreditationDataContext();
                    //    db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];

                    //    var group =
                    //        from c in db.TblSubpoenaFrms
                    //        where c.CaseId.Contains(txtCaseId.Text) && c.OfficialName.Contains(txtOfficial.Text)
                    //        && c.DetativeName.Contains(txtDetactive.Text)&& c.Status.Contains(txtStatus.Text)

                    //        select c;

                    //    if (group.Count() ==0)
                    //    {
                            
                    //        Utilities.CreateMessageLabel(this, BLL.Constants.NoRecordToExport, false);
                    //    }
                    //    string Path = "D:\\ImportExcelFromDatabase\\myexcelfile_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".xls";
                    //    FileInfo FI = new FileInfo(Path);
                    //    StringWriter stringWriter = new StringWriter();
                    //    HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWriter);

                    //    DataGrid DataGrd = new DataGrid();
                    //    DataGrd.DataSource = group;
                    //    DataGrd.DataBind();

                    //    DataGrd.RenderControl(htmlWrite);
                    //    string directory = Path.Substring(0, Path.LastIndexOf("\\"));// GetDirectory(Path);
                    //    if (!Directory.Exists(directory))
                    //    {
                    //        Directory.CreateDirectory(directory);
                    //    }

                    //    System.IO.StreamWriter vw = new System.IO.StreamWriter(Path, true);
                    //    stringWriter.ToString().Normalize();
                    //    vw.Write(stringWriter.ToString());
                    //    vw.Flush();
                    //    vw.Close();
                    //    Utilities.CreateMessageLabel(this, BLL.Constants.ExcelFileCreated, true);
                    //    // WriteAttachment(FI.Name, "application/vnd.ms-excel", stringWriter.ToString());
                    //}
                    //catch (Exception ex)
                    //{
                    //    //throw new Exception(ex.Message);
                    //}
                }

                protected void PageSize_SelectedIndexChanged(object sender, EventArgs e)
                {
                    LoadnSetGridPageSize();
                }
                private void LoadnSetGridPageSize()
                {
                    AccreditationDataContext objDB = new AccreditationDataContext();
                    objDB.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
                    int cnt = Convert.ToInt16(((from D in objDB.TblSubpoenaFrms
                                                select D)).Count());

                    var group =
                        from c in objDB.TblSubpoenaFrms
                        where c.CaseId.Contains(txtCaseId.Text) && c.OfficialName.Contains(txtOfficial.Text) && c.Status.Contains(txtStatus.Text)
                        && c.DetativeName.Contains(txtDetactive.Text) && c.Active.Equals(true)
                        select c;

                    GridView1.PageSize = PageSize.SelectedValue.Equals("4",
                         StringComparison.InvariantCultureIgnoreCase)
                         ? cnt
                         : int.Parse(PageSize.SelectedValue);
                    GridView1.DataSource = group;
                    GridView1.DataBind();
                }

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

                public static IEnumerable<LINQ.TblSubpoenaFrm> ColumnSort(string sortExpression, string direction)
                {
                    AccreditationDataContext dbContext = new AccreditationDataContext();
                    dbContext.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
                    IEnumerable<LINQ.TblSubpoenaFrm> bgs = null;
                    switch (sortExpression)
                    {
                        case "OfficialName":
                            if (direction.ToUpper().Contains("ASC"))
                                bgs = from d in dbContext.TblSubpoenaFrms where d.Active.Equals(true) orderby d.OfficialName ascending select d;
                            else
                                bgs = from d in dbContext.TblSubpoenaFrms where d.Active.Equals(true) orderby d.OfficialName descending select d;
                            return bgs;
                        case "DetectiveName":
                            if (direction.ToUpper().Contains("ASC"))
                                bgs = from d in dbContext.TblSubpoenaFrms where d.Active.Equals(true) orderby d.DetativeName ascending select d;
                            else
                                bgs = from d in dbContext.TblSubpoenaFrms where d.Active.Equals(true) orderby d.DetativeName descending select d;
                            return bgs;                        
                        
                        case "StateName":
                            if (direction.ToUpper().Contains("ASC"))
                                bgs = from d in dbContext.TblSubpoenaFrms where d.Active.Equals(true) orderby d.TblState.StateName ascending select d;
                            else
                                bgs = from d in dbContext.TblSubpoenaFrms where d.Active.Equals(true) orderby d.TblState.StateName descending select d;
                            return bgs;
                        case "CuntyName":
                            if (direction.ToUpper().Contains("ASC"))
                                bgs = from d in dbContext.TblSubpoenaFrms where d.Active.Equals(true) orderby d.TblCounty.CountyName ascending select d;
                            else
                                bgs = from d in dbContext.TblSubpoenaFrms where d.Active.Equals(true) orderby d.TblCounty.CountyName descending select d;
                            return bgs;
                        default:
                            bgs = from d in dbContext.TblSubpoenaFrms where d.Active.Equals(true) orderby d.CaseId ascending select d;
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




            }
}
