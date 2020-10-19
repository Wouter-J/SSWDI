using System;
using System.Collections.Generic;
using System.Text;
using AS_Core.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace AS_EFShelterData
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            Lodging lodge = new Lodging()
            {
                ID = 1,
                LodgingType = LodgingType.Group,
                MaxCapacity = 100,
                CurrentCapacity = 10,
                AnimalType = AnimalType.Dog,
                Stays = new List<Stay>() { },
            };

            Lodging lodge2 = new Lodging()
            {
                ID = 2,
                LodgingType = LodgingType.Group,
                MaxCapacity = 100,
                CurrentCapacity = 10,
                AnimalType = AnimalType.Cat,
                Stays = new List<Stay>() { },
            };
            modelBuilder.Entity<Lodging>().HasData(lodge, lodge2);

            Animal doggo = new Animal()
            {
                ID = 1,
                Name = "Doggo",
                Birthdate = new DateTime(2018, 10, 18),
                Age = 2,
                EstimatedAge = 2,
                Description = "Good boi",
                AnimalType = AnimalType.Dog,
                Race = "Best Bois",
                Picture = "Goodboi.png",
                DateOfDeath = null,
                Castrated = true,
                ChildFriendly = ChildFriendly.Yes,
                ReasonGivenAway = "Too good a boi",
            };

            Animal garfield = new Animal()
            {
                ID = 2,
                Name = "Garfield",
                Birthdate = new DateTime(2018, 10, 18),
                Age = 2,
                EstimatedAge = 2,
                Description = "Good boi",
                AnimalType = AnimalType.Cat,
                Race = "Garfields",
                Picture = "Garfield.png",
                DateOfDeath = null,
                Castrated = true,
                ChildFriendly = ChildFriendly.Yes,
                ReasonGivenAway = "Ate too much lasagna",
            };
            modelBuilder.Entity<Animal>().HasData(doggo, garfield);

            Stay doggoStay = new Stay()
            {
                ID = 1,
                ArrivalDate = new DateTime(2019, 10, 18),
                AdoptionDate = null,
                CanBeAdopted = true,
                AdoptedBy = string.Empty,
                LodgingLocationID = lodge.ID,
                AnimalID = doggo.ID,
                Comments = new List<Comment>(),
                Treatments = new List<Treatment>(),
            };

            Stay garfieldStay = new Stay()
            {
                ID = 2,
                ArrivalDate = new DateTime(2019, 10, 18),
                AdoptionDate = null,
                CanBeAdopted = true,
                AdoptedBy = string.Empty,
                AnimalID = garfield.ID,
                LodgingLocationID = lodge2.ID,
                Comments = new List<Comment>() { },
                Treatments = new List<Treatment>() { },
            };
            modelBuilder.Entity<Stay>().HasData(doggoStay, garfieldStay);

            Comment doggoComment = new Comment()
            {
                ID = 1,
                Content = "Cool doggo",
                Date = DateTime.Now,
                WrittenBy = "Barry",
                StayID = doggoStay.ID,
            };

            Comment garfieldComment = new Comment()
            {
                ID = 2,
                Content = "Ate all the lasagna",
                Date = DateTime.Now,
                WrittenBy = "Barry",
                StayID = garfieldStay.ID,
            };
            modelBuilder.Entity<Comment>().HasData(doggoComment, garfieldComment);

            Treatment doggoTreatment = new Treatment()
            {
                ID = 1,
                Description = "Inenting voor ziekte x",
                TreatmentType = TreatmentType.Vaccination,
                Costs = 100.50M,
                RequiredAge = 1,
                DoneBy = "Some Person",
                Date = DateTime.Now,
                StayID = doggoStay.ID
            };

            Treatment garfieldTreatment = new Treatment()
            {
                ID = 2,
                Description = "Removed lasagna from stomach",
                TreatmentType = TreatmentType.Operation,
                Costs = 100.50M,
                RequiredAge = 1,
                DoneBy = "Some Person",
                Date = DateTime.Now,
                StayID = garfieldStay.ID
            };
            modelBuilder.Entity<Treatment>().HasData(doggoTreatment, garfieldTreatment);
        }
    }
}
