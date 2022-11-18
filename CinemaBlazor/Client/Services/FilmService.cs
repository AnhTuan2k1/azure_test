using CinemaBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBlazor.Client.Services
{
    public class FilmService : IFilmService
    {
        private readonly HttpClient httpClient;

        public FilmService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Film>?> GetFilms()
        {
            var films = await httpClient.GetFromJsonAsync<IEnumerable<Film>>("api/films");
            return films;
        
        }
    }
}
