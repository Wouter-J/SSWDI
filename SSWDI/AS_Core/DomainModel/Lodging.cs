﻿using AS_Core.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AS_Core.DomainModel
{
    public class Lodging
    {
        [Required]
        [Key]
        public int ID { get; set; }

        public string Description { get; set; }

        public LodgingType LodgingType { get; set; }

        public int MaxCapacity { get; set; }

        public int CurrentCapacity { get; set; }

        public AnimalType AnimalType { get; set; }

        public List<Stay> Stays { get; set; } = new List<Stay>();
    }
}
