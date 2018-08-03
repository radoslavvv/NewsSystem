using NewsSystem.Models;
using NewsSystem.Models.ViewModels;
using NewsSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsSystem.Controllers
{
    public class ArticleController : Controller
    {
        private ArticlesService articlesService;
        public ArticleController()
        {
            this.articlesService = new ArticlesService();
        }

        // GET: Article
        public ActionResult Details(int id)
        {
            Article article = this.articlesService.GetArticleById(id);
            return View(article);
        }

        [Authorize]
        public ActionResult ListAllArticles()
        {
            IEnumerable<ArticleViewModel> categories = this.articlesService.GetAllArticles();

            return View(categories);
        }
    }
}