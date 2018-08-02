using NewsSystem.Data;
using NewsSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsSystem.Controllers
{
    public class HomeController : Controller
    {
        private ArticlesService articlesService;
        public HomeController()
        {
            this.articlesService = new ArticlesService();
        }

        public ActionResult Index()
        {
            NewsSystemContext context = new NewsSystemContext();
            var articles = this.articlesService.ListTopThreeArticles();
            return View(articles);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}