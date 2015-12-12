using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Example
{
    public interface IArticleRepository : IRepository<Article>
    {
        List<Article> GetLast(int take = 10);

        Task<List<Article>> GetLastAsync(int take = 10);
    }
}