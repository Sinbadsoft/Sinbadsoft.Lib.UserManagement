﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;

using MonkeyOrm;

using Sinbadsoft.Lib.UserManagement;

namespace SampleWebApplication
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            var connectionString = WebConfigurationManager.ConnectionStrings["default"].ConnectionString;
            var connectionFactory = new DbProviderBasedConnectionFactory("default", connectionString);

            using (var connection = connectionFactory.Create())
            {
                connection.Open();
                if (connection.ReadOne(
                    @"SELECT EXISTS(SELECT 1 
                      FROM information_schema.tables 
                      WHERE table_schema=@Database AND table_name='Users') As HasTable",
                    new { connection.Database }).HasTable != 0)
                {
                    UsersTable.Create(connection);
                }
            }
        }
    }
}