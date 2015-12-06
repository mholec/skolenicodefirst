using System;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using IsolationLevel = System.Data.IsolationLevel;

namespace Dotazovani.Priklady
{
    public class SerializableExamples
    {
        public SerializableExamples()
        {
        }

        public void Start()
        {
            BookStoreContext context1 = new BookStoreContext();
            BookStoreContext context2 = new BookStoreContext();

            var book1 = context1.Books.Find(2);
            book1.Title = "O pejskách a kočičkách AH";

            var book2 = context2.Books.Find(2);
            book2.Title = "Nový pejsci a kočičky PO";

            context2.SaveChanges();
            context1.SaveChanges();

            context1.Dispose();
            context2.Dispose();
        }
    }
}
