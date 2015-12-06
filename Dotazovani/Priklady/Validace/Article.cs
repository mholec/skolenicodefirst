using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dotazovani.Priklady.Validace
{
    public class Article : IValidatableObject
    {
        public string Title { get; set; }
        public string Description { get; set; }
        

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Title.Length > Description.Length)
                yield return new ValidationResult("Titulek nemůže být delší než popis článku");
        }
    }
}
