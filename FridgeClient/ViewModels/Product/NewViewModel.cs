using System.ComponentModel.DataAnnotations;

namespace FridgeClient.ViewModels.Product
{
    public class NewViewModel
    {
        [Required(ErrorMessage = "Product name is a required field")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Default quantity is a required field")]
        [Range(0, int.MaxValue, ErrorMessage = "Default quantity cannot be negative")]
        public int DefaultQuantity { get; set; }
    }
}
