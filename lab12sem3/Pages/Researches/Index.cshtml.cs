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
    public class IndexModel : PageModel
    {
        private readonly LaboratoryContext _context;

        public IndexModel(LaboratoryContext context)
        {
            _context = context;
        }

        public IList<Research> Research { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Research = await _context.Researches.ToListAsync();
        }
    }
}
