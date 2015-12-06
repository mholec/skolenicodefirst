using System.Data.Entity;

namespace WebApp.Example
{
    public class Context : DbContext
    {
        public DbSet<Article> Articles { get; set; }
    }
}