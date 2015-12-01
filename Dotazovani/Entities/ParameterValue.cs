namespace Dotazovani.Entities
{
    public class ParameterValue
    {
        // pk
        public int ParameterValueId { get; set; }

        //fk
        public int ParameterId { get; set; }
        public int BookId { get; set; }
        
        // properties
        public string Value { get; set; }
        
        // navigation properties
        public Parameter Parameter { get; set; }
        public Book Book { get; set; }
    }
}