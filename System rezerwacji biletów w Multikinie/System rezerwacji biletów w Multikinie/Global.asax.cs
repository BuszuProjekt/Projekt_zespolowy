using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using WebMatrix.WebData;

namespace System_rezerwacji_biletów_w_Multikinie
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            Initial();
        }

        private void Initial()
        {
            if (!Roles.RoleExists("Client"))
            {
                Roles.CreateRole("Client");
            }
            if (!Roles.RoleExists("Admin"))
            {
                Roles.CreateRole("Admin");
                WebSecurity.CreateUserAndAccount("Admin", "qwerty12345");
                Roles.AddUserToRole("Admin", "Admin");
            }
            if (!Roles.RoleExists("Worker"))
            {
                Roles.CreateRole("Worker");
                WebSecurity.CreateUserAndAccount("Ilona", "qwerty12345");
                Roles.AddUserToRole("Ilona", "Worker");
            }
        }
    }
}