using System.Data.Entity;

namespace Extras.Adonet
{
    public class MyContext : DbContext
    {
        public MyContext()
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
