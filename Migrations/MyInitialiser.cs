using System.Data.Entity;

namespace TheMigrations
{
    public class MyInitialiser : CreateDatabaseIfNotExists<MyContext>
    {
        public override void InitializeDatabase(MyContext context)
        {
            base.InitializeDatabase(context);
        }

        protected override void Seed(MyContext context)
        {
            base.Seed(context);
        }
    }

    //public class LatestVersion : MigrateDatabaseToLatestVersion<MyContext, Configuration>
    //{
    //    public override void InitializeDatabase(MyContext context)
    //    {
    //        base.InitializeDatabase(context);
    //    }
    //}
}
