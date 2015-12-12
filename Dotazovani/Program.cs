using Dotazovani.Priklady;

namespace Dotazovani
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ef profiler
            EntityFrameworkProfilerBootstrapper.PreStart();

            using (var db = new BookStoreContext())
            {
                db.Database.Initialize(false);

                var examples = new PredicateBuilderExamples(db);
                //var examples = new SerializableExamples();
                examples.Start();
            }
        }
    }
}

