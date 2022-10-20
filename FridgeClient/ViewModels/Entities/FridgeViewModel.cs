﻿using System;

namespace FridgeClient.ViewModels.Entities
{
    public class FridgeViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? OwnerName { get; set; }

        public FridgeModelViewModel Model { get; set; } 
    }
}
