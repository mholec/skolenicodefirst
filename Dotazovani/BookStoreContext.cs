using System;
using System.Data.Entity;
using System.Linq;
using Dotazovani.Entities;
using Dotazovani.Mapping;

namespace Dotazovani
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<ParameterValue> ParameterValues { get; set; }

        public BookStoreContext() : base("MyContext")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookMapping());
            modelBuilder.Configurations.Add(new CategoryMapping());
            modelBuilder.Configurations.Add(new ParameterMapping());
            modelBuilder.Configurations.Add(new ParameterValueMapping());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var changeInfo = ChangeTracker.Entries()
            .Where(t => t.State == EntityState.Modified)
            .Select(t => new {
                Original = t.OriginalValues.PropertyNames.ToDictionary(pn => pn, pn => t.OriginalValues[pn]),
                Current = t.CurrentValues.PropertyNames.ToDictionary(pn => pn, pn => t.CurrentValues[pn]),
            });

            foreach (var change in changeInfo)
            {
                // audit
            }

            return base.SaveChanges();
        }
    }
}
