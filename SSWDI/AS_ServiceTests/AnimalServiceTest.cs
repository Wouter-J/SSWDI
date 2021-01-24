using System;
using System.Collections.Generic;
using AS_Core.DomainModel;
using AS_Core.Enums;
using AS_DomainServices;
using AS_DomainServices.Repositories;
using AS_DomainServices.Services;
using AS_Services;
using Moq;
using Xunit;

namespace AS_ServiceTests
{
    public class AnimalServiceTest
    {
        /// <summary>
        /// This test makes sure a animal with proper values can be added.
        /// Lodging has proper capacity, same goes for the animaltype & castration.
        /// </summary>
        [Fact]
        public void AnimalWithProperShouldBeAdded()
        {
            // Arrange
            var stayRepository = new Mock<IStayRepository>();
            var stayService = new Mock<IStayService>();

            Animal dog = new Animal()
            {
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

            Lodging coolLocation = new Lodging()
            {
                LodgingType = LodgingType.Group,
                MaxCapacity = 100,
                CurrentCapacity = 10,
                AnimalType = AnimalType.Cat,
                Stays = new List<Stay>() { },
            };

            Stay stay = new Stay()
            {
                Animal = dog,
                ArrivalDate = new DateTime(2019, 10, 18),
                AdoptionDate = null,
                CanBeAdopted = true,
                AdoptedBy = null,
                LodgingLocation = coolLocation,
                Comments = new List<Comment>(),
                Treatments = new List<Treatment>(),
            };

            // Act
            stayService.Setup(_ => _.Add(stay));

            // Assert
            IEnumerable<Stay> stays = stayRepository.Object.GetAll();

            Assert.NotNull(stays);
        }

        [Fact]
        public void DogsAndCatsShouldNotGoIntoSameLodging()
        {
            // Arrange
            var stayRepository = new Mock<IStayRepository>();
            var stayService = new Mock<IStayService>();

            Animal dog = new Animal()
            {
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

            Lodging catLocation = new Lodging()
            {
                LodgingType = LodgingType.Group,
                MaxCapacity = 100,
                CurrentCapacity = 10,
                AnimalType = AnimalType.Cat,
                Stays = new List<Stay>() { },
            };

            Stay stay = new Stay()
            {
                Animal = dog,
                ArrivalDate = new DateTime(2019, 10, 18),
                AdoptionDate = null,
                CanBeAdopted = true,
                AdoptedBy = null,
                LodgingLocation = catLocation,
                Comments = new List<Comment>(),
                Treatments = new List<Treatment>(),
            };

            // Act
            stayService.Setup(_ => _.Add(stay));
            IEnumerable<Stay> stays = stayRepository.Object.GetAll();

            // Assert
            Assert.Empty(stays);
        }

        [Fact]
        public void AnimalAgeShouldBeCalculatedProperly()
        {
            // Arrange
            var animalRepository = new Mock<IAnimalRepository>();
            var animalService = new Mock<IAnimalService>();

            Animal dog = new Animal()
            {
                ID = 1,
                Name = "Doggo",
                Birthdate = DateTime.MinValue,
                Age = 0,
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

            Animal cat = new Animal()
            {
                ID = 2,
                Name = "Cat",
                Birthdate = new DateTime(2018, 10, 18),
                Age = 2,
                EstimatedAge = 0,
                Description = "Good boi",
                AnimalType = AnimalType.Dog,
                Race = "Best Bois",
                Picture = "Goodboi.png",
                DateOfDeath = null,
                Castrated = true,
                ChildFriendly = ChildFriendly.Yes,
                ReasonGivenAway = "Too good a boi",
            };

            // Act
            animalService.Setup(_ => _.Add(dog));
            animalService.Setup(_ => _.Add(cat));

            animalRepository.Setup(animalRepository => animalRepository.GetAll()).Returns(new List<Animal>()
            {
                dog,
                cat
            });

            List<Animal> stays = animalRepository.Object.GetAll() as List<Animal>;

            Animal addedDog = animalService.Object.FindByID(dog.ID);
            Animal addedCat = animalRepository.Object.FindByID(2);

            // Assert
            Assert.Equal(2, stays[0].EstimatedAge);
            Assert.Equal(2, stays[1].Age);
        }

        [Fact]
        public void BirthDataAndCaluclatedDateNotAllowed() { }

        [Fact]
        public void SterrilisationShouldBeAddedWithTreatment() { }


    }
}
