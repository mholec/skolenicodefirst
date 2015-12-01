using System.Data.Entity;

namespace SkoleniCodeFirst.VztahyMeziEntitami.KomplexniTypy
{
    public class MyContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Redactor> Redactors { get; set; }
    }
}
