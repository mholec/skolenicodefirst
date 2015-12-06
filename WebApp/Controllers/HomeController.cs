using System.Web.Mvc;
using WebApp.Example;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleRepository articleRepository;

        public HomeController(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        // GET: Home
        public ActionResult Index()
        {
            var lastArticles = articleRepository.GetLast(5);
            var article = articleRepository.AddNew(new Article());

            return View();
        }
    }
}