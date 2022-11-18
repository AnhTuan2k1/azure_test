using System;
using System.Collections.Generic;

namespace CinemaBlazor.Shared.Models
{
    public partial class Ticket
    {
        public int Id { get; set; }
        public DateTime DateSale { get; set; }
        public string Seat { get; set; } = null!;
        public string? TicketType { get; set; }
        public int? Money { get; set; }
        public int ShowTimes { get; set; }
        public int Customer { get; set; }
        public int Employee { get; set; }

        public virtual Customer CustomerNavigation { get; set; } = null!;
        public virtual Employee EmployeeNavigation { get; set; } = null!;
        public virtual ShowTime ShowTimesNavigation { get; set; } = null!;
    }
}
