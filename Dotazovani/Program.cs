using System.Data.Entity;
using Dotazovani.Priklady;
using HibernatingRhinos.Profiler.Appender.EntityFramework;

namespace Dotazovani
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EntityFrameworkProfilerBootstrapper.PreStart();

            using (var db = new BookStoreContext())
            {
                db.Database.Initialize(false);

                var examples = new EntityStateExamples(db);
                //var examples = new SerializableExamples();
                examples.Start();
            }

        }
    }
}

