using System;

namespace FridgeClient.ViewModels.Entities
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set;}

        public int? DefaultQuantity { get; set; }
    }
}
