using Microsoft.Owin;
using NewsSystem.Data;
using NewsSystem.Models;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(NewsSystem.Startup))]
namespace NewsSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Seed();
        }

        public void Seed()
        {
            NewsSystemContext context = new NewsSystemContext();
            Random randomizer = new Random();

            List<Category> categories = new List<Category>()
            {
                new Category(){ Name = "Technology"},
                new Category(){ Name = "Politics"},
                new Category(){ Name = "Health"},
                new Category(){ Name = "Technology"},
                new Category(){ Name = "Business"},
                new Category(){ Name = "Entertainment"}
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            User user = context.Users.FirstOrDefault();
            List<Article> articles = new List<Article>()
            {
                new Article(){ Title = "Article1", Content ="Content1", CategoryId = categories[randomizer.Next(0,categories.Count -1)].CategoryId, Author = user, CreationDate = DateTime.Now},
                new Article(){ Title = "Article2", Content ="Content2", CategoryId = categories[randomizer.Next(0,categories.Count -1)].CategoryId, Author = user, CreationDate = DateTime.Now },
                new Article(){ Title = "Article3", Content ="Content3", CategoryId = categories[randomizer.Next(0,categories.Count -1)].CategoryId, Author = user, CreationDate = DateTime.Now},
                new Article(){ Title = "Article4", Content ="Content4", CategoryId = categories[randomizer.Next(0,categories.Count -1)].CategoryId, Author = user, CreationDate = DateTime.Now },
            };

            context.Articles.AddRange(articles);
            context.SaveChanges();
        }
    }
}
