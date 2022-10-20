using System;
using System.ComponentModel.DataAnnotations;

namespace FridgeClient.ViewModels.Entities
{
    public class StoredProductViewModel
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative")]
        public int Quantity { get; set; }
    }
}
