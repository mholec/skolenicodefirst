using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp.Example;

namespace WebApp.Controllers
{
    public class SyncController : Controller
    {
        private readonly IArticleRepository articleRepository;

        public SyncController(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public async Task<ActionResult> IndexAsync()
        {
            await AddArticleAsync(new Article { Title = "Moje kniha" });

            var articles1 = await articleRepository.GetLastAsync(25);
            var articles2 = await articleRepository.GetLastAsync(25);
            var articles3 = await articleRepository.GetLastAsync(25);

            return View("Index", new MultipleArticles { A1 = articles1, A2 = articles2, A3 = articles3});
        }

        public ActionResult Index()
        {
            AddArticle(new Article {Title = "Moje kniha"});

            var articles1 = articleRepository.GetLast(25);
            var articles2 = articleRepository.GetLast(25);
            var articles3 = articleRepository.GetLast(25);

            return View("Index", new MultipleArticles { A1 = articles1, A2 = articles2, A3 = articles3 });
        }

        private void AddArticle(Article article)
        {
            articleRepository.AddNew(article);
            articleRepository.Save();
        }

        private async Task AddArticleAsync(Article article)
        {
            articleRepository.AddNew(article);
            await articleRepository.SaveAsync();
        }
    }

    public class MultipleArticles
    {
        public List<Article> A1 { get; set; }
        public List<Article> A2 { get; set; }
        public List<Article> A3 { get; set; }
    }
}