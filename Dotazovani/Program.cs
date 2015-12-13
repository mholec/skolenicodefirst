using Dotazovani.Priklady;
using Dotazovani.Priklady.Validace;

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

                var examples = new MethodSyntaxExamples(db);
                //var examples = new SerializableExamples();
                examples.Start();
            }
        }
    }
}

