using System;

namespace FridgeClient.FridgeAPI.DataTransferObjects.Request
{
    public class StoredProductToCreate
    {
        public Guid? ProductId { get; set; }

        public int? Quantity { get; set; }
    }
}