namespace Extras
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            EntityFrameworkProfilerBootstrapper.PreStart();

            var example = new Adonet.Examples();
            example.Start();
        }
    }
}