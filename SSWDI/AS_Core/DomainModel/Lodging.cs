﻿using System.Collections.Generic;

namespace AS_Core.DomainModel
{
    public class Lodging
    {
        public int ID { get; set; }
        public LodgingType LodgingType { get; set; }
        public int MaxCapacity { get; set; }
        public AnimalType AnimalType { get; set; }
        public List<Animal> Animals { get; set; }
    }
}