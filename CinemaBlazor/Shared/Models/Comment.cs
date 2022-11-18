using System;
using System.Collections.Generic;

namespace CinemaBlazor.Shared.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public int FilmId { get; set; }
        public int Customer { get; set; }

        public virtual Customer CustomerNavigation { get; set; } = null!;
        public virtual Film Film { get; set; } = null!;
    }
}
