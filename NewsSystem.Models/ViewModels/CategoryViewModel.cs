using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsSystem.Models.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }

        public CategoryViewModel()
        {
            this.Articles = new List<ArticleViewModel>();
        }

        public string Name { get; set; }

        public virtual List<ArticleViewModel> Articles { get; set; }
    }
}
