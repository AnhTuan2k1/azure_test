using System;
using System.Collections.Generic;

namespace CinemaBlazor.Shared.Models
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
        public decimal? TotalPrice { get; set; }
        public int Customer { get; set; }
        public int Employee { get; set; }

        public virtual Customer CustomerNavigation { get; set; } = null!;
        public virtual Employee EmployeeNavigation { get; set; } = null!;
    }
}
