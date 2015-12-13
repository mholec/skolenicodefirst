using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using Dotazovani.Entities;

namespace Dotazovani.Priklady.Validace
{
    public class ValidationExamples
    {
        public void Start()
        {
            /* validace entit jako takových */
            Article article = new Article
            {
                AuthorEmail = "mirek.cz"
            };

            ICollection<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(article, new ValidationContext(article), results, true);

            if (!isValid)
            {
                foreach (var validationResult in results)
                {
                    Console.WriteLine("Property: {0}, Error {1}", string.Join(", ", validationResult.MemberNames),
                        validationResult.ErrorMessage);
                }
            }
            
            Console.WriteLine("**************");

            /* explicitní validace nad contextem */
            BookStoreContext context = new BookStoreContext();
            context.Books.Add(new Book() {});
            context.Books.Add(new Book() {});

            foreach (var validationResults in context.GetValidationErrors())
            {
                foreach (var error in validationResults.ValidationErrors)
                {
                    Console.WriteLine("Property: {0}, Error {1}", error.PropertyName, error.ErrorMessage);
                }
            }

        }
    }
}
