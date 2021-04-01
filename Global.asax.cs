using AdminPortal.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace AdminPortal
{
    public class Global : HttpApplication
    {
        public static int ID;
        void Application_Start(object sender, EventArgs e)
        {
            DatabaseConnectionModel.Database = ConfigurationManager.AppSettings["Database"];
            DatabaseConnectionModel.Server = ConfigurationManager.AppSettings["Server"];
            DatabaseConnectionModel.Username = ConfigurationManager.AppSettings["Username"];
            DatabaseConnectionModel.Password = ConfigurationManager.AppSettings["Password"];

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}