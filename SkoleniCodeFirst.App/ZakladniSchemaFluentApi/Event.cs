using System;

namespace SkoleniCodeFirst.ZakladniSchemaFluentApi
{
    public class Event
    {
        public string Name { get; set; }
        public int PlaceId { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
    }
}
