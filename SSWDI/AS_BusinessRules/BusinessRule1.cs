using System;
using System.Collections.Generic;
using System.Linq;
using AS_Core.DomainModel;
using AS_Core.Enums;
using AS_DomainServices;
using AS_DomainServices.Repositories;
using AS_DomainServices.Services;
using AS_Management.Controllers;
using AS_Services;
using Moq;
using Xunit;

namespace AS_BusinessRules
{
    /// <summary>
    /// Business Rule 01
    /// Tests if maximum amount of capacity within a lodge cannot be exceeded.
    /// </summary>
    public class BusinessRule1
    {
        [Fact]
        public void AnimalCanBeAddedToLodge() 
        {
            // Arrange
            Mock<IStayRepository> stayRepository = new Mock<IStayRepository>();
            Mock<ILodgingRepository> lodgingRepository = new Mock<ILodgingRepository>();
            Mock<IAnimalRepository> animalRepository = new Mock<IAnimalRepository>();

            IStayService stayService = new StayService(stayRepository.Object, lodgingRepository.Object, animalRepository.Object);

            Animal dog = new Animal()
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
            Lodging coolLocation = new Lodging()
            {
                ID = 1,
                LodgingType = LodgingType.Group,
                MaxCapacity = 100,
                CurrentCapacity = 10,
                AnimalType = AnimalType.Dog,
                Stays = new List<Stay>() { },
            };
            Stay stay = new Stay()
            {
                ID = 1,
                Animal = dog,
                AnimalID = dog.ID,
                ArrivalDate = new DateTime(2019, 10, 18),
                AdoptionDate = null,
                CanBeAdopted = true,
                AdoptedBy = null,
                LodgingLocation = coolLocation,
                LodgingLocationID = coolLocation.ID,
                Comments = new List<Comment>(),
                Treatments = new List<Treatment>(),
            };

            // Setup for ValidateStay
            lodgingRepository.Setup(e => e.FindByID(coolLocation.ID))
                .Returns(coolLocation);

            animalRepository.Setup(e => e.FindByID(dog.ID))
                .Returns(dog);

            // Act
            stayService.Add(stay);

            //Assert
            stayRepository.Verify(x => x.Add(stay), Times.Once());
            stayRepository.Verify(x => x.Add(stay));
        }

        [Fact]
        public void MaxLodgingCapShouldNotBeOverwritten() 
        {
            //Arrange
            Mock<IStayRepository> stayRepository = new Mock<IStayRepository>();
            Mock<ILodgingRepository> lodgingRepository = new Mock<ILodgingRepository>();
            Mock<IAnimalRepository> animalRepository = new Mock<IAnimalRepository>();

            Animal dog = new Animal()
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
            Lodging fullLocation = new Lodging()
            {
                ID = 1,
                LodgingType = LodgingType.Group,
                MaxCapacity = 100,
                CurrentCapacity = 100,
                AnimalType = AnimalType.Cat,
                Stays = new List<Stay>() { },
            };
            Stay stay = new Stay()
            {
                ID = 1,
                Animal = dog,
                AnimalID = dog.ID,
                ArrivalDate = new DateTime(2019, 10, 18),
                AdoptionDate = null,
                CanBeAdopted = true,
                AdoptedBy = null,
                LodgingLocation = fullLocation,
                LodgingLocationID = fullLocation.ID,
                Comments = new List<Comment>(),
                Treatments = new List<Treatment>(),
            };

            lodgingRepository.Setup(e => e.FindByID(fullLocation.ID))
                .Returns(fullLocation);

            animalRepository.Setup(e => e.FindByID(dog.ID))
                .Returns(dog);

            stayRepository.Setup(e => e.FindByID(stay.ID))
                .Returns(stay);
            IStayService stayService = new StayService(stayRepository.Object, lodgingRepository.Object, animalRepository.Object);

            var ex = Assert.Throws<InvalidOperationException>(() => stayService.PlaceAnimal(stay, fullLocation));

            // Assert
            Assert.Equal("AS_Services", ex.Source); // Make sure the error is actually thrown in the service, not somewhere else
            Assert.Equal("Lodge is at max capacity", ex.Message);
        }

        // Calls Repo
        // Update
        // Delete
        // Index / Read
    }
}
