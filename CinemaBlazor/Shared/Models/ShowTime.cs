using System;
using System.Collections.Generic;

namespace CinemaBlazor.Shared.Models
{
    public partial class ShowTime
    {
        public ShowTime()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int FilmId { get; set; }
        public int ProjectionRoomId { get; set; }
        public int CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; } = null!;
        public virtual Film Film { get; set; } = null!;
        public virtual ProjectionRoom ProjectionRoom { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
