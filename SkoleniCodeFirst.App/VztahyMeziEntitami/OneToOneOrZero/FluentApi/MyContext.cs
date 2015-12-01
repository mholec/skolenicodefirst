using System.Data.Entity;

namespace SkoleniCodeFirst.VztahyMeziEntitami.OneToOneOrZero.FluentApi
{
    public class MyContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasKey(x => x.ArticleId);
            modelBuilder.Entity<ArticleMetadata>().HasKey(x => x.ArticleId);

            modelBuilder.Entity<ArticleMetadata>().HasRequired(x => x.Article).WithOptional(x => x.Metadata);
            modelBuilder.Entity<Article>().HasOptional(x => x.Metadata).WithRequired(x => x.Article);
        }
    }
}
