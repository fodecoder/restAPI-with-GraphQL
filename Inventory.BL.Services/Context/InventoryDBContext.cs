using Common.DB.Model;
using Microsoft.EntityFrameworkCore;

namespace Inventory.BL.Services.Context
{
    public class InventoryDBContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public InventoryDBContext( DbContextOptions<InventoryDBContext> options )
        : base ( options )
        {
        }
    }
}
