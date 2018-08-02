namespace NewsSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using NewsSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class NewsSystemContext : IdentityDbContext<User>
    {
        public NewsSystemContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Article> Articles { get; set; }

        public virtual DbSet<Like> Likes{ get; set; }

        public static NewsSystemContext Create()
        {
            return new NewsSystemContext();
        }
    }
}