using GraphQL;
using GraphQL.Types;
using Inventory.BL.Interfaces.Model;
using Inventory.BL.Interfaces.Service;

namespace Inventory.BL.Services.Queries
{
    public class InventoryQuery : ObjectGraphType
    {
        public InventoryQuery( IItemService itemService )
        {
            Field<ListGraphType<ItemData>> ( "items" )
                .Description ( "Returns a collection of items." )
                .Arguments ( new QueryArguments ( new QueryArgument<IntGraphType> { Name = "limit" } ) )
                .ResolveAsync ( async context =>
                {
                    var retValue = await itemService.GetItemsAsync ( context.GetArgument<int> ( "limit" ) );
                    return retValue;
                } );
        }
    }
}
