using System;

namespace FridgeClient.FridgeAPI.DataTransferObjects.Request
{
    public class FridgeModelToReturn
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int? Year { get; set; }
    }
}
