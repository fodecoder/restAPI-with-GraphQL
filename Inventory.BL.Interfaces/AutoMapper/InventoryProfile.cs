using AutoMapper;
using Inventory.BL.Interfaces.Model;
using DB = Common.DB.Model;

namespace Inventory.BL.Interfaces.AutoMapper
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<DB.Item , Item> ();
        }
    }
}
