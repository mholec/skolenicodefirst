using System.ComponentModel.DataAnnotations;

namespace SkoleniCodeFirst.VztahyMeziEntitami.KomplexniTypy.FluentApi
{
    public class Redactor
    {
        [Key]
        public int RedactorId { get; set; }
        public Contact Contact { get; set; }
    }
}
