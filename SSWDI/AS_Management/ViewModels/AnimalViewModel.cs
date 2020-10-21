using AS_Core.DomainModel;
using System.Collections.Generic;
using AS_Core.Enums;

namespace AS_Management.ViewModels
{
    public class AnimalViewModel
    {
        public Animal Animal { get; set; }

        public Stay Stay { get; set; }

        public AnimalType AnimalType { get; set; }

        public Lodging Lodge { get; set; }

        public IEnumerable<Lodging> Lodgings { get; set; }
    }
}