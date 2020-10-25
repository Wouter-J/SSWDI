using AS_Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AS_WebService.Filters
{
    public class AnimalFilters
    {
        // Animal Type
        public AnimalType AnimalType { get; set; }

        //Oke with kiddos or not
        public ChildFriendly ChildFriendly { get; set; }

        // Gender
        public char Gender { get; set; }

        public bool CanBeAdopted { get; set; }

    }
}
