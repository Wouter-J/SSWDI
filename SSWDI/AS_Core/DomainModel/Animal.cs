using AS_Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AS_Core.DomainModel
{
    public class Animal
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        [Required]
        public int Age { get; set; }

        public int EstimatedAge { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public AnimalType AnimalType { get; set; }

        public string Race { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public string Picture { get; set; }

        public string ImageName { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public DateTime? DateOfDeath { get; set; }

        [Required]
        public bool Castrated { get; set; }

        [Required]
        public ChildFriendly ChildFriendly { get; set; }

        [Required]
        public string ReasonGivenAway { get; set; } // Only employees should be able to read this

        public ICollection<Stay> Stays { get; set; } = new List<Stay>();

        public string InterestedUser { get; set; } // TODO : Change this to user
    }
}
