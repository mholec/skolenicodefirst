using System.Data.Entity;

namespace SkoleniCodeFirst.DatabaseContext.ZakladniMetody
{
    public class MyContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public MyContext()
        {
            // Při volání metody SaveChanges se nejprve zkontroluje model
            Configuration.ValidateOnSaveEnabled = true;

            // Při použití SaveChanges se volá DetectChanges metody, která prochází model a kontroluje celý graph
            Configuration.AutoDetectChangesEnabled = true;

            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            Configuration.UseDatabaseNullSemantics = false;

            // Timeout pro každý příkaz (nikoliv connection - connectionstring)
            Database.CommandTimeout = 10;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Conventions - konvence pro kód, obvykle není třeba vytvářet nové
            // modelBuilder.Configurations - konfigurace pro fluent api

            // fluent api
            modelBuilder.Entity<Connections.Article>().HasKey(x => x.ArticleId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
