using System.Collections.Generic;

namespace WebApp.Example
{
    public interface IArticleRepository : IRepository<Article>
    {
        List<Article> GetLast(int take = 10);
    }
}