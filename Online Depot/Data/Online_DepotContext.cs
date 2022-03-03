#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Online_Depot.item;

namespace Online_Depot.Data
{
    public class Online_DepotContext : DbContext
    {
        public Online_DepotContext (DbContextOptions<Online_DepotContext> options)
            : base(options)
        {
        }

        public DbSet<Online_Depot.item.itemclass> itemclass { get; set; }
    }
}
