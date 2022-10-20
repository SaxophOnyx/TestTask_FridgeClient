using System;

namespace FridgeClient.FridgeAPI.DataTransferObjects.Request
{
    public class FridgeToCreate
    {
        public string? Name { get; set; }

        public string? OwnerName { get; set; }

        public Guid? ModelId { get; set; }
    }
}
