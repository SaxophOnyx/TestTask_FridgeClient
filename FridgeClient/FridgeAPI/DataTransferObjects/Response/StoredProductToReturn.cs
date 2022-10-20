using System;

namespace FridgeClient.FridgeAPI.DataTransferObjects.Request
{
    public class StoredProductToReturn
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }
    }
}
