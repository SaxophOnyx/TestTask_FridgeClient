using FridgeClient.ViewModels.Entities;
using System.Collections.Generic;

namespace FridgeClient.ViewModels.Fridge
{
    public class DetailsViewModel
    {
        public IEnumerable<StoredProductViewModel> Products { get; set; }
    }
}