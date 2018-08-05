using Microsoft.AspNet.Identity;
using NewsSystem.Models;
using NewsSystem.Models.ViewModels;
using NewsSystem.Services;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace NewsSystem.Controllers
{
    public class ArticleController : Controller
    {
        private ArticlesService articlesService;
        private LikesService likesService;
        public ArticleController()
        {
            this.articlesService = new ArticlesService();
            this.likesService = new LikesService();
        }

        // GET: Article
        public ActionResult Details(int id)
        {
            Article article = this.articlesService.GetArticleById(id);
            return View(article);
        }

        [HttpGet]
        [Authorize]
        public int Like(int id)
        {
            Article article = this.articlesService.Context.Articles.FirstOrDefault(a => a.ArticleId == id);

            string userId = this.User.Identity.GetUserId();
            this.likesService.LikeArticle(id, userId);

            int likesValue = this.articlesService.Context.Articles.FirstOrDefault(a => a.ArticleId == id).Likes.Sum(l => l.Value);

            return likesValue;
        }

        [Authorize]
        public int Dislike(int id)
        {
            Article article = this.articlesService.Context.Articles.FirstOrDefault(a => a.ArticleId == id);

            string userId = this.User.Identity.GetUserId();
            this.likesService.DislikeArticle(id, userId);

            int likesValue = this.articlesService.Context.Articles.FirstOrDefault(a => a.ArticleId == id).Likes.Sum(l => l.Value);

            return likesValue;
        }

        [Authorize]
        public ActionResult ListAllArticles(string sortOrder, int? page)
        {
            IEnumerable<ArticleViewModel> articles = this.articlesService.GetAllArticles();

            ViewBag.CurrentSort = sortOrder;
            ViewBag.TitleSortParm = sortOrder == "title" ? "title_desc" : "title";
            ViewBag.DateSortParm = sortOrder == "date" ? "date_desc" : "date";

            switch (sortOrder)
            {
                case "title":
                    articles = articles.OrderBy(a => a.Title);
                    break;
                case "tile_desc":
                    articles = articles.OrderByDescending(a => a.Title);
                    break;
                case "date":
                    articles = articles.OrderBy(a => a.CreationDate);
                    break;
                case "date_desc":
                    articles = articles.OrderByDescending(a => a.CreationDate);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);


            return View(articles.ToPagedList(pageNumber, pageSize));
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(this.articlesService.Context.Users, "Id", "UserName");
            ViewBag.CategoryId = new SelectList(this.articlesService.Context.Categories, "CategoryId", "Name");

            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticleId,Title,Content,CreationDate,AuthorId,CategoryId")] Article article)
        {
            if (ModelState.IsValid)
            {
                this.articlesService.AddArticle(article);

                return RedirectToAction("ListAllArticles");
            }

            ViewBag.AuthorId = new SelectList(this.articlesService.Context.Users, "Id", "UserName", article.AuthorId);
            ViewBag.CategoryId = new SelectList(this.articlesService.Context.Categories, "CategoryId", "Name", article.CategoryId);

            return View(article);
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Article article = this.articlesService.FindArticleById(id);
            if (article == null)
            {
                return HttpNotFound();
            }


            ViewBag.AuthorId = new SelectList(this.articlesService.Context.Users, "Id", "UserName", article.AuthorId);
            ViewBag.CategoryId = new SelectList(this.articlesService.Context.Categories, "CategoryId", "Name", article.CategoryId);

            return View(article);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                this.articlesService.EditArticle(article);

                return RedirectToAction("ListAllArticles");
            }

            ViewBag.AuthorId = new SelectList(this.articlesService.Context.Users, "Id", "UserName", article.AuthorId);
            ViewBag.CategoryId = new SelectList(this.articlesService.Context.Categories, "CategoryId", "Name", article.CategoryId);

            return View(article);
        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Article article = this.articlesService.FindArticleById(id);
            if (article == null)
            {
                return HttpNotFound();
            }

            return View(article);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = this.articlesService.FindArticleById(id);

            this.likesService.DeleteLike(id);
            this.articlesService.DeleteArticle(article);

            return RedirectToAction("ListAllArticles");
        }
    }
}