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
                new Category(){ Name = "World News"},
                new Category(){ Name = "Business"},
                new Category(){ Name = "Entertainment"}
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            List<string> titles = new List<string>()
            {
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi faucibus",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut ac.",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc iaculis.",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse eu."
            };

            List<string> contents = new List<string>()
            {
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam consequat nulla et mi ullamcorper dapibus. Nulla facilisi. Nunc semper velit vel lectus volutpat, eu ullamcorper est lacinia. Integer at egestas augue, at ultrices ante. Aenean diam libero, rutrum at sollicitudin sed, ultricies at nulla. Nulla pellentesque lobortis justo, nec aliquet eros laoreet a. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Interdum et malesuada fames ac ante ipsum primis in faucibus. Suspendisse non libero accumsan, placerat ante non, sollicitudin mi. Quisque pharetra augue in bibendum facilisis. Aliquam egestas consectetur dolor. Sed non malesuada dui. Fusce ultrices semper justo, non semper leo mattis gravida. ",
                " Proin consequat dictum sapien sed imperdiet. Donec accumsan, diam sed accumsan tempus, odio orci rhoncus libero, nec sagittis leo est in est. Aliquam euismod vehicula tortor vitae maximus. Curabitur nisl ligula, lacinia et dapibus ultrices, elementum ac velit. Duis blandit vitae sem eu finibus. Donec fringilla augue diam, non lobortis neque cursus tincidunt. Etiam fermentum gravida ipsum, at aliquet elit condimentum ut. Vivamus turpis est, egestas ac auctor et, feugiat eu libero. Phasellus tempor, turpis nec mollis tristique, augue turpis aliquam nibh, ut vehicula nisl lorem finibus nisl. Maecenas accumsan lacus ut erat rutrum, non bibendum arcu aliquet. Nullam tempus auctor mi a consectetur. Suspendisse convallis, tortor tincidunt pulvinar egestas, nisl urna hendrerit ligula, nec euismod neque nisi at nibh.Nullam enim tellus, mattis eget porttitor accumsan, egestas quis lorem. Nulla non neque sed tortor elementum consequat et vel dolor. Phasellus vulputate, arcu pharetra pretium feugiat, felis erat posuere mi, sed laoreet lectus nibh eget urna. In eget enim lacus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. In vel diam velit. Curabitur eu consequat felis. Etiam non nisl non velit finibus cursus sed sed erat. Sed laoreet, sapien ac porta varius, sem purus hendrerit orci, non posuere nibh ipsum quis lacus. Integer posuere lobortis nunc ut malesuada. Sed consequat felis eget magna mollis, nec dapibus felis volutpat. Nunc vitae arcu id dolor gravida tempor. Nulla facilisi. ",
                " Proin consequat dictum sapien sed imperdiet. Donec accumsan, diam sed accumsan tempus, odio orci rhoncus libero, nec sagittis leo est in est. Aliquam euismod vehicula tortor vitae maximus. Curabitur nisl ligula, lacinia et dapibus ultrices, elementum ac velit. Duis blandit vitae sem eu finibus. Donec fringilla augue diam, non lobortis neque cursus tincidunt. Etiam fermentum gravida ipsum, at aliquet elit condimentum ut. Vivamus turpis est, egestas ac auctor et, feugiat eu libero. Phasellus tempor, turpis nec mollis tristique, augue turpis aliquam nibh, ut vehicula nisl lorem finibus nisl. Maecenas accumsan lacus ut erat rutrum, non bibendum arcu aliquet. Nullam tempus auctor mi a consectetur. Suspendisse convallis, tortor tincidunt pulvinar egestas, nisl urna hendrerit ligula, nec euismod neque nisi at nibh.",
                " Nullam enim tellus, mattis eget porttitor accumsan, egestas quis lorem. Nulla non neque sed tortor elementum consequat et vel dolor. Phasellus vulputate, arcu pharetra pretium feugiat, felis erat posuere mi, sed laoreet lectus nibh eget urna. In eget enim lacus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. In vel diam velit. Curabitur eu consequat felis. Etiam non nisl non velit finibus cursus sed sed erat. Sed laoreet, sapien ac porta varius, sem purus hendrerit orci, non posuere nibh ipsum quis lacus. Integer posuere lobortis nunc ut malesuada. Sed consequat felis eget magna mollis, nec dapibus felis volutpat. Nunc vitae arcu id dolor gravida tempor. Nulla facilisi. "
            };


            User user = context.Users.FirstOrDefault();
            List<Article> articles = new List<Article>()
            {
                new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[0].CategoryId, Author = user, CreationDate = DateTime.Now},
                  new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[0].CategoryId, Author = user, CreationDate = DateTime.Now},
                    new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[0].CategoryId, Author = user, CreationDate = DateTime.Now},  new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[0].CategoryId, Author = user, CreationDate = DateTime.Now},
                      new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[1].CategoryId, Author = user, CreationDate = DateTime.Now},
                        new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[1].CategoryId, Author = user, CreationDate = DateTime.Now},
                          new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[1].CategoryId, Author = user, CreationDate = DateTime.Now},
                            new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[1].CategoryId, Author = user, CreationDate = DateTime.Now},
                              new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[2].CategoryId, Author = user, CreationDate = DateTime.Now},
                                new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[2].CategoryId, Author = user, CreationDate = DateTime.Now},
                                  new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[2].CategoryId, Author = user, CreationDate = DateTime.Now},
                                    new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[2].CategoryId, Author = user, CreationDate = DateTime.Now},
                                      new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[3].CategoryId, Author = user, CreationDate = DateTime.Now},
                                        new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[3].CategoryId, Author = user, CreationDate = DateTime.Now},
                                          new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[3].CategoryId, Author = user, CreationDate = DateTime.Now},
                                            new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[3].CategoryId, Author = user, CreationDate = DateTime.Now},
                                              new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[4].CategoryId, Author = user, CreationDate = DateTime.Now},
                                                new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[4].CategoryId, Author = user, CreationDate = DateTime.Now},
                                                  new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[4].CategoryId, Author = user, CreationDate = DateTime.Now},
                                                    new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[4].CategoryId, Author = user, CreationDate = DateTime.Now},
                                                      new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[5].CategoryId, Author = user, CreationDate = DateTime.Now},
                                                        new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[5].CategoryId, Author = user, CreationDate = DateTime.Now},
                                                          new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[5].CategoryId, Author = user, CreationDate = DateTime.Now},
                                                            new Article(){ Title = titles[randomizer.Next(0, titles.Count - 1)], Content = contents[randomizer.Next(0, contents.Count-1)], CategoryId = categories[5].CategoryId, Author = user, CreationDate = DateTime.Now},

            };

            context.Articles.AddRange(articles);
            context.SaveChanges();
        }
    }
}
