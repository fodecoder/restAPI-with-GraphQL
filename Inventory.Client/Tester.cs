using Inventory.BL.Interfaces.Service;

namespace Inventory.Client
{
    public class Tester
    {
        private readonly IItemService _itemService;

        public Tester( IItemService itemService )
        {
            _itemService = itemService;
        }

        public async Task Run()
        {
            Console.WriteLine ( "Testin APIs..." );

            Console.WriteLine ( "Test create..." );
            await _itemService.CreateItemAsync (
                new BL.Interfaces.Model.Item ()
                {
                    Name = "Test - " + new Random ().Next ( 0 , 10000 ) ,
                    Description = "Description - " + new Random ().Next ( 0 , 10000 ) ,
                    Type = "Type - " + new Random ().Next ( 0 , 10 )
                } );
        }
    }
}
