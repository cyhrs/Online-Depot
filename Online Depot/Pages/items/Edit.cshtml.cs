#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Depot.Data;
using Online_Depot.item;

namespace Online_Depot.Pages.items
{
    public class EditModel : PageModel
    {
        private readonly Online_Depot.Data.Online_DepotContext _context;

        public EditModel(Online_Depot.Data.Online_DepotContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(itemclass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!itemclassExists(itemclass.ID))
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

        private bool itemclassExists(int id)
        {
            return _context.itemclass.Any(e => e.ID == id);
        }
    }
}
