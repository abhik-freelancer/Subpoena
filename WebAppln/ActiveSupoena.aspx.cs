using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LINQ;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace WebAppln
{
    public partial class ActiveSupoena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string subpoeanaId = Request.QueryString["subpoeanaId"];
            string status = Request.QueryString["Status"];
            string message = string.Empty;

             AccreditationDataContext db = new AccreditationDataContext();
            db.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["constr"];
            var stsubpoeanrs =
                (from c in db.TblSubpoenaFrms
                 where c.SubpoenaFrmId == int.Parse(subpoeanaId)
                 select c).FirstOrDefault();
            if (status.ToLower() == "yes")
            {
                stsubpoeanrs.Status = ((int)BLL.Constants.Status.YES).ToString(); //"Close";
                stsubpoeanrs.UpdatedOn = DateTime.Now;
                db.SubmitChanges();
                lblMessage.Text = "Accepted subpoena";
                message = "Subpoena hass been accepted by detective";
            }
            else if (status.ToLower() == "maybe")
            {
                stsubpoeanrs.Status = ((int)BLL.Constants.Status.MAYBE).ToString(); //"Close";
                stsubpoeanrs.UpdatedOn = DateTime.Now;
                db.SubmitChanges();
                lblMessage.Text = "Subpoena accepted";
                message = "Subpoena hass been accepted by detective with may be late comment.";
            }
            else
            {
                stsubpoeanrs.Status = ((int)BLL.Constants.Status.NO).ToString();// "Rejected";
                stsubpoeanrs.SaveType = "Save"; //Rejected subpoena change to save status.
                stsubpoeanrs.UpdatedOn = DateTime.Now;
                db.SubmitChanges();
                lblMessage.Text = "Rejected subpoena";
                message = "Subpoena hass been rejected by detective. <br/>Subpoena changed to Save state";
            }
            //stsubpoeanrs.CreatedBy
            SendMail(stsubpoeanrs.CreatedBy, stsubpoeanrs.SubpoenaName, message);
        }

        protected void SendMail(string YourEmail, string subPoneaName, string message)
        {
            string to = YourEmail;
            string smtpName = ConfigurationManager.AppSettings["DomainName"];
            string smtpPort = ConfigurationManager.AppSettings["EmailPort"];
            string bolSsl = ConfigurationManager.AppSettings["isSSL"];
            string from = ConfigurationManager.AppSettings["VerificationSenderEmail"];
            string password = ConfigurationManager.AppSettings["EmailPassword"];
            string SiteRoot = ConfigurationManager.AppSettings["SiteRoot"];
            string subject = "Subpoena: Detective Confirmation";
            string Body = "";
            Body += " <html>";
            Body += "<body>";
            Body += "<table cellspacing='5' cellpadding='4' style='width:100%;border:1px solid rgba(0, 0, 0, 0.95)'>";
            Body += "<tr>";
            Body += "<td>Subpoena : </td><td> " + subPoneaName + "</td>";
            Body += "</tr>";
            Body += "<tr>";
            Body += "<td>&nbsp; </td><td>" + message + "</td>";
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
                smtp.EnableSsl = bool.Parse(bolSsl);
                NetworkCredential NetworkCred = new NetworkCredential(from, password);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(smtpPort);
                smtp.Send(mm);

                //         ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
            }
        }
    }
}