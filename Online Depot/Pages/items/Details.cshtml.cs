#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_Depot.Data;
using Online_Depot.item;

namespace Online_Depot.Pages.items
{
    public class DetailsModel : PageModel
    {
        private readonly Online_Depot.Data.Online_DepotContext _context;

        public DetailsModel(Online_Depot.Data.Online_DepotContext context)
        {
            _context = context;
        }

        public itemclass itemclass { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            itemclass = await _context.itemclass.FirstOrDefaultAsync(m => m.ID == id);

            if (itemclass == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
