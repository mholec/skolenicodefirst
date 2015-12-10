using Extras;
using HibernatingRhinos.Profiler.Appender.EntityFramework;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(EntityFrameworkProfilerBootstrapper), "PreStart")]
namespace Extras
{
	public static class EntityFrameworkProfilerBootstrapper
	{
		public static void PreStart()
		{
			EntityFrameworkProfiler.Initialize();
		}
	}
}

