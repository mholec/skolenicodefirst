using System.Linq;

namespace Extras.Views
{
    public class Examples
    {
        public void Start()
        {
            using (var db = new MyContext())
            {
                db.Database.Initialize(true);

                var articleFromView = db.Articles.ToList();
                Article article = articleFromView.FirstOrDefault();
                article.Title = "Chci změnit titulek";

                db.SaveChanges();
            }
        }
    }
}
