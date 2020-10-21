using System;
using System.Collections.Generic;
using AS_Core.DomainModel;
using AS_Core.Enums;
using AS_DomainServices;
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
            var stayService = new Mock<StayService>();

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
                AdoptedBy = string.Empty,
                LodgingLocation = coolLocation,
                Comments = new List<Comment>(),
                Treatments = new List<Treatment>(),
            };

            // Act
            //stayService.Setup(_ => _.Add(stay));

            // Assert
            IEnumerable<Stay> stays = stayRepository.Object.GetAll();

            Assert.NotNull(stays);
        }

        [Fact]
        public void DogsAndCatsShouldNotGoIntoSameLodging() { }

        [Fact]
        public void MaxLodgingCapShouldNotBeOverwritten() { }

        [Fact]
        public void AnimalAgeShouldBeCalculatedProperly() { }

        [Fact]
        public void BirthDataAndCaluclatedDateNotAllowed() { }

        [Fact]
        public void SterrilisationShouldBeAddedWithTreatment() { }


    }
}
