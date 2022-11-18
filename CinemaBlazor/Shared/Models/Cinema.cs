using System;
using System.Collections.Generic;

namespace CinemaBlazor.Shared.Models
{
    public partial class Cinema
    {
        public Cinema()
        {
            ProjectionRooms = new HashSet<ProjectionRoom>();
            ShowTimes = new HashSet<ShowTime>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? ImageUrl { get; set; }

        public virtual ICollection<ProjectionRoom> ProjectionRooms { get; set; }
        public virtual ICollection<ShowTime> ShowTimes { get; set; }
    }
}
