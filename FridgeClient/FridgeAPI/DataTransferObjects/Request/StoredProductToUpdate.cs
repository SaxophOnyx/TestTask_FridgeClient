using System;

namespace FridgeClient.FridgeAPI.DataTransferObjects.Request
{
    public class StoredProductToUpdate
    {
        public Guid? Id { get; set; }

        public int? Quantity { get; set; }
    }
}
