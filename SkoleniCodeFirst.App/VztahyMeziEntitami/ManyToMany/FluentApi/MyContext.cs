using System.Data.Entity;

namespace SkoleniCodeFirst.VztahyMeziEntitami.ManyToMany.FluentApi
{
    public class MyContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasMany(x => x.Authors).WithMany(x => x.Articles)
                .Map(x =>
                {
                    x.ToTable("AuthorArticles");
                    x.MapLeftKey("ArticleId");
                    x.MapRightKey("AuthorId");
                });

            modelBuilder.Entity<Author>().HasMany(x => x.Articles).WithMany(x => x.Authors)
                .Map(x =>
                {
                    x.ToTable("AuthorArticles");
                    x.MapLeftKey("ArticleId");
                    x.MapRightKey("AuthorId");
                });

            //modelBuilder.Entity<Article>().HasMany(x => x.Authors).WithMany(x => x.Articles)
            //    .Map(x => x.MapLeftKey("ArticleId"))
            //    .Map(x => x.MapRightKey("AuthorId"))
            //    .Map(x => x.ToTable("AuthorArticles"));

            //modelBuilder.Entity<Author>().HasMany(x => x.Articles).WithMany(x => x.Authors)
            //    .Map(x => x.MapLeftKey("ArticleId"))
            //    .Map(x => x.MapRightKey("AuthorId"))
            //    .Map(x => x.ToTable("AuthorArticles"));
        }
    }
}
