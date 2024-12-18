using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClassLibrary1;

namespace lab12sem3.Pages.Scientists
{
    public class DetailsModel : PageModel
    {
        private readonly LaboratoryContext _context;

        public DetailsModel(LaboratoryContext context)
        {
            _context = context;
        }

        public Scientist Scientist { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scientist = await _context.Scientists.FirstOrDefaultAsync(m => m.Id == id);
            if (scientist == null)
            {
                return NotFound();
            }
            else
            {
                Scientist = scientist;
            }
            return Page();
        }
    }
}
