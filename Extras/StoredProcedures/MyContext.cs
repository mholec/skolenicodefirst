using System.Data.Entity;

namespace Extras.StoredProcedures
{
    public class MyContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public MyContext() : base("StoredProcedures")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().MapToStoredProcedures(sp => sp
                .Insert(x => x.HasName("InsertArticle"))
                .Delete(x => x.HasName("DeleteArticle"))
                .Update(x => x.HasName("UpdateArticle"))
                );
        }
    }
}
