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
        public IEnumerable<ArticleViewModel> ListAllArticles()
        {
            IEnumerable<Article> articles = this.Context.Articles.ToList();
            IEnumerable<ArticleViewModel> articleViewModels = Mapper.Instance.Map<IEnumerable<Article>, IEnumerable<ArticleViewModel>>(articles);

            return articleViewModels;
        }
    }
}
