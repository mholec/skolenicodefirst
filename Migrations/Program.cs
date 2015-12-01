using System.Data.Entity;

namespace Migrations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Database.SetInitializer(new MyInitialiser());

            using (var context = new MyContext())
            {
                context.Database.Initialize(false);
            }
        }
    }
}
