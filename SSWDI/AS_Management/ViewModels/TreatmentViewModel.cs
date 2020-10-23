using AS_Core.DomainModel;
using System.Collections.Generic;

namespace AS_Management.ViewModels
{
    public class TreatmentViewModel
    {
        public Animal Animal { get; set; }

        public IEnumerable<Animal> Animals { get; set; }

        public Stay Stay { get; set; }

        public Treatment Treatment { get; set; }
    }
}
