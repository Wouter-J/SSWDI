using AS_Core.DomainModel;

namespace AS_Management.ViewModels
{
    public class AnimalViewModel
    {
        public Animal Animal { get; set; }

        public Stay Stay { get; set; }

        public AnimalType AnimalType { get; set; }
    }
}