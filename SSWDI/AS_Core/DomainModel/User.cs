using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AS_Core.DomainModel
{
    public class User
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        [Required]
        public string Email { get; set; }

        public string Cellphone { get; set; }

        public DateTime BirthDay { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }
        public IEnumerable<Stay> AnimalsAdopted { get; set; } = new List<Stay>();

        // TODO: Add role
        // public IEnumerable<Animal> InterestInAnimals { get; set; } = new List<Animal>();
        public IEnumerable<InterestedAnimal> InterestedAnimals { get; set; } = new List<InterestedAnimal>();

        public int InterestCount { get; set; }
    }
}
