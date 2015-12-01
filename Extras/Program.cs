using HibernatingRhinos.Profiler.Appender.EntityFramework;

namespace Extras
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            EntityFrameworkProfiler.Initialize();

            var example = new Views.Examples();
            example.Start();
        }
    }
}