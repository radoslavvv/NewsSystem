using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NewsSystem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
            name: "Create Category",
            url: "category/create",
            defaults: new { controller = "Category", action = "Create" }
            );

            routes.MapRoute(
           name: "Delete Category",
           url: "category/delete/{id}",
           defaults: new { controller = "Category", action = "Delete" }
           );

            routes.MapRoute(
            name: "Edit Category",
            url: "category/edit/{id}",
            defaults: new { controller = "Category", action = "Edit" }
            );

            routes.MapRoute(
              name: "List All Categories",
              url: "category/all",
              defaults: new { controller = "Category", action = "ListAllCategories" }
          );

            routes.MapRoute(
                name: "List All Articles Of Category",
                url: "category/all/{categoryName}",
                defaults: new { controller = "Category", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
