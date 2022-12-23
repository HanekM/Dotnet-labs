using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab5.Models;

namespace Lab5.Pages.Position
{
    public class CreateModel : PageModel
    {
        private readonly Lab5.Models.UniversityContext _context;

        public CreateModel(Lab5.Models.UniversityContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Position Position { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Positions == null || Position == null)
            {
                return Page();
            }

            _context.Positions.Add(Position);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
