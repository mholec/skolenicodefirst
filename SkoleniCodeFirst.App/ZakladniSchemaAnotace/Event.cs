using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkoleniCodeFirst.ZakladniSchemaAnotace
{
    public class Event
    {
        [Key]
        [Column(Order = 1)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2)]
        public int PlaceId { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime Date { get; set; }

        public string Notes { get; set; }
    }
}
