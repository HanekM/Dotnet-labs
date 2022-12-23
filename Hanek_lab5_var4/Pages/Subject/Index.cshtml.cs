using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab5.Models;

namespace Lab5.Pages.Subject
{
    public class IndexModel : PageModel
    {
        private readonly Lab5.Models.UniversityContext _context;

        public IndexModel(Lab5.Models.UniversityContext context)
        {
            _context = context;
        }

        public IList<Models.Subject> Subject { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Subjects != null)
            {
                Subject = await _context.Subjects.ToListAsync();
            }
        }
    }
}
