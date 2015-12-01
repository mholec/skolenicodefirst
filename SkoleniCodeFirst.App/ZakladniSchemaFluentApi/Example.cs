using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SkoleniCodeFirst.ZakladniSchemaFluentApi
{
    public class Example
    {
        public void Start()
        {
            ValidationFailed();
            // ValidationDisabled();
            // EmailValidation();
            // ValidateBeforeSave();
        }

        public void ValidationFailed()
        {
            using (var db = new MyContext())
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<MyContext>());

                Article articleLengthTest = new Article
                {
                    Title = "My Title",
                    Description = "Short text"
                };

                db.Articles.Add(articleLengthTest);
                db.SaveChanges();
            }
        }

        public void ValidationDisabled()
        {
            using (var db = new MyContext())
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<MyContext>());

                Article articleLengthTest = new Article
                {
                    Title = "My Title",
                    Description = "Short text"
                };

                db.Articles.Add(articleLengthTest);
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges(); // uložení projde, protože MinLength() není db constraint
            }
        }

        public void EmailValidation()
        {
            using (var db = new MyContext())
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<MyContext>());

                Author author = new Author
                {
                    FirstName = "Miroslav",
                    LastName = "Holec",
                    Email = "mirek@miroslavholec.cz",
                    SecondEmail = "thisIsNotEmail"
                };

                db.Authors.Add(author);
                db.SaveChanges();
            }
        }

        public void ValidateBeforeSave()
        {
            // Slouží k tomu objekt Validator

            Author author = new Author
            {
                FirstName = "Miroslav",
                LastName = null,
                Email = null,
                SecondEmail = ""
            };

            ValidationContext validationContext = new ValidationContext(author);

            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(author, validationContext, results);

            if (!isValid)
            {
                foreach (var validationResult in results)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }
            }
        }
    }
}
