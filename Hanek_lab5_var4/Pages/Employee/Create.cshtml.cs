using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab5.Models;

namespace Lab5.Pages.Employee
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
        ViewData["HomeAddressID"] = new SelectList(_context.Locations, "Id", "Id");
        ViewData["PositionID"] = new SelectList(_context.Positions, "Id", "Id");
        ViewData["SubjectID"] = new SelectList(_context.Subjects, "Id", "Id");
        ViewData["WorkplaceAddressID"] = new SelectList(_context.Locations, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Models.Employee Employee { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Employees == null || Employee == null)
            {
                return Page();
            }

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
