using System.Data.Entity;
using System.Linq;

namespace SkoleniCodeFirst.ZakladniSchema
{
    public class Example
    {
        public void Start()
        {
            using (var db = new MyContext())
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<MyContext>());
                var article = db.Articles.FirstOrDefault();
            }
        }
    }
}
