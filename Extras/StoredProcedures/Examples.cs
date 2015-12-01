namespace Extras.StoredProcedures
{
    public class Examples
    {
        public void Start()
        {
            using (var db = new MyContext())
            {
                db.Database.Initialize(true);

                var article = new Article {Title = "Muj prvni clanek"};
                db.Articles.Add(article);
                db.SaveChanges();
            }
        }
    }
}
