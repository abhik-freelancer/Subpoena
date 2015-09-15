using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using System.Security.Cryptography;
//using FileHelpers;
public partial class DbConnection 
{
    public static string GetHash(string password)
    {
        //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
        var sha1 = new SHA1CryptoServiceProvider();

        var originalBytes = Encoding.Default.GetBytes(password + "kajalhazra");
        var encodedBytes = sha1.ComputeHash(originalBytes);

        //Convert encoded bytes back to a 'readable' string
        return BitConverter.ToString(encodedBytes);
    }

    public static string GetData(string Query, ref int CountRow)
    {

        string conString = System.Configuration.ConfigurationManager.ConnectionStrings["constrww"].ToString();
        SqlConnection Connection = new SqlConnection(conString);
        Connection.Open();
        SqlCommand cmdXls = new SqlCommand(Query, Connection);
        SqlDataAdapter daXls = new SqlDataAdapter(cmdXls);
        DataSet dsXls = new DataSet();
        string StrJsion = "";
        try
            {
                daXls.Fill(dsXls);
                if (dsXls.Tables.Count > 1)
                {
                    CountRow = Convert.ToInt32(dsXls.Tables[1].Rows[0][0]);
                    StrJsion = JsonConvert.SerializeObject(dsXls.Tables[0], Formatting.Indented);
                   
                }
                else
                {
                    StrJsion = JsonConvert.SerializeObject(dsXls.Tables[0], Formatting.Indented);
                }
            }
            catch (Exception  e)
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
        return StrJsion;
              
    }
    public static void GetPositionOfData(string Q1, ref int postion)
    {

        string conString = System.Configuration.ConfigurationManager.ConnectionStrings["constrww"].ToString();
        SqlConnection Connection = new SqlConnection(conString);
        Connection.Open();
        SqlCommand cmdXls = new SqlCommand(Q1, Connection);
        SqlDataAdapter daXls = new SqlDataAdapter(cmdXls);
        DataSet dsXls = new DataSet();
        
        try
        {
            daXls.Fill(dsXls);
           foreach(DataRow row in dsXls.Tables[0].Rows)
               {
                   postion = int.Parse(row["row"].ToString());
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
       

    }
    public static string CheckConnect()
    {
        string msg = "";
        WebClient client = new WebClient();
        byte[] datasize = null;
        try
        {
            datasize = client.DownloadData("http://www.google.com");
        }
        catch (Exception ex)
        {
        }
        if (datasize != null && datasize.Length > 0)
            msg = "Internet Connection Available.";
        else
            msg = "Internet Connection Not Available.";
        return msg;
    }
    public static void GetPrevOfData(string Q2, ref int PrevId)
    {

        string conString = System.Configuration.ConfigurationManager.ConnectionStrings["constrww"].ToString();
        SqlConnection Connection = new SqlConnection(conString);
        Connection.Open();
        SqlCommand cmdXls = new SqlCommand(Q2, Connection);
        SqlDataAdapter daXls = new SqlDataAdapter(cmdXls);
        DataSet dsXls = new DataSet();
       
        try
        {
            daXls.Fill(dsXls);
            foreach (DataRow row in dsXls.Tables[0].Rows)
            {
                PrevId = int.Parse(row["Id"].ToString());
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
     

    }
    public static void GetNextData(string Q3, ref int NextId)
    {

        string conString = System.Configuration.ConfigurationManager.ConnectionStrings["constrww"].ToString();
        SqlConnection Connection = new SqlConnection(conString);
        Connection.Open();
        SqlCommand cmdXls = new SqlCommand(Q3, Connection);
        SqlDataAdapter daXls = new SqlDataAdapter(cmdXls);
        DataSet dsXls = new DataSet();
        
        try
        {
            daXls.Fill(dsXls);
            foreach (DataRow row in dsXls.Tables[0].Rows)
            {
                NextId = int.Parse(row["Id"].ToString());
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
    

    }
    public static string ToCSV(DataTable table)
    {
        //---------------------------------------  Create comma delimetar (CSV) file create here
        var delimator = ",";
        var result = new StringBuilder();
        for (int i = 0; i < table.Columns.Count; i++)
        {
            result.Append(table.Columns[i].ColumnName);
            result.Append(i == table.Columns.Count - 1 ? ";" : delimator);
        }
        foreach (DataRow row in table.Rows)
        {
            for (int i = 0; i < table.Columns.Count; i++)
            {
                result.Append(row[i].ToString());
                result.Append(i == table.Columns.Count - 1 ? ";" : delimator);
            }
        }
        return result.ToString().TrimEnd(new char[] { '\r', '\n' });
        //---------------------------------------------------------------------return result.ToString();
    }


    public static  DataTable GetOneTableData(string Query)
    {

        string conString = System.Configuration.ConfigurationManager.ConnectionStrings["constrww"].ToString();
        SqlConnection Connection = new SqlConnection(conString);
        Connection.Open();
        SqlCommand cmdXls = new SqlCommand(Query, Connection);
        SqlDataAdapter daXls = new SqlDataAdapter(cmdXls);
        DataTable dsXls = new DataTable();
        
        try
        {
            daXls.Fill(dsXls);
           
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
        return dsXls;

    }



    public static DataSet GetMultitableTableData(string Query)
    {

        string conString = System.Configuration.ConfigurationManager.ConnectionStrings["constrww"].ToString();
        SqlConnection Connection = new SqlConnection(conString);
        Connection.Open();
        SqlCommand cmdXls = new SqlCommand(Query, Connection);
        SqlDataAdapter daXls = new SqlDataAdapter(cmdXls);
        DataSet dsXls = new DataSet();

        try
        {
            daXls.Fill(dsXls);

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
        return dsXls;

    }

    public static void ExecuteMyQuery(string Query)
    {

        string conString = System.Configuration.ConfigurationManager.ConnectionStrings["constrww"].ToString();
        SqlConnection Connection = new SqlConnection(conString);
        Connection.Open();
        SqlCommand cmdXls = new SqlCommand(Query, Connection);
        
        try
        {
            cmdXls.ExecuteNonQuery();
        }
        catch (Exception e)
        {
           
            cmdXls.Dispose();
         
            Connection.Dispose();
        }
        finally
        {
           
            cmdXls.Dispose();
          
            Connection.Dispose();

        }

    }



}