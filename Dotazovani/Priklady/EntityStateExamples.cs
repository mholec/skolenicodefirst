using System;
using System.Data.Entity;
using System.Linq;
using Dotazovani.Entities;

namespace Dotazovani.Priklady
{
    public class EntityStateExamples
    {
        private readonly BookStoreContext context;

        public EntityStateExamples(BookStoreContext context)
        {
            this.context = context;
        }

        public void Start()
        {
            // https://www.miroslavholec.cz/blog/odstranovani-dat-v-entity-framework-bez-preloadu

            // direct delete (by ID)
            Book book1 = new Book { BookId = 46 };
            context.Entry(book1).State = EntityState.Deleted;
            context.SaveChanges();

            // direct update
            EBook book2 = new EBook {BookId = 42, Title = "Tipy a triky pro iPhone 6", Added = DateTime.Now, CategoryId = 1};
            context.Entry(book2).State = EntityState.Modified; // !!! neprovede se změna typu, EF bug
            context.SaveChanges();
            
            // asnotracking
            var all1 = context.Books.ToList();
            var all2 = context.Books.AsNoTracking().ToList();
            Book book3 = context.Books.OrderByDescending(x => x.BookId).FirstOrDefault();
            Book book4 = context.Books.AsNoTracking().OrderBy(x => x.BookId).FirstOrDefault();
            book3.Title = "Chci změnit titulek";
            book4.Title = "Chci změnit titulek";
            context.SaveChanges();

            // global tracking
            context.Configuration.AutoDetectChangesEnabled = false;
            Category category = context.Categories.FirstOrDefault();
            Book book = context.Books.FirstOrDefault();
            book.Category = category;
            context.SaveChanges();

            // detect changes
            context.ChangeTracker.DetectChanges();
            context.SaveChanges();
        }
    }
}
