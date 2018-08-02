using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsSystem.Models
{
    public class Category
    {
        public Category()
        {
            this.Articles = new List<Article>();
        }

        [Key]
        [Index(IsUnique = true)]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
