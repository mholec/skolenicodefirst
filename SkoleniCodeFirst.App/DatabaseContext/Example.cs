using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using SkoleniCodeFirst.DatabaseContext.Initializers;

namespace SkoleniCodeFirst.DatabaseContext
{
    public class Example
    {
        public void Start()
        {
            // ZakladniMetody();
            Connections();
            Initializers();
        }

        public void ZakladniMetody()
        {
            using (var db = new ZakladniMetody.MyContext())
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<ZakladniMetody.MyContext>());

                var article = db.Articles.FirstOrDefault();
            }
        }

        public void Connections()
        {
            using (var db = new Connections.MyContext("MyContext"))
            {
                DbConnection connection = db.Database.Connection;

                Database.SetInitializer(new DropCreateDatabaseAlways<Connections.MyContext>());

                var article = db.Articles.FirstOrDefault();

                using (var db2 = new Connections.OtherContext(connection))
                {
                    var author = db2.Authors.FirstOrDefault();
                }
            }
        }

        public void Initializers()
        {
            using (var db = new Initializers.MyContext())
            {
                var articles = db.Articles.Select(x => x).FirstOrDefault();
                db.Articles.Add(new Article() {Title = "Clanek"});
                db.SaveChanges();
            }
        }
    }
}
