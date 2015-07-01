using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ;

namespace BLL
{
   public static class ErrorLog
    {
        public static IEnumerable<LINQ.ErrorLog> ColumnSort(string sortExpression, string direction)
        {
            AccreditationDataContext dbContext = new AccreditationDataContext();
            IEnumerable<LINQ.ErrorLog> errors = null;
            switch (sortExpression)
            {
                case "Description":
                    if (direction.Contains("ASC"))
                        errors = from e in dbContext.ErrorLogs orderby e.Description ascending select e;
                    else
                        errors = from e in dbContext.ErrorLogs orderby e.Description descending select e;
                    return errors;
                case "Page":
                    if (direction.Contains("ASC"))
                        errors = from e in dbContext.ErrorLogs orderby e.Page ascending select e;
                    else
                        errors = from e in dbContext.ErrorLogs orderby e.Page descending select e;
                    return errors;
                case "PostBackData":
                    if (direction.Contains("ASC"))
                        errors = from e in dbContext.ErrorLogs orderby e.PostBackData ascending select e;
                    else
                        errors = from e in dbContext.ErrorLogs orderby e.PostBackData descending select e;
                    return errors;
                case "BrowserName":
                    if (direction.Contains("ASC"))
                        errors = from e in dbContext.ErrorLogs orderby e.BrowserName ascending select e;
                    else
                        errors = from e in dbContext.ErrorLogs orderby e.BrowserName descending select e;
                    return errors;
                case "BrowserVersion":
                    if (direction.Contains("ASC"))
                        errors = from e in dbContext.ErrorLogs orderby e.BrowserVersion ascending select e;
                    else
                        errors = from e in dbContext.ErrorLogs orderby e.BrowserVersion descending select e;
                    return errors;
                case "BrowserPlatform":
                    if (direction.Contains("ASC"))
                        errors = from e in dbContext.ErrorLogs orderby e.BrowserPlatform ascending select e;
                    else
                        errors = from e in dbContext.ErrorLogs orderby e.BrowserPlatform descending select e;
                    return errors;
                case "MinorError":
                    if (direction.Contains("ASC"))
                        errors = from e in dbContext.ErrorLogs orderby e.MinorError ascending select e;
                    else
                        errors = from e in dbContext.ErrorLogs orderby e.MinorError descending select e;
                    return errors;
                case "StackTrace":
                    if (direction.Contains("ASC"))
                        errors = from e in dbContext.ErrorLogs orderby e.StackTrace ascending select e;
                    else
                        errors = from e in dbContext.ErrorLogs orderby e.StackTrace descending select e;
                    return errors;
                case "Time":
                    if (direction.Contains("ASC"))
                        errors = from e in dbContext.ErrorLogs orderby e.Time ascending select e;
                    else
                        errors = from e in dbContext.ErrorLogs orderby e.Time descending select e;
                    return errors;
                case "UserID":
                    if (direction.Contains("ASC"))
                        errors = from e in dbContext.ErrorLogs orderby e.UserID ascending select e;
                    else
                        errors = from e in dbContext.ErrorLogs orderby e.UserID descending select e;
                    return errors;
                default:
                    errors = from e in dbContext.ErrorLogs orderby e.UserID ascending select e;
                    return errors;
            }
        }
    }
}
