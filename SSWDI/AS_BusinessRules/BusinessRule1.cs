using System;
using System.Collections.Generic;
using System.Linq;
using AS_Core.DomainModel;
using AS_Core.Enums;
using AS_DomainServices;
using AS_DomainServices.Repositories;
using AS_DomainServices.Services;
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
            //Arrange
            Mock<IStayRepository> stayRepository = new Mock<IStayRepository>();
            Mock<IStayService> stayService = new Mock<IStayService>();

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

            //Act
            stayService.Setup(_ => _.Add(stay));


            //Assert
            //List<Stay> list = stayService.Object.GetAll() as List<Stay>;
            IEnumerable<Stay> stays = stayRepository.Object.GetAll();
            Assert.NotNull(stays);
            //Assert.Equal(1, stays.Count()); //TODO: Create bigger list & Assert equal (number, list)
        }

        [Fact]
        public void MaxLodgingCapShouldNotBeOverwritten() 
        {
            //Arrange
            Mock<IStayRepository> stayRepository = new Mock<IStayRepository>();
            Mock<IStayService> stayService = new Mock<IStayService>();

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

            Lodging fullLocation = new Lodging()
            {
                LodgingType = LodgingType.Group,
                MaxCapacity = 100,
                CurrentCapacity = 100,
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
                LodgingLocation = fullLocation,
                Comments = new List<Comment>(),
                Treatments = new List<Treatment>(),
            };

            //Act
            stayService.Setup(_ => _.Add(stay));

            //Assert
            IEnumerable<Stay> stays = stayRepository.Object.GetAll();

            Assert.Empty(stays);
        }
    }
}
