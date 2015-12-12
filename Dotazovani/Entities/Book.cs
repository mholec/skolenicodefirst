using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace Dotazovani.Entities
{
    public partial class Book
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


        // predicates
        public static Expression<Func<Book, bool>> IsInteresting()
        {
            return x => x.Title.Length > 10;
        }

        public static Expression<Func<Book, bool>> HasParameters()
        {
            return x => x.ParameterValues.Any();
        }
    }
}
