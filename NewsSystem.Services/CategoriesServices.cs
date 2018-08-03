using AutoMapper;
using NewsSystem.Models;
using NewsSystem.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsSystem.Services
{
    public class CategoriesServices : Service
    {
        public IEnumerable<CategoryViewModel> GetAllCategories()
        {
            IEnumerable<Category> categories = this.Context.Categories.Include(c => c.Articles).ToList();
            IEnumerable<CategoryViewModel> categoryViewModels = Mapper.Instance.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);

            return categoryViewModels;
        }

        public IEnumerable<ArticleViewModel> ListAllArticlesForCategory(string categoryName)
        {
            List<Article> articles = this.Context
                .Categories
                .Include(c => c.Articles)
                .FirstOrDefault(c => c.Name == categoryName)
                .Articles.ToList();

            IEnumerable<ArticleViewModel> articleViewModels = Mapper.Instance.Map<IEnumerable<Article>, IEnumerable<ArticleViewModel>>(articles);

            return articleViewModels;
        }

        public Category FindCategoryById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            Category category = this.Context.Categories.Find(id);

            return category;
        }

        public void AddCategory(Category category)
        {
            this.Context.Categories.Add(category);
            this.Context.SaveChanges();
        }

        public void EditCategory(Category category)
        {
            Category categoryToEdit = this.Context.Categories.Find(category.CategoryId);

            this.Context.Entry(categoryToEdit).CurrentValues.SetValues(category);
            this.Context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            this.Context.Categories.Remove(category);
            this.Context.SaveChanges();
        }
    }
}
