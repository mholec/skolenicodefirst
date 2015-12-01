using System.Data.Entity;

namespace SkoleniCodeFirst.VztahyMeziEntitami.OneToOneOrZero
{
    public class MyContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
    }
}
