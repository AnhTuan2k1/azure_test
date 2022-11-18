using System;
using System.Collections.Generic;

namespace CinemaBlazor.Shared.Models
{
    public partial class InvoiceDetail
    {
        public int? Quantity { get; set; }
        public int InvoiceId { get; set; }
        public int TicketId { get; set; }

        public virtual Invoice Invoice { get; set; } = null!;
        public virtual Ticket Ticket { get; set; } = null!;
    }
}
