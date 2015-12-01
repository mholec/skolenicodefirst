using System;
using System.Collections.Generic;
using Dotazovani.Entities;

namespace Dotazovani.Priklady
{
    public class ModificationExamples
    {
        private readonly BookStoreContext context;

        public ModificationExamples(BookStoreContext context)
        {
            this.context = context;
        }

        public void Start()
        {
            /*************************************** UPDATE */

            // načtení dat a následné uložení
            Book book = context.Books.Find(2);
            book.Title = "O pejskovi a kočičce";
            context.SaveChanges();

            // aktualizace na závislé property není problém
            var bookWithCategory = context.Books.Find(2);
            bookWithCategory.Category.Name = "Psychologická kniha";
            context.SaveChanges();

            /*************************************** CREATE */

            // přidání záznamu
            context.Books.Add(book);
            context.SaveChanges();

            // přidání záznamu s navázanou entitou
            Category category = new Category {Name = "Hudební knihy"};
            context.Books.Add(new EBook {Title = "Michael Jackson", Added = DateTime.Now, CategoryId = 1});
            context.Books.Add(new PrintedBook {Title = "Michael Jackson", Added = DateTime.Now, Category = category});
            context.SaveChanges();

            var allData = new EBook
            {
                Title = "Jezevčík",
                Added = DateTime.Now,
                Category = new Category { Name = "Zvířata" },
                ParameterValues = new List<ParameterValue>
                {
                    new ParameterValue { ParameterId = 1, Value = "135"},
                    new ParameterValue {ParameterId = 2, Value = "2015"}
                }
            };

            context.Books.Add(allData);
            context.SaveChanges();

            /*************************************** DELETE */

            // odstranění záznamu
            context.Books.Remove(allData);
            context.SaveChanges();

            // cascading delete disabled
            var parameters = allData.ParameterValues;
            context.ParameterValues.RemoveRange(parameters);
            context.Books.Remove(allData);
            context.SaveChanges();

            // https://www.miroslavholec.cz/blog/entity-framework-a-optimalizace-dotazu
        }
    }
}
