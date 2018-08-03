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
              name: "Like Article",
              url: "article/details/{id}/like",
              defaults: new { controller = "Article", action = "Like" }
           );

            routes.MapRoute(
              name: "Dislike Article",
              url: "article/details/{id}/dislike",
              defaults: new { controller = "Article", action = "Dislike" }
           );

            routes.MapRoute(
               name: "View Article",
               url: "news/article/{id}",
               defaults: new { controller = "Article", action = "Details" }
            );

            routes.MapRoute(
               name: "Create Article",
               url: "news/create",
               defaults: new { controller = "Article", action = "Create" }
            );

            routes.MapRoute(
               name: "Delete Article",
               url: "news/delete/{id}",
               defaults: new { controller = "Article", action = "Delete" }
            );

            routes.MapRoute(
               name: "Edit Article",
               url: "news/edit/{id}",
               defaults: new { controller = "Article", action = "Edit" }
            );

            routes.MapRoute(
               name: "List All Articles",
               url: "news/all",
               defaults: new { controller = "Article", action = "ListAllArticles" }
           );

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
