using AS_Core.Enums;

namespace AS_Core.Filters
{
    public class AnimalFilter
    {
        // Animal Type
        public AnimalType AnimalType { get; set; }

        public ChildFriendly ChildFriendly { get; set; }

        // Gender
        public Gender Gender { get; set; }

        public bool CanBeAdopted { get; set; }
    }
}
