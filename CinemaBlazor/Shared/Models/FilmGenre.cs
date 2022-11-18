using System;
using System.Collections.Generic;

namespace CinemaBlazor.Shared.Models
{
    public partial class FilmGenre
    {
        public FilmGenre()
        {
            Films = new HashSet<Film>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Film> Films { get; set; }
    }
}
