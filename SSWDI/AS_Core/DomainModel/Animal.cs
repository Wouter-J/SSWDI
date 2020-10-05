using System;
using System.Collections.Generic;

namespace AS_Core.DomainModel
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
        public DateTime? DateOfDeath { get; set; }
        public bool Castrated { get; set; }
        public ChildFriendly ChildFriendly { get; set; }
        public string ReasonGivenAway { get; set; } //Only employees should be able to read this
        public List<AnimalStay> AnimalStays { get; set; }
    }
}
