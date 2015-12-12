using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Example
{
    public interface IRepository<T> where T : class
    {
        T AddNew(T entity);
        T Delete(T entity);
        IQueryable<T> GetAll();
        void Save();
        Task SaveAsync();
    }
}