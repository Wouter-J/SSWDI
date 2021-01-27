using AS_Core.DomainModel;
using AS_Core.Enums;
using AS_DomainServices.Repositories;
using AS_DomainServices.Services;
using AS_Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AS_BusinessRules
{
    /// <summary>
    /// Business rule 02
    /// Non Sterilised Animals can't be added to Animals of the opposite gender in the same location
    /// </summary>
    public class BusinessRule2
    {
        [Fact]
        public void AnimalWithProperValuesShouldBeAdded() 
        {
            //Arrange
            Mock<IStayRepository> stayRepository = new Mock<IStayRepository>();
            Mock<ILodgingRepository> lodgingRepository = new Mock<ILodgingRepository>();
            Mock<IAnimalRepository> animalRepository = new Mock<IAnimalRepository>();

            IStayService stayService = new StayService(stayRepository.Object, lodgingRepository.Object, animalRepository.Object);

            Animal castratedDog = new Animal()
            {
                ID = 1,
                Name = "Doggo",
                Birthdate = new DateTime(2018, 10, 18),
                Age = 2,
                Description = "Good boi",
                AnimalType = AnimalType.Dog,
                Race = "Beautiful Doggos",
                Picture = "Goodboi.png",
                DateOfDeath = null,
                Castrated = true,
                ChildFriendly = ChildFriendly.Yes,
                ReasonGivenAway = "Too good a boi",
            };
            Lodging dogGroupLocation = new Lodging()
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
                Animal = castratedDog,
                AnimalID = castratedDog.ID,
                ArrivalDate = new DateTime(2019, 10, 18),
                AdoptionDate = null,
                CanBeAdopted = true,
                AdoptedBy = null,
                LodgingLocation = dogGroupLocation,
                LodgingLocationID = dogGroupLocation.ID,
                Comments = new List<Comment>(),
                Treatments = new List<Treatment>(),
            };

            // Setup for ValidateStay
            lodgingRepository.Setup(e => e.FindByID(dogGroupLocation.ID))
                .Returns(dogGroupLocation);

            animalRepository.Setup(e => e.FindByID(castratedDog.ID))
                .Returns(castratedDog);

            // Act
            stayService.Add(stay);

            //Assert
            stayRepository.Verify(x => x.Add(stay), Times.Once());
            stayRepository.Verify(x => x.Add(stay));

        }

        [Fact]
        public void NonCastratedAnimalCannotBeAddedToGroupLodge() 
        {
            //Arrange
            Mock<IStayRepository> stayRepository = new Mock<IStayRepository>();
            Mock<ILodgingRepository> lodgingRepository = new Mock<ILodgingRepository>();
            Mock<IAnimalRepository> animalRepository = new Mock<IAnimalRepository>();

            IStayService stayService = new StayService(stayRepository.Object, lodgingRepository.Object, animalRepository.Object);

            Animal notCastratedDog = new Animal()
            {
                ID = 1,
                Name = "Doggo",
                Birthdate = new DateTime(2018, 10, 18),
                Age = 2,
                Description = "Good boi",
                AnimalType = AnimalType.Dog,
                Race = "Beautiful Doggos",
                Picture = "Goodboi.png",
                DateOfDeath = null,
                Castrated = false,
                ChildFriendly = ChildFriendly.Yes,
                ReasonGivenAway = "Too good a boi",
            };
            Lodging dogGroupLocation = new Lodging()
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
                Animal = notCastratedDog,
                AnimalID = notCastratedDog.ID,
                ArrivalDate = new DateTime(2019, 10, 18),
                AdoptionDate = null,
                CanBeAdopted = true,
                AdoptedBy = null,
                LodgingLocation = dogGroupLocation,
                LodgingLocationID = dogGroupLocation.ID,
                Comments = new List<Comment>(),
                Treatments = new List<Treatment>(),
            };

            // Setup for ValidateStay
            lodgingRepository.Setup(e => e.FindByID(dogGroupLocation.ID))
                .Returns(dogGroupLocation);

            animalRepository.Setup(e => e.FindByID(notCastratedDog.ID))
                .Returns(notCastratedDog);

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => stayService.Add(stay));

            //Assert
            Assert.Equal("AS_Services", ex.Source); // Make sure the error is actually thrown in the service, not somewhere else
            Assert.Equal("Can't place non-castrated animal in a group location", ex.Message);
        }

        [Fact]
        public void NonCastratedAnimalCanBeAddedToIndividualLodge()
        {
            //Arrange
            Mock<IStayRepository> stayRepository = new Mock<IStayRepository>();
            Mock<ILodgingRepository> lodgingRepository = new Mock<ILodgingRepository>();
            Mock<IAnimalRepository> animalRepository = new Mock<IAnimalRepository>();

            IStayService stayService = new StayService(stayRepository.Object, lodgingRepository.Object, animalRepository.Object);

            Animal notCastratedDog = new Animal()
            {
                ID = 1,
                Name = "Doggo",
                Birthdate = new DateTime(2018, 10, 18),
                Age = 2,
                Description = "Good boi",
                AnimalType = AnimalType.Dog,
                Race = "Beautiful Doggos",
                Picture = "Goodboi.png",
                DateOfDeath = null,
                Castrated = false,
                ChildFriendly = ChildFriendly.Yes,
                ReasonGivenAway = "Too good a boi",
            };
            Lodging individualDogLodge = new Lodging()
            {
                ID = 1,
                LodgingType = LodgingType.Individual,
                MaxCapacity = 1,
                CurrentCapacity = 0,
                AnimalType = AnimalType.Dog,
                Stays = new List<Stay>() { },
            };
            Stay stay = new Stay()
            {
                ID = 1,
                Animal = notCastratedDog,
                AnimalID = notCastratedDog.ID,
                ArrivalDate = new DateTime(2019, 10, 18),
                AdoptionDate = null,
                CanBeAdopted = true,
                AdoptedBy = null,
                LodgingLocation = individualDogLodge,
                LodgingLocationID = individualDogLodge.ID,
                Comments = new List<Comment>(),
                Treatments = new List<Treatment>(),
            };

            // Setup for ValidateStay
            lodgingRepository.Setup(e => e.FindByID(individualDogLodge.ID))
                .Returns(individualDogLodge);

            animalRepository.Setup(e => e.FindByID(notCastratedDog.ID))
                .Returns(notCastratedDog);

            // Act
            stayService.Add(stay);

            //Assert
            stayRepository.Verify(x => x.Add(stay), Times.Once());
            stayRepository.Verify(x => x.Add(stay));
        }
    }
}
