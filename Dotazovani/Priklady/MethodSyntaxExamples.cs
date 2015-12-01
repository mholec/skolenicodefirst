using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Dotazovani.Entities;

namespace Dotazovani.Priklady
{
    public class MethodSyntaxExamples
    {
        private readonly BookStoreContext context;

        public MethodSyntaxExamples(BookStoreContext context)
        {
            this.context = context;
        }

        public void Start()
        {
            /************************************** ZAKLADNI PRIKLADY A MATERIALIZACE */

            // běžná kolekce dat
            DbSet<Book> allBooks = context.Books;

            // načtení dat na základě podmínky
            IQueryable<Book> books = allBooks.Where(x => x.BookId > 0);
            Console.WriteLine(books.ToString());

            // postupné zpřesňování dotazu (tvorba sql query)
            books = books.Where(x => x.Title.Length > 10);
            Console.WriteLine(books.ToString());

            // načtení do paměti
            var materialised = books.ToList();

            // rozdíl je tedy v následujcím
            List<Book> good = context.Books.Where(x => x.Title.Contains("a")).Where(x => x.Added > DateTime.Now).ToList();
            List<Book> bad = context.Books.Where(x => x.Title.Contains("a")).ToList().Where(x => x.Added > DateTime.Now).ToList();

            // ne všechno lze přeložit na sql query
            try
            {
                var lastYear = context.Books.Where(x => x.Added > DateTime.Now.AddYears(-1)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                var lastYear = context.Books.Where(x => x.Added > DbFunctions.AddYears(DateTime.Now, -1)).ToList();
            }

            /************************************** WHERE A ORDER */

            // kompletní dotaz
            List<Book> example2 = context.Books.Where(x => x.Title.Contains("Superb")).OrderBy(x => x.Title).Skip(0).Take(10).ToList();

            // složený where
            List<Book> example3 = context.Books.Where(x => x.Title.Contains("Superb") && x.Title.Length > 6).ToList();

            // řazení záznamů
            List<Book> example4 = context.Books.OrderByDescending(x => x.Added).ThenBy(x => x.Title).ToList();

            /*************************************** SELECT */

            // select vybraných sloupců (do entit / anonymních typů)
            List<Book> selecting1 = context.Books.ToList();
            var selecting2 = context.Books.Select(x => new { x.BookId, x.Title }).ToList();
            var selecting3 = context.Books.ToDictionary(x => x.BookId, x => x.Title);

            // https://www.miroslavholec.cz/blog/zradna-metoda-todictionary-a-rozhrani-iqueryable

            // distinct
            List<string> uniqueTitles = context.Books.Select(x => x.Title).Distinct().ToList();

            /*************************************** SELECT 1 */
            // https://www.miroslavholec.cz/blog/rozdily-mezi-volanim-first-or-default-single-or-default-find-v-entity-framework

            Book firstByTitle = context.Books.OrderBy(x => x.Title).FirstOrDefault();
            Book firstById = context.Books.FirstOrDefault(x => x.BookId == 1);

            // prvni nebo zadna
            Book firstOrDefault = context.Books.FirstOrDefault(x => x.Title.Length > 10);

            // prvni (predpoklad, ze nejaka existuje)
            Book first = context.Books.First(x => x.Title.StartsWith("a"));

            // konkretni nebo zadna
            Book singleOrDefault = context.Books.SingleOrDefault(x => x.BookId == 155);

            // konkretni
            Book single = context.Books.Single(x => x.BookId == 2);

            // vykonnostne nejlepsi
            Book book = context.Books.Find(2);

            /*************************************** GROUPING */

            var resultGroup = context.Books.GroupBy(x => x.CategoryId).Select(x => new { CategoryId = x.Key, Count = x.Count() });
            var resultGroupMaterialised = resultGroup.Where(x => x.CategoryId > 5).ToList();

            /*************************************** LOADING */

            // klasicky eager loading
            var eagerSet = context.Books.Include(x => x.Category);
            var eagerBook = eagerSet.FirstOrDefault();
            var eagerCategory = eagerBook.Category;
            var categoryCachedId7 = context.Categories.Find(7);
            var categoryCachedId6 = context.Categories.Find(6);

            // lazy loading
            var lazySet = context.Books;
            var lazyBook = lazySet.FirstOrDefault();
            var lazyCategory = lazyBook.Category;

            // rozdily eager vs lazy loading
            var eagerSet2 = context.Books.Include(x => x.Category).ToList();
            foreach (var bookDetail in eagerSet2)
            {
                Console.WriteLine(bookDetail.Category.Name);
            }

            // explicit loading
            var explicitBook = context.Books.FirstOrDefault();
            context.Entry(explicitBook).Reference(x => x.Category).Load();
            var category = explicitBook.Category;

            /*************************************** NESTED QUERIES */
            var booksWithParameters =
                context.Books.Select(
                    x => new {Book = x, Parameters = x.ParameterValues.Select(y => new {y.Parameter.Name, y.Value})})
                    .ToList();

            var paramsForAllBooks =
                context.Books.SelectMany(x => x.ParameterValues).Select(x => new {x.Parameter}).Distinct().ToList();

            /*************************************** OF TYPE (INHERITANCE) */
            List<EBook> ebooks = context.Books.OfType<EBook>().Where(x => string.IsNullOrEmpty(x.Url)).ToList();
            List<PrintedBook> pbooks = context.Books.OfType<PrintedBook>().ToList();

            foreach (var someBook in context.Books)
            {
                if (someBook is EBook)
                {
                    EBook ebook = (EBook) someBook;
                    Console.WriteLine(ebook.Url);
                }
            }
        }
    }
}
