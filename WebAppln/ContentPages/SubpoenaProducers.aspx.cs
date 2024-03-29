﻿using System;
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
using System.IO;
using System.Collections.Generic;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.html;
using System.Net;
using System.Web.Services;
using System.Net.Mail;
using BLL;



namespace Website.Pages
{
    public partial class SubpoenaProducers : System.Web.UI.Page
    {

//Commit Test//
        string Actiontype, poenaId;
        const string SUPERVISOR_SIGNATURE = "supervisor";
        const string REPRESENTATIVE_SIGNATURE = "representative";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GroupId"] == null || Session["UserEmail"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
           
            if (!IsPostBack)
            {
                showsubpoeana();
                showtemplate();
                showState();
                showCounty();
                ShowGroup();
                ShowDetectiveuser();
                chkRepChanges();
                chkSupChanges();
                viewEditSubPoena();
            }
            //For view / edit from diff page.'SubpoenaProducers.aspx?Type=view&&Id=' + sitename;
        }

        private void viewEditSubPoena()
        {
            if (Request.QueryString["Type"] != null)
            {
                Actiontype = Request.QueryString["Type"].ToString();
                poenaId = Request.QueryString["Id"].ToString();
            }
            else
            {
                return;
            }
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            //View /edit subpoena id from diff page. 
            if (int.Parse(poenaId) > 0)
            {
                var viewEditSubpoena =
                from c in db.TblSubpoenaFrms
                where c.SubpoenaFrmId == int.Parse(poenaId)
                select new { c.SubpoenaFrmId, SubpoenaName = c.SubpoenaName };

                if (viewEditSubpoena.Count() > 0)
                {
                    ExistingSubpoeanaList.DataSource = viewEditSubpoena;
                    ExistingSubpoeanaList.DataTextField = "SubpoenaName";
                    ExistingSubpoeanaList.DataValueField = "SubpoenaFrmId";
                    ExistingSubpoeanaList.DataBind();
                    ExistingSubpoeanaList.SelectedValue = poenaId;
                    //ExistingSubpoeanaList.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select subpoeana----", "0"));
                }
                OnchangeexistingSubPoeana(ExistingSubpoeanaList, new EventArgs());
            }
            if (Actiontype == "view")
            {
                DisableFormContrl();
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

        protected void btnNewSubpoena_Click(object sender, EventArgs e)
        {

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
        private void showtemplate()
        {


        }
        
        private void showsubpoeana()
        {
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var stsubpoeanrs =
                from c in db.TblSubpoenaFrms
                where c.SaveType == "Save"
                && c.CreatedBy == Session["UserEmail"].ToString().Trim()
                select new { c.SubpoenaFrmId, SubpoenaName = c.SubpoenaName };

            if (stsubpoeanrs.Count() > 0)
            {
                ExistingSubpoeanaList.DataSource = stsubpoeanrs;
                ExistingSubpoeanaList.DataTextField = "SubpoenaName";
                ExistingSubpoeanaList.DataValueField = "SubpoenaFrmId";
                ExistingSubpoeanaList.DataBind();
                ExistingSubpoeanaList.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select subpoeana----", "0"));
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
            if(Convert.ToInt16(DrpDwnState.SelectedItem.Value) !=0)
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            String NewCaseId="";
            //if (DrpDwnCity.SelectedIndex > 0 && txtGrpName.Text.Trim() != string.Empty
            //    && txtNatureofBsns1.Text.Trim() != string.Empty && txtAddr1.Text.Trim() != string.Empty)
            //string queryautonum = " select isnull(MAX(CaseId),0)+1 from TblSubpoenaFrm where  ISNUMERIC(CaseId)=1";
            string queryautonum = "select isnull(MAX(SUBSTRING(CaseId,6,6)),0)+1 from TblSubpoenaFrm";
            DataSet Result = DbConnection.GetMultitableTableData(queryautonum);
            String CaseIdUpld="";
            //try
            //{
            if (btnSave.Text.Equals("Save"))
            {
             //   Constants cons = new Constants();

                if (txtEditSubpoeanaId.Value != null && txtEditSubpoeanaId.Value != "" && int.Parse(txtEditSubpoeanaId.Value.ToString()) > 0)
                {
                    AccreditationDataContext objDB = new AccreditationDataContext();
                    objDB.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
                    using (AccreditationDataContext group = new AccreditationDataContext())
                    {
                        LINQ.TblSubpoenaFrm Sbf = objDB.TblSubpoenaFrms.First(D => D.SubpoenaFrmId == int.Parse(txtEditSubpoeanaId.Value.ToString()));
                        CaseIdUpld=Sbf.CaseId;
                        Sbf.SubpoenaName = txtSubpoenaName.Text.Trim();
                        Sbf.StateId = Convert.ToInt16(DrpDwnState.SelectedItem.Value);
                        Sbf.CountyId = Convert.ToInt16(DrpDwnCounty.SelectedItem.Value);
                        Sbf.GroupId = Convert.ToInt16(DropDownGroup.SelectedItem.Value);
                        Sbf.Supervisor = txtSupervisor.Text.Trim();
                        Sbf.Representative = txtRepresentative.Text.Trim();
                        // Sbf.PDFPath = pdfFileName;
                        Sbf.DetectiveId = Convert.ToInt16(DropDownDetective.SelectedItem.Value);
                        // Sbf.CaseId = "CASE-" + Result.Tables[0].Rows[0][0].ToString().PadLeft(6, Convert.ToChar("0"));
                        // OfficialName = 
                        // DetativeName = txtAddr1.Text.Trim(),
                        Sbf.OfficialName = string.Empty;// "Test name";
                        Sbf.DetativeName = DropDownDetective.SelectedItem.Text;// "Test";

                        //   Sbf.Status = Constants.Status.NEW.ToString();
                        Sbf.SaveType = "Save";
                        Sbf.Date = (txtDate.Text.Trim().ToString().Length > 0) ? Convert.ToDateTime(txtDate.Text.Trim()) : System.DateTime.Now;
                        Sbf.Custodian = txtCustodian.Text.Trim();
                        Sbf.RecordsPertainTo = txtRecordsPertainTo.Text.Trim();
                        Sbf.AddressIndividualBusiness = txtAddressIndividualBusiness.Text.Trim();
                        Sbf.CrimeUnderInvestigation = txtCrimeUnderInvestigation.Text.Trim();
                        Sbf.FSS = txtFSS.Text.Trim();
                        Sbf.Suspect = txtSuspect.Text.Trim();
                        Sbf.Offense = txtOffense.Text.Trim();
                        Sbf.InformationRequested = txtInformationRequested.Text.Trim();
                        // Disclaimer = 
                        Sbf.ProbableCause = txtProbableCause.Text.Trim();
                        //Status =
                        Sbf.Disclaimer = chkboxYes.Checked == true ? true : false;
                        Sbf.SignatureRequired = txtRepresentative.Text.Trim();
                        Sbf.DisclaimerYes = chkboxNo.Checked == true ? true : false;

                        Sbf.IsDigitalSupervisor = RdoSupDigSig.Checked == true ? true : false;
                        Sbf.IsDigitalRepresentative = RdoDigSig.Checked == true ? true : false;
                        Sbf.SupervisorSignatureRequired = txtSupervisorSig.Text.Trim();
                        Sbf.RepresentativeSig = txtRepresentativeSig.Text.Trim();
                        Sbf.Active = true;
                        if (UploadRepFile.HasFile)
                            Sbf.RepresentiveSignatureFile = getUploadFileName(CaseIdUpld, UploadRepFile.FileName, REPRESENTATIVE_SIGNATURE);
                        if (UploadSupFile.HasFile)
                            Sbf.SupervisorSignatureFile = getUploadFileName(CaseIdUpld, UploadSupFile.FileName, SUPERVISOR_SIGNATURE);
                        // CreatedOn = System.DateTime.Now,
                        Sbf.UpdatedBy = Session["UserEmail"].ToString();
                        Sbf.UpdatedOn = System.DateTime.Now;
                        objDB.SubmitChanges();
                    }

                }
                else
                {

                    using (AccreditationDataContext subpoena = new AccreditationDataContext())
                    {
                        
                        CaseIdUpld="CASE-" + Result.Tables[0].Rows[0][0].ToString().PadLeft(6, Convert.ToChar("0"));
                        TblSubpoenaFrm subpoena1 = new TblSubpoenaFrm

                        {
                            SubpoenaName = txtSubpoenaName.Text.Trim(),
                            StateId = Convert.ToInt16(DrpDwnState.SelectedItem.Value),
                            CountyId = Convert.ToInt16(DrpDwnCounty.SelectedItem.Value),
                            GroupId = Convert.ToInt16(DropDownGroup.SelectedItem.Value),
                            Supervisor = txtSupervisor.Text.Trim(),
                            Representative = txtRepresentative.Text.Trim(),
                            DetectiveId = Convert.ToInt16(DropDownDetective.SelectedItem.Value),
                            CaseId = "CASE-" + Result.Tables[0].Rows[0][0].ToString().PadLeft(6, Convert.ToChar("0")),
                            // OfficialName = 
                            // DetativeName = txtAddr1.Text.Trim(),
                            OfficialName =string.Empty,// "Test name",
                            DetativeName = DropDownDetective.SelectedItem.Text,//string.Empty,//"Test",
                            Status =((int)BLL.Constants.Status.NEW).ToString(),// Constants.Status.NEW.ToString(),
                            SaveType = "Save",
                            Date = (txtDate.Text.Trim().ToString().Length > 0) ? Convert.ToDateTime(txtDate.Text.Trim()) : System.DateTime.Now,
                            Custodian = txtCustodian.Text.Trim(),
                            RecordsPertainTo = txtRecordsPertainTo.Text.Trim(),
                            AddressIndividualBusiness = txtAddressIndividualBusiness.Text.Trim(),
                            CrimeUnderInvestigation = txtCrimeUnderInvestigation.Text.Trim(),

                            FSS = txtFSS.Text.Trim(),
                            Suspect = txtSuspect.Text.Trim(),
                            Offense = txtOffense.Text.Trim(),
                            InformationRequested = txtInformationRequested.Text.Trim(),
                            // Disclaimer = 
                            ProbableCause = txtProbableCause.Text.Trim(),
                            //Status =
                            Disclaimer = chkboxYes.Checked == true ? true : false,
                            DisclaimerYes = chkboxNo.Checked == true ? true : false,
                            IsDigitalSupervisor = RdoSupDigSig.Checked == true ? true : false,
                            IsDigitalRepresentative = RdoDigSig.Checked == true ? true : false,
                            SupervisorSignatureRequired = txtSupervisorSig.Text.Trim(),
                            SignatureRequired = txtRepresentative.Text.Trim(),
                            RepresentativeSig = txtRepresentativeSig.Text.Trim(),
                            Active = true,
                            CreatedBy = Session["UserEmail"].ToString(),
                            CreatedOn = System.DateTime.Now,
                            RepresentiveSignatureFile=UploadRepFile.HasFile==true?getUploadFileName(CaseIdUpld,UploadRepFile.FileName,REPRESENTATIVE_SIGNATURE):string.Empty,
                            SupervisorSignatureFile = UploadSupFile.HasFile == true ? getUploadFileName(CaseIdUpld, UploadSupFile.FileName, SUPERVISOR_SIGNATURE) : string.Empty,
                            //UpdatedOn = System.DateTime.Now
                        };

                        
                        NewCaseId = subpoena1.CaseId;
                        subpoena.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
                        subpoena.TblSubpoenaFrms.InsertOnSubmit(subpoena1);
                        subpoena.SubmitChanges();

                    }
                }
                if (UploadRepFile.HasFile)
                {
                    UploadFile(getUploadFileName(CaseIdUpld, UploadRepFile.FileName, REPRESENTATIVE_SIGNATURE), REPRESENTATIVE_SIGNATURE);
                    HypRepSig.Text = getUploadFileName(CaseIdUpld, UploadRepFile.FileName, REPRESENTATIVE_SIGNATURE);
                    HypRepSig.NavigateUrl = "Uploads/Signature/" + getUploadFileName(CaseIdUpld, UploadRepFile.FileName, REPRESENTATIVE_SIGNATURE);
                }

                if (UploadSupFile.FileName != "")
                {
                    UploadFile(getUploadFileName(CaseIdUpld, UploadSupFile.FileName, SUPERVISOR_SIGNATURE), SUPERVISOR_SIGNATURE);
                    HypSupSig.Text = getUploadFileName(CaseIdUpld, UploadSupFile.FileName, SUPERVISOR_SIGNATURE);
                    HypSupSig.NavigateUrl = getUploadFileName(CaseIdUpld, UploadSupFile.FileName, SUPERVISOR_SIGNATURE);
                }

                
                
            }
            if(NewCaseId !="")
                showOutputMessage((int)BLL.Constants.MessageType.Success, "Subpoena Saved Successfully..Case ID is " + NewCaseId);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Subpoena Saved Successfully..Case ID is " + NewCaseId + "');window.location.href='SubpoenaProducers.aspx';", true);
            else
                showOutputMessage((int)BLL.Constants.MessageType.Success, "Subpoena Updated Successfully");
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Subpoena Updated Successfully');window.location.href='SubpoenaProducers.aspx';", true);
            Response.AddHeader("REFRESH", "5;URL=SubpoenaProducers.aspx");
            return;
            //  }
            //catch(Exception Ex)
            //{
            //}

        }

        private string getUploadFileName(string caseId, string uploadFileName, string signType)
        {
            string fileName = string.Empty;
            fileName = String.Format("{0}_{1}_{2}", caseId, signType, uploadFileName);
            return fileName;
        }

        private void UploadFile(string uploadFileName, string signType)
        {
            string fileNamePath = "Uploads/Signature\\" + uploadFileName;
            if (signType == REPRESENTATIVE_SIGNATURE)
            {
                if (UploadRepFile.HasFile)
                {
                    if (File.Exists(fileNamePath))
                    {
                        File.Delete(fileNamePath);
                    }
                    UploadRepFile.SaveAs(Server.MapPath(fileNamePath));

                }
            }
            else
            {
                if (UploadSupFile.HasFile)
                {
                    if (File.Exists(fileNamePath))
                    {
                        File.Delete(fileNamePath);
                    }
                    UploadSupFile.SaveAs(Server.MapPath(fileNamePath));
                }
            }
        }

        private void ClearForm()
        {
            txtSubpoenaName.Text = string.Empty;
            txtSupervisor.Text = string.Empty;
            txtRepresentative.Text = string.Empty;
            txtDate.Text = string.Empty;
            txtCustodian.Text = string.Empty;
            txtRecordsPertainTo.Text = string.Empty;
            txtAddressIndividualBusiness.Text = string.Empty;
            txtCrimeUnderInvestigation.Text = string.Empty;
            txtFSS.Text = string.Empty;
            //Logo.ImageUrl = string.Empty;
            txtSuspect.Text = string.Empty;
            txtOffense.Text = string.Empty;
            txtInformationRequested.Text = string.Empty;
            txtProbableCause.Text = string.Empty;
            DrpDwnCounty.SelectedIndex = 0;
            DrpDwnState.SelectedIndex = 0;
            //btnSave.Text = "Save";
        }

        private void DisableFormContrl()
        {
            txtSubpoenaName.Enabled = false;
            txtSupervisor.Enabled = false;
            txtRepresentative.Enabled = false;
            txtDate.Enabled = false;
            txtCustodian.Enabled = false;
            txtRecordsPertainTo.Enabled = false;
            txtAddressIndividualBusiness.Enabled = false;
            txtCrimeUnderInvestigation.Enabled = false;
            txtFSS.Enabled = false;
            //Logo.ImageUrl = string.Empty;
            txtSuspect.Enabled = false;
            txtOffense.Enabled = false;
            txtInformationRequested.Enabled = false;
            txtProbableCause.Enabled = false;
            ExistingSubpoeanaList.Enabled = false;
            DrpDwnCounty.Enabled = false;
            DrpDwnState.Enabled = false;
            DropDownGroup.Enabled = false;
            DropDownDetective.Enabled = false;
            ChooseSubpoeanaTempalte.Enabled = false;
            btnSave.Enabled = false;
            bntSubmit.Enabled = false;
        }

        protected void bntPreview_Click(object sender, EventArgs e)
        {
            string pdfFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_Subpoeana.pdf";

            CreatePdfFile(pdfFileName);

            string FilePath = Server.MapPath("~\\PdfReport\\" + pdfFileName);
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }

            File.Delete(FilePath);
        }

        private void CreatePdfFile(string pdfFileName)
        {

            HtmlForm form = new HtmlForm();

            StringWriter sw = new StringWriter();
            HtmlTextWriter hTextWriter = new HtmlTextWriter(sw);

            string html = sw.ToString();

            Rectangle r = new Rectangle(240, 300);
            Document Doc = new Document(r);
            Doc.SetPageSize(iTextSharp.text.PageSize.A4);

            string path = Server.MapPath("~\\PdfReport\\" + pdfFileName);

            PdfWriter.GetInstance
           (Doc, new FileStream(path, FileMode.Create));
            Doc.Open();

            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            Font times = new Font(bfTimes, 10, Font.BOLD, Color.BLACK);

            iTextSharp.text.Font contentFont = iTextSharp.text.FontFactory.GetFont("Calibri", 14, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font contentFont1 = iTextSharp.text.FontFactory.GetFont("Calibri", 11);
            iTextSharp.text.Font contentFont2 = iTextSharp.text.FontFactory.GetFont("Arial", 14, Font.ITALIC);
            iTextSharp.text.Font contentFont3 = iTextSharp.text.FontFactory.GetFont("Arial", 10, Font.BOLDITALIC);
            iTextSharp.text.Font contentFont4 = iTextSharp.text.FontFactory.GetFont("Arial", 8, Font.NORMAL);
            iTextSharp.text.Font contentFont5 = iTextSharp.text.FontFactory.GetFont("Arial", 8, Font.BOLD);
            iTextSharp.text.Font contentFont6 = iTextSharp.text.FontFactory.GetFont("Arial", 8, Font.UNDERLINE);
            iTextSharp.text.Font contentFont7 = iTextSharp.text.FontFactory.GetFont("Arial", 8, Font.UNDERLINE | Font.NORMAL);

            iTextSharp.text.Font Headerstyle1 = iTextSharp.text.FontFactory.GetFont("Arial", 12, Font.BOLD);
            iTextSharp.text.Font paragraph = iTextSharp.text.FontFactory.GetFont("Arial", 11, Font.BOLD);
            string imageURLHeader = Server.MapPath("~\\Images\\innerLogo.png");

            iTextSharp.text.Image headerimg = iTextSharp.text.Image.GetInstance(imageURLHeader);
            headerimg.ScalePercent(50f);
            headerimg.SetAbsolutePosition(35, Doc.PageSize.Height - 60f);

            PdfPTable tableH1 = new PdfPTable(11);
            tableH1.WidthPercentage = 100;
            float[] widthH = new float[] { 3.5f, 0.3f, 4.0f, 0.3f, 0.5f, 3.0f, 1.5f, 4.0f, 3.0f, 0.5f, 4.5f };
            tableH1.SetWidths(widthH);

            PdfPCell cellH1;
            GrayColor gray = new GrayColor(150);
            GrayColor graycell = new GrayColor(220);
            //---------------------------------------------------------header portion
            //================3==================================
            cellH1 = new PdfPCell(new Phrase("\n", contentFont5));
            //cellH1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 11;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase("To: Office of the State Attorney ", Headerstyle1));
            cellH1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.Colspan = 6;
            tableH1.AddCell(cellH1);
            cellH1 = new PdfPCell(new Phrase("REQUEST FOR", Headerstyle1));
            cellH1.HorizontalAlignment = Element.ALIGN_CENTER;

            cellH1.BackgroundColor = gray;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.Colspan = 5;
            tableH1.AddCell(cellH1);


            cellH1 = new PdfPCell(new Phrase("First judical Circuit", Headerstyle1));
            cellH1.HorizontalAlignment = Element.ALIGN_CENTER;
            cellH1.PaddingLeft = 10f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.Colspan = 6;
            tableH1.AddCell(cellH1);
            cellH1 = new PdfPCell(new Phrase("SUBPOENA DUCES TECUM", Headerstyle1));
            cellH1.HorizontalAlignment = Element.ALIGN_CENTER;

            cellH1.BackgroundColor = gray;
            cellH1.PaddingLeft = 10f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.Colspan = 5;
            tableH1.AddCell(cellH1);
            //================3==================================
            cellH1 = new PdfPCell(new Phrase("\n", contentFont5));
            //cellH1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 11;
            tableH1.AddCell(cellH1);
            //---------------------------------------------------------------- end header portion
            //===================1=================================
            cellH1 = new PdfPCell(new Phrase("Agency :", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthBottom = 0f;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase(txtSupervisor.Text, contentFont7));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BackgroundColor = graycell;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.Colspan = 3;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase("Representative:", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.Colspan = 2;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase(txtRepresentative.Text, contentFont7));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BackgroundColor = graycell;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.Colspan = 2;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase("Date:", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.Colspan = 2;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase(txtDate.Text, contentFont7));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BackgroundColor = graycell;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.BorderWidthRight = 0f;
            tableH1.AddCell(cellH1);

            //================3==================================
            cellH1 = new PdfPCell(new Phrase("\n", contentFont5));
            //cellH1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 11;
            tableH1.AddCell(cellH1);
            //================3==================================
            cellH1 = new PdfPCell(new Phrase("REQUEST IS HEREBY MADE of the State Attorney, or his duly authorized Assistant, of the First Judicial" +
                        "Circuit of Florida for investigative assistance and the issuance of a subpoena duces tecum for the" +
                        "appearance and testimony of a custodian of records and / or copies of certain records, documents, and /" +
                        "or papers pertinent to an ongoing criminal investigation, more particularly described as follows:", paragraph));
            cellH1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cellH1.PaddingLeft = 25f;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.Colspan = 11;
            tableH1.AddCell(cellH1);
            //================3==================================
            cellH1 = new PdfPCell(new Phrase("\n", contentFont5));
            //cellH1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 11;
            tableH1.AddCell(cellH1);
            //===========================2===============================
            cellH1 = new PdfPCell(new Phrase("Possessor of Records:", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.PaddingLeft = 25f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.Colspan = 3;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase(txtProbableCause.Text, contentFont7));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BackgroundColor = graycell;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.Colspan = 3;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase("Records Pertain To:", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.Colspan = 2;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase(txtRecordsPertainTo.Text, contentFont7));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BackgroundColor = graycell;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.Colspan = 3;
            tableH1.AddCell(cellH1);

            //================3==================================
            cellH1 = new PdfPCell(new Phrase("\n", contentFont5));
            //cellH1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 11;
            tableH1.AddCell(cellH1);
            //===================================4======================================
            cellH1 = new PdfPCell(new Phrase("Address:", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.PaddingLeft = 25f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthBottom = 0f;

            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase(txtAddressIndividualBusiness.Text, contentFont7));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BackgroundColor = graycell;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.Colspan = 10;
            tableH1.AddCell(cellH1);
            //================3==================================
            cellH1 = new PdfPCell(new Phrase("\n", contentFont5));
            //cellH1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 11;
            tableH1.AddCell(cellH1);


            cellH1 = new PdfPCell(new Phrase("Crime Under Investigation:", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.PaddingLeft = 25f;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.Colspan = 3;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase(txtCrimeUnderInvestigation.Text, contentFont7));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BackgroundColor = graycell;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.Colspan = 4;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase("F.S.S.", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthBottom = 0f;

            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase(txtFSS.Text, contentFont7));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BackgroundColor = graycell;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.Colspan = 3;
            tableH1.AddCell(cellH1);
            //================3==================================
            cellH1 = new PdfPCell(new Phrase("\n", contentFont5));
            //cellH1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 11;
            tableH1.AddCell(cellH1);
            //----------------------------------------
            cellH1 = new PdfPCell(new Phrase("Suspect(s):", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.PaddingLeft = 25f;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthBottom = 0f;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase(txtSuspect.Text, contentFont7));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BackgroundColor = graycell;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.Colspan = 5;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase("Offense#:", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.Colspan = 2;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase(txtOffense.Text, contentFont7));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BackgroundColor = graycell;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.Colspan = 3;
            tableH1.AddCell(cellH1);

            //================3==================================
            cellH1 = new PdfPCell(new Phrase("\n", contentFont5));
            //cellH1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 11;
            tableH1.AddCell(cellH1);
            //===============5==========================================
            cellH1 = new PdfPCell(new Phrase("Information Requested: ", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthBottom = 0f;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase(txtInformationRequested.Text, contentFont4));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BackgroundColor = graycell;
            cellH1.FixedHeight = 60f;
            cellH1.BorderWidthTop = 0.5f;
            cellH1.BorderWidthLeft = 0.5f;
            cellH1.BorderWidthRight = 0.5f;
            cellH1.BorderWidthBottom = 0.5f;
            cellH1.Colspan = 10;
            tableH1.AddCell(cellH1);

            //================3==================================
            cellH1 = new PdfPCell(new Phrase("\n", contentFont5));
            //cellH1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 11;
            tableH1.AddCell(cellH1);

            //----------------------------------------------------------------------
            //===============5==========================================
            cellH1 = new PdfPCell(new Phrase("\"No notice to suspect\" disclaimer needed? ", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.Colspan = 5;
            tableH1.AddCell(cellH1);

          //string chk = chkboxNo.Checked == true ? "Yes" : "No";
            if(chkboxNo.Checked==true)
                cellH1 = new PdfPCell(new Phrase("Yes", contentFont4));
            else
                cellH1 = new PdfPCell(new Phrase("", contentFont4));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BackgroundColor = graycell;
            cellH1.BorderWidthTop = 1f;
            cellH1.BorderWidthLeft = 1f;
            cellH1.BorderWidthRight = 1f;
            cellH1.BorderWidthBottom = 1f;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase("Yes", contentFont4));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthBottom = 0f;
            tableH1.AddCell(cellH1);

            if (chkboxNo.Checked == true)
                cellH1 = new PdfPCell(new Phrase("", contentFont4));
            else
                cellH1 = new PdfPCell(new Phrase("No", contentFont4));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BackgroundColor = graycell;
            cellH1.BorderWidthTop = 1f;
            cellH1.BorderWidthLeft = 1f;
            cellH1.BorderWidthRight = 1f;
            cellH1.BorderWidthBottom = 1f;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase("No", contentFont4));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthBottom = 0f;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase("(Required for certain companies, banks, etc.)", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.Colspan = 2;
            tableH1.AddCell(cellH1);
            //================3==================================
            cellH1 = new PdfPCell(new Phrase("\n", contentFont5));
            //cellH1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 11;
            tableH1.AddCell(cellH1);

            //===============5==========================================
            cellH1 = new PdfPCell(new Phrase("Probable Cause:", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthBottom = 0f;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase(txtProbableCause.Text, contentFont4));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BackgroundColor = graycell;
            cellH1.FixedHeight = 80f;
            cellH1.BorderWidthTop = 0.5f;
            cellH1.BorderWidthLeft = 0.5f;
            cellH1.BorderWidthRight = 0.5f;
            cellH1.BorderWidthBottom = 0.5f;
            cellH1.Colspan = 10;
            tableH1.AddCell(cellH1);

            //================3==================================
            cellH1 = new PdfPCell(new Phrase("\n", contentFont5));
            //cellH1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 11;
            tableH1.AddCell(cellH1);

            //================3==================================
            cellH1 = new PdfPCell(new Phrase("AUTHORIZATION: The requesting law enforcement agency has authorized the under signed representative  to make the foregoing request and will be responsible for any " +
"costs incurred in making said copies. Further, the undersigned here by certifies this request is made in good faith in furtherance of the official pendind" +
"criminal investigation described herein and all other avenues for obtaining the described records have been exhausted.", contentFont4));
            cellH1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cellH1.PaddingLeft = 25f;
            cellH1.BorderWidthTop = 0f;
            cellH1.BorderWidthLeft = 0f;
            cellH1.BorderWidthRight = 0f;
            cellH1.BorderWidthBottom = 0f;
            cellH1.Colspan = 11;
            tableH1.AddCell(cellH1);


            //================3==================================
            cellH1 = new PdfPCell(new Phrase("\n", contentFont5));
            //cellH1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 11;
            tableH1.AddCell(cellH1);

            //================3==================================
            cellH1 = new PdfPCell(new Phrase("Representative Signature (Required)" + "\n" + "______________________________", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 6;
            tableH1.AddCell(cellH1);

            

            cellH1 = new PdfPCell(new Phrase("Supervisor Signature (Required)" + "\n" + "______________________________", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 6;
            tableH1.AddCell(cellH1);
            //================3==================================
            cellH1 = new PdfPCell(new Phrase("\n", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 11;
            tableH1.AddCell(cellH1);


            //================3==================================
            string imagepath = Server.MapPath("../ContentPages/Uploads/Signature/");
            if (HypRepSig.Text != "")
            {
               
                iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(imagepath + HypRepSig.Text);
                cellH1 = new PdfPCell(new Phrase("Signature"));
                gif.ScaleToFit(150, 75);
                cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
                cellH1.BorderWidthTop = 0;
                cellH1.BorderWidthLeft = 0;
                cellH1.BorderWidthRight = 0;
                cellH1.BorderWidthBottom = 0;
                cellH1.AddElement(gif);
                cellH1.Colspan = 9;
                tableH1.AddCell(cellH1);
            }
            //================3==================================
            if (HypSupSig.Text != "")
            {
                iTextSharp.text.Image SupGif = iTextSharp.text.Image.GetInstance(imagepath + HypSupSig.Text);
                cellH1 = new PdfPCell(new Phrase("Signature"));
                SupGif.ScaleToFit(150, 75);
                cellH1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellH1.BorderWidthTop = 0;
                cellH1.BorderWidthLeft = 0;
                cellH1.BorderWidthRight = 0;
                cellH1.BorderWidthBottom = 0;
                cellH1.AddElement(SupGif);
                cellH1.Colspan = 6;
                tableH1.AddCell(cellH1);
            }
            
            //================3==================================
            cellH1 = new PdfPCell(new Phrase(txtRepresentativeSig.Text, contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_MIDDLE;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
           // cellH1.Colspan = 6;
            tableH1.AddCell(cellH1);

            //================3==================================
            cellH1 = new PdfPCell(new Phrase(txtSupervisorSig.Text, contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_MIDDLE;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 6;
            tableH1.AddCell(cellH1);

            //================3==================================
            cellH1 = new PdfPCell(new Phrase("\n", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 11;
            tableH1.AddCell(cellH1);
            //================3==================================
            cellH1 = new PdfPCell(new Phrase("________________________________________________________________________________________________________________", contentFont5));
            //cellH1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 11;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase(". . . THIS SECTION MUST BE COMPLETED BY AUTHORIZING PROSECUTOR. . .", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_CENTER;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 11;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase("REQUEST GRANTED []", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 11;
            tableH1.AddCell(cellH1);
            //----------------------------------
            cellH1 = new PdfPCell(new Phrase("REQUEST GRANTED []", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 4;
            tableH1.AddCell(cellH1);
            cellH1 = new PdfPCell(new Phrase("REASONS(S):", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 3;
            tableH1.AddCell(cellH1);
            cellH1 = new PdfPCell(new Phrase("__________________________________", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 4;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase("REQUEST DECLINED []", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 4;
            tableH1.AddCell(cellH1);
            cellH1 = new PdfPCell(new Phrase("REASONS(S):", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 3;
            tableH1.AddCell(cellH1);
            cellH1 = new PdfPCell(new Phrase("__________________________________", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 4;
            tableH1.AddCell(cellH1);
            //-------------------------------------------------

            cellH1 = new PdfPCell(new Phrase("SIGNATURE required", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 3;
            tableH1.AddCell(cellH1);
            cellH1 = new PdfPCell(new Phrase("________________________________________________________", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 8;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase("TYPE name", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 2;
            tableH1.AddCell(cellH1);
            cellH1 = new PdfPCell(new Phrase("_________________________________________________________________", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 7;
            tableH1.AddCell(cellH1);
            cellH1 = new PdfPCell(new Phrase("Assistant State Attorney", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 2;
            tableH1.AddCell(cellH1);

            cellH1 = new PdfPCell(new Phrase("REMINDER TO ISSUING ASA: Notice to Defendant required when obtaining medical records via subpoena duces tecum.", contentFont5));
            cellH1.HorizontalAlignment = Element.ALIGN_LEFT;
            cellH1.BorderWidthTop = 0;
            cellH1.BorderWidthLeft = 0;
            cellH1.BorderWidthRight = 0;
            cellH1.BorderWidthBottom = 0;
            cellH1.Colspan = 11;
            tableH1.AddCell(cellH1);

            Chunk c7 = new Chunk
                 ("\n\n" + "ORIGINAL - STATE ATTORNEY'S OFFICE", contentFont4);
            Paragraph p7 = new Paragraph();
            p7.Alignment = Element.ALIGN_CENTER;
            p7.IndentationLeft = 0f;
            p7.Add(c7);

            //Chunk c8 = new Chunk
            //    ("Supervisor Signature (Required)" + "\n" + "______________________________", contentFont4);
            //Paragraph p8 = new Paragraph();
            //p8.Alignment = Element.ALIGN_RIGHT;
            //p8.IndentationLeft = 280f;
            //p8.Add(c8);

            Doc.Add(headerimg);
            Doc.Add(tableH1);
            Doc.Add(p7);
            //Doc.Add(p8);
            Doc.NewPage();
            System.Xml.XmlTextReader xmlReader = new System.Xml.XmlTextReader(new StringReader(html));
            HtmlParser.Parse(Doc, xmlReader);
            Doc.Close();

        }

        protected void bntSubmit_Click(object sender, EventArgs e)
        {
            //string pdfFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_Subpoeana.pdf";
            string pdfFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_Subpoeana.pdf";
            AccreditationDataContext objDB = new AccreditationDataContext();
            objDB.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            String CaseIdUpld = "";
            int subpoeanaCuurId = 0;

            if (txtEditSubpoeanaId.Value != null && txtEditSubpoeanaId.Value != "" && int.Parse(txtEditSubpoeanaId.Value.ToString()) > 0)
            {
                subpoeanaCuurId = int.Parse(txtEditSubpoeanaId.Value.ToString());
                using (AccreditationDataContext group = new AccreditationDataContext())
                {
                    LINQ.TblSubpoenaFrm Sbf = objDB.TblSubpoenaFrms.First(D => D.SubpoenaFrmId == int.Parse(txtEditSubpoeanaId.Value.ToString()));
                    CaseIdUpld = Sbf.CaseId;
                    Sbf.SubpoenaName = txtSubpoenaName.Text.Trim();
                    Sbf.StateId = Convert.ToInt16(DrpDwnState.SelectedItem.Value);
                    Sbf.CountyId = Convert.ToInt16(DrpDwnCounty.SelectedItem.Value);
                    Sbf.GroupId = Convert.ToInt16(DropDownGroup.SelectedItem.Value);
                    Sbf.Supervisor = txtSupervisor.Text.Trim();
                    Sbf.Representative = txtRepresentative.Text.Trim();
                    Sbf.PDFPath = pdfFileName;
                    Sbf.DetectiveId = Convert.ToInt16(DropDownDetective.SelectedItem.Value);
                    // Sbf.CaseId = "CASE-" + Result.Tables[0].Rows[0][0].ToString().PadLeft(6, Convert.ToChar("0"));
                    // OfficialName = 
                    // DetativeName = txtAddr1.Text.Trim(),
                    Sbf.OfficialName = string.Empty;// "Test name";
                    Sbf.DetativeName = DropDownDetective.SelectedItem.Text;// string.Empty;// "Test";
                    Sbf.Status = ((int)BLL.Constants.Status.NEW).ToString();// "New";
                    Sbf.SaveType = "Submit";
                    Sbf.Date = (txtDate.Text.Trim().ToString().Length > 0) ? Convert.ToDateTime(txtDate.Text.Trim()) : System.DateTime.Now;
                    Sbf.Custodian = txtCustodian.Text.Trim();
                    Sbf.RecordsPertainTo = txtRecordsPertainTo.Text.Trim();
                    Sbf.AddressIndividualBusiness = txtAddressIndividualBusiness.Text.Trim();
                    Sbf.CrimeUnderInvestigation = txtCrimeUnderInvestigation.Text.Trim();
                    if (UploadRepFile.HasFile)
                        Sbf.RepresentiveSignatureFile = getUploadFileName(CaseIdUpld, UploadRepFile.FileName, REPRESENTATIVE_SIGNATURE);
                    if (UploadSupFile.HasFile)
                        Sbf.SupervisorSignatureFile = getUploadFileName(CaseIdUpld, UploadSupFile.FileName, SUPERVISOR_SIGNATURE);
                    Sbf.FSS = txtFSS.Text.Trim();
                    Sbf.Suspect = txtSuspect.Text.Trim();
                    Sbf.Offense = txtOffense.Text.Trim();
                    Sbf.InformationRequested = txtInformationRequested.Text.Trim();
                    Sbf.IsDigitalSupervisor = RdoSupDigSig.Checked == true ? true : false;
                    Sbf.IsDigitalRepresentative = RdoDigSig.Checked == true ? true : false;
                    // Disclaimer = 
                    Sbf.ProbableCause = txtProbableCause.Text.Trim();
                    //   Sbf.SignatureRequired=txt
                  
                    Sbf.Active = true;
                    Sbf.UpdatedBy = Session["UserEmail"].ToString();
                    // Sbf.CreatedOn = System.DateTime.Now;
                    Sbf.UpdatedOn = System.DateTime.Now;
                    objDB.SubmitChanges();
                    showOutputMessage((int)BLL.Constants.MessageType.Success, "Subpoena submitted Successfully");
                }

            }
            else
            {

              //  string queryautonum = "select isnull(MAX(CaseId),0)+1 from TblSubpoenaFrm where  ISNUMERIC(CaseId)=1";
                string queryautonum = "select isnull(MAX(SUBSTRING(CaseId,6,6)),0)+1 from TblSubpoenaFrm";
                DataSet Result = DbConnection.GetMultitableTableData(queryautonum);
                using (AccreditationDataContext subpoena = new AccreditationDataContext())
                {
                    CaseIdUpld = "CASE-" + Result.Tables[0].Rows[0][0].ToString().PadLeft(6, Convert.ToChar("0"));
                    TblSubpoenaFrm subpoena1 = new TblSubpoenaFrm

                    {
                        SubpoenaName = txtSubpoenaName.Text.Trim(),
                        StateId = Convert.ToInt16(DrpDwnState.SelectedItem.Value),
                        CountyId = Convert.ToInt16(DrpDwnCounty.SelectedItem.Value),
                        GroupId = Convert.ToInt16(DropDownGroup.SelectedItem.Value),
                        Supervisor = txtSupervisor.Text.Trim(),
                        Representative = txtRepresentative.Text.Trim(),
                        PDFPath = pdfFileName,
                        DetectiveId = Convert.ToInt16(DropDownDetective.SelectedItem.Value),
                        CaseId = "CASE-" + Result.Tables[0].Rows[0][0].ToString().PadLeft(6, Convert.ToChar("0")),
                        // OfficialName = 
                        // DetativeName = txtAddr1.Text.Trim(),
                        OfficialName =string.Empty,// "Test name",
                        DetativeName =DropDownDetective.SelectedItem.Text,// "Test",
                        Status = ((int)BLL.Constants.Status.NEW).ToString(),//"New",
                        SaveType = "Submit",
                        Date = (txtDate.Text.Trim().ToString().Length > 0) ? Convert.ToDateTime(txtDate.Text.Trim()) : System.DateTime.Now,
                        Custodian = txtCustodian.Text.Trim(),
                        RecordsPertainTo = txtRecordsPertainTo.Text.Trim(),
                        AddressIndividualBusiness = txtAddressIndividualBusiness.Text.Trim(),
                        CrimeUnderInvestigation = txtCrimeUnderInvestigation.Text.Trim(),

                        IsDigitalSupervisor = RdoSupDigSig.Checked == true ? true : false,
                        IsDigitalRepresentative = RdoDigSig.Checked == true ? true : false,
                        RepresentiveSignatureFile = UploadRepFile.HasFile == true ? getUploadFileName(CaseIdUpld, UploadRepFile.FileName, REPRESENTATIVE_SIGNATURE) : string.Empty,
                        SupervisorSignatureFile = UploadSupFile.HasFile == true ? getUploadFileName(CaseIdUpld, UploadSupFile.FileName, SUPERVISOR_SIGNATURE) : string.Empty,

                        FSS = txtFSS.Text.Trim(),
                        Suspect = txtSuspect.Text.Trim(),
                        Offense = txtOffense.Text.Trim(),
                        InformationRequested = txtInformationRequested.Text.Trim(),
                        SignatureRequired = txtRepresentative.Text.Trim(),
                        RepresentativeSig = txtRepresentativeSig.Text.Trim(),
                        // Disclaimer = 
                        ProbableCause = txtProbableCause.Text.Trim(),
                        //Status =

                        Active = true,
                        CreatedOn = System.DateTime.Now,
                        CreatedBy = Session["UserEmail"].ToString(),
                        //UpdatedOn = System.DateTime.Now
                    };

                    if (UploadRepFile.HasFile)
                    {
                        UploadFile(getUploadFileName(CaseIdUpld, UploadRepFile.FileName, REPRESENTATIVE_SIGNATURE), REPRESENTATIVE_SIGNATURE);
                        HypRepSig.Text = getUploadFileName(CaseIdUpld, UploadRepFile.FileName, REPRESENTATIVE_SIGNATURE);
                        HypRepSig.NavigateUrl = "Uploads/Signature/" + getUploadFileName(CaseIdUpld, UploadRepFile.FileName, REPRESENTATIVE_SIGNATURE);
                    }

                    if (UploadSupFile.FileName != "")
                    {
                        UploadFile(getUploadFileName(CaseIdUpld, UploadSupFile.FileName, SUPERVISOR_SIGNATURE), SUPERVISOR_SIGNATURE);
                        HypSupSig.Text = getUploadFileName(CaseIdUpld, UploadSupFile.FileName, SUPERVISOR_SIGNATURE);
                        HypSupSig.NavigateUrl = getUploadFileName(CaseIdUpld, UploadSupFile.FileName, SUPERVISOR_SIGNATURE);
                    }

                    //UploadSupFile.SaveAs(Server.MapPath("Uploads/Signature\\" + UploadSupFile.FileName));
                    subpoena.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
                    subpoena.TblSubpoenaFrms.InsertOnSubmit(subpoena1);
                    subpoena.SubmitChanges();
                    subpoeanaCuurId = subpoena1.SubpoenaFrmId;
                    showOutputMessage((int)BLL.Constants.MessageType.Success, "Subpoena submitted Successfully");
                }

            }


            CreatePdfFile(pdfFileName);

            var userRegDetect = objDB.TblUserRegistrations.Where(x => x.UserId == Convert.ToInt16(DropDownDetective.SelectedItem.Value)).FirstOrDefault();
            SendMail(userRegDetect.UserEmail, userRegDetect.UserFirstName, subpoeanaCuurId, userRegDetect.Group);
            Response.AddHeader("REFRESH", "5;URL=SubpoenaProducers.aspx");
            //Response.Redirect("SubpoenaProducers.aspx");
            return;
        }

        /*
         *@Date: 30-09-2015 *
         *@desc :This Section for sending a mail to detective mail id.
         */
        protected void SendMail(string YourEmail, string name, int subpoeanaCuurId, int groupid)
        {

        /*
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var stsubpoeanrs =
                (from c in db.TblSubpoenaFrms
                 where c.SubpoenaFrmId == subpoeanaCuurId
                 select new
                 {
                     c.CaseId,
                     When = c.Date,
                     Wherefrom = (from x in db.TblGroupCreations.Where(p => p.GrpId == groupid) select x).FirstOrDefault().City + " " + (from x in db.TblStates.Where(p => p.StateId == c.StateId) select x).FirstOrDefault().StateName + "  " + (from x in db.TblCounties.Where(p => p.CountyId == c.CountyId) select x).FirstOrDefault().CountyName,
                     CalendarText = c.OfficialName,
                     EhoText = c.Offense,
                     c.SubpoenaFrmId
                 }


                 ).FirstOrDefault();

            string SiteRoot = ConfigurationManager.AppSettings["SiteRoot"];
            string MailBody = "";
            MailBody += " <html>";
            MailBody += "<body>";

            MailBody += "<table cellspacing='5' cellpadding='4' style='width:100%;border:1px solid rgba(0, 0, 0, 0.95)'>";
            MailBody += "<tr>";
            MailBody += " <td align='right'>Case Id :</td>";
            MailBody += " <td >" + stsubpoeanrs.CaseId + "</td>";

            MailBody += " </tr>";
            MailBody += "<tr>";
            MailBody += " <td align='right'>When :</td>";
            MailBody += "<td>" + stsubpoeanrs.When + "</td>";

            MailBody += " </tr>";
            MailBody += " <tr>";
            MailBody += " <td align='right'>Where :</td>";
            MailBody += " <td>" + stsubpoeanrs.Wherefrom + "</td>";

            MailBody += "</tr>";

            MailBody += " <tr>";
            MailBody += "  <td align='right'>Calendar :</td>";
            MailBody += " <td>" + stsubpoeanrs.CalendarText + "</td>";

            MailBody += "</tr>";
            MailBody += "<tr>";
            MailBody += " <td align='right'>Who :</td>";
            MailBody += " <td>None</td>";

            MailBody += " </tr>";

            MailBody += " <tr>";
            MailBody += "  <td align='right'>Going ?</td>";
            MailBody += " <td><a href='" + SiteRoot + "ActiveSupoena.aspx?Status=Yes&subpoeanaId=" + stsubpoeanrs.SubpoenaFrmId + "'>Yes</a> &nbsp;&nbsp; <a href='" + SiteRoot + "ActiveSupoena.aspx?Status=No&subpoeanaId=" + stsubpoeanrs.SubpoenaFrmId + "'>No</a></td>";

            MailBody += "</tr>";

            MailBody += "</table>";
            MailBody += "</body>";
            MailBody += "</html>";

            var fromAddress = new MailAddress(ConfigurationManager.AppSettings["VerificationSenderEmail"], "Subpoena");
            var toAddress = new MailAddress(YourEmail, name);

            string fromPassword = ConfigurationManager.AppSettings["EmailPassword"]; //"subpoena@123";
            const string subject = "Subject";
            const string body = "Body";

            var smtp = new SmtpClient
            {
                Host = ConfigurationManager.AppSettings["DomainName"],//"Smtpout.secureserver.net",// "smtp.gmail.com",
                //Port = 25,
                //EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = MailBody,
                IsBodyHtml=true
            })
            {
                smtp.Send(message);
            }

            */






            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var stsubpoeanrs =
                (from c in db.TblSubpoenaFrms
                 where c.SubpoenaFrmId == subpoeanaCuurId
                 select new
                 {
                     c.CaseId,
                     When = c.Date,
                     Wherefrom = (from x in db.TblGroupCreations.Where(p => p.GrpId == groupid) select x).FirstOrDefault().City + " " + (from x in db.TblStates.Where(p => p.StateId == c.StateId) select x).FirstOrDefault().StateName + "  " + (from x in db.TblCounties.Where(p => p.CountyId == c.CountyId) select x).FirstOrDefault().CountyName,
                     CalendarText = c.OfficialName,
                     EhoText = c.Offense,
                     c.SubpoenaFrmId
                 }


                 ).FirstOrDefault();
            string to = YourEmail;// "friend.rahul.rch@gmail.com";//ConfigurationManager.AppSettings["DomainName"];
            string smtpName = ConfigurationManager.AppSettings["DomainName"];
            string smtpPort = ConfigurationManager.AppSettings["EmailPort"];
            string bolssl = ConfigurationManager.AppSettings["isSSL"];
            string from = ConfigurationManager.AppSettings["VerificationSenderEmail"];
            string password = ConfigurationManager.AppSettings["EmailPassword"];
            string SiteRoot = ConfigurationManager.AppSettings["SiteRoot"];
            string subject = "Subpoena : New Subpoena Generated";
            string Body = "";
            Body += " <html>";
            Body += "<body>";

            Body += "<table cellspacing='5' cellpadding='4' style='width:100%;border:1px solid rgba(0, 0, 0, 0.95)'>";
            Body += "<tr>";
            Body += " <td align='right'>Case Id :</td>";
            Body += " <td >" + stsubpoeanrs.CaseId + "</td>";

            Body += " </tr>";
            Body += "<tr>";
            Body += " <td align='right'>When :</td>";
            Body += "<td>" + stsubpoeanrs.When + "</td>";

            Body += " </tr>";
            Body += " <tr>";
            Body += " <td align='right'>Where :</td>";
            Body += " <td>" + stsubpoeanrs.Wherefrom + "</td>";

            Body += "</tr>";

            Body += " <tr>";
            Body += "  <td align='right'>Calendar :</td>";
            Body += " <td>" + stsubpoeanrs.CalendarText + "</td>";

            Body += "</tr>";
            Body += "<tr>";
            Body += " <td align='right'>Who :</td>";
            Body += " <td>None</td>";

            Body += " </tr>";

            Body += " <tr>";
            Body += "  <td align='right'>Going ?</td>";
            Body += " <td><a href='" + SiteRoot + "ActiveSupoena.aspx?Status=Yes&subpoeanaId=" + stsubpoeanrs.SubpoenaFrmId + "'>Yes</a> "+
                            "&nbsp;&nbsp; <a href='" + SiteRoot + "ActiveSupoena.aspx?Status=No&subpoeanaId=" + stsubpoeanrs.SubpoenaFrmId + "'>No</a>"+
                            "&nbsp;&nbsp; <a href='" + SiteRoot + "ActiveSupoena.aspx?Status=MayBe&subpoeanaId=" + stsubpoeanrs.SubpoenaFrmId + "'>Later</a>" +
                            "</td>";

            Body += "</tr>";

            Body += "</table>";
            Body += "</body>";
            Body += "</html>";
            MailAddress mailAddFrom = new MailAddress(from, "Subpoena Admin");
            MailAddress mailAddTo= new MailAddress(to);
            using (MailMessage mm = new MailMessage(mailAddFrom, mailAddTo))
            {
                mm.Subject = subject;
                mm.Body = Body;
                //if (fuAttachment.HasFile)
                //{
                //    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
                //    mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
                //}

                string pdfFileName = txtSubpoenaName.Text + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_Subpoeana.pdf";

                CreatePdfFile(pdfFileName);

                string FilePath = Server.MapPath("~\\PdfReport\\" + pdfFileName);

                Attachment attachment = new Attachment(FilePath);
                mm.Attachments.Add(attachment);

                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = smtpName; //"smtp.gmail.com";
                smtp.EnableSsl = bool.Parse(bolssl);
                NetworkCredential NetworkCred = new NetworkCredential(from, password);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(smtpPort);
                smtp.Send(mm);
                //         ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
            }
        }
        // End Mail Function
        protected void OnchangeDrpDwnCounty(object sender, EventArgs e)
        {
            PupulateGroup();
        }
        protected void PupulateGroup()
        {
            //AccreditationDataContext db = new AccreditationDataContext();
            //db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            //var userdetactive =
            //    from c1 in db.TblUserRegistrations
            //    from c2 in db.TblGroupCreations.Where(x => x.GrpId == c1.Group && c1.userRole == "Detective" && x.CountryId == Convert.ToInt16(DrpDwnCounty.SelectedItem.Value) && x.StateId == Convert.ToInt16(DrpDwnState.SelectedItem.Value))
            //    select new { c1.UserId, Username = c1.UserFirstName + " " + c1.UserLastName };


            //DropDownDetective.DataSource = userdetactive;
            //DropDownDetective.DataTextField = "Username";
            //DropDownDetective.DataValueField = "UserId";
            //DropDownDetective.DataBind();
            //DropDownDetective.Items.Insert(0, new System.Web.UI.WebControls.ListItem("----Select detective----", "0"));

            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var Group =
                from c in db.TblGroupCreations
                where c.CountryId == Convert.ToInt32(DrpDwnCounty.SelectedItem.Value)
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

        protected void OnchangeexistingSubPoeana(object sender, EventArgs e)
        {
            int subpoeanaid = Convert.ToInt16(ExistingSubpoeanaList.SelectedItem.Value);
            AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var stsubpoeanrs =
                (from c in db.TblSubpoenaFrms
                 where c.SubpoenaFrmId == subpoeanaid
                 select c).FirstOrDefault();

            txtEditSubpoeanaId.Value = subpoeanaid.ToString();
            //ExistingSubpoeanaList.SelectedValue=stsubpoeanrs.
            txtSubpoenaName.Text = stsubpoeanrs.SubpoenaName;
            DrpDwnState.SelectedValue = stsubpoeanrs.StateId.ToString();
            PopulateState();
            DrpDwnCounty.SelectedValue = stsubpoeanrs.CountyId.ToString();
            PupulateGroup();
            DropDownGroup.SelectedValue = stsubpoeanrs.GroupId.ToString();
            //   if(DropDownDetective.Attributes.
            PopulateDetective();
            DropDownDetective.SelectedValue = stsubpoeanrs.DetectiveId.ToString();
            //     DropDownDetective.SelectedItem.Text = stsubpoeanrs.DetativeName.ToString();
            txtSupervisor.Text = stsubpoeanrs.Supervisor;
            txtRepresentative.Text = stsubpoeanrs.Representative;
            txtDate.Text = stsubpoeanrs.Date.ToString("yyyy-MM-dd");
            txtCustodian.Text = stsubpoeanrs.Custodian;
            txtRecordsPertainTo.Text = stsubpoeanrs.RecordsPertainTo;
            txtAddressIndividualBusiness.Text = stsubpoeanrs.AddressIndividualBusiness;
            txtCrimeUnderInvestigation.Text = stsubpoeanrs.CrimeUnderInvestigation;
            txtFSS.Text = stsubpoeanrs.FSS;
            txtSuspect.Text = stsubpoeanrs.Suspect;
            txtOffense.Text = stsubpoeanrs.Offense;
            txtInformationRequested.Text = stsubpoeanrs.InformationRequested;
            // chkboxYes.Text=;
            // chkboxNo.Text=stsubpoeanrs.SubpoenaName;
            txtProbableCause.Text = stsubpoeanrs.ProbableCause;
            txtRepresentativeSig.Text = stsubpoeanrs.RepresentativeSig;
            txtSupervisorSig.Text = stsubpoeanrs.SupervisorSig;
            txtSupervisorSig.Text = stsubpoeanrs.SupervisorSignatureRequired;
            HypRepSig.Text = stsubpoeanrs.RepresentiveSignatureFile;
            HypRepSig.NavigateUrl = "Uploads/Signature/" + stsubpoeanrs.RepresentiveSignatureFile;
            HypSupSig.Text = stsubpoeanrs.SupervisorSignatureFile;
            HypSupSig.NavigateUrl = "Uploads/Signature/" + stsubpoeanrs.SupervisorSignatureFile;

            if (stsubpoeanrs.Disclaimer == true)
                chkboxYes.Checked = true;
            else
                chkboxYes.Checked = false;

            if (stsubpoeanrs.DisclaimerYes == true)
                chkboxNo.Checked = true;
            else
                chkboxNo.Checked = false;

            if (stsubpoeanrs.IsDigitalRepresentative == true)
                RdoDigSig.Checked = true;
            else
                RdoSig.Checked = true;

            if (stsubpoeanrs.IsDigitalSupervisor == true)
                RdoSupDigSig.Checked = true;
            else
                RdoSupSig.Checked = true;

        }

        protected void ChooseSubpoeanaTempalteSubPoeana(object sender, EventArgs e)
        {

        }
        //protected void bntSubmit_Click(object sender, EventArgs e)
        //{
        //    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
        //    Phrase phrase = null;
        //    PdfPCell cell = null;
        //    PdfPTable table = null;
        //    iTextSharp.text.BaseColor color = null;

        //    document.Open();
        //    Paragraph heading = new Paragraph("Page Heading", new Font(Font.HELVETICA, 28f, Font.BOLD));
        //    //Header Table
        //    table = new PdfPTable(2);
        //    table.TotalWidth = 500f;
        //    table.LockedWidth = true;
        //    table.SetWidths(new float[] { 0.3f, 0.7f });

        //    //Company Logo
        //    cell = ImageCell("~/images/Edit.gif", 30f, PdfPCell.ALIGN_CENTER);
        //    table.AddCell(cell);

        //    //Company Name and Address
        //    phrase = new Phrase();
        //    phrase.Add(new Chunk("To: Office of the State Attorney First judical Circuit\n\n", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
        //    //phrase.Add(new Chunk("ABC Road,\n", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
        //    //phrase.Add(new Chunk("Salt Lake City,\n", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
        //    //phrase.Add(new Chunk("Florida, USA", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
        //    cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
        //    cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
        //    table.AddCell(cell);

        //    //Separater Line
        //    //color = new iTextSharp.text.BaseColor(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));
        //    //DrawLine(writer, 25f, document.Top - 79f, document.PageSize.Width - 25f, document.Top - 79f, color);
        //    //DrawLine(writer, 25f, document.Top - 80f, document.PageSize.Width - 25f, document.Top - 80f, color);
        //    //document.Add(table);

        //    //table = new PdfPTable(3);
        //    //table.HorizontalAlignment = Element.ALIGN_LEFT;
        //    //table.SetWidths(new float[] { 0.3f, 1f });
        //    //table.SpacingBefore = 10f;

        //    //Employee Details
        //    //cell = PhraseCell(new Phrase("Subpoena Record", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.UNDERLINE, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT);
        //    //cell.Colspan = 2;
        //    //table.AddCell(cell);
        //    //cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
        //    //cell.Colspan = 2;
        //    //cell.PaddingBottom = 30f;
        //    //table.AddCell(cell);

        //    //Photo
        //    //cell = ImageCell(string.Format("~/Signature/{0}", Session["signature"].ToString()), 25f, PdfPCell.ALIGN_CENTER);
        //    //table.AddCell(cell);

        //    //Name
        //    //phrase = new Phrase();
        //    //phrase.Add(new Chunk(" ", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
        //    //phrase.Add(new Chunk("", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
        //    //cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
        //    //cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
        //    //table.AddCell(cell);
        //    //document.Add(table);

        //    //DrawLine(writer, 160f, 80f, 160f, 690f, iTextSharp.text.BaseColor.BLACK);
        //    //DrawLine(writer, 115f, document.Top - 200f, document.PageSize.Width - 100f, document.Top - 200f, iTextSharp.text.BaseColor.BLACK);

        //    table = new PdfPTable(3);
        //    table.SetWidths(new float[] { 2f, 2f, 2f });
        //    table.TotalWidth = 500f;
        //    table.LockedWidth = true;
        //    table.SpacingBefore = 20f;
        //    table.HorizontalAlignment = Element.ALIGN_RIGHT;

        //    //Deatails
        //    table.AddCell(PhraseCell(new Phrase("Supervisor:", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
        //    table.AddCell(PhraseCell(new Phrase(txtSubpoenaName.Text, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
        //    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
        //    //cell.Colspan = 2;
        //    cell.PaddingBottom = 10f;
        //    table.AddCell(cell);

        //    table.AddCell(PhraseCell(new Phrase("Representative:", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
        //    table.AddCell(PhraseCell(new Phrase(txtRepresentative.Text, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
        //    //table.AddCell(PhraseCell(new Phrase(DrpDwnState.SelectedItem.Text, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
        //    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
        //    //cell.Colspan = 2;
        //    cell.PaddingBottom = 10f;
        //    table.AddCell(cell);

        //    table.AddCell(PhraseCell(new Phrase("Date :", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
        //    table.AddCell(PhraseCell(new Phrase(txtDate.Text, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
        //    // table.AddCell(PhraseCell(new Phrase(DrpDwnCounty.SelectedItem.Text, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
        //    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
        //    //cell.Colspan = 2;
        //    cell.PaddingBottom = 10f;
        //    table.AddCell(cell);

        //    table.AddCell(PhraseCell(new Phrase("Supervisor :", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
        //    table.AddCell(PhraseCell(new Phrase(txtSupervisor.Text, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
        //    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
        //    cell.Colspan = 2;
        //    cell.PaddingBottom = 10f;
        //    table.AddCell(cell);



        //    table.AddCell(PhraseCell(new Phrase("Representative :", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
        //    table.AddCell(PhraseCell(new Phrase(txtRepresentative.Text, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
        //    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
        //    cell.Colspan = 2;
        //    cell.PaddingBottom = 10f;
        //    table.AddCell(cell);
        //    //EmpDetails
        //    table.AddCell(PhraseCell(new Phrase("Date:", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
        //    phrase = new Phrase(new Chunk(txtDate.Text + "\n", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));

        //    table.AddCell(PhraseCell(phrase, PdfPCell.ALIGN_LEFT));
        //    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
        //    cell.Colspan = 2;
        //    cell.PaddingBottom = 10f;
        //    table.AddCell(cell);

        //    // table.AddCell(PhraseCell(new Phrase(Label5.Text, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
        //    phrase = new Phrase(new Chunk("Custodian:" + txtCustodian.Text + "\n", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));

        //    table.AddCell(PhraseCell(phrase, PdfPCell.ALIGN_LEFT));
        //    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
        //    cell.Colspan = 2;
        //    cell.PaddingBottom = 10f;
        //    table.AddCell(cell);
        //    if (Session["signature"] != null)
        //    {

        //        if (!string.IsNullOrEmpty(Session["signature"].ToString()))
        //        {

        //            cell = ImageCell(string.Format("~/Signature/{0}", Session["signature"].ToString()), 25f, PdfPCell.ALIGN_LEFT);
        //            cell.PaddingTop = 25f;
        //            //cell = ImageCell("~/images/Edit.jpg", 30f, PdfPCell.ALIGN_CENTER);
        //            table.AddCell(cell);
        //        }
        //    }
        //    table.AddCell(PhraseCell(new Phrase("", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
        //    phrase = new Phrase(new Chunk("" + "\n", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));

        //    table.AddCell(PhraseCell(phrase, PdfPCell.ALIGN_LEFT));
        //    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
        //    cell.Colspan = 2;
        //    cell.PaddingBottom = 10f;
        //    table.AddCell(cell);
        //    document.Add(table);
        //    document.Close();
        //    byte[] bytes = memoryStream.ToArray();
        //    memoryStream.Close();
        //    Response.Clear();
        //    Response.ContentType = "application/pdf";
        //    Response.AddHeader("Content-Disposition", "attachment; filename=Subpoena.pdf");
        //    Response.ContentType = "application/pdf";
        //    Response.Buffer = true;
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.BinaryWrite(bytes);
        //    Response.End();
        //    Response.Close();
        //}


        //////// Added By Rahul //////////
        protected void OnchangeDrpDwnState(object sender, EventArgs e)
        {
            PopulateState();
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
        protected void chkboxYes_CheckedChanged(object sender, EventArgs e)
        { }

        protected void OnchangeDrpDwnGroup(object sender, EventArgs e)
        {
            PopulateDetective();
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
        protected void RepresentativeSignature(object sender, EventArgs e)
        {

            chkRepChanges();
        }
        protected void chkRepChanges()
        { 
            if (RdoSig.Checked == true)
                {
                    txtRepresentativeSig.Enabled = true;
                    UploadRepFile.Enabled = false;
                }
                if (RdoDigSig.Checked == true)
                {
                    txtRepresentativeSig.Enabled = false;
                    UploadRepFile.Enabled = true;
                }
        }
        protected void SupervisorSignature(object sender, EventArgs e)
        {
            chkSupChanges();

        }
        protected void chkSupChanges()
        {
            if (RdoSupSig.Checked == true)
            {
                txtSupervisorSig.Enabled = true;
                UploadSupFile.Enabled = false;
            }
            if (RdoSupDigSig.Checked == true)
            {
                txtSupervisorSig.Enabled = false;
                UploadSupFile.Enabled = true;
            }
        }
    }
}
