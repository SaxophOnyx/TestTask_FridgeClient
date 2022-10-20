using System;

namespace FridgeClient.FridgeAPI.DataTransferObjects.Request
{
    public class ProductToReturn
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int? DefaultQuantity { get; set; }
    }
}
