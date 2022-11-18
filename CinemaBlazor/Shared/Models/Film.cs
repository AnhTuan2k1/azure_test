using System;
using System.Collections.Generic;

namespace CinemaBlazor.Shared.Models
{
    public partial class Film
    {
        public Film()
        {
            Comments = new HashSet<Comment>();
            Rates = new HashSet<Rate>();
            ShowTimes = new HashSet<ShowTime>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Content { get; set; }
        public int FilmGenreId { get; set; }
        public int? Length { get; set; }
        public DateTime? OpenningDay { get; set; }
        public string? ImageUrl { get; set; }
        public string? TrailerUrl { get; set; }
        public string? Nation { get; set; }
        public string? Directior { get; set; }
        public string? Cast { get; set; }

        public virtual FilmGenre FilmGenre { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<ShowTime> ShowTimes { get; set; }
    }
}
