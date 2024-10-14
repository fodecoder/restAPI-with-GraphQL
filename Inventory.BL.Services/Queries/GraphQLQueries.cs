using GraphQL.Types;
using Inventory.BL.Interfaces.Model;

namespace Inventory.BL.Services.Queries
{
    public class InventoryQuery : ObjectGraphType
    {
        private List<ItemData> items = new List<ItemData> ();

        public InventoryQuery()
        {
            Field<ListGraphType<ItemData>> ( "items" )
                .Description ( "Returns a collection of items." )
                .Resolve ( context => items );
        }
    }
}
