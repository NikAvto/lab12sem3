using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClassLibrary1;

namespace lab12sem3.Pages.Researches
{
    public class CreateModel : PageModel
    {
        private readonly LaboratoryContext _context;

        public CreateModel(LaboratoryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Research Research { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Researches.Add(Research);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
