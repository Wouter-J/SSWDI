using AS_Core.DomainModel;
using AS_Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AS_Adoption.ViewModels
{
    public class StayViewModel
    {
        public IEnumerable<Stay> Stays { get; set; }

        public Animal Animal { get; set; }

        public IEnumerable<Animal> Animals { get; set; }

        public AnimalType AnimalType { get; set; }

        public Gender Gender { get; set; }

        public ChildFriendly ChildFriendly { get; set; }
    }
}
