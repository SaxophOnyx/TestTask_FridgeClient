using System;

namespace FridgeClient.FridgeAPI.DataTransferObjects.Request
{
    public class ProductToCreate
    {
        public string? Name { get; set; }

        public int? DefaultQuantity { get; set; }
    }
}
