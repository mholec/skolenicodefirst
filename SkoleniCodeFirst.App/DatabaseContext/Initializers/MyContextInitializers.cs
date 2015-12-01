using System.Data.Entity;

namespace SkoleniCodeFirst.DatabaseContext.Initializers
{
    public class MyCreateIfNotExistsContextInitializer : CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            // přidání vlastních dat, pokud je splněn initializer
            base.Seed(context);
        }
    }

    public class MyDropIfModelChangesContextInitializer : DropCreateDatabaseIfModelChanges<MyContext>
    {
        public override void InitializeDatabase(MyContext context)
        {
            base.InitializeDatabase(context);
        }

        protected override void Seed(MyContext context)
        {
            // přidání vlastních dat, pokud je splněn initializer
            base.Seed(context);
        }
    }

    public class MyDropAlwaysContextInitializer : DropCreateDatabaseAlways<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            // přidání vlastních dat, pokud je splněn initializer
            base.Seed(context);
        }
    }

    //public class MyLatestVersionContentInitializer : MigrateDatabaseToLatestVersion<>
}
