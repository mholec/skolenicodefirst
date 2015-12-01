using System.Data.Entity;

namespace SkoleniCodeFirst.VztahyMeziEntitami.Enumy.BestPractice
{
    public class MyContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleState> ArticleStates { get; set; }
    }
}
