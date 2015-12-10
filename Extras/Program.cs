namespace Extras
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            EntityFrameworkProfilerBootstrapper.PreStart();

            var example = new Views.Examples();
            example.Start();
        }
    }
}