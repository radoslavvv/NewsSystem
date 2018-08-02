using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewsSystem.Models
{
    public class Article
    {
        public Article()
        {
            this.Likes = new List<Like>();
        }

        [Key]
        public int ArticleId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public string AuthorId { get; set; }
        public virtual User Author { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}