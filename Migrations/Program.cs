using System.Data.Entity;

namespace TheMigrations
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
