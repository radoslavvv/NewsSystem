using AutoMapper;
using NewsSystem.Data;
using NewsSystem.Models;
using NewsSystem.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsSystem.Services
{
    public class ArticlesService : Service
    {
        public IEnumerable<ArticleViewModel> ListTopThreeArticles()
        {
            IEnumerable<Article> articles = this.Context.Articles.OrderBy(a => a.Likes.Count).Take(3).ToList();
            IEnumerable<ArticleViewModel> articleViewModels = Mapper.Instance.Map<IEnumerable<Article>, IEnumerable<ArticleViewModel>>(articles);

            return articleViewModels;
        }

        public Article GetArticleById(int id)
        {
            Article article = this.Context.Articles.Find(id);

            return article;
        }

        public IEnumerable<ArticleViewModel> GetAllArticles()
        {
            IEnumerable<Article> articles = this.Context.Articles.ToList();
            IEnumerable<ArticleViewModel> articleViewModels = Mapper.Instance.Map<IEnumerable<Article>, IEnumerable<ArticleViewModel>>(articles);

            return articleViewModels;
        }

        public void DeleteArticlesFromCategory(int categoryId)
        {
            List<Article> articlesToRemove = this.Context
                .Articles
                .Where(a => a.CategoryId == categoryId)
                .ToList();

            this.Context.Articles.RemoveRange(articlesToRemove);
            this.Context.SaveChanges();
        }
    }
}
