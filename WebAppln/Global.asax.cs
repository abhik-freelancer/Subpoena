using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace WebAppln
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
           // BundleConfig.RegisterBundles(BundleTable.Bundles);

            //ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            //{
            //    Path = "~/scripts/jquery-2.0.2.min.js",
            //    DebugPath = "~/scripts/jquery-2.0.2.js",
            //    CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-2.0.2.min.js",
            //    CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-2.0.2.js"
            //});

        }
    }
}