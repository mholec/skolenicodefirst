using System.Data.Common;
using System.Data.Entity;

namespace SkoleniCodeFirst.DatabaseContext.Connections
{
    public class OtherContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public OtherContext()
        {
        }

        public OtherContext(string connectionString = "MyContext") : base(connectionString)
        {
        }

        public OtherContext(DbConnection connection) : base(connection, false)
        {
        }
    }
}
