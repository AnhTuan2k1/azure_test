using CinemaBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBlazor.Client.Services
{
    public class FilmGenreService : IFilmGenreService
    {
        private readonly HttpClient httpClient;

        public FilmGenreService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<FilmGenre>?> GetFilmGenres()
        {
            var films = await httpClient.GetFromJsonAsync<IEnumerable<FilmGenre>>("api/filmgenres");
            return films;

        }
    }
}
