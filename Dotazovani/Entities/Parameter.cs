using System.Collections.Generic;

namespace Dotazovani.Entities
{
    public class Parameter
    {
        // pk
        public int ParameterId { get; set; }

        // properties
        public string Name { get; set; }
        
        // navigation properties
        public virtual ICollection<ParameterValue> Values { get; set; }
    }
}