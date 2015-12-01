using System.Linq;

namespace Extras.Adonet
{
    public class Examples
    {
        public void Start()
        {
            using (var db = new MyContext())
            {
                db.Database.Initialize(true);

                // vlozeni dat
                int result = db.Database.ExecuteSqlCommand("insert into articles(Title) values('Muj novy clanek')");

                // dotazovani
                var articles = db.Database.SqlQuery<Article>("select * from Articles").ToList();

                // volani stored procedures
                var articlesFromSp = db.Database.SqlQuery<Article>("EXEC GetArticles").ToList();

                // volani view
                var articlesFromView = db.Database.SqlQuery<Article>("select * from TopArticles").ToList();
            }
        }
    }
}
