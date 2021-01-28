using System;
using System.Collections.Generic;
using System.Text;

namespace AS_Core.DomainModel
{
    public class InterestedAnimal
    {
        public int AnimalID { get; set; }

        public Animal Animal { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }
    }
}
