using System.Data.Entity;

namespace SkoleniCodeFirst.Dedicnost.TPH
{
    public class MyContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // přejmenuje sloupec Discriminator na Type

            //modelBuilder.Entity<Article>()
            //  .Map<OnlineArticle>(x => x.Requires("Type").HasValue(1))
            //  .Map<OfflineArticle>(x => x.Requires("Type").HasValue(2));
        }
    }
}
