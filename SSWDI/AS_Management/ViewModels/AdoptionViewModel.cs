using AS_Core.DomainModel;

namespace AS_Management.ViewModels
{
    public class AdoptionViewModel
    {
        public Animal Animal { get; set; }

        public Stay Stay { get; set; }

        public User User { get; set; }
    }
}
