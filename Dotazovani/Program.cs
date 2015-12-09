using System.Data.Entity;
using Dotazovani.Priklady;
using HibernatingRhinos.Profiler.Appender.EntityFramework;

namespace Dotazovani
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // profilovací nástroj
            // http://www.hibernatingrhinos.com/products/efprof
            EntityFrameworkProfiler.Initialize();

            using (var db = new BookStoreContext())
            {
                db.Database.Initialize(false);

                var examples = new MethodSyntaxExamples(db);
                //var examples = new SerializableExamples();
                examples.Start();
            }

        }
    }
}
