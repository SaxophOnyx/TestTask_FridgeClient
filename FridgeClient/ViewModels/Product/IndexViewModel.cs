using FridgeClient.ViewModels.Entities;
using System.Collections.Generic;

namespace FridgeClient.ViewModels.Product
{
    public class IndexViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
