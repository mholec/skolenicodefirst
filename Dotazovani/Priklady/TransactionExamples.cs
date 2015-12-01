using System;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using IsolationLevel = System.Data.IsolationLevel;

namespace Dotazovani.Priklady
{
    public class TransactionExamples
    {
        private readonly BookStoreContext context;

        public TransactionExamples(BookStoreContext context)
        {
            this.context = context;
        }

        public void Start()
        {
            // samotna save changes je transakce
            var book = context.Books.FirstOrDefault();
            book.Title = book.Title + " NEW";

            var author = context.Categories.FirstOrDefault();
            author.Name = author.Name + " ml.";

            context.SaveChanges();

            // nekdy je ale potreba prubezne ukladat a pote zmeny potvrdit (standardni transakce)
            // http://gavindraper.com/2012/02/18/sql-server-isolation-levels-by-example/
            using (var transaction = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    book.Title = book.Title.Replace(" NEW", "");
                    context.SaveChanges();

                    author.Name = author.Name.Replace(" ml.", "");
                    context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                }
            }

            // je mozne pouzit System.TransactionScope
            using (var scope = new TransactionScope())
            {
                // sql queries
                // c# code
                // async / await

                scope.Complete();
            }
        }
    }
}
