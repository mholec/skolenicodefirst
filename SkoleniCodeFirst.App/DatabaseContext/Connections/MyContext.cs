using System.Data.Common;
using System.Data.Entity;

namespace SkoleniCodeFirst.DatabaseContext.Connections
{
    public class MyContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public MyContext()
        {
        }

        public MyContext(string connectionString = "MyContext") : base(connectionString)
        {
        }

        public MyContext(DbConnection connection) : base(connection, false)
        {
        }
    }
}
