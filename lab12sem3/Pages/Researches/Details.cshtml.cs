using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClassLibrary1;

namespace lab12sem3.Pages.Researches
{
    public class DetailsModel : PageModel
    {
        private readonly LaboratoryContext _context;

        public DetailsModel(LaboratoryContext context)
        {
            _context = context;
        }

        public Research Research { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var research = await _context.Researches.FirstOrDefaultAsync(m => m.Id == id);
            if (research == null)
            {
                return NotFound();
            }
            else
            {
                Research = research;
            }
            return Page();
        }
    }
}
