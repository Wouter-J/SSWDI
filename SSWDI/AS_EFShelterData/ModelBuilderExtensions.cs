using System;
using System.Collections.Generic;
using System.Text;
using AS_Core.DomainModel;
using AS_Core.Enums;
using Microsoft.EntityFrameworkCore;
using AS_DomainServices.Repositories;

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
                Description = "Grote opvang voor Honden ",
                MaxCapacity = 100,
                CurrentCapacity = 10,
                AnimalType = AnimalType.Dog,
                Stays = new List<Stay>() { },
            };

            Lodging lodge2 = new Lodging()
            {
                ID = 2,
                LodgingType = LodgingType.Group,
                Description = "Grote opvang voor Katten ",
                MaxCapacity = 100,
                CurrentCapacity = 10,
                AnimalType = AnimalType.Cat,
                Stays = new List<Stay>() { },
            };
            modelBuilder.Entity<Lodging>().HasData(lodge, lodge2);

            User Wouter = new User()
            {
                ID = 1,
                Firstname = "Wouter",
                Lastname = "Jansen",
                Email = "wouterjansen97@gmail.com",
                Cellphone = "0612345678",
                BirthDay = new DateTime(1997, 04, 08),
                Address = "Kloostergang 326",
                PostalCode = "4201JA",
                InterestInAnimals = new List<Animal>(),
                AnimalsAdopted = new List<Stay>() { }
            };
            modelBuilder.Entity<User>().HasData(Wouter);

            modelBuilder.Entity<Animal>().HasData(new
            {
                ID = 1,
                Name = "Doggo",
                Birthdate = new DateTime(2018, 10, 18),
                Age = 2,
                EstimatedAge = 2,
                Description = "Good boi",
                Gender = Gender.Male,
                AnimalType = AnimalType.Dog,
                Race = "Best Bois",
                Picture = "Goodboi.png",
                Castrated = true,
                ChildFriendly = ChildFriendly.Yes,
                ReasonGivenAway = "Too good a boi",
                InderestedUserID = Wouter.ID
            });

            Animal garfield = new Animal()
            {
                ID = 2,
                Name = "Garfield",
                Birthdate = new DateTime(2018, 10, 18),
                Age = 2,
                EstimatedAge = 2,
                Description = "Good boi",
                Gender = Gender.Female,
                AnimalType = AnimalType.Cat,
                Race = "Garfields",
                Picture = "Garfield.png",
                DateOfDeath = null,
                Castrated = true,
                ChildFriendly = ChildFriendly.Yes,
                ReasonGivenAway = "Ate too much lasagna",
            };
            modelBuilder.Entity<Animal>().HasData(garfield);

            Stay doggoStay = new Stay()
            {
                ID = 1,
                ArrivalDate = new DateTime(2019, 10, 18),
                AdoptionDate = null,
                CanBeAdopted = true,
                AdoptedBy = "wouterjansen97@gmail.com",
                LodgingLocationID = lodge.ID,
                AnimalID = 1,
                Comments = new List<Comment>(),
                Treatments = new List<Treatment>(),
            };

            Stay garfieldStay = new Stay()
            {
                ID = 2,
                ArrivalDate = new DateTime(2019, 10, 18),
                AdoptionDate = null,
                CanBeAdopted = true,
                AdoptedBy = null,
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
                Costs = 100,
                RequiredAge = 0.6f,
                DoneBy = "Some Person",
                Date = DateTime.Now,
                StayID = doggoStay.ID
            };

            Treatment garfieldTreatment = new Treatment()
            {
                ID = 2,
                Description = "Removed lasagna from stomach",
                TreatmentType = TreatmentType.Operation,
                Costs = 100,
                RequiredAge = 0.6f,
                DoneBy = "Some Person",
                Date = DateTime.Now,
                StayID = garfieldStay.ID
            };
            modelBuilder.Entity<Treatment>().HasData(doggoTreatment, garfieldTreatment);
        }
    }
}
