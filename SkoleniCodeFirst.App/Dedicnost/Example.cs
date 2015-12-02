using System.Data.Entity;

namespace SkoleniCodeFirst.Dedicnost
{
    public class Example
    {
        public void Start()
        {
            TablePerHierarchy();
            // TablePerType();
            // TablePerClass();
        }

        public void TablePerHierarchy()
        {
            using (var db = new TPH.MyContext())
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<TPH.MyContext>());

                var commonArticle = new TPH.Article { Title = "Common article" };
                var onlineArticle = new TPH.OnlineArticle { Title = "Online article", Url = "http://www.cz"};
                var offlineArticle = new TPH.OfflineArticle { Title = "Offline article", Isbn = "123-456"};

                db.Articles.Add(commonArticle);
                db.Articles.Add(onlineArticle);
                db.Articles.Add(offlineArticle);

                db.SaveChanges();
            }
        }

        public void TablePerType()
        {
            using (var db = new TPT.MyContext())
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<TPT.MyContext>());

                var commonArticle = new TPT.Article { Title = "Common article" };
                var onlineArticle = new TPT.OnlineArticle { Title = "Online article", Url = "http://www.cz" };
                var offlineArticle = new TPT.OfflineArticle { Title = "Offline article", Isbn = "123-456" };

                db.Articles.Add(commonArticle);
                db.Articles.Add(onlineArticle);
                db.Articles.Add(offlineArticle);

                db.SaveChanges();
            }
        }

        public void TablePerClass()
        {
            using (var db = new TPC.MyContext())
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<TPC.MyContext>());

                var onlineArticle = new TPC.OnlineArticle { Title = "Online article", Url = "http://www.cz" };
                var offlineArticle = new TPC.OfflineArticle { Title = "Offline article", Isbn = "123-456" };

                db.Articles.Add(onlineArticle);
                db.Articles.Add(offlineArticle);

                db.SaveChanges();
            }
        }
    }
}
