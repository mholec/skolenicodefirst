using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        //[Timestamp]
        //public byte[] RowVersion { get; set; }


        // navigation properties
        public Category Category { get; set; }
        public virtual ICollection<ParameterValue> ParameterValues { get; set; }
    }
}
