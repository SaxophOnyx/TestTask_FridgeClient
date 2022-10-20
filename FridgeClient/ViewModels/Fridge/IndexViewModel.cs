using FridgeClient.ViewModels.Entities;
using System.Collections.Generic;

namespace FridgeClient.ViewModels.Fridge
{
    public class IndexViewModel
    {
        public IEnumerable<FridgeViewModel> Fridges { get; set; }
    }
}
