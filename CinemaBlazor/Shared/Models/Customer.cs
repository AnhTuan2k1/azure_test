using System;
using System.Collections.Generic;

namespace CinemaBlazor.Shared.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Comments = new HashSet<Comment>();
            Invoices = new HashSet<Invoice>();
            Rates = new HashSet<Rate>();
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? Birthday { get; set; }
        public string? AvatarUrl { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
