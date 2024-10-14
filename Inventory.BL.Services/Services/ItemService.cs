using AutoMapper;
using Inventory.BL.Interfaces.Model;
using Inventory.BL.Interfaces.Repository;
using Inventory.BL.Interfaces.Service;
using DB = Common.DB.Model;

namespace Inventory.BL.Services.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemService( IItemRepository itemRepository , IMapper mapper )
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task CreateItemAsync( Item element )
        {
            var newItem = new DB.Item ()
            {
                Id = Guid.NewGuid () ,
                Name = element.Name ,
                Description = element.Description ,
                Type = element.Type
            };

            await _itemRepository.CreateDBItemAsync ( newItem );
        }

        public async Task DeleteItemAsync( Guid id )
        {
            await _itemRepository.DeleteDBItemAsync ( id );
        }

        public async Task<IEnumerable<Item>> GetItemsAsync( int limit )
        {
            var retValue = await _itemRepository.GetDBItemListAsync ( limit );
            return _mapper.Map<IEnumerable<Item>> ( retValue );
        }

        public async Task<Item> ReadItemAsync( Guid id )
        {
            var retValue = await _itemRepository.ReadDBItemAsync ( id );
            return _mapper.Map<Item> ( retValue );
        }

        public async Task UpdateItemAsync( Item element )
        {
            var updatedItem = new DB.Item ()
            {
                Id = element.Id ,
                Name = element.Name ,
                Description = element.Description ,
                Type = element.Type ,
                Modified = DateTime.UtcNow
            };
            await _itemRepository.UpdateDBItemAsync ( updatedItem );
        }
    }
}
