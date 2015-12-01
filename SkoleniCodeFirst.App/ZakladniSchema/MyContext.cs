using System.Data.Entity;

namespace SkoleniCodeFirst.ZakladniSchema
{
    public class MyContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
