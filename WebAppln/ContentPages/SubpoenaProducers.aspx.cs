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
using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Configuration;
using System.Data;
using System.IO;
using System.Collections.Generic;
namespace Website.Pages
{
    public partial class SubpoenaProducers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showState();
                showCounty();
            }
        }

        protected void btnNewSubpoena_Click(object sender, EventArgs e)
        {

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
                DrpDwnState.Items.Insert(0, "--Select State--");
            }

        }
        private void showCounty()
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
                DrpDwnCounty.Items.Insert(0, "---Select County---");
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //if (DrpDwnCity.SelectedIndex > 0 && txtGrpName.Text.Trim() != string.Empty
            //    && txtNatureofBsns1.Text.Trim() != string.Empty && txtAddr1.Text.Trim() != string.Empty)
            try
            {
                if (btnSave.Text.Equals("Save"))
                {
                    using (AccreditationDataContext subpoena = new AccreditationDataContext())
                    {
                        TblSubpoenaFrm subpoena1 = new TblSubpoenaFrm
                        
                        {
                            SubpoenaName = txtSubpoenaName.Text.Trim(),
                            StateId = Convert.ToInt16(DrpDwnState.SelectedItem.Value),
                            CountyId = Convert.ToInt16(DrpDwnCounty.SelectedItem.Value),
                            Supervisor = txtSupervisor.Text.Trim(),
                            Representative = txtRepresentative.Text.Trim(),
                           // OfficialName = 
                           // DetativeName = txtAddr1.Text.Trim(),

                            Date =(txtDate.Text.Trim().ToString().Length>0)? Convert.ToDateTime(txtDate.Text.Trim()):System.DateTime.Now,
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
                           
                            Active = true,
                            CreatedOn = System.DateTime.Now,
                            UpdatedOn = System.DateTime.Now
                        };
                        subpoena.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
                        subpoena.TblSubpoenaFrms.InsertOnSubmit(subpoena1);
                        subpoena.SubmitChanges();

                    }
                }
                else
                {
                    //Update((int)Session["ID"], txtGrpName.Text, txtNatureofBsns1.Text, txtEn.Text,
                    //    txtNacSsc.Text,
                    //    Convert.ToDateTime(txtEnDate.Text),
                    //    txtLogo.Text,
                    //    txtAddr1.Text, txtAddr2.Text,
                    //    Convert.ToInt32(DrpDwnCity.SelectedItem.Value), Convert.ToInt32(DrpDwnState.SelectedItem.Value),
                    //    txtZipCode.Text
                    //    );
                    //btnSave.Text = "Save";
                }
                // ClearForm();
                //ViewData();
                ClearForm();
                //tblForm1.Visible = false;
            }
            catch(Exception Ex)
            { }

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

        protected void bntPreview_Click(object sender, EventArgs e)
        {
            CreatePdfFile();
        }

        private void CreatePdfFile()
        {
            Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
            iTextSharp.text.Font NormalFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                Phrase phrase = null;
                PdfPCell cell = null;
                PdfPTable table = null;
                iTextSharp.text.BaseColor color = null;

                document.Open();

                //Header Table
                table = new PdfPTable(2);
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SetWidths(new float[] { 0.3f, 0.7f });

                //Company Logo
                cell = ImageCell("~/images/Edit.jpg", 30f, PdfPCell.ALIGN_CENTER);
                table.AddCell(cell);

                //Company Name and Address
                phrase = new Phrase();
                phrase.Add(new Chunk("Sudipta Pvt Company\n\n", FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.RED)));
                phrase.Add(new Chunk("ABC Road,\n", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                phrase.Add(new Chunk("Salt Lake City,\n", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                phrase.Add(new Chunk("Florida, USA", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                table.AddCell(cell);

                //Separater Line
                color = new iTextSharp.text.BaseColor(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));
                DrawLine(writer, 25f, document.Top - 79f, document.PageSize.Width - 25f, document.Top - 79f, color);
                DrawLine(writer, 25f, document.Top - 80f, document.PageSize.Width - 25f, document.Top - 80f, color);
                document.Add(table);

                table = new PdfPTable(2);
                table.HorizontalAlignment = Element.ALIGN_LEFT;
                table.SetWidths(new float[] { 0.3f, 1f });
                table.SpacingBefore = 20f;

                //Employee Details
                cell = PhraseCell(new Phrase("Subpoena Record", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.UNDERLINE, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 30f;
                table.AddCell(cell);

                //Photo
                //cell = ImageCell(string.Format("~/Signature/{0}", Session["signature"].ToString()), 25f, PdfPCell.ALIGN_CENTER);
                //table.AddCell(cell);

                //Name
                phrase = new Phrase();
                phrase.Add(new Chunk(" ", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                phrase.Add(new Chunk("", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(cell);
                document.Add(table);

                //DrawLine(writer, 160f, 80f, 160f, 690f, iTextSharp.text.BaseColor.BLACK);
                //DrawLine(writer, 115f, document.Top - 200f, document.PageSize.Width - 100f, document.Top - 200f, iTextSharp.text.BaseColor.BLACK);

                table = new PdfPTable(2);
                table.SetWidths(new float[] { 0.5f, 2f });
                table.TotalWidth = 340f;
                table.LockedWidth = true;
                table.SpacingBefore = 20f;
                table.HorizontalAlignment = Element.ALIGN_RIGHT;

                //Deatails
                table.AddCell(PhraseCell(new Phrase("Subpoena:", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(txtSubpoenaName.Text , FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                table.AddCell(cell);

                table.AddCell(PhraseCell(new Phrase("State:", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(DrpDwnState.SelectedItem.Text, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                table.AddCell(cell);

                table.AddCell(PhraseCell(new Phrase("County :", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(DrpDwnCounty.SelectedItem.Text, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                table.AddCell(cell);

                table.AddCell(PhraseCell(new Phrase("Supervisor :", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(txtSupervisor.Text, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                table.AddCell(cell);



                table.AddCell(PhraseCell(new Phrase("Representative :", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(txtRepresentative.Text, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                table.AddCell(cell);
                //EmpDetails
                table.AddCell(PhraseCell(new Phrase("Date:", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                phrase = new Phrase(new Chunk(txtDate.Text + "\n", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));

                table.AddCell(PhraseCell(phrase, PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                table.AddCell(cell);

                table.AddCell(PhraseCell(new Phrase(Label5.Text, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                phrase = new Phrase(new Chunk("Custodian:" + txtCustodian.Text + "\n", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));

                table.AddCell(PhraseCell(phrase, PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                table.AddCell(cell);
                if (Session["signature"] != null)
                {

                    if (!string.IsNullOrEmpty(Session["signature"].ToString()))
                    {

                        cell = ImageCell(string.Format("~/Signature/{0}", Session["signature"].ToString()), 25f, PdfPCell.ALIGN_LEFT);
                        cell.PaddingTop = 25f;
                        //cell = ImageCell("~/images/Edit.jpg", 30f, PdfPCell.ALIGN_CENTER);
                        table.AddCell(cell);
                    }
                }
                table.AddCell(PhraseCell(new Phrase("", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                phrase = new Phrase(new Chunk("" + "\n", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));

                table.AddCell(PhraseCell(phrase, PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                table.AddCell(cell);
                document.Add(table);
                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=Subpoena.pdf");
                Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();
            }
        }
        private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, iTextSharp.text.BaseColor color)
        {
            PdfContentByte contentByte = writer.DirectContent;
            contentByte.SetColorStroke(color);
            contentByte.MoveTo(x1, y1);
            contentByte.LineTo(x2, y2);
            contentByte.Stroke();
        }
        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = iTextSharp.text.BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            return cell;
        }
        private static PdfPCell ImageCell(string path, float scale, int align)
        {
            
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
                image.ScalePercent(scale);
                PdfPCell cell = new PdfPCell(image);
                cell.BorderColor = iTextSharp.text.BaseColor.WHITE;
                cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                cell.HorizontalAlignment = align;
                cell.PaddingBottom = 0f;
                cell.PaddingTop = 0f;
                return cell;
            
        }

        protected void bntSubmit_Click(object sender, EventArgs e)
        {

        }

    }
}
