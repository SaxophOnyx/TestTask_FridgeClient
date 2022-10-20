using FridgeClient.ViewModels.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FridgeClient.ViewModels.Fridge
{
    public class EditViewModel
    {
        public SelectList AvaliableFridgeModels { get; set; }

        public List<StoredProductViewModel> AvaliableProducts { get; set; }

        [Required(ErrorMessage = "Fridge name is a required field")]
        public string FridgeName { get; set; }

        [Required(ErrorMessage = "Owner's name is a required field")]
        public string OwnerName { get; set; }

        [Required(ErrorMessage = "Fridge model is a required field")]
        public Guid? FridgeModelId { get; set; }


        public EditViewModel(IEnumerable<FridgeModelViewModel> avaliableModels, List<StoredProductViewModel> avaliableProducts)
        {
            AvaliableFridgeModels = new SelectList(avaliableModels, nameof(FridgeModelViewModel.Id), nameof(FridgeModelViewModel.FullName));
            AvaliableProducts = avaliableProducts;
        }

        public EditViewModel()
        {
            AvaliableFridgeModels = new SelectList(Enumerable.Empty<FridgeModelViewModel>(), nameof(FridgeModelViewModel.Id), nameof(FridgeModelViewModel.FullName));
            AvaliableProducts = new List<StoredProductViewModel>();
        }
    }
}
