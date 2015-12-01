using System.Data.Entity;

namespace SkoleniCodeFirst.VztahyMeziEntitami.KomplexniTypy.FluentApi
{
    public class MyContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Redactor> Redactors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ComplexType<Contact>().Property(x => x.Phone).HasColumnName("Phone");
            modelBuilder.ComplexType<Contact>().Property(x => x.Phone).HasColumnName("WebsiteUrl");
        }
    }
}
