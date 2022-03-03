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
#pragma warning disable CS8604
    public class IndexModel : PageModel
    {
        private readonly Online_Depot.Data.Online_DepotContext _context;

        public IndexModel(Online_Depot.Data.Online_DepotContext context)
        {
            _context = context;
        }

        public IList<itemclass> itemclass { get;set; }

        public async Task OnGetAsync()
        {
            itemclass = await _context.itemclass.ToListAsync();
        }
#pragma warning restore CS8618
#pragma warning restore CS8604
    }
}
