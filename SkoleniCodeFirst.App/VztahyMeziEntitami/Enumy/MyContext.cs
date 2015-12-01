using System.Data.Entity;

namespace SkoleniCodeFirst.VztahyMeziEntitami.Enumy
{
    public class MyContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
    }
}
