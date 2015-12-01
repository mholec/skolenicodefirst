using System.Data.Entity;

namespace SkoleniCodeFirst.DatabaseContext.Initializers
{
    public class MyContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public MyContext()
        {
            // Database.SetInitializer<MyContext>(new CreateDatabaseIfNotExists<MyContext>());
            Database.SetInitializer<MyContext>(new DropCreateDatabaseIfModelChanges<MyContext>());
            // Database.SetInitializer<MyContext>(new DropCreateDatabaseAlways<MyContext>());
            //Database.SetInitializer<MyContext>(new MyDropIfModelChangesContextInitializer());
            Database.SetInitializer<MyContext>(new MyCreateIfNotExistsContextInitializer());
            Database.Initialize(true);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
