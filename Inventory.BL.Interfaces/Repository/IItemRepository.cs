using Common.DB.Model;

namespace Inventory.BL.Interfaces.Repository
{
    public interface IItemRepository
    {
        // CRUD operations
        Task CreateDBItemAsync( Item element );
        Task<Item> ReadDBItemAsync( Guid id );
        Task UpdateDBItemAsync( Item element );
        Task DeleteDBItemAsync( Guid id );

        // List
        Task<IEnumerable<Item>> GetDBItemListAsync( int limit );
    }
}
