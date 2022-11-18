using System;
using System.Collections.Generic;

namespace CinemaBlazor.Shared.Models
{
    public partial class ProjectionRoom
    {
        public ProjectionRoom()
        {
            ShowTimes = new HashSet<ShowTime>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ScreenType { get; set; }
        public int CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; } = null!;
        public virtual ICollection<ShowTime> ShowTimes { get; set; }
    }
}
