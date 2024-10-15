﻿using Common.DB.Model;
using Inventory.BL.Interfaces.Repository;
using Inventory.BL.Services.Context;
using Microsoft.EntityFrameworkCore;

namespace Inventory.BL.Services.Repository
{
    public class ItemRepository : IItemRepository
    {
        private InventoryDBContext _inventoryDb;

        public ItemRepository( InventoryDBContext localDb )
        {
            _inventoryDb = localDb;
        }

        public async Task CreateDBItemAsync( Item element )
        {
            await _inventoryDb.Items
                .AddAsync ( element );

            var result = await _inventoryDb.SaveChangesAsync ();
        }

        public async Task DeleteDBItemAsync( Guid id )
        {
            var find = await _inventoryDb.Items
                .FirstOrDefaultAsync ( x => x.Id == id );

            var result = _inventoryDb.Items
                .Remove ( find );

            await _inventoryDb.SaveChangesAsync ();
        }

        public async Task<IEnumerable<Item>> GetDBItemListAsync( string name , int limit )
        {
            return await _inventoryDb.Items
                .Where ( i => i.Name.Contains ( name ) )
                .Take ( limit )
                .ToListAsync ();
        }

        public async Task<Item> ReadDBItemAsync( Guid id )
        {
            return await _inventoryDb.Items
                .FirstOrDefaultAsync ( x => x.Id == id );
        }

        public async Task UpdateDBItemAsync( Item element )
        {
            _inventoryDb.Items
                 .Update ( element );

            var result = await _inventoryDb.SaveChangesAsync ();
        }
    }
}
