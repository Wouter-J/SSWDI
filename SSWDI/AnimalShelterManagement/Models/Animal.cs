using System;
using System.Collections.Generic;
using AnimalShelterManagement.Enums;

namespace AnimalShelterManagement.Models
{
    public class Animal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public int EstimatedAge { get; set; }
        public string Description { get; set; }
        public AnimalType AnimalType { get; set; }
        public string Race { get; set; } 
        public char Gender { get; set; } //M is male F is female
        public string Picture { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime AdoptionDate { get; set; }
        public DateTime DateOfDeath { get; set; }
        public bool Castrated { get; set; }
        public ChildFriendly ChildFriendly { get; set; }
        public List<Treatment> Treatments { get; set; }
        public List<Comment> Comments { get; set; }
        public string ReasonGivenAway { get; set; } //Only employees should be able to read this
        public bool CanBeAdopted { get; set; }
        public string AdoptedBy { get; set; } //TODO: Make this a link to a User
        public Lodging LodgingLocation { get; set; }

    }
}
