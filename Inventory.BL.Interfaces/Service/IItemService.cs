using Inventory.BL.Interfaces.Model;

namespace Inventory.BL.Interfaces.Service
{
    public interface IItemService
    {
        public Task CreateItemAsync( Item element );
        public Task<Item> ReadItemAsync( Guid id );
        public Task UpdateItemAsync( Item element );
        public Task DeleteItemAsync( Guid id );
    }
}
