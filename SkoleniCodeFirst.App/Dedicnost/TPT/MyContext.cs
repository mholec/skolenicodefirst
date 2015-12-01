using System.Data.Entity;

namespace SkoleniCodeFirst.Dedicnost.TPT
{
    public class MyContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().ToTable("Articles");
            modelBuilder.Entity<OnlineArticle>().ToTable("OnlineArticles");
            modelBuilder.Entity<OfflineArticle>().ToTable("OfflineArticles");
        }
    }
}
