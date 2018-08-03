using NewsSystem.Models;
using NewsSystem.Models.ViewModels;
using NewsSystem.Services;
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
        public CategoryController()
        {
            this.categoryService = new CategoriesServices();
            this.articlesService = new ArticlesService();
        }

        public ActionResult Index(string categoryName)
        {
            IEnumerable<ArticleViewModel> articles = this.categoryService.ListAllArticlesForCategory(categoryName);

            return View(articles);
        }

        [Authorize]
        public ActionResult ListAllCategories()
        {
            IEnumerable<CategoryViewModel> categories = this.categoryService.GetAllCategories();

            return View(categories);
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
        public ActionResult Edit([Bind(Include = "CategoryId,Name")] Category category)
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

            this.articlesService.DeleteArticlesFromCategory(id);
            this.categoryService.DeleteCategory(category);

            return RedirectToAction("ListAllCategories");
        }
    }
}