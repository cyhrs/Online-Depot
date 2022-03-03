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
#pragma warning disable CS8618
#pragma warning disable CS8601
#pragma warning disable CS8602
#pragma warning disable CS8604
    public class DeleteModel : PageModel
    {
        private readonly Online_Depot.Data.Online_DepotContext _context;

        public DeleteModel(Online_Depot.Data.Online_DepotContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            itemclass = await _context.itemclass.FindAsync(id);

            if (itemclass != null)
            {
                _context.itemclass.Remove(itemclass);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
            #pragma warning restore CS8618
            #pragma warning restore CS8601
            #pragma warning restore CS8602
            #pragma warning restore CS8604
    }
}
