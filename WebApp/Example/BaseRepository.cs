using System.Data.Entity;
using System.Linq;

namespace WebApp.Example
{
    public abstract class BaseRepository<T> : IRepository<T> where T: class
    {
        protected readonly Context Context;
        protected readonly DbSet<T> Set;

        protected BaseRepository(Context context)
        {
            this.Context = context;
            this.Set = context.Set<T>();
        }

        public T AddNew(T entity)
        {
            return Set.Add(entity);
        }

        public T Delete(T entity)
        {
            return Set.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return Set;
        }
    }
}