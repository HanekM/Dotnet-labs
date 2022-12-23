using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab5.Models;

namespace Lab5.Pages.Employee
{
    public class IndexModel : PageModel
    {
        private readonly Lab5.Models.UniversityContext _context;

        public IndexModel(Lab5.Models.UniversityContext context)
        {
            _context = context;
        }

        public IList<Models.Employee> Employee { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Employees != null)
            {
                Employee = await _context.Employees
                .Include(e => e.HomeAddress)
                .Include(e => e.Position)
                .Include(e => e.Subject)
                .Include(e => e.WorkplaceAddress).ToListAsync();
            }
        }
    }
}
