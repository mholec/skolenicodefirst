using System;
using System.Collections.Generic;

namespace Dotazovani.Entities
{
    public class Book
    {
        // pk
        public int BookId { get; set; }

        // fk
        public int CategoryId { get; set; }

        // properties
        public string Title { get; set; }
        public DateTime Added { get; set; }
        
        
        // navigation properties
        public virtual Category Category { get; set; }
        public virtual ICollection<ParameterValue> ParameterValues { get; set; }
    }
}
