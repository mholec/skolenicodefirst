using System.ComponentModel.DataAnnotations.Schema;

namespace SkoleniCodeFirst.VztahyMeziEntitami.KomplexniTypy
{
    public class Contact
    {
        [Column("Phone")]
        public string Phone { get; set; }

        [Column("WebsiteUrl")]
        public string WebsiteUrl { get; set; }

        public string Email { get; set; }
    }
}
