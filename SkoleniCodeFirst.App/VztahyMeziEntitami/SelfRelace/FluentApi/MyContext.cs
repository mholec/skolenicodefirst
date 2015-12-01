using System.Data.Entity;

namespace SkoleniCodeFirst.VztahyMeziEntitami.SelfRelace.FluentApi
{
    public class MyContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(x => x.CategoryId);

            modelBuilder.Entity<Category>()
                .HasMany(x => x.Children)
                .WithOptional(x => x.ParentCategory)
                .HasForeignKey(x => x.ParentCategoryId);

            modelBuilder.Entity<Category>()
                .HasOptional(x => x.ParentCategory)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.ParentCategoryId);
        }
    }
}
