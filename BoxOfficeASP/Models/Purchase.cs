using System;

namespace BoxOfficeASP.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int TicketQuantities { get; set; }
        public DateTime TimeSelling { get; set; }
        public int SeanceId { get; set; }
        public Seance Seance { get; set; }
    }
}
