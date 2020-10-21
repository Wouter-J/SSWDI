﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AS_Core.DomainModel
{
    public class Stay
    {
        [Key]
        public int ID { get; set; }

        public int AnimalID { get; set; }

        [ForeignKey("AnimalID")]
        [Required]
        public Animal Animal { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime? AdoptionDate { get; set; }

        public List<Treatment> Treatments { get; set; }

        public ICollection<Comment> Comments { get; set; }

        [Required]
        public bool CanBeAdopted { get; set; }

        public string AdoptedBy { get; set; } // TODO: Make this a link to a User

        public int LodgingLocationID { get; set; }

        [ForeignKey("LodgingLocationID")]
        public Lodging LodgingLocation { get; set; }
    }
}