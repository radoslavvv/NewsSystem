using NewsSystem.Models;
using NewsSystem.Models.ViewModels;
using NewsSystem.Services;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NewsSystem.Controllers
{
    public class CategoryController : Controller
    {
        private CategoriesServices categoryService;
        private ArticlesService articlesService;
        private LikesService likesService;

        public CategoryController()
        {
            this.categoryService = new CategoriesServices();
            this.articlesService = new ArticlesService();
            this.likesService = new LikesService();
        }

        public ActionResult Index(string categoryName, int? page)
        {
            IEnumerable<ArticleViewModel> articles = this.categoryService.ListAllArticlesForCategory(categoryName);

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(articles.ToPagedList(pageNumber, pageSize));
        }

        [Authorize]
        public ActionResult ListAllCategories(string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TitleSortParm = sortOrder == "name" ? "name_desc" : "name";
            ViewBag.DateSortParm = sortOrder == "articles" ? "articles_desc" : "articles";

            IEnumerable<CategoryViewModel> categories = this.categoryService.GetAllCategories();
            switch (sortOrder)
            {
                case "name":
                    categories = categories.OrderBy(a => a.Name);
                    break;
                case "name_desc":
                    categories = categories.OrderByDescending(a => a.Name);
                    break;
                case "articles":
                    categories = categories.OrderBy(a => a.Articles.Count);
                    break;
                case "articles_desc":
                    categories = categories.OrderByDescending(a => a.Articles.Count);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(categories.ToPagedList(pageNumber, pageSize));
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                this.categoryService.AddCategory(category);

                return RedirectToAction("ListAllCategories");
            }

            return View(category);
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = this.categoryService.FindCategoryById(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId, Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                this.categoryService.EditCategory(category);

                return RedirectToAction("ListAllCategories");
            }
            return View(category);
        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = this.categoryService.FindCategoryById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = this.categoryService.FindCategoryById(id);

            this.likesService.DeleteLike(id);
            this.articlesService.DeleteArticlesFromCategory(id);
            this.categoryService.DeleteCategory(category);

            return RedirectToAction("ListAllCategories");
        }
    }
}