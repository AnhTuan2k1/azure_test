using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaBlazor.Shared.Models;

namespace CinemaBlazor.Server.Pages.film
{
    public class CreateModel : PageModel
    {
        private readonly CinemaBlazor.Shared.Models.CinemaDBContext _context;

        public CreateModel(CinemaBlazor.Shared.Models.CinemaDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FilmGenreId"] = new SelectList(_context.FilmGenres, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Film Film { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Films.Add(Film);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
