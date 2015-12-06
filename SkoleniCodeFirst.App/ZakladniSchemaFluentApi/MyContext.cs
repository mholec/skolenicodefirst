using System.Data.Entity;

namespace SkoleniCodeFirst.ZakladniSchemaFluentApi
{
    public class MyContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // model builder API
            modelBuilder.Entity<Article>().HasKey(x => x.ArticleId);
            modelBuilder.Entity<Article>().Property(x => x.Title).HasMaxLength(100);
            modelBuilder.Entity<Article>().Ignore(x => x.InternalTitle);
            modelBuilder.Entity<Article>().Property(x => x.RowVersion).IsRowVersion();

            modelBuilder.Entity<Event>().HasKey(x => new {x.Name, x.PlaceId, x.Date});

            // fluent api (configuration classes)
            modelBuilder.Configurations.Add(new AuthorDbConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
