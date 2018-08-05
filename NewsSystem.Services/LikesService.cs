using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsSystem.Services
{
    public class LikesService : Service
    {
        public void LikeArticle(int articleId, string authorId)
        {
            Article article = this.Context.Articles.FirstOrDefault(a => a.ArticleId == articleId);

            if (article.Likes.Any(a => a.AuthorId == authorId))
            {
                int value = article.Likes.FirstOrDefault(l => l.AuthorId == authorId).Value;

                if (value == 1)
                {
                    article.Likes.FirstOrDefault(l => l.AuthorId == authorId).Value = 0;
                }
                else
                {
                    article.Likes.FirstOrDefault(l => l.AuthorId == authorId).Value = 1;
                }

                this.Context.SaveChanges();
            }
            else
            {
                Like like = new Like()
                {
                    ArticleId = articleId,
                    AuthorId = authorId,
                    Value = 1
                };

                article.Likes.Add(like);
                this.Context.SaveChanges();
            }
        }

        public void DislikeArticle(int articleId, string authorId)
        {
            Article article = this.Context.Articles.FirstOrDefault(a => a.ArticleId == articleId);

            if (article.Likes.Any(a => a.AuthorId == authorId))
            {
                int value = article.Likes.FirstOrDefault(l => l.AuthorId == authorId).Value;

                if (value == -1)
                {
                    article.Likes.FirstOrDefault(l => l.AuthorId == authorId).Value = 0;
                }
                else
                {
                    article.Likes.FirstOrDefault(l => l.AuthorId == authorId).Value = -1;

                }

                this.Context.SaveChanges();
            }
            else
            {
                Like like = new Like()
                {
                    ArticleId = articleId,
                    AuthorId = authorId,
                    Value = -1
                };

                article.Likes.Add(like);
                this.Context.SaveChanges();
            }
        }

        public void DeleteLike(int articleId)
        {
            IEnumerable<Like> likesToRemove = this.Context.Likes.Where(l => l.ArticleId == articleId);

            this.Context.Likes.RemoveRange(likesToRemove);
            this.Context.SaveChanges();
        }
    }
}
