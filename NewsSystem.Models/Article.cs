﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewsSystem.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        [MinLength(45)]
        [Required]
        public string Title { get; set; }

        [MinLength(150)]
        [Required]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
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