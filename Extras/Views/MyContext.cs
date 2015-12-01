using System.Data.Entity;

namespace Extras.Views
{
    public class MyContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public MyContext()
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().Map(x => x.ToTable("TopArticles"));
        }
    }
}
