using System.ComponentModel.DataAnnotations;

namespace NewsSystem.Models
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }

        [Required]
        public int Value { get; set; }

        [Required]
        public string AuthorId { get; set; }
        public virtual User Author { get; set; }

        [Required]
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}