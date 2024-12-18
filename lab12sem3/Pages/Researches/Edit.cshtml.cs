using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassLibrary1;

namespace lab12sem3.Pages.Researches
{
    public class EditModel : PageModel
    {
        private readonly LaboratoryContext _context;

        public EditModel(LaboratoryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Research Research { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var research =  await _context.Researches.FirstOrDefaultAsync(m => m.Id == id);
            if (research == null)
            {
                return NotFound();
            }
            Research = research;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Research).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResearchExists(Research.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ResearchExists(int id)
        {
            return _context.Researches.Any(e => e.Id == id);
        }
    }
}
