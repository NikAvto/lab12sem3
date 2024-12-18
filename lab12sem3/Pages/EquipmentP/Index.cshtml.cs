using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClassLibrary1;

namespace lab12sem3.Pages.EquipmentP
{
    public class IndexModel : PageModel
    {
        private readonly LaboratoryContext _context;

        public IndexModel(LaboratoryContext context)
        {
            _context = context;
        }

        public IList<Equipment> Equipment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Equipment = await _context.Equipments.ToListAsync();
        }
    }
}
