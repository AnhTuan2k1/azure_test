using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaBlazor.Shared.Models;

namespace CinemaBlazor.Server.Pages.film
{
    public class IndexModel : PageModel
    {
        private readonly CinemaBlazor.Shared.Models.CinemaDBContext _context;

        public IndexModel(CinemaBlazor.Shared.Models.CinemaDBContext context)
        {
            _context = context;
        }

        public IList<Film> Film { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Films != null)
            {
                Film = await _context.Films
                .Include(f => f.FilmGenre).ToListAsync();
            }
        }
    }
}
