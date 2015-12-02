using System.Data.Entity;
using System.Linq;
using SkoleniCodeFirst.VztahyMeziEntitami.Enumy;
using SkoleniCodeFirst.VztahyMeziEntitami.ManyToOneToMany;

namespace SkoleniCodeFirst.VztahyMeziEntitami
{
    public class Example
    {
        public void Start()
        {
            // OneToMany();
            // ManyToMany();
            // ManyToOneToMany();
            // SelfRelace();
            // OneToOneOrZero();
            // KomplexniTypy();
            // Enumy();
             EnumyBestPractice();
        }

        public void OneToMany()
        {
            using (var db = new OneToMany.MyContext())
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<OneToMany.MyContext>());
                var article = db.Articles.FirstOrDefault();
            }
        }

        public void ManyToMany()
        {
            using (var db = new ManyToMany.FluentApi.MyContext())
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<ManyToMany.FluentApi.MyContext>());

                var article = new ManyToMany.FluentApi.Article() { Title = "My article" };
                article.Authors.Add(new ManyToMany.FluentApi.Author() { FirstName = "Miroslav" });

                db.Articles.Add(article);
                db.SaveChanges();
            }
        }

        public void ManyToOneToMany()
        {
            using (var db = new ManyToOneToMany.MyContext())
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<ManyToOneToMany.MyContext>());
                var article = db.Articles.FirstOrDefault();
                article.AuthorArticles.Add(new AuthorArticles {Author = new Author(), Priority = 1});
            }
        }

        public void SelfRelace()
        {
            using (var db = new SelfRelace.MyContext())
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<SelfRelace.MyContext>());
                var category = db.Categories.FirstOrDefault();
            }
        }

        public void OneToOneOrZero()
        {
            using (var db = new OneToOneOrZero.MyContext())
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<OneToOneOrZero.MyContext>());
                var art = new OneToOneOrZero.Article
                {
                    Title = "sss"
                };
                // art.Metadata = new ArticleMetadata();

                db.Articles.Add(art);
                db.SaveChanges();
            }
        }

        public void KomplexniTypy()
        {
            using (var db = new KomplexniTypy.MyContext())
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<KomplexniTypy.MyContext>());
                var author = db.Authors.FirstOrDefault();
            }
        }

        public void Enumy()
        {
            using ( var db = new Enumy.MyContext())
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<Enumy.MyContext>());
                var article = new Enumy.Article
                {
                    Title = "My article",
                    // State = State.Public
                };

                db.Articles.Add(article);
                db.SaveChanges();

                var myArticle = db.Articles.FirstOrDefault(x => x.State == State.New);
            }
        }

        public void EnumyBestPractice()
        {
            using (var db = new Enumy.BestPractice.MyContext())
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<Enumy.BestPractice.MyContext>());
                var article = new Enumy.BestPractice.Article
                {
                    Title = "My article",
                    StateId = VztahyMeziEntitami.Enumy.BestPractice.State.Public
                };

                db.Articles.Add(article);
                db.SaveChanges();

                var myArticle = db.Articles.FirstOrDefault(x => x.StateId == VztahyMeziEntitami.Enumy.BestPractice.State.New);
            }
        }
    }
}
