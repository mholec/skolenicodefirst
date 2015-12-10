using Dotazovani;
using HibernatingRhinos.Profiler.Appender.EntityFramework;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(EntityFrameworkProfilerBootstrapper), "PreStart")]
namespace Dotazovani
{
	public static class EntityFrameworkProfilerBootstrapper
	{
		public static void PreStart()
		{
			// Initialize the profiler
			EntityFrameworkProfiler.Initialize();
		}
	}
}

