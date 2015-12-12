using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApp.Example
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(Context context) : base(context)
        {
        }

        public List<Article> GetLast(int take = 10)
        {
            return Set.OrderByDescending(x => x.ArticleId).Take(take).ToList();
        }

        public Task<List<Article>> GetLastAsync(int take = 10)
        {
            var articles = Set.OrderByDescending(x => x.ArticleId).Take(take).ToListAsync();

            return articles;
        }
    }
}