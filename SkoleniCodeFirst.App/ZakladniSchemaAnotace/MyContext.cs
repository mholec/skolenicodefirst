using System.Data.Entity;

namespace SkoleniCodeFirst.ZakladniSchemaAnotace
{
    public class MyContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
