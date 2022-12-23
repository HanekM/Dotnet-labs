using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab5.Models;

namespace Lab5.Pages.Position
{
    public class DetailsModel : PageModel
    {
        private readonly Lab5.Models.UniversityContext _context;

        public DetailsModel(Lab5.Models.UniversityContext context)
        {
            _context = context;
        }

      public Models.Position Position { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Positions == null)
            {
                return NotFound();
            }

            var position = await _context.Positions.FirstOrDefaultAsync(m => m.Id == id);
            if (position == null)
            {
                return NotFound();
            }
            else 
            {
                Position = position;
            }
            return Page();
        }
    }
}
