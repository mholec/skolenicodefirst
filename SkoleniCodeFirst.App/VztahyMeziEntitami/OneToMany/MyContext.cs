using System.Data.Entity;

namespace SkoleniCodeFirst.VztahyMeziEntitami.OneToMany
{
    public class MyContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
