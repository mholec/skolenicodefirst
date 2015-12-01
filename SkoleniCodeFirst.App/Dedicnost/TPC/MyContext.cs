using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SkoleniCodeFirst.Dedicnost.TPC
{
    public class MyContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasKey(x => x.ArticleId);
            modelBuilder.Entity<Article>()
                .Property(x => x.ArticleId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<OnlineArticle>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("OnlineArticles");
            });

            modelBuilder.Entity<OfflineArticle>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("OfflineArticles");
            });
        }
    }
}
