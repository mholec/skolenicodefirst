using System.Data.Entity;

namespace SkoleniCodeFirst.VztahyMeziEntitami.ManyToMany
{
    public class MyContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
