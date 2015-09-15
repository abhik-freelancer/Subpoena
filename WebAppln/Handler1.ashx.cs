using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Text;
using System;
using System.Web.Script.Serialization;
using WebAppln.Models;
namespace WebAppln
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            System.Collections.Specialized.NameValueCollection forms = context.Request.Form;
            string ShortOrderBy = forms.Get("sidx").ToString();
            string Sord = forms.Get("sord").ToString();
            string filterquery = "";
            string filtersJson = "";
            //bool flag = true;
            if (Convert.ToBoolean(forms.Get("_search").ToString()))
            {
                filtersJson = forms.Get("filters").ToString();
                var serializer = new JavaScriptSerializer();
                //  Filter xfilters = serializer.Deserialize<Filter>(filters);
                Filter xfilters = serializer.Deserialize<Filter>(filtersJson);
                foreach (var xx in xfilters.rules)
                {
                    if (filterquery.ToString().Trim() != "")
                    {
                        filterquery += "  AND ";
                    }
                    filterquery += xx.field + " like  '" + xx.data + "%'";

                }

            }
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["constrww"].ToString();
            SqlConnection Connection = new SqlConnection(conString);
            Connection.Open();
            int pageIndex = 0;
            int pageSize = 0;
            string Query = forms.Get("QueryString").ToString();

            string Query3 = Query;
            //if (forms.Get("rows").ToString() != "All")
            //{
            pageIndex = Convert.ToInt32(forms.Get("page").ToString());
            pageSize = Convert.ToInt32(forms.Get("rows").ToString());
            if (filterquery.Trim() == "")
            {
                filterquery = "1=1";
            }
            Query = Query.Replace("##paging##", "  row Between " + ((pageIndex - 1) * pageSize + 1) + " and  " + (pageIndex * pageSize) + "");
            Query = Query.Replace("##ID##", ShortOrderBy);
            Query = Query.Replace("##desc##", Sord);
            Query = Query.Replace("##filters##", filterquery);

            Query3 = Query3.Replace("##paging##", " 1 = 1 ");
            //}
            //else
            //{
            //    pageIndex = 1;
            //    pageSize =999999999;
            //    Query = Query.Replace("##paging##", " 1=1 ");

            //}

            Query3 = Query3.Replace("##ID##", ShortOrderBy);
            Query3 = Query3.Replace("##desc##", Sord);
            Query3 = Query3.Replace("##filters##", filterquery);
            string actquery = Query;

            //if (filterquery.ToString().Trim() != "")
            //{
            //    Query = "select * from ( " + actquery + " ) AS XX where " + filterquery;
            //    Query += "; SELECT  COUNT(*) FROM ( " + Query3 + " ) AS YY where " + filterquery;
            //}
            //else
            //{
            //    Query += "; SELECT  COUNT(*) FROM ( " + Query3 + " ) AS YY ";

            //}
            Query += "; SELECT  COUNT(*) FROM ( " + Query3 + " ) AS YY ";

            SqlCommand cmdXls = new SqlCommand(Query, Connection);
            SqlDataAdapter daXls = new SqlDataAdapter(cmdXls);
            DataSet dsXls = new DataSet();
            string StrJsion = "";
            int totalPages;
            int totalRecords;
            try
            {
                daXls.Fill(dsXls);
                if (dsXls.Tables.Count > 1)
                {
                    totalRecords = Convert.ToInt32(dsXls.Tables[1].Rows[0][0]);
                    totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);
                    StrJsion = "{\"page\":" + pageIndex + ",\"total\":" + totalPages + ",\"records\":" + totalRecords + ",\"rows\":" + JsonConvert.SerializeObject(dsXls.Tables[0], Formatting.Indented) + "}";

                }
                else
                {
                    if (dsXls.Tables[0].Rows.Count > 0)
                    {
                        totalRecords = Convert.ToInt32(dsXls.Tables[0].Rows.Count);
                        // if (forms.Get("rows").ToString() != "All")
                        //{
                        //    totalPages = 1;
                        //}
                        //else 
                        //{
                        totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);
                        //}


                        StrJsion = "{\"page\":" + pageIndex + ",\"total\":" + totalPages + ",\"records\":" + totalRecords + ",\"rows\":" + JsonConvert.SerializeObject(dsXls.Tables[0], Formatting.Indented) + "}";

                    }
                }



            }
            catch (Exception e)
            {
                dsXls.Dispose();
                cmdXls.Dispose();
                daXls.Dispose();
                Connection.Dispose();
            }
            finally
            {
                dsXls.Dispose();
                cmdXls.Dispose();
                daXls.Dispose();
                Connection.Dispose();
            }
            //context.Response.ContentType = "text/plain";
            context.Response.Write(StrJsion);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}