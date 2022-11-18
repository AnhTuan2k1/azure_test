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
    public class DeleteModel : PageModel
    {
        private readonly CinemaBlazor.Shared.Models.CinemaDBContext _context;

        public DeleteModel(CinemaBlazor.Shared.Models.CinemaDBContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Film Film { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Films == null)
            {
                return NotFound();
            }

            var film = await _context.Films.FirstOrDefaultAsync(m => m.Id == id);

            if (film == null)
            {
                return NotFound();
            }
            else 
            {
                Film = film;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Films == null)
            {
                return NotFound();
            }
            var film = await _context.Films.FindAsync(id);

            if (film != null)
            {
                Film = film;
                _context.Films.Remove(Film);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
