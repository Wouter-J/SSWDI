using AS_Core.DomainModel;
using System.Collections.Generic;

namespace AS_Management.ViewModels
{
    public class StayViewModel
    {
        public IEnumerable<Animal> Animals { get; set; }

        public Stay stay { get; set; } // Needed for table headers

        public Animal animal { get; set; } // Needed for table headers

        public IEnumerable<Stay> Stays { get; set; }
    }
}
