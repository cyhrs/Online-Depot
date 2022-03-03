#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Online_Depot.Data;
using Online_Depot.item;

namespace Online_Depot.Pages.items
{
    public class CreateModel : PageModel
    {
        private readonly Online_Depot.Data.Online_DepotContext _context;

        public CreateModel(Online_Depot.Data.Online_DepotContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public itemclass itemclass { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.itemclass.Add(itemclass);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
