using AS_Core.DomainModel;
using System.Collections.Generic;
using AS_Core.Enums;

namespace AS_Management.ViewModels
{
    public class TreatmentViewModel
    {
        public Animal Animal { get; set; }

        public IEnumerable<Animal> Animals { get; set; }

        public Stay Stay { get; set; }

        public Treatment Treatment { get; set; }

        public IEnumerable<Treatment> Treatments { get; set; }
    }
}
