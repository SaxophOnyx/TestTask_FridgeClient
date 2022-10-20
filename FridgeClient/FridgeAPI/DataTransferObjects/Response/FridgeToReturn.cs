using System;

namespace FridgeClient.FridgeAPI.DataTransferObjects.Request
{
    public class FridgeToReturn
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? OwnerName { get; set; }

        public FridgeModelToReturn Model { get; set; }
    }
}
