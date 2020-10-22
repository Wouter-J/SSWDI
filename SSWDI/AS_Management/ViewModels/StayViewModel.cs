using AS_Core.DomainModel;
using System.Collections.Generic;

namespace AS_Management.ViewModels
{
    public class StayViewModel
    {
        public IEnumerable<Animal> Animals { get; set; }

        public Stay Stay { get; set; } // Needed for table headers

        public Animal Animal { get; set; } // Needed for table headers

        public IEnumerable<Stay> Stays { get; set; }

        public Lodging Lodge { get; set; }

        public Lodging CurrentLodge { get; set; }

        public IEnumerable<Lodging> Lodges { get; set; }
    }
}
