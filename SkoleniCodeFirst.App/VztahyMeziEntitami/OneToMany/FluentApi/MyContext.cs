using System.Data.Entity;

namespace SkoleniCodeFirst.VztahyMeziEntitami.OneToMany.FluentApi
{
    public class MyContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasKey(x => x.ArticleId);
            modelBuilder.Entity<Author>().HasKey(x => x.AuthorId);
            modelBuilder.Entity<Category>().HasKey(x => x.CategoryId);


            modelBuilder.Entity<Article>()
                .HasOptional(x => x.Category)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<Category>()
                .HasMany(x => x.Articles)
                .WithOptional(x => x.Category)
                .HasForeignKey(x => x.CategoryId);


            modelBuilder.Entity<Article>()
                .HasRequired(x => x.Author)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.AuthorId);

            modelBuilder.Entity<Author>()
                .HasMany(x => x.Articles)
                .WithRequired(x => x.Author)
                .HasForeignKey(x => x.AuthorId);
        }
    }
}
