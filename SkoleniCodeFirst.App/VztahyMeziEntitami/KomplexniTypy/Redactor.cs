using System.ComponentModel.DataAnnotations;

namespace SkoleniCodeFirst.VztahyMeziEntitami.KomplexniTypy
{
    public class Redactor
    {
        [Key]
        public int RedactorId { get; set; }
        public Contact Contact { get; set; }
    }
}
