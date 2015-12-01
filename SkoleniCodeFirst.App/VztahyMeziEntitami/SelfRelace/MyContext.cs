using System.Data.Entity;

namespace SkoleniCodeFirst.VztahyMeziEntitami.SelfRelace
{
    public class MyContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
    }
}
