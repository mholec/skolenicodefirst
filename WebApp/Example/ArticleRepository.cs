using System.Collections.Generic;
using System.Linq;

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
    }
}