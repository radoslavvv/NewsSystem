using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsSystem.Models.ViewModels
{
    public class ArticleViewModel
    {
        public int ArticleId { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }

        public string Content { get; set; }

        [DisplayName("Date of Creation")]
        public string CreationDate { get; set; }

        public virtual User Author { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
