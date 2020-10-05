using System;
using System.Collections.Generic;
using System.Text;

namespace AS_Core.DomainModel
{
    public class AnimalStay
    {
        //public int AnimalID { get; set; }
        public virtual Animal Animal { get; set; }
        public virtual Stay Stay { get; set; }
    }
}
