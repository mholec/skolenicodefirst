using System.Linq;
using Dotazovani.Entities;
using LinqKit;

namespace Dotazovani.Priklady
{
    public class PredicateBuilderExamples
    {
        private readonly BookStoreContext context;

        public PredicateBuilderExamples(BookStoreContext context)
        {
            this.context = context;
        }

        public void Start()
        {
            /*************************************** BEZNE RESENI (chceme ALL ) */

            string[] keywords = new[] {"Adolf", "Felicia"};

            IQueryable<Book> allBooks = context.Books;

            foreach (var keyword in keywords)
            {
                allBooks = allBooks.Where(x => x.Title.Contains(keyword));
            }

            var allBooksMaterialised = allBooks.ToList();


            /*************************************** PREDICATE BUILDERS (chceme ANY) */
            var predicate = PredicateBuilder.False<Book>();
            foreach (string keyword in keywords)
            {
                predicate = predicate.Or(p => p.Title.Contains(keyword));
            }

            var anyBooksMaterialised = context.Books.AsExpandable().Where(predicate).ToList();


            // skladani predikatu
            var selectedBooks = context.Books.AsExpandable().Where(Book.IsInteresting().And(Book.HasParameters())).ToList();

            // genericky predikat, viz odkaz:
            // http://www.albahari.com/nutshell/predicatebuilder.aspx
        }
    }
}
