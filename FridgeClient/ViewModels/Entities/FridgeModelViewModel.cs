using System;

namespace FridgeClient.ViewModels.Entities
{
    public class FridgeModelViewModel
    {
        public Guid Id { get; set;  }

        public string Name { get; set;  }

        public int? Year { get; set; }

        public string FullName
        {
            get { return $"{Name} ({Year})"; }
        }
    }
}
