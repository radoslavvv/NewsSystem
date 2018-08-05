using NewsSystem.Data;
using NewsSystem.Models.ViewModels;
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
        private CategoriesServices categoriesService;

        public HomeController()
        {
            this.articlesService = new ArticlesService();
            this.categoriesService = new CategoriesServices();
        }

        public ActionResult Index()
        {
            NewsSystemContext context = new NewsSystemContext();
            IEnumerable<ArticleViewModel> articles = this.articlesService.ListTopThreeArticles();
            IEnumerable<CategoryViewModel> categories = this.categoriesService.GetAllCategories();

            ViewBag.Categories = categories;
            return View(articles);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contacts()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}